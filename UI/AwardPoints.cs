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
        protected PlayerManager m_parent;
        private Player m_player;

        #endregion

        #region Constructors

        public AwardPoints(PlayerManager parent)//No need to send the whole player object I just need this 2.
        {
            m_parent = parent;
            
            InitializeComponent();
            m_player = (m_parent.CurrentPlayer != null ? m_parent.CurrentPlayer : m_parent.LastPlayerFromServer);
            
            lblPlayerNameIndicator.Text = GetPlayerName();
            m_playerId = m_player.Id;
            PointsAwarded = 0M;
        }

        #endregion

        #region Events

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
            UpdatePlayerPoints();
        }


        public bool UpdatePlayerPoints()
        {
            bool result = true;
            int PIN = 0;
            //From this point we have our player info
            if (m_parent.Settings.PlayerInterfaceIsPinRequiredForPointAdjustment)
            {
                var c = m_parent.LastPlayerFromServer.PlayerCardPINError;
                bool PINProblem = false;
                //bool playerCardPinError  = true;

                try
                {
                    do
                    {                                                
                            PIN = m_parent.GetPlayerCardPINFromUser(true);
                            if (PIN == 0) return false;
                         

                            m_parent.StartUpdatePlayerPoints(PIN);//knc2
                            m_parent.ShowWaitForm(this); // Block until we are done.

                            var x = m_parent.LastPlayerFromServer.PlayerCardPINError;

                           // PINProblem = (PIN != 0 && m_parent.LastPlayerFromServer.ThirdPartyInterfaceDown && m_parent.LastPlayerFromServer.PlayerCardPINError);// && (m_parent.CurrentSale.Player.PlayerCardPINError || !m_parent.CurrentSale.Player.PointsUpToDate);

                            PINProblem = false;
                             if (PIN == 0)
                            {
                              //  PINProblem = false;
                            }
                            else
                        if (m_parent.LastPlayerFromServer.ThirdPartyInterfaceDown)
                            {
                                PINProblem = true;
                            }
                            else 
                            if (m_parent.LastPlayerFromServer.PlayerCardPINError)
                            {
                                PINProblem = true;
                            }


                        // if (m_parent.Settings.ThirdPartyPlayerInterfaceUsesPIN && !m_parent.CurrentSale.Player.WeHaveThePlayerCardPIN && (m_parent.Settings.ThirdPartyPlayerInterfaceNeedPINForPoints || m_parent.Settings.ThirdPartyPlayerInterfaceGetPINWhenCardSwiped))
                        if (PINProblem)
                                MessageForm.Show(Resources.PlayerCardPINError);
                   
                    } while (PINProblem);


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


                        DialogResult = DialogResult.OK;
                        Close();


                    }
                }
                catch (Exception ex)
                {
                    //m_parent.Log("Failed to update points for player/machine: " + ex.Message, LoggerLevel.Severe);
                    //MessageForm.Show(this, m_displayMode, Resources.GetPlayerFailed, ex.Message);
                    MessageBox.Show("Hi");

                    result = false;
                }

                if (!CheckForError())
                {
                    //SetPlayer();
    //Save it all here
                    MessageBox.Show("No error save it");
                }
                else
                {
                    result = false;
                }

    
            } return result;
        }


        private bool CheckForError()
        {
            if (m_parent.LastAsyncException != null)
            {
                if (m_parent.LastAsyncException is ServerCommException)
                    m_parent.ServerCommFailed();
                else if (!(m_parent.LastAsyncException is PlayerCenterException))
                    MessageForm.Show(this, m_displayMode, m_parent.LastAsyncException.Message);

                return true;
            }
            else
                return false;
        }

        #endregion

        #region Properties

        public bool IsPointsAwardedSuccess { get; set; }
        public decimal PointsAwarded { get; set; }

        #endregion

    }
}