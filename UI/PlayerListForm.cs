#region Copyright
// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2008-2010 GameTech
// International, Inc.
#endregion

// Rally US144

using System;
using System.Windows.Forms;
using System.Globalization;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using GTI.Modules.Shared;
using GTI.Modules.PlayerCenter.Business;
using GTI.Modules.PlayerCenter.Properties;

using System.Drawing; //US2469  
using GTI.Modules.PlayerCenter.Data; //US2469    
using System.Collections.Generic;  //US2469
using CheckComboBoxTest;
using GTI.Modules.Shared.Business;

namespace GTI.Modules.PlayerCenter.UI
{
    /// <summary>
    /// The form that allows you to create a list of players meeting various 
    /// criteria.
    /// </summary>
    internal partial class PlayerListForm : GradientForm
    {
        #region Constants and Data Types
        protected const string ExportFileFilter = "Comma-separated values (*.csv)|*.csv";
        protected const string DefaultFileExt = "csv";
        private string[] SessionNumber = { @"ALL", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        protected const string ALL_SESSIONS_SELECTED = "(1:2:3:4:5:6:7:8:9:10),";

        public enum Loc : byte
        {
            City,
            State,
            Postal,
            Country
        }

        /// <summary>
        /// Used for the birthday month combo boxes.
        /// </summary>
        protected struct MonthItem
        {
            public int Number;
            public string Name;

            public override string ToString()
            {
                return Name;
            }
        }
        #endregion

        #region Member Variables

        protected PlayerManager m_parent;
        private int DefID;
        private string m_ListName;
        private string DaysOfWeekNSession;
        private string SelectedProductPar;
        private PlayerActualListSetting PlyrActListSetting = new PlayerActualListSetting();
        private PlayerListSetting pls = new PlayerListSetting();
        Dictionary<int, int> IndexToDefID = new Dictionary<int, int>();
        ContextMenuStrip contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
        private bool isSavedList = false;
        private bool isDeleteList = false;
        private bool isNewList = false;
        private int countCheckBox = 0;
        private int ActiveButton_ = 0;
        private PlayerListParams m_playerListParams;// = new PlayerListParams();

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the PlayerListForm class.
        /// </summary>
        /// <param name="parent">The PlayerManager to which this form 
        /// belongs.</param>
        public PlayerListForm(PlayerManager parent)
        {
            if (parent == null) throw new ArgumentNullException("parent");
            m_parent = parent;
            InitializeComponent();
            LoadValues();
            PlayerListDefault();

            m_printRaffleRadio.Text = String.Format("{0} Ticket", (raffle_Setting.RaffleTextSetting  == 1) ? "Raffle" : "Drawing");

            foreach (string name in Enum.GetNames(typeof(Loc)))
            {
                m_locationTypeComboBox.Items.Add(name);
            }

            cmbxPlayerList2.ContextMenuStrip = contextMenuStrip1;
            cmbxPlayerList2.MouseUp += new MouseEventHandler(listBox_Usernames_MouseUp);
            LoadPlayerListSettingComboBox(); //Load the Player List Setting combo box.
            DisableAllControl();
            DisableAllPanel();
            m_listCriteriaPanel.Visible = false;

        }
        #endregion

        #region Member Methods


        private void DisableAllControl()
        {
            imgbtn.Enabled = false;
            imgbtnDelete.Enabled = false;
            imgbtn_AwardPointsToListOfPlayer.Enabled =false;
            btnSaveList.Enabled = false;
            imgbtnCancel.Enabled = false;
            m_generateButton.Enabled = false;
            DisablePlayerListMainButton();
        }

        private void DisablePlayerListMainButton()
        {
            m_listCriteriaButton1.Enabled = false;
            m_locationButton.Enabled = false;
            m_playDatesButton.Enabled = false;
            m_spendBotton.Enabled = false;
        }

        /// <summary>
        /// Load the Player List Setting combo box.
        /// </summary>
        protected void LoadPlayerListSettingComboBox()
        {
            if (cmbxPlayerList2.Items.Count > 0)
            {
                cmbxPlayerList2.Items.Clear();
            }

            if (IndexToDefID.Count > 0)
            {
                IndexToDefID.Clear();
            }

            GetPlayerListDefinition get_pld = new GetPlayerListDefinition();
            List<PlayerListDefinition> List_pld = get_pld.GetPlayerListDefinitionMSG();
            int indexOf = 0;

            if (List_pld.Count > 0)
            {
                var sortPlayerListDef = List_pld.OrderBy(x => x.DefinitionName);
                foreach (PlayerListDefinition pld in sortPlayerListDef)
                {
                    cmbxPlayerList2.Items.Add(pld.DefinitionName);
                    IndexToDefID.Add(indexOf, pld.DefId);
                    indexOf = indexOf + 1;
                }
            }
        }
        
        /// <summary>
        /// Populates lists on the form.
        /// </summary>
        protected void PlayerListDefault()
        {
            m_locationPanel.Visible = false;
            m_listCriteriaPanel.Visible = true;
            m_listCriteriaPanel.Enabled = true;
            m_playDatesPanel.Visible = false;
        }

        /// <summary>
        /// Set to default after adding a player List Detail/Definition.
        /// </summary>
        protected void PlayerListDefault2()
        {
            if (m_findAllVIPCheckBox.Checked != false) m_findAllVIPCheckBox.Checked = false;
            if (m_genderCheck.Checked != false) m_genderCheck.Checked = false;
            if (m_statusCheck.Checked != false) m_statusCheck.Checked = false;
            if (m_birthdayCheck.Checked) m_birthdayCheck.Checked = false;
            if (m_daysPlayedCheck.Checked) m_daysPlayedCheck.Checked = false;
            if (m_sessionPlayedCheck.Checked) m_sessionPlayedCheck.Checked = false;
            if (m_daysOfWeekAndSessionCheck.Checked) m_daysOfWeekAndSessionCheck.Checked = false;
            if (m_lastVisitCheck.Checked) m_lastVisitCheck.Checked = false;
            if (m_ProductCheckBox.Checked) m_ProductCheckBox.Checked = false;
            if (m_pointBalanceCheck.Checked) m_pointBalanceCheck.Checked = false;
            if (m_spendCheck.Checked) m_spendCheck.Checked = false;
            if (m_averageRadio.Checked) m_averageRadio.Checked = false;
            m_dateRangefromDPDatePicker.Value = DateTime.Now.AddMonths(-1);

            if (cmbxPlayerList2.SelectedIndex > -1)
            {
                if (!imgbtnDelete.Enabled) imgbtnDelete.Enabled = true;
                if (!imgbtn.Enabled) imgbtn.Enabled = true;
                if (!m_generateButton.Enabled) m_generateButton.Enabled = true;
                if (!m_closeButton.Enabled) m_closeButton.Enabled = true;
                if (!cmbxPlayerList2.Enabled) cmbxPlayerList2.Enabled = true;
                if (!m_listTypePanel.Enabled) m_listTypePanel.Enabled = true;
            }

        }
        
        protected void LoadValues()
        {
            Calendar cal = CultureInfo.CurrentCulture.Calendar;
            m_fromBirthdayMonth.BeginUpdate();
            m_toBirthdayMonth.BeginUpdate();
            m_fromBirthdayMonth.Items.Clear();
            m_toBirthdayMonth.Items.Clear();
            int numMonths = cal.GetMonthsInYear(DateTime.Now.Year);

            for (int month = 1; month <= numMonths; month++)
            {
                DateTime time = new DateTime(DateTime.Now.Year, month, 1);
                MonthItem item = new MonthItem();
                item.Number = month;
                item.Name = time.ToString("MMM", CultureInfo.CurrentCulture);
                m_fromBirthdayMonth.Items.Add(item);
                m_toBirthdayMonth.Items.Add(item);
            }

            m_fromBirthdayMonth.EndUpdate();
            m_toBirthdayMonth.EndUpdate();

            // Select the first month by default.
            if (m_fromBirthdayMonth.Items.Count > 0)
            {
                m_fromBirthdayMonth.SelectedIndex = 0;
                m_toBirthdayMonth.SelectedIndex = 0;
            }

            // Set the from last visit and from spend date to a month ago.
            m_fromLastVisit.Value = DateTime.Now.AddMonths(-1);
            m_fromSpendDate.Value = DateTime.Now.AddMonths(-1);
            m_dateRangefromDPDatePicker.Value = DateTime.Now.AddMonths(-1);

            // FIX: DE1891
            m_genderList.BeginUpdate();

            // m_genderList.Items.Add(string.Empty);
            m_genderList.Items.Add(Resources.GenderMale);
            m_genderList.Items.Add(Resources.GenderFemale);

            m_genderList.SelectedIndex = 0;

            m_genderList.EndUpdate();
            // END: DE1891

            LoadSelectedOption(m_rangeOptionDPComboBox);
            LoadSelectedOption(m_rangeOptionSPComboBox);
        }
        
        protected void LoadSelectedOption(ComboBox x)
        {
            x.BeginUpdate();
            x.Items.Add(Resources.DayPlayedOption1);
            x.Items.Add(Resources.DayPlayedOption2);
            x.Items.Add(Resources.DayPlayedOption3);
            x.Items.Add(Resources.DayPlayedOption4);
            x.Items.Add(Resources.DayPlayedOption5);
            x.EndUpdate();
        }

        /// <summary>
        /// Sets the MaxLength property of all the text boxes.
        /// </summary>
        protected void SetMaxTextLengths()
        {
            m_minPointBalance.MaxLength = StringSizes.MaxDecimalLength;
            m_maxPointBalance.MaxLength = StringSizes.MaxDecimalLength;
            m_fromSpend.MaxLength = StringSizes.MaxDecimalLength;
            m_toSpend.MaxLength = StringSizes.MaxDecimalLength;
        }
        
        private string Selection(string x)
        {
            string z = "";
            switch (x)
            {
                case "Greater Than":
                    z = ">";
                    break;
                case "Greater Than or Equal ": z = ">="; break;
                case "Equal": z = "="; break;
                case "Less Than Or Equal ": z = "<="; break;
                case "Less Than": z = "<"; break;
            }

            return z;
        }
        
        private void EnableOrDisableSavedButton(RadioButton rdobtn)
        {
            if (rdobtn.Checked)
            {
                countCheckBox = countCheckBox + 1;
                if (!btnSaveList.Enabled) btnSaveList.Enabled = true;
            }
            else
            {
                countCheckBox = countCheckBox - 1;
                if (countCheckBox == 0)
                {
                    btnSaveList.Enabled = false;
                }
            }
        }
        
        private void EnableOrDisableSavedButton(CheckBox chkbx)
        {
            if (chkbx.Checked)
            {
                countCheckBox = countCheckBox + 1;
                if (!btnSaveList.Enabled) btnSaveList.Enabled = true;
            }
            else
            {
                countCheckBox = countCheckBox - 1;
                if (countCheckBox == 0)
                {
                    btnSaveList.Enabled = false;
                }
            }
        }

        private void EnableOrDisableSavedButton(ComboBox Selected_cmbx)
        {
            if (Convert.ToInt32(Selected_cmbx.Tag) == 7)//Number of days visited option
            {
                if (Selected_cmbx.SelectedIndex != -1 && !string.IsNullOrEmpty(m_rangeOptionDPTextBox.Text))
                {
                    countCheckBox = countCheckBox + 1;
                    if (!btnSaveList.Enabled) btnSaveList.Enabled = true;
                }
                else
                {
                    if (!string.IsNullOrEmpty(m_rangeOptionDPTextBox.Text))
                        countCheckBox = countCheckBox - 1;
                    if (countCheckBox == 0)
                    {
                        if (btnSaveList.Enabled) btnSaveList.Enabled = false;
                    }
                }
            }
            else if (Convert.ToInt32(Selected_cmbx.Tag) == 8)//Number of days visited option
            {
                if (Selected_cmbx.SelectedIndex != -1 && !string.IsNullOrEmpty(m_rangeOptionSPTextBox.Text))
                {
                    countCheckBox = countCheckBox + 1;
                    if (!btnSaveList.Enabled) btnSaveList.Enabled = true;
                }
                else
                {
                    if (!string.IsNullOrEmpty(m_rangeOptionSPTextBox.Text))
                        countCheckBox = countCheckBox - 1;
                    if (countCheckBox == 0)
                    {
                        if (btnSaveList.Enabled) btnSaveList.Enabled = false;
                    }
                }
            }
            else if (Convert.ToInt32(Selected_cmbx.Tag) == 9)//Number of days visited option
            {
                if (Selected_cmbx.SelectedIndex != -1 && !string.IsNullOrEmpty(m_optionValuePBText.Text))
                {
                    countCheckBox = countCheckBox + 1;
                    if (!btnSaveList.Enabled) btnSaveList.Enabled = true;
                }
                else
                {
                    if (!string.IsNullOrEmpty(m_optionValuePBText.Text))
                        countCheckBox = countCheckBox - 1;
                    if (countCheckBox == 0)
                    {
                        if (btnSaveList.Enabled) btnSaveList.Enabled = false;
                    }
                }
            }
        }
        
        private void SetListOfSetting(int SettingID, string SettingValue)
        {
            pls = new PlayerListSetting();
            pls.SettingID = SettingID;
            pls.SettingValue = SettingValue;
            PlyrActListSetting.Settings.Add(pls);
        }

        protected void m_loadLocaListBox(int selectedindex)
        {
            CultureInfo currentCulture = System.Threading.Thread.CurrentThread.CurrentCulture;

            if (selectedindex == 0)//city 
            {
                m_locListBox.Items.Clear();
                foreach (LocationCity City in PlayerManager.ListLocationCity)
                {
                    string City2 = City.ToString();
                    City2 = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(City2.ToLower());
                    m_locListBox.Items.Add(City2);
                }

            }
            else if (selectedindex == 1)
            {
                m_locListBox.Items.Clear();
                foreach (LocationState State in PlayerManager.ListLocationState)
                {
                    m_locListBox.Items.Add(State.State);
                }
            }
            else if (selectedindex == 2)
            {
                m_locListBox.Items.Clear();
                foreach (LocationZipCode PostalCode in PlayerManager.ListLocationZipCode)
                {
                    m_locListBox.Items.Add(PostalCode);
                }
            }
            else if (selectedindex == 3)
            {
                m_locListBox.Items.Clear();
                foreach (LocationCountry Country in PlayerManager.ListLocationCountry)
                {
                    string Country2 = Country.ToString();
                    Country2 = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(Country2.ToLower());
                    m_locListBox.Items.Add(Country2);
                }
            }
        }


        private void ClearAllSummaryItem()
        {
            summary_Gender.Text = string.Empty;
            summary_Status.Text = string.Empty;
            summary_Birthday.Text = string.Empty;
            summary_VisitedDateFrom.Text = string.Empty;
            summary_NDaysVisitedFrom.Text = string.Empty;
            summary_DaysWeek2.Text = string.Empty;
            summary_NSessionVisitedFrom.Text = string.Empty;
            summary_LastVisitDateFrom.Text = string.Empty;
            summary_Location.Text = string.Empty;
            summary_SpendDateFrom.Text = string.Empty;
            summary_PBFrom.Text = string.Empty;
            summary_NAverageFrom.Text = string.Empty;
            summary_NSpendFrom.Text = string.Empty;
            summary_ProductPurchase2.Text = string.Empty;
                                                                                                                                                          

        }
        
        private void PopulateDataIntoControls()
        {
            ClearAllSummaryItem();
            string t_summary_DateFrom = "";
            DateTime t_summary_DateFrom_dt = new DateTime();
            string t_summary_value = "";
            string t_summary_Option = "";

            foreach (PlayerListSetting pls in PlyrActListSetting.Settings)
            {
                DateTime tempDateTime;
                int tempIndexOf = 0; ;
               

                switch (pls.SettingID)
                {
                    case (int)PlayerListSettingEnum.Gender://Gender
                        m_genderCheck.Checked = true;
                        m_genderList.SelectedIndex = m_genderList.Items.IndexOf(pls.SettingValue);
                        summary_Gender.Text = pls.SettingValue;
                        break;
                    case (int)PlayerListSettingEnum.Status://Status
                        m_statusCheck.Checked = true;
                        string tempStatus = pls.SettingValue.ToString() + ",";
                        tempStatus = tempStatus.Replace("/|\\", ",");
                        tempIndexOf = tempStatus.IndexOf(",");
                        summary_Status.Text =  tempStatus.Remove(tempStatus.Length - 1, 1);
                        while (tempStatus.IndexOf(",") != -1)
                        {
                            string Status = tempStatus.Substring(0, tempIndexOf);

                            int setIndex = m_statusCheckComboBox.Items.IndexOf(Status);
                            m_statusCheckComboBox.SetItemChecked(setIndex, true);

                            tempStatus = tempStatus.Substring(tempIndexOf + 1);
                            tempIndexOf = tempStatus.IndexOf(",");
                        }

                        break;
                    case (int)PlayerListSettingEnum.BirthdayBetween://Birthday From
                        m_birthdayCheck.Checked = true;
                        tempDateTime = Convert.ToDateTime(pls.SettingValue);
                        m_fromBirthdayMonth.SelectedIndex = tempDateTime.Month - 1;
                        m_fromBirthdayDay.SelectedIndex = tempDateTime.Day - 1;
                        t_summary_DateFrom = tempDateTime.ToString("MMM dd");
                        //summary_Birthday.Text = tempDateTime.ToString();

                        break;
                    case (int)PlayerListSettingEnum.BirthdayTo://BirthDay to
                        //m_birthdayCheck.Checked = true;
                        tempDateTime = Convert.ToDateTime(pls.SettingValue);
                        m_toBirthdayMonth.SelectedIndex = tempDateTime.Month - 1;
                        m_toBirthdayDay.SelectedIndex = tempDateTime.Day - 1;
                        summary_Birthday.Text = "Between " + t_summary_DateFrom +" And "+ tempDateTime.ToString("MMM dd");
                        break;

                    case (int)PlayerListSettingEnum.City://VIP City
                        m_findAllVIPCheckBox.Checked = true;
                        m_locationTypeComboBox.SelectedIndex = 0;//City

                        tempIndexOf = 0;
                        //tempIndexOf = pls.SettingValue.IndexOf(",");
                        string tempCity = pls.SettingValue.ToString() + ",";
                        summary_lblLocation.Text = "City";
                        summary_Location.Text = tempCity.Remove(tempCity.Length - 1, 1);
                        tempIndexOf = tempCity.IndexOf(",");
                        while (tempCity.IndexOf(",") != -1)
                        {
                            string City = tempCity.Substring(0, tempIndexOf);
                            m_locListBoxSelected.Items.Add(City);
                            m_locListBox.Items.Remove(City);

                            tempCity = tempCity.Substring(tempIndexOf + 1);
                            tempIndexOf = tempCity.IndexOf(",");
                        }

                        break;

                    case (int)PlayerListSettingEnum.State://VIP State
                        m_findAllVIPCheckBox.Checked = true;
                        m_locationTypeComboBox.SelectedIndex = 1;//State

                        tempIndexOf = 0;
                        //tempIndexOf = pls.SettingValue.IndexOf(",");
                        string tempState = pls.SettingValue.ToString() + ",";
                        summary_lblLocation.Text = "State";
                        summary_Location.Text = tempState.Remove(tempState.Length - 1, 1);
                        tempIndexOf = tempState.IndexOf(",");

                        while (tempState.IndexOf(",") != -1)
                        {
                            string State = tempState.Substring(0, tempIndexOf);
                            m_locListBoxSelected.Items.Add(State);
                            m_locListBox.Items.Remove(State);

                            tempState = tempState.Substring(tempIndexOf + 1);
                            tempIndexOf = tempState.IndexOf(",");
                        }

                        break;

                    case (int)PlayerListSettingEnum.Postal://VIP Postal
                        m_findAllVIPCheckBox.Checked = true;
                        m_locationTypeComboBox.SelectedIndex = 2;//Postal

                        tempIndexOf = 0;
                        //tempIndexOf = pls.SettingValue.IndexOf(",");
                        string tempPostal = pls.SettingValue.ToString() + ",";
                        summary_lblLocation.Text = "Postal";
                        summary_Location.Text = tempPostal.Remove(tempPostal.Length - 1, 1);
                        tempIndexOf = tempPostal.IndexOf(",");

                        while (tempPostal.IndexOf(",") != -1)
                        {
                            string Postal = tempPostal.Substring(0, tempIndexOf);
                            m_locListBoxSelected.Items.Add(Postal);
                            m_locListBox.Items.Remove(Postal);

                            tempPostal = tempPostal.Substring(tempIndexOf + 1);
                            tempIndexOf = tempPostal.IndexOf(",");
                        }

                        break;

                    case (int)PlayerListSettingEnum.Country://VIP Country
                        m_findAllVIPCheckBox.Checked = true;
                        m_locationTypeComboBox.SelectedIndex = 3;//Country

                        tempIndexOf = 0;
                        // tempIndexOf = pls.SettingValue.IndexOf(",");
                        string tempCountry = pls.SettingValue.ToString() + ",";
                          summary_lblLocation.Text = "Country";
                          summary_Location.Text = tempCountry.Remove(tempCountry.Length - 1, 1);
                        tempIndexOf = tempCountry.IndexOf(",");
                        while (tempCountry.IndexOf(",") != -1)
                        {
                            string Postal = tempCountry.Substring(0, tempIndexOf);
                            m_locListBoxSelected.Items.Add(Postal);
                            m_locListBox.Items.Remove(Postal);

                            tempCountry = tempCountry.Substring(tempIndexOf + 1);
                            tempIndexOf = tempCountry.IndexOf(",");
                        }

                        break;

                    case (int)PlayerListSettingEnum.VisitedFrom://Date "From" days played.

                        tempDateTime = Convert.ToDateTime(pls.SettingValue);                       
                        t_summary_DateFrom_dt = tempDateTime;
                        m_dateRangefromDPDatePicker.Value = tempDateTime;
                        break;

                    case (int)PlayerListSettingEnum.VisitedTo://Date "To" days played.

                        tempDateTime = Convert.ToDateTime(pls.SettingValue);

                        summary_VisitedDateFrom.Text =  t_summary_DateFrom_dt.ToString("MMM dd") +"  to " +  tempDateTime.ToString("MMM dd");
                        m_dateRangetoDPDatePicker.Value = tempDateTime;
               
                        break;

                    case (int)PlayerListSettingEnum.LastVisitBetween://Date last visit from.
                        m_lastVisitCheck.Checked = true;
                        tempDateTime = Convert.ToDateTime(pls.SettingValue);
                        t_summary_DateFrom_dt = tempDateTime;
                        m_fromLastVisit.Value = tempDateTime;
                        break;

                    case (int)PlayerListSettingEnum.LastVisitTo://Date last visit to.
                        //m_lastVisitCheck.Checked = true;
                        tempDateTime = Convert.ToDateTime(pls.SettingValue);
                        m_toLastVisit.Value = tempDateTime;
                        summary_LastVisitDateFrom.Text = t_summary_DateFrom_dt.ToString("MMM dd") + "  to " + tempDateTime.ToString("MMM dd");
                        break;

                    case (int)PlayerListSettingEnum.NumberofDaysVisitedFrom://Days visited range from.
                        m_daysPlayedCheck.Checked = true;
                        m_rangeDPRadioButton.Checked = true;
                        t_summary_value = pls.SettingValue.ToString();
                        m_fromRangeDPTextBox.Text = pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.NumberofDaysVisitedTo://Days visited ranger to.
                        m_toRangeDPTextBox.Text = pls.SettingValue.ToString();
                        summary_NDaysVisitedFrom.Text = "Between "+ t_summary_value + " and " + pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.NumberofDaysVisitedGreaterThan://Days visited option >.
                        m_daysPlayedCheck.Checked = true;
                        m_rangeoptionDPRadioButton.Checked = true;
                        m_rangeOptionDPComboBox.SelectedIndex = 0;
                        m_rangeOptionDPTextBox.Text = pls.SettingValue.ToString();
                        summary_NDaysVisitedFrom.Text = m_rangeOptionDPComboBox.SelectedItem +" to " + pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.NumberofDaysVisitedGreaterThanOrEqualTo://Days visited option >=.
                        m_daysPlayedCheck.Checked = true;
                        m_rangeoptionDPRadioButton.Checked = true;
                        m_rangeOptionDPComboBox.SelectedIndex = 1;
                        m_rangeOptionDPTextBox.Text = pls.SettingValue.ToString();
                        summary_NDaysVisitedFrom.Text = m_rangeOptionDPComboBox.SelectedItem + " to " + pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.NumberofDaysVisitedEqualTo://Days visited option =.
                        m_daysPlayedCheck.Checked = true;
                        m_rangeoptionDPRadioButton.Checked = true;
                        m_rangeOptionDPComboBox.SelectedIndex = 2;
                        m_rangeOptionDPTextBox.Text = pls.SettingValue.ToString();
                       // summary_NDaysVisited.Text = pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.NumberofDaysVisitedLessThanOrEqualTo://Days visited option <=.
                        m_daysPlayedCheck.Checked = true;
                        m_rangeoptionDPRadioButton.Checked = true;
                        m_rangeOptionDPComboBox.SelectedIndex = 3;
                        m_rangeOptionDPTextBox.Text = pls.SettingValue.ToString();
                        summary_NDaysVisitedFrom.Text = m_rangeOptionDPComboBox.SelectedItem + " to " + pls.SettingValue.ToString();
                       // summary_NDaysVisited.Text = pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.NumberofDaysVisitedLessThan://Days visited option <.
                        m_daysPlayedCheck.Checked = true;
                        m_rangeoptionDPRadioButton.Checked = true;
                        m_rangeOptionDPComboBox.SelectedIndex = 4;
                        m_rangeOptionDPTextBox.Text = pls.SettingValue.ToString();
                        summary_NDaysVisitedFrom.Text = m_rangeOptionDPComboBox.SelectedItem + " to " + pls.SettingValue.ToString();
                       // summary_NDaysVisited.Text = pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.NumberofSessionsVisitedFrom://Sessions visited range from.
                        m_sessionPlayedCheck.Checked = true;
                        m_rangeSPRadioButton.Checked = true;
                        m_fromRangeSPTextBox.Text = pls.SettingValue.ToString();
                        t_summary_value = pls.SettingValue.ToString();
      
                        break;

                    case (int)PlayerListSettingEnum.NumberofSessionsVistsedTo://Session visited range to.
                        m_toRangeSPTextBox.Text = pls.SettingValue.ToString();
                        summary_NSessionVisitedFrom.Text = "Between " + t_summary_value + " and " + pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.NumberofSessionsVisitedGreaterThan://Session visited option >.
                        m_sessionPlayedCheck.Checked = true;
                        m_rangeoptionSPRadioButton.Checked = true;
                        m_rangeOptionSPComboBox.SelectedIndex = 0;
                        m_rangeOptionSPTextBox.Text = pls.SettingValue.ToString();
                        //summary_NSessionVisited.Text = pls.SettingValue.ToString();
                        summary_NSessionVisitedFrom.Text = m_rangeOptionSPComboBox.SelectedItem + " " + pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.NumberofSessionsVisitedGreaterThanOrEqualTo://Session visited option >=.
                        m_sessionPlayedCheck.Checked = true;
                        m_rangeoptionSPRadioButton.Checked = true;
                        m_rangeOptionSPComboBox.SelectedIndex = 1;
                        m_rangeOptionSPTextBox.Text = pls.SettingValue.ToString();
                        summary_NSessionVisitedFrom.Text = m_rangeOptionSPComboBox.SelectedItem + " to " + pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.NumberofSessionsVisitedEqualTo://Session visited option  =.
                        m_sessionPlayedCheck.Checked = true;
                        m_rangeoptionSPRadioButton.Checked = true;
                        m_rangeOptionSPComboBox.SelectedIndex = 2;
                        m_rangeOptionSPTextBox.Text = pls.SettingValue.ToString();
                        summary_NSessionVisitedFrom.Text = m_rangeOptionSPComboBox.SelectedItem + " to " + pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.NumberofSessionsVisitedLessThanOrEqualTo://Session visited option <=.
                        m_sessionPlayedCheck.Checked = true;
                        m_rangeoptionSPRadioButton.Checked = true;
                        m_rangeOptionSPComboBox.SelectedIndex = 3;
                        m_rangeOptionSPTextBox.Text = pls.SettingValue.ToString();
                        summary_NSessionVisitedFrom.Text = m_rangeOptionSPComboBox.SelectedItem + " to " + pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.NumberofSessionsVisitedLessThan://Session visited option <.
                        m_sessionPlayedCheck.Checked = true;
                        m_rangeoptionSPRadioButton.Checked = true;
                        m_rangeOptionSPComboBox.SelectedIndex = 4;
                        m_rangeOptionSPTextBox.Text = pls.SettingValue.ToString();
                        summary_NSessionVisitedFrom.Text = m_rangeOptionSPComboBox.SelectedItem + " " + pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.DaysofWeekSession://Days of week and sessions.
                        m_daysOfWeekAndSessionCheck.Checked = true;
                        tempIndexOf = 0;                  
                        tempIndexOf = pls.SettingValue.IndexOf(",");
                        string tempDays = "";

                        if (tempIndexOf != -1)
                        {
                            tempDays = pls.SettingValue.ToString() + ",";
                   
                            //summary_DaysWeek2.Text = tempDays;
                            while (tempDays.IndexOf(",") != -1)
                            {
                                string DaynSession = tempDays.Substring(0, tempIndexOf);
                                string Days = DaynSession.Substring(0, DaynSession.IndexOf("(") - 1);

                                string cSession = DaynSession.Substring(DaynSession.IndexOf("(") + 1);
                                cSession = cSession.Replace(")", ":");
                                if (summary_DaysWeek2.TextLength > 0)
                                {
                                    summary_DaysWeek2.AppendText(Environment.NewLine);
                                }
                                summary_DaysWeek2.AppendText(Days + "/ Session: ");//knc
                                populateDays(Days, cSession);

                                tempDays = tempDays.Substring(tempIndexOf + 1);
                                tempIndexOf = tempDays.IndexOf(",");
                            }
                        }
                        else
                        {
                            string DaynSession = pls.SettingValue.ToString();
                            string Days = DaynSession.Substring(0, DaynSession.IndexOf("(") - 1);
                            string cSession = DaynSession.Substring(DaynSession.IndexOf("(") + 1);
                            cSession = cSession.Replace(")", ":");

                            if (cSession.Length == 21)
                            {
                                cSession = "ALL";
                            }
               
                            populateDays(Days, cSession);
                        }
                        break;

                    case (int)PlayerListSettingEnum.SpendFrom://Date spend from (date).
                        tempDateTime = Convert.ToDateTime(pls.SettingValue);
                        m_fromSpendDate.Value = tempDateTime;
                        t_summary_DateFrom_dt = tempDateTime;
                        break;

                    case (int)PlayerListSettingEnum.SpendTo://Date spend to (date).
                        tempDateTime = Convert.ToDateTime(pls.SettingValue);
                        m_toSpendDate.Value = tempDateTime;
                        summary_SpendDateFrom.Text = t_summary_DateFrom_dt.ToString("MMM dd") + " to " + tempDateTime.ToString("MMM dd");
                        //summary_spendDateFrom.Text = tempDateTime.ToString();
                        break;

                    case (int)PlayerListSettingEnum.ProductPurchased://Product purchased.
                        m_ProductCheckBox.Checked = true;
                        string tempProduct = pls.SettingValue.ToString() + ",";
                        tempProduct = tempProduct.Replace("/|\\", ",");
                        tempIndexOf = tempProduct.IndexOf(",");
                        summary_ProductPurchase2.Text = tempProduct;
                        while (tempProduct.IndexOf(",") != -1)
                        {                            //var indexof = m_ProductCheckBox2.Items.OfType<string>().;//IndexOf(Product);
                            string Product = tempProduct.Substring(0, tempIndexOf);

                            // int test3 =  m_ProductCheckBox2.FindString(Product); Not working
                            //I have to all of this trouble just to find the index of a certain item of a checkcombobox :(.
                            foreach (object o in m_ProductCheckBox2.Items)
                            {

                                Type x = o.GetType();
                                IList<System.Reflection.PropertyInfo> props = new List<System.Reflection.PropertyInfo>(x.GetProperties());
                                int indexOf = -1;
                                bool Exit = false;
                                foreach (System.Reflection.PropertyInfo prop in props)
                                {
                                    object propValue = prop.GetValue(o, null);
                                    if (prop.Name == "Value")
                                    {
                                        indexOf = Convert.ToInt32(propValue);
                                    }
                                    else
                                    {
                                        if (propValue.ToString() == Product)
                                        {
                                            m_ProductCheckBox2.SetItemChecked(indexOf, true);
                                            Exit = true;
                                            break;
                                        }
                                    }
                                }

                                if (Exit == true)
                                {
                                    break;
                                }
                            }
                            tempProduct = tempProduct.Substring(tempIndexOf + 1);
                            tempIndexOf = tempProduct.IndexOf(",");
                        }
                        break;

                    case (int)PlayerListSettingEnum.PointBalanceFrom://Point balance range min.
                        m_pointBalanceCheck.Checked = true;
                        m_rangePBRadio.Checked = true;
                        m_minPointBalance.Text = pls.SettingValue.ToString();
                        //summary_NSpendFrom.Text = pls.SettingValue.ToString();
                        t_summary_value = pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.PointBalanceTo://Point balance range max.           
                        m_maxPointBalance.Text = pls.SettingValue.ToString();
                        summary_PBFrom.Text =  "Between " + t_summary_value.ToString() + " to " +  pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.PointBalanceGreaterThan://Point balance option >.
                        m_pointBalanceCheck.Checked = true;
                        m_optionPBRadio.Checked = true;
                        m_optionSelectedPBCombo.SelectedIndex = 0;
                        m_optionValuePBText.Text = pls.SettingValue.ToString();
                        summary_PBFrom.Text = m_optionSelectedPBCombo.SelectedItem  + " " + pls.SettingValue.ToString();
                       // summary_NSpend.Text = pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.PointBalanceGreaterThanOrEqualTo://Point balance option >=.
                        m_pointBalanceCheck.Checked = true;
                        m_optionPBRadio.Checked = true;
                        m_optionSelectedPBCombo.SelectedIndex = 1;
                        m_optionValuePBText.Text = pls.SettingValue.ToString();
                        summary_PBFrom.Text = m_optionSelectedPBCombo.SelectedItem + " to " + pls.SettingValue.ToString();
                     //   summary_NSpend.Text = pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.PointBalanceEqualTo://Point balance option =.
                        m_pointBalanceCheck.Checked = true;
                        m_optionPBRadio.Checked = true;
                        m_optionSelectedPBCombo.SelectedIndex = 2;
                        m_optionValuePBText.Text = pls.SettingValue.ToString();
                      //  summary_NSpend.Text = pls.SettingValue.ToString();
                        summary_PBFrom.Text = m_optionSelectedPBCombo.SelectedItem + " to " + pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.PointBalanceLessThanOrEqualTo://Point balance option <=.
                        m_pointBalanceCheck.Checked = true;
                        m_optionPBRadio.Checked = true;
                        m_optionSelectedPBCombo.SelectedIndex = 3;
                        m_optionValuePBText.Text = pls.SettingValue.ToString();
                        summary_PBFrom.Text = m_optionSelectedPBCombo.SelectedItem + " to " + pls.SettingValue.ToString();
                      //  summary_NSpend.Text = pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.PointBalanceLessThan://Point balance option <.
                        m_pointBalanceCheck.Checked = true;
                        m_optionPBRadio.Checked = true;
                        m_optionSelectedPBCombo.SelectedIndex = 4;
                        m_optionValuePBText.Text = pls.SettingValue.ToString();
                     //   summary_NSpend.Text = pls.SettingValue.ToString();
                        summary_PBFrom.Text = m_optionSelectedPBCombo.SelectedItem + " " + pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.SpendFromvalue://Spend range from.
                        m_spendCheck.Checked = true;
                        m_rangeSARadio.Checked = true;
                        m_fromSpend.Text = pls.SettingValue.ToString();
                        //summary_NSpendFrom.Text = pls.SettingValue.ToString();
                        t_summary_value = pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.SpendTovalue:///Spend  range from.           
                        m_toSpend.Text = pls.SettingValue.ToString();
                        summary_NSpendFrom.Text = "Between " + t_summary_value.ToString() + " to " + pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.SpendGreaterThan:///Spend  option >.
                        m_spendCheck.Checked = true;
                        m_OptionSARadio.Checked = true;
                        m_optionSelectedSACombo.SelectedIndex = 0;
                        m_optionValueSAText.Text = pls.SettingValue.ToString();
                     //   summary_NSpend.Text = pls.SettingValue.ToString();
                        summary_NSpendFrom.Text = m_optionSelectedSACombo.SelectedItem + " " + pls.SettingValue.ToString();
            
                        break;

                    case (int)PlayerListSettingEnum.SpendGreaterThanOrEqualTo:///Spend option >=.
                        m_spendCheck.Checked = true;
                        m_OptionSARadio.Checked = true;
                        m_optionSelectedSACombo.SelectedIndex = 1;
                        m_optionValueSAText.Text = pls.SettingValue.ToString();
                     //   summary_NSpend.Text = pls.SettingValue.ToString();
                        summary_NSpendFrom.Text = m_optionSelectedSACombo.SelectedItem + " to " + pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.SpendEqualTo:///Spend  option =.
                        m_spendCheck.Checked = true;
                        m_OptionSARadio.Checked = true;
                        m_optionSelectedSACombo.SelectedIndex = 2;
                        m_optionValueSAText.Text = pls.SettingValue.ToString();
                  //      summary_NSpend.Text = pls.SettingValue.ToString();
                        summary_NSpendFrom.Text = m_optionSelectedSACombo.SelectedItem + " to " + pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.SpendLessThanOrEqualTo:///Spend  option <=.
                        m_spendCheck.Checked = true;
                        m_OptionSARadio.Checked = true;
                        m_optionSelectedSACombo.SelectedIndex = 3;
                        m_optionValueSAText.Text = pls.SettingValue.ToString();
                        //summary_NSpend.Text = pls.SettingValue.ToString();
                        summary_NSpendFrom.Text = m_optionSelectedSACombo.SelectedItem + " to " + pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.SpendLessThan:///Spend option <.
                        m_spendCheck.Checked = true;
                        m_OptionSARadio.Checked = true;
                        m_optionSelectedSACombo.SelectedIndex = 4;
                        m_optionValueSAText.Text = pls.SettingValue.ToString();
                       // summary_NSpend.Text = pls.SettingValue.ToString();
                        summary_NSpendFrom.Text = m_optionSelectedSACombo.SelectedItem + " " + pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.AverageSpendFrom://Average spend range from.
                        m_averageRadio.Checked = true;
                        m_rangeSARadio.Checked = true;
                        m_fromSpend.Text = pls.SettingValue.ToString();
                        t_summary_value = pls.SettingValue.ToString();
                        //summary_NAverageFrom.Text = pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.AverageSpendTo:///Average spend  range from.           
                        m_toSpend.Text = pls.SettingValue.ToString();
                        summary_NAverageFrom.Text = "Between " + t_summary_value + " to " + pls.SettingValue.ToString(); 
                        //summary_NAverageTo.Text = pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.AverageSpendGreaterThan:///Average spend  option >.
                        m_averageRadio.Checked = true;
                        m_OptionSARadio.Checked = true;
                        m_optionSelectedSACombo.SelectedIndex = 0;
                        m_optionValueSAText.Text = pls.SettingValue.ToString();
                        //summary_NAverage.Text = pls.SettingValue.ToString();
                        summary_NAverageFrom.Text = m_optionSelectedSACombo.SelectedItem + " " + pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.AverageGreaterThanOrEqualTo:///Average spend option >=.
                        m_averageRadio.Checked = true;
                        m_OptionSARadio.Checked = true;
                        m_optionSelectedSACombo.SelectedIndex = 1;
                        m_optionValueSAText.Text = pls.SettingValue.ToString();
                        summary_NAverageFrom.Text = m_optionSelectedSACombo.SelectedItem + " to " + pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.AverageEqualTo:///Average spend  option =.
                        m_averageRadio.Checked = true;
                        m_OptionSARadio.Checked = true;
                        m_optionSelectedSACombo.SelectedIndex = 2;
                        m_optionValueSAText.Text = pls.SettingValue.ToString();
                        summary_NAverageFrom.Text = m_optionSelectedSACombo.SelectedItem + " to " + pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.AverageLessThanOrEqualTo:///Average spend  option <=.
                        m_averageRadio.Checked = true;
                        m_OptionSARadio.Checked = true;
                        m_optionSelectedSACombo.SelectedIndex = 3;
                        m_optionValueSAText.Text = pls.SettingValue.ToString();
                        summary_NAverageFrom.Text = m_optionSelectedSACombo.SelectedItem + " to " + pls.SettingValue.ToString();
                        break;

                    case (int)PlayerListSettingEnum.AverageLessThan:///Average spend option <.
                        m_averageRadio.Checked = true;
                        m_OptionSARadio.Checked = true;
                        m_optionSelectedSACombo.SelectedIndex = 4;
                        m_optionValueSAText.Text = pls.SettingValue.ToString();
                        summary_NAverageFrom.Text = m_optionSelectedSACombo.SelectedItem + " " + pls.SettingValue.ToString();
                        break;
                }
            }
        }

        /// <summary>
        /// Clears out the errors on the UI
        /// </summary>
        private void clearErrorProvider()
        {
            m_errorProvider.SetError(m_birthdayCheck, string.Empty);
            m_errorProvider.SetError(m_statusCheck, string.Empty); // Rally US493
            m_errorProvider.SetError(m_pointBalanceCheck, string.Empty);
            m_errorProvider.SetError(m_minPointBalance, string.Empty);
            m_errorProvider.SetError(m_maxPointBalance, string.Empty);
            m_errorProvider.SetError(m_rangePBRadio, string.Empty);
            m_errorProvider.SetError(m_optionSelectedPBCombo, string.Empty);
            m_errorProvider.SetError(m_optionPBRadio, string.Empty);
            m_errorProvider.SetError(m_optionValuePBText, string.Empty);
            m_errorProvider.SetError(m_spendCheck, string.Empty);
            m_errorProvider.SetError(m_rangeSARadio, string.Empty);
            m_errorProvider.SetError(m_fromSpend, string.Empty);
            m_errorProvider.SetError(m_toSpend, string.Empty);
            m_errorProvider.SetError(m_averageRadio, string.Empty);
            m_errorProvider.SetError(m_rangeSARadio, string.Empty);
            m_errorProvider.SetError(m_OptionSARadio, string.Empty);
            m_errorProvider.SetError(m_fromSpend, string.Empty);
            m_errorProvider.SetError(m_toSpend, string.Empty);
            m_errorProvider.SetError(m_optionSelectedSACombo, string.Empty);
            m_errorProvider.SetError(m_optionValueSAText, string.Empty);
            m_errorProvider.SetError(m_lastVisitCheck, string.Empty);
            m_errorProvider.SetError(m_averageRadio, string.Empty);
            m_errorProvider.SetError(m_locationTypeComboBox, string.Empty);
            m_errorProvider.SetError(m_locListBoxSelected, string.Empty);
            m_errorProvider.SetError(m_daysPlayedCheck, string.Empty);
            m_errorProvider.SetError(m_rangeDPRadioButton, string.Empty);
            m_errorProvider.SetError(m_fromRangeDPTextBox, string.Empty);
            m_errorProvider.SetError(m_toRangeDPTextBox, string.Empty);
            m_errorProvider.SetError(m_rangeoptionDPRadioButton, string.Empty);
            m_errorProvider.SetError(m_rangeOptionDPComboBox, string.Empty);
            m_errorProvider.SetError(m_rangeOptionDPTextBox, string.Empty);
            m_errorProvider.SetError(m_sessionPlayedCheck, string.Empty);
            m_errorProvider.SetError(m_rangeSPRadioButton, string.Empty);
            m_errorProvider.SetError(m_rangeoptionSPRadioButton, string.Empty);
            m_errorProvider.SetError(m_fromRangeSPTextBox, string.Empty);
            m_errorProvider.SetError(m_toRangeSPTextBox, string.Empty);
            m_errorProvider.SetError(m_rangeOptionSPTextBox, string.Empty);
            m_errorProvider.SetError(m_rangeOptionSPComboBox, string.Empty);
            m_errorProvider.SetError(m_dateRangefromDPDatePicker, string.Empty);
            m_errorProvider.SetError(m_daysOfWeekAndSessionCheck, string.Empty);
            m_errorProvider.SetError(m_ProductCheckBox2, string.Empty);
            m_errorProvider.SetError(m_statusCheckComboBox, string.Empty);
            m_errorProvider.SetError(m_fromSpendDate, string.Empty);
            //m_errorProvider.SetError(txtbxDefinitionName, string.Empty);
            m_errorProvider.SetError(btnSaveList, string.Empty);
        }

        private void populateSessions(CheckedComboBox cmbx, string Sessions)
        {
            int TempIndexOf = 0;
            TempIndexOf = Sessions.IndexOf(":");

            if (TempIndexOf != -1 && Sessions.Count() != 21)
            {
                RichTextBox trchTxtBxText = new RichTextBox();
                trchTxtBxText.Text = "";
                while (Sessions.IndexOf(":") != -1)
                {
                    int session;
                    bool result = Int32.TryParse(Sessions.Substring(0, TempIndexOf), out session);
                    if (trchTxtBxText.TextLength > 0)
                    {
                        trchTxtBxText.AppendText(", ");
                    }
                    trchTxtBxText.AppendText(session.ToString());
                    if (result == true)
                    {
                        cmbx.SetItemChecked(session, true);
                    }

                    Sessions = Sessions.Substring(TempIndexOf + 1);
                    TempIndexOf = Sessions.IndexOf(":");

                }
               // trchTxtBxText.Text = trchTxtBxText.Text.Remove(trchTxtBxText.Text.Length - 1, 1);
                summary_DaysWeek2.AppendText(trchTxtBxText.Text);
            }
            else
            {
                cmbx.SetItemChecked(0, true);
                Sessions = Sessions.Remove(Sessions.Length - 1, 1);
                Sessions = Sessions.Replace(":", ", ");
                summary_DaysWeek2.AppendText(Sessions);
            }
        }
        
        private void populateDays(string days, string Sessions)
        {
            //int TempIndexOf = 0;
            CheckedComboBox cmbx = new CheckedComboBox();
            switch (days)
            {
                case "All":
                    m_allDaysVisitCheck.Checked = true;
                    cmbx = m_checkComboAllSession;
                    break;
                case "Mon":
                    m_monDaysVisitCheck.Checked = true;
                    cmbx = m_checkComboMONSession;
                    break;
                case "Tue":
                    m_tuesDaysVisitCheck.Checked = true;
                    cmbx = m_checkComboTUESession;
                    break;
                case "Wed":
                    m_wedDaysVisitCheck.Checked = true;
                    cmbx = m_checkComboWEDSession;
                    break;
                case "Thu":
                    m_thursDaysVisitCheck.Checked = true;
                    cmbx = m_checkComboTHURSSession;
                    break;
                case "Fri":
                    m_friDaysVisitCheck.Checked = true;
                    cmbx = m_checkComboFRISession;
                    break;
                case "Sat":
                    m_satDaysVisitCheck.Checked = true;
                    cmbx = m_checkComboSATSession;
                    break;
                case "Sun":
                    m_sunDaysVisitCheck.Checked = true;
                    cmbx = m_checkComboSUNSession;
                    break;
            }

            populateSessions(cmbx, Sessions);
        }
        
        /// <summary>
        /// Updates the "day of week" checkbox UI to match the data
        /// </summary>
        private void UpdateDowCheckBoxes(bool keepValues = false)
        {
            DateTime from = m_dateRangefromDPDatePicker.Value;
            DateTime to = m_dateRangetoDPDatePicker.Value;

            int numOfDays = to.Subtract(from).Days + 1;
            bool enableFields = m_daysOfWeekAndSessionCheck.Checked; // cut down on UI references

            m_allDaysVisitCheck.Enabled = m_monDaysVisitCheck.Enabled = m_tuesDaysVisitCheck.Enabled =
                m_wedDaysVisitCheck.Enabled = m_thursDaysVisitCheck.Enabled = m_friDaysVisitCheck.Enabled =
                m_satDaysVisitCheck.Enabled = m_sunDaysVisitCheck.Enabled = enableFields;

            if (numOfDays < 7 && enableFields)
            {
                for (int i = 0; i < numOfDays; i++)
                {
                    switch (from.DayOfWeek)
                    {
                        case DayOfWeek.Monday:
                            m_monDaysVisitCheck.Enabled = enableFields;
                            break;
                        case DayOfWeek.Tuesday:
                            m_tuesDaysVisitCheck.Enabled = enableFields;
                            break;
                        case DayOfWeek.Wednesday:
                            m_wedDaysVisitCheck.Enabled = enableFields;
                            break;
                        case DayOfWeek.Thursday:
                            m_thursDaysVisitCheck.Enabled = enableFields;
                            break;
                        case DayOfWeek.Friday:
                            m_friDaysVisitCheck.Enabled = enableFields;
                            break;
                        case DayOfWeek.Saturday:
                            m_satDaysVisitCheck.Enabled = enableFields;
                            break;
                        case DayOfWeek.Sunday:
                            m_sunDaysVisitCheck.Enabled = enableFields;
                            break;
                        default: // invalid
                            break;
                    }

                    from = from.AddDays(1);
                }
            }

            if (!keepValues)
            {
                m_allDaysVisitCheck.Checked = false;
                m_monDaysVisitCheck.Checked = false;
                m_tuesDaysVisitCheck.Checked = false;
                m_wedDaysVisitCheck.Checked = false;
                m_thursDaysVisitCheck.Checked = false;
                m_friDaysVisitCheck.Checked = false;
                m_satDaysVisitCheck.Checked = false;
                m_sunDaysVisitCheck.Checked = false;
            }
        }
        #endregion

        #region Events


      

        /// <summary>
        /// Handles the checkboxes' check changed event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the
        /// event data.</param>
        private void OptionChanged(object sender, EventArgs e)
        {
            m_errorProvider.Clear();
            CheckBox currentCheckbox = new CheckBox();
            RadioButton currentRadioButton = new RadioButton();

            if (sender is CheckBox)
            {
                currentCheckbox = (CheckBox)sender;
            }
            else if (sender is RadioButton)
            {
                currentRadioButton = (RadioButton)sender;
            }

            if (sender == m_findAllVIPCheckBox)
            {
                m_locationTypeComboBox.Enabled = m_findAllVIPCheckBox.Checked;
                m_locListBox.Enabled = m_findAllVIPCheckBox.Checked;
                m_addItemButton.Enabled = m_findAllVIPCheckBox.Checked;
                m_removeItemButton.Enabled = m_findAllVIPCheckBox.Checked;
                m_addAllItemButton.Enabled = m_findAllVIPCheckBox.Checked;
                m_removedAllItemButton.Enabled = m_findAllVIPCheckBox.Checked;
                m_locListBoxSelected.Enabled = m_findAllVIPCheckBox.Checked;

                if (m_findAllVIPCheckBox.Checked == true)
                {
                    //EnableSavedButton = true;
                    m_locListBox.BackColor = System.Drawing.SystemColors.Window;
                    m_locListBoxSelected.BackColor = System.Drawing.SystemColors.Window;
                }
                else if (m_findAllVIPCheckBox.Checked == false)
                {
                    m_locListBox.BackColor = System.Drawing.SystemColors.ButtonFace;
                    m_locListBoxSelected.BackColor = System.Drawing.SystemColors.ButtonFace;
                    m_locationTypeComboBox.Text = string.Empty;
                    m_locListBox.Items.Clear();
                    m_locListBoxSelected.Items.Clear();
                    m_locationTypeComboBox.SelectedIndex = -1;
                }
            }

            if (sender == m_birthdayCheck)
            {
                m_fromBirthdayMonth.Enabled = m_birthdayCheck.Checked;
                m_fromBirthdayDay.Enabled = m_birthdayCheck.Checked;
                m_toBirthdayMonth.Enabled = m_birthdayCheck.Checked;
                m_toBirthdayDay.Enabled = m_birthdayCheck.Checked;
                if (isNewList == true) EnableOrDisableSavedButton(currentCheckbox);
                //if (m_birthdayCheck.Checked) EnableSavedButton = true;
            }
            else if (sender == m_genderCheck)
            {
                m_genderList.Enabled = m_genderCheck.Checked; // FIX: DE1891
                if (m_genderCheck.Checked == false)
                {
                    m_genderList.SelectedIndex = 0;
                }

                if (isNewList == true) EnableOrDisableSavedButton(currentCheckbox);
                //if (m_genderCheck.Checked) EnableSavedButton = true;

            }
            else if (sender == m_pointBalanceCheck)
            {
                m_rangeOptionPBPanel.Enabled = m_pointBalanceCheck.Checked;

                if (m_pointBalanceCheck.Checked == false)
                {
                    m_rangePBRadio.Checked = false;
                    m_optionPBRadio.Checked = false;
                }

                // if (m_pointBalanceCheck.Checked) EnableSavedButton = true;
            }
            else if (sender == m_rangePBRadio)
            {
                m_errorProvider.SetError(m_optionPBRadio, string.Empty);
                m_minPointBalance.Enabled = m_rangePBRadio.Checked;
                m_maxPointBalance.Enabled = m_rangePBRadio.Checked;
                if (isNewList == true) EnableOrDisableSavedButton(currentRadioButton);

                if (m_rangePBRadio.Checked)
                {
                    countCheckBox = countCheckBox + 1;
                    if (!btnSaveList.Enabled) btnSaveList.Enabled = true;

                }
                else if (m_rangePBRadio.Checked == false)
                {
                    m_minPointBalance.Text = "0.00";
                    m_maxPointBalance.Text = "0.00";

                    countCheckBox = countCheckBox - 1;
                    if (countCheckBox == 0)
                    {
                        if (btnSaveList.Enabled) btnSaveList.Enabled = false;
                    }
                }
            }
            else if (sender == m_optionPBRadio)
            {
                m_errorProvider.SetError(m_rangePBRadio, string.Empty);
                m_optionSelectedPBCombo.Enabled = m_optionPBRadio.Checked;
                m_optionValuePBText.Enabled = m_optionPBRadio.Checked;
                if (isNewList == true) EnableOrDisableSavedButton(currentRadioButton);

                if (m_optionPBRadio.Checked == true)
                {
                    LoadSelectedOption(m_optionSelectedPBCombo);
                    //  EnableSavedButton = true;
                }
                else if (m_optionPBRadio.Checked == false)
                {
                    m_optionSelectedPBCombo.Items.Clear();
                    m_optionSelectedPBCombo.Text = string.Empty;
                    m_optionValuePBText.Text = "0.00";
                }
            }
            else if (sender == m_lastVisitCheck)
            {
                m_fromLastVisit.Enabled = m_lastVisitCheck.Checked;
                m_toLastVisit.Enabled = m_lastVisitCheck.Checked;
                if (isNewList == true) EnableOrDisableSavedButton(currentCheckbox);
                /// if (m_lastVisitCheck.Checked) EnableSavedButton = true;
            }
            else if (sender == m_spendCheck)
            {
                if (m_spendCheck.Checked == true)
                {
                    m_averageRadio.Checked = false;
                    m_RangeOptionSAPanel.Enabled = true;
                    m_fromSpendDate.Enabled = true;
                    m_toSpendDate.Enabled = true;
                    //  EnableSavedButton = true;
                }
                else
                {
                    m_RangeOptionSAPanel.Enabled = false;
                    if (m_ProductCheckBox.Checked == false)
                    {
                        m_fromSpendDate.Enabled = false;
                        m_toSpendDate.Enabled = false;
                    }
                    if (m_rangeSARadio.Checked)
                    {
                        m_rangeSARadio.Checked = false;
                    }
                    if (m_OptionSARadio.Checked)
                    {
                        m_OptionSARadio.Checked = false;
                    }
                }
            }
            else if (sender == m_averageRadio)
            {
                if (m_averageRadio.Checked == true)
                {
                    m_spendCheck.Checked = false;
                    m_RangeOptionSAPanel.Enabled = true;
                    m_fromSpendDate.Enabled = true;
                    m_toSpendDate.Enabled = true;
                    // EnableSavedButton = true;
                }
                else
                {
                    m_RangeOptionSAPanel.Enabled = false;
                    if (m_ProductCheckBox.Checked == false)
                    {
                        m_fromSpendDate.Enabled = false;
                        m_toSpendDate.Enabled = false;
                    }
                    if (m_rangeSARadio.Checked)
                    {
                        m_rangeSARadio.Checked = false;
                    }
                    if (m_OptionSARadio.Checked)
                    {
                        m_OptionSARadio.Checked = false;
                    }
                }
            }
            else if (sender == m_rangeSARadio)
            {
                m_errorProvider.SetError(m_OptionSARadio, string.Empty);
                m_fromSpend.Enabled = m_rangeSARadio.Checked;
                m_toSpend.Enabled = m_rangeSARadio.Checked;
                if (isNewList == true) EnableOrDisableSavedButton(currentRadioButton);
                if (m_rangeSARadio.Checked == false)
                {
                    m_fromSpend.Text = "0.00";
                    m_toSpend.Text = "0.00";
                }
                // if (m_rangeSARadio.Checked) EnableSavedButton = true;
            }
            else if (sender == m_OptionSARadio)
            {
                m_errorProvider.SetError(m_rangeSARadio, string.Empty);
                m_optionSelectedSACombo.Enabled = m_OptionSARadio.Checked;
                m_optionValueSAText.Enabled = m_OptionSARadio.Checked;
                if (isNewList == true) EnableOrDisableSavedButton(currentRadioButton);
                if (m_OptionSARadio.Checked == true)
                {
                    LoadSelectedOption(m_optionSelectedSACombo);
                    // EnableSavedButton = true;
                }
                else if (m_OptionSARadio.Checked == false)
                {
                    m_optionSelectedSACombo.Items.Clear();
                    m_optionSelectedSACombo.Text = string.Empty;
                    m_optionValueSAText.Text = "0.00";
                }
            }
            else if (sender == m_statusCheck) // Rally US493
            {
                m_statusCheckComboBox.Enabled = m_statusCheck.Checked;
                if (m_statusCheck.Checked == false)
                {
                    m_statusCheckComboBox.Items.Clear();
                    m_statusCheckComboBox.Text = string.Empty;
                }
                else
                {
                    // EnableSavedButton = true;
                    List<string> Statusx = new List<string>();
                    foreach (PlayerStatus status in PlayerManager.OperatorPlayerStatusList)
                    {
                        if (status.IsActive)
                        {
                            Statusx.Add(status.ToString());
                        }
                    }
                    Statusx.Sort();

                    foreach (string status in Statusx)
                    {
                        m_statusCheckComboBox.Items.Add(status);
                    }
                }
            }
            else if (sender == m_daysPlayedCheck)
            {
                m_errorProvider.Clear();
                m_rangeDPRadioButton.Enabled = m_daysPlayedCheck.Checked;
                m_rangeoptionDPRadioButton.Enabled = m_daysPlayedCheck.Checked;

                if (m_daysPlayedCheck.Checked)
                {
                    //EnableSavedButton = true;
                    m_dateRangefromDPDatePicker.Enabled = true;
                    m_dateRangetoDPDatePicker.Enabled = true;
                }

                else if (m_daysPlayedCheck.Checked == false
                    && m_sessionPlayedCheck.Checked == false
                    && m_daysOfWeekAndSessionCheck.Checked == false)
                {
                    m_dateRangefromDPDatePicker.Enabled = false;
                    m_dateRangetoDPDatePicker.Enabled = false;
                }

                if (m_rangeDPRadioButton.Checked == true)
                {
                    m_rangeDPRadioButton.Checked = false;
                    // EnableSavedButton = true;
                }
                if (m_rangeoptionDPRadioButton.Checked)
                {
                    m_rangeoptionDPRadioButton.Checked = false;
                }
                m_fromRangeDPTextBox.Text = "0";
                m_toRangeDPTextBox.Text = "0";
                m_rangeOptionDPComboBox.SelectedIndex = -1;
                m_rangeOptionDPTextBox.Text = "";
            }
            else if (sender == m_rangeDPRadioButton)
            {
                m_errorProvider.Clear();
                m_fromRangeDPTextBox.Enabled = m_rangeDPRadioButton.Checked;
                m_toRangeDPTextBox.Enabled = m_rangeDPRadioButton.Checked;

                m_rangeOptionDPComboBox.SelectedIndex = -1;
                m_rangeOptionDPTextBox.Text = "";

                if (isNewList == true) EnableOrDisableSavedButton(currentRadioButton);

            }
            else if (sender == m_rangeoptionDPRadioButton)
            {
                m_errorProvider.Clear();
                m_rangeOptionDPComboBox.Enabled = m_rangeoptionDPRadioButton.Checked;
                m_rangeOptionDPTextBox.Enabled = m_rangeoptionDPRadioButton.Checked;
                if (isNewList == true) EnableOrDisableSavedButton(currentRadioButton);

                if (m_rangeoptionDPRadioButton.Checked == true)
                {
                    m_fromRangeDPTextBox.Text = "0";
                    m_toRangeDPTextBox.Text = "0";

                }
                else if (m_rangeoptionDPRadioButton.Checked == false)
                {
                    m_rangeOptionDPComboBox.Text = string.Empty;
                }
            }
            else if (sender == m_sessionPlayedCheck)
            {
                m_errorProvider.Clear();
                m_rangeSPRadioButton.Enabled = m_sessionPlayedCheck.Checked;
                m_rangeoptionSPRadioButton.Enabled = m_sessionPlayedCheck.Checked;

                if (m_sessionPlayedCheck.Checked)
                {
                    m_dateRangefromDPDatePicker.Enabled = true;
                    m_dateRangetoDPDatePicker.Enabled = true;
                }
                else if (m_daysPlayedCheck.Checked == false
                    && m_sessionPlayedCheck.Checked == false
                    && m_daysOfWeekAndSessionCheck.Checked == false)
                {
                    m_dateRangefromDPDatePicker.Enabled = false;
                    m_dateRangetoDPDatePicker.Enabled = false;
                }

                if (m_rangeSPRadioButton.Checked == true)
                {
                    m_rangeSPRadioButton.Checked = false;
                }
                if (m_rangeoptionSPRadioButton.Checked)
                {
                    m_rangeoptionSPRadioButton.Checked = false;
                }
                m_fromRangeSPTextBox.Text = "0";
                m_toRangeSPTextBox.Text = "0";
                m_rangeOptionSPComboBox.SelectedIndex = -1;
                m_rangeOptionSPTextBox.Text = "";
            }
            else if (sender == m_rangeSPRadioButton)
            {
                m_errorProvider.Clear();
                m_fromRangeSPTextBox.Enabled = m_rangeSPRadioButton.Checked;
                m_toRangeSPTextBox.Enabled = m_rangeSPRadioButton.Checked;

                m_rangeOptionSPComboBox.SelectedIndex = -1;
                m_rangeOptionSPTextBox.Text = "";
                if (isNewList == true) EnableOrDisableSavedButton(currentRadioButton);
            }
            else if (sender == m_rangeoptionSPRadioButton)
            {
                m_errorProvider.Clear();
                m_rangeOptionSPComboBox.Enabled = m_rangeoptionSPRadioButton.Checked;
                m_rangeOptionSPTextBox.Enabled = m_rangeoptionSPRadioButton.Checked;
                if (isNewList == true) EnableOrDisableSavedButton(currentRadioButton);

                if (m_rangeoptionSPRadioButton.Checked == true)
                {
                    m_fromRangeSPTextBox.Text = "0";
                    m_toRangeSPTextBox.Text = "0";
                }
                else if (m_rangeoptionSPRadioButton.Checked == false)
                {
                    m_rangeOptionSPComboBox.Text = string.Empty;
                }
            }
            else if (sender == m_allDaysVisitCheck)
            {
                m_checkComboAllSession.Enabled = m_allDaysVisitCheck.Checked;

                if (m_allDaysVisitCheck.Checked == false)
                {
                    m_checkComboAllSession.Items.Clear();
                    m_checkComboAllSession.Text = string.Empty;
                }
                else
                {
                    for (int i = 0; i < SessionNumber.Length; i++)
                    {
                        CCBoxItem item = new CCBoxItem(SessionNumber[i], i);
                        m_checkComboAllSession.Items.Add(item);
                    }
                    m_checkComboAllSession.MaxDropDownItems = 10;
                    m_checkComboAllSession.DisplayMember = "Name";
                    m_checkComboAllSession.ValueSeparator = ", ";
                    m_checkComboAllSession.Text = "ALL";
                }
            }
            else if (sender == m_monDaysVisitCheck)
            {
                m_checkComboMONSession.Enabled = m_monDaysVisitCheck.Checked;

                if (m_monDaysVisitCheck.Checked == false)
                {
                    m_checkComboMONSession.Items.Clear();
                    m_checkComboMONSession.Text = string.Empty;
                }
                else
                {
                    for (int i = 0; i < SessionNumber.Length; i++)
                    {
                        CCBoxItem item = new CCBoxItem(SessionNumber[i], i);
                        m_checkComboMONSession.Items.Add(item);
                    }
                    m_checkComboMONSession.MaxDropDownItems = 10;
                    m_checkComboMONSession.DisplayMember = "Name";
                    m_checkComboMONSession.ValueSeparator = ", ";
                    m_checkComboMONSession.Text = "ALL";
                }
            }
            else if (sender == m_tuesDaysVisitCheck)
            {
                m_checkComboTUESession.Enabled = m_tuesDaysVisitCheck.Checked;

                if (m_tuesDaysVisitCheck.Checked == false)
                {
                    m_checkComboTUESession.Items.Clear();
                    m_checkComboTUESession.Text = string.Empty;
                }
                else
                {
                    for (int i = 0; i < SessionNumber.Length; i++)
                    {
                        CCBoxItem item = new CCBoxItem(SessionNumber[i], i);
                        m_checkComboTUESession.Items.Add(item);
                    }
                    m_checkComboTUESession.MaxDropDownItems = 10;
                    m_checkComboTUESession.DisplayMember = "Name";
                    m_checkComboTUESession.ValueSeparator = ", ";
                    m_checkComboTUESession.Text = "ALL";
                }
            }
            else if (sender == m_wedDaysVisitCheck)
            {
                m_checkComboWEDSession.Enabled = m_wedDaysVisitCheck.Checked;

                if (m_wedDaysVisitCheck.Checked == false)
                {
                    m_checkComboWEDSession.Items.Clear();
                    m_checkComboWEDSession.Text = string.Empty;
                }
                else
                {
                    for (int i = 0; i < SessionNumber.Length; i++)
                    {
                        CCBoxItem item = new CCBoxItem(SessionNumber[i], i);
                        m_checkComboWEDSession.Items.Add(item);
                    }
                    m_checkComboWEDSession.MaxDropDownItems = 10;
                    m_checkComboWEDSession.DisplayMember = "Name";
                    m_checkComboWEDSession.ValueSeparator = ", ";
                    m_checkComboWEDSession.Text = "ALL";
                }
            }
            else if (sender == m_thursDaysVisitCheck)
            {
                m_checkComboTHURSSession.Enabled = m_thursDaysVisitCheck.Checked;

                if (m_thursDaysVisitCheck.Checked == false)
                {
                    m_checkComboTHURSSession.Items.Clear();
                    m_checkComboTHURSSession.Text = string.Empty;
                }
                else
                {
                    for (int i = 0; i < SessionNumber.Length; i++)
                    {
                        CCBoxItem item = new CCBoxItem(SessionNumber[i], i);
                        m_checkComboTHURSSession.Items.Add(item);
                    }
                    m_checkComboTHURSSession.MaxDropDownItems = 10;
                    m_checkComboTHURSSession.DisplayMember = "Name";
                    m_checkComboTHURSSession.ValueSeparator = ", ";
                    m_checkComboTHURSSession.Text = "ALL";
                }
            }
            else if (sender == m_friDaysVisitCheck)
            {
                m_checkComboFRISession.Enabled = m_friDaysVisitCheck.Checked;

                if (m_friDaysVisitCheck.Checked == false)
                {
                    m_checkComboFRISession.Items.Clear();
                    m_checkComboFRISession.Text = string.Empty;
                }
                else
                {
                    for (int i = 0; i < SessionNumber.Length; i++)
                    {
                        CCBoxItem item = new CCBoxItem(SessionNumber[i], i);
                        m_checkComboFRISession.Items.Add(item);
                    }
                    m_checkComboFRISession.MaxDropDownItems = 10;
                    m_checkComboFRISession.DisplayMember = "Name";
                    m_checkComboFRISession.ValueSeparator = ", ";
                    m_checkComboFRISession.Text = "ALL";
                }
            }
            else if (sender == m_satDaysVisitCheck)
            {
                m_checkComboSATSession.Enabled = m_satDaysVisitCheck.Checked;

                if (m_satDaysVisitCheck.Checked == false)
                {
                    m_checkComboSATSession.Items.Clear();
                    m_checkComboSATSession.Text = string.Empty;
                }
                else
                {
                    for (int i = 0; i < SessionNumber.Length; i++)
                    {
                        CCBoxItem item = new CCBoxItem(SessionNumber[i], i);
                        m_checkComboSATSession.Items.Add(item);
                    }
                    m_checkComboSATSession.MaxDropDownItems = 10;
                    m_checkComboSATSession.DisplayMember = "Name";
                    m_checkComboSATSession.ValueSeparator = ", ";
                    m_checkComboSATSession.Text = "ALL";
                }
            }
            else if (sender == m_sunDaysVisitCheck)
            {
                m_checkComboSUNSession.Enabled = m_sunDaysVisitCheck.Checked;

                if (m_sunDaysVisitCheck.Checked == false)
                {
                    m_checkComboSUNSession.Items.Clear();
                    m_checkComboSUNSession.Text = string.Empty;
                }
                else
                {
                    for (int i = 0; i < SessionNumber.Length; i++)
                    {
                        CCBoxItem item = new CCBoxItem(SessionNumber[i], i);
                        m_checkComboSUNSession.Items.Add(item);
                    }
                    m_checkComboSUNSession.MaxDropDownItems = 10;
                    m_checkComboSUNSession.DisplayMember = "Name";
                    m_checkComboSUNSession.ValueSeparator = ", ";
                    m_checkComboSUNSession.Text = "ALL";
                }
            }
            else if (sender == m_daysOfWeekAndSessionCheck)
            {
                if (m_daysOfWeekAndSessionCheck.Checked)
                {
                    m_dateRangefromDPDatePicker.Enabled = true;
                    m_dateRangetoDPDatePicker.Enabled = true;
                }
                else if (m_daysPlayedCheck.Checked == false
                   && m_sessionPlayedCheck.Checked == false
                   && m_daysOfWeekAndSessionCheck.Checked == false)
                {
                    m_dateRangefromDPDatePicker.Enabled = false;
                    m_dateRangetoDPDatePicker.Enabled = false;
                }
                UpdateDowCheckBoxes();
            }
            else if (sender == m_ProductCheckBox)
            {

                if (m_ProductCheckBox.Checked == true)
                {
                    m_fromSpendDate.Enabled = true;
                    m_toSpendDate.Enabled = true;
                }
                else if (m_ProductCheckBox.Checked == false && m_spendCheck.Checked == false && m_averageRadio.Checked == false)
                {
                    m_fromSpendDate.Enabled = false;
                    m_toSpendDate.Enabled = false;
                }

                m_ProductCheckBox2.Enabled = m_ProductCheckBox.Checked;
                if (m_ProductCheckBox.Checked == false)
                {
                    m_ProductCheckBox2.Items.Clear();
                    m_ProductCheckBox2.Text = string.Empty;
                }
                else
                {
                    List<string> Productx = new List<string>();
                    foreach (ProductItem x in PlayerManager.EnabledProducts)
                    {
                        Productx.Add(x.ToString());
                    }
                    Productx.Sort();
                    Productx.Insert(0, "ALL");

                    string[] ProductName = Productx.ToArray();
                    int i = 0;
                    for (i = 0; i < ProductName.Length; i++)
                    {
                        CCBoxItem Product = new CCBoxItem(ProductName[i], i);
                        m_ProductCheckBox2.Items.Add(Product);

                    }

                    if (i > 10) { i = 10; }
                    m_ProductCheckBox2.MaxDropDownItems = i;//Gets or sets the maximum number of items to be shown in the drop-down portion of the ComboBox.
                    m_ProductCheckBox2.DisplayMember = "Name";
                    m_ProductCheckBox2.ValueSeparator = ", ";
                }
            }

            //US2649
        }

        /// <summary>
        /// Handles the birthday month lists' selected index changed event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the
        /// event data.</param>
        private void SelectedMonthChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            ComboBox dayList = null;

            if (combo != null && combo == m_fromBirthdayMonth)
                dayList = m_fromBirthdayDay;
            else if (combo != null && combo == m_toBirthdayMonth)
                dayList = m_toBirthdayDay;

            // Populate the days of the month.
            if (dayList != null)
            {
                dayList.BeginUpdate();
                dayList.Items.Clear();

                Calendar cal = CultureInfo.CurrentCulture.Calendar;
                int month = ((MonthItem)combo.SelectedItem).Number;
                int numDays = cal.GetDaysInMonth(DateTime.Now.Year, month);

                for (int day = 1; day <= numDays; day++)
                {
                    dayList.Items.Add(day);
                }

                dayList.EndUpdate();

                // Select the first day by default.
                if (dayList.Items.Count > 0)
                    dayList.SelectedIndex = 0;
            }
        }


