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
//using System.Globalization;
//using GTI.Modules.PlayerCenter.Business;
using GTI.Modules.PlayerCenter.Properties;
using GTI.Modules.Shared.Business; 
//using GTI.Modules.PlayerCenter.Data; //US2469    
//using System.Collections.Generic;  //US2469

namespace GTI.Modules.PlayerCenter.UI
{
    public partial class PlayerLoyaltyForm : GradientForm
    {

        private int m_tierId = 0;
        private int m_color;
        private int DefaultTierIndex = -2;
        private bool ContinueSave = false;
        
        //************************************
        private TierRule m_tierRule;
        private List<Tier> m_tiers;
        private Tier m_tierNew;
        private Tier m_tierCurrent;
        //**************************************

        public PlayerLoyaltyForm()
        {
            InitializeComponent();
            m_cmbxQualfyingSpend.SelectedIndex = 1;
            m_cmbxQualifyingpoints.SelectedIndex = 1;
            cmbx_DefaultTier.Items.Clear();
            m_lstboxTiers.Items.Clear();       
            dateTimePicker1.Value = DateTime.Now.AddYears(1);
            m_tierRule = new TierRule();
            m_tiers = new List<Tier>();
            m_tierRule = GetPlayerTierRule.Msg();
            m_tiers = GetPlayerTier.Msg(0);
            DisplayPlayerRule();
            DisplayTierName();

            if (m_lstboxTiers.Items.Count > 0)
            {
              m_lstboxTiers.SelectedIndex = 0;
          }
          else
          {              
                  m_btnDelete.Enabled = false;
                  m_btnEdit.Enabled = false;
          }

            DisableControls();
            DisableContorls_TierRules();
            if (m_lstboxTiers.Items.Count > 0) 
            {
                DiplayTierNameInTierRule();
            }

            //Lets check this out 
            if (m_lstboxTiers.Items.Count == 0)
            {
                m_lblTierColor.BackColor = SystemColors.Control;
            }

            m_btnCancel.Enabled = false;
            m_btnSave.Enabled = false;

            
        }

        private void DiplayTierNameInTierRule()
        {
        int  defaulttier = m_tierRule.DefaultTierID;
        int i = 0;
         foreach (Tier TierName in m_tiers)
         {
                 cmbx_DefaultTier.Items.Add(TierName.TierName);
                 if (defaulttier == TierName.TierID)
                 {
                     cmbx_DefaultTier.SelectedIndex = i;
                 }

                 i++;

         }

         //int z = i;// now this is 10
            
        }


        private void DisableTierUIControl(bool _isEnable)//knc
        {
            //m_tbctrlPlayerLoyalty.Enabled = _isEnable;       
            m_lstboxTiers.Enabled = _isEnable;
            m_btnSave.Enabled = !_isEnable;
            m_btnCancel.Enabled = !_isEnable;
            m_btnClose.Enabled = _isEnable;
            m_btnAdd.Enabled = _isEnable;
            m_btnEdit.Enabled = _isEnable;
            m_btnDelete.Enabled = _isEnable;

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
        }

        private void DisableControls()
        {
            //m_txtbxTierName.Enabled = false;
            //m_lblTierColor.Enabled = false;
            //m_cmbxQualfyingSpend.Enabled = false;
            //m_txtbxSpendStart.Enabled = false;
            //m_cmbxQualifyingpoints.Enabled = false;
            //m_txtbxPointStart.Enabled = false;
            //m_txtbxAwardPointsMultiplier.Enabled = false;
            //m_txtbxTierName.BackColor = SystemColors.Control;
            ////cboColor.BackColor = SystemColors.Control;
            //m_cmbxQualfyingSpend.BackColor = SystemColors.Control;
            //m_txtbxSpendStart.BackColor = SystemColors.Control;
            //m_cmbxQualifyingpoints.BackColor = SystemColors.Control;
            //m_txtbxPointStart.BackColor = SystemColors.Control;
            //m_txtbxAwardPointsMultiplier.BackColor = SystemColors.Control;
        }

        private void DisableContorls_TierRules()
        {
            deytympiker_QualifyingPeriodStart.Enabled = false;
            dateTimePicker1.Enabled = false;
            cmbx_DefaultTier.Enabled = false;
            comboBoxRestart.Enabled = false;
        }

