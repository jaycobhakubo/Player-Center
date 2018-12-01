using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.PlayerCenter.Data;
using GTI.Modules.PlayerCenter.Business;
using GTI.Modules.PlayerCenter;
using GTI.Modules.PlayerCenter.Properties;
using GTI.Modules.Shared.Business; 

namespace GTI.Modules.PlayerCenter.UI
{
    public partial class PlayerLoyaltyForm : GradientForm
    {
        #region MEMBER VARIABLE
        private TierRule m_tierRule;
        private List<Tier> m_tiers;
        private Tier m_tierSelected;
        private int m_color;//?
        #endregion

        #region CONSTRUCTOR
        public PlayerLoyaltyForm(List<Tier>tiers_ , TierRule tierRule_)
        {
            InitializeComponent();
            m_tiers = tiers_;
            m_tierRule = tierRule_;
            DisplayTierRule();
            PopulateTierList();
            SelectDefaultOrFirstRowTier();          
            DisableEnableControlDefaultTierRules(true);
            DisableEnableControlDefaultTier(true);
        }
        #endregion

        #region METHOD

       // CLEAR CONTROL FOR NEW TIER
        private void ClearTiersTab()
        {
            m_txtbxTierName.Text = "";
            m_cmbxQualfyingSpend.SelectedIndex = 1;
            m_txtbxSpendStart.Text = "";
            m_cmbxQualifyingpoints.SelectedIndex = 1;
            m_txtbxPointStart.Text = "";
            m_txtbxAwardPointsMultiplier.Text = "1.00";
            m_lblTierColor.BackColor = SystemColors.ButtonHighlight;
            //m_tierId = 0;
        }

      //DISABLE OR ENABLE CONTROL BASE ON ADD, EDIT CANCEL SAVE .. TIER
        private void DisableEnableControlDefaultTier(bool _isEnable)
        {
            //m_tbctrlPlayerLoyalty.Enabled = _isEnable;       
            m_lstboxTiers.Enabled = _isEnable;
            m_btnSaveTier.Enabled = !_isEnable;
            m_btnCancelTier.Enabled = !_isEnable;
            m_btnCloseTier.Enabled = _isEnable;
            m_btnAddTier.Enabled = _isEnable;
            m_btnEditTier.Enabled = _isEnable;
            m_btnDeleteTier.Enabled = _isEnable;

            m_txtbxTierName.Enabled = !_isEnable;
            m_lblTierColor.Enabled = !_isEnable;
            m_cmbxQualfyingSpend.Enabled = !_isEnable;
            m_txtbxSpendStart.Enabled = !_isEnable;
            m_cmbxQualifyingpoints.Enabled = !_isEnable;
            m_txtbxPointStart.Enabled = !_isEnable;
            m_txtbxAwardPointsMultiplier.Enabled = !_isEnable;

            if (_isEnable)
            {
                m_txtbxTierName.BackColor = SystemColors.Control;
                m_txtbxSpendStart.BackColor = SystemColors.Control;
                m_txtbxPointStart.BackColor = SystemColors.Control;
                m_txtbxAwardPointsMultiplier.BackColor = SystemColors.Control;
                m_cmbxQualifyingpoints.BackColor = SystemColors.Control;
                m_cmbxQualfyingSpend.BackColor = SystemColors.Control;
                m_lstboxTiers.BackColor = SystemColors.Window;
                //m_lblTierColor.BackColor = SystemColors.Control;
                m_tbctrlPlayerLoyalty.Selecting -= new TabControlCancelEventHandler(m_tbctrlPlayerLoyalty_Selecting);
                m_cmbxQualfyingSpend.SelectedIndexChanged -=new EventHandler(m_cmbxQualfyingSpend_SelectedIndexChanged);
                m_cmbxQualifyingpoints.SelectedIndexChanged -=new EventHandler(m_cmbxQualifyingpoints_SelectedIndexChanged);
       
            }
            else
            {
                m_txtbxTierName.BackColor = SystemColors.Window;
                m_txtbxSpendStart.BackColor = SystemColors.Window;
                m_txtbxPointStart.BackColor = SystemColors.Window;
                m_txtbxAwardPointsMultiplier.BackColor = SystemColors.Window;
                m_cmbxQualifyingpoints.BackColor = SystemColors.Window;
                m_cmbxQualfyingSpend.BackColor = SystemColors.Window;
                m_lstboxTiers.BackColor = SystemColors.Control;
                m_tbctrlPlayerLoyalty.Selecting += new TabControlCancelEventHandler(m_tbctrlPlayerLoyalty_Selecting);
                m_cmbxQualfyingSpend.SelectedIndexChanged += new EventHandler(m_cmbxQualfyingSpend_SelectedIndexChanged);
                m_cmbxQualifyingpoints.SelectedIndexChanged += new EventHandler(m_cmbxQualifyingpoints_SelectedIndexChanged);
            }

           if (lbl_MessageSaved.Visible == true) lbl_MessageSaved.Visible = false;
          

        }
                   
