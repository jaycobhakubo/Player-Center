using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using GTI.Modules.PlayerCenter.Business;
using GTI.Modules.PlayerCenter.Properties;
using GTI.Modules.PlayerCenter.Data;
using GTI.Modules.Shared;
using GTI.Modules.PlayerCenter.UI;
using System.Windows.Forms;

namespace GTI.Modules.PlayerCenter.Business
{
             class PlayerCenterThirdPartyInterface
     {
        #region VARIABLES

       private Player m_player;
       private bool m_isCardPinRequired;
       private int m_syncMode;
       private int m_interfaceId;
       private WaitForm m_waitForm = null;
       private MagneticCardReader m_magCardReader;
       private int m_pinlength;
         //private PlayerCenterSettings m_settings;

       private BackgroundWorker m_worker = null;
       private const string LogPrefix = "PlayerCenter - ";
       private readonly int m_operatorID;
       private object m_errorSync = new object();
       private Exception m_asyncException = null;
       private ConcurrentQueue<ServerMessage> pendingMessages = new ConcurrentQueue<ServerMessage>();
       private bool m_loggingEnabled;
       private object m_logSync = new object();
       public event EventHandler<GetPlayerEventArgs> GetPlayerCompletedAwardPoints;

       class PlayerLookupInfo
       {
           public int playerID = 0;
           public string CardNumber = string.Empty;
           public int PIN = 0;
           public bool UpdateCurrentPlayer = false;
           public bool WaitFormDisplayed = false;
       }

        #endregion
        #region CONSTRUCTOR

       public PlayerCenterThirdPartyInterface
            (Player player,
            int operatorId,
            bool isCardpinRequired,
            int syncMode,
            int interfaceId,
            int pinLength,
            MagneticCardReader magCardReader
            )
        {
            m_player = player;
            m_operatorID = operatorId;
            m_isCardPinRequired = isCardpinRequired;
            m_syncMode = syncMode;
            m_interfaceId = interfaceId;
            m_pinlength = pinLength;
            m_magCardReader = magCardReader;
            m_waitForm = new WaitForm();
          
            GetPlayerCompletedAwardPoints += _GetPlayerCompletedAwardPoints;
            PointsAwarded = 0M;
        }

        #endregion
        #region PROPERTIES

       public bool IsPointsAwardedSuccess { get; set; }
       public decimal PointsAwarded { get; set; }

       public GradientForm UICurrent { get; set; }

        public bool IsBusy
        {
            get { return (m_worker != null && m_worker.IsBusy); }                                 
        }

        public Player PlayerSelected
        {
            get { return m_player; }
            set { m_player = value; }
        }

        public Exception LastAsyncException
        {
            get
            {
                lock (m_errorSync)
                {
                    return m_asyncException;
                }
            }
            set
            {
                lock (m_errorSync)
                {
                    m_asyncException = value;
                }
            }
        }

        #endregion
        #region FUNCTION

        private delegate DialogResult CreatePlayerPromptDelegate(IWin32Window owner);

        /// <summary>
        /// Displays a message box asking if the user would like to create a 
        /// new player account.
        /// </summary>
        /// <param name="owner">Any object that implements IWin32Window 
        /// that represents the top-level window that will own any modal 
        /// dialog boxes.</param>
        /// <returns>The DialogResult of the MessageForm (Yes or No).</returns>
        private DialogResult PromptToCreatePlayer(IWin32Window owner)
        {
            DisplayMode displayMode;

            lock (PlayerCenterSettings.Instance.SyncRoot)
            {
                displayMode = PlayerCenterSettings.Instance.DisplayMode;
            }

            return MessageForm.Show(owner, displayMode, Resources.NoPlayersFound + Environment.NewLine + Resources.CreatePlayer, MessageFormTypes.YesNo);
        }
        //public int CreatePlayerForPOS(string magCardNum)
        //{
        //    if (string.IsNullOrEmpty(magCardNum) || magCardNum.Trim().Length == 0)
        //        throw new ArgumentException("magCardNum");