        #region SAVEPLAYERLIST
        /// <summary>
        /// Handles the generate list button's click event. Also handles the save button's click event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the
        /// event data.</param>
        private void GenerateClick(object sender, EventArgs e)
        {
            Button ActiveButton = (Button)sender;

            clearErrorProvider();

            // Validate the input.
            if (!ValidateChildren(ValidationConstraints.Enabled | ValidationConstraints.Visible))
                return;

            if (ActiveButton_ == 0) { ActiveButton_ = Convert.ToInt32(ActiveButton.Tag); }

            if (ActiveButton_ == 1)
            {
                PlyrActListSetting = new PlayerActualListSetting();
                isSavedList = true;

                cmbxPlayerList2.Items.Remove(cmbxPlayerList2.SelectedItem);
            }
            else if (ActiveButton_ == 3)
            {
                PlyrActListSetting = new PlayerActualListSetting();
                isSavedList = true;
            }
            else if (ActiveButton_ == 2)
            {
                PlyrActListSetting = new PlayerActualListSetting();
                isDeleteList = true;
            }

            // Send the arguments to the parent.
            PlayerListParams args = new PlayerListParams();
            args.ListName = m_ListName;

            if (m_birthdayCheck.Checked)
            {
                args.UseBirthday = true;

                int month = ((MonthItem)m_fromBirthdayMonth.SelectedItem).Number;
                int day = Convert.ToInt32(m_fromBirthdayDay.SelectedItem, CultureInfo.CurrentCulture);

                args.FromBirthday = new DateTime(DateTime.Now.Year, month, day);
                SetListOfSetting((int)PlayerListSettingEnum.BirthdayBetween, args.FromBirthday.ToString());

                month = ((MonthItem)m_toBirthdayMonth.SelectedItem).Number;
                day = Convert.ToInt32(m_toBirthdayDay.SelectedItem, CultureInfo.CurrentCulture);

                args.ToBirthday = new DateTime(DateTime.Now.Year, month, day);
                SetListOfSetting((int)PlayerListSettingEnum.BirthdayTo, args.ToBirthday.ToString());
            }

            if (m_genderCheck.Checked)
            {
                args.UseGender = true;
                args.Gender = (string)m_genderList.SelectedItem; // FIX: DE1891      

                SetListOfSetting((int)PlayerListSettingEnum.Gender, args.Gender);
            }

            // Rally US493
            if (m_statusCheck.Checked)
            {
                args.UseStatus = true;
                //args.Status = ((PlayerStatus)m_statusList.SelectedItem).Id;
                // string statusID = m_statusID.Text;
                string statusID = m_statusCheckComboBox.Text;
                statusID = statusID.Replace(@", ", "/|\\");
                args.Status = statusID;

                SetListOfSetting((int)PlayerListSettingEnum.Status, args.Status);
            }

            // if(m_pointBalanceCheck.Checked)
            if (m_rangePBRadio.Checked)
            {
                args.UsePoints = true;
                args.PBIsRange = true;
                args.MinPoints = Convert.ToDecimal(m_minPointBalance.Text, CultureInfo.CurrentCulture);
                SetListOfSetting((int)PlayerListSettingEnum.PointBalanceFrom, args.MinPoints.ToString());
                args.MaxPoints = Convert.ToDecimal(m_maxPointBalance.Text, CultureInfo.CurrentCulture);
                SetListOfSetting((int)PlayerListSettingEnum.PointBalanceTo, args.MaxPoints.ToString());
            }
            else
            {
                args.MinPoints = Convert.ToDecimal("-1", CultureInfo.CurrentCulture);
            }

            if (m_optionPBRadio.Checked)
            {
                args.UsePoints = true;
                args.PBIsOption = true;
                string SelectionSelected;
                SelectionSelected = Selection(m_optionSelectedPBCombo.Text);
                args.PBOptionSelected = SelectionSelected;
                args.PBOptionValue = Convert.ToDecimal(m_optionValuePBText.Text, CultureInfo.CurrentCulture);

                switch (m_optionSelectedPBCombo.SelectedIndex)
                {
                    case 0:
                        SetListOfSetting((int)PlayerListSettingEnum.PointBalanceGreaterThan, args.PBOptionValue.ToString());
                        break;
                    case 1:
                        SetListOfSetting((int)PlayerListSettingEnum.PointBalanceGreaterThanOrEqualTo, args.PBOptionValue.ToString());
                        break;
                    case 2:
                        SetListOfSetting((int)PlayerListSettingEnum.PointBalanceEqualTo, args.PBOptionValue.ToString());
                        break;
                    case 3:
                        SetListOfSetting((int)PlayerListSettingEnum.PointBalanceLessThanOrEqualTo, args.PBOptionValue.ToString());
                        break;
                    case 4:
                        SetListOfSetting((int)PlayerListSettingEnum.PointBalanceLessThan, args.PBOptionValue.ToString());
                        break;
                }
            }

            if (m_lastVisitCheck.Checked)
            {
                args.UseLastVisit = true;
                args.FromLastVisit = m_fromLastVisit.Value;
                SetListOfSetting((int)PlayerListSettingEnum.LastVisitBetween, args.FromLastVisit.ToString());
                args.ToLastVisit = m_toLastVisit.Value;
                SetListOfSetting((int)PlayerListSettingEnum.LastVisitTo, args.ToLastVisit.ToString());
            }

            //Players spend range
            if (m_spendCheck.Checked && m_rangeSARadio.Checked)
            {
                args.UseSpend = true;
                args.SAIsRange = true;
                args.FromSpend = Convert.ToDecimal(m_fromSpend.Text, CultureInfo.CurrentCulture);
                args.ToSpend = Convert.ToDecimal(m_toSpend.Text, CultureInfo.CurrentCulture);
                args.FromSpendDate = m_fromSpendDate.Value;
                args.ToSpendDate = m_toSpendDate.Value;
                SetListOfSetting((int)PlayerListSettingEnum.SpendFromvalue, args.FromSpend.ToString());
                SetListOfSetting((int)PlayerListSettingEnum.SpendTovalue, args.ToSpend.ToString());
                SetListOfSetting((int)PlayerListSettingEnum.SpendFrom, args.FromSpendDate.ToString());
                SetListOfSetting((int)PlayerListSettingEnum.SpendTo, args.ToSpendDate.ToString());
            }

            //Players spend option.
            if (m_spendCheck.Checked && m_OptionSARadio.Checked)
            {
                args.UseSpend = true;
                args.SAOption = true;
                string SelectionSelected;
                SelectionSelected = Selection(m_optionSelectedSACombo.Text);
                args.SAOptionSelected = SelectionSelected;
                args.SAOptionValue = Convert.ToDecimal(m_optionValueSAText.Text, CultureInfo.CurrentCulture);
                args.FromSpendDate = m_fromSpendDate.Value;
                args.ToSpendDate = m_toSpendDate.Value;

                switch (m_optionSelectedSACombo.SelectedIndex)
                {
                    case 0:
                        SetListOfSetting((int)PlayerListSettingEnum.SpendGreaterThan, args.SAOptionValue.ToString());
                        break;
                    case 1:
                        SetListOfSetting((int)PlayerListSettingEnum.SpendGreaterThanOrEqualTo, args.SAOptionValue.ToString());
                        break;
                    case 2:
                        SetListOfSetting((int)PlayerListSettingEnum.SpendEqualTo, args.SAOptionValue.ToString());
                        break;
                    case 3:
                        SetListOfSetting((int)PlayerListSettingEnum.SpendLessThanOrEqualTo, args.SAOptionValue.ToString());
                        break;
                    case 4:
                        SetListOfSetting((int)PlayerListSettingEnum.SpendLessThan, args.SAOptionValue.ToString());
                        break;
                }

                SetListOfSetting((int)PlayerListSettingEnum.SpendFrom, args.FromSpendDate.ToString());
                SetListOfSetting((int)PlayerListSettingEnum.SpendTo, args.ToSpendDate.ToString());
            }

            //Average spend range.
            if (m_averageRadio.Checked && m_rangeSARadio.Checked)
            {
                args.UseAverageSpend = true;
                args.SAIsRange = true;
                args.FromSpend = Convert.ToDecimal(m_fromSpend.Text, CultureInfo.CurrentCulture);
                args.ToSpend = Convert.ToDecimal(m_toSpend.Text, CultureInfo.CurrentCulture);
                args.FromSpendDate = m_fromSpendDate.Value;
                args.ToSpendDate = m_toSpendDate.Value;

                SetListOfSetting((int)PlayerListSettingEnum.AverageSpendFrom, args.FromSpend.ToString());
                SetListOfSetting((int)PlayerListSettingEnum.AverageSpendTo, args.ToSpend.ToString());
                SetListOfSetting((int)PlayerListSettingEnum.SpendFrom, args.FromSpendDate.ToString());
                SetListOfSetting((int)PlayerListSettingEnum.SpendTo, args.ToSpendDate.ToString());
            }

            //Players average spend option.
            if (m_averageRadio.Checked && m_OptionSARadio.Checked)
            {
                args.UseAverageSpend = true;
                args.SAOption = true;
                string SelectionSelected;
                SelectionSelected = Selection(m_optionSelectedSACombo.Text);
                args.SAOptionSelected = SelectionSelected;
                args.SAOptionValue = Convert.ToDecimal(m_optionValueSAText.Text, CultureInfo.CurrentCulture);
                args.FromSpendDate = m_fromSpendDate.Value;
                args.ToSpendDate = m_toSpendDate.Value;

                switch (m_optionSelectedSACombo.SelectedIndex)
                {
                    case 0:
                        SetListOfSetting((int)PlayerListSettingEnum.AverageSpendGreaterThan, args.SAOptionValue.ToString());
                        break;
                    case 1:
                        SetListOfSetting((int)PlayerListSettingEnum.AverageGreaterThanOrEqualTo, args.SAOptionValue.ToString());
                        break;
                    case 2:
                        SetListOfSetting((int)PlayerListSettingEnum.AverageEqualTo, args.SAOptionValue.ToString());
                        break;
                    case 3:
                        SetListOfSetting((int)PlayerListSettingEnum.AverageLessThanOrEqualTo, args.SAOptionValue.ToString());
                        break;
                    case 4:
                        SetListOfSetting((int)PlayerListSettingEnum.AverageLessThan, args.SAOptionValue.ToString());
                        break;
                }
                SetListOfSetting((int)PlayerListSettingEnum.SpendFrom, args.FromSpendDate.ToString());
                SetListOfSetting((int)PlayerListSettingEnum.SpendTo, args.ToSpendDate.ToString());
            }

            //Location
            if (m_findAllVIPCheckBox.Checked)
            {
                args.IsLocation = true;
                if (LocCat == 0)
                {
                    args.LocationType = 1;

                    args.UseCity = true;

                    foreach (object city in m_locListBoxSelected.Items)
                    {
                        args.City += city.ToString() + "_|_";
                    }

                    if (m_locListBoxSelected.Items.Count != 0)
                    {
                        int TotalLEN;
                        TotalLEN = args.City.Length;
                        args.City = args.City.Remove(TotalLEN - 3, 3);
                        args.LocationDefinition = args.City;
                    }
                    SetListOfSetting((int)PlayerListSettingEnum.City, args.LocationDefinition.Replace("_|_", ","));
                }
                else if (LocCat == 1)
                {
                    args.UseState = true;
                    args.LocationType = 2;

                    foreach (object state in m_locListBoxSelected.Items)
                    {
                        args.State += state.ToString() + "_|_";
                    }

                    if (m_locListBoxSelected.Items.Count != 0)
                    {
                        int TotalLEN;
                        TotalLEN = args.State.Length;
                        args.State = args.State.Remove(TotalLEN - 3, 3);
                        args.LocationDefinition = args.State;
                    }
                    SetListOfSetting((int)PlayerListSettingEnum.State, args.LocationDefinition.Replace("_|_", ","));
                }
                else if (LocCat == 2)
                {
                    args.UseZipCode = true;
                    args.LocationType = 3;

                    foreach (object ZipCode in m_locListBoxSelected.Items)
                    {
                        args.ZipCode += ZipCode.ToString() + "_|_";
                    }

                    if (m_locListBoxSelected.Items.Count != 0)
                    {
                        int TotalLEN;
                        TotalLEN = args.ZipCode.Length;
                        args.ZipCode = args.ZipCode.Remove(TotalLEN - 3, 3);
                        args.LocationDefinition = args.ZipCode;
                    }
                    SetListOfSetting((int)PlayerListSettingEnum.Postal, args.LocationDefinition.Replace("_|_", ","));
                }
                else if (LocCat == 3)
                {
                    args.UseCountry = true;
                    args.LocationType = 4;

                    foreach (object country in m_locListBoxSelected.Items)
                    {
                        args.Country += country.ToString() + "_|_";
                    }

                    if (m_locListBoxSelected.Items.Count != 0)
                    {
                        int TotalLEN;
                        TotalLEN = args.Country.Length;
                        args.Country = args.Country.Remove(TotalLEN - 3, 3);
                        args.LocationDefinition = args.Country;
                    }

                    SetListOfSetting((int)PlayerListSettingEnum.Country, args.LocationDefinition.Replace("_|_", ","));
                }

                if (m_locListBoxSelected.Items.Count == 0)
                {
                    args.LocationDefinition = string.Empty;
                }
            }

            //Number of days visited.
            if (m_daysPlayedCheck.Checked)
            {
                args.IsNumberOfdDaysPlayed = true;
                args.DPDateRangeFrom = m_dateRangefromDPDatePicker.Value;
                args.DPDateRangeTo = m_dateRangetoDPDatePicker.Value;

                SetListOfSetting((int)PlayerListSettingEnum.VisitedFrom, args.DPDateRangeFrom.ToString());
                SetListOfSetting((int)PlayerListSettingEnum.VisitedTo, args.DPDateRangeTo.ToString());

                if (m_rangeDPRadioButton.Checked)
                {
                    args.IsDPRange = true;
                    args.DPRangeFrom = m_fromRangeDPTextBox.Text;
                    SetListOfSetting((int)PlayerListSettingEnum.NumberofDaysVisitedFrom, args.DPRangeFrom);
                    args.DPRangeTo = m_toRangeDPTextBox.Text;
                    SetListOfSetting((int)PlayerListSettingEnum.NumberofDaysVisitedTo, args.DPRangeTo);
                }
                else
                {
                    args.IsDPRange = false;
                    args.DPRangeFrom = m_fromRangeDPTextBox.Text;
                    args.DPRangeTo = m_toRangeDPTextBox.Text;
                }

                if (m_rangeoptionDPRadioButton.Checked)
                {
                    args.IsDPOption = true;
                    string SelectionSelected;
                    SelectionSelected = Selection(m_rangeOptionDPComboBox.Text);
                    //args.DPOptionSelected = m_rangeOptionDPComboBox.Text; 
                    args.DPOptionSelected = SelectionSelected;
                    args.DPOptionValue = m_rangeOptionDPTextBox.Text;

                    switch (m_rangeOptionDPComboBox.SelectedIndex)
                    {
                        case 0:
                            SetListOfSetting((int)PlayerListSettingEnum.NumberofDaysVisitedGreaterThan, args.DPOptionValue);
                            break;
                        case 1:
                            SetListOfSetting((int)PlayerListSettingEnum.NumberofDaysVisitedGreaterThanOrEqualTo, args.DPOptionValue);
                            break;
                        case 2:
                            SetListOfSetting((int)PlayerListSettingEnum.NumberofDaysVisitedEqualTo, args.DPOptionValue);
                            break;
                        case 3:
                            SetListOfSetting((int)PlayerListSettingEnum.NumberofDaysVisitedLessThanOrEqualTo, args.DPOptionValue);
                            break;
                        case 4:
                            SetListOfSetting((int)PlayerListSettingEnum.NumberofDaysVisitedLessThan, args.DPOptionValue);
                            break;
                    }
                }
                else
                {
                    args.IsDPOption = false;
                    args.DPOptionSelected = m_rangeOptionDPComboBox.Text;
                    args.DPOptionValue = m_rangeOptionDPTextBox.Text;
                }
            }
            else
            {
                args.IsNumberOfdDaysPlayed = false;
                args.IsDPRange = false;
                args.IsDPOption = false;
            }

            //Number of session attended.
            if (m_sessionPlayedCheck.Checked)
            {
                args.IsNumberOfSessionPlayed = true;

                args.DPDateRangeFrom = m_dateRangefromDPDatePicker.Value;
                args.DPDateRangeTo = m_dateRangetoDPDatePicker.Value;

                SetListOfSetting((int)PlayerListSettingEnum.VisitedFrom, args.DPDateRangeFrom.ToString());
                SetListOfSetting((int)PlayerListSettingEnum.VisitedTo, args.DPDateRangeTo.ToString());

                if (m_rangeSPRadioButton.Checked)
                {
                    args.IsSPRange = true;
                    args.SPRangeFrom = m_fromRangeSPTextBox.Text;
                    args.SPRangeTo = m_toRangeSPTextBox.Text;

                    SetListOfSetting((int)PlayerListSettingEnum.NumberofSessionsVisitedFrom, args.SPRangeFrom);
                    SetListOfSetting((int)PlayerListSettingEnum.NumberofSessionsVistsedTo, args.SPRangeTo);
                }
                else
                {
                    args.IsSPRange = false;
                    args.SPRangeFrom = m_fromRangeSPTextBox.Text;
                    args.SPRangeTo = m_toRangeSPTextBox.Text;
                }

                if (m_rangeoptionSPRadioButton.Checked)
                {
                    args.IsSPOption = true;
                    string SelectionSelected;
                    SelectionSelected = Selection(m_rangeOptionSPComboBox.Text);
                    args.SPOptionSelected = SelectionSelected;
                    args.SPOptionValue = m_rangeOptionSPTextBox.Text;

                    switch (m_rangeOptionSPComboBox.SelectedIndex)
                    {
                        case 0:
                            SetListOfSetting((int)PlayerListSettingEnum.NumberofSessionsVisitedGreaterThan, args.SPOptionValue);
                            break;
                        case 1:
                            SetListOfSetting((int)PlayerListSettingEnum.NumberofSessionsVisitedGreaterThanOrEqualTo, args.SPOptionValue);
                            break;
                        case 2:
                            SetListOfSetting((int)PlayerListSettingEnum.NumberofSessionsVisitedEqualTo, args.SPOptionValue);
                            break;
                        case 3:
                            SetListOfSetting((int)PlayerListSettingEnum.NumberofSessionsVisitedLessThanOrEqualTo, args.SPOptionValue);
                            break;
                        case 4:
                            SetListOfSetting((int)PlayerListSettingEnum.NumberofSessionsVisitedLessThan, args.SPOptionValue);
                            break;
                    }
                }
                else
                {
                    args.IsSPOption = false;
                    args.SPOptionSelected = m_rangeOptionSPComboBox.Text;
                    args.SPOptionValue = m_rangeOptionSPTextBox.Text;
                }
            }
            else
            {
                args.IsNumberOfSessionPlayed = false;
                args.IsSPRange = false;
                args.IsSPOption = false;
            }

            //Days of week and session Visisted
            if (m_daysOfWeekAndSessionCheck.Checked)
            {
                args.DPDateRangeFrom = m_dateRangefromDPDatePicker.Value;
                args.DPDateRangeTo = m_dateRangetoDPDatePicker.Value;
                SetListOfSetting((int)PlayerListSettingEnum.VisitedFrom, args.DPDateRangeFrom.ToString());
                SetListOfSetting((int)PlayerListSettingEnum.VisitedTo, args.DPDateRangeTo.ToString());

                DaysOfWeekNSession = string.Empty;

                if (m_allDaysVisitCheck.Checked == true)
                {
                    DaysOfWeekNSession += "All ";

                    if (m_checkComboAllSession.Text == "ALL")
                    {
                        DaysOfWeekNSession += ALL_SESSIONS_SELECTED;
                    }
                    else
                    {
                        string days = m_checkComboAllSession.Text.Replace(@", ", ":");
                        DaysOfWeekNSession += "(" + days + "),";
                    }
                }

                if (m_monDaysVisitCheck.Checked == true)
                {
                    DaysOfWeekNSession += "Mon ";

                    if (m_checkComboMONSession.Text == "ALL")
                    {
                        DaysOfWeekNSession += ALL_SESSIONS_SELECTED;
                    }
                    else
                    {
                        string days = m_checkComboMONSession.Text.Replace(@", ", ":");
                        DaysOfWeekNSession += "(" + days + "),";
                    }
                }

                if (m_tuesDaysVisitCheck.Checked)
                {
                    DaysOfWeekNSession += "Tue ";
                    if (m_checkComboTUESession.Text == "ALL")
                    {
                        DaysOfWeekNSession += ALL_SESSIONS_SELECTED;
                    }
                    else
                    {
                        string days = m_checkComboTUESession.Text.Replace(@", ", ":");
                        DaysOfWeekNSession += "(" + days + "),";
                    }
                }

                if (m_wedDaysVisitCheck.Checked)
                {
                    DaysOfWeekNSession += "Wed ";

                    if (m_checkComboWEDSession.Text == "ALL")
                    {
                        DaysOfWeekNSession += ALL_SESSIONS_SELECTED;
                    }
                    else
                    {
                        string days = m_checkComboWEDSession.Text.Replace(@", ", ":");
                        DaysOfWeekNSession += "(" + days + "),";
                    }
                }

                if (m_thursDaysVisitCheck.Checked)
                {
                    DaysOfWeekNSession += "Thu ";

                    if (m_checkComboTHURSSession.Text == "ALL")
                    {
                        DaysOfWeekNSession += ALL_SESSIONS_SELECTED;
                    }
                    else
                    {
                        string days = m_checkComboTHURSSession.Text.Replace(@", ", ":");
                        DaysOfWeekNSession += "(" + days + "),";
                    }
                }

                if (m_friDaysVisitCheck.Checked)
                {
                    DaysOfWeekNSession += "Fri ";

                    if (m_checkComboFRISession.Text == "ALL")
                    {
                        DaysOfWeekNSession += ALL_SESSIONS_SELECTED;
                    }
                    else
                    {
                        string days = m_checkComboFRISession.Text.Replace(@", ", ":");
                        DaysOfWeekNSession += "(" + days + "),";
                    }
                }

                if (m_satDaysVisitCheck.Checked)
                {
                    DaysOfWeekNSession += "Sat ";
                    if (m_checkComboSATSession.Text == "ALL")
                    {
                        DaysOfWeekNSession += ALL_SESSIONS_SELECTED;
                    }
                    else
                    {
                        string days = m_checkComboSATSession.Text.Replace(@", ", ":");
                        DaysOfWeekNSession += "(" + days + "),";
                    }
                }

                if (m_sunDaysVisitCheck.Checked)
                {
                    DaysOfWeekNSession += "Sun ";
                    if (m_checkComboSUNSession.Text == "ALL")
                    {
                        DaysOfWeekNSession += ALL_SESSIONS_SELECTED;
                    }
                    else
                    {
                        string days = m_checkComboSUNSession.Text.Replace(@", ", ":");
                        DaysOfWeekNSession += "(" + days + "),";
                    }
                }

                DaysOfWeekNSession = DaysOfWeekNSession.Remove(DaysOfWeekNSession.Length - 1, 1);
                args.DaysOFweekAndSession = DaysOfWeekNSession;

                SetListOfSetting((int)PlayerListSettingEnum.DaysofWeekSession, args.DaysOFweekAndSession);
            }
            else
            {
                args.DaysOFweekAndSession = string.Empty;
            }

            //Product
            if (m_ProductCheckBox.Checked)
            {
                args.IsProduct = true;
                SelectedProductPar = m_ProductCheckBox2.Text;
                SelectedProductPar = SelectedProductPar.Replace(@", ", "/|\\");
                args.SelectedProduct = SelectedProductPar;
                SetListOfSetting((int)PlayerListSettingEnum.ProductPurchased, args.SelectedProduct);

                args.FromSpendDate = m_fromSpendDate.Value;
                args.ToSpendDate = m_toSpendDate.Value;

                SetListOfSetting((int)PlayerListSettingEnum.SpendFrom, args.FromSpendDate.ToString());
                SetListOfSetting((int)PlayerListSettingEnum.SpendTo, args.ToSpendDate.ToString());
            }

     
            if (m_isAwardPointToPlayerList)
            {
                m_playerListParams = args;
            }
            else
            {

                // Spawn a new thread to find players and wait until done.
                // FIX: DE2476
                DialogResult result = DialogResult.OK;

                if (isSavedList == true || isDeleteList == true)//SaveList
                {
                    if (cmbxPlayerList2.SelectedIndex == -1)//New
                    {
                        PlyrActListSetting.DefID = 0;
                        PlyrActListSetting.Definition = m_ListName; //txtbxDefinitionName.Text;
                    }
                    else
                    {
                        PlyrActListSetting.DefID = DefID;
                        if (isDeleteList == true)
                        {
                            PlyrActListSetting.Definition = cmbxPlayerList2.SelectedItem.ToString();
                        }
                        else//Update player definition name.
                        {
                            PlyrActListSetting.Definition = m_ListName; // txtbxDefinitionName.Text;
                        }
                    }

                    if (isSavedList == true)
                    {
                        if (PlyrActListSetting.Settings.Count() == 0)
                        {
                            m_errorProvider.SetError(btnSaveList, "Apply atleast one setting to set.");
                            return;
                        }

                        PlyrActListSetting.Deleted = false;

                    }
                    else if (isDeleteList == true)
                    {
                        DialogResult result2 = MessageForm.Show("Are you sure you want to delete " + PlyrActListSetting.Definition + "?", "Delete Player List", MessageFormTypes.YesNo);
                        if (result2 == DialogResult.No)
                        {
                            isDeleteList = false;
                            return;
                        }

                        PlyrActListSetting.Deleted = true;
                        PlyrActListSetting.DefID = DefID;
                    }

                    SetPlayerList setPlayerList_ = new SetPlayerList();
                    setPlayerList_.SetPlayerListMSG(PlyrActListSetting);

                    if (setPlayerList_.IsSuccess == true && isSavedList == true)
                    {
                        LoadPlayerListSettingComboBox(); //repopulate PlayerList combo box.    
                        isSavedList = false; isNewList = false;

                        PlayerListDefault2();
                        DisablePlayerListMainButton();

                        if (imgbtnCancel.Enabled) imgbtnCancel.Enabled = false;
                        if (btnSaveList.Enabled) btnSaveList.Enabled = false;
                        //if (lblListName.Visible) lblListName.Visible = false;
                        //if (txtbxDefinitionName.Visible) txtbxDefinitionName.Visible = false;
                        if (!imgbtnNewList.Enabled) imgbtnNewList.Enabled = true;
                        if (imgbtnDelete.Enabled) imgbtnDelete.Enabled = false;
                        if (imgbtn.Enabled) imgbtn.Enabled = false;
                        if (imgbtnDelete.Visible) imgbtnDelete.Visible = false;
                        if (imgbtn.Visible) imgbtn.Visible = false;
                        if (!m_generateButton.Enabled) m_generateButton.Enabled = true;
                        if (!m_closeButton.Enabled) m_closeButton.Enabled = true;
                        if (!cmbxPlayerList2.Enabled) cmbxPlayerList2.Enabled = true;
                        if (!m_listTypePanel.Enabled) m_listTypePanel.Enabled = true;
                        if (!m_playDatesButton.Enabled) m_playDatesPanel.Enabled = true;
                        if (!m_locationPanel.Enabled) m_locationPanel.Enabled = true;
                        if (!m_spendPanel.Enabled) m_spendPanel.Enabled = true;
                        if (!m_listCriteriaPanel.Enabled) m_listCriteriaPanel.Enabled = true;
                       

                        cmbxPlayerList2.SelectedIndex = -1;
                    }
                    else if (setPlayerList_.IsSuccess == true && isDeleteList == true) //(SetPlayerList.IsSuccess_static == true && isDeleteList == true)
                    {
                        LoadPlayerListSettingComboBox(); //repopulate PlayerList combo box.                
                        isDeleteList = false;
                        PlayerListDefault2();
                        if (imgbtnCancel.Enabled) imgbtnCancel.Enabled = false;
                        if (btnSaveList.Enabled) btnSaveList.Enabled = false;
                        //if (lblListName.Visible) lblListName.Visible = false;
                        //if (txtbxDefinitionName.Visible) txtbxDefinitionName.Visible = false;
                        if (!imgbtnNewList.Enabled) imgbtnNewList.Enabled = true;
                        if (imgbtnDelete.Visible) imgbtnDelete.Visible = false;
                        imgbtn.Visible = false;
                        if (!m_generateButton.Enabled) m_generateButton.Enabled = true;
                        if (!m_closeButton.Enabled) m_closeButton.Enabled = true;
                        if (!cmbxPlayerList2.Enabled) cmbxPlayerList2.Enabled = true;
                        if (!m_listTypePanel.Enabled) m_listTypePanel.Enabled = true;
                        if (!m_playDatesButton.Enabled) m_playDatesPanel.Enabled = true;
                        if (!m_locationPanel.Enabled) m_locationPanel.Enabled = true;
                        if (!m_spendPanel.Enabled) m_spendPanel.Enabled = true;
                        if (!m_listCriteriaPanel.Enabled) m_listCriteriaPanel.Enabled = true;
                    }

                    isNewList = false;
                    cmbxPlayerList2.SelectedIndex = -1;
                    ActiveButton_ = 0;
                    if (!imgbtnNewList.Visible) imgbtnNewList.Visible = true;
                    if (imgbtn_AwardPointsToListOfPlayer.Visible) imgbtn_AwardPointsToListOfPlayer.Visible = false;

                    return;
                }
                else if (m_exportRadio.Checked)
                {
                    // Prompt the user for the file name.
                    SaveFileDialog saveForm = new SaveFileDialog();
                    saveForm.RestoreDirectory = true;
                    saveForm.Filter = ExportFileFilter;
                    saveForm.DefaultExt = DefaultFileExt;

                    result = saveForm.ShowDialog(this);

                    if (result == DialogResult.OK)
                        m_parent.StartExportPlayerList(saveForm.FileName, args);
                }
                else if (m_printRaffleRadio.Checked)
                {
                    m_parent.StartPrintPlayerRaffle(args);
                }
                else
                {
                    m_parent.StartGetPlayerReport(m_listReportRadio.Checked, args);
                }

                if (result == DialogResult.OK)
                {
                    m_parent.ShowWaitForm(this); // Block until we are done.

                    if (m_parent.LastAsyncException != null)
                    {
                        if (m_parent.LastAsyncException is ServerCommException)
                            Close();
                        else
                            MessageForm.Show(this, m_parent.LastAsyncException.Message, Resources.PlayerCenterName);
                    }
                    else if (m_parent.LastAsyncException == null && !m_exportRadio.Checked)
                        m_parent.ShowReportForm();
                    else if (m_parent.LastAsyncException == null && m_exportRadio.Checked)
                    {
                        if (m_parent.LastNumPlayersExported > 0)
                            MessageForm.Show(this, string.Format(CultureInfo.CurrentCulture, Resources.PlayersExported, m_parent.LastNumPlayersExported), Resources.PlayerCenterName);
                        else
                            MessageForm.Show(this, Resources.NoPlayersExported, Resources.PlayerCenterName);
                    }
                }            // END: DE2476
            }
        }
        #endregion


