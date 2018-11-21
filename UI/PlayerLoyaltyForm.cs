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

        public PlayerLoyaltyForm()
        {
            InitializeComponent();
            m_datetimepickerQualifyingPeriodEnd.Value = DateTime.Now.AddYears(1);
            m_tierRule = new TierRule();
            m_tierRule = GetPlayerTierRule.Msg();
            m_tiers = new List<Tier>();
            m_tiers = GetPlayerTier.Msg(0);
            DisplayTierRule();
            DisplayTier();
        }

        private void DisplayTierRule()
        {
           
            //If tier rule is not null
            if (m_tierRule.TierRulesID != null)
            {
                m_tierIdDefault = m_tierRule.TierRulesID;
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

        private void DisplayTier()
        {
            if (m_lstboxTiers != null)
            {
                m_lstboxTiers.DataSource = m_tiers;
                m_lstboxTiers.ValueMember = "TierID";
                m_lstboxTiers.DisplayMember = "TierName";
            }         
        }
    }   
}

