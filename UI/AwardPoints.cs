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
            m_player = m_parent.CurrentPlayer;
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

        //public bool UpdatePlayerPoints(bool forceIt = false)
        public bool UpdatePlayerPoints()
        {
            bool result = true;

            //if (m_parent.CurrentSale == null || m_parent.CurrentSale.Player == null)
            //    return false;

            //if (!forceIt && m_parent.CurrentSale.Player.PointsUpToDate)
            //{
            //    m_parent.CurrentSale.NeedPlayerCardPIN = false;
            //    return true;
            //}



            // Check if third party Interface required player pin to enter.

                 int PIN = 0;
                //if (m_parent.Settings.PlayerInterfaceIsPinRequiredForPointAdjustment && !m_parent.CurrentSale.Player.WeHaveThePlayerCardPIN && (m_parent.Settings.ThirdPartyPlayerInterfaceNeedPINForPoints || m_parent.Settings.ThirdPartyPlayerInterfaceGetPINWhenCardSwiped))
                    if (m_parent.Settings.PlayerInterfaceIsPinRequiredForPointAdjustment )
                {

       bool PINProblem = false;
 do
 {
                                                   
            bool newPIN = false;
     

 //If player dont have his/her playerpin
     var WeHaveThePlayerCardPIN = false;
     if ( !WeHaveThePlayerCardPIN)
     {
                    newPIN = true;


                    PIN = m_parent.GetPlayerCardPINFromUser(true);

                    if (PIN == 0) //PIN entry canceled.
                        return false;
     }
                

                // Spawn a new thread to find the player and wait until done.
                m_parent.StartUpdatePlayerPoints(PIN);
                m_parent.ShowWaitForm(this); // Block until we are done.

                PINProblem = PIN != 0 && !m_parent.CurrentSale.Player.ThirdPartyInterfaceDown && (m_parent.CurrentSale.Player.PlayerCardPINError || !m_parent.CurrentSale.Player.PointsUpToDate);
                    
                if (PINProblem)
                    MessageForm.Show(Resources.PlayerCardPINError);
  
 }
            while (PINProblem);

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

            return result;
        }


        #endregion

        #region Properties

        public bool IsPointsAwardedSuccess { get; set; }
        public decimal PointsAwarded { get; set; }

        #endregion

    }
}