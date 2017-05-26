#region Copyright
// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2008 GameTech
// International, Inc.
#endregion


using System;
using System.Drawing;
using System.Windows.Forms;
using GTI.Modules.PlayerCenter.Business;
using GTI.Modules.Shared;
using GTI.Modules.PlayerCenter.Properties;
using GTI.Modules.PlayerCenter.Data;
using System.Globalization;
using System.ComponentModel; 


namespace GTI.Modules.PlayerCenter.UI
{
    public partial class AwardPoints : EliteGradientForm
    {
        #region Members

        private readonly int m_playerId;
        private bool m_isPlayerPinRequiredForPointAdjustment = false;
        private  int m_playerPinRequiredForPointAdjustmentLength = 0;
        private MagneticCardReader m_magCardReader;
        Player m_player;

        #endregion

        #region Constructors

        public AwardPoints
            (
            string playerName, 
            int playerId ,
            Player player
            )
        {
            InitializeComponent();
            m_player = player;
            lblPlayerNameIndicator.Text = playerName;
            m_playerId = playerId;
            //m_isPlayerPinRequiredForPointAdjustment = isPlayerPinRequired;
            //m_playerPinRequiredForPointAdjustmentLength = playerPinLen;
            PointsAwarded = 0M;
        }

        #endregion

        public void SetInterfaceSetting(bool isPlayerPinRequired, int playerPinLen, MagneticCardReader magneticCardReader)
        {
            m_isPlayerPinRequiredForPointAdjustment = isPlayerPinRequired;
            m_playerPinRequiredForPointAdjustmentLength = playerPinLen;
            m_magCardReader = magneticCardReader;
        }

        #region Events

        private void ManualAwardPoints_Load(object sender, EventArgs e)
        {        
                FormBorderStyle = FormBorderStyle.FixedSingle;
                BackgroundImage = null;
                DrawGradient = true;
                acceptImageButton.ImageNormal = Resources.BlueButtonUp;
                acceptImageButton.ImagePressed = Resources.BlueButtonDown;
                cancelImageButton.ImageNormal = Resources.BlueButtonUp;
                cancelImageButton.ImagePressed = Resources.BlueButtonDown;
        }      

        private void cancelImageButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        
        private class PlayerLookupInfo
        {
            public int playerID = 0;
            public string CardNumber = string.Empty;
            public int PIN = 0;
            public bool UpdateCurrentPlayer = false;
            public bool WaitFormDisplayed = false;
        }
  

        internal void StartUpdatePlayerPoints(int PIN)//_knc1
        {
    

            PlayerLookupInfo playerInfo = new PlayerLookupInfo();

            playerInfo.playerID = m_playerId;
            playerInfo.PIN = PIN;
            playerInfo.UpdateCurrentPlayer = true;

            //SendGetPlayer(playerInfo);
            //GetPlayerComplete();
            //RunWorker(m_settings.EnableAnonymousMachineAccounts ? Resources.WaitFormGettingMachine : Resources.WaitFormGettingPlayer,
            //          new DoWorkEventHandler(SendGetPlayer), (object)playerInfo, new RunWorkerCompletedEventHandler(GetPlayerComplete));
        }

