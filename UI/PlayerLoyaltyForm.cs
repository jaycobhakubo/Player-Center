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
//using GTI.Modules.PlayerCenter.Data; //US2469    
//using System.Collections.Generic;  //US2469

namespace GTI.Modules.PlayerCenter.UI
{
    public partial class PlayerLoyaltyForm : GradientForm
    {

        //private string[] ColorNames;
        internal static List<TierData> List_PlayerTierData { get; private set; }
        private int m_TierID = 0;
        private int m_color;
        int DefaultTierIndex = -2;

        public PlayerLoyaltyForm()
        {
            InitializeComponent();
            comboBoxSpend.SelectedIndex = 1;
            comboBoxPoints.SelectedIndex = 1;
            cmbx_DefaultTier.Items.Clear();
            colorListBoxTiers.Items.Clear();
            GetPlayerTierData.getPlayerTierData.Clear();
            
            dateTimePicker1.Value = DateTime.Now.AddYears(1); 
            GetPlayerTierRulesDatam.GetPlayerTierRules();
            DisplayPlayerRule();
            List_PlayerTierData = GetPlayerTierDatam.getPlayertierData(0);
            DisplayTierName();

            if (colorListBoxTiers.Items.Count > 0)
            {
              colorListBoxTiers.SelectedIndex = 0;
          }
          else
          {              
                  imageButtonRemoveTier.Enabled = false;
                  imageButtonEditTier.Enabled = false;
          }

           DisableControls();
            DisableContorls_TierRules();
            if (colorListBoxTiers.Items.Count > 0) 
            {
                DiplayTierNameInTierRule();
            }

            //Lets check this out 
            if (colorListBoxTiers.Items.Count == 0)
            {
                cboColor.BackColor = SystemColors.Control;
            }

            m_cancelButton.Enabled = false;
            imageButtonSave.Enabled = false;

            
        }

