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


namespace GTI.Modules.PlayerCenter.UI
{
    public partial class AwardPoints : EliteGradientForm
    {
        #region Members

        private readonly int m_playerId;
        private PlayerManager m_parent;
        private Player m_player;
        #endregion

        #region Constructors

        public AwardPoints(PlayerManager parent)//No need to send the whole player object I just need this 2.
        {
            InitializeComponent();
            m_player = m_parent.CurrentPlayer;
            m_player = (m_parent.CurrentPlayer != null ? m_parent.CurrentPlayer : m_parent.LastPlayerFromServer);
            lblPlayerNameIndicator.Text = GetPlayerName();
            m_playerId = m_player.Id;
            PointsAwarded = 0M;
        }


        //US2100
        private string GetPlayerName()
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

        #endregion

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

        private void acceptImageButton_Click(object sender, EventArgs e)
        {




            if (!string.IsNullOrEmpty(txtbxPointsAwarded.Text))
            {
                PointsAwarded = 0M;
                var tempManualPlayerPoints = txtbxPointsAwarded.Text;
                SetPlayerPointsAwarded msg = new SetPlayerPointsAwarded(m_playerId, tempManualPlayerPoints);               
                msg.Send();
                if (msg.ReturnCode == (int)GTIServerReturnCode.Success)
                {
                    IsPointsAwardedSuccess = true;
                    PointsAwarded = decimal.Parse(tempManualPlayerPoints, CultureInfo.InvariantCulture);
                }
                else
                {
                    IsPointsAwardedSuccess = false;
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }


        public void GetPlayer(string cardData, bool usingWaitForm = false)//This is force the player to create a new pin because third party requirements.
        {
            if (m_parent.IsBusy) // only one player request at a time. It ability to queue them up currently works, but it's confusing for the user.
            {
                return;
            }

            int PIN = 0;

            //if (m_parent.CurrentSale != null && m_parent.CurrentSale.Player != null && cardData != m_parent.CurrentSale.Player.PlayerCard) //changing player, abort current sale first
            //    StartOver(true);

            // Spawn a new thread to find the player and wait until done.
            try
            {
                bool PINProblem = false;
                bool newPIN = false;

                do
                {
                    if (m_parent.Settings.PlayerInterfaceIsPinRequiredForPointAdjustment)// || (/* m_parent.CurrentSale.NeedPlayerCardPIN*/)) //we have done something requiring a player and a PIN
                    {
                        newPIN = true;

                        PIN = GetPlayerCardPINFromUser(true);
                    }

                    //we always block when using a PIN since we need to validate the PIN before moving on
                    if (!newPIN)
                        DisplayGettingPlayer(); //not blocking, tell the user we are working on it

                    m_parent.StartGetPlayer(cardData, PIN);//knc

                    if (newPIN) //we need to wait here until we get the player so we can validate the PIN
                    {
                        m_parent.ShowWaitForm(this); // Block until we are done.

                        if (m_parent.CurrentSale != null && m_parent.CurrentSale.Player != null)
                        {
                            PINProblem = PIN != 0 && !m_parent.CurrentSale.Player.ThirdPartyInterfaceDown && m_parent.CurrentSale.Player.PlayerCardPINError;

                            if (PINProblem)
                                MessageForm.Show(Resources.PlayerCardPINError);
                        }
                    }
                } while (PINProblem);

                if (m_parent.CurrentSale != null && m_parent.CurrentSale.Player != null)
                {
                    m_parent.CurrentSale.NeedPlayerCardPIN = false;
                    m_parent.CurrentSale.Player.WeHaveThePlayerCardPIN = PIN != 0 && !m_parent.CurrentSale.Player.ThirdPartyInterfaceDown && !m_parent.CurrentSale.Player.PlayerCardPINError && m_parent.CurrentSale.Player.PointsUpToDate;

                    if (newPIN && m_parent.CurrentSale.Player.WeHaveThePlayerCardPIN) //save the PIN with the player card number
                    {
                        m_parent.StartSetPlayerCardPIN(m_parent.CurrentSale.Player.Id, PIN);
                        m_parent.ShowWaitForm(this); // Block until we are done.
                    }
                }
            }
            catch (Exception ex)
            {
                m_parent.Log("Failed to get the player/machine: " + ex.Message, LoggerLevel.Severe);
                MessageForm.Show(this, m_displayMode, string.Format(CultureInfo.CurrentCulture, (m_parent.Settings.EnableAnonymousMachineAccounts) ? Resources.GetMachineFailed : Resources.GetPlayerFailed, ex.Message));
            }
        }

        int GetPlayerCardPINFromUser(bool throwOnCancel = false)
        {
            int PIN = 0;
            bool inputCanceled = false;

            if (!m_parent.Settings.ThirdPartyPlayerInterfaceUsesPIN)
                return 0;

            bool MSRActive = m_parent.MagCardReader.ReadingCards;

            if (MSRActive)
                m_parent.MagCardReader.EndReading();

            //we need a PIN, get it and get the player points to test the PIN
            GTI.Modules.Shared.UI.NumericInputForm PINEntry = new Shared.UI.NumericInputForm(m_parent.Settings.ThirdPartyPlayerInterfacePINLength);
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
                m_parent.MagCardReader.BeginReading();

            if (inputCanceled && throwOnCancel)
                throw new POSException(Resources.PlayerCardPINEntryCanceled);

            return PIN;
        }



        private void DisplayGettingPlayer()
        {
            if (this.InvokeRequired) // if it's not coming in on the UI thread, move the work to the UI thread.
            {
                this.BeginInvoke((Action)DisplayGettingPlayer);
                return;
            }

            // Clear out the last player's information. Keep the name if updating the current player's information (card was the same)
            bool gettingNewPlayer = m_parent.CurrentSale == null || m_parent.CurrentSale.Player == null;
            ClearPlayer(gettingNewPlayer);

            if (!gettingNewPlayer)
                m_playerInfoList.Items.Add(m_parent.Settings.EnableAnonymousMachineAccounts ? Resources.WaitFormGettingMachine : Resources.WaitFormUpdatingPlayer);
            else
                m_playerInfoList.Items.Add(m_parent.Settings.EnableAnonymousMachineAccounts ? Resources.WaitFormGettingMachine : Resources.WaitFormGettingPlayer);
        }



        #endregion


        #region Properties

        public bool IsPointsAwardedSuccess { get; set; }
        public decimal PointsAwarded { get; set; }

        #endregion

    }
}