        //    CreateNewPlayerMessage createMsg = new CreateNewPlayerMessage();
        //    createMsg.JoinDate = DateTime.Now;
        //    createMsg.LastVisit = createMsg.JoinDate;
        //    createMsg.MagCardNumber = magCardNum;

        //    // Send the message.
        //    try
        //    {
        //        createMsg.Send();
        //    }
        //    catch (ServerCommException ex)
        //    {
        //        Log("Server communication error sending the 'CreateNewPlayer' message " + ex.ToString(), LoggerLevel.Severe);
        //        throw ex; // Don't repackage the ServerCommException
        //    }
        //    catch (ServerException ex)
        //    {
        //        Log("Error processing the 'CreateNewPlayer' message " + ex.ToString(), LoggerLevel.Severe);
        //        if ((int)ex.ReturnCode == 1)
        //            throw new PlayerCenterException(Resources.errorDupMagCard);
        //        else
        //            throw;
        //    }

        //    return createMsg.PlayerId;
        //}


        #region (GetPlayer) -> starting point

        internal void GetPlayer(string cardData, bool usingWaitForm = false)//This is force the player to create a new pin because third party requirements.
        {
            if (IsBusy) { return; } // only one player request at a time. It ability to queue them up currently works, but it's confusing for the user.

            int PIN = 0;      
  
            try
            {
                bool PINProblem = false;
                bool newPIN = false;

                do
                {
                    if (m_isCardPinRequired)// || (/* m_parent.CurrentSale.NeedPlayerCardPIN*/)) //we have done something requiring a player and a PIN
                    {
                        newPIN = true;
                        PIN = GetPlayerCardPINFromUser(true);
                    }

                    if (!newPIN) DisplayGettingPlayer(); //not blocking, tell the user we are working on it
                     
                    StartGetPlayer(cardData, PIN);//knc

                    if (newPIN) //we need to wait here until we get the player so we can validate the PIN
                    {
                        ShowWaitForm(UICurrent); // Block until we are done.
                        PINProblem = PIN != 0 && !m_player.ThirdPartyInterfaceDown && m_player.PlayerCardPINError; ;

                        if (PINProblem) MessageForm.Show(Resources.PlayerCardPINError);                         
                    }
                } 
                while (PINProblem);

                // m_parent.NeedPlayerCardPIN = false;
                m_player.WeHaveThePlayerCardPIN = PIN != 0 && !m_player.ThirdPartyInterfaceDown && !m_player.PlayerCardPINError && m_player.PointsUpToDate;

                if (newPIN && m_player.WeHaveThePlayerCardPIN) //save the PIN with the player card number
                {
                    StartSetPlayerCardPIN(m_player.Id, PIN);
                    ShowWaitForm(UICurrent); // Block until we are done.
                }
            }
            catch (Exception ex)
            {
                Log("Failed to get the player/machine: " + ex.Message, LoggerLevel.Severe);
                //MessageForm.Show(this, m_displayMode, string.Format(CultureInfo.CurrentCulture, (m_parent.Settings.EnableAnonymousMachineAccounts) ? Resources.GetMachineFailed : Resources.GetPlayerFailed, ex.Message));
            }
        }

        int GetPlayerCardPINFromUser(bool throwOnCancel = false)
        {
            int PIN = 0;
            bool inputCanceled = false;

            if (!m_isCardPinRequired)
                return 0;

            bool MSRActive = m_magCardReader.ReadingCards;

            if (MSRActive)
                m_magCardReader.EndReading();

            //we need a PIN, get it and get the player points to test the PIN
            GTI.Modules.Shared.UI.NumericInputForm PINEntry = new Shared.UI.NumericInputForm(m_pinlength);
            PINEntry.UseDecimalKey = false;
            PINEntry.Password = true;
            PINEntry.Description = Resources.EnterPlayerCardPIN;

            do
            {
                inputCanceled = PINEntry.ShowDialog(UICurrent) == System.Windows.Forms.DialogResult.Cancel;

                if (!inputCanceled)
                    PIN = Convert.ToInt32(PINEntry.DecimalResult);
            } while (!inputCanceled && PIN == 0);

            PINEntry.Dispose();

            if (MSRActive)
                m_magCardReader.BeginReading();

            if (inputCanceled && throwOnCancel)
                throw new PlayerCenterException(Resources.PlayerCardPINEntryCanceled);

            return PIN;
        }