        private void DiplayTierNameInTierRule()
        {
        int  defaulttier = GetPlayerTierRulesData.getPlayerTierRulesData.DefaultTierID;
        int i = 0;
         foreach (TierData TierName in GetPlayerTierData.getPlayerTierData)
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

        private void DisableControls()
        {
            txtTierName.Enabled = false;
            cboColor.Enabled = false;
            comboBoxSpend.Enabled = false;
            textBoxSpendStart.Enabled = false;
            comboBoxPoints.Enabled = false;
            textBoxPointsStart.Enabled = false;
            textBoxAwardPoints.Enabled = false;

            txtTierName.BackColor = SystemColors.Control;
            //cboColor.BackColor = SystemColors.Control;
            comboBoxSpend.BackColor = SystemColors.Control;
            textBoxSpendStart.BackColor = SystemColors.Control;
            comboBoxPoints.BackColor = SystemColors.Control;
            textBoxPointsStart.BackColor = SystemColors.Control;
            textBoxAwardPoints.BackColor = SystemColors.Control;


        }

        private void DisableContorls_TierRules()
        {
            dateTimePicker2.Enabled = false;
            dateTimePicker1.Enabled = false;
            cmbx_DefaultTier.Enabled = false;
            comboBoxRestart.Enabled = false;
        }

        private void EnableControls()
        {
            txtTierName.Enabled = true;
            cboColor.Enabled = true;
            comboBoxSpend.Enabled = true;
            comboBoxPoints.Enabled = true;
            textBoxAwardPoints.Enabled = true;

            txtTierName.BackColor = SystemColors.Window;
            //cboColor.BackColor = SystemColors.Window;
            comboBoxSpend.BackColor = SystemColors.Window;
            //textBoxSpendStart.BackColor = SystemColors.Control;
            comboBoxPoints.BackColor = SystemColors.Window;
            //textBoxPointsStart.BackColor = SystemColors.Control;
            textBoxAwardPoints.BackColor = SystemColors.Window;

        }

        private void EnableContorls_TierRules()
        {
            dateTimePicker2.Enabled = true;
            dateTimePicker1.Enabled = true;
            cmbx_DefaultTier.Enabled = true;
            comboBoxRestart.Enabled = true;
        }


        private void DisplayTierName()
        {
         
              int  defaulttier = GetPlayerTierRulesData.getPlayerTierRulesData.DefaultTierID;


              int i = 0;

            foreach (TierData TierName_ in GetPlayerTierData.getPlayerTierData)
            {

                if (TierName_.TierID == defaulttier)
                {
                    
                     colorListBoxTiers.Items.Add(TierName_.TierName + " (default)");
                }
                else
                {
                    colorListBoxTiers.Items.Add(TierName_.TierName);
                    colorListBoxTiers.Tag = TierName_.TierID;
                }

                i++;
            }
            int z = i;
        }

        private void DisplayPlayerRule()
        {
           //if its null

            int checkTierRulesID = GetPlayerTierRulesData.getPlayerTierRulesData.TierRulesID; 

            if (checkTierRulesID != 0)
            {
                dateTimePicker2.Value = GetPlayerTierRulesData.getPlayerTierRulesData.QualifyingStartDate;
                dateTimePicker1.Value = GetPlayerTierRulesData.getPlayerTierRulesData.QualifyingEndDate;

                int checkDefaultTier = GetPlayerTierRulesData.getPlayerTierRulesData.DefaultTierID;
                //will work on this later on
          


                bool x = GetPlayerTierRulesData.getPlayerTierRulesData.DowngradeToDefault;

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

        private void imageButtonAddTier_Click(object sender, EventArgs e)
        {
            ClearALLError();

            imageButtonSave.Enabled = true;
            m_cancelButton.Enabled = true;

            lbl_MessageSaved.Visible = false;
            colorListBoxTiers.SelectedIndex = -1; 
            ClearTiersTab();
            comboBoxSpend.SelectedIndex = 1;
            comboBoxPoints.SelectedIndex = 1;

            EnableControls();
            imageButtonEditTier.Enabled = false;
            imageButtonRemoveTier.Enabled = false;


        }

        private void ClearTiersTab()
        {
            txtTierName.Text = "";
            comboBoxSpend.SelectedIndex = 1;
            textBoxSpendStart.Text = "";
            comboBoxPoints.SelectedIndex = 1;
            textBoxPointsStart.Text = "";
            textBoxAwardPoints.Text = "1.00";
            cboColor.BackColor = SystemColors.ButtonHighlight;
            //label2.Text = "";
            m_TierID = 0;
        }


        private void comboBoxSpend_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (comboBoxSpend.SelectedIndex == 0)
            {
                textBoxSpendStart.Enabled = true;
                textBoxSpendStart.BackColor = SystemColors.Window;
                textBoxSpendStart.Text = "0.00";
            }
            else
            {
                textBoxSpendStart.Enabled = false;
                textBoxSpendStart.BackColor = SystemColors.Control;
                textBoxSpendStart.Text = string.Empty;
            }
        }

        private void comboBoxPoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPoints.SelectedIndex == 0)
            {
                textBoxPointsStart.Enabled = true;
                textBoxPointsStart.BackColor = SystemColors.Window;
                textBoxPointsStart.Text = "0.00";
            }
            else
            {
                textBoxPointsStart.Enabled = false;
                textBoxPointsStart.BackColor = SystemColors.Control;
                textBoxPointsStart.Text = string.Empty;
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
            ColorDialog frmColor = new ColorDialog { Color = cboColor.BackColor };
            if (frmColor.ShowDialog(this) == DialogResult.OK)
            {            
                    cboColor.BackColor = frmColor.Color;
                    cboColor.Invalidate();
            }
            frmColor.Dispose();
      
        }

        private void ClearALLError()
        {
            m_errorProvider.SetError(txtTierName, string.Empty);
            m_errorProvider.SetError(textBoxSpendStart, string.Empty);
            m_errorProvider.SetError(textBoxPointsStart, string.Empty);
            m_errorProvider.SetError(textBoxAwardPoints, string.Empty);
            m_errorProvider.SetError(comboBoxSpend, string.Empty);
        }

        private void NoChangeSetControl()
        {
            // MessageForm.Show("No changes made.");
            lbl_MessageSaved.Visible = true;
            if (colorListBoxTiers.Items.Count > 0)
            {
                imageButtonRemoveTier.Enabled = true;
                imageButtonEditTier.Enabled = true;
                imageButtonAddTier.Enabled = true;
                colorListBoxTiers.Enabled = true;
            }
            DisableControls();
            int Color_ = cboColor.BackColor.ToArgb();
            if (Color_ == -1)
            {
                cboColor.BackColor = SystemColors.Control;
            }
            imageButtonSave.Enabled = false;
            m_cancelButton.Enabled = false;
        }

        private void saveTier()
        {
            if (colorListBoxTiers.SelectedIndex != -1)
            {
                bool check = false;
                check = IstherAnyChangesmadeFromTheUser();
                if (check == false)
                {
                    // MessageForm.Show("No changes made.");
                    lbl_MessageSaved.Visible = true;
                    if (colorListBoxTiers.Items.Count > 0)
                    {
                        imageButtonRemoveTier.Enabled = true;
                        imageButtonEditTier.Enabled = true;
                        imageButtonAddTier.Enabled = true;
                        colorListBoxTiers.Enabled = true;
                    }
                    DisableControls();
                    int Color_ = cboColor.BackColor.ToArgb();
                    if (Color_ == -1)
                    {
                        cboColor.BackColor = SystemColors.Control;
                    }
                    imageButtonSave.Enabled = false;
                    m_cancelButton.Enabled = false;
                 
                    return;
                }
            }


            m_errorProvider.SetError(txtTierName, string.Empty);
            m_errorProvider.SetError(textBoxSpendStart, string.Empty);
            m_errorProvider.SetError(textBoxPointsStart, string.Empty);
            m_errorProvider.SetError(textBoxAwardPoints, string.Empty);
            m_errorProvider.SetError(comboBoxSpend, string.Empty);

            if (!ValidateChildren(ValidationConstraints.Enabled | ValidationConstraints.Visible))
                return;

            //bool QualifyingSpend = false;
            //if (Convert.ToString(comboBoxSpend.SelectedItem) == "Yes")
            //{ QualifyingSpend = true; }
            //else { QualifyingSpend = false; }

            //bool QualifyingPoints = false;
            //if (Convert.ToString(comboBoxPoints.SelectedItem) == "Yes")
            //{ QualifyingPoints = true; }
            //else { QualifyingPoints = false; }

            TierData Code1 = new TierData();

            if (m_TierID != 0)
            {
                Code1.TierID = m_TierID;
            }



            Code1.TierRulesID = GetPlayerTierRulesData.getPlayerTierRulesData.TierRulesID;//single row

            if (txtTierName.Text.Contains(" (default)"))
            {
                string Test = txtTierName.Text;
                Code1.TierName = txtTierName.Text.Replace(" (default)", "");
            }
            else
            {
                Code1.TierName = txtTierName.Text;
            }

            Code1.TierColor = cboColor.BackColor.ToArgb();
            if (textBoxSpendStart.Text != string.Empty)
            {
                Code1.AmntSpend = Convert.ToDecimal(textBoxSpendStart.Text);
            }
            else { Code1.AmntSpend = -1; } //= Convert.ToDecimal("0.00");}//send a negative value or empty string will work this afternoon
            if (textBoxPointsStart.Text != string.Empty)
            {
                Code1.NbrPoints = Convert.ToDecimal(textBoxPointsStart.Text);
            }
            else
            { Code1.NbrPoints = -1; }//Convert.ToDecimal("0.00");}

            if (textBoxAwardPoints.Text != string.Empty)
            {
                Code1.Multiplier = Convert.ToDecimal(textBoxAwardPoints.Text);
            }
            else
            { Code1.Multiplier = Convert.ToDecimal("0.00"); }//error provider -> will not allow you enter a empty string
            SetTiersData.tiersData = Code1;
            Code1.isdelete = false;
            int TierID = SetPlayerTierData.Save(Code1);//
            if (m_TierID == 0)
            {
                colorListBoxTiers.Items.Add(txtTierName.Text);
                Code1.TierID = TierID;
                GetPlayerTierData.getPlayerTierData.Add(Code1);
                cmbx_DefaultTier.Items.Add(txtTierName.Text);
                ClearTiersTab();
                DisableControls();
                int countItem = colorListBoxTiers.Items.Count;
                colorListBoxTiers.SelectedIndex = countItem - 1;

            }
            else if (m_TierID != 0)
            {
                int i = colorListBoxTiers.SelectedIndex;
              
                string x = colorListBoxTiers.SelectedItem.ToString();
                if (x.Contains(" (default)"))
                {
                    x = x.Replace(" (default)", "");
                    colorListBoxTiers.Items[i] = txtTierName.Text + " (default)";//rename
                }
                else
                {
                    colorListBoxTiers.Items[i] = txtTierName.Text;
                }

                int ii = cmbx_DefaultTier.Items.IndexOf(x);
                cmbx_DefaultTier.Items[ii] = txtTierName.Text;

                TierData a = GetPlayerTierData.getPlayerTierData.Single(l => l.TierName == x);
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

                    if (textBoxPointsStart.Text == string.Empty)
                    {
                        a.NbrPoints = -1;
                    }
                    else
                    {
                        a.NbrPoints = Convert.ToDecimal(textBoxPointsStart.Text);
                    }
                    // a.NbrPoints = Convert.ToDecimal(textBoxPointsStart.Text);
                }
            }
            lbl_MessageSaved.Visible = true;
            if (colorListBoxTiers.Items.Count > 0)
            {
                imageButtonRemoveTier.Enabled = true;
                imageButtonEditTier.Enabled = true;
                imageButtonAddTier.Enabled = true;
                colorListBoxTiers.Enabled = true;
            }

            imageButtonSave.Enabled = false;
            m_cancelButton.Enabled = false;
        }