      // DISABLE OR ENABLE CONTROL BASE ON  EDIT  CANCEL SAVE.. TIER RULE
        private void DisableEnableControlDefaultTierRules(bool IsDefault)
        {
            m_datetimepickerQualifyingPeriodStart.Enabled = !IsDefault;
            m_datetimepickerQualifyingPeriodEnd.Enabled = !IsDefault;
            m_cmbxDefaultTier.Enabled = !IsDefault;
            m_cmbxDowngradeToDefault.Enabled = !IsDefault;
            m_btnCancelTierRule.Enabled = !IsDefault;
            m_btnCloseTierRule.Enabled = IsDefault;

            //m_tbctrlPlayerLoyalty.Enabled = !IsDefault; -- need to work on this Do ot change tab while editing
           
           
            if (IsDefault == true)
            {
                m_btnEditSaveTierRule.Text = "&Edit";
                m_tbctrlPlayerLoyalty.Selecting -= new TabControlCancelEventHandler(m_tbctrlPlayerLoyalty_Selecting);
            }
            else
            {
                m_btnEditSaveTierRule.Text = "&Save";
                m_tbctrlPlayerLoyalty.Selecting += new TabControlCancelEventHandler(m_tbctrlPlayerLoyalty_Selecting);
            }

            if (m_lblTierRuleSavedSuccessNotification.Visible == true) m_lblTierRuleSavedSuccessNotification.Visible = false;
        }
    
       // DISABLE OR ENABLE SPEND/POINTS CONTROL
        private void EnableDisableSpendPoints()
        {
            if (m_cmbxQualfyingSpend.SelectedIndex == 0)
            {
                m_txtbxSpendStart.Enabled = true;
                m_txtbxSpendStart.BackColor = SystemColors.Window;
                // m_txtbxSpendStart.Text = "0.00";
            }
            else
            {
                m_txtbxSpendStart.Enabled = false;
                m_txtbxSpendStart.BackColor = SystemColors.Control;
                m_txtbxSpendStart.Text = string.Empty;
            }

            if (m_cmbxQualifyingpoints.SelectedIndex == 0)
            {
                m_txtbxPointStart.Enabled = true;
                m_txtbxPointStart.BackColor = SystemColors.Window;
                //  m_txtbxPointStart.Text = "0.00";
            }
            else
            {
                m_txtbxPointStart.Enabled = false;
                m_txtbxPointStart.BackColor = SystemColors.Control;
                m_txtbxPointStart.Text = string.Empty;
            }
        }
 