        private void EnableControls()
        {
            //m_txtbxTierName.Enabled = true;
            //m_lblTierColor.Enabled = true;
            //m_cmbxQualfyingSpend.Enabled = true;
            //m_cmbxQualifyingpoints.Enabled = true;
            //m_txtbxAwardPointsMultiplier.Enabled = true;

            //m_txtbxTierName.BackColor = SystemColors.Window;
            ////cboColor.BackColor = SystemColors.Window;
            //m_cmbxQualfyingSpend.BackColor = SystemColors.Window;
            ////textBoxSpendStart.BackColor = SystemColors.Control;
            //m_cmbxQualifyingpoints.BackColor = SystemColors.Window;
            ////textBoxPointsStart.BackColor = SystemColors.Control;
            //m_txtbxAwardPointsMultiplier.BackColor = SystemColors.Window;

        }

        private void EnableContorls_TierRules()
        {
            deytympiker_QualifyingPeriodStart.Enabled = true;
            dateTimePicker1.Enabled = true;
            cmbx_DefaultTier.Enabled = true;
            comboBoxRestart.Enabled = true;
        }


        private void DisplayTierName()
        {

            var defaulttier = m_tierRule.DefaultTierID;//GetPlayerTierRulesData.getPlayerTierRulesData.DefaultTierID;


              int i = 0;

              m_lstboxTiers.DataSource = m_tiers;
              m_lstboxTiers.ValueMember = "TierID";
              m_lstboxTiers.DisplayMember = "TierName";
     
              
              



            //foreach (Tier TierName_ in m_tiers)
            //{

            //    if (TierName_.TierID == defaulttier)
            //    {
                    
            //         m_lstboxTiers.Items.Add(TierName_.TierName + " (default)");
            //    }
            //    else
            //    {
            //        m_lstboxTiers.Items.Add(TierName_.TierName);
            //        m_lstboxTiers.Tag = TierName_.TierID;
            //    }

            //    i++;
            //}
            //int z = i;
        }

        private void DisplayPlayerRule()
        {
            int checkTierRulesID = m_tierRule.TierRulesID; 

            if (checkTierRulesID != 0)
            {
                deytympiker_QualifyingPeriodStart.Value = m_tierRule.QualifyingStartDate;
                dateTimePicker1.Value = m_tierRule.QualifyingEndDate;
                int checkDefaultTier = m_tierRule.DefaultTierID;
                bool x = m_tierRule.DowngradeToDefault;

                if (x == false)
                {
                    comboBoxRestart.SelectedIndex = 1;
                }
                else
                {
                    comboBoxRestart.SelectedIndex = 0;
                }
            }
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
            m_tierId = 0;
        }


        private void comboBoxSpend_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (m_cmbxQualfyingSpend.SelectedIndex == 0)
            {
                m_txtbxSpendStart.Enabled = true;
                m_txtbxSpendStart.BackColor = SystemColors.Window;
                m_txtbxSpendStart.Text = "0.00";
            }
            else
            {
                m_txtbxSpendStart.Enabled = false;
                m_txtbxSpendStart.BackColor = SystemColors.Control;
                m_txtbxSpendStart.Text = string.Empty;
            }
        }