        bool ContinueSave = false;
        TierData new_tierData;// = new TierData();
        TierData current_tierData;

        private void imageButtonSave_Click(object sender, EventArgs e)
        {
            ClearALLError();
            new_tierData = new TierData();      
            new_tierData.TierName = txtTierName.Text;
            new_tierData.TierColor = cboColor.BackColor.ToArgb();
            new_tierData.AmntSpend = (textBoxSpendStart.Text != string.Empty) ? Convert.ToDecimal(textBoxSpendStart.Text) : -1;
            new_tierData.NbrPoints = (textBoxPointsStart.Text != string.Empty) ? Convert.ToDecimal(textBoxPointsStart.Text) : -1;
            new_tierData.Multiplier = (textBoxAwardPoints.Text != string.Empty) ? Convert.ToDecimal(textBoxAwardPoints.Text) : Convert.ToDecimal("0.00");
            new_tierData.isdelete = false;
            new_tierData.TierID = (colorListBoxTiers.SelectedIndex != -1) ? m_TierID : 0;
            new_tierData.TierRulesID = GetPlayerTierRulesData.getPlayerTierRulesData.TierRulesID;
            current_tierData = new TierData();
            //UPDATE
            if (colorListBoxTiers.SelectedIndex != -1)//Existing Tier (update)
            {
                current_tierData = GetPlayerTierData.getPlayerTierData.Single(l => l.TierID == new_tierData.TierID);
                if (current_tierData.Equals(new_tierData))
                {
                    ContinueSave = false;
                    return;
                }
            }
            else if (colorListBoxTiers.SelectedIndex == -1)
            {
                new_tierData.TierID = 0;
               
            }

            //VALIDATE USER INPUT (check for Empty String)

           // var testr = !ValidateChildren(ValidationConstraints.Enabled | ValidationConstraints.Visible);

            if (!ValidateChildren(ValidationConstraints.Enabled | ValidationConstraints.Visible))
                return;

            int TierID = SetPlayerTierData.Save(new_tierData);//
            if (m_TierID == 0)
            {
                colorListBoxTiers.Items.Add(txtTierName.Text);
                new_tierData.TierID = TierID;
                GetPlayerTierData.getPlayerTierData.Add(new_tierData);
                cmbx_DefaultTier.Items.Add(txtTierName.Text);
                ClearTiersTab();
                DisableControls();
                int countItem = colorListBoxTiers.Items.Count;
                colorListBoxTiers.SelectedIndex = countItem - 1;

            }
            else if (m_TierID != 0)
            {
                int i = colorListBoxTiers.SelectedIndex;

                string x = colorListBoxTiers.SelectedItem.ToString();
                if (x.Contains(" (default)"))
                {
                    x = x.Replace(" (default)", "");
                    colorListBoxTiers.Items[i] = txtTierName.Text + " (default)";//rename
                }
                else
                {
                    colorListBoxTiers.Items[i] = txtTierName.Text;
                }

                int ii = cmbx_DefaultTier.Items.IndexOf(x);
                cmbx_DefaultTier.Items[ii] = txtTierName.Text;

                TierData a = GetPlayerTierData.getPlayerTierData.Single(l => l.TierName == x);
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

                    if (textBoxPointsStart.Text == string.Empty)
                    {
                        a.NbrPoints = -1;
                    }
                    else
                    {
                        a.NbrPoints = Convert.ToDecimal(textBoxPointsStart.Text);
                    }
                    // a.NbrPoints = Convert.ToDecimal(textBoxPointsStart.Text);
                }
            }
            lbl_MessageSaved.Visible = true;
            if (colorListBoxTiers.Items.Count > 0)
            {
                imageButtonRemoveTier.Enabled = true;
                imageButtonEditTier.Enabled = true;
                imageButtonAddTier.Enabled = true;
                colorListBoxTiers.Enabled = true;
            }

