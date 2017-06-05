diff --git a/Business/PlayerCenterSettings.cs b/Business/PlayerCenterSettings.cs
index f8ad993..1562f9c 100644
--- a/Business/PlayerCenterSettings.cs
+++ b/Business/PlayerCenterSettings.cs
@@ -1,394 +1,403 @@
 #region Copyright
 // This is an unpublished work protected under the copyright laws of the
 // United States and other countries.  All rights reserved.  Should
 // publication occur the following will apply:  ? 2008 GameTech
 // International, Inc.
 #endregion
 
 //US4120 (ND) Add setting for Player PIN Required
 //US4147 System Settings: Set the PIN length.
 
 using System;
 using System.Globalization;
 using GTI.Modules.Shared;
 using GTI.Modules.PlayerCenter.Properties;
 using GTI.Modules.Shared;
 
 namespace GTI.Modules.PlayerCenter.Business
 {
     /// <summary>
     /// Contains all the different workstation settings for the Player 
     /// Center module.
     /// </summary>
     public class PlayerCenterSettings
     {
         #region Member Variables
 
         //US4120 changed singlton to access from Pin form
         private static volatile PlayerCenterSettings m_instance;
         private static readonly object m_sync = new Object();
         private MSRSettings CardReaderSettings = new MSRSettings();
         protected bool m_ThirdPartyPlayerInterfaceGetPINWhenCardSwiped = false;
         protected int m_ThirdPartyPlayerInterfaceID;
         protected int m_ThirdPartyPlayerSyncMode = 0;
 
         public bool ThirdPartyPlayerInterfaceGetPINWhenCardSwiped
         {
             get
             {
                 return (m_ThirdPartyPlayerInterfaceID == 0 ? false : m_ThirdPartyPlayerInterfaceGetPINWhenCardSwiped);
             }
         }
 
         public int ThirdPartyPlayerInterfaceID
         {
             get
             {
                 return m_ThirdPartyPlayerInterfaceID;
             }
         }
  
 
         private PlayerCenterSettings()
         {
             SyncRoot = new object();
             DisplayMode = null;
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
                     case Setting.MagneticCardFilters:
                         CardReaderSettings.setFilters(setting.Value);
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
                     case Setting.MSRReadTriggers: //for keyboard wedge MSR, these are the characters that indicate input is from the MSR and when the input stream has stopped
                         CardReaderSettings.setReadTriggers(setting.Value);
                         break;
 
                     case Setting.VIPRequiresPIN:
                         PinRequired = Convert.ToBoolean(setting.Value);
                         break;
 
                     case Setting.POSReceiptPrinterName:
                         POSreceiptPrinterName = setting.Value.ToString();
                         break;
 
                     case Setting.RaffleDrawingSetting:
                         RaffleDrawingSetting = Convert.ToInt32(setting.Value);
                         break;
 
                     case Setting.ReceiptHeaderLine1:
                         ReceiptHeaderLine1 = setting.Value.ToString();
                         break;
 
                     case Setting.ReceiptHeaderLine2:
                         ReceiptHeaderLine2 = setting.Value.ToString();
                         break;
 
                     case Setting.RaffleRunFromLocation:
                         RaffleRunLocation = Convert.ToInt32(setting.Value);
                         break;
 
                     case Setting.PlayerPinLength: //US4147
                         PlayerPinLength = Convert.ToInt32(setting.Value, CultureInfo.InvariantCulture);
                         break;
 
                     //US2100 if staff has permission to adjust points to a player then get this 2 setting.
                     case Setting.ThirdPartyPlayerInterfaceNeedPINForRating:
                         PlayerInterfaceIsPinRequiredForPointAdjustment = Convert.ToBoolean(setting.Value);
                         break;
                     case Setting.ThirdPartyPlayerInterfacePINLength:
                         PlayerInterfaceIsPinRequiredForPointAdjustmentLength = Convert.ToInt32(setting.Value, CultureInfo.InvariantCulture);
                         break;
                     case Setting.ThirdPartyPlayerInterfaceGetPINWhenCardSwiped:
                         m_ThirdPartyPlayerInterfaceGetPINWhenCardSwiped = Convert.ToBoolean(setting.Value);
                         break;
                     case Setting.ThirdPartyPlayerInterfaceID:
                         m_ThirdPartyPlayerInterfaceID = Convert.ToInt32(setting.Value);
                         break;
                     case Setting.ThirdPartyPlayerSyncMode:
                         m_ThirdPartyPlayerSyncMode = Convert.ToInt32(setting.Value);
                         break;
+
                 }
             }
             catch
             {
             }
         }
+
+        public int ThirdPartyPlayerSyncMode
+        {
+            get
+            {
+                return m_ThirdPartyPlayerSyncMode;
+            }
+        }
         public bool PlayerInterfaceIsPinRequiredForPointAdjustment { get; set; }
         public int PlayerInterfaceIsPinRequiredForPointAdjustmentLength { get; set; }
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
 
                     //US4120
                     case LicenseSetting.NDSalesMode:
                         NDSalesMode = Convert.ToBoolean(setting.Value, CultureInfo.InvariantCulture);
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
         /// Gets an instance to Player Center Settings
         /// </summary>
         public static PlayerCenterSettings Instance
         {
             get
             {
                 if (m_instance == null)
                 {
                     lock (m_sync)
                     {
                         if (m_instance == null)
                             m_instance = new PlayerCenterSettings();
                     }
                 }
 
                 return m_instance;
             }
         }
 
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
 
         /// <summary>
         /// Gets the setting class for the MagneticCardReader.
         /// </summary>
         public MSRSettings MSRSettingsInfo
         {
             get
             {
                 return CardReaderSettings;
             }
         }
 
         // TA1651
         /// <summary>
         /// Gets or sets whether a pin number is required.
         /// </summary>
         public bool PinRequired { get; set; }
 
         public int PlayerPinLength { get; set; } //US4120
 
         // Rally TA7897
         public bool CreditEnabled { get; set; }
 
         public bool NDSalesMode { get; set; } //US4147
 
         //ALL about raffle
         public string POSreceiptPrinterName
         {
             get { return UI.raffle_Setting.posRafflePrinterName; }
             set
             { UI.raffle_Setting.posRafflePrinterName = value;}
         }
 
         //    RaffleDrawingSetting = 182,
         public int RaffleDrawingSetting 
         { 
             get{return UI.raffle_Setting.RaffleTextSetting;} 
             set{UI.raffle_Setting.RaffleTextSetting = value; }
         
         }
 
        // ReceiptHeaderLine1 = 189,
         public string ReceiptHeaderLine1
         {
             get { return UI.raffle_Setting.OperatorName; }
             set { UI.raffle_Setting.OperatorName = value; }
         }
 
         // ReceiptHeaderLine2 = 190
         public string ReceiptHeaderLine2
         {
             get { return UI.raffle_Setting.SponsoredBy; }
             set { UI.raffle_Setting.SponsoredBy = value; }
         }
 
         public int RaffleRunLocation
         {
             get { return UI.raffle_Setting.RaffleRunLocation; }
             set { UI.raffle_Setting.RaffleRunLocation = value; }
         }
 
         #endregion
     }
 }