        private void DisplayGettingPlayer()
        {

            if (UICurrent.InvokeRequired) // if it's not coming in on the UI thread, move the work to the UI thread.
            {
                UICurrent.BeginInvoke((Action)DisplayGettingPlayer);
                return;
            }
        }

#endregion           
        #region Create Player

        public int CreatePlayerForPOS(string magCardNum)
        {
            if (string.IsNullOrEmpty(magCardNum) || magCardNum.Trim().Length == 0)
                throw new ArgumentException("magCardNum");

            CreateNewPlayerMessage createMsg = new CreateNewPlayerMessage();
            createMsg.JoinDate = DateTime.Now;
            createMsg.LastVisit = createMsg.JoinDate;
            createMsg.MagCardNumber = magCardNum;

            // Send the message.
            try
            {
                createMsg.Send();
            }
            catch (ServerCommException ex)
            {
                Log("Server communication error sending the 'CreateNewPlayer' message " + ex.ToString(), LoggerLevel.Severe);
                throw ex; // Don't repackage the ServerCommException
            }
            catch (ServerException ex)
            {
                Log("Error processing the 'CreateNewPlayer' message " + ex.ToString(), LoggerLevel.Severe);
                if ((int)ex.ReturnCode == 1)
                    throw new PlayerCenterException(Resources.errorDupMagCard);
                else
                    throw;
            }

            return createMsg.PlayerId;
        }

        #endregion
        #region Supporting

        private void DoneProcessingMessage()
        {
            ServerMessage temp;
            pendingMessages.TryDequeue(out temp);

            if (pendingMessages.Count == 0) { }
        }

        internal void ShowWaitForm(IWin32Window owner)
        {
            if (m_waitForm != null)
                m_waitForm.ShowDialog(owner);
        }


        internal static void ForceEnglish()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
        }

        internal void SetupThread()
        {
            lock (PlayerCenterSettings.Instance.SyncRoot)
            {
                if (PlayerCenterSettings.Instance.ForceEnglish)
                    ForceEnglish();
                else
                    Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            }
            System.Windows.Forms.Application.DoEvents();
        }


        internal string GetPlayerName()
        {
            var FullName = "";
            if (m_player != null)
            {
                FullName = (m_player.FirstName.Length != 0) ? m_player.FirstName + " " : "";
                FullName += (m_player.MiddleInitial.Length != 0) ? m_player.MiddleInitial + " " : "";
                FullName += (m_player.LastName.Length != 0) ? m_player.LastName : "";
            }
            return FullName;
        }

        private bool ShouldStartProcessingMessage(ServerMessage message)
        {
            bool addMessage = true; // defaults to true as undefined messages should always be added to the queue to be processed
            lock (pendingMessages) // keep the "any" check and the enqueue atomic
            {
                if (message is FindPlayerByCardMessage) // US4809
                {
                    string magCardNum = (message as FindPlayerByCardMessage).MagCardNumber;

                    addMessage = !pendingMessages.Any(x =>
                    {
                        if (!(x is FindPlayerByCardMessage))
                            return false;
                        else
                            return String.Equals((x as FindPlayerByCardMessage).MagCardNumber, magCardNum, StringComparison.CurrentCultureIgnoreCase);
                    });
                }

                if (addMessage)
                {
                    pendingMessages.Enqueue(message);
                    //IsBusy = true;
                }
            }
            return addMessage;
        }