            imageButtonSave.Enabled = false;
            m_cancelButton.Enabled = false;

            //saveTier();
        }

        private void imageButton4_Click(object sender, EventArgs e)
        {
           

            m_errorProvider.SetError(dateTimePicker2, string.Empty);

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
            m_errorProvider.SetError(dateTimePicker2, string.Empty);



            if (!ValidateChildren(ValidationConstraints.Enabled | ValidationConstraints.Visible))
                return;

            int TierRuleID = GetPlayerTierRulesData.getPlayerTierRulesData.TierRulesID;
            TierRulesData code1 = new TierRulesData();
            code1.TierRulesID = TierRuleID;
            code1.QualifyingStartDate = DateTime.Parse(dateTimePicker2.Value.ToShortDateString());
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
                    var f = GetPlayerTierData.getPlayerTierData.Exists(p => p.TierName == DefaultTierName);
                    bool cc = f;

                    var DefaultTierID = GetPlayerTierData.getPlayerTierData.Where(l => l.TierName == DefaultTierName);
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

            SetPlayerTierRulesData.setPlayerTierRulesData = code1;
            GetPlayerTierRulesData.getPlayerTierRulesData = code1; //will replace the old 1 no need to clear it

            int x = SetPlayerTierRule.Save(code1);

            label4.Visible = true;
            imageButton4.Text = "&Edit";
            DisableContorls_TierRules();

            if (cmbx_DefaultTier.SelectedIndex != -1)
            {
                int n = -1;
                string o = "";
                foreach (string m in colorListBoxTiers.Items)
                {
                    if (m.Contains(" (default)"))
                    {
                        n = colorListBoxTiers.Items.IndexOf(m);
                        o = m.Replace(" (default)", "");

                    }
                }

                if (n != -1)
                {
                    colorListBoxTiers.Items[n] = o;
                }
                string items = cmbx_DefaultTier.SelectedItem.ToString();
                int index = colorListBoxTiers.Items.IndexOf(items);
                items = items + " (default)";
                colorListBoxTiers.Items[index] = items;

            }
        }

