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
using System.Collections.Generic;


namespace GTI.Modules.PlayerCenter.UI
{
   partial class AwardPoints : GradientForm
   {
       private PlayerCenterThirdPartyInterface m_playercenterThirdPartyInterface;
       private WaitForm m_waitForm = null;
       private bool m_wholePoints = false;
       private bool m_isAwardPointsToPlayerList;
       public List<int> PlayerList { get; set; }


       public AwardPoints(PlayerCenterThirdPartyInterface playerCenterThirdPartyInterface,  bool wholePoints)
        {
            InitializeComponent();
            m_playercenterThirdPartyInterface = playerCenterThirdPartyInterface;
            m_wholePoints = wholePoints;
            CheckForWholePoints();
            m_isAwardPointsToPlayerList = false;
        }

       public AwardPoints()
       {
           InitializeComponent();
           m_isAwardPointsToPlayerList = true;
    
       }

       public void CheckForWholePoints()
       {
           if (m_wholePoints)
           {
               txtbxPointsAwarded.Mask = GTI.Controls.TextBoxNumeric2.TextBoxType.Integer;
           }
       }
    
        public int PlayerId { get { return m_playercenterThirdPartyInterface.PlayerSelected.Id; } }
        public string CardNumber { get { return m_playercenterThirdPartyInterface.PlayerSelected.PlayerCard; } }

     
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
        private bool m_isPointsAwardedSuccess;

        private bool AwardPointsToPlayer(int playerId)
        {
            PointsAwarded = 0M;
            var tempManualPlayerPoints = txtbxPointsAwarded.Text;
            m_isPointsAwardedSuccess = false;

            SetPlayerPointsAwarded msg = new SetPlayerPointsAwarded(playerId, tempManualPlayerPoints);
            msg.Send();
            if (msg.ReturnCode == (int)GTIServerReturnCode.Success)
            {
                m_isPointsAwardedSuccess = true;
                PointsAwarded = decimal.Parse(tempManualPlayerPoints, CultureInfo.InvariantCulture);
                //MessageForm.Show(Resources.InfoPointsAwardSuccessed, Resources.PlayerCenterName);
              
            }
            return m_isPointsAwardedSuccess;
        }

        private void acceptImageButton_Click(object sender, EventArgs e)
        {
           


            if (m_isAwardPointsToPlayerList == false)
            {
                if (CardNumber != string.Empty)
                {
                    m_playercenterThirdPartyInterface.GetPlayer(CardNumber);
                }
                else
                {
                    m_playercenterThirdPartyInterface.StartGetPlayer(PlayerId);
                }

                if (!string.IsNullOrEmpty(txtbxPointsAwarded.Text))
                {
                    try
                    {
                        if (AwardPointsToPlayer(PlayerId))
                        {
                            MessageForm.Show(Resources.InfoPointsAwardSuccessed, Resources.PlayerCenterName);
                        }
          
                    }
                    catch
                    {
                        MessageForm.Show(Resources.InfoPointsAwardFailed, Resources.PlayerCenterName);
                    }

                }
            }
            else//award points to a list of player
            {
                foreach (int t_playerId in PlayerList)
                {
                    try
                    {
                        AwardPointsToPlayer(t_playerId);
                    }
                    catch
                    {
                        MessageForm.Show(Resources.InfoPointsAwardFailed, Resources.PlayerCenterName);
                    }
                }

                if (m_isPointsAwardedSuccess)
                {
                    MessageForm.Show(Resources.InfoPointsAwardSuccessed, Resources.PlayerCenterName);
                }
            }

          

            DialogResult = DialogResult.OK;
            Close();
        }


        public bool IsPointsAwardedSuccess { get; set; }
        public decimal PointsAwarded { get; set; }
    }
}