        internal bool Log(string message, LoggerLevel level)
        {
            lock (m_logSync)
            {
                if (m_loggingEnabled)
                {
                    StackFrame frame = new StackFrame(1, true);
                    string fileName = frame.GetFileName();
                    int lineNumber = frame.GetFileLineNumber();
                    //message = ThirdPartyGetPlayerPerCardPin.LogPrefix + message; //PlayerManager.LogPrefix + message;

                    try
                    {
                        switch (level)
                        {
                            case LoggerLevel.Severe:
                                Logger.LogSevere(message, fileName, lineNumber);
                                break;

                            case LoggerLevel.Warning:
                                Logger.LogWarning(message, fileName, lineNumber);
                                break;

                            default:
                            case LoggerLevel.Information:
                                Logger.LogInfo(message, fileName, lineNumber);
                                break;

                            case LoggerLevel.Configuration:
                                Logger.LogConfig(message, fileName, lineNumber);
                                break;

                            case LoggerLevel.Debug:
                                Logger.LogDebug(message, fileName, lineNumber);
                                break;

                            case LoggerLevel.Message:
                                Logger.LogMessage(message, fileName, lineNumber);
                                break;

                            case LoggerLevel.SQL:
                                Logger.LogSql(message, fileName, lineNumber);
                                break;
                        }

                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
                else
                    return false;
            }
        }

#endregion
        #endregion
        #region FUNCTION -> (thread)
        #region StartGetPlayer(from GetPlayer fn)

        internal void StartGetPlayer(int playerId)
        {
            StartGetPlayer(playerId, 0);
        }

        internal void StartGetPlayer(int playerId, int PIN)
        {
            PlayerLookupInfo playerInfo = new PlayerLookupInfo();
            playerInfo.playerID = playerId;
            playerInfo.PIN = PIN;

            m_waitForm.Message = Resources.WaitFormGettingPlayer;
            m_worker = new BackgroundWorker();
            m_worker.WorkerReportsProgress = true;
            m_worker.WorkerSupportsCancellation = false;
            m_worker.DoWork += new DoWorkEventHandler(SendGetPlayer);
            m_worker.ProgressChanged += new ProgressChangedEventHandler(m_waitForm.ReportProgress);
            m_worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(GetPlayerCompleteAwardPoints);
            m_worker.RunWorkerAsync(playerInfo);
        }

        internal void StartGetPlayer(string magCardNumber, int PIN)
        {
            PlayerLookupInfo playerInfo = new PlayerLookupInfo();
            playerInfo.CardNumber = magCardNumber;
            playerInfo.PIN = PIN;

            m_waitForm.Message = Resources.WaitFormGettingPlayer;
            m_worker = new BackgroundWorker();
            m_worker.WorkerReportsProgress = true;
            m_worker.WorkerSupportsCancellation = false;
            m_worker.DoWork += new DoWorkEventHandler(SendGetPlayer);
            m_worker.ProgressChanged += new ProgressChangedEventHandler(m_waitForm.ReportProgress);
            m_worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(GetPlayerCompleteAwardPoints);
            m_worker.RunWorkerAsync(playerInfo);
        }

        #endregion
        #region (dowork)


         
        private void SendGetPlayer(object sender, DoWorkEventArgs e)
        {
            SetupThread();
            var enableMachineAccounts = false;
            var promptForCreate         = false ;
            var enterRaffle = false;

            //lock (m_settings.SyncRoot)
            //{
            //    // TTP 50114
            //    enableMachineAccounts = m_settings.EnableAnonymousMachineAccounts;
            //    promptForCreate = m_settings.PromptForPlayerCreation; // PDTS 1044
            //    enterRaffle = m_settings.SwipeEntersRaffle;
            //}

            var sentPlayer = (PlayerLookupInfo)e.Argument;
            var playerId = sentPlayer.playerID;
            var magCardNum = sentPlayer.CardNumber;
            var PIN = sentPlayer.PIN;
            var updatePlayer = sentPlayer.UpdateCurrentPlayer;
            var justSynced = false;

            if (!m_isCardPinRequired) PIN = 0;

            if (playerId == 0)
            {
                FindPlayerByCardMessage cardMsg = new FindPlayerByCardMessage();
                cardMsg.MagCardNumber = magCardNum;
                cardMsg.PIN = PIN;
                cardMsg.SyncPlayerWithThirdParty = m_syncMode == 0;

                if (!ShouldStartProcessingMessage(cardMsg))
                {
                    Log("FindPlayerByCardMessage with same card already being processed, ignored extra call", LoggerLevel.Message);
                    return;
                }

                try { cardMsg.Send(); }  // Send the message.
                catch (ServerCommException) { throw; }// // Don't repackage the ServerCommException}
                catch (Exception ex) { throw new PlayerCenterException(string.Format(Resources.GetPlayerFailed, ServerExceptionTranslator.FormatExceptionMessage(ex)), ex); }

                if (cardMsg.PlayerId == 0)
                {
                    bool noSyncWithThirdPartySoAddPlayer = m_interfaceId != 0 && (!cardMsg.SyncPlayerWithThirdParty || cardMsg.ThirdPartyInterfaceDown);

                    if (!enableMachineAccounts /*&& IsPlayerCenterInitialized */&& !string.IsNullOrEmpty(magCardNum) && ((promptForCreate && m_interfaceId == 0) || noSyncWithThirdPartySoAddPlayer))
                    {
                        bool doCreate = false;

                        if (noSyncWithThirdPartySoAddPlayer)
                        {
                            doCreate = true;
                        }
                        else
                        {
                            if (m_waitForm != null && !m_waitForm.IsDisposed && m_waitForm.InvokeRequired) // if we're using the wait form
                            {
                           CreatePlayerPromptDelegate prompt = new CreatePlayerPromptDelegate(PromptToCreatePlayer);
                                doCreate = ((DialogResult)m_waitForm.Invoke(prompt, new object[] { m_waitForm }) == DialogResult.Yes);
                            }
                            //else if (m_sellingForm != null && m_sellingForm.InvokeRequired) // if there's no wait form, but still requires the UI thread
                            //{
                            //    CreatePlayerPromptDelegate prompt = new CreatePlayerPromptDelegate(PromptToCreatePlayer);
                            //    doCreate = ((DialogResult)m_sellingForm.Invoke(prompt, new object[] { m_sellingForm }) == DialogResult.Yes);
                            //}
                            else // Just try it? Hopefully it doesn't get here if the UI thread is required
                            {
                                doCreate = (PromptToCreatePlayer(m_waitForm) == DialogResult.Yes);
                            }
                        }

                        if (doCreate)
                            playerId = CreatePlayerForPOS(magCardNum);
                        else
                            throw new PlayerCenterUserCancelException(Resources.NoPlayersFound);
                    }
                    else
                    {
                        throw new PlayerCenterException(/*enableMachineAccounts ? Resources.NoMachineFound :*/ Resources.NoPlayersFound);
                    }
                }
                else
                {
                    playerId = cardMsg.PlayerId;

                    if (cardMsg.SyncPlayerWithThirdParty && cardMsg.PointsUpToDate)
                        justSynced = true;
                }
                //    bool noSyncWithThirdPartySoAddPlayer = m_interfaceId != 0 && (!cardMsg.SyncPlayerWithThirdParty || cardMsg.ThirdPartyInterfaceDown);

                //    if (!string.IsNullOrEmpty(magCardNum) && ((m_interfaceId == 0) || noSyncWithThirdPartySoAddPlayer))
                //    {
                //        bool doCreate = false;
                //        if (noSyncWithThirdPartySoAddPlayer) { doCreate = true; } else { }

                //        if (doCreate)
                //            playerId = CreatePlayerForPOS(magCardNum);
                //        else
                //            throw new PlayerCenterUserCancelException(Resources.NoPlayersFound);
                //    }
                //    else { throw new PlayerCenterException(Resources.NoPlayersFound); }
                //}
                //else
                //{
                //    playerId = cardMsg.PlayerId;
                //    if (cardMsg.SyncPlayerWithThirdParty && cardMsg.PointsUpToDate) justSynced = true;//(if invalid pin = true /false) ; if valid pin = true/true                      
                //}
            }

            Player player = null;

            if (!enableMachineAccounts)
            {
                PlayerCardSwipeMessage swipeMsg = new PlayerCardSwipeMessage(playerId, null, enterRaffle, PIN);

                try { swipeMsg.Send(); }
                catch (ServerCommException) { throw; }
            }

            try
            {
                bool syncPlayer = !justSynced && (m_syncMode == 0 || updatePlayer); //realtime or need points
                player = new Player(playerId, m_operatorID, PIN, syncPlayer, justSynced);//syncPlayer, justSynced If invalid pin = true/false ; if valisd pin = false /true
            }
            catch (ServerCommException) { throw; }
            catch (ServerException exc) { throw new PlayerCenterException(string.Format(CultureInfo.CurrentCulture, Resources.GetPlayerFailed, ServerExceptionTranslator.FormatExceptionMessage(exc)) + " " + string.Format(CultureInfo.CurrentCulture, Resources.MessageName, exc.Message), exc); } // TTP 50114              
            catch (Exception exc) { throw new PlayerCenterException(string.Format(CultureInfo.CurrentCulture, Resources.GetPlayerFailed, ServerExceptionTranslator.FormatExceptionMessage(exc)), exc); }
            e.Result = new Tuple<Player, bool, bool>(player, updatePlayer, sentPlayer.WaitFormDisplayed);

        }

        #endregion
        #region (workcompleted)

        private void GetPlayerCompleteAwardPoints(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null && e.Result == null) { return; }

            try
            {
                LastAsyncException = e.Error;
                Player player = null;

                if (e.Error == null)
                {
                    Tuple<Player, bool, bool> result = (Tuple<Player, bool, bool>)e.Result;
                    player = result.Item1;
                    bool updatePoints = result.Item2;

                    if (updatePoints)//false for both valid pin and invalid pin
                    {
                        if (m_player != null) //we have one, update it
                        {
                            m_player.PlayerCardPINError = player.PlayerCardPINError;
                            m_player.PointsBalance = player.PointsBalance;
                            m_player.PointsUpToDate = player.PointsUpToDate;
                        }
                    }
                    else
                    {
                        try
                        {
                            m_player = player; //Do we want to assign the new value?
                        }
                        catch (PlayerCenterException ex)
                        {
                            //PlayerManager.Instance.Message1(ex.Message);//knc
                        }
                    }

                    if (!player.PlayerCardPINError && player.ErrorMessage != string.Empty) { }
                    //PlayerManager.Instance.Message2(player.ErrorMessage);//knc
                }

                EventHandler<GetPlayerEventArgs> handler = GetPlayerCompletedAwardPoints;
                if (handler != null)
                    handler(this, new GetPlayerEventArgs(player, LastAsyncException));
            }
            catch (Exception ex)
            {
                Log("Error finishing player lookup " + ex.ToString(), LoggerLevel.Severe);
            }
            finally
            {
                // Close the wait form.
                if (m_waitForm != null && !m_waitForm.IsDisposed)
                    m_waitForm.CloseForm();

                DoneProcessingMessage(); // notify that we're done processing the message.
            }
        }

        #endregion
        #region StartSetPlayerCardPIN(thread)
        internal void StartSetPlayerCardPIN(int playerId, int PIN)
        {
            PlayerLookupInfo playerInfo = new PlayerLookupInfo();

            playerInfo.playerID = playerId;
            playerInfo.PIN = PIN;
            m_waitForm.Message = Resources.WaitFormUpdatingPlayer;
            m_worker = new BackgroundWorker();
            m_worker.WorkerReportsProgress = true;
            m_worker.WorkerSupportsCancellation = false;
            m_worker.DoWork += new DoWorkEventHandler(SendGetSetPlayerCardPIN);
            m_worker.ProgressChanged += new ProgressChangedEventHandler(m_waitForm.ReportProgress);
            m_worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(GetSetPlayerCardPINComplete);
            m_worker.RunWorkerAsync(playerInfo);

        }
        #endregion
        #region (dowork)

        private void SendGetSetPlayerCardPIN(object sender, DoWorkEventArgs e)
        {
            SetupThread();

            // Unbox the argument.
            int playerId = ((PlayerLookupInfo)(e.Argument)).playerID;
            int PIN = ((PlayerLookupInfo)(e.Argument)).PIN;

            // Are we getting the PIN?
            if (PIN == -1) //yes
            {
                GetPlayerMagCardPINMessage PINMsg = new GetPlayerMagCardPINMessage(playerId);

                PINMsg.Send();

                PIN = PINMsg.PlayerMagCardPIN;
            }
            else //setting the PIN
            {
                SetPlayerMagCardPINMessage PINMsg = new SetPlayerMagCardPINMessage(playerId, PIN);

                PINMsg.Send();
            }

            e.Result = new Tuple<int, int>(playerId, PIN);
        }

        #endregion
        #region (wrokcompleted)
        private void GetSetPlayerCardPINComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            // Set the error that occurred (if any).
            LastAsyncException = e.Error;

            if (e.Error == null)
            {
                int playerId = ((Tuple<int, int>)e.Result).Item1;
                int PIN = ((Tuple<int, int>)e.Result).Item2;

                if (PIN > 0 && m_player != null && m_player.Id == playerId)
                    m_player.PlayerCardPIN = PIN;
            }

            // Close the wait form.
            m_waitForm.CloseForm();
        }