        private void colorListBoxTiers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearALLError();
            lbl_MessageSaved.Visible = false;
           
    

            if (colorListBoxTiers.SelectedIndex != -1)
            {

                object tiername = colorListBoxTiers.SelectedItem;
                string TierName = Convert.ToString(tiername);
                if (TierName.Contains(" (default)"))
                {
                    TierName = TierName.Replace(" (default)", string.Empty);
                }
                int TierID = 0;                         
                var z = GetPlayerTierData.getPlayerTierData.Where(l => l.TierName == TierName);
                foreach (var a in z)
                {
                    TierID = a.TierID;
                    m_TierID = a.TierID;
                   
                }

                if (m_TierID != 0)
                {
                    TierID = m_TierID;
                }

                List<TierData> DTierData = new List<TierData>();
                DTierData = GetPlayerTierDatam.getPlayertierData(TierID);

                foreach (TierData x in DTierData)
                {
                    txtTierName.Text = x.TierName;
                   // label2.Text = x.TierName;

                    cboColor.BackColor = Color.FromArgb(x.TierColor);
                    m_color = x.TierColor;
                    bool y = false;
                    int count = 0;

                    if (x.AmntSpend != -1)
                    {
                        comboBoxSpend.SelectedIndex = 0;
                        y = x.AmntSpend == (Int64)x.AmntSpend;//check if its a whole number or a decimal
                        if (y == true)
                        {
                            textBoxSpendStart.Text = Convert.ToString(x.AmntSpend) + ".00";
                        }
                        else
                        {
                            count = BitConverter.GetBytes(decimal.GetBits(x.AmntSpend)[3])[2];
                            //if its only have 1 decimal places then lets add 1 more
                            if (count == 1)
                            {
                                textBoxPointsStart.Text = Convert.ToString(x.AmntSpend) + "0";
                            }
                            //if its more than 2 then lets round it off
                            else if (count > 2)
                            {
                                textBoxPointsStart.Text = Math.Round(x.AmntSpend, 2).ToString();
                            }
                            else
                            {
                                textBoxPointsStart.Text = Convert.ToString(x.AmntSpend);
                            }
                        }
                    }
                    else { comboBoxSpend.SelectedIndex = 1;
                    textBoxSpendStart.Text = "";
                    }


                  
               
                    //string AmountSpend = Math.Round(double.Parse(x.AmntSpend.ToString()), 2).ToString();//= Convert.ToString(x.AmntSpend);
                    //textBoxSpendStart.Text = string.Format("{0:0.##}", AmountSpend); //Convert.ToString(x.AmntSpend);
                    //textBoxSpendStart.Text =  Math.Round(double.Parse(x.AmntSpend.ToString()), 2).ToString();

                 

                    if (x.NbrPoints != -1)
                    {
                        comboBoxPoints.SelectedIndex = 0;
                        y = x.NbrPoints == (Int64)x.NbrPoints;
                        if (y == true)
                        {
                            textBoxPointsStart.Text = Convert.ToString(x.NbrPoints) + ".00";
                        }
                        else
                        {
                            //lets check how many decimal places is being use?
                            count = BitConverter.GetBytes(decimal.GetBits(x.NbrPoints)[3])[2];
                            //if its only have 1 decimal places then lets add 1 more
                            if (count == 1)
                            {
                                textBoxPointsStart.Text = Convert.ToString(x.NbrPoints)+"0";
                            }
                                //if its more than 2 then lets round it off
                            else if (count > 2)
                            {
                                textBoxPointsStart.Text = Math.Round(x.NbrPoints, 2).ToString();
                            }
                            else
                            {
                                textBoxPointsStart.Text = Convert.ToString(x.NbrPoints);
                            }
                        }
                    }
                    else
                    {
                        comboBoxPoints.SelectedIndex = 1;//NO
                        textBoxPointsStart.Text = "";
                    }

                    


                    y = x.Multiplier == (Int64)x.Multiplier;
                    if (y == true)
                    {
                        textBoxAwardPoints.Text = Convert.ToString(x.Multiplier) + ".00";
                    }
                    else
                    {
                        count = BitConverter.GetBytes(decimal.GetBits(x.Multiplier)[3])[2];
                        //if its only have 1 decimal places then lets add 1 more
                        if (count == 1)
                        {
                            textBoxPointsStart.Text = Convert.ToString(x.Multiplier) + "0";
                        }
                        //if its more than 2 then lets round it off
                        else if (count > 2)
                        {
                            textBoxPointsStart.Text = Math.Round(x.Multiplier, 2).ToString();
                        }
                        else
                        {
                            textBoxPointsStart.Text = Convert.ToString(x.Multiplier);
                        }
                    }
                    
                }

                textBoxSpendStart.Enabled = false;
                textBoxPointsStart.Enabled = false;
                DisableControls();

                if (colorListBoxTiers.SelectedIndex != -1)
                {
                    imageButtonSave.Enabled = false;
                    m_cancelButton.Enabled = false;
                }
            }

