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
        #region Member Variables
        private readonly int m_playerId;
        public bool IsManualPointsAwarded { get; set; }
        public decimal ManualPointsAwardedValue;
        #endregion

        #region Constructors
        public AwardPoints(string playerName, int playerId)
        {
            InitializeComponent();
            lblPlayerNameIndicator.Text = playerName;
            m_playerId = playerId;
            ManualPointsAwarded = 0M;
        }

        #endregion

        #region Member Methods
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

        private void Number_KeyPress(object sender, KeyPressEventArgs e)
        {         
        }

        private void PINTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void cancelImageButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public decimal ManualPointsAwarded { get; set; }

        private void acceptImageButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbxPointsAwarded.Text))
            {
                ManualPointsAwarded = 0M;
                var tempManualPlayerPoints = txtbxPointsAwarded.Text;
                SetPlayerPointsAwarded msg = new SetPlayerPointsAwarded(m_playerId, tempManualPlayerPoints);               
                msg.Send();
                if (msg.ReturnCode == (int)GTIServerReturnCode.Success)
                {
                    IsManualPointsAwarded = true;
                    ManualPointsAwarded = decimal.Parse(tempManualPlayerPoints, CultureInfo.InvariantCulture);
                }
                else
                {
                    IsManualPointsAwarded = false;
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void pinTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    txtbxPointsAwarded.Focus();
            //}
        }

        #endregion

    }
}