        private AwardPointsToListOfPlayer m_awardPointsToListOfPlayer;
        private bool m_isAwardPointToPlayerList;
        private decimal m_pointsAwarded;

        private void imgbtn_AwardPointsToListOfPlayer_Click(object sender, EventArgs e)
        {
            m_isAwardPointToPlayerList = false;
            m_awardPointsToListOfPlayer = new AwardPointsToListOfPlayer();
            DialogResult result = DialogResult.OK;
            result = m_awardPointsToListOfPlayer.ShowDialog();
            m_isAwardPointToPlayerList = m_awardPointsToListOfPlayer.IsAwardPoints;

            if (m_isAwardPointToPlayerList)
            {
                m_pointsAwarded = 0M;
                m_pointsAwarded = m_awardPointsToListOfPlayer.PointsAwardedValue;
                GenerateClick(sender, e);
                m_parent.StartAwardPointsToPlayer(m_playerListParams, m_pointsAwarded);
                m_isAwardPointToPlayerList = false;
            }

            if (result == DialogResult.OK)
            {
                m_parent.ShowWaitForm(this); // Block until we are done.

                if (m_parent.LastAsyncException != null)
                {
                    if (m_parent.LastAsyncException is ServerCommException)
                        Close();
                    else
                        MessageForm.Show(this, m_parent.LastAsyncException.Message, Resources.PlayerCenterName);
                }
                else
                {
                    MessageForm.Show(this, string.Format(CultureInfo.CurrentCulture, Resources.PlayersRewarded, m_parent.NumberOfPlayersRewarded), Resources.PlayerCenterName);
                }           
            }        
        }