            imageButtonEditTier.Enabled = true;
            imageButtonRemoveTier.Enabled = true;
            imageButtonAddTier.Enabled = true;
            //if its a default color then disable
           int Color_ = cboColor.BackColor.ToArgb();
            if (Color_ == -1)
            {
               cboColor.BackColor = SystemColors.Control;
            }



        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void imageButtonRemoveTier_Click(object sender, EventArgs e)
        {
            int CurrentIndex = colorListBoxTiers.SelectedIndex;
            string ItemSelected = colorListBoxTiers.SelectedItem.ToString();

            if (ItemSelected.Contains(" (default)"))
            {
                ItemSelected = ItemSelected.Replace(" (default)", string.Empty);
            }
   
            /*
            if (MessageForm.Show("You are about to delete this " + ItemSelected + " Tier. \nDo you want to continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {

            }*/

            if (MessageForm.Show("Are you sure you want to permanently delete this " + ItemSelected + " Tier." , "Player Loyalty", MessageFormTypes.YesNo) == DialogResult.No)
            {
                return;
            }


           // return MessageForm.Show(Resources.Changes, Resources.PlayerCenterName, MessageFormTypes.YesNo) == DialogResult.Yes;

            /*
            if (MessageBox.Show("You are about to delete this " + ItemSelected + " Tier. \nDo you want to continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)

            { return; }*/
 

            lbl_MessageSaved.Visible = false;
            
            TierData code1 = new TierData();
            code1.TierID = m_TierID;
            code1.TierRulesID = 0;
            code1.TierName = string.Empty;
            code1.TierColor = 0;
            code1.AmntSpend = 0;
            code1.NbrPoints = 0;
            code1.Multiplier = 0;
            code1.isdelete = true;
            SetPlayerTierData.Save(code1);
            
           
            colorListBoxTiers.Items.RemoveAt(CurrentIndex);

           
            CurrentIndex = cmbx_DefaultTier.Items.IndexOf(ItemSelected);
            cmbx_DefaultTier.Items.RemoveAt(CurrentIndex);

            GetPlayerTierData.getPlayerTierData.RemoveAll(i => i.TierID == m_TierID);
            GetPlayerTierRulesData.getPlayerTierRulesData.DefaultTierID = 0 ;
      
            colorListBoxTiers.SelectedIndex = -1; 
            ClearTiersTab();
            if (colorListBoxTiers.Items.Count == 0)
            {
                imageButtonRemoveTier.Enabled = false;
                imageButtonEditTier.Enabled = false;
                cboColor.BackColor = SystemColors.Control;
            }

            if (colorListBoxTiers.Items.Count > 0)
            {
                colorListBoxTiers.TopIndex = 0;
                colorListBoxTiers.SelectedIndex = 0;
            }
        }

        private void imageButtonEditTier_Click(object sender, EventArgs e)
        {
            imageButtonSave.Enabled = true;
            m_cancelButton.Enabled = true;
            imageButtonRemoveTier.Enabled = false;
            imageButtonAddTier.Enabled = false;


            lbl_MessageSaved.Visible = false;
            EnableControls();
            if (comboBoxSpend.SelectedIndex == 0)
            {
                textBoxSpendStart.Enabled = true;
                textBoxSpendStart.BackColor = SystemColors.Window;
            }
            else
            { textBoxSpendStart.Enabled = false;
            textBoxSpendStart.BackColor = SystemColors.Control;
            }

            if (comboBoxPoints.SelectedIndex == 0)
            {
                textBoxPointsStart.Enabled = true;
                textBoxPointsStart.BackColor = SystemColors.Window;
            }
            else 
            { textBoxPointsStart.Enabled = false;
            textBoxPointsStart.BackColor = SystemColors.Control;
            }


            if (m_color == -1)
            {
                cboColor.BackColor = Color.White;
            }
        }

