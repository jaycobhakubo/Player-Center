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
        private TierRule m_tierRule;
        private List<Tier> m_tiers;
        private Tier m_tierSelected;
        private int m_color;//?

        public PlayerLoyaltyForm()
        {
            InitializeComponent();
            m_tierRule = new TierRule();
            m_tiers = new List<Tier>();

            m_tierRule = GetPlayerTierRule.Msg();
            m_tiers = GetPlayerTier.Msg(0, m_tierRule.DefaultTierID);//if 0,0 then no default tier
            DisplayTierRule();
            PopulateTierList();    
            DisableEnableControlDefaultTierRules(true);
            DisableEnableControlDefaultTier(true);
        }


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
            }

           if (lbl_MessageSaved.Visible == true) lbl_MessageSaved.Visible = false;
        }

        private void DisableEnableControlDefaultTierRules(bool IsDefault)
        {
            m_datetimepickerQualifyingPeriodStart.Enabled = !IsDefault;
            m_datetimepickerQualifyingPeriodEnd.Enabled = !IsDefault;
            m_cmbxDefaultTier.Enabled = !IsDefault;
            m_cmbxDowngradeToDefault.Enabled = !IsDefault;
            //m_tbctrlPlayerLoyalty.Enabled = !IsDefault; -- need to work on this Do ot change tab while editing

            if (IsDefault == true)
            {
                m_btnEditSaveTierRule.Text = "&Edit";
            }
            else
            {
                m_btnEditSaveTierRule.Text = "&Save";
            }

            if (m_lblSavedSuccessNotification.Visible == true) m_lblSavedSuccessNotification.Visible = false;
        }

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
                    foreach (Tier TierName in m_tiers)
                    {
                        m_cmbxDefaultTier.Items.Add(TierName.TierName);
                        if (m_tierRule.DefaultTierID != 0 && m_tierRule.DefaultTierID == TierName.TierID)
                        {
                            m_cmbxDefaultTier.SelectedIndex = itemCount;
                        }
                        itemCount++;
                    }
                }
            }
            else
            {
                m_datetimepickerQualifyingPeriodEnd.Value = DateTime.Now.AddYears(1);
            }
        }
        
    
        private void SelectDefaultOrFirstRowTier()
        {
            if (m_tierRule.DefaultTierID != 0 && m_tiers.Count != 0)
            {
                m_lstboxTiers.SelectedValue = m_tierRule.DefaultTierID;
            }    
        }

        private void PopulateTierList()
        {      
                m_lstboxTiers.ValueMember = "TierID";
                m_lstboxTiers.DisplayMember = "TierName";
                m_lstboxTiers.DataSource = m_tiers;//Will fire selected index = 0      
                SelectDefaultOrFirstRowTier();                                            
        }

        private void DisplayTier(Tier x)
        {
            m_txtbxTierName.Text = x.TierName;
            m_lblTierColor.BackColor = Color.FromArgb(x.TierColor);
            m_color = x.TierColor;
            bool y = false;
            int count = 0;

            if (x.QualifyingSpend != -1)
            {
                m_cmbxQualfyingSpend.SelectedIndex = 0;
                y = x.QualifyingSpend == (Int64)x.QualifyingSpend;//check if its a whole number or a decimal
                if (y == true)
                {
                    m_txtbxSpendStart.Text = Convert.ToString(x.QualifyingSpend) + ".00";
                }
                else
                {
                    count = BitConverter.GetBytes(decimal.GetBits(x.QualifyingSpend)[3])[2];
                    //if its only have 1 decimal places then lets add 1 more
                    if (count == 1)
                    {
                        m_txtbxPointStart.Text = Convert.ToString(x.QualifyingSpend) + "0";
                    }
                    //if its more than 2 then lets round it off
                    else if (count > 2)
                    {
                        m_txtbxPointStart.Text = Math.Round(x.QualifyingSpend, 2).ToString();
                    }
                    else
                    {
                        m_txtbxPointStart.Text = Convert.ToString(x.QualifyingSpend);
                    }
                }
            }
            else
            {
                m_cmbxQualfyingSpend.SelectedIndex = 1;
                m_txtbxSpendStart.Text = "";
            }

            if (x.QualifyingPoints != -1)
            {
                m_cmbxQualifyingpoints.SelectedIndex = 0;
                y = x.QualifyingPoints == (Int64)x.QualifyingPoints;
                if (y == true)
                {
                    m_txtbxPointStart.Text = Convert.ToString(x.QualifyingPoints) + ".00";
                }
                else
                {
                    //lets check how many decimal places is being use?
                    count = BitConverter.GetBytes(decimal.GetBits(x.QualifyingPoints)[3])[2];
                    //if its only have 1 decimal places then lets add 1 more
                    if (count == 1)
                    {
                        m_txtbxPointStart.Text = Convert.ToString(x.QualifyingPoints) + "0";
                    }
                    //if its more than 2 then lets round it off
                    else if (count > 2)
                    {
                        m_txtbxPointStart.Text = Math.Round(x.QualifyingPoints, 2).ToString();
                    }
                    else
                    {
                        m_txtbxPointStart.Text = Convert.ToString(x.QualifyingPoints);
                    }
                }
            }
            else
            {
                m_cmbxQualifyingpoints.SelectedIndex = 1;//NO
                m_txtbxPointStart.Text = "";
            }

            y = x.AwardPointsMultiplier == (Int64)x.AwardPointsMultiplier;
            if (y == true)
            {
                m_txtbxAwardPointsMultiplier.Text = Convert.ToString(x.AwardPointsMultiplier) + ".00";
            }
            else
            {
                count = BitConverter.GetBytes(decimal.GetBits(x.AwardPointsMultiplier)[3])[2];
                //if its only have 1 decimal places then lets add 1 more
                if (count == 1)
                {
                    m_txtbxAwardPointsMultiplier.Text = Convert.ToString(x.AwardPointsMultiplier) + "0";
                }
                //if its more than 2 then lets round it off
                else if (count > 2)
                {
                    m_txtbxAwardPointsMultiplier.Text = Math.Round(x.AwardPointsMultiplier, 2).ToString();
                }
                else
                {
                    m_txtbxAwardPointsMultiplier.Text = Convert.ToString(x.AwardPointsMultiplier);
                }
            }
        }

        private void m_lstboxTiers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_lstboxTiers.SelectedIndex != -1)//If item is being selected
            {
                m_tierSelected = new Tier();
                m_tierSelected = (Tier)m_lstboxTiers.SelectedItem;
                DisplayTier(m_tierSelected);             
            }
        }

        private void m_btnEditSaveTierRule_Click(object sender, EventArgs e)
        {
           // m_errorProvider.SetError(m_datetimepickerQualifyingPeriodStart, string.Empty);



            if (m_btnEditSaveTierRule.Text == "&Edit")
            {
                DisableEnableControlDefaultTierRules(false);
                m_btnEditSaveTierRule.Text = "&Save";
            
                // tabControl1.TabPages.

            }
            else if (m_btnEditSaveTierRule.Text == "&Save")
            {
                //savePlayerTierRules();
                m_btnEditSaveTierRule.Text = "&Edit";
                DisableEnableControlDefaultTierRules(true);
                m_lblSavedSuccessNotification.Visible = true;
               

            }
        }

        private void m_btnCancelTierRule_Click(object sender, EventArgs e)
        {
            //m_errorProvider.SetError(m_datetimepickerQualifyingPeriodStart, string.Empty);
            //label4.Visible = false;
            //DisplayPlayerRule();
            DisableEnableControlDefaultTierRules(true);
            DisplayTierRule();
            if (m_tierRule.DefaultTierID != 0)
            m_cmbxDefaultTier.SelectedValue = m_tierRule.DefaultTierID;
            //DisplayPlayerRule();
            //if (m_cmbxDefaultTier.Items.Count != 0 && DefaultTierIndex != -2)
            //    m_cmbxDefaultTier.SelectedIndex = DefaultTierIndex;
        }

        private void m_btnCloseTierRule_Click(object sender, EventArgs e)
        {
           // m_errorProvider.SetError(m_datetimepickerQualifyingPeriodStart, string.Empty);
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

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

        private void m_btnAddTier_Click(object sender, EventArgs e)
        {
            //ClearALLError();
            lbl_MessageSaved.Visible = false;
            m_lstboxTiers.SelectedIndex = -1;
            ClearTiersTab();
            DisableEnableControlDefaultTier(false);
        }

        private void m_btnEditTier_Click(object sender, EventArgs e)
        {
            DisableEnableControlDefaultTier(false);
         //   lbl_MessageSaved.Visible = false;
           
            
        }

     
   

        private void m_btnDeleteTier_Click(object sender, EventArgs e)
        {

            if (MessageForm.Show("Are you sure you want to permanently delete this " + m_tierSelected.TierName + " Tier.", "Player Loyalty", MessageFormTypes.YesNo) == DialogResult.No)
            {
                return;
            }
        /*
            int CurrentIndex = listbox_Tiers.SelectedIndex;
            string ItemSelected = listbox_Tiers.SelectedItem.ToString();

            if (ItemSelected.Contains(" (default)"))
            {
                ItemSelected = ItemSelected.Replace(" (default)", string.Empty);
            }

            if (MessageForm.Show("Are you sure you want to permanently delete this " + ItemSelected + " Tier.", "Player Loyalty", MessageFormTypes.YesNo) == DialogResult.No)
            {
                return;
            }

            lbl_MessageSaved.Visible = false;
            Tier code1 = new Tier();
            code1.TierID = m_tierId;
            code1.TierRulesID = 0;
            code1.TierName = string.Empty;
            code1.TierColor = 0;
            code1.AmntSpend = 0;
            code1.NbrPoints = 0;
            code1.Multiplier = 0;
            code1.isdelete = true;
            //SetPlayerTierData.Save(code1);

            listbox_Tiers.Items.RemoveAt(CurrentIndex);
            CurrentIndex = cmbx_DefaultTier.Items.IndexOf(ItemSelected);
            cmbx_DefaultTier.Items.RemoveAt(CurrentIndex);
            m_tiers.RemoveAll(i => i.TierID == m_tierId);
            m_tierRule.DefaultTierID = 0; //GetPlayerTierRulesData.getPlayerTierRulesData.DefaultTierID = 0 ;   //???
            listbox_Tiers.SelectedIndex = -1;
            ClearTiersTab();

            if (listbox_Tiers.Items.Count == 0)
            {
                imageButtonRemoveTier.Enabled = false;
                imageButtonEditTier.Enabled = false;
                cboColor.BackColor = SystemColors.Control;
            }

            if (listbox_Tiers.Items.Count > 0)
            {
                listbox_Tiers.TopIndex = 0;
                listbox_Tiers.SelectedIndex = 0;
            }
        */
        }

        private void m_btnSaveTier_Click(object sender, EventArgs e)
        {
        
            DisableEnableControlDefaultTier(true);
            lbl_MessageSaved.Visible = true;
            /*
            ClearALLError();
            m_tierNew = new Tier();
            m_tierNew.TierName = txtTierName.Text;
            m_tierNew.TierColor = cboColor.BackColor.ToArgb();
            m_tierNew.AmntSpend = (textBoxSpendStart.Text != string.Empty) ? Convert.ToDecimal(textBoxSpendStart.Text) : -1;
            m_tierNew.NbrPoints = (textbox_PointsStart.Text != string.Empty) ? Convert.ToDecimal(textbox_PointsStart.Text) : -1;
            m_tierNew.Multiplier = (textbox_AwardPointsMultiplier.Text != string.Empty) ? Convert.ToDecimal(textbox_AwardPointsMultiplier.Text) : Convert.ToDecimal("0.00");
            m_tierNew.isdelete = false;
            m_tierNew.TierID = (listbox_Tiers.SelectedIndex != -1) ? m_tierId : 0;
            m_tierNew.TierRulesID = m_tierRule.TierRulesID;//GetPlayerTierRulesData.getPlayerTierRulesData.TierRulesID;
            m_tierCurrent = new Tier();

            if (listbox_Tiers.SelectedIndex != -1)//Existing Tier (update)
            {
                m_tierCurrent = m_tiers.Single(l => l.TierID == m_tierNew.TierID);
                if (m_tierCurrent.Equals(m_tierNew))
                {
                    ContinueSave = false;
                    return;
                }
            }
            else if (listbox_Tiers.SelectedIndex == -1)
            {
                m_tierNew.TierID = 0;
            }

            var testx = ValidateChildren(ValidationConstraints.Enabled | ValidationConstraints.Visible);

            if (!ValidateChildren(ValidationConstraints.Enabled | ValidationConstraints.Visible))           //VALIDATE USER INPUT (check for Empty String)
                return;

            int TierID = SetPlayerTier.Msg(m_tierNew);//
            if (m_tierId == 0)
            {
                listbox_Tiers.Items.Add(txtTierName.Text);
                // m_tierNew.TierID = TierID;
                m_tiers.Add(m_tierNew);
                cmbx_DefaultTier.Items.Add(txtTierName.Text);
                ClearTiersTab();
                DisableControls();
                int countItem = listbox_Tiers.Items.Count;
                listbox_Tiers.SelectedIndex = countItem - 1;

            }
            else if (m_tierId != 0)
            {
                int i = listbox_Tiers.SelectedIndex;

                string x = listbox_Tiers.SelectedItem.ToString();
                if (x.Contains(" (default)"))
                {
                    x = x.Replace(" (default)", "");
                    listbox_Tiers.Items[i] = txtTierName.Text + " (default)";//rename
                }
                else
                {
                    listbox_Tiers.Items[i] = txtTierName.Text;
                }

                listbox_Tiers.Update();
                listbox_Tiers.Refresh();

                int ii = cmbx_DefaultTier.Items.IndexOf(x);
                cmbx_DefaultTier.Items[ii] = txtTierName.Text;


                Tier a = m_tiers.Single(l => l.TierName == x);
                if (a != null)
                {
                    a.TierName = txtTierName.Text;
                    if (textBoxSpendStart.Text == string.Empty)
                    {
                        a.AmntSpend = -1;
                    }
                    else
                    {
                        a.AmntSpend = Convert.ToDecimal(textBoxSpendStart.Text);
                    }

                    if (textbox_PointsStart.Text == string.Empty)
                    {
                        a.NbrPoints = -1;
                    }
                    else
                    {
                        a.NbrPoints = Convert.ToDecimal(textbox_PointsStart.Text);
                    }

                    //a.Multiplier = Convert.ToDecimal(textbox_AwardPoints);
                    // a.NbrPoints = Convert.ToDecimal(textBoxPointsStart.Text);
                }
            }
            lbl_MessageSaved.Visible = true;
            if (listbox_Tiers.Items.Count > 0)
            {
                imageButtonRemoveTier.Enabled = true;
                imageButtonEditTier.Enabled = true;
                imageButtonAddTier.Enabled = true;
                listbox_Tiers.Enabled = true;
            }

            btn_Save.Enabled = false;
            m_cancelButton.Enabled = false;
            */
        }

        private void m_btnCancelTier_Click(object sender, EventArgs e)
        {
            DisableEnableControlDefaultTier(true);
            SelectDefaultOrFirstRowTier();
        }

        private void m_btnCloseTier_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }   
}

