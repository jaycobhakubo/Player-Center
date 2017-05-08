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

namespace GTI.Modules.PlayerCenter.UI
{
    public partial class AwardPoints : EliteGradientForm
    {
        #region Member Variables
        private readonly bool isTouchScreen;
        private string m_playerName;
        #endregion

     

        #region Constructors
        public AwardPoints(string playerName)
        {
            InitializeComponent();
            lblPlayerNameIndicator.Text = playerName;
        }

        public AwardPoints(DisplayMode displayMode)
            : base(displayMode)
        {
            InitializeComponent();
            isTouchScreen = true;

        }
        #endregion

        #region Member Methods
        private void TakePIN_Load(object sender, EventArgs e)
        {
            if (isTouchScreen)
            {
                Size = m_displayMode.DialogSize;
                acceptImageButton.Text = acceptImageButton.Text.Replace("&", string.Empty);
                cancelImageButton.Text = cancelImageButton.Text.Replace("&", string.Empty);
            }
            else
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
                BackgroundImage = null;
                DrawGradient = true;
                acceptImageButton.ImageNormal = Resources.BlueButtonUp;
                acceptImageButton.ImagePressed = Resources.BlueButtonDown;
                cancelImageButton.ImageNormal = Resources.BlueButtonUp;
                cancelImageButton.ImagePressed = Resources.BlueButtonDown;
            }
        }

        private void Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            //var tb = sender as TextBox;
            //if (tb != null)
            //{
            //    //DE12731 Able to enter "." into password box
            //    if (!char.IsNumber(e.KeyChar) &&
            //        (Keys)e.KeyChar != Keys.Back)
            //    {
            //        e.Handled = true;
            //    }

            //    //US4186
            //    if (tb.Text.Length >= PlayerCenterSettings.Instance.PlayerPinLength &&
            //        (Keys)e.KeyChar != Keys.Back)
            //    {
            //        e.Handled = true;
            //    }
            //}
        }

        private void PINTextBox_TextChanged(object sender, EventArgs e)
        {

            ////lblErrorText.Visible = false;
            //var tb = sender as TextBox;
            //if (tb != null)
            //{
            //    //DE12734 
            //    //US4120
            //    //get pin length from settings
            //    var pinLength = PlayerCenterSettings.Instance.PlayerPinLength;

            //    //tb.BackColor = SystemColors.Window;
            //    if (txtbxPointsAwarded.Text == pinTextBox.Text && pinTextBox.Text.Length == pinLength)
            //    {
            //        //verifiedPINTextBox.BackColor = SystemColors.Window;
            //        acceptImageButton.Enabled = true;
            //    }
            //    else
            //    {
            //        //US4120
            //        //DE12702 Validate pin length of verify text box
            //        if ((pinTextBox.Text.Length == txtbxPointsAwarded.Text.Length && pinTextBox.Text.Length != pinLength) ||
            //            pinTextBox.Text.Length > pinLength ||
            //            txtbxPointsAwarded.Text.Length > pinLength)
            //        {
            //            //lblErrorText.Text = string.Format(Resources.PinMustBeSetLengthText, pinLength);
            //            //lblErrorText.Visible = true;
            //        }
            //        else if (pinTextBox.Text.Length == txtbxPointsAwarded.Text.Length)
            //        {
            //            //lblErrorText.Text = Resources.PinsDoNotMatchText;
            //            //lblErrorText.Visible = true;
            //        }
            //        //verifiedPINTextBox.BackColor = Color.LightPink;
            //        acceptImageButton.Enabled = false;
            //    }
            //}
        }

        private void cancelImageButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void acceptImageButton_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(pinTextBox.Text))
            //{
            //    mPinNumber = pinTextBox.Text;
            //}

            //DialogResult = DialogResult.OK;
            //Close();
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