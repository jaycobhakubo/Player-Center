#region Copyright
// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2008 GameTech
// International, Inc.
#endregion

using System;
using System.Drawing;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.PlayerCenter.Properties; // FIX: DE3202

namespace GTI.Modules.PlayerCenter.UI
{
    public partial class TakePIN : EliteGradientForm
    {
        #region Member Variables
        int mPinNumber = -1;
        private readonly bool isTouchScreen;
        #endregion

        #region Member Properties
        public int PIN
        {
            get { return mPinNumber; }
        }
        #endregion

        #region Constructors
        public TakePIN()
        {
            InitializeComponent();
        }

        public TakePIN(DisplayMode displayMode)
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
                // FIX: DE3202 - Dialog didn't match rest of the theme.
                BackgroundImage = null;
                DrawGradient = true;
                acceptImageButton.ImageNormal = Resources.BlueButtonUp;
                acceptImageButton.ImagePressed = Resources.BlueButtonDown;
                cancelImageButton.ImageNormal = Resources.BlueButtonUp;
                cancelImageButton.ImagePressed = Resources.BlueButtonDown;
                // END: DE3202
            }
        }

        private void Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            var tb = sender as TextBox;
            if (tb != null)
            {
                if (!char.IsNumber(e.KeyChar) &&
                    (Keys)e.KeyChar != Keys.Back &&
                    (Keys)e.KeyChar != Keys.Delete)
                {
                    e.Handled = true;
                }
                if (tb.Text.Length >= 9 &&
                    (Keys)e.KeyChar != Keys.Back &&
                    (Keys)e.KeyChar != Keys.Delete)
                {
                    e.Handled = true;
                }
            }
        }

        private void PINTextBox_TextChanged(object sender, EventArgs e)
        {
            lblDoNotMatch.Visible = false;
            var tb = sender as TextBox;
            if (tb != null)
            {
                if (!ValidateNumber(tb.Text))
                {
                    //tb.Select(0, tb.Text.Length);
                    //tb.BackColor = Color.LightPink;
                    acceptImageButton.Enabled = false;
                }
                else
                {
                    //tb.BackColor = SystemColors.Window;
                    if (verifiedPINTextBox.Text == pinTextBox.Text)
                    {
                        //verifiedPINTextBox.BackColor = SystemColors.Window;
                        acceptImageButton.Enabled = true;
                    }
                    else
                    {
                        if (pinTextBox.Text.Length == verifiedPINTextBox.Text.Length) lblDoNotMatch.Visible = true;
                        //verifiedPINTextBox.BackColor = Color.LightPink;
                        acceptImageButton.Enabled = false;
                    }

                }
            }
        }

        private static bool ValidateNumber(string inText)
        {
            bool isOk = false;
            if (inText.Length > 0)
            {
                int result;
                isOk = int.TryParse(inText, out result);
            }
            return isOk;
        }

        private void cancelImageButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void acceptImageButton_Click(object sender, EventArgs e)
        {
            if (pinTextBox.Text != string.Empty)
            {
                int result;
                if (int.TryParse(pinTextBox.Text, out result)) mPinNumber = result;
            }
            Close();
        }

        #endregion
    }
}