        private void DisableAllPanel()
        {
            if (m_locationPanel.Visible != false) m_locationPanel.Visible = false;
            if (m_listCriteriaPanel.Visible != false) m_listCriteriaPanel.Visible = false;
            if (m_playDatesPanel.Visible != false) m_playDatesPanel.Visible = false;
            if (m_spendPanel.Visible != false) m_spendPanel.Visible = false;
            if (m_summaryPanel.Visible != false) m_summaryPanel.Visible = false;
        }

        private void m_locationButton_Click(object sender, EventArgs e)
        {
            DisableAllPanel();
            m_locationPanel.Visible = true;

        }
        private void m_listCriteriaButton1_Click(object sender, EventArgs e)
        {
            DisableAllPanel();
            m_listCriteriaPanel.Visible = true;
     
        }

        private void m_listTypeButton_Click(object sender, EventArgs e)
        {
            m_locationPanel.Visible = false;
            m_listCriteriaPanel.Visible = false;
            m_playDatesPanel.Visible = false;
        }

        private void m_playDatesButton_Click(object sender, EventArgs e)
        {
            DisableAllPanel();
            m_playDatesPanel.Visible = true;
        }

        private void m_spendBotton_Click(object sender, EventArgs e)
        {
            DisableAllPanel();
            m_spendPanel.Visible = true;
        }