        private void acceptImageButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbxPointsAwarded.Text))
            {
                //Check if the player required pin
                if (m_isPlayerPinRequiredForPointAdjustment)
                {

                    int PIN = 0;
                    bool PINProblem = false;
                    bool newPIN = false;
                    do
                    {
                        if (PINProblem)
                            MessageForm.Show(Resources.PlayerCardPINError);

                        //if (m_parent.Settings.ThirdPartyPlayerInterfaceUsesPIN && !m_parent.CurrentSale.Player.WeHaveThePlayerCardPIN && (m_parent.Settings.ThirdPartyPlayerInterfaceNeedPINForPoints || m_parent.Settings.ThirdPartyPlayerInterfaceGetPINWhenCardSwiped))
                      
                            newPIN = true;

                            PIN = GetPlayerCardPINFromUser(true);//4_knc

                            if (PIN == 0) //PIN entry canceled.
                                return ;


                            //if (PIN == m_player.PinNumber)
                            //{

                            //}


                        // Spawn a new thread to find the player and wait until done.
                  StartUpdatePlayerPoints(PIN);
                       ShowWaitForm(this); // Block until we are done.

                        //PINProblem = PIN != 0 && !m_parent.CurrentSale.Player.ThirdPartyInterfaceDown && (m_parent.CurrentSale.Player.PlayerCardPINError || !m_parent.CurrentSale.Player.PointsUpToDate);
                       PINProblem = PIN != 0 && 1 == 0; //PIN != 0 && !m_parent.CurrentSale.Player.ThirdPartyInterfaceDown && (m_parent.CurrentSale.Player.PlayerCardPINError || !m_parent.CurrentSale.Player.PointsUpToDate);
                       var c = 1;
                    } while (PINProblem);
                }

                IsPointsAwardedSuccess = false;
                PointsAwarded = 0M;
                var tempManualPlayerPoints = txtbxPointsAwarded.Text;
                SetPlayerPointsAwarded msg = new SetPlayerPointsAwarded(m_playerId, tempManualPlayerPoints);               
                msg.Send();
                if (msg.ReturnCode == (int)GTIServerReturnCode.Success)
                {
                    IsPointsAwardedSuccess = true;
                    PointsAwarded = decimal.Parse(tempManualPlayerPoints, CultureInfo.InvariantCulture);
                }
               
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        //private void SendGetPlayer(PlayerLookupInfo playerInfo)//_knc1
        //{
   

        //    // Unbox the argument.
        //    PlayerLookupInfo sentPlayer = new PlayerLookupInfo();
        //    int playerId = sentPlayer.playerID;
        //    string magCardNum = sentPlayer.CardNumber;
        //    int PIN = sentPlayer.PIN;
        //    bool updatePlayer = sentPlayer.UpdateCurrentPlayer;
        //    bool justSynced = false;

        //    if (!m_isPlayerPinRequiredForPointAdjustment)
        //        PIN = 0;

           
        //        if (cardMsg.PlayerId == 0)
        //        {
        //            // PDTS 1044
        //            // Can we create the account?
        //            bool noSyncWithThirdPartySoAddPlayer = Settings.ThirdPartyPlayerInterfaceID != 0 && (!cardMsg.SyncPlayerWithThirdParty || cardMsg.ThirdPartyInterfaceDown);

        //            if (!enableMachineAccounts && IsPlayerCenterInitialized && !string.IsNullOrEmpty(magCardNum) && ((promptForCreate && Settings.ThirdPartyPlayerInterfaceID == 0) || noSyncWithThirdPartySoAddPlayer))
        //            {
        //                bool doCreate = false;

        //                if (noSyncWithThirdPartySoAddPlayer)
        //                {
        //                    doCreate = true;
        //                }
        //                else
        //                {
        //                    if (m_waitForm != null && !m_waitForm.IsDisposed && m_waitForm.InvokeRequired) // if we're using the wait form
        //                    {
        //                        CreatePlayerPromptDelegate prompt = new CreatePlayerPromptDelegate(PromptToCreatePlayer);
        //                        doCreate = ((DialogResult)m_waitForm.Invoke(prompt, new object[] { m_waitForm }) == DialogResult.Yes);
        //                    }
        //                    else if (m_sellingForm != null && m_sellingForm.InvokeRequired) // if there's no wait form, but still requires the UI thread
        //                    {
        //                        CreatePlayerPromptDelegate prompt = new CreatePlayerPromptDelegate(PromptToCreatePlayer);
        //                        doCreate = ((DialogResult)m_sellingForm.Invoke(prompt, new object[] { m_sellingForm }) == DialogResult.Yes);
        //                    }
        //                    else // Just try it? Hopefully it doesn't get here if the UI thread is required
        //                    {
        //                        doCreate = (PromptToCreatePlayer(m_waitForm) == DialogResult.Yes);
        //                    }
        //                }

        //                if (doCreate)
        //                    playerId = m_playerCenter.CreatePlayerForPOS(magCardNum);
        //                else
        //                    throw new POSUserCancelException(Resources.NoPlayersFound);
        //            }
        //            else
        //            {
        //                throw new POSException(enableMachineAccounts ? Resources.NoMachineFound : Resources.NoPlayersFound);
        //            }
        //        }
        //        else
        //        {
        //            playerId = cardMsg.PlayerId;

        //            if (cardMsg.SyncPlayerWithThirdParty && cardMsg.PointsUpToDate)//_knc
        //                justSynced = true;
        //        }
        //    }

        //    Player player = null;
        //    int opId;

        //    lock (m_currentOp.SyncRoot)
        //    {
        //        opId = m_currentOp.Id;
        //    }

        //    if (!enableMachineAccounts)
        //    {
        //        PlayerCardSwipeMessage swipeMsg = new PlayerCardSwipeMessage(playerId, null, enterRaffle, PIN);

        //        try
        //        {
        //            swipeMsg.Send();
        //        }
        //        catch (ServerCommException)
        //        {
        //            throw; // Don't repackage the ServerCommException
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new POSException(string.Format(CultureInfo.CurrentCulture, Resources.CardSwipeFailed, ServerExceptionTranslator.FormatExceptionMessage(ex)), ex);
        //        }
        //    }
        //    // END: DE2580

        //    try
        //    {
        //        bool syncPlayer = !justSynced && (m_settings.ThirdPartyPlayerSyncMode == 0 || updatePlayer); //realtime or need points

        //        player = new Player(playerId, opId, PIN, syncPlayer, justSynced);
        //    }
        //    catch (ServerCommException)
        //    {
        //        throw; // Don't repackage the ServerCommException
        //    }

        //    e.Result = new Tuple<Player, bool, bool>(player, updatePlayer, sentPlayer.WaitFormDisplayed);
        //}

        private WaitForm m_waitForm;
        internal void ShowWaitForm(IWin32Window owner)
        {
            if (m_waitForm != null)
                m_waitForm.ShowDialog(owner);
        }

        //private bool Reading

        int GetPlayerCardPINFromUser(bool throwOnCancel = false)
        {

            int PIN = 0;
            bool inputCanceled = false;

            if (!m_isPlayerPinRequiredForPointAdjustment)
                return 0;

            bool MSRActive = m_magCardReader.ReadingCards;

            if (MSRActive)
                m_magCardReader.EndReading();

            //we need a PIN, get it and get the player points to test the PIN
            GTI.Modules.Shared.UI.NumericInputForm PINEntry = new Shared.UI.NumericInputForm(m_playerPinRequiredForPointAdjustmentLength);//knc
            PINEntry.UseDecimalKey = false;
            PINEntry.Password = true;
            PINEntry.Description = Resources.EnterPlayerCardPIN;

            do
            {
                inputCanceled = PINEntry.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel;

                if (!inputCanceled)
                    PIN = Convert.ToInt32(PINEntry.DecimalResult);
            } while (!inputCanceled && PIN == 0);

            PINEntry.Dispose();

            if (MSRActive)
                m_magCardReader.BeginReading();

            if (inputCanceled && throwOnCancel)
                throw new PlayerCenterException("Player card PIN entry canceled");

            return PIN;
        }

        #endregion


        #region Properties

        public bool IsPointsAwardedSuccess { get; set; }
        public decimal PointsAwarded { get; set; }
        //public bool IsPlayerPinRequiredForPointAdjustment { get; set; }
        //public int PlayerPinRequiredForPointAdjustmentLength { get; set; }

        #endregion

    }
}