#region Copyright
// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2008 GameTech
// International, Inc.
#endregion

using System;
using System.Globalization;
using GTI.Modules.Shared;
using GTI.Modules.PlayerCenter.Properties;

namespace GTI.Modules.PlayerCenter.Business
{
    /// <summary>
    /// Contains all the different workstation settings for the Player 
    /// Center module.
    /// </summary>
    public class PlayerCenterSettings
    {
        #region Member Variables
        public PlayerCenterSettings()
        {
            SyncRoot = new object();
            DisplayMode = null;
            Sentinels = null;
            ShowCursor = false;
            ForceEnglish = false;
            EnableLogging = false;
            PinRequired = false;
        }
        #endregion

        #region Member Methods
        /// <summary>
        /// Parses a setting from the server and loads it into the 
        /// PlayerCenterSettings, if valid.
        /// </summary>
        /// <param name="setting">The setting to parse.</param>
        public void LoadSetting(SettingValue setting)
        {
            try
            {
                var param = (Setting)setting.Id;

                switch(param)
                {
                    case Setting.MagneticCardSentinels:
                        Sentinels = SentinelPair.CreatePairs(setting.Value);
                        break;

                    case Setting.ShowMouseCursor:
                        ShowCursor = Convert.ToBoolean(setting.Value);
                        break;

                    // PDTS 312
                    case Setting.DatabaseServer:
                        DatabaseServer = setting.Value;
                        break;

                    case Setting.DatabaseName:
                        DatabaseName = setting.Value;
                        break;

                    case Setting.DatabaseUser:
                        DatabaseUser = setting.Value;
                        break;

                    case Setting.DatabasePassword:
                        DatabasePassword = setting.Value;
                        break;

                    case Setting.ForceEnglish:
                        ForceEnglish = Convert.ToBoolean(setting.Value);
                        break;

                    case Setting.EnableLogging:
                        EnableLogging = Convert.ToBoolean(setting.Value);
                        break;

                    case Setting.LoggingLevel:
                        LoggingLevel = Convert.ToInt32(setting.Value, CultureInfo.InvariantCulture);
                        break;

                    case Setting.LogRecycleDays:
                        FileLogRecycleDays = Convert.ToInt32(setting.Value, CultureInfo.InvariantCulture);
                        break;

                    // PDTS 312
                    case Setting.ClientInstallDrive:
                        ClientInstallDrive = setting.Value;
                        break;

                    case Setting.ClientInstallRootDirectory:
                        ClientInstallRootDir = setting.Value;
                        break;

                    // PDTS 1064
                    case Setting.MagneticCardReaderMode:
                        MagCardMode = (MagneticCardReaderMode)Convert.ToInt32(setting.Value, CultureInfo.InvariantCulture);

                        if(!Enum.IsDefined(typeof(MagneticCardReaderMode), MagCardMode))
                            throw new ArgumentException();

                        break;

                    case Setting.MagneticCardReaderParameters:
                        MagCardModeSettings = setting.Value;
                        break;

                    // Rally DE130
                    case Setting.StripNonAlphanumeric:
                        StripNonAlphanumeric = Convert.ToBoolean(setting.Value);
                        break;

                    case Setting.VIPRequiresPIN:
                        PinRequired = Convert.ToBoolean(setting.Value);
                        break;
                }
            }
            catch
            {
            }
        }

        // Rally TA7897
        /// <summary>
        /// Parses a license setting from the server and loads it into the 
        /// PlayerCenterSettings, if valid.
        /// </summary>
        /// <param name="setting">The license setting to parse.</param>
        public void LoadSetting(LicenseSettingValue setting)
        {
            LicenseSetting param = (LicenseSetting)setting.Id;

            try
            {
                switch(param)
                {
                    case LicenseSetting.CreditEnabled:
                        CreditEnabled = Convert.ToBoolean(setting.Value, CultureInfo.InvariantCulture);
                        break;
                }
            }
            catch(Exception e)
            {
                throw new PlayerCenterException(string.Format(CultureInfo.CurrentCulture, Resources.InvalidSetting, setting.Id, setting.Value), e);
            }
        }
        #endregion

        #region Member Properties
        /// <summary>
        /// Gets an object that can be used to synchronize access to 
        /// the settings.
        /// </summary>
        public object SyncRoot { get; protected set; }

        /// <summary>
        /// Gets or sets the display mode to use for user interfaces.
        /// </summary>
        public DisplayMode DisplayMode { get; set; }

        /// <summary>
        /// Gets or sets the magnetic card sentinel character pairs.
        /// </summary>
        public SentinelPair[] Sentinels { get; protected set; }

        /// <summary>
        /// Gets or sets whether to show the mouse cursor.
        /// </summary>
        public bool ShowCursor { get; set; }

        // PDTS 312
        /// <summary>
        /// Gets or sets the database server name to use for reports.
        /// </summary>
        public string DatabaseServer { get; set; }

        /// <summary>
        /// Gets or sets the database name to use for reports.
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the database user to use for reports.
        /// </summary>
        public string DatabaseUser { get; set; }

        /// <summary>
        /// Gets or sets the database password to use for reports.
        /// </summary>
        public string DatabasePassword { get; set; }

        /// <summary>
        /// Gets or sets whether to force the program to display in the 
        /// English language.
        /// </summary>
        public bool ForceEnglish { get; set; }

        /// <summary>
        /// Gets or sets whether to log output to a file.
        /// </summary>
        public bool EnableLogging { get; set; }

        /// <summary>
        /// Gets or sets level of logging.
        /// </summary>
        public int LoggingLevel { get; set; }

        /// <summary>
        /// Gets or sets the number of days to keep a file log.
        /// </summary>
        public int FileLogRecycleDays { get; set; }

        // PDTS 312
        /// <summary>
        /// Gets or sets the drive letter the client software is installed on.
        /// </summary>
        public string ClientInstallDrive { get; set; }

        /// <summary>
        /// Gets or sets the folder the client software is installed in.
        /// </summary>
        public string ClientInstallRootDir { get; set; }

        // PDTS 1064
        /// <summary>
        /// Gets or sets the mode of the MagneticCardReader (which sources 
        /// are enabled).
        /// </summary>
        public MagneticCardReaderMode MagCardMode { get; set; }

        /// <summary>
        /// Gets or sets the setting string for the MagneticCardReader and 
        /// its sources.
        /// </summary>
        public string MagCardModeSettings { get; set; }

        // Rally DE130
        /// <summary>
        /// Gets or sets whether to remove non-alphanumeric characters when a 
        /// mag. card is swiped.
        /// </summary>
        public bool StripNonAlphanumeric { get; set; }

        // TA1651
        /// <summary>
        /// Gets or sets whether a pin number is required.
        /// </summary>
        public bool PinRequired { get; set; }

        // Rally TA7897
        public bool CreditEnabled { get; set; }
        #endregion
    }
}