        private void m_dateRangefromDPDatePicker_ValueChanged(object sender, EventArgs e)
        {
            UpdateDowCheckBoxes(true);
        }

        private void m_dateRangetoDPDatePicker_ValueChanged(object sender, EventArgs e)
        {
            UpdateDowCheckBoxes(true);
        }

        private void m_playDatesButton_Click_1(object sender, EventArgs e)
        {

        }

        private void m_rangeSPRadioButton_Validating(object sender, CancelEventArgs e)
        {
            if (m_rangeSPRadioButton.Checked == false && m_rangeoptionSPRadioButton.Checked == false)
            {
                e.Cancel = true;
                m_errorProvider.SetError(m_sessionPlayedCheck, "Please make a selection");
            }
        }

        private void m_fromRangeSPTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int from, to = -1;
                from = int.Parse(m_fromRangeSPTextBox.Text);

                if (m_toRangeSPTextBox.Text != string.Empty)
                {
                    to = int.Parse(m_toRangeSPTextBox.Text);
                }

                if (to >= 0)
                {
                    if (from > to)
                    {
                        e.Cancel = true;
                        m_errorProvider.SetError(m_rangeSPRadioButton, "FROM option must be greater than TO option");
                    }
                }
                if (from < 0)
                {
                    e.Cancel = true;
                    m_errorProvider.SetError(m_rangeSPRadioButton, "Invalid Entry");
                }

            }
            catch(Exception ex)
            {
                PlayerManager.Log("Exception encountered validating 'from' date value " + ex.ToString(), LoggerLevel.Severe);
                e.Cancel = true;
                m_errorProvider.SetError(m_rangeSPRadioButton, "Invalid Entry");
            }
        }

        private void m_toRangeSPTextBox_Validating(object sender, CancelEventArgs e)
        {
            int from, to;
            try
            {
                from = int.Parse(m_fromRangeSPTextBox.Text);
                to = int.Parse(m_toRangeSPTextBox.Text);

                if (to == 0)
                {
                    e.Cancel = true;
                    m_errorProvider.SetError(m_rangeSPRadioButton, "Invalid Entry");
                }

                if (to < 0)
                {
                    e.Cancel = true;
                    m_errorProvider.SetError(m_rangeSPRadioButton, "Invalid Entry");
                }

            }
            catch(Exception ex)
            {
                PlayerManager.Log("Exception encountered validating 'to' date value " + ex.ToString(), LoggerLevel.Severe);
                e.Cancel = true;
                //     m_errorProvider.SetError(m_toRangeSPTextBox,, Resources.InvalidPlayerListNSessionPlayedRange2);
                m_errorProvider.SetError(m_rangeSPRadioButton, "Invalid Entry");
            }
        }

        private void m_rangePBRadio_Validating(object sender, CancelEventArgs e)//If user did not pick any selection
        {
            if (m_rangePBRadio.Checked == false && m_optionPBRadio.Checked == false)
            {

                // m_errorProvider.SetError(m_pointBalanceCheck, "Please make a selection.");
                m_errorProvider.SetError(m_rangePBRadio, "Please make a selection.");
                m_errorProvider.SetError(m_optionPBRadio, "Please make a selection.");
                e.Cancel = true;
            }
        }

        private void m_rangeSARadio_Validating(object sender, CancelEventArgs e)
        {
            if (m_rangeSARadio.Checked == false && m_OptionSARadio.Checked == false)
            {
                m_errorProvider.SetError(m_rangeSARadio, "Please make a selection.");
                m_errorProvider.SetError(m_OptionSARadio, "Please make a selection.");
                e.Cancel = true;
            }
        }

        private void m_optionSelectedPBCombo_Validating(object sender, CancelEventArgs e)
        {
            if (m_optionSelectedPBCombo.Text == string.Empty)
            {

                m_errorProvider.SetError(m_optionSelectedPBCombo, "invalid Entry");
                e.Cancel = true;
            }
        }

        private void m_optionValuePBText_Validating(object sender, CancelEventArgs e)
        {
            decimal value;
            if (decimal.TryParse(m_optionValuePBText.Text, out value))
            {
                if (value < 0)//if its negative
                {
                    m_errorProvider.SetError(m_optionValuePBText, "Invalid Entry");
                    e.Cancel = true;
                }

            }
            else //any special character cancel the event
            {
                m_errorProvider.SetError(m_optionValuePBText, "Invalid Entry");
                e.Cancel = true;
            }
        }

        private void m_optionSelectedSACombo_Validating(object sender, CancelEventArgs e)
        {
            if (m_optionSelectedSACombo.Text == string.Empty)
            {
                m_errorProvider.SetError(m_optionSelectedSACombo, "Invalid Entry");
                e.Cancel = true;
            }
        }

        private void m_optionValueSAText_Validating(object sender, CancelEventArgs e)
        {
            decimal value;
            if (decimal.TryParse(m_optionValueSAText.Text, out value))
            {
                if (value < 0)//if its negative
                {
                    m_errorProvider.SetError(m_optionValueSAText, "Invalid Entry");
                    e.Cancel = true;
                }

            }
            else //any special character cancel the event
            {
                m_errorProvider.SetError(m_optionValueSAText, "Invalid Entry");
                e.Cancel = true;
            }
        }

        //# this code wil populate the m_locListBox Everytime m_locationTypeComboBox is changed. 
        int LocCat;

        private void m_locationTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocCat = m_locationTypeComboBox.SelectedIndex;
            m_locListBoxSelected.Items.Clear();
            m_loadLocaListBox(LocCat);
        }

        private void m_addItemButton_Click(object sender, EventArgs e)
        {
            if (LocCat == 0)
            {
                List<object> CityList = new List<Object>();
                foreach (object City in m_locListBox.SelectedItems)
                {
                    CityList.Add(City);
                }
                foreach (object City in CityList)
                {
                    m_locListBoxSelected.Items.Add(City);
                }
                foreach (object City in CityList)
                {
                    m_locListBox.Items.Remove(City);
                }
            }
            else if (LocCat == 1)
            {
                List<object> StateList = new List<Object>();
                foreach (object State in m_locListBox.SelectedItems)
                {
                    StateList.Add(State);
                }
                foreach (object State in StateList)
                {
                    m_locListBoxSelected.Items.Add(State);
                }
                foreach (object State in StateList)
                {
                    m_locListBox.Items.Remove(State);
                }
            }
            else if (LocCat == 2)
            {
                List<object> PostalCodeList = new List<Object>();
                foreach (object PostalCode in m_locListBox.SelectedItems)
                {
                    PostalCodeList.Add(PostalCode);
                }
                foreach (object PostalCode in PostalCodeList)
                {
                    m_locListBoxSelected.Items.Add(PostalCode);
                }
                foreach (object PostalCode in PostalCodeList)
                {
                    m_locListBox.Items.Remove(PostalCode);
                }
            }
            else if (LocCat == 3)
            {
                List<object> CountryList = new List<Object>();
                foreach (object Country in m_locListBox.SelectedItems)
                {
                    CountryList.Add(Country);
                }
                foreach (object Country in CountryList)
                {
                    m_locListBoxSelected.Items.Add(Country);
                }
                foreach (object Country in CountryList)
                {
                    m_locListBox.Items.Remove(Country);
                }
            }

            //if (isNewList == true)
            //{
                if (m_locListBoxSelected.Items.Count > 0)
                {
                    if (!btnSaveList.Enabled) btnSaveList.Enabled = true;
                }
                else
                {
                    if (btnSaveList.Enabled) btnSaveList.Enabled = false;
                }
            //}

        }

        private void m_removeItemButton_Click(object sender, EventArgs e)
        {
            if (LocCat == 0)
            {
                List<object> CityList = new List<object>();
                foreach (object city in m_locListBoxSelected.SelectedItems)
                {
                    CityList.Add(city);
                }
                foreach (object city in CityList)
                {
                    m_locListBox.Items.Add(city);
                }
                foreach (object city in CityList)
                {
                    m_locListBoxSelected.Items.Remove(city);
                }
            }
            else if (LocCat == 1)
            {
                List<object> StateList = new List<object>();
                foreach (object State in m_locListBoxSelected.SelectedItems)
                {
                    StateList.Add(State);
                }
                foreach (object State in StateList)
                {
                    m_locListBox.Items.Add(State);
                }
                foreach (object State in StateList)
                {
                    m_locListBoxSelected.Items.Remove(State);
                }
            }
            else if (LocCat == 2)
            {
                List<object> PostalCodeList = new List<object>();
                foreach (object PostalCode in m_locListBoxSelected.SelectedItems)
                {
                    PostalCodeList.Add(PostalCode);
                }
                foreach (object zipcode in PostalCodeList)
                {
                    m_locListBox.Items.Add(zipcode);
                }
                foreach (object zipcode in PostalCodeList)
                {
                    m_locListBoxSelected.Items.Remove(zipcode);
                }
            }
            else if (LocCat == 3)
            {
                List<object> CountryList = new List<object>();
                foreach (object Country in m_locListBoxSelected.SelectedItems)
                {
                    CountryList.Add(Country);
                }
                foreach (object Country in CountryList)
                {
                    m_locListBox.Items.Add(Country);
                }
                foreach (object Country in CountryList)
                {
                    m_locListBoxSelected.Items.Remove(Country);
                }
            }

            if (m_locListBoxSelected.Items.Count > 0)
            {
                if (!btnSaveList.Enabled) btnSaveList.Enabled = true;
            }
            else
            {
                if (btnSaveList.Enabled) btnSaveList.Enabled = false;
            }
        }

        private void m_addAllItemButton_Click(object sender, EventArgs e)
        {
            if (LocCat == 0)
            {
                foreach (object city in m_locListBox.Items)
                {
                    m_locListBoxSelected.Items.Add(city);
                }
                m_locListBox.Items.Clear();
            }
            else if (LocCat == 1)
            {
                foreach (object State in m_locListBox.Items)
                {
                    m_locListBoxSelected.Items.Add(State);
                }
                m_locListBox.Items.Clear();
            }
            else if (LocCat == 2)
            {
                foreach (object PostalCode in m_locListBox.Items)
                {
                    m_locListBoxSelected.Items.Add(PostalCode);
                }
                m_locListBox.Items.Clear();
            }
            else if (LocCat == 3)
            {
                foreach (object Country in m_locListBox.Items)
                {
                    m_locListBoxSelected.Items.Add(Country);
                }
                m_locListBox.Items.Clear();
            }

            if (m_locListBoxSelected.Items.Count > 0)
            {
                if (!btnSaveList.Enabled) btnSaveList.Enabled = true;
            }
            else
            {
                if (btnSaveList.Enabled) btnSaveList.Enabled = false;
            }
        }

        private void m_removedAllItemButton_Click(object sender, EventArgs e)
        {
            if (LocCat == 0)
            {
                foreach (object city in m_locListBoxSelected.Items)
                {
                    m_locListBox.Items.Add(city);
                }
                m_locListBoxSelected.Items.Clear();
            }
            else if (LocCat == 1)
            {
                foreach (object State in m_locListBoxSelected.Items)
                {
                    m_locListBox.Items.Add(State);
                }
                m_locListBoxSelected.Items.Clear();
            }
            else if (LocCat == 2)
            {
                foreach (object PostalCode in m_locListBoxSelected.Items)
                {
                    m_locListBox.Items.Add(PostalCode);
                }
                m_locListBoxSelected.Items.Clear();
            }
            else if (LocCat == 3)
            {
                foreach (object Country in m_locListBoxSelected.Items)
                {
                    m_locListBox.Items.Add(Country);
                }
                m_locListBoxSelected.Items.Clear();
            }

            if (m_locListBoxSelected.Items.Count > 0)
            {
                if (!btnSaveList.Enabled) btnSaveList.Enabled = true;
            }
            else
            {
                if (btnSaveList.Enabled) btnSaveList.Enabled = false;
            }
        }

        private void m_locationTypeComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (m_locationTypeComboBox.SelectedIndex == -1)
            {
                e.Cancel = true;
                m_errorProvider.SetError(m_locationTypeComboBox, "Invalid Entry");
            }
        }

        private void m_locListBoxSelected_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (m_locListBoxSelected.Items.Count > 510)
                {
                    e.Cancel = true;
                    m_errorProvider.SetError(m_locListBoxSelected, "Exceeded limit. Reduce the number of addresses selected.");
                }

                if (m_locListBoxSelected.Items.Count == 0)
                {
                    e.Cancel = true;
                    m_errorProvider.SetError(m_locListBoxSelected, "Please insert a entry on list.");
                }

            }
            catch(Exception ex)
            {
                PlayerManager.Log("Exception encountered validating 'location' value " + ex.ToString(), LoggerLevel.Severe);
                e.Cancel = true;
                m_errorProvider.SetError(m_locListBoxSelected, "Unknown Error");
            }
        }

        private void m_ProductCheckBox2_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (m_ProductCheckBox2.Text == string.Empty)
                {
                    e.Cancel = true;
                    m_errorProvider.SetError(m_ProductCheckBox2, "Invalid Entry");
                }
            }
            catch
            {
                e.Cancel = true;
                m_errorProvider.SetError(m_ProductCheckBox2, "Invalid Entry");
            }
        }

        private void m_locListBox_KeyDown(object sender, KeyEventArgs e)
        {
            //   m_locListBox.ClearSelected();  
            int x;
            if ((e.Modifiers & Keys.Control) == Keys.Control)//if control key is being press
            {
                x = MyListBox.y;
            }
            else //if control key is not being press
            {
                m_locListBox.ClearSelected();//verything will be claear
            }
        }
        
       

        private void cmbxPlayerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isNewList == true) return;

            PlayerListDefault2();
            clearErrorProvider();

            if (cmbxPlayerList2.SelectedIndex != -1)
            {
                DisableAllPanel();
                m_summaryPanel.Visible = true;
                if (m_parent.StaffHasPermissionToAwardPoints)
                {
                    imgbtn_AwardPointsToListOfPlayer.Visible = true;
                    imgbtn_AwardPointsToListOfPlayer.Enabled = true;
                }

                DefID = IndexToDefID[cmbxPlayerList2.SelectedIndex];
                PlyrActListSetting = new PlayerActualListSetting();
                GetPlayerListDetail gpld = new GetPlayerListDetail(DefID);
                //gpld.GetPlayerListDetailSQL(DefID);
                PlyrActListSetting = gpld.pals;
                PlyrActListSetting.Definition = cmbxPlayerList2.SelectedItem.ToString();
                m_ListName = cmbxPlayerList2.SelectedItem.ToString();
                PopulateDataIntoControls();

                if (btnSaveList.Enabled) btnSaveList.Enabled = false;
                if (!imgbtnCancel.Enabled) imgbtnCancel.Enabled = true;
                if (!imgbtn.Visible) imgbtn.Visible = true;
                if (!imgbtnDelete.Visible) imgbtnDelete.Visible = true;
                if (m_playDatesButton.Enabled) m_playDatesPanel.Enabled = false;
                if (m_locationPanel.Enabled) m_locationPanel.Enabled = false;
                if (m_spendAndLabel.Enabled) m_spendPanel.Enabled = false;
                if (m_listCriteriaPanel.Enabled) m_listCriteriaPanel.Enabled = false;
            }
            else
            {
                if (imgbtn_AwardPointsToListOfPlayer.Visible != false)
                imgbtn_AwardPointsToListOfPlayer.Visible = false;
            }
        }

        private void imgbtnNewList_Click(object sender, EventArgs e)
        {
            PlayerListDefault2();
            isNewList = true; 
            ActiveButton_ = 1;
            if (cmbxPlayerList2.Items.Count > 0) cmbxPlayerList2.SelectedIndex = -1;

            if (m_summaryPanel.Visible != false) m_summaryPanel.Visible = false;
            if (m_listCriteriaPanel.Visible != true) m_listCriteriaPanel.Visible = true;
            EnablePlayerListButton();

            if (imgbtnDelete.Visible) imgbtnDelete.Visible = false;
            if (imgbtnNewList.Visible) imgbtnNewList.Visible = false;
            if (imgbtn.Visible) imgbtn.Visible = false;
            if (m_generateButton.Enabled) m_generateButton.Enabled = false;
            if (m_closeButton.Enabled) m_closeButton.Enabled = false;
            if (cmbxPlayerList2.Enabled) cmbxPlayerList2.Enabled = false;
            if (m_listTypePanel.Enabled) m_listTypePanel.Enabled = false;
            if (!m_playDatesPanel.Enabled) m_playDatesPanel.Enabled = true;
            if (!m_locationPanel.Enabled) m_locationPanel.Enabled = true;
            if (!m_spendPanel.Enabled) m_spendPanel.Enabled = true;
            if (!m_listCriteriaPanel.Enabled) m_listCriteriaPanel.Enabled = true;
            if (!imgbtnCancel.Enabled) imgbtnCancel.Enabled = true;
            if (btnSaveList.Enabled) btnSaveList.Enabled = false;
            if (imgbtn_AwardPointsToListOfPlayer.Visible) imgbtn_AwardPointsToListOfPlayer.Visible = false;
            //if (!lblListName.Visible) lblListName.Visible = true;
            //if (!txtbxDefinitionName.Visible) { txtbxDefinitionName.Visible = true; txtbxDefinitionName.Text = string.Empty; }

            PlayerGroupListEnterOrEdit pgl = new PlayerGroupListEnterOrEdit();
            pgl.IsNewOrEdit = 1;
            pgl.ShowDialog();
            if (pgl.isAccept == false)
            {
                imgbtnCancel.PerformClick();
                return; //Skip
            }

            m_ListName = pgl.ListName;
            cmbxPlayerList2.Items.Add(m_ListName);
            cmbxPlayerList2.SelectedIndex = cmbxPlayerList2.Items.Count - 1;
            clearErrorProvider();
        }
        
        private void imgbtnCancel_Click(object sender, EventArgs e)
        {
            PlayerListDefault2();
            if (!imgbtnNewList.Visible) imgbtnNewList.Visible = true;

            if (isNewList == true)
            {
                cmbxPlayerList2.Items.Remove(cmbxPlayerList2.SelectedItem);//Remove select item.
            }

            isNewList = false;
            DisableAllPanel();
            DisablePlayerListMainButton();
            if (imgbtnCancel.Enabled) imgbtnCancel.Enabled = false;
            if (btnSaveList.Enabled) btnSaveList.Enabled = false;
            //if (lblListName.Visible)lblListName.Visible = false;
            //if (txtbxDefinitionName.Visible) txtbxDefinitionName.Visible = false;

            if (m_generateButton.Enabled) m_generateButton.Enabled = false;
            if (!m_closeButton.Enabled) m_closeButton.Enabled = true;
            if (!cmbxPlayerList2.Enabled) cmbxPlayerList2.Enabled = true;
            if (!m_listTypePanel.Enabled) m_listTypePanel.Enabled = true;

            if (!m_playDatesPanel.Enabled) m_playDatesPanel.Enabled = true;
            if (!m_locationPanel.Enabled) m_locationPanel.Enabled = true;
            if (!m_spendPanel.Enabled) m_spendPanel.Enabled = true;
            if (!m_listCriteriaPanel.Enabled) m_listCriteriaPanel.Enabled = true;

            if (cmbxPlayerList2.SelectedIndex != -1) cmbxPlayerList2.SelectedIndex = -1;
            if (imgbtnDelete.Visible) imgbtnDelete.Visible = false;
            if (imgbtn.Visible) imgbtn.Visible = false;
            if (!imgbtnNewList.Enabled) imgbtnNewList.Enabled = true;

            clearErrorProvider();
        }

        private void imgbtn_Click(object sender, EventArgs e)
        {
            if (m_summaryPanel.Visible != false) m_summaryPanel.Visible = false;
            if (m_listCriteriaPanel.Visible != true) m_listCriteriaPanel.Visible = true;
            if (imgbtn_AwardPointsToListOfPlayer.Visible) imgbtn_AwardPointsToListOfPlayer.Visible = false;
            ActiveButton_ = 3;
            m_listTypePanel.Enabled = false;
            m_playDatesPanel.Enabled = true;
            m_locationPanel.Enabled = true;
            m_spendPanel.Enabled = true;
            m_listCriteriaPanel.Enabled = true;
            imgbtnNewList.Enabled = false;
            cmbxPlayerList2.Enabled = false;
            imgbtn.Enabled = false;
            imgbtnDelete.Enabled = false;
            m_closeButton.Enabled = false;
            m_generateButton.Enabled = false;
            btnSaveList.Enabled = true;
            imgbtnCancel.Enabled = true;
            EnablePlayerListButton();

        }

        private void EnablePlayerListButton()
        {
            m_listCriteriaButton1.Enabled = true;
            m_locationButton.Enabled = true;
            m_playDatesButton.Enabled = true;
            m_spendBotton.Enabled = true;
        }

        //US2649

        /// <summary>
        /// Textbox will only accept numeric input.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxNumericOnly(object sender, KeyPressEventArgs e)
        {
            bool result = true;
            if (e.KeyChar == (char)Keys.Back)
            {
                result = false;
            }
            if (result)
            {
                result = !char.IsDigit(e.KeyChar);
            }

            e.Handled = result;
        }

        /// <summary>
        ///  It will disable/enable the save button base on user set settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmbx = (ComboBox)sender;
            if (isNewList == true) EnableOrDisableSavedButton(cmbx);
        }

        /// <summary>
        /// Textbox will only accept numeric input with decimal with 2 decimal places e.g "34567.99"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtbxDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {

            TextBox txtbxValue = new TextBox();
            if (sender is TextBox)
            {
                txtbxValue = (TextBox)sender;
                bool result = false;

                string x = txtbxValue.Text;
                if (txtbxValue.SelectionLength > 0)
                {
                    int tlen = x.Length - txtbxValue.SelectionLength;
                    x = x.Substring(0, tlen);
                }

                int count = x.Split('.').Length - 1;

                if (!char.IsControl(e.KeyChar))
                {
                    switch (e.KeyChar)
                    {
                        case (char)46://period
                            //allow 1 decimal point
                            if (count > 0)
                            {
                                result = true;
                            }
                            else
                            {
                                result = false;
                            }
                            break;
                        default:
                            result = !char.IsDigit(e.KeyChar);
                            break;
                    }
                }

                if (e.KeyChar == (char)Keys.Back)
                {
                    result = false;

                }
            
                else if (Regex.IsMatch(x, @"\.\d\d"))
                {
                    result = true;

                }

                e.Handled = result;
            }
        }

        /// <summary>
        /// It will disable/enable the save button base on user set settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextbxChanged(object sender, EventArgs e)
        {
            TextBox currentTextBox = (TextBox)sender;
            int tag = Convert.ToInt32(currentTextBox.Tag);

            if (tag == 1 || tag == 2)
            {
                try
                {
                    int from = int.Parse(m_fromRangeDPTextBox.Text);
                    int to = int.Parse(m_toRangeDPTextBox.Text);

                    if (from <= to /*&& to != 0*/)
                    {
                        countCheckBox = countCheckBox + 1;
                        if (!btnSaveList.Enabled) btnSaveList.Enabled = true;
                    }
                    else
                    {
                        countCheckBox = countCheckBox - 1;
                        if (countCheckBox == 0)
                        {
                            if (btnSaveList.Enabled) btnSaveList.Enabled = false;
                        }
                    }

                }
                catch (Exception ex)
                {
                    PlayerManager.Log("Exception encountered validating textbox " + currentTextBox.ToString() +" value "+ ex.ToString(), LoggerLevel.Severe);
                    //countCheckBox = countCheckBox - 1;
                    //if (countCheckBox == 0)
                    //{
                    //    if (btnSaveList.Enabled) btnSaveList.Enabled = false;
                    //}
                }
            }
            else if (tag == 3 || tag == 4)//Number of sessions visited range
            {
                try
                {
                    int from = int.Parse(m_fromRangeSPTextBox.Text);
                    int to = int.Parse(m_toRangeSPTextBox.Text);

                    if (from <= to /*&& to != 0*/)
                    {
                        countCheckBox = countCheckBox + 1;
                        if (!btnSaveList.Enabled) btnSaveList.Enabled = true;
                    }
                    else
                    {
                        countCheckBox = countCheckBox - 1;
                        if (countCheckBox == 0)
                        {
                            if (btnSaveList.Enabled) btnSaveList.Enabled = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    PlayerManager.Log("Exception encountered validating textbox " + currentTextBox.ToString() + " value " + ex.ToString(), LoggerLevel.Severe);
                    //countCheckBox = countCheckBox - 1;
                    //if (countCheckBox == 0)
                    //{
                    //    if (btnSaveList.Enabled) btnSaveList.Enabled = false;
                    //}
                }
            }
            else if (tag == 5)//Number of days visited option.
            {
                if (m_rangeOptionDPComboBox.SelectedIndex != -1 && !string.IsNullOrEmpty(currentTextBox.Text))
                {
                    countCheckBox = countCheckBox + 1;
                    if (!btnSaveList.Enabled) btnSaveList.Enabled = true;
                }
                else
                {
                    if (m_rangeOptionDPComboBox.SelectedIndex != -1)
                        countCheckBox = countCheckBox - 1;
                    if (countCheckBox == 0)
                    {
                        if (btnSaveList.Enabled) btnSaveList.Enabled = false;
                    }
                }
            }
            else if (tag == 6)//Number of days visited option.
            {
                if (m_rangeOptionSPComboBox.SelectedIndex != -1 && !string.IsNullOrEmpty(currentTextBox.Text))
                {
                    countCheckBox = countCheckBox + 1;
                    if (!btnSaveList.Enabled) btnSaveList.Enabled = true;
                }
                else
                {
                    if (m_rangeOptionSPComboBox.SelectedIndex != -1)
                    {
                        countCheckBox = countCheckBox - 1;
                    }

                    if (countCheckBox == 0)
                    {
                        if (btnSaveList.Enabled) btnSaveList.Enabled = false;
                    }
                }
            }
            else if (tag == 10)//Point balance option text.
            {
                if (m_optionSelectedPBCombo.SelectedIndex != -1 && !string.IsNullOrEmpty(currentTextBox.Text))
                {
                    countCheckBox = countCheckBox + 1;
                    if (!btnSaveList.Enabled) btnSaveList.Enabled = true;
                }
                else
                {
                    if (m_optionSelectedPBCombo.SelectedIndex != -1)
                    {
                        countCheckBox = countCheckBox - 1;
                    }

                    if (countCheckBox == 0)
                    {
                        if (btnSaveList.Enabled) btnSaveList.Enabled = false;
                    }
                }
            }
        }

        /// <summary>
        /// It will disable/enable the save button base on user set settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_statusCheckComboBox_TextChanged(object sender, EventArgs e)
        {
            CheckedComboBox chkcmbxCurrent = new CheckedComboBox();
            if (sender is CheckedComboBox)
            {
                chkcmbxCurrent = (CheckedComboBox)sender;
                if (chkcmbxCurrent.Text.Count() > 0)
                {
                    countCheckBox = countCheckBox + 1;
                    if (!btnSaveList.Enabled) btnSaveList.Enabled = true;
                }
                else
                {
                    countCheckBox = countCheckBox - 1;
                    if (countCheckBox == 0)
                    {
                        if (btnSaveList.Enabled) btnSaveList.Enabled = false;
                    }
                }
            }
        }
        
        /// <summary>
        /// Acivate whenever user right click an item on the ListBox List Of player List.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void listBox_Usernames_MouseUp(object sender, MouseEventArgs e)
        {
            int index = cmbxPlayerList2.IndexFromPoint(e.Location);

            if (contextMenuStrip1.Items.Count > 0)
            {
                contextMenuStrip1.Items.RemoveAt(0);
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (index != ListBox.NoMatches)
                {
                    if (cmbxPlayerList2.SelectedIndex == index)
                    {

                        ToolStripItem item = contextMenuStrip1.Items.Add("Rename");
                        item.Click += new EventHandler(item_Click);
                        cmbxPlayerList2.ContextMenuStrip.Visible = true;
                    }
                    else
                    {
                        cmbxPlayerList2.ContextMenuStrip.Visible = false;

                    }
                }
                else
                {
                    cmbxPlayerList2.ContextMenuStrip.Visible = false;
                }
            }
            else
            {
                cmbxPlayerList2.ContextMenuStrip.Visible = false;
            }
        }

        /// <summary>
        /// Selected List Name to be edited.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         private void item_Click(object sender, EventArgs e)
         {
             ToolStripItem clickedItem = sender as ToolStripItem;
             PlayerGroupListEnterOrEdit pgl = new PlayerGroupListEnterOrEdit();
             pgl.IsNewOrEdit = 2;
             pgl.ListName = m_ListName;
             pgl.ShowDialog();
             if (pgl.isAccept == false)
             {
                 imgbtnCancel.PerformClick();
                 return; //Skip
             }
             else
             {
                 m_ListName = pgl.ListName;
                 ActiveButton_ = 3;
                 GenerateClick(btnSaveList, EventArgs.Empty);
             }

         }



        #endregion

        #region Events-Validating

        /// <summary>
        /// Handles the birthday combo boxes' validating event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An CancelEventArgs object that contains the
        /// event data.</param>
        private void BirthdayValidate(object sender, CancelEventArgs e)
        {
            // Create DateTimes from our combo boxes and see if they are valid.
            try
            {
                DateTime from, to;

                int month = ((MonthItem)m_fromBirthdayMonth.SelectedItem).Number;
                int day = Convert.ToInt32(m_fromBirthdayDay.SelectedItem, CultureInfo.CurrentCulture);

                from = new DateTime(DateTime.Now.Year, month, day);

                month = ((MonthItem)m_toBirthdayMonth.SelectedItem).Number;
                day = Convert.ToInt32(m_toBirthdayDay.SelectedItem, CultureInfo.CurrentCulture);

                to = new DateTime(DateTime.Now.Year, month, day);

                if (from > to)
                {
                    e.Cancel = true;
                    m_errorProvider.SetError(m_birthdayCheck, Resources.InvalidPlayerListBirthdayBackward);
                }
            }
            catch(Exception ex)
            {
                PlayerManager.Log("Error validating the birthday fields " + ex.ToString(), LoggerLevel.Severe);
                e.Cancel = true;
                m_errorProvider.SetError(m_birthdayCheck, Resources.InvalidPlayerListBirthday);
            }
        }
        
        /// <summary>
        /// Handles the point balance text boxes' validating event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An CancelEventArgs object that contains the
        /// event data.</param>
        private void PointsValidate(object sender, CancelEventArgs e)
        {
            // Check to make sure we have a valid points range.
            //try
            //{
            decimal min, max;
            //if min is a valid number
            if (decimal.TryParse(m_minPointBalance.Text, out min))
            {
                //if min balance is negative 
                if (min < 0)
                {
                    m_errorProvider.SetError(m_minPointBalance, "Invalid Entry");
                    e.Cancel = true;
                }

                if (decimal.TryParse(m_maxPointBalance.Text, out max)) //if max is valid value
                {
                    if (min > max) //if min is greater than max
                    {
                        m_errorProvider.SetError(m_minPointBalance, "Minimum poin balance must be greater than maximum point balance.");
                        m_errorProvider.SetError(m_maxPointBalance, "Minimum poin balance must be greater than maximum point balance.");
                        e.Cancel = true;
                    }
                    if (max < 0)//if maximum is negative value
                    {
                        m_errorProvider.SetError(m_maxPointBalance, "Maximum point balance must not be equal to negative value.");
                        e.Cancel = true;
                    }

                }
                else //if maximum is not a valid value
                {
                    m_errorProvider.SetError(m_maxPointBalance, "Invalid Entry");
                    e.Cancel = true;
                }

            }
            else
            {
                if (!decimal.TryParse(m_maxPointBalance.Text, out max)) //if max is invalid value
                {
                    m_errorProvider.SetError(m_maxPointBalance, "Invalid Entry");
                }
                m_errorProvider.SetError(m_minPointBalance, "Invalid Entry");
                e.Cancel = true;
            }
        }
        
        /// <summary>
        /// Handles the last visit datetimepickers' validating event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An CancelEventArgs object that contains the
        /// event data.</param>
        private void LastVisitValidate(object sender, CancelEventArgs e)
        {
            if (m_fromLastVisit.Value > m_toLastVisit.Value)
            {
                e.Cancel = true;
                m_errorProvider.SetError(m_lastVisitCheck, Resources.InvalidPlayerListLastVisit);
            }
        }

        /// <summary>
        /// Handles the player spend text boxes' validating event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An CancelEventArgs object that contains the
        /// event data.</param>
        private void SpendValidate(object sender, CancelEventArgs e)
        {
            decimal min, max;

            if (decimal.TryParse(m_fromSpend.Text, out min))
            {
                if (min < 0)
                {
                    m_errorProvider.SetError(m_fromSpend, "Invalid Entry");
                    e.Cancel = true;
                }

                if (decimal.TryParse(m_toSpend.Text, out max))
                {
                    if (min > max)
                    {
                        m_errorProvider.SetError(m_fromSpend, "ToSpend must be greater that FromSpend.");
                        m_errorProvider.SetError(m_toSpend, "ToSpend must be greater that FromSpend.");
                        e.Cancel = true;
                    }
                    if (max < 0)
                    {
                        m_errorProvider.SetError(m_toSpend, "Please enter a positive value.");
                        e.Cancel = true;
                    }
                }
                else
                {
                    m_errorProvider.SetError(m_toSpend, "Invalid Entry");
                    e.Cancel = true;
                }

            }
            else
            {
                if (!decimal.TryParse(m_toSpend.Text, out max))
                {
                    m_errorProvider.SetError(m_toSpend, "Invalid Entry");
                }
                m_errorProvider.SetError(m_fromSpend, "Invalid Entry");
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Handles the spend datetimepickers' validating event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An CancelEventArgs object that contains the
        /// event data.</param>
        private void SpendDateValidate(object sender, CancelEventArgs e)
        {
            if (m_fromSpendDate.Value > m_toSpendDate.Value)
            {
                e.Cancel = true;
                //  m_errorProvider.SetError(m_averageRadio, Resources.InvalidPlayerListSpendDateBackward);
                m_errorProvider.SetError(m_fromSpendDate, "Invalid Date Range");
            }
        }
        
        private void m_dateRangefromDPDatePicker_Validating(object sender, CancelEventArgs e)
        {
            if (m_dateRangefromDPDatePicker.Value.Date > m_dateRangetoDPDatePicker.Value.Date)//Ignore time.
            {
                e.Cancel = true;
                m_errorProvider.SetError(m_dateRangefromDPDatePicker, Resources.InvalidPlayerListNDaysPlayedDateRange);
            }
        }

        private void m_fromRangeDPTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int from, to = -1;

                from = int.Parse(m_fromRangeDPTextBox.Text);

                if (m_toRangeDPTextBox.Text != string.Empty)
                {
                    to = int.Parse(m_toRangeDPTextBox.Text);
                }

                if (to >= 0)
                {
                    if (from > to)
                    {
                        e.Cancel = true;
                        m_errorProvider.SetError(m_rangeDPRadioButton, "FROM option must be greater than TO option.");
                    }
                }
                if (from < 0)
                {
                    e.Cancel = true;
                    m_errorProvider.SetError(m_rangeDPRadioButton, "Invalid entry");
                }
            }
            catch
            {

                e.Cancel = true;
                m_errorProvider.SetError(m_rangeDPRadioButton, "Invalid Entry");
            }
        }

        private void m_toRangeDPTextBox_Validating(object sender, CancelEventArgs e)
        {
            int from, to;
            try
            {
                from = int.Parse(m_fromRangeDPTextBox.Text);
                to = int.Parse(m_toRangeDPTextBox.Text);

                if (to == 0)
                {
                    e.Cancel = true;
                    m_errorProvider.SetError(m_rangeDPRadioButton, "RANGE TO must not be equal to zero.");
                }

                if (to < 0)
                {
                    e.Cancel = true;
                    m_errorProvider.SetError(m_rangeDPRadioButton, "Invalid Entry");
                }


            }
            catch
            {
                e.Cancel = true;
                m_errorProvider.SetError(m_rangeDPRadioButton, "Invalid Entry");
            }
        }
        
        private void m_rangeOptionDPComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (m_rangeOptionDPComboBox.SelectedIndex == -1)//|| m_rangeOptionDPComboBox.SelectedIndex == 0)
            {
                e.Cancel = true;
                //   m_errorProvider.SetError(m_rangeOptionDPComboBox, Resources.InvalidPlayerListNDaysPlayedOptionSElected); 
                m_errorProvider.SetError(m_rangeoptionDPRadioButton, "Invalid Entry");
            }
        }
        
        private void m_rangeOptionDPTextBox_Validating_1(object sender, CancelEventArgs e)
        {
            try
            {
                int value = int.Parse(m_rangeOptionDPTextBox.Text);

                if (value == 0)
                {
                    e.Cancel = true;
                    m_errorProvider.SetError(m_rangeoptionDPRadioButton, "Not a valid entry.");
                }
                if (value < 0)
                {
                    e.Cancel = true;
                    m_errorProvider.SetError(m_rangeoptionDPRadioButton, "Not a valid entry.");
                }
            }
            catch
            {
                e.Cancel = true;
                m_errorProvider.SetError(m_rangeoptionDPRadioButton, "Not a valid entry.");
            }
        }
        
        private void m_daysOfWeekAndSessionCheck_Validating(object sender, CancelEventArgs e)
        {
            if (
                m_allDaysVisitCheck.Checked == false
                && m_monDaysVisitCheck.Checked == false
                && m_tuesDaysVisitCheck.Checked == false
                && m_wedDaysVisitCheck.Checked == false
                && m_thursDaysVisitCheck.Checked == false
                && m_friDaysVisitCheck.Checked == false
                && m_satDaysVisitCheck.Checked == false
                && m_sunDaysVisitCheck.Checked == false
                && m_daysOfWeekAndSessionCheck.Checked == true
                )
            {
                e.Cancel = true;
                m_errorProvider.SetError(m_daysOfWeekAndSessionCheck, "Please select a day.");
            }
        }
        
        private void m_rangeOptionSPComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (m_rangeOptionSPComboBox.SelectedIndex == -1)// || m_rangeOptionSPComboBox.SelectedIndex == 0)
            {
                e.Cancel = true;
                m_errorProvider.SetError(m_rangeoptionSPRadioButton, "Invalid Entry");
            }
        }

        private void m_rangeOptionSPTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int value = int.Parse(m_rangeOptionSPTextBox.Text);

                if (value == 0)
                {
                    e.Cancel = true;
                    m_errorProvider.SetError(m_rangeoptionSPRadioButton, "Invalid Entry");
                }
                else if (value < 0)
                {
                    e.Cancel = true;
                    m_errorProvider.SetError(m_rangeoptionSPRadioButton, "Invalid Entry");
                }
            }
            catch
            {
                e.Cancel = true;
                m_errorProvider.SetError(m_rangeoptionSPRadioButton, "Invalid Entry");
            }
        }
        
        private void m_rangeDPRadioButton_Validating(object sender, CancelEventArgs e)
        {
            if (m_rangeDPRadioButton.Checked == false && m_rangeoptionDPRadioButton.Checked == false)
            {
                e.Cancel = true;
                m_errorProvider.SetError(m_daysPlayedCheck, "Please make a selection");
            }
        }

        private void m_statusCheckComboBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (m_statusCheckComboBox.Text == string.Empty)
                {
                    e.Cancel = true;
                    m_errorProvider.SetError(m_statusCheckComboBox, "Invalid Entry");
                }
            }
            catch
            {
                e.Cancel = true;
                m_errorProvider.SetError(m_statusCheckComboBox, "Invalid Entry");
            }
        }

        private void txtbxDefinitionName_Validating(object sender, CancelEventArgs e)
        {

        }
        
        #endregion

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

       

        
        
    }

    class PlayerActualListSetting
    {
        public int DefID;
        public string Definition;
        public bool Deleted;
        public List<PlayerListSetting> Settings;

        public PlayerActualListSetting()
        {
            Settings = new List<PlayerListSetting>();
        }
    }

    struct PlayerListDefinition
    {
        public int DefId;
        public string DefinitionName;
    }

    struct PlayerListSetting
    {
        public int SettingID;
        public string SettingValue;
    }

    enum PlayerListSettingEnum : int
    {
        Gender = 1,
        Status = 2,
        BirthdayBetween = 3,
        BirthdayTo = 4,
        City = 5,
        State = 6,
        Postal = 7,
        Country = 8,
        VisitedFrom = 9,
        VisitedTo = 10,
        LastVisitBetween = 11,
        LastVisitTo = 12,
        NumberofDaysVisitedFrom = 13,
        NumberofDaysVisitedTo = 14,
        NumberofDaysVisitedGreaterThan = 15,
        NumberofDaysVisitedGreaterThanOrEqualTo = 16,
        NumberofDaysVisitedEqualTo = 17,
        NumberofDaysVisitedLessThanOrEqualTo = 18,
        NumberofDaysVisitedLessThan = 19,
        NumberofSessionsVisitedFrom = 20,
        NumberofSessionsVistsedTo = 21,
        NumberofSessionsVisitedGreaterThan = 22,
        NumberofSessionsVisitedGreaterThanOrEqualTo = 23,
        NumberofSessionsVisitedEqualTo = 24,
        NumberofSessionsVisitedLessThanOrEqualTo = 25,
        NumberofSessionsVisitedLessThan = 26,
        DaysofWeekSession = 27,
        SpendFrom = 28,
        SpendTo = 29,
        ProductPurchased = 30,
        PointBalanceFrom = 31,
        PointBalanceTo = 32,
        PointBalanceGreaterThan = 33,
        PointBalanceGreaterThanOrEqualTo = 34,
        PointBalanceEqualTo = 35,
        PointBalanceLessThanOrEqualTo = 36,
        PointBalanceLessThan = 37,
        SpendFromvalue = 38,
        SpendTovalue = 39,
        SpendGreaterThan = 40,
        SpendGreaterThanOrEqualTo = 41,
        SpendEqualTo = 42,
        SpendLessThanOrEqualTo = 43,
        SpendLessThan = 44,
        AverageSpendFrom = 45,
        AverageSpendTo = 46,
        AverageSpendGreaterThan = 47,
        AverageGreaterThanOrEqualTo = 48,
        AverageEqualTo = 49,
        AverageLessThanOrEqualTo = 50,
        AverageLessThan = 51,
    }
}