        #endregion
        #endregion
        #region EVENTS

        private void _GetPlayerCompletedAwardPoints(object sender, GetPlayerEventArgs e)
        {
            if (e.Player != null)
            {
                m_player = e.Player;
                if (m_interfaceId != 0 && m_player.ThirdPartyInterfaceDown)
                    throw new PlayerCenterException(Resources.PlayerTrackingInterfaceDown);
            }
            else if (e.Error != null)
            {
                if (e.Error is ServerCommException) { }
                    //PlayerManager.Instance.ServerCommFailed();//knc
            }
        }

        #endregion
        #region NOT Sure if this is being called

        internal void StartGetPlayerCardPIN(int playerId)
        {
            PlayerLookupInfo playerInfo = new PlayerLookupInfo();

            playerInfo.playerID = playerId;
            playerInfo.PIN = -1;

            m_waitForm.Message = Resources.WaitFormUpdatingPlayer;
            m_worker = new BackgroundWorker();
            m_worker.WorkerReportsProgress = true;
            m_worker.WorkerSupportsCancellation = false;
            m_worker.DoWork += new DoWorkEventHandler(SendGetSetPlayerCardPIN);
            m_worker.ProgressChanged += new ProgressChangedEventHandler(m_waitForm.ReportProgress);
            m_worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(GetSetPlayerCardPINComplete);
            m_worker.RunWorkerAsync(playerInfo);
        }

        #endregion 

    }



    public class GetPlayerEventArgs : EventArgs
    {

     
        public GetPlayerEventArgs(Player player)
        {
            Player = player;
        }

    
        public GetPlayerEventArgs(Exception ex)
        {
            Error = ex;
        }

     
        public GetPlayerEventArgs(Player player, Exception ex)
        {
            Player = player;
            Error = ex;
        }
      
        public Player Player
        {
            get;
            set;
        }
  
        public Exception Error
        {
            get;
            set;
        }
    }
}
