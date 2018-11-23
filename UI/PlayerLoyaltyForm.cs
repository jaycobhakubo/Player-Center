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
        private int m_tierIdDefault;
        private List<Tier> m_tiers;
        private Tier m_tierSelected;
        private int m_color;//?

        public PlayerLoyaltyForm()
        {
            InitializeComponent();
            m_datetimepickerQualifyingPeriodEnd.Value = DateTime.Now.AddYears(1);
            m_tierRule = new TierRule();
            m_tierRule = GetPlayerTierRule.Msg();
            m_tiers = new List<Tier>();
            m_tiers = GetPlayerTier.Msg(0);
            DisplayTierRule();
            PopulateTierList();

        }

        private void SelectTierDefault()
        {
            if (m_tierIdDefault != 0)      //Always select the default tier if no default first tier             
            {
                m_lstboxTiers.SelectedValue = m_tierIdDefault;
            }
            else
            {
                m_lstboxTiers.SelectedIndex = 0;
            }
        }

        private void DisplayTierRule()
        {
            if (m_tierRule != null)            //If tier rule is not null
            {
                m_tierIdDefault = m_tierRule.DefaultTierID;//If not 0 then it has a default tier -> need to  test wit == 0.
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
        }

        private void PopulateTierList()
        {
            if (m_lstboxTiers != null)
            {
                m_lstboxTiers.ValueMember = "TierID";
                m_lstboxTiers.DisplayMember = "TierName";
                m_lstboxTiers.DataSource = m_tiers;//Will fire selected index = 0              
            }              
        }

        private void DisplayTier(Tier x)
        {
            m_txtbxTierName.Text = x.TierName;
            m_lblTierColor.BackColor = Color.FromArgb(x.TierColor);
            m_color = x.TierColor;
            bool y = false;
            int count = 0;

            if (x.AmntSpend != -1)
            {
                m_cmbxQualfyingSpend.SelectedIndex = 0;
                y = x.AmntSpend == (Int64)x.AmntSpend;//check if its a whole number or a decimal
                if (y == true)
                {
                    m_txtbxSpendStart.Text = Convert.ToString(x.AmntSpend) + ".00";
                }
                else
                {
                    count = BitConverter.GetBytes(decimal.GetBits(x.AmntSpend)[3])[2];
                    //if its only have 1 decimal places then lets add 1 more
                    if (count == 1)
                    {
                        m_txtbxPointStart.Text = Convert.ToString(x.AmntSpend) + "0";
                    }
                    //if its more than 2 then lets round it off
                    else if (count > 2)
                    {
                        m_txtbxPointStart.Text = Math.Round(x.AmntSpend, 2).ToString();
                    }
                    else
                    {
                        m_txtbxPointStart.Text = Convert.ToString(x.AmntSpend);
                    }
                }
            }
            else
            {
                m_cmbxQualfyingSpend.SelectedIndex = 1;
                m_txtbxSpendStart.Text = "";
            }

            if (x.NbrPoints != -1)
            {
                m_cmbxQualifyingpoints.SelectedIndex = 0;
                y = x.NbrPoints == (Int64)x.NbrPoints;
                if (y == true)
                {
                    m_txtbxPointStart.Text = Convert.ToString(x.NbrPoints) + ".00";
                }
                else
                {
                    //lets check how many decimal places is being use?
                    count = BitConverter.GetBytes(decimal.GetBits(x.NbrPoints)[3])[2];
                    //if its only have 1 decimal places then lets add 1 more
                    if (count == 1)
                    {
                        m_txtbxPointStart.Text = Convert.ToString(x.NbrPoints) + "0";
                    }
                    //if its more than 2 then lets round it off
                    else if (count > 2)
                    {
                        m_txtbxPointStart.Text = Math.Round(x.NbrPoints, 2).ToString();
                    }
                    else
                    {
                        m_txtbxPointStart.Text = Convert.ToString(x.NbrPoints);
                    }
                }
            }
            else
            {
                m_cmbxQualifyingpoints.SelectedIndex = 1;//NO
                m_txtbxPointStart.Text = "";
            }

            y = x.Multiplier == (Int64)x.Multiplier;
            if (y == true)
            {
                m_txtbxAwardPointsMultiplier.Text = Convert.ToString(x.Multiplier) + ".00";
            }
            else
            {
                count = BitConverter.GetBytes(decimal.GetBits(x.Multiplier)[3])[2];
                //if its only have 1 decimal places then lets add 1 more
                if (count == 1)
                {
                    m_txtbxAwardPointsMultiplier.Text = Convert.ToString(x.Multiplier) + "0";
                }
                //if its more than 2 then lets round it off
                else if (count > 2)
                {
                    m_txtbxAwardPointsMultiplier.Text = Math.Round(x.Multiplier, 2).ToString();
                }
                else
                {
                    m_txtbxAwardPointsMultiplier.Text = Convert.ToString(x.Multiplier);
                }
            }
        }

        private void DisplayTier()
        {         
            if (m_lstboxTiers != null)
            {
                PopulateTierList();             
            }         
        }

        private void m_lstboxTiers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_lstboxTiers.SelectedIndex != -1)// Update
            {
                m_tierSelected = new Tier();
                m_tierSelected = (Tier)m_lstboxTiers.SelectedItem;
                DisplayTier(m_tierSelected);             
            }
        }
    }   
}

