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
using GTI.Modules.Shared;
using GTI.Modules.PlayerCenter.Business;
using GTI.Modules.PlayerCenter.Properties;

using System.Drawing; //US2469  
using GTI.Modules.PlayerCenter.Data; //US2469    
using System.Collections.Generic;  //US2469
using CheckComboBoxTest;

namespace GTI.Modules.PlayerCenter.UI
{
    /// <summary>
    /// The form that allows you to create a list of players meeting various 
    /// criteria.
    /// </summary>
    /// 

    internal partial class PlayerListForm : GradientForm
    {
        #region Constants and Data Types
        protected const string ExportFileFilter = "Comma-separated values (*.csv)|*.csv";
        protected const string DefaultFileExt = "csv";
        private string[] SessionNumber = { @"ALL",  "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        private string DaysOfWeekNSession;
        private string SelectedProductPar;

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
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the PlayerListForm class.
        /// </summary>
        /// <param name="parent">The PlayerManager to which this form 
        /// belongs.</param>
        public PlayerListForm(PlayerManager parent)
        {
            if(parent == null) throw new ArgumentNullException("parent");
            m_parent = parent;
            InitializeComponent();
            LoadValues();
            PlayerListDefault();

            foreach (string name in Enum.GetNames(typeof(Loc)))
            {
                m_locationTypeComboBox.Items.Add(name);  
            }

     
        }
        #endregion

        #region Member Methods
        /// <summary>
        /// Populates lists on the form.
        /// </summary>
        /// 
        protected void PlayerListDefault()
        {
            m_locationPanel.Visible = false ;
            m_listCriteriaPanel.Visible  = true;
            m_listCriteriaPanel.Enabled = true; 
            m_playDatesPanel.Visible = false;  
    
        }



        protected void LoadValues()
        {
            

            Calendar cal = CultureInfo.CurrentCulture.Calendar;

            // Birthday lists
            m_fromBirthdayMonth.BeginUpdate();
            m_toBirthdayMonth.BeginUpdate();

            m_fromBirthdayMonth.Items.Clear();
            m_toBirthdayMonth.Items.Clear();

            int numMonths = cal.GetMonthsInYear(DateTime.Now.Year);

            for(int month = 1; month <= numMonths; month++)
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
            if(m_fromBirthdayMonth.Items.Count > 0)
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

  
        protected void LoadSelectedOption(ComboBox  x)
        {
            x.BeginUpdate(); 
            x.Items.Add(Resources.DayPlayedOption1);
            x.Items.Add(Resources.DayPlayedOption2);
            x.Items.Add(Resources.DayPlayedOption3);
            x.Items.Add(Resources.DayPlayedOption4);
            x.Items.Add(Resources.DayPlayedOption5);
            x.EndUpdate();
        }
     
        protected void LoadDaysINWeek()
        {
            m_monDaysVisitCheck.Checked = false;
            m_monDaysVisitCheck.Enabled = false;
            m_tuesDaysVisitCheck.Checked = false;
            m_wedDaysVisitCheck.Checked = false;
            m_thursDaysVisitCheck.Checked = false;
            m_friDaysVisitCheck.Checked = false;
            m_satDaysVisitCheck.Checked = false;
            m_sunDaysVisitCheck.Checked = false;
            m_tuesDaysVisitCheck.Enabled = false;
            m_wedDaysVisitCheck.Enabled = false;
            m_thursDaysVisitCheck.Enabled = false;
            m_friDaysVisitCheck.Enabled = false;
            m_satDaysVisitCheck.Enabled = false;
            m_sunDaysVisitCheck.Enabled = false;

            DateTime x = m_dateRangefromDPDatePicker.Value;
            DateTime y = m_dateRangetoDPDatePicker.Value;

            int numOfDays = y.Subtract(x).Days + 1;

            if (numOfDays < 7)
            {
                for (int i = 0; i < numOfDays; i++)
                {
                    if (m_monDaysVisitCheck.Text == x.ToString("ddd"))
                    {
                        m_monDaysVisitCheck.Enabled = m_daysOfWeekAndSessionCheck.Checked;
                    }
                    if (m_tuesDaysVisitCheck.Text == x.ToString("ddd"))
                    {
                        m_tuesDaysVisitCheck.Enabled = m_daysOfWeekAndSessionCheck.Checked;
                    }
                    if (m_wedDaysVisitCheck.Text == x.ToString("ddd"))
                    {
                        m_wedDaysVisitCheck.Enabled = m_daysOfWeekAndSessionCheck.Checked;
                    }
                    if (m_thursDaysVisitCheck.Text == x.ToString("ddd"))
                    {
                        m_thursDaysVisitCheck.Enabled = m_daysOfWeekAndSessionCheck.Checked;
                    }
                    if (m_friDaysVisitCheck.Text == x.ToString("ddd"))
                    {
                        m_friDaysVisitCheck.Enabled = m_daysOfWeekAndSessionCheck.Checked;
                    }
                    if (m_satDaysVisitCheck.Text == x.ToString("ddd"))
                    {
                        m_satDaysVisitCheck.Enabled = m_daysOfWeekAndSessionCheck.Checked;
                    }
                    if (m_sunDaysVisitCheck.Text == x.ToString("ddd"))
                    {
                        m_sunDaysVisitCheck.Enabled = m_daysOfWeekAndSessionCheck.Checked;
                    }

                    x = x.AddDays(1);
                }
            }
            else
            {
                m_monDaysVisitCheck.Enabled = m_daysOfWeekAndSessionCheck.Checked;
                m_tuesDaysVisitCheck.Enabled = m_daysOfWeekAndSessionCheck.Checked;
                m_wedDaysVisitCheck.Enabled = m_daysOfWeekAndSessionCheck.Checked;
                m_thursDaysVisitCheck.Enabled = m_daysOfWeekAndSessionCheck.Checked;
                m_friDaysVisitCheck.Enabled = m_daysOfWeekAndSessionCheck.Checked;
                m_satDaysVisitCheck.Enabled = m_daysOfWeekAndSessionCheck.Checked;
                m_sunDaysVisitCheck.Enabled = m_daysOfWeekAndSessionCheck.Checked;
            }
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



        private string  Selection (string x)
        {
            string z = "";
            switch (x) 
            {
                case "Greater Than": z = ">"; break;
                case "Greater Than or Equal ": z = ">="; break;
                case "Equal": z= "="; break;
                case "Less Than Or Equal ": z = "<="; break;
                case "Less Than": z = "<"; break;
            }

            return z; 
         }

        /// <summary>
        /// Handles the checkboxes' check changed event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the
        /// event data.</param>
        private void OptionChanged(object sender, EventArgs e)
        {
            if (sender == m_findAllVIPCheckBox)
            {
                m_locationTypeComboBox.Enabled = m_findAllVIPCheckBox.Checked;
                m_locListBox.Enabled = m_findAllVIPCheckBox.Checked;
                m_addItemButton.Enabled = m_findAllVIPCheckBox.Checked;
                m_removeItemButton.Enabled = m_findAllVIPCheckBox.Checked;
                m_addAllItemButton.Enabled = m_findAllVIPCheckBox.Checked;
                m_removedAllItemButton.Enabled = m_findAllVIPCheckBox.Checked;
                m_locListBoxSelected.Enabled = m_findAllVIPCheckBox.Checked;

                if (m_findAllVIPCheckBox.Checked == true )
                {
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
                }
            }
            if(sender == m_birthdayCheck)
            {
                m_fromBirthdayMonth.Enabled = m_birthdayCheck.Checked;
                m_fromBirthdayDay.Enabled = m_birthdayCheck.Checked;
                m_toBirthdayMonth.Enabled = m_birthdayCheck.Checked;
                m_toBirthdayDay.Enabled = m_birthdayCheck.Checked;
            }
            else if(sender == m_genderCheck)
            {
                m_genderList.Enabled = m_genderCheck.Checked; // FIX: DE1891
                if (m_genderCheck.Checked == false)
                {
                    m_genderList.SelectedIndex = 0;
                }

            }
            else if(sender == m_pointBalanceCheck)
            {        
                m_rangeOptionPBPanel.Enabled = m_pointBalanceCheck.Checked;

                if (m_pointBalanceCheck.Checked  == false)
                {
                    m_rangePBRadio.Checked = false;
                    m_optionPBRadio.Checked = false;  
                }

            }
            else if (sender == m_rangePBRadio)
            {
                m_errorProvider.SetError(m_optionPBRadio, string.Empty);   
                m_minPointBalance.Enabled = m_rangePBRadio.Checked;
                m_maxPointBalance.Enabled = m_rangePBRadio.Checked;

                if (m_rangePBRadio.Checked  == false)
                {
                    m_minPointBalance.Text = "0.00";
                    m_maxPointBalance.Text = "0.00"; 
                }
            }
            else if (sender == m_optionPBRadio)
            {
                m_errorProvider.SetError(m_rangePBRadio, string.Empty);
                m_optionSelectedPBCombo.Enabled = m_optionPBRadio.Checked;
                m_optionValuePBText.Enabled = m_optionPBRadio.Checked;

                if (m_optionPBRadio.Checked == true)
                {
                    LoadSelectedOption(m_optionSelectedPBCombo);                    
                }
                else if (m_optionPBRadio.Checked == false)
                {                             
                    m_optionSelectedPBCombo.Items.Clear();
                    m_optionSelectedPBCombo.Text = string.Empty;
                    m_optionValuePBText.Text = "0.00";
                }
           }

            else if(sender == m_lastVisitCheck)
            {
                m_fromLastVisit.Enabled = m_lastVisitCheck.Checked;
                m_toLastVisit.Enabled = m_lastVisitCheck.Checked;
            }
            else if(sender == m_spendCheck)
            {              
              if (m_spendCheck.Checked == true)
                {
                    m_averageRadio.Checked = false;
                    m_RangeOptionSAPanel.Enabled = true;
                    m_fromSpendDate.Enabled = true;
                    m_toSpendDate.Enabled = true;
                }
                else
                {
                    m_RangeOptionSAPanel.Enabled = false ;
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
                if (m_rangeSARadio.Checked == false)
                {
                    m_fromSpend.Text = "0.00";
                    m_toSpend.Text = "0.00";
                }
            }
            else if (sender == m_OptionSARadio)
                {
                    m_errorProvider.SetError(m_rangeSARadio, string.Empty);
                    m_optionSelectedSACombo.Enabled = m_OptionSARadio.Checked;
                    m_optionValueSAText.Enabled = m_OptionSARadio.Checked;
                    if (m_OptionSARadio.Checked == true)
                    {
                        LoadSelectedOption(m_optionSelectedSACombo);  
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
                    m_dateRangefromDPDatePicker.Enabled = true;
                    m_dateRangetoDPDatePicker.Enabled = true;
                }

                else if  (m_daysPlayedCheck.Checked == false 
                    && m_sessionPlayedCheck.Checked == false
                    && m_daysOfWeekAndSessionCheck.Checked == false)
                {
                    m_dateRangefromDPDatePicker.Enabled = false; 
                    m_dateRangetoDPDatePicker.Enabled = false; 
                }

                if (m_rangeDPRadioButton.Checked == true)
                {
                    m_rangeDPRadioButton.Checked = false;
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

            }
            else if (sender == m_rangeoptionDPRadioButton)
            {
                m_errorProvider.Clear();
                m_rangeOptionDPComboBox.Enabled = m_rangeoptionDPRadioButton.Checked;
                m_rangeOptionDPTextBox.Enabled = m_rangeoptionDPRadioButton.Checked;

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
                     else if  (m_daysPlayedCheck.Checked == false 
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
            }
            else if (sender == m_rangeoptionSPRadioButton)
            {
                m_errorProvider.Clear();
                m_rangeOptionSPComboBox.Enabled = m_rangeoptionSPRadioButton.Checked;
                m_rangeOptionSPTextBox.Enabled = m_rangeoptionSPRadioButton.Checked;

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
            else if (sender == m_monDaysVisitCheck)
            {
                m_checkComboMONSession.Enabled = m_monDaysVisitCheck.Checked;

                if (m_monDaysVisitCheck.Checked == false)
                {
                    m_checkComboMONSession.Items.Clear();
                    m_checkComboMONSession.Text = string.Empty; //""; 
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
                m_dateRangefromDPDatePicker.Enabled = true ;
                m_dateRangetoDPDatePicker.Enabled =  true  ;
                }
                 else if  (m_daysPlayedCheck.Checked == false 
                    && m_sessionPlayedCheck.Checked == false
                    && m_daysOfWeekAndSessionCheck.Checked == false)
                {
                    m_dateRangefromDPDatePicker.Enabled = false; 
                    m_dateRangetoDPDatePicker.Enabled = false; 
                }

                DateTime x = m_dateRangefromDPDatePicker.Value;
                DateTime y = m_dateRangetoDPDatePicker.Value;

                int numOfDays = y.Subtract(x).Days + 1;

                if (numOfDays < 7)
                {
                    for (int i = 0; i < numOfDays; i++)
                    {
                        if (m_monDaysVisitCheck.Text == x.ToString("ddd"))
                        {
                            m_monDaysVisitCheck.Enabled = m_daysOfWeekAndSessionCheck.Checked;
                        }
                        if (m_tuesDaysVisitCheck.Text == x.ToString("ddd"))
                        {
                            m_tuesDaysVisitCheck.Enabled = m_daysOfWeekAndSessionCheck.Checked;
                        }
                        if (m_wedDaysVisitCheck.Text == x.ToString("ddd"))
                        {
                            m_wedDaysVisitCheck.Enabled = m_daysOfWeekAndSessionCheck.Checked;
                        }
                        if (m_thursDaysVisitCheck.Text == x.ToString("ddd"))
                        {
                            m_thursDaysVisitCheck.Enabled = m_daysOfWeekAndSessionCheck.Checked;
                        }
                        if (m_friDaysVisitCheck.Text == x.ToString("ddd"))
                        {
                            m_friDaysVisitCheck.Enabled = m_daysOfWeekAndSessionCheck.Checked;
                        }
                        if (m_satDaysVisitCheck.Text == x.ToString("ddd"))
                        {
                            m_satDaysVisitCheck.Enabled = m_daysOfWeekAndSessionCheck.Checked;
                        }
                        if (m_sunDaysVisitCheck.Text == x.ToString("ddd"))
                        {
                            m_sunDaysVisitCheck.Enabled = m_daysOfWeekAndSessionCheck.Checked;
                        }

                        x = x.AddDays(1);
                    }
                }
                else
                {
                    m_monDaysVisitCheck.Enabled = m_daysOfWeekAndSessionCheck.Checked;
                    m_tuesDaysVisitCheck.Enabled = m_daysOfWeekAndSessionCheck.Checked;
                    m_wedDaysVisitCheck.Enabled = m_daysOfWeekAndSessionCheck.Checked;
                    m_thursDaysVisitCheck.Enabled = m_daysOfWeekAndSessionCheck.Checked;
                    m_friDaysVisitCheck.Enabled = m_daysOfWeekAndSessionCheck.Checked;
                    m_satDaysVisitCheck.Enabled = m_daysOfWeekAndSessionCheck.Checked;
                    m_sunDaysVisitCheck.Enabled = m_daysOfWeekAndSessionCheck.Checked;
                }

                m_monDaysVisitCheck.Checked = false;
                m_tuesDaysVisitCheck.Checked = false;
                m_wedDaysVisitCheck.Checked = false;
                m_thursDaysVisitCheck.Checked = false;
                m_friDaysVisitCheck.Checked = false;
                m_satDaysVisitCheck.Checked = false;
                m_sunDaysVisitCheck.Checked = false;
            }
            else if (sender == m_ProductCheckBox)
            {

                if (m_ProductCheckBox.Checked == true)
                {
                    m_fromSpendDate.Enabled = true;
                    m_toSpendDate.Enabled = true;
                }
                else if (m_ProductCheckBox.Checked == false  && m_spendCheck.Checked == false &&   m_averageRadio.Checked == false)
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
                    foreach (ProductList x in PlayerManager.ProductListName)
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

                    m_ProductCheckBox2.MaxDropDownItems = i;
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

            if(combo != null && combo == m_fromBirthdayMonth)
                dayList = m_fromBirthdayDay;
            else if(combo != null && combo == m_toBirthdayMonth)
                dayList = m_toBirthdayDay;

            // Populate the days of the month.
            if(dayList != null)
            {
                dayList.BeginUpdate();
                dayList.Items.Clear();

                Calendar cal = CultureInfo.CurrentCulture.Calendar;
                int month = ((MonthItem)combo.SelectedItem).Number;
                int numDays = cal.GetDaysInMonth(DateTime.Now.Year, month);

                for(int day = 1; day <= numDays; day++)
                {
                    dayList.Items.Add(day);
                }

                dayList.EndUpdate();

                // Select the first day by default.
                if(dayList.Items.Count > 0)
                    dayList.SelectedIndex = 0;
            }
        }

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

                if(from > to)
                {
                    e.Cancel = true;
                    m_errorProvider.SetError(m_birthdayCheck, Resources.InvalidPlayerListBirthdayBackward);
                }
            }
            catch
            {
                e.Cancel = true;
                m_errorProvider.SetError(m_birthdayCheck, Resources.InvalidPlayerListBirthday);
            }
        }

        // Rally US493
        /// <summary>
        /// Handles the status combo box's validating event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An CancelEventArgs object that contains the
        /// event data.</param>
        //private void StatusValidate(object sender, CancelEventArgs e)
        //{
        //    if(m_statusList.SelectedIndex == -1)
        //    {
        //        e.Cancel = true;
        //        m_errorProvider.SetError(m_statusCheck, Resources.InvalidPlayerListStatus);
        //    }
        //}

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
            if(m_fromLastVisit.Value > m_toLastVisit.Value)
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
            if(m_fromSpendDate.Value > m_toSpendDate.Value)
            {
                e.Cancel = true;
              //  m_errorProvider.SetError(m_averageRadio, Resources.InvalidPlayerListSpendDateBackward);
                m_errorProvider.SetError(m_fromSpendDate, "Invalid Date Range"); 
            }
        }



        private void m_dateRangefromDPDatePicker_Validating(object sender, CancelEventArgs e)
        {
            if (m_dateRangefromDPDatePicker.Value > m_dateRangetoDPDatePicker.Value)
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
            if (m_rangeOptionDPComboBox.SelectedIndex == -1 )//|| m_rangeOptionDPComboBox.SelectedIndex == 0)
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
                m_monDaysVisitCheck.Checked == false
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
                m_errorProvider.SetError(m_rangeoptionSPRadioButton,"Invalid Entry");
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
                m_errorProvider.SetError(m_daysPlayedCheck,"Please make a selection");
            }
        }




        /// <summary>
        /// Handles the generate list button's click event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the
        /// event data.</param>
        private void GenerateClick(object sender, EventArgs e)
        {
            // Clear the previous errors.
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
           
            // Validate the input.
            if(!ValidateChildren(ValidationConstraints.Enabled | ValidationConstraints.Visible))
                return;

            // Send the arguments to the parent.
            PlayerListParams args = new PlayerListParams();

            if(m_birthdayCheck.Checked)
            {
                args.UseBirthday = true;

                int month = ((MonthItem)m_fromBirthdayMonth.SelectedItem).Number;
                int day = Convert.ToInt32(m_fromBirthdayDay.SelectedItem, CultureInfo.CurrentCulture);

                args.FromBirthday = new DateTime(DateTime.Now.Year, month, day);

                month = ((MonthItem)m_toBirthdayMonth.SelectedItem).Number;
                day = Convert.ToInt32(m_toBirthdayDay.SelectedItem, CultureInfo.CurrentCulture);

                args.ToBirthday = new DateTime(DateTime.Now.Year, month, day);
            }

            if(m_genderCheck.Checked)
            {
                args.UseGender = true;
                args.Gender = (string)m_genderList.SelectedItem; // FIX: DE1891                 
            }

            // Rally US493
            if(m_statusCheck.Checked)
            {
                args.UseStatus = true;
                //args.Status = ((PlayerStatus)m_statusList.SelectedItem).Id;
               // string statusID = m_statusID.Text;
                string statusID = m_statusCheckComboBox.Text;
                statusID = statusID.Replace(@", ", "/|\\");
                args.Status = statusID; 
            }

           // if(m_pointBalanceCheck.Checked)
            if (m_rangePBRadio.Checked) 
            {
                args.UsePoints = true;
                args.PBIsRange = true;
                args.MinPoints = Convert.ToDecimal(m_minPointBalance.Text, CultureInfo.CurrentCulture);
                args.MaxPoints = Convert.ToDecimal(m_maxPointBalance.Text, CultureInfo.CurrentCulture);
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
            }

            if(m_lastVisitCheck.Checked)
            {
                args.UseLastVisit = true;
                args.FromLastVisit = m_fromLastVisit.Value;
                args.ToLastVisit = m_toLastVisit.Value;
            }


            if (m_spendCheck.Checked && m_rangeSARadio.Checked)
            {
                args.UseSpend = true;
                args.SAIsRange = true;
                args.FromSpend = Convert.ToDecimal(m_fromSpend.Text, CultureInfo.CurrentCulture);
                args.ToSpend = Convert.ToDecimal(m_toSpend.Text, CultureInfo.CurrentCulture);
                args.FromSpendDate = m_fromSpendDate.Value;
                args.ToSpendDate = m_toSpendDate.Value;
            }
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
            }
            if (m_averageRadio.Checked && m_rangeSARadio.Checked)
            {
                args.UseAverageSpend = true;
                args.SAIsRange = true;
                args.FromSpend = Convert.ToDecimal(m_fromSpend.Text, CultureInfo.CurrentCulture);
                args.ToSpend = Convert.ToDecimal(m_toSpend.Text, CultureInfo.CurrentCulture);
                args.FromSpendDate = m_fromSpendDate.Value;
                args.ToSpendDate = m_toSpendDate.Value;
            }
            if (m_averageRadio.Checked && m_OptionSARadio.Checked)
            {
                args.UseAverageSpend = true;
                args.SAOption  = true;
                string SelectionSelected;
                SelectionSelected = Selection(m_optionSelectedSACombo.Text);
                args.SAOptionSelected = SelectionSelected;
                args.SAOptionValue = Convert.ToDecimal(m_optionValueSAText.Text, CultureInfo.CurrentCulture);
                args.FromSpendDate = m_fromSpendDate.Value;
                args.ToSpendDate = m_toSpendDate.Value;

            }

            if (m_findAllVIPCheckBox.Checked)
            {
                args.IsLocation = true;
                if (LocCat == 0)
                {
                    args.LocationType  = 1;

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
                }

                if (m_locListBoxSelected.Items.Count == 0)
                {
                    args.LocationDefinition = string.Empty;      
                }


            }
            if (m_daysPlayedCheck.Checked)
            {
                args.IsNumberOfdDaysPlayed = true; 
                args.DPDateRangeFrom = m_dateRangefromDPDatePicker.Value;
                args.DPDateRangeTo = m_dateRangetoDPDatePicker.Value;
           
                if (m_rangeDPRadioButton.Checked)
                {
                    args.IsDPRange = true;
                    args.DPRangeFrom = m_fromRangeDPTextBox.Text;
                    args.DPRangeTo = m_toRangeDPTextBox.Text;
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

            if (m_sessionPlayedCheck.Checked)
            {
        
                args.IsNumberOfSessionPlayed = true;

                args.DPDateRangeFrom = m_dateRangefromDPDatePicker.Value;
                args.DPDateRangeTo = m_dateRangetoDPDatePicker.Value;
           
                if (m_rangeSPRadioButton.Checked)
                {
                    args.IsSPRange = true;
                    args.SPRangeFrom = m_fromRangeSPTextBox.Text;
                    args.SPRangeTo = m_toRangeSPTextBox.Text;
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
            if (m_daysOfWeekAndSessionCheck.Checked)
            {
                args.DPDateRangeFrom = m_dateRangefromDPDatePicker.Value;
                args.DPDateRangeTo = m_dateRangetoDPDatePicker.Value;
                DaysOfWeekNSession = string.Empty; 

                if (m_monDaysVisitCheck.Checked == true)
                {
                    DaysOfWeekNSession += "Mon ";

                    if (m_checkComboMONSession.Text == "ALL")
                    {
                        DaysOfWeekNSession += "(1:2:3:4:5:6:7:8:9:10),";
                    }
                    else
                    {
                        string days;
                        days = m_checkComboMONSession.Text;
                        days = days.Replace(@", ", ":");
                        DaysOfWeekNSession += "(" + days + "),";
                    }
                }

                if (m_tuesDaysVisitCheck.Checked)
                {
                    DaysOfWeekNSession += "Tue ";
                    if (m_checkComboTUESession.Text == "ALL") 
                    {
                        DaysOfWeekNSession += "(1:2:3:4:5:6:7:8:9:10),";
                    }
                    else
                    {                         
                        string days;
                        days = m_checkComboTUESession.Text;
                        days = days.Replace(@", ", ":");
                        DaysOfWeekNSession += "(" + days + "),";
                    }
                }

                if (m_wedDaysVisitCheck.Checked)
                {
                    DaysOfWeekNSession += "Wed ";

                    if (m_checkComboWEDSession.Text == "ALL")
                    {
                        DaysOfWeekNSession += "(1:2:3:4:5:6:7:8:9:10),";
                    }
                    else
                    {
                        string days;
                        days = m_checkComboWEDSession.Text;
                        days = days.Replace(@", ", ":");
                        DaysOfWeekNSession += "(" + days + "),";
                    }

                }

                if (m_thursDaysVisitCheck.Checked)
                {
                    DaysOfWeekNSession += "Thu ";

                    if (m_checkComboTHURSSession.Text == "ALL")
                    {
                        DaysOfWeekNSession += "(1:2:3:4:5:6:7:8:9:10),";
                    }
                    else
                    {
                        string days;
                        days = m_checkComboTHURSSession.Text;
                        days = days.Replace(@", ", ":");
                        DaysOfWeekNSession += "(" + days + "),";
                    }
                }

                if (m_friDaysVisitCheck.Checked)
                {
                    DaysOfWeekNSession += "Fri ";

                    if (m_checkComboFRISession.Text == "ALL")
                    {
                        DaysOfWeekNSession += "(1:2:3:4:5:6:7:8:9:10),";
                    }
                    else
                    {
                        string days;
                        days = m_checkComboFRISession.Text;
                        days = days.Replace(@", ", ":");
                        DaysOfWeekNSession += "(" + days + "),";
                    }

                }

                if (m_satDaysVisitCheck.Checked)
                {
                    DaysOfWeekNSession += "Sat ";
                    if (m_checkComboSATSession.Text == "ALL")
                    {
                        DaysOfWeekNSession += "(1:2:3:4:5:6:7:8:9:10),";
                    }
                    else
                    {
                        string days;
                        days = m_checkComboSATSession.Text;
                        days = days.Replace(@", ", ":");
                        DaysOfWeekNSession += "(" + days + "),";
                    }
                }

                if (m_sunDaysVisitCheck.Checked)
                {
                    DaysOfWeekNSession += "Sun ";
                    if (m_checkComboSUNSession.Text == "ALL")
                    {
                        DaysOfWeekNSession += "(1:2:3:4:5:6:7:8:9:10),";
                    }
                    else
                    {
                        string days;
                        days = m_checkComboSUNSession.Text;
                        days = days.Replace(@", ", ":");
                        DaysOfWeekNSession += "(" + days + "),";
                    }
                }
                   
                DaysOfWeekNSession = DaysOfWeekNSession.Remove(DaysOfWeekNSession.Length - 1, 1);         
                args.DaysOFweekAndSession = DaysOfWeekNSession;
       
            }
            else
            {
                args.DaysOFweekAndSession = string.Empty; 
            }

            if (m_ProductCheckBox.Checked)
            {
                args.IsProduct = true; 
                SelectedProductPar = m_ProductCheckBox2.Text;
                SelectedProductPar = SelectedProductPar.Replace(@", ", "/|\\");
                args.SelectedProduct = SelectedProductPar;
                args.FromSpendDate = m_fromSpendDate.Value;
                args.ToSpendDate = m_toSpendDate.Value;              
           }


            // Spawn a new thread to find players and wait until done.
            // FIX: DE2476
            DialogResult result = DialogResult.OK;

            if(m_exportRadio.Checked)
            {
                // Prompt the user for the file name.
                SaveFileDialog saveForm = new SaveFileDialog();
                saveForm.RestoreDirectory = true;
                saveForm.Filter = ExportFileFilter;
                saveForm.DefaultExt = DefaultFileExt;

                result = saveForm.ShowDialog(this);

                if(result == DialogResult.OK)
                    m_parent.StartExportPlayerList(saveForm.FileName, args);
            }
            else
                m_parent.StartGetPlayerReport(m_listReportRadio.Checked, args);

            if(result == DialogResult.OK)
            {
                m_parent.ShowWaitForm(this); // Block until we are done.

                if(m_parent.LastAsyncException != null)
                {
                    if(m_parent.LastAsyncException is ServerCommException)
                        Close();
                    else
                        MessageForm.Show(this, m_parent.LastAsyncException.Message, Resources.PlayerCenterName);
                }
                else if(m_parent.LastAsyncException == null && !m_exportRadio.Checked)
                    m_parent.ShowReportForm();
                else if(m_parent.LastAsyncException == null && m_exportRadio.Checked)
                {
                    if(m_parent.LastNumPlayersExported > 0)
                        MessageForm.Show(this, string.Format(CultureInfo.CurrentCulture, Resources.PlayersExported, m_parent.LastNumPlayersExported), Resources.PlayerCenterName);
                    else
                        MessageForm.Show(this, Resources.NoPlayersExported, Resources.PlayerCenterName);
                }
            }            // END: DE2476
        }     
        private void m_locationButton_Click(object sender, EventArgs e)
        {
            m_locationPanel.Visible = true;
            m_listCriteriaPanel.Visible = false;
            m_playDatesPanel.Visible = false;
            m_spendPanel.Visible = false; 
        }
        private void m_listCriteriaButton1_Click(object sender, EventArgs e)
        {
            m_locationPanel.Visible = false;
            m_playDatesPanel.Visible = false;
            m_listCriteriaPanel.Visible = true;
            m_spendPanel.Visible = false; 
        }

        private void m_listTypeButton_Click(object sender, EventArgs e)
        {
            m_locationPanel.Visible = false;
            m_listCriteriaPanel.Visible = false;
            m_playDatesPanel.Visible = false; 
        }

        private void m_playDatesButton_Click(object sender, EventArgs e)
        {
            m_spendPanel.Visible = false; 
            m_locationPanel.Visible = false;
            m_listCriteriaPanel.Visible = false;
            m_playDatesPanel.Visible = true;
        }

        private void m_dateRangefromDPDatePicker_ValueChanged(object sender, EventArgs e)
        {
            LoadDaysINWeek();      

        }

        private void m_dateRangetoDPDatePicker_ValueChanged(object sender, EventArgs e)
        {
            LoadDaysINWeek(); 
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
            catch
            {
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
            catch
            {
                e.Cancel = true;
           //     m_errorProvider.SetError(m_toRangeSPTextBox,, Resources.InvalidPlayerListNSessionPlayedRange2);
                m_errorProvider.SetError(m_rangeSPRadioButton, "Invalid Entry");
            }
        }

        private void m_rangePBRadio_Validating(object sender, CancelEventArgs e)//If user did not pick any selection
        {
            if (m_rangePBRadio.Checked == false && m_optionPBRadio.Checked  == false)
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
           
           if  (m_optionSelectedPBCombo.Text == string.Empty)  
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
                  
                    m_locListBox.Items.Add(State);
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
            else if  (LocCat == 1)
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
            catch
            {
                e.Cancel = true;
                m_errorProvider.SetError(m_locListBoxSelected, "Unknown Error");
            }
        }

        private void m_ProductCheckBox2_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (m_ProductCheckBox2.Text  == string.Empty)
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
            //     m_locListBox.SetSelected(x, false);
              
             }
             else //if control key is not being press
             {
                 m_locListBox.ClearSelected();//verything will be claear
                
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

        private void m_spendBotton_Click(object sender, EventArgs e)
        {


            m_locationPanel.Visible = false;
            m_listCriteriaPanel.Visible = false;
            m_playDatesPanel.Visible = false;
            m_spendPanel.Visible = true; 
 
  
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        //private void m_closeButton_Click(object sender, EventArgs e)
        //{

        //}



        //private void m_statusCheckComboBox_ItemCheck(object sender, ItemCheckEventArgs e)
        //{
        //  //  int i = m_statusCheckComboBox.SelectedIndex;
        //    int i = e.Index; 
          
        //    if (e.NewValue  == CheckState.Checked)
        //    {
        //        m_statusID.SetItemChecked(i, true);
        //    }
        //    else if (e.NewValue == CheckState.Unchecked)
        //    {
        //        m_statusID.SetItemChecked(i, false);
        //    }

        //}
        //US2649
        #endregion
    }
}