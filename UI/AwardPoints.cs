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

        #endregion

        #region Constructors

        public AwardPoints(string playerName, int playerId)//No need to send the whole player object I just need this 2.
        {
            InitializeComponent();
            lblPlayerNameIndicator.Text = playerName;
            m_playerId = playerId;
            PointsAwarded = 0M;
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
                //Check if the player required pin
                if (IsPlayerPinRequiredForPointAdjustment)
                {

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


        /// <summary>
        /// Pops up a window to get the player card pin input from the user
        /// </summary>
        /// <param name="throwOnCancel"></param>
        /// <returns></returns>
        int GetPlayerCardPINFromUser(bool throwOnCancel = false)
        {
            int PIN = 0;
            //bool inputCanceled = false;

      
            ////bool MSRActive = m_parent.MagCardReader.ReadingCards;

            ////if (MSRActive)
            ////    m_parent.MagCardReader.EndReading();

            ////we need a PIN, get it and get the player points to test the PIN
            //GTI.Modules.Shared.UI.NumericInputForm PINEntry = new Shared.UI.NumericInputForm(m_parent.PlayerInterfaceIsPinRequiredForPointAdjustmentLength);//knc
            //PINEntry.UseDecimalKey = false;
            //PINEntry.Password = true;
            //PINEntry.Description = "Enter Player Card PIN";

            //do
            //{
            //    inputCanceled = PINEntry.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel;

            //    if (!inputCanceled)
            //        PIN = Convert.ToInt32(PINEntry.DecimalResult);
            //} while (!inputCanceled && PIN == 0);

            //PINEntry.Dispose();

            //if (MSRActive)
            //    //m_parent.MagCardReader.BeginReading();

            //if (inputCanceled && throwOnCancel)
            //    throw new PlayerCenterException("Player card PIN entry canceled");

            return PIN;
        }

        #endregion


        #region Properties

        public bool IsPointsAwardedSuccess { get; set; }
        public decimal PointsAwarded { get; set; }
        public bool IsPlayerPinRequiredForPointAdjustment { get; set; }
        public int PlayerPinRequiredForPointAdjustmentLength { get; set; }
        public bool MSRActive;

        #endregion

    }
}