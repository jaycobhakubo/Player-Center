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

            m_datetimepickerQualifyingPeriodEnd.Value = DateTime.Now.AddYears(1);
            m_tierRule = new TierRule();
            m_tiers = new List<Tier>();

            m_tierRule = GetPlayerTierRule.Msg();
            if (m_tierRule != null) DisplayTierRule();

            m_tiers = GetPlayerTier.Msg(0, m_tierRule.DefaultTierID);//if 0,0 then no default tier
            if (m_tiers != null) PopulateTierList();



            DisableEnableControlDefaultTierRules(true);
            
        }

        //private void SelectTierDefault()
        //{
        //    if (m_tierIdDefault != 0)      //Always select the default tier if no default first tier             
        //    {
        //        m_lstboxTiers.SelectedValue = m_tierIdDefault;
        //    }
        //    else
        //    {
        //        m_lstboxTiers.SelectedIndex = 0;
        //    }
        

        private void DisableEnableControlDefaultTierRules(bool IsDefault)
        {
            m_datetimepickerQualifyingPeriodStart.Enabled = !IsDefault;
            m_datetimepickerQualifyingPeriodEnd.Enabled = !IsDefault;
            m_cmbxDefaultTier.Enabled = !IsDefault;
            m_cmbxDowngradeToDefault.Enabled = !IsDefault;

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
                m_datetimepickerQualifyingPeriodStart.Value  = m_tierRule.QualifyingStartDate;
                m_datetimepickerQualifyingPeriodEnd.Value = m_tierRule.QualifyingEndDate;
             
                if (!m_tierRule.DowngradeToDefault)
                {
                    m_cmbxDowngradeToDefault.SelectedIndex = 1;
                }
                else
                {
                    m_cmbxDowngradeToDefault.SelectedIndex = 0;
                }

        
        }

        private void PopulateTierList()
        {      
                m_lstboxTiers.ValueMember = "TierID";
                m_lstboxTiers.DisplayMember = "TierName";
                m_lstboxTiers.DataSource = m_tiers;//Will fire selected index = 0   

                m_cmbxDefaultTier.ValueMember = "TierID";
                m_cmbxDefaultTier.DisplayMember = "TierName";
                m_cmbxDefaultTier.DataSource = m_tiers;//Will fire selected index = 0   

                if (m_tierRule.DefaultTierID != 0)
                {
                    m_lstboxTiers.SelectedValue = m_tierRule.DefaultTierID;
                    m_cmbxDefaultTier.SelectedValue = m_tierRule.DefaultTierID;
                }                       
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
    }   
}