        private void comboBoxPoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_cmbxQualifyingpoints.SelectedIndex == 0)
            {
                m_txtbxPointStart.Enabled = true;
                m_txtbxPointStart.BackColor = SystemColors.Window;
                m_txtbxPointStart.Text = "0.00";
            }
            else
            {
                m_txtbxPointStart.Enabled = false;
                m_txtbxPointStart.BackColor = SystemColors.Control;
                m_txtbxPointStart.Text = string.Empty;
            }
        }

        private void textBoxSpendStart_KeyPress(object sender, KeyPressEventArgs e)
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



        private void textBoxPointsStart_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cboColor_Click(object sender, EventArgs e)
        {
            ColorDialog frmColor = new ColorDialog { Color = m_lblTierColor.BackColor };
            if (frmColor.ShowDialog(this) == DialogResult.OK)
            {            
                    m_lblTierColor.BackColor = frmColor.Color;
                    m_lblTierColor.Invalidate();
            }
            frmColor.Dispose();
      
        }

        private void ClearALLError()
        {
            m_errorProvider.SetError(m_txtbxTierName, string.Empty);
            m_errorProvider.SetError(m_txtbxSpendStart, string.Empty);
            m_errorProvider.SetError(m_txtbxPointStart, string.Empty);
            m_errorProvider.SetError(m_txtbxAwardPointsMultiplier, string.Empty);
            m_errorProvider.SetError(m_cmbxQualfyingSpend, string.Empty);

            if (lbl_MessageSaved.Visible) lbl_MessageSaved.Visible = false;
        }

        private void NoChangeSetControl()
        {
            // MessageForm.Show("No changes made.");
            lbl_MessageSaved.Visible = true;
            if (m_lstboxTiers.Items.Count > 0)
            {
                m_btnDelete.Enabled = true;
                m_btnEdit.Enabled = true;
                m_btnAdd.Enabled = true;
                m_lstboxTiers.Enabled = true;
            }

            DisableControls();
            int Color_ = m_lblTierColor.BackColor.ToArgb();
            if (Color_ == -1)
            {
                m_lblTierColor.BackColor = SystemColors.Control;
            }
            m_btnSave.Enabled = false;
            m_btnCancel.Enabled = false;
        }



        private void imageButtonSave_Click(object sender, EventArgs e)//SAVED tier
        {
            ClearALLError();
            m_tierNew = new Tier();      
            m_tierNew.TierName = m_txtbxTierName.Text;
            m_tierNew.TierColor = m_lblTierColor.BackColor.ToArgb();
            m_tierNew.AmntSpend = (m_txtbxSpendStart.Text != string.Empty) ? Convert.ToDecimal(m_txtbxSpendStart.Text) : -1;
            m_tierNew.NbrPoints = (m_txtbxPointStart.Text != string.Empty) ? Convert.ToDecimal(m_txtbxPointStart.Text) : -1;
            m_tierNew.Multiplier = (m_txtbxAwardPointsMultiplier.Text != string.Empty) ? Convert.ToDecimal(m_txtbxAwardPointsMultiplier.Text) : Convert.ToDecimal("0.00");
            m_tierNew.isdelete = false;
            m_tierNew.TierID = (m_lstboxTiers.SelectedIndex != -1) ? m_tierId : 0;
            m_tierNew.TierRulesID = m_tierRule.TierRulesID;//GetPlayerTierRulesData.getPlayerTierRulesData.TierRulesID;
            m_tierCurrent = new Tier();
  
            if (m_lstboxTiers.SelectedIndex != -1)//Existing Tier (update)
            {
                m_tierCurrent = m_tiers.Single(l => l.TierID == m_tierNew.TierID);
                if (m_tierCurrent.Equals(m_tierNew))
                {
                    ContinueSave = false;
                    return;
                }
            }
            else if (m_lstboxTiers.SelectedIndex == -1)
            {
                m_tierNew.TierID = 0;               
            }

            var testx = ValidateChildren(ValidationConstraints.Enabled | ValidationConstraints.Visible);

            if (!ValidateChildren(ValidationConstraints.Enabled | ValidationConstraints.Visible))           //VALIDATE USER INPUT (check for Empty String)
            return;

            int TierID = SetPlayerTier.Msg(m_tierNew);//
            if (m_tierId == 0)
            {
                m_lstboxTiers.Items.Add(m_txtbxTierName.Text);
               // m_tierNew.TierID = TierID;
                m_tiers.Add(m_tierNew);
                cmbx_DefaultTier.Items.Add(m_txtbxTierName.Text);
                ClearTiersTab();
                DisableControls();
                int countItem = m_lstboxTiers.Items.Count;
                m_lstboxTiers.SelectedIndex = countItem - 1;

            }
            else if (m_tierId != 0)
            {
                int i = m_lstboxTiers.SelectedIndex;

                string x = m_lstboxTiers.SelectedItem.ToString();
                if (x.Contains(" (default)"))
                {
                    x = x.Replace(" (default)", "");
                    m_lstboxTiers.Items[i] = m_txtbxTierName.Text + " (default)";//rename
                }
                else
                {
                    m_lstboxTiers.Items[i] = m_txtbxTierName.Text;              
                }

                m_lstboxTiers.Update();
                m_lstboxTiers.Refresh();

                int ii = cmbx_DefaultTier.Items.IndexOf(x);
                cmbx_DefaultTier.Items[ii] = m_txtbxTierName.Text;

                
                Tier a = m_tiers.Single(l => l.TierName == x);
                if (a != null)
                {
                    a.TierName = m_txtbxTierName.Text;
                    if (m_txtbxSpendStart.Text == string.Empty)
                    {
                        a.AmntSpend = -1;
                    }
                    else
                    {
                        a.AmntSpend = Convert.ToDecimal(m_txtbxSpendStart.Text);
                    }

                    if (m_txtbxPointStart.Text == string.Empty)
                    {
                        a.NbrPoints = -1;
                    }
                    else
                    {
                        a.NbrPoints = Convert.ToDecimal(m_txtbxPointStart.Text);
                    }

                    //a.Multiplier = Convert.ToDecimal(textbox_AwardPoints);
                    // a.NbrPoints = Convert.ToDecimal(textBoxPointsStart.Text);
                }
            }
            lbl_MessageSaved.Visible = true;
            DisableTierUIControl(true);
            //if (m_lstboxTiers.Items.Count > 0)
            //{
                //m_btnDelete.Enabled = true;
                //m_btnEdit.Enabled = true;
                //m_btnAdd.Enabled = true;
                //m_lstboxTiers.Enabled = true;
            //}

            //m_btnSave.Enabled = false;
            //m_btnCancel.Enabled = false;
        }

        private void imageButton4_Click(object sender, EventArgs e)
        {
           

            m_errorProvider.SetError(deytympiker_QualifyingPeriodStart, string.Empty);

            DefaultTierIndex = cmbx_DefaultTier.SelectedIndex;

            if (imageButton4.Text == "&Edit")
            {
                EnableContorls_TierRules();
                imageButton4.Text = "&Save";
                label4.Visible = false; 
              // tabControl1.TabPages.
 
            }
            else if (imageButton4.Text == "&Save")
            {
                savePlayerTierRules();
        
            }
           
        }

        private void savePlayerTierRules()
        {
            m_errorProvider.SetError(deytympiker_QualifyingPeriodStart, string.Empty);



            if (!ValidateChildren(ValidationConstraints.Enabled | ValidationConstraints.Visible))
                return;

            int TierRuleID = m_tierRule.TierRulesID;//GetPlayerTierRulesData.getPlayerTierRulesData.TierRulesID;
            TierRule code1 = new TierRule();
            code1.TierRulesID = TierRuleID;
            code1.QualifyingStartDate = DateTime.Parse(deytympiker_QualifyingPeriodStart.Value.ToShortDateString());
            code1.QualifyingEndDate = DateTime.Parse(dateTimePicker1.Value.ToShortDateString());

            if (cmbx_DefaultTier.Items.Count == 0)
            {
                code1.DefaultTierID = 0;
            }
            else
            {
                if (cmbx_DefaultTier.SelectedIndex != -1)
                {
                    string DefaultTierName = cmbx_DefaultTier.SelectedItem.ToString();
                    var f = m_tiers.Exists(p => p.TierName == DefaultTierName);
                    bool cc = f;

                    var DefaultTierID = m_tiers.Where(l => l.TierName == DefaultTierName);
                    foreach (var c in DefaultTierID)
                    { int y = c.TierID; code1.DefaultTierID = y; }
                }
            }

            string IsDownGradeTDefault = comboBoxRestart.SelectedItem.ToString();
            if (IsDownGradeTDefault == "No")
            {
                code1.DowngradeToDefault = false;
            }
            else
            {
                code1.DowngradeToDefault = true;
            }

            //SetPlayerTierRulesData.setPlayerTierRulesData = code1;
            m_tierRule = code1; //will replace the old 1 no need to clear it

            int x = SetPlayerTierRule.Msg(code1);

            label4.Visible = true;
            imageButton4.Text = "&Edit";
            DisableContorls_TierRules();

            if (cmbx_DefaultTier.SelectedIndex != -1)
            {
                int n = -1;
                string o = "";
                foreach (string m in m_lstboxTiers.Items)
                {
                    if (m.Contains(" (default)"))
                    {
                        n = m_lstboxTiers.Items.IndexOf(m);
                        o = m.Replace(" (default)", "");

                    }
                }

                if (n != -1)
                {
                    m_lstboxTiers.Items[n] = o;
                }
                string items = cmbx_DefaultTier.SelectedItem.ToString();
                int index = m_lstboxTiers.Items.IndexOf(items);
                items = items + " (default)";
                m_lstboxTiers.Items[index] = items;

            }
        }

        private void PopulateTierIntoUI(Tier x)
        {
            //foreach (Tier x in DTierData)
            //{
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
            //}
        }

      

        private void colorListBoxTiers_SelectedIndexChanged(object sender, EventArgs e)
        {

            ClearALLError();
            if (m_lstboxTiers.SelectedIndex != -1)//Update
            {
                var _tierName = Convert.ToString(m_lstboxTiers.SelectedItem);

                if (_tierName.Contains(" (default)"))
                {
                    _tierName = _tierName.Replace(" (default)", string.Empty);
                }

                m_tierCurrent = m_tiers.Single(l => l.TierName == _tierName);
                m_tierId = m_tierCurrent.TierID;
                PopulateTierIntoUI(m_tierCurrent);
                //ActivateDeactivateControl();
             
            }
            else //After saved and delete successfull
            {
                //int Color_ = cboColor.BackColor.ToArgb();

                //if (Color_ == -1)
                //{
                //   cboColor.BackColor = SystemColors.Control;
                //}
                //cboColor.BackColor = SystemColors.Control;
            }

            //imageButtonEditTier.Enabled = true;
            //imageButtonRemoveTier.Enabled = true;
            //imageButtonAddTier.Enabled = true;
           
        }


        private void imageButtonRemoveTier_Click(object sender, EventArgs e)
        {
            int CurrentIndex = m_lstboxTiers.SelectedIndex;
            string ItemSelected = m_lstboxTiers.SelectedItem.ToString();

            if (ItemSelected.Contains(" (default)"))
            {
                ItemSelected = ItemSelected.Replace(" (default)", string.Empty);
            }     

            if (MessageForm.Show("Are you sure you want to permanently delete this " + ItemSelected + " Tier." , "Player Loyalty", MessageFormTypes.YesNo) == DialogResult.No)
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
            SetPlayerTier.Msg(code1);
                   
            m_lstboxTiers.Items.RemoveAt(CurrentIndex);          
            CurrentIndex = cmbx_DefaultTier.Items.IndexOf(ItemSelected);
            cmbx_DefaultTier.Items.RemoveAt(CurrentIndex);
            m_tiers.RemoveAll(i => i.TierID == m_tierId);
            m_tierRule.DefaultTierID = 0; //GetPlayerTierRulesData.getPlayerTierRulesData.DefaultTierID = 0 ;   //???
            //m_lstboxTiers.SelectedIndex = -1; 
            ClearTiersTab();

            if (m_lstboxTiers.Items.Count == 0)
            {
                m_lstboxTiers.SelectedIndex = -1; 
            }

            if (m_lstboxTiers.Items.Count > 0)
            {
                m_lstboxTiers.TopIndex = 0;
                m_lstboxTiers.SelectedIndex = 0;
            }

            DisableTierUIControl(true);
        }


        private void imageButtonAddTier_Click(object sender, EventArgs e)
        {
            ClearALLError();
            lbl_MessageSaved.Visible = false;
            m_lstboxTiers.SelectedIndex = -1;
            ClearTiersTab();
            m_cmbxQualfyingSpend.SelectedIndex = 1;
            m_cmbxQualifyingpoints.SelectedIndex = 1;
            DisableTierUIControl(false);
        }


        private void imageButtonEditTier_Click(object sender, EventArgs e)
        {
            ClearALLError();
            if(lbl_MessageSaved.Visible)lbl_MessageSaved.Visible = false;
            DisableTierUIControl(false);
        }

        private void m_cancelButton_Click(object sender, EventArgs e)
        {          
            ClearALLError();
            if (lbl_MessageSaved.Visible)lbl_MessageSaved.Visible = false;       
            ClearTiersTab();    
            m_lstboxTiers.SelectedIndex = 0;
            DisableTierUIControl(true);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_tbctrlPlayerLoyalty.SelectedIndex == 1)
            {
                DisableTierUIControl(true);

                //bool rulesChange = CheckChangesOnRules();
                //if (rulesChange == true)
                //{
                    //TierRulesCancelButton();
                    //tabControl1.SelectedTab = tabPage1;
                    //if (MessageForm.Show("Do you want save your changes.", "Player Loyalty", MessageFormTypes.YesNo) == DialogResult.Yes)
                    //{
                    //    savePlayerTierRules();
                    //    return;
                    //    //then let us save
                    //}
                    //else
                    //{
                    //    tabControl1.SelectedTab = tabPage2;
                    //    m_errorProvider.SetError(dateTimePicker2, string.Empty);
                    //    lbl_MessageSaved.Visible = false;
                    //    label4.Visible = false;
                    //}
                //}
                //else
                //{
                    //MessageBox.Show("No changes found");
                    //set tab to default
                    //  tabControl1.SelectedTab = tabPage2;
                    //m_errorProvider.SetError(dateTimePicker2, string.Empty);
                    //lbl_MessageSaved.Visible = false;
                    //label4.Visible = false;

                //}
            }



            //m_errorProvider.SetError(deytympiker_QualifyingPeriodStart, string.Empty);
            //lbl_MessageSaved.Visible = false;
            //label4.Visible = false;
        }

        private void imageButton3_Click(object sender, EventArgs e)
        {
            TierRulesCancelButton();
        }

        private void TierRulesCancelButton()
        {
            m_errorProvider.SetError(deytympiker_QualifyingPeriodStart, string.Empty);
            label4.Visible = false;
            //DisplayPlayerRule();
            DisableContorls_TierRules();
            if (imageButton4.Text == "&Save")
            {
                imageButton4.Text = "&Edit";
            }

            DisplayPlayerRule();
            if (cmbx_DefaultTier.Items.Count != 0 && DefaultTierIndex != -2)
                cmbx_DefaultTier.SelectedIndex = DefaultTierIndex;
        }

        private void textBoxAwardPoints_KeyPress(object sender, KeyPressEventArgs e)
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


        #region VALIDATE USER INPUT
        //TIERNAME
        private void txtTierName_Validating(object sender, CancelEventArgs e)
        {     
            try
            {
                if (m_tierNew.TierName == string.Empty)
                {
                  
                    m_errorProvider.SetError(m_txtbxTierName, "Please enter a Tier Name.");
                    e.Cancel = true;
                    return;
                }

                bool itExists = false;
                if (m_lstboxTiers.SelectedIndex != -1)
                {
                    if (m_tierCurrent.TierName != m_tierNew.TierName)//Renaming existing tier. 
                    {
                        itExists = m_tiers.Where(p => p.TierID != m_tierNew.TierID).ToList().Exists(l => l.TierName.Equals(m_tierNew.TierName, StringComparison.InvariantCultureIgnoreCase));
                    }             
                }
                else
                {
                   itExists = m_tiers.Exists(l => l.TierName.Equals(m_tierNew.TierName, StringComparison.InvariantCultureIgnoreCase));                
                }

                if (itExists)
                {
                    ContinueSave = false; //do not saved.
                    m_errorProvider.SetError(m_txtbxTierName, "Name already exists.");
                    e.Cancel = true;
                }

            }                                           
            catch
            {
                e.Cancel = true;
                m_errorProvider.SetError(m_txtbxTierName, "Check your input");
            }
            var testy = e.Cancel;
        }


        private void textBoxSpendStart_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (m_cmbxQualfyingSpend.SelectedIndex == 0)//YES
                {
                    if (m_txtbxSpendStart.Text == string.Empty)
                    {
                        e.Cancel = true;
                        m_errorProvider.SetError(m_txtbxSpendStart, "Please enter a Spend start.");

                    }

                    decimal checkinput;
                    if (Decimal.TryParse(m_txtbxSpendStart.Text, out checkinput))//if its a decimal
                    {

                        bool itExists = false;
                        if (m_lstboxTiers.SelectedIndex != -1)
                        {

                            if (m_tierCurrent.AmntSpend != m_tierNew.AmntSpend)
                            {
                                itExists = m_tiers.Where(p => p.TierID != m_tierNew.TierID).ToList().Exists(l => l.AmntSpend.Equals(m_tierNew.AmntSpend));
                            }
                         
                        }
                        else
                        {
                            itExists = m_tiers.Exists(l => l.AmntSpend.Equals(m_tierNew.AmntSpend));

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
                    }

                }
            }
            catch
            {
                e.Cancel = true;
                m_errorProvider.SetError(m_txtbxSpendStart, "Unknown error call Technician.");
            }
        }

        private void textBoxPointsStart_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (m_cmbxQualifyingpoints.SelectedIndex == 0)//YES
                {
                    if (m_txtbxPointStart.Text == string.Empty)
                    {
                        e.Cancel = true;
                        m_errorProvider.SetError(m_txtbxPointStart, "Please enter a point start.");

                    }


                    decimal checkinput;
                    if (Decimal.TryParse(m_txtbxPointStart.Text, out checkinput))//if its a decimal
                    {

                        bool itExists = false;
                        if (m_lstboxTiers.SelectedIndex != -1)
                        {

                            if (m_tierCurrent.NbrPoints != m_tierNew.NbrPoints)
                            {
                                itExists = m_tiers.Where(p => p.TierID != m_tierNew.TierID).ToList().Exists(l => l.NbrPoints.Equals(m_tierNew.NbrPoints));
                            }                                                     
                        }
                        else
                        {
                            itExists = m_tiers.Exists(l => l.NbrPoints.Equals(m_tierNew.NbrPoints));
                             
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
            }
        }

        private void textBoxAwardPoints_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (m_txtbxAwardPointsMultiplier.Text == string.Empty)
                {
                    e.Cancel = true;
                    m_errorProvider.SetError(m_txtbxAwardPointsMultiplier, "Please make an entry");
                }
            }
            catch
            {
                e.Cancel = true;
                   m_errorProvider.SetError(m_txtbxAwardPointsMultiplier, "Please make an entry");
            }
        }

        private void comboBoxSpend_Validating(object sender, CancelEventArgs e)
        {
            if (m_cmbxQualifyingpoints.SelectedIndex == 1 && m_cmbxQualfyingSpend.SelectedIndex == 1)
            {
                e.Cancel = true;
                m_errorProvider.SetError(m_cmbxQualfyingSpend, "Atleast make one selection spend or points");
            }
        }
        #endregion

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void m_closeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void imageButton1_Click(object sender, EventArgs e)
        {
            m_errorProvider.SetError(deytympiker_QualifyingPeriodStart, string.Empty);
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool CheckChangesOnRules()
        {
            bool YesorNo = false;

            DateTime NewQualifyingPeriodStart = Convert.ToDateTime(deytympiker_QualifyingPeriodStart.Value);
            DateTime NewQualifyingPeriodEnd = Convert.ToDateTime(dateTimePicker1.Value);//if it give you an error use toString
            string NewDefaultier = string.Empty;

            if (cmbx_DefaultTier.SelectedIndex != -1)//its been set to default
            {
                NewDefaultier = cmbx_DefaultTier.SelectedItem.ToString();
            }

            bool NewDownGradeToDefault = false;
            if (comboBoxRestart.SelectedIndex == 0)//YES
            {
                NewDownGradeToDefault = true;
            }


            TierRule t = m_tierRule;//GetPlayerTierRulesData.getPlayerTierRulesData;
            string currentDefaultTier = "";
            if (t.DefaultTierID != 0)//error here
            {
                var lll = m_tiers.Single(l => l.TierID == t.DefaultTierID);//(l => l.TierRulesID == t.DefaultTierID);
                currentDefaultTier = lll.TierName;
            }

            
            //foreach (var h in GetPlayerTierData.getPlayerTierData)
            //{
            //    int r = h.TierID;
            //}


            //var td = GetPlayerTierData.getPlayerTierData.Where(l => l.TierID == t.DefaultTierID);
            //string currentDefaultTier = string.Empty;
            //foreach (var x in td)
            //{
            //    currentDefaultTier = x.TierName;
            //}


            if (t.QualifyingStartDate != NewQualifyingPeriodStart)
            {
                YesorNo = true;
            }
            else if (t.QualifyingEndDate != NewQualifyingPeriodEnd)
            {
                YesorNo = true;
            }
            else if (/*lll.TierName*/ currentDefaultTier != NewDefaultier)
            {
                YesorNo = true;
            }
            else if (t.DowngradeToDefault != NewDownGradeToDefault)
            {
                YesorNo = true;
            }
            else
            {
                YesorNo = false;
            }



            return YesorNo;
        }

        private bool IstherAnyChangesmadeFromTheUser()
        {
            bool YESorNO = false;
            string NewTierName = m_txtbxTierName.Text;

            int NewColor = m_lblTierColor.BackColor.ToArgb();
            //bool NewQualifyingSpend = false;
            //if (comboBoxSpend.SelectedIndex == 0)//true
            //{
            //    NewQualifyingSpend = true;
            //}
              decimal NewSpendStart = -1;
            if (m_txtbxSpendStart.Text != string.Empty)
            {
             NewSpendStart = Convert.ToDecimal(m_txtbxSpendStart.Text);

            }
            //bool NewQualifyingPoints = false;
            //if (comboBoxPoints.SelectedIndex == 0)
            //{
            //    NewQualifyingPoints = true;
            //}
            decimal NewPointStart = -1;//it means its null
            if (m_txtbxPointStart.Text != string.Empty)
            {
                NewPointStart = Convert.ToDecimal(m_txtbxPointStart.Text);
            }

            decimal NewAwardsMultiplier = 0;
            if (m_txtbxAwardPointsMultiplier.Text != string.Empty)
            {
             NewAwardsMultiplier = Convert.ToDecimal(m_txtbxAwardPointsMultiplier.Text);
            }




            string current_TierName = m_lstboxTiers.SelectedItem.ToString();
            if (current_TierName.Contains(" (default)"))
            {
                current_TierName = current_TierName.Replace(" (default)", "");

            }

            Tier a = m_tiers.Single(l => l.TierName == current_TierName);

            if (NewTierName != a.TierName)
            {
                YESorNO = true;
            }
            else if (NewColor != a.TierColor)
            {
                YESorNO = true;
            }
            else if (NewSpendStart != a.AmntSpend)
            {
                YESorNO = true;
            }
            else if (NewPointStart != a.NbrPoints)
            {
                YESorNO = true;
            }
            else if (NewAwardsMultiplier != a.Multiplier)
            {
                YESorNO = true;
            }
            else
            {
                YESorNO = false;
            }



            //  if (a != null)
          //  {

            //    a.TierName = txtTierName.Text;
             //   a.AmntSpend = Convert.ToDecimal(textBoxSpendStart.Text);
            //a.NbrPoints = Convert.ToDecimal(textBoxPointsStart.Text);
           // }


            return YESorNO; //return true for now 
        }

        private void dateTimePicker2_Validating(object sender, CancelEventArgs e)
        {
            bool v = (dateTimePicker1.Value < deytympiker_QualifyingPeriodStart.Value);
            if (dateTimePicker1.Value < deytympiker_QualifyingPeriodStart.Value)
            {
                e.Cancel = true;
                m_errorProvider.SetError(deytympiker_QualifyingPeriodStart, "Qualify Period Start is after Qualifying Period End");//Resources.InvalidPlayerListLastVisit);
            }
        }



        //US3407
        //knc for testing purposes 
        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(@"Data Source=gtiserver;Initial Catalog=Daily;Persist Security Info=True;User ID=sa;Password=Guardian1"); sc.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(@"exec ForTesting_spUpdatePlayerClubBalancesNow", sc);
            cmd.ExecuteNonQuery();
            sc.Close();
        }

        ////US3407
        ////knc for testing purposes 
        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(@"Data Source=gtiserver;Initial Catalog=Daily;Persist Security Info=True;User ID=sa;Password=Guardian1"); sc.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(@"exec ForTesting_spUpdatePlayerClubBalancesRollBackToRecent", sc);
            cmd.ExecuteNonQuery();
            sc.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                button1.Visible = true;
                button2.Visible = true;

            }
            else if (checkBox1.Checked == false)
            {
                button1.Visible = false;
                button2.Visible = false;
            }
        }
        
    }
   
}

