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
   partial class AwardPoints : GradientForm
   {
       private PlayerCenterThirdPartyInterface m_playercenterThirdPartyInterface;
       private WaitForm m_waitForm = null;
       private bool m_wholePoints = false;

       public AwardPoints(PlayerCenterThirdPartyInterface playerCenterThirdPartyInterface,  bool wholePoints, decimal currentPlayerpoints_)
        {
            InitializeComponent();
            m_playercenterThirdPartyInterface = playerCenterThirdPartyInterface;
            lblPlayerNameIndicator.Text = playerCenterThirdPartyInterface.GetPlayerName();
            lblPlayerCurrentPoint.Text = playerCenterThirdPartyInterface.GetPlayerPointBalance().ToString("N2");
            m_wholePoints = wholePoints;
            CheckForWholePoints();
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

        private void acceptImageButton_Click(object sender, EventArgs e)
        {
            if (CardNumber != string.Empty)
            {
                m_playercenterThirdPartyInterface.GetPlayer(CardNumber);
            }
            else
            {
                m_playercenterThirdPartyInterface.StartGetPlayer(PlayerId);
            }


            if (!string.IsNullOrEmpty(txtbxPointsAwarded.Text) || !string.IsNullOrEmpty(txtbxPointsSubtracted.Text))
            {
                try
                {
                    PointsAwarded = 0M;
                    decimal tPlayerPointsAdded = 0;
                    decimal.TryParse(txtbxPointsAwarded.Text, out tPlayerPointsAdded);

                    decimal tPlayerPointsSubtracted = 0;
                    decimal.TryParse(txtbxPointsSubtracted.Text, out tPlayerPointsSubtracted);

                    tPlayerPointsSubtracted = tPlayerPointsSubtracted * -1;

                    // DE14415 Create a total and display that
                    decimal totalPointAdjustment = tPlayerPointsAdded + tPlayerPointsSubtracted;

                    IsPointsAwardedSuccess = false;

                    string reasonMessage = "Manual point adjustment for player " + lblPlayerNameIndicator.Text + " (ID = " + m_playercenterThirdPartyInterface.PlayerSelected.Id.ToString() + ") for " + totalPointAdjustment.ToString() + " point(s). Reason: " + (string.IsNullOrWhiteSpace(txtManualPointAdjustReason.Text) ? "None" : txtManualPointAdjustReason.Text);

                    SetPlayerPointsAwarded msg = new SetPlayerPointsAwarded(PlayerId, (tPlayerPointsAdded + tPlayerPointsSubtracted), reasonMessage);

                    msg.Send();

                    if (msg.ReturnCode == (int)GTIServerReturnCode.Success)
                    {
                        IsPointsAwardedSuccess = true;
                        PointsAwarded = tPlayerPointsAdded + tPlayerPointsSubtracted;
                        MessageForm.Show(Resources.InfoPointsAwardSuccessed, Resources.PlayerCenterName);
                    }
                }
                catch
                {
                    MessageForm.Show(Resources.InfoPointsAwardFailed, Resources.PlayerCenterName);
                }
               
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        public bool IsPointsAwardedSuccess { get; set; }
        public decimal PointsAwarded { get; set; }

        private void txtbxPointsSubtracted_TextChanged(object sender, EventArgs e)
        {
            decimal value;
            if (
                (
                    (!string.IsNullOrWhiteSpace(txtbxPointsAwarded.Text) && decimal.TryParse(txtbxPointsAwarded.Text, out value) && value != 0)
                    ||
                    (!string.IsNullOrWhiteSpace(txtbxPointsSubtracted.Text) && decimal.TryParse(txtbxPointsSubtracted.Text, out value) && value != 0)
                )
                &&
                (!string.IsNullOrWhiteSpace(txtManualPointAdjustReason.Text) /*&& decimal.TryParse(txtbxPointsAwarded.Text, out value) && value != 0*/)
                )
                acceptImageButton.Enabled = true;
            else
                acceptImageButton.Enabled = false;
        }

        private void txtbxPointsAwarded_TextChanged(object sender, EventArgs e)
        {
            decimal value;
            if (
                (
                    (!string.IsNullOrWhiteSpace(txtbxPointsAwarded.Text) && decimal.TryParse(txtbxPointsAwarded.Text, out value) && value != 0)
                    ||
                    (!string.IsNullOrWhiteSpace(txtbxPointsSubtracted.Text) && decimal.TryParse(txtbxPointsSubtracted.Text, out value) && value != 0)
                )
                &&
                (!string.IsNullOrWhiteSpace(txtManualPointAdjustReason.Text) /*&& decimal.TryParse(txtbxPointsAwarded.Text, out value) && value != 0*/)
                )
                acceptImageButton.Enabled = true;
            else
                acceptImageButton.Enabled = false;
        }

        private void txtManualPointAdjustReason_TextChanged(object sender, EventArgs e)
        {
            lblManualPointsAdjustReasonCharactersLeft.Text = (txtManualPointAdjustReason.MaxLength - txtManualPointAdjustReason.TextLength).ToString();

            decimal value;
            if (
                (
                    (!string.IsNullOrWhiteSpace(txtbxPointsAwarded.Text) && decimal.TryParse(txtbxPointsAwarded.Text, out value) && value != 0)
                    ||
                    (!string.IsNullOrWhiteSpace(txtbxPointsSubtracted.Text) && decimal.TryParse(txtbxPointsSubtracted.Text, out value) && value != 0)
                )
                &&
                (!string.IsNullOrWhiteSpace(txtManualPointAdjustReason.Text) /*&& decimal.TryParse(txtbxPointsAwarded.Text, out value) && value != 0*/)
                )
                acceptImageButton.Enabled = true;
            else
                acceptImageButton.Enabled = false;

        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Return)
                return true;

            return base.ProcessDialogKey(keyData);
        }

        private void txtbxPointsAwarded_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                txtManualPointAdjustReason.Focus();
                return;
            }
        }

  
   }
}