       // DISLAY TIER RULE ON TAB PAGE UI
        private void DisplayTierRule()
        {
            if (m_tierRule != null)
            {
                m_datetimepickerQualifyingPeriodStart.Value = m_tierRule.QualifyingStartDate;
                m_datetimepickerQualifyingPeriodEnd.Value = m_tierRule.QualifyingEndDate;

                if (!m_tierRule.DowngradeToDefault)
                {
                    m_cmbxDowngradeToDefault.SelectedIndex = 1;
                }
                else
                {
                    m_cmbxDowngradeToDefault.SelectedIndex = 0;
                }


                int itemCount = 0;

                if (m_tiers.Count != 0)
                {
                    m_cmbxDefaultTier.Items.Clear();
                    foreach (Tier TierName in m_tiers)
                    {
                        m_cmbxDefaultTier.Items.Add(TierName.TierName);
                        if (m_tierRule.DefaultTierID != 0 && m_tierRule.DefaultTierID == TierName.TierID)
                        {
                            m_cmbxDefaultTier.SelectedIndex = itemCount;
                        }
                        itemCount++;
                    }
                    m_cmbxDefaultTier.Update();
                }
            }
            else
            {
                m_datetimepickerQualifyingPeriodEnd.Value = DateTime.Now.AddYears(1);
            }
        }
        
      // DISPLAY TIER NAME IN  LIST BOX
        private void PopulateTierList()
        {
                m_lstboxTiers.DataSource = null;
                m_lstboxTiers.Items.Clear();
                m_lstboxTiers.ValueMember = "TierID";
                m_lstboxTiers.DisplayMember = "TierName";
                m_lstboxTiers.DataSource = m_tiers;//Will fire selected index = 0      
                m_lstboxTiers.Update();                                                
        }
  
       //DISPLAY TIER FOR ALL CONTROL
        private void DisplayTier(Tier x)
        {
            m_txtbxTierName.Text = x.TierName;
            m_lblTierColor.BackColor = Color.FromArgb(x.TierColor);
            m_color = x.TierColor;

            if (x.QualifyingSpend != -1)
            {
                m_cmbxQualfyingSpend.SelectedIndex = 0;
                FixedDecimalUserInput(x.QualifyingSpend, m_txtbxSpendStart);             
            }
            else
            {
                m_cmbxQualfyingSpend.SelectedIndex = 1;
                m_txtbxSpendStart.Text = string.Empty;
            }

            if (x.QualifyingPoints != -1)
            {
                m_cmbxQualifyingpoints.SelectedIndex = 0;
                FixedDecimalUserInput(x.QualifyingPoints, m_txtbxPointStart);
            }
            else
            {
                m_cmbxQualifyingpoints.SelectedIndex = 1;//NO
                m_txtbxPointStart.Text = string.Empty; ;
            }
            FixedDecimalUserInput(x.AwardPointsMultiplier, m_txtbxAwardPointsMultiplier);
        }

     // NOTIFICATION 
        private void ClearUserNotification()
        {
            m_errorProvider.SetError(m_txtbxTierName, string.Empty);
            m_errorProvider.SetError(m_txtbxSpendStart, string.Empty);
            m_errorProvider.SetError(m_txtbxPointStart, string.Empty);
            m_errorProvider.SetError(m_txtbxAwardPointsMultiplier, string.Empty);
            m_errorProvider.SetError(m_cmbxQualfyingSpend, string.Empty);                  

            //Tab Page Tier Rule
            m_errorProvider.SetError(m_datetimepickerQualifyingPeriodStart, string.Empty);
            if (m_lblTierRuleSavedSuccessNotification.Visible) m_lblTierRuleSavedSuccessNotification.Visible = false;
            if (lbl_MessageSaved.Visible) lbl_MessageSaved.Visible = false;
        }
      
