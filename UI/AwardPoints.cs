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
   partial class AwardPoints : EliteGradientForm
   {
       private PlayerCenterThirdPartyInterface m_playercenterThirdPartyInterface;
       private WaitForm m_waitForm = null;

        public AwardPoints()
        {
            InitializeComponent();         
        }

        internal void Initialize(PlayerCenterThirdPartyInterface playerCenterThirdPartyInterface)
        {
            m_playercenterThirdPartyInterface = playerCenterThirdPartyInterface;
        }

        private static volatile AwardPoints m_instance;
        private static readonly object m_sync = new Object();
        public static AwardPoints Instance
        {
            get
            {
                if (m_instance == null)
                {
                    lock (m_sync)
                    {
                        if (m_instance == null)
                            m_instance = new AwardPoints();
                    }
                }

                return m_instance;
            }
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
        
            if (m_playercenterThirdPartyInterface.PlayerSelected.MagneticCardNumber != string.Empty)
            {
                m_playercenterThirdPartyInterface.GetPlayer(m_playercenterThirdPartyInterface.PlayerSelected.MagneticCardNumber);//knc

            }
            else
            {
                m_playercenterThirdPartyInterface.StartGetPlayer(m_playercenterThirdPartyInterface.PlayerSelected.Id);
            }


            if (!string.IsNullOrEmpty(txtbxPointsAwarded.Text))
            {
                m_playercenterThirdPartyInterface.RunMessageSetPlayerPoints(txtbxPointsAwarded.Text);
            }

            DialogResult = DialogResult.OK;
            Close();
        }


        public bool IsPointsAwardedSuccess { get; set; }
        public decimal PointsAwarded { get; set; }
    }
}