        private void m_cancelButton_Click(object sender, EventArgs e)
        {
            lbl_MessageSaved.Visible = false;
            imageButtonAddTier.Enabled = true;

            ClearALLError();

            lbl_MessageSaved.Visible = false;
            colorListBoxTiers.SelectedIndex = -1;
            ClearTiersTab();
            comboBoxSpend.SelectedIndex = 1;
            comboBoxPoints.SelectedIndex = 1;

            //EnableControls();
            DisableControls();
            imageButtonEditTier.Enabled = false;
            imageButtonRemoveTier.Enabled = false;

            if (colorListBoxTiers.SelectedIndex == -1)
            {
                cboColor.BackColor = SystemColors.Control;
            }

            imageButtonSave.Enabled = false;
            colorListBoxTiers.SelectedIndex = 0; 

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                bool rulesChange = CheckChangesOnRules();
                if (rulesChange == true)
                {
                    TierRulesCancelButton();
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
                }
                else
                {
                    //MessageBox.Show("No changes found");
                    //set tab to default
                    //  tabControl1.SelectedTab = tabPage2;
                    //m_errorProvider.SetError(dateTimePicker2, string.Empty);
                    //lbl_MessageSaved.Visible = false;
                    //label4.Visible = false;

                }
            }



            m_errorProvider.SetError(dateTimePicker2, string.Empty);
            lbl_MessageSaved.Visible = false;
            label4.Visible = false;
        }

        private void imageButton3_Click(object sender, EventArgs e)
        {
            TierRulesCancelButton();
        }

        private void TierRulesCancelButton()
        {
            m_errorProvider.SetError(dateTimePicker2, string.Empty);
            label4.Visible = false;
            //DisplayPlayerRule();
            DisableContorls_TierRules();
            if (imageButton4.Text == "&Save")
            {
                imageButton4.Text = "&Edit";
            }

            DisplayPlayerRule();
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
                if (new_tierData.TierName == string.Empty)
                {
                  
                    m_errorProvider.SetError(txtTierName, "Please enter a Tier Name.");
                    e.Cancel = true;
                }

                bool itExists = false;
                if (colorListBoxTiers.SelectedIndex != -1)
                {
                    if (current_tierData.TierName != new_tierData.TierName)//Renaming existing tier. 
                    {
                        itExists = GetPlayerTierData.getPlayerTierData.Where(p => p.TierID != new_tierData.TierID).ToList().Exists(l => l.TierName.Equals(new_tierData.TierName, StringComparison.InvariantCultureIgnoreCase));
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                   itExists = GetPlayerTierData.getPlayerTierData.Exists(l => l.TierName.Equals(new_tierData.TierName, StringComparison.InvariantCultureIgnoreCase));
                
                }

                if (itExists)
                {
                    ContinueSave = false; //do not saved.
                    m_errorProvider.SetError(txtTierName, "Name already exists.");
                    e.Cancel = true;
                }

            }                                           
            catch
            {
                e.Cancel = true;
                m_errorProvider.SetError(txtTierName, "Check your input");
            }
        }


        private void textBoxSpendStart_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (comboBoxSpend.SelectedIndex == 0)//YES
                {
                    if (textBoxSpendStart.Text == string.Empty)
                    {
                        e.Cancel = true;
                        m_errorProvider.SetError(textBoxSpendStart, "Please enter a Spend start.");

                    }

                    decimal checkinput;
                    if (Decimal.TryParse(textBoxSpendStart.Text, out checkinput))//if its a decimal
                    {

                        bool itExists = false;
                        if (colorListBoxTiers.SelectedIndex != -1)
                        {

                            if (current_tierData.AmntSpend != new_tierData.AmntSpend)
                            {
                                itExists = GetPlayerTierData.getPlayerTierData.Where(p => p.TierID != new_tierData.TierID).ToList().Exists(l => l.AmntSpend.Equals(new_tierData.AmntSpend));
                            }
                            else
                            {
                                e.Cancel = true;
                            }
                        }
                        else
                        {
                            itExists = GetPlayerTierData.getPlayerTierData.Exists(l => l.AmntSpend.Equals(new_tierData.AmntSpend));

                        }


                        if (itExists)
                        {
                            e.Cancel = true;
                            m_errorProvider.SetError(textBoxSpendStart, "Spend amount is being used by another Tier");
                            return;
                        }

                    }
                    else
                    {
                        e.Cancel = true;
                        m_errorProvider.SetError(textBoxSpendStart, "Not a valid decimal number.");
                    }

                }
            }
            catch
            {
                e.Cancel = true;
                m_errorProvider.SetError(textBoxSpendStart, "Unknown error call Technician.");
            }
        }

        private void textBoxPointsStart_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (comboBoxPoints.SelectedIndex == 0)//YES
                {
                    if (textBoxPointsStart.Text == string.Empty)
                    {
                        e.Cancel = true;
                        m_errorProvider.SetError(textBoxPointsStart, "Please enter a point start.");

                    }


                    decimal checkinput;
                    if (Decimal.TryParse(textBoxPointsStart.Text, out checkinput))//if its a decimal
                    {

                        bool itExists = false;
                        if (colorListBoxTiers.SelectedIndex != -1)
                        {

                            if (current_tierData.NbrPoints != new_tierData.NbrPoints)
                            {
                                itExists = GetPlayerTierData.getPlayerTierData.Where(p => p.TierID != new_tierData.TierID).ToList().Exists(l => l.NbrPoints.Equals(new_tierData.NbrPoints));
                            }                                                     
                        }
                        else
                        {
                            itExists = GetPlayerTierData.getPlayerTierData.Exists(l => l.NbrPoints.Equals(new_tierData.NbrPoints));
                             
                        }


                        if (itExists)
                        {
                            e.Cancel = true;
                            m_errorProvider.SetError(textBoxPointsStart, "Point amount is being used by another Tier");
                            return;
                        }                   
                    }
                    else
                    {
                        e.Cancel = true;
                        m_errorProvider.SetError(textBoxPointsStart, "Not a valid decimal number.");
                    }
                }
            }
            catch
            {
                e.Cancel = true;
                m_errorProvider.SetError(textBoxPointsStart, "Unknown error call Technician.");
            }
        }

        private void textBoxAwardPoints_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (textBoxAwardPoints.Text == string.Empty)
                {
                    e.Cancel = true;
                    m_errorProvider.SetError(textBoxAwardPoints, "Please make an entry");
                }
            }
            catch
            {
                e.Cancel = true;
                   m_errorProvider.SetError(textBoxAwardPoints, "Please make an entry");
            }
        }

        private void comboBoxSpend_Validating(object sender, CancelEventArgs e)
        {
            if (comboBoxPoints.SelectedIndex == 1 && comboBoxSpend.SelectedIndex == 1)
            {
                e.Cancel = true;
                m_errorProvider.SetError(comboBoxSpend, "Atleast make one selection spend or points");
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
            m_errorProvider.SetError(dateTimePicker2, string.Empty);
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool CheckChangesOnRules()
        {
            bool YesorNo = false;

            DateTime NewQualifyingPeriodStart = Convert.ToDateTime(dateTimePicker2.Value);
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


            TierRulesData t = GetPlayerTierRulesData.getPlayerTierRulesData;
            string currentDefaultTier = "";
            if (t.DefaultTierID != 0)//error here
            {
                var lll = GetPlayerTierData.getPlayerTierData.Single(l => l.TierID == t.DefaultTierID);//(l => l.TierRulesID == t.DefaultTierID);
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
            string NewTierName = txtTierName.Text;

            int NewColor = cboColor.BackColor.ToArgb();
            //bool NewQualifyingSpend = false;
            //if (comboBoxSpend.SelectedIndex == 0)//true
            //{
            //    NewQualifyingSpend = true;
            //}
              decimal NewSpendStart = -1;
            if (textBoxSpendStart.Text != string.Empty)
            {
             NewSpendStart = Convert.ToDecimal(textBoxSpendStart.Text);

            }
            //bool NewQualifyingPoints = false;
            //if (comboBoxPoints.SelectedIndex == 0)
            //{
            //    NewQualifyingPoints = true;
            //}
            decimal NewPointStart = -1;//it means its null
            if (textBoxPointsStart.Text != string.Empty)
            {
                NewPointStart = Convert.ToDecimal(textBoxPointsStart.Text);
            }

            decimal NewAwardsMultiplier = 0;
            if (textBoxAwardPoints.Text != string.Empty)
            {
             NewAwardsMultiplier = Convert.ToDecimal(textBoxAwardPoints.Text);
            }




            string current_TierName = colorListBoxTiers.SelectedItem.ToString();
            if (current_TierName.Contains(" (default)"))
            {
                current_TierName = current_TierName.Replace(" (default)", "");

            }

            TierData a = GetPlayerTierData.getPlayerTierData.Single(l => l.TierName == current_TierName);

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
            bool v = (dateTimePicker1.Value < dateTimePicker2.Value);
            if (dateTimePicker1.Value < dateTimePicker2.Value)
            {
                e.Cancel = true;
                m_errorProvider.SetError(dateTimePicker2, "Qualify Period Start is after Qualifying Period End");//Resources.InvalidPlayerListLastVisit);
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