       // SAVE TIER RULE
        private bool SaveTierRule()
        {
            ClearUserNotification();

            if (!ValidateChildren(ValidationConstraints.Enabled | ValidationConstraints.Visible))
            {
                return false;
            }
            else
            {
                TierRule NewTierRule = new TierRule();
                NewTierRule.TierRulesID = m_tierRule.TierRulesID;
                NewTierRule.QualifyingStartDate = DateTime.Parse(m_datetimepickerQualifyingPeriodStart.Value.ToShortDateString());
                NewTierRule.QualifyingEndDate = DateTime.Parse(m_datetimepickerQualifyingPeriodEnd.Value.ToShortDateString());

                if (m_cmbxDefaultTier.Items.Count == 0)//New default tier; this code will never be executed; Not sure If we want to support multiple Tier Rule  just put this one just in case
                {
                    NewTierRule.DefaultTierID = 0;
                }
                else
                {
                    if (m_cmbxDefaultTier.SelectedIndex != -1)
                    {
                        string DefaultTierName = m_cmbxDefaultTier.SelectedItem.ToString();
                        var f = m_tiers.Exists(p => p.TierName == DefaultTierName);
                        bool cc = f;

                        var DefaultTierID = m_tiers.Where(l => l.TierName == DefaultTierName);
                        foreach (var c in DefaultTierID)
                        {
                            int y = c.TierID;
                            NewTierRule.DefaultTierID = y;
                        }
                    }
                }

                string IsDownGradeTDefault = m_cmbxDowngradeToDefault.SelectedItem.ToString();
                if (IsDownGradeTDefault == "No")
                {
                    NewTierRule.DowngradeToDefault = false;
                }
                else
                {
                    NewTierRule.DowngradeToDefault = true;
                }
                //Check If theres any changes
                int t_tierRuleId = 0;

                if (m_tierRule.Equals(NewTierRule))//true = no changes
                {
                    return false;
                }
                else
                {
                    t_tierRuleId = SetPlayerTierRule.Msg(NewTierRule);
                    //  UpdateTierList(NewTierRule);  
                    if (NewTierRule.DefaultTierID != m_tierRule.DefaultTierID)
                    {
                        Tier t_testD = m_tiers.Single(l => l.TierID == m_tierRule.DefaultTierID);
                        t_testD.IsDefaultTier = false;
                        t_testD = m_tiers.Single(l => l.TierID == NewTierRule.DefaultTierID);
                        t_testD.IsDefaultTier = true;
                        m_tierRule = NewTierRule;
                        m_lstboxTiers.SelectedValue = m_tierRule.DefaultTierID;
                        DisplayTierRule();
                        PopulateTierList();
                    }
                    else
                    {
                        m_tierRule = NewTierRule;
                        DisplayTierRule();
                    }
                }
                return true;
            }
        }

      
      // SELECT DEFAULT TIER IF NONE THEN SELECT THE LOWEST TIER
        private void SelectDefaultOrFirstRowTier()
        {
            if (m_tierRule.DefaultTierID != 0 && m_tiers.Count != 0)
            {
                m_lstboxTiers.SelectedValue = m_tierRule.DefaultTierID;
            }
        }

        // CORRECT USER INPUT FOR DECIMAL VALUE
        private void FixedDecimalUserInput(decimal decimalValue_, TextBox txtbxDecimal_)
        {
            bool y = false;
            int count = 0;

            y = decimalValue_ == (Int64)decimalValue_;//check if its a whole number or a decimal
            if (y == true)
            {
                int convertedToWholeNumber = (int)decimalValue_;
                txtbxDecimal_.Text = Convert.ToString(convertedToWholeNumber) + ".00";
            }
            else
            {
                count = BitConverter.GetBytes(decimal.GetBits(decimalValue_)[3])[2];
                //if its only have 1 decimal places then lets add 1 more
                if (count == 1)
                {
                    txtbxDecimal_.Text = Convert.ToString(decimalValue_) + "0";
                }
                //if its more than 2 then lets round it off
                else if (count > 2)
                {
                    txtbxDecimal_.Text = Math.Round(decimalValue_, 2).ToString();
                }
                else
                {
                    txtbxDecimal_.Text = Convert.ToString(decimalValue_);
                }
            }
        }
        #endregion

        #region EVENT

        //  SELECTED TIER
        private void m_lstboxTiers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbl_MessageSaved.Visible) lbl_MessageSaved.Visible = false;

