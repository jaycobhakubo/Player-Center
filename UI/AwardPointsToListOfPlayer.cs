#region Copyright
// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2008 GameTech
// International, Inc.
#endregion


using System;
using System.Drawing;
using System.Windows.Forms;
using GTI.Modules.PlayerCenter.Business;
using GTI.Modules.Shared;
using GTI.Modules.PlayerCenter.Properties;
using GTI.Modules.PlayerCenter.Data;
using System.Globalization;


namespace GTI.Modules.PlayerCenter.UI
{
   partial class AwardPointsToListOfPlayer : GradientForm
   {
       protected string m_reason = string.Empty;

       public AwardPointsToListOfPlayer(string listName)
        {
           InitializeComponent();

           lblPlayerNameIndicator.Text = listName;
        }

       private void acceptImageButton_Click(object sender, EventArgs e)
       {
           IsAwardPoints = true;
           PointsAwardedValue = 0M;
           var tempManualPlayerPoints = txtbxPointsAwarded.Text;
           PointsAwardedValue = decimal.Parse(tempManualPlayerPoints, CultureInfo.InvariantCulture);
           m_reason = txtManualPointAdjustReason.Text;
           DialogResult = DialogResult.OK;
           Close();
       }

       private void cancelImageButton_Click(object sender, EventArgs e)
       {
           DialogResult = DialogResult.Cancel;
           Close();
       }

       public bool IsAwardPoints { get; set; }
       public decimal PointsAwardedValue { get; set; }
       public string ReasonPointsWereAwarded
       {
           get
           {
               return m_reason;
           }
       }

       private void txtManualPointAdjustReason_TextChanged(object sender, EventArgs e)
       {
           lblManualPointsAdjustReasonCharactersLeft.Text = (txtManualPointAdjustReason.MaxLength - txtManualPointAdjustReason.TextLength).ToString();

           decimal value;

           if (
               (!string.IsNullOrWhiteSpace(txtbxPointsAwarded.Text) && decimal.TryParse(txtbxPointsAwarded.Text, out value) && value != 0)
                 &&
                (!string.IsNullOrWhiteSpace(txtManualPointAdjustReason.Text) && decimal.TryParse(txtbxPointsAwarded.Text, out value) && value != 0)
               )
               acceptImageButton.Enabled = true;
           else
               acceptImageButton.Enabled = false;
       }

       private void txtbxPointsAwarded_TextChanged(object sender, EventArgs e)
       {
           decimal value;

           if (
               (!string.IsNullOrWhiteSpace(txtbxPointsAwarded.Text) && decimal.TryParse(txtbxPointsAwarded.Text, out value) && value != 0)
                 &&
                (!string.IsNullOrWhiteSpace(txtManualPointAdjustReason.Text) && decimal.TryParse(txtbxPointsAwarded.Text, out value) && value != 0)
               )
               acceptImageButton.Enabled = true;
           else
               acceptImageButton.Enabled = false;
       }

       protected override bool ProcessDialogKey(Keys keyData)
       {
           if (keyData == Keys.Return)
               return true;

           return base.ProcessDialogKey(keyData);
       }
       
       private void txtbxPointsAwarded_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
       {
           if (e.KeyCode == Keys.Return)
           {
               txtManualPointAdjustReason.Focus();
               return;
           }
       }
    }
}




