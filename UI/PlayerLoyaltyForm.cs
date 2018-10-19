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

namespace GTI.Modules.PlayerCenter.UI
{
    public partial class PlayerLoyaltyForm : GradientForm
    {

        //private string[] ColorNames;

        public PlayerLoyaltyForm()
        {
            InitializeComponent();
           // cmbc_Color.Text = string.Empty;
            comboBoxSpend.SelectedIndex = 1;
            comboBoxPoints.SelectedIndex = 1;
         //   LoadColorNames();

            //Let us remove all hardcoded data
            cmbx_DefaultTier.Items.Clear();
            colorListBoxTiers.Items.Clear();
            dateTimePicker1.Value = DateTime.Now.AddYears(1); //Let us set to default first display.
           // GetPlayerTierRulesDatam.GetPlayerTierRules();

           
           // int checkTierRulesID = GetPlayerTierRulesData.getPlayerTierRulesData.TierRulesID; //if its 0 the it means null
                     
            //if (checkTierRulesID != 0)
            //{
            //    dateTimePicker2.Value = GetPlayerTierRulesData.getPlayerTierRulesData.QualifyingStartDate;
            //    dateTimePicker1.Value = GetPlayerTierRulesData.getPlayerTierRulesData.QualifyingEndDate;

            //    int checkDefaultTier = GetPlayerTierRulesData.getPlayerTierRulesData.DefaultTierID;
            //    //will work on this later on


            //    bool x = GetPlayerTierRulesData.getPlayerTierRulesData.DowngradeToDefault;//its false

            //    if (x == false)
            //    {
            //        comboBoxRestart.SelectedIndex = 1;
            //    }
            //    else
            //    {
            //        comboBoxRestart.SelectedIndex = 0;
            //    }


            //}


        }

        private void imageButtonAddTier_Click(object sender, EventArgs e)
        {
            ClearTiersTab();
        }

        private void ClearTiersTab()
        {
            txtTierName.Text = "";
          //  textBoxColor.Text = "";
            comboBoxSpend.SelectedIndex = 1;
            textBoxSpendStart.Text = "";
            comboBoxPoints.SelectedIndex = 1;
            textBoxPointsStart.Text = "";
            textBoxAwardPoints.Text = "0.00";
        }

        private void comboBoxSpend_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSpend.SelectedIndex == 0)
            {
                textBoxSpendStart.Enabled = true;
            }
            else
            {
                textBoxSpendStart.Enabled = false;
            }

        }

        private void comboBoxPoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPoints.SelectedIndex == 0)
            {
                textBoxPointsStart.Enabled = true;
            }
            else
            {
                textBoxPointsStart.Enabled = false;
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

        private void imageButtonSave_Click(object sender, EventArgs e)
        {
            //bool QualifyingSpend = false;
            //if (Convert.ToString(comboBoxSpend.SelectedItem) == "Yes")
            //{ QualifyingSpend = true; }
            //else { QualifyingSpend = false; }

            //bool QualifyingPoints = false;
            //if (Convert.ToString(comboBoxPoints.SelectedItem) == "Yes")
            //{ QualifyingPoints = true; }
            //else { QualifyingPoints = false; }

            //TiersData Code1 = new TiersData();
            //Code1.TiersName = txtTierName.Text;
            //Code1.TColor = cboColor.BackColor.ToArgb();//int a = cboColor.BackColor.ToArgb();
            //Code1.TQualifyingSpend = QualifyingSpend; /*Convert.ToBoolean(comboBoxSpend.SelectedItem);*/
            //Code1.TSpendStart = Convert.ToDecimal(textBoxSpendStart.Text);
            //Code1.TQualifyingPoints = QualifyingPoints; /*Convert.ToBoolean(comboBoxPoints.SelectedText);*/
            //Code1.TPoinStart = Convert.ToDecimal(textBoxPointsStart.Text);
            //Code1.TAwardsPointMultiplier = Convert.ToDecimal(textBoxAwardPoints.Text);
            //SetTiersData.tiersData = Code1;

        }

        private void imageButton4_Click(object sender, EventArgs e)
        {   //we have to get the data first
            SetPlayerTierRulesData code1 = new SetPlayerTierRulesData();
            
              


        }


  
                    
    }
   
}