            if (m_lstboxTiers.SelectedIndex != -1)//If item is being selected
            {
                m_tierSelected = new Tier();
                m_tierSelected = (Tier)m_lstboxTiers.SelectedItem;
                DisplayTier(m_tierSelected);
            }
            else
            {
                ClearTiersTab();
            }
        }
    
        // SELECTED QUALIFYING SPEND
        private void m_cmbxQualfyingSpend_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_cmbxQualfyingSpend.SelectedIndex == 0)
            {
                m_txtbxSpendStart.Enabled = true;
                m_txtbxSpendStart.BackColor = SystemColors.Window;
                m_txtbxSpendStart.Text = (m_tierSelected.QualifyingSpend != -1) ? m_tierSelected.QualifyingSpend.ToString() : "0.00";

            }
            else
            {
                m_txtbxSpendStart.Enabled = false;
                m_txtbxSpendStart.BackColor = SystemColors.Control;
                m_txtbxSpendStart.Text = string.Empty;
            }
        }
            
        // SELECTED QUALIFYING POINTS
        private void m_cmbxQualifyingpoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_cmbxQualifyingpoints.SelectedIndex == 0)
            {
                m_txtbxPointStart.Enabled = true;
                m_txtbxPointStart.BackColor = SystemColors.Window;
                m_txtbxPointStart.Text = (m_tierSelected.QualifyingPoints != -1) ? m_tierSelected.QualifyingPoints.ToString() : "0.00";
            }
            else
            {
                m_txtbxPointStart.Enabled = false;
                m_txtbxPointStart.BackColor = SystemColors.Control;
                m_txtbxPointStart.Text = string.Empty;
            }
        }
             
        // EDIT SAVED TIER RULE
        private void m_btnEditSaveTierRule_Click(object sender, EventArgs e)
        {
            // m_errorProvider.SetError(m_datetimepickerQualifyingPeriodStart, string.Empty);
            if (m_btnEditSaveTierRule.Text == "&Edit")
            {
                DisableEnableControlDefaultTierRules(false);
                m_btnEditSaveTierRule.Text = "&Save";
            }
            else if (m_btnEditSaveTierRule.Text == "&Save")
            {
                if (SaveTierRule())
                {
                    m_btnEditSaveTierRule.Text = "&Edit";
                    DisableEnableControlDefaultTierRules(true);
                    m_lblTierRuleSavedSuccessNotification.Visible = true;
                }
            }
        }
       
        //CANCEL TIER RULE
        private void m_btnCancelTierRule_Click(object sender, EventArgs e)
        {
            DisableEnableControlDefaultTierRules(true);
            DisplayTierRule();
            if (m_tierRule.DefaultTierID != 0)
            m_cmbxDefaultTier.SelectedValue = m_tierRule.DefaultTierID;
        }
        
        // CLOSE TIER RULE
        private void m_btnCloseTierRule_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
             
       // ADD TIER
        private void m_btnAddTier_Click(object sender, EventArgs e)
        {
            //ClearALLError();
            if (!lbl_MessageSaved.Visible) lbl_MessageSaved.Visible  = false;
            m_lstboxTiers.SelectedIndex = -1;
            DisableEnableControlDefaultTier(false);
            m_tierSelected = new Tier();
        }

        // EDIT TIER
        private void m_btnEditTier_Click(object sender, EventArgs e)
        {
            DisableEnableControlDefaultTier(false);
            EnableDisableSpendPoints();                           
        }

        /* DELETE TIER*/
        private void m_btnDeleteTier_Click(object sender, EventArgs e)
        {

            if (MessageForm.Show("Are you sure you want to permanently delete this " + m_tierSelected.TierName + " Tier.", "Player Loyalty", MessageFormTypes.YesNo) == DialogResult.No)
            {
                return;
            }
            else
            {
                m_tierSelected.IsDelete = true;
                SetPlayerTier.Msg(m_tierSelected);
                m_tiers.Remove(m_tierSelected);
                PopulateTierList();
                DisableEnableControlDefaultTier(true);
                SelectDefaultOrFirstRowTier();               
            }       
        }

        // SAVED TIER
        private void m_btnSaveTier_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled | ValidationConstraints.Visible))           //VALIDATE USER INPUT (check for Empty String)
            {
                return;
            }
            else
            {
                var t_tierNew = new Tier();
                t_tierNew.TierName = m_txtbxTierName.Text;
                t_tierNew.TierColor =  m_lblTierColor.BackColor.ToArgb();
                t_tierNew.QualifyingSpend = (  m_txtbxSpendStart.Text != string.Empty) ? Convert.ToDecimal(m_txtbxSpendStart.Text) : -1;
                t_tierNew.QualifyingPoints = (m_txtbxPointStart.Text != string.Empty) ? Convert.ToDecimal(m_txtbxPointStart.Text) : -1;
                t_tierNew.AwardPointsMultiplier = ( m_txtbxAwardPointsMultiplier.Text != string.Empty) ? Convert.ToDecimal(m_txtbxAwardPointsMultiplier.Text) : Convert.ToDecimal("0.00");
                t_tierNew.IsDelete = false;
                t_tierNew.TierID = (m_lstboxTiers.SelectedIndex != -1) ? m_tierSelected.TierID : 0;
                t_tierNew.TierRulesID = m_tierRule.TierRulesID;//GetPlayerTierRulesData.getPlayerTierRulesData.TierRulesID;
                t_tierNew.IsDefaultTier = (m_lstboxTiers.SelectedIndex != -1) ? m_tierSelected.IsDefaultTier : false;

                if (m_tierSelected.Equals(t_tierNew))
                {
                    return;
                }                
                
                int t_tierID = SetPlayerTier.Msg(t_tierNew);
                if (t_tierID == t_tierNew.TierID)
                {               
                    Tier t_testD = m_tiers.Single(l => l.TierID == m_tierSelected.TierID);
                    m_tiers.Remove(t_testD);
                    m_tiers.Add(t_tierNew);
                    PopulateTierList();
                    m_lstboxTiers.SelectedValue = t_tierID;
                }
                else
                {
                    t_tierNew.TierID = t_tierID;
                    m_tiers.Add(t_tierNew);
                    PopulateTierList();
                    m_lstboxTiers.SelectedValue = t_tierID;
                }


                ClearUserNotification();
                DisableEnableControlDefaultTier(true);
                lbl_MessageSaved.Visible = true;
            }

          
        }
     
      // CANCEL TIER
        private void m_btnCancelTier_Click(object sender, EventArgs e)
        {
            DisableEnableControlDefaultTier(true);
            ClearUserNotification();
            if (m_tierSelected.TierID == 0)
            {
                SelectDefaultOrFirstRowTier();
            }
            else
            {
                var t_tierNew = new Tier();
                t_tierNew.TierName = m_txtbxTierName.Text;
                t_tierNew.TierColor = m_lblTierColor.BackColor.ToArgb();
                t_tierNew.QualifyingSpend = (m_txtbxSpendStart.Text != string.Empty) ? Convert.ToDecimal(m_txtbxSpendStart.Text) : -1;
                t_tierNew.QualifyingPoints = (m_txtbxPointStart.Text != string.Empty) ? Convert.ToDecimal(m_txtbxPointStart.Text) : -1;
                t_tierNew.AwardPointsMultiplier = (m_txtbxAwardPointsMultiplier.Text != string.Empty) ? Convert.ToDecimal(m_txtbxAwardPointsMultiplier.Text) : Convert.ToDecimal("0.00");
                t_tierNew.IsDelete = false;
                t_tierNew.TierID = (m_lstboxTiers.SelectedIndex != -1) ? m_tierSelected.TierID : 0;
                t_tierNew.TierRulesID = m_tierRule.TierRulesID;//GetPlayerTierRulesData.getPlayerTierRulesData.TierRulesID;

                if (m_tierSelected.Equals(t_tierNew))
                {
                    return;
                }
                else
                {
                    DisplayTier(m_tierSelected);
                }
            }
        }
     
        // CLOSE TIER
        private void m_btnCloseTier_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
       
        //COLOR FORM SHOW
        private void m_lblTierColor_Click(object sender, EventArgs e)
        {
            ColorDialog frmColor = new ColorDialog { Color = m_lblTierColor.BackColor };
            if (frmColor.ShowDialog(this) == DialogResult.OK)
            {
                m_lblTierColor.BackColor = frmColor.Color;
                m_lblTierColor.Invalidate();
            }
            frmColor.Dispose();
        }

        //Qualifying period date
        private void ValidateTierRuleQualifyingPeriodDate(object sender, CancelEventArgs e)
        {
            bool v = (m_datetimepickerQualifyingPeriodEnd.Value < m_datetimepickerQualifyingPeriodStart.Value);
            if (m_datetimepickerQualifyingPeriodEnd.Value < m_datetimepickerQualifyingPeriodStart.Value)
            {
                e.Cancel = true;
                m_errorProvider.SetError(m_datetimepickerQualifyingPeriodStart, "Qualify Period Start is after Qualifying Period End");//Resources.InvalidPlayerListLastVisit);
            }
        }
 
        //Tier Name
        private void m_txtbxTierName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (m_txtbxTierName.Text == string.Empty)
                {
                    m_errorProvider.SetError(m_txtbxTierName, "Please enter a Tier Name.");
                    e.Cancel = true;
                    return;
                }

                bool itExists = false;
                if (m_lstboxTiers.SelectedIndex != -1)
                {
                    if (m_tierSelected.TierName != m_txtbxTierName.Text)//Renaming existing tier. 
                    {
                        itExists = m_tiers.Where(p => p.TierID != m_tierSelected.TierID).ToList().Exists(l => l.TierName.Equals(m_txtbxTierName.Text, StringComparison.InvariantCultureIgnoreCase));
                    }

                }
                else
                {
                    itExists = m_tiers.Exists(l => l.TierName.Equals(m_txtbxTierName.Text, StringComparison.InvariantCultureIgnoreCase));
                }

                if (itExists)
                {
                    m_errorProvider.SetError(m_txtbxTierName, "Name already exists.");
                    e.Cancel = true;
                }
            }
            catch
            {
                e.Cancel = true;
                m_errorProvider.SetError(m_txtbxTierName, "Check your input");
                return;
            }
        }

        // Spend Start
        private void m_txtbxSpendStart_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (m_cmbxQualfyingSpend.SelectedIndex == 0)//YES
                {
                    if (m_txtbxSpendStart.Text == string.Empty)
                    {
                        e.Cancel = true;
                        m_errorProvider.SetError(m_txtbxSpendStart, "Please enter a Spend start.");
                        return;

                    }

                    decimal checkinput;
                    if (Decimal.TryParse(m_txtbxSpendStart.Text, out checkinput))//if its a decimal
                    {

                        bool itExists = false;
                        var newQualifyingSpend = decimal.Parse(m_txtbxSpendStart.Text);
                        if (m_lstboxTiers.SelectedIndex != -1)
                        {

                            if (m_tierSelected.QualifyingSpend != newQualifyingSpend)
                            {
                                itExists = m_tiers.Where(p => p.TierID != m_tierSelected.TierID).ToList().Exists(l => l.QualifyingSpend.Equals(newQualifyingSpend));
                            }

                        }
                        else
                        {
                            itExists = m_tiers.Exists(l => l.QualifyingSpend.Equals(newQualifyingSpend));
                        }


                        if (itExists)
                        {
                            e.Cancel = true;
                            m_errorProvider.SetError(m_txtbxSpendStart, "Spend amount is being used by another Tier");
                            return;
                        }

                    }
                    else
                    {
                        e.Cancel = true;
                        m_errorProvider.SetError(m_txtbxSpendStart, "Not a valid decimal number.");
                        return;
                    }
                }
            }
            catch
            {
                e.Cancel = true;
                m_errorProvider.SetError(m_txtbxSpendStart, "Unknown error call Technician.");
                return;
            }
        }

       //Point Start
        private void m_txtbxPointStart_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (m_cmbxQualifyingpoints.SelectedIndex == 0)//YES
                {
                    if (m_txtbxPointStart.Text == string.Empty)
                    {
                        e.Cancel = true;
                        m_errorProvider.SetError(m_txtbxPointStart, "Please enter a point start.");
                        return;
                    }


                    decimal checkinput;
                    if (Decimal.TryParse(m_txtbxPointStart.Text, out checkinput))//if its a decimal
                    {

                        bool itExists = false;
                        var newQualifyingPoints = decimal.Parse(m_txtbxPointStart.Text);
                        if (m_lstboxTiers.SelectedIndex != -1)
                        {
                            if (m_tierSelected.QualifyingPoints != newQualifyingPoints)
                            {
                                itExists = m_tiers.Where(p => p.TierID != m_tierSelected.TierID).ToList().Exists(l => l.QualifyingPoints.Equals(newQualifyingPoints));
                            }
                        }
                        else
                        {
                            itExists = m_tiers.Exists(l => l.QualifyingPoints.Equals(newQualifyingPoints));
                        }

                        if (itExists)
                        {
                            e.Cancel = true;
                            m_errorProvider.SetError(m_txtbxPointStart, "Point amount is being used by another Tier");
                            return;
                        }
                    }
                    else
                    {
                        e.Cancel = true;
                        m_errorProvider.SetError(m_txtbxPointStart, "Not a valid decimal number.");
                    }
                }
            }
            catch
            {
                e.Cancel = true;
                m_errorProvider.SetError(m_txtbxPointStart, "Unknown error call Technician.");
                return;
            }
        }

        // Award Points Multiplier
        private void m_txtbxAwardPointsMultiplier_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (m_txtbxAwardPointsMultiplier.Text == string.Empty)
                {
                    e.Cancel = true;
                    m_errorProvider.SetError(m_txtbxAwardPointsMultiplier, "Please make an entry");
                    return;
                }
                decimal checkinput;
                if (Decimal.TryParse(m_txtbxAwardPointsMultiplier.Text, out checkinput))//if its a decimal
                {
                }
                else
                {
                    e.Cancel = true;
                    m_errorProvider.SetError(m_txtbxAwardPointsMultiplier, "Not a valid decimal number.");
                    return;
                }
            }
            catch
            {
                e.Cancel = true;
                m_errorProvider.SetError(m_txtbxAwardPointsMultiplier, "Please make an entry");
                return;
            }
        }

        //Spend/Points Combobox
        private void m_cmbxQualfyingSpend_Validating(object sender, CancelEventArgs e)
        {
            if (m_cmbxQualifyingpoints.SelectedIndex == 1 && m_cmbxQualfyingSpend.SelectedIndex == 1)
            {
                e.Cancel = true;
                m_errorProvider.SetError(m_cmbxQualfyingSpend, "Need one selection spend or points");
            }
        }



        private void m_txtbxAwardPointsMultiplier_KeyPress(object sender, KeyPressEventArgs e)
        {

            bool result = false;
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
                result = e.Handled;
            }

            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
                result = e.Handled;
            }
            e.Handled = result;

        }

        //PREVENT NAVIGATING TO OTHER TAB PAG WHILE CREATING/UPDATING TIER OR TIER RULE
        private void m_tbctrlPlayerLoyalty_Selecting(object sender, TabControlCancelEventArgs e)
        {
  
                if (e.TabPageIndex == 0)
                {
                    e.Cancel = true;
                }
                else
                if (e.TabPageIndex == 1)
                {
                    e.Cancel = true;
                }           
        }
        #endregion            
    }   
}
