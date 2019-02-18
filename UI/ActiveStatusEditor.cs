using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GTI.Modules.PlayerCenter.Business;
using GTI.Modules.PlayerCenter.Data;
using GTI.Modules.PlayerCenter.Properties;
using GTI.Modules.Shared;

namespace GTI.Modules.PlayerCenter.UI
{
    public partial class ActiveStatusEditor : GradientForm
    {
        // FIX: TA4069 - Change how Player Statuses work in stand-alone Player Center.
        private const string UnNamed = "(Unnamed)";

        private List<ExtendedStatus> workList;

        public ActiveStatusEditor(int operatorId)
        {
            InitializeComponent();
            OperatorId = operatorId;
        }

        private int OperatorId { get; set; }

        private void ActiveStatusEditor_Load(object sender, EventArgs e)
        {
            workList = new List<ExtendedStatus>();
            workList.Clear();
            foreach (PlayerStatus status in PlayerManager.OperatorPlayerStatusList)
            {
                string name = (string.IsNullOrEmpty(status.Name)) ? UnNamed : status.Name;
                workList.Add(new ExtendedStatus
                             {
                                 Id = status.Id,
                                 IsAlert = status.IsAlert,
                                 IsNew = false,
                                 IsActive = status.IsActive,
                                 Name = name,
                                 OrigName = name,
                                 OrigAlert = status.IsAlert,
                                 OrigActive = status.IsActive,
                                 OrigIsBannedstring = status.Banned_string,
                                 IsBannedstring = status.Banned_string,
                                 OrigIsBannedbool = status.Banned,
                                 IsBannedbool = status.Banned

                             });
            }

            LoadListBox(-1);
        }

        private void LoadListBox(int index)
        {
            listViewStatus.Items.Clear();
            foreach (ExtendedStatus status in workList)
            {
                if (!string.IsNullOrEmpty(status.Name))
                {
                    ListViewItem lvi = new ListViewItem() { Checked = status.IsAlert,  Tag = status};
                    lvi.SubItems.Add(status.Name);
                    lvi.SubItems.Add(status.IsBannedstring); 

                    listViewStatus.Items.Add(lvi);
                    lvi.ForeColor = (status.IsActive) ? SystemColors.WindowText : SystemColors.GrayText;
                }
            }
            if (index > -1)
            {
                listViewStatus.EnsureVisible(index);
                listViewStatus.Items[index].Selected = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ExtendedStatus status = new ExtendedStatus {IsNew = true, IsActive = true, Name = UnNamed, OrigName = UnNamed};

            // FIX: DE2791 - Add new player status loses status name if New isn't pressed or a row isn't highlighted.
            if(listViewStatus.SelectedItems.Count == 0 && !string.IsNullOrEmpty(textBoxName.Text))
            status.Name = textBoxName.Text;
            status.IsBannedbool = chkbxBanned.Checked;
            status.IsBannedstring = chkbxBanned.Checked == true ? "TRUE" : "FALSE";

            workList.Add(status);
            LoadListBox(-1);

            listViewStatus.Items[listViewStatus.Items.Count - 1].Selected = true;

            // END: DE2791
            textBoxName.SelectAll();
            textBoxName.Focus();
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            if (listViewStatus.SelectedItems.Count > 0)
            {
                ListViewItem lvi = listViewStatus.SelectedItems[0];
                ExtendedStatus es = (ExtendedStatus)lvi.Tag;
                es.IsActive = !es.IsActive;
                LoadListBox(listViewStatus.SelectedIndices[0]);
                btnActive.Text = es.IsActive ? Resources.Deactivate : Resources.Activate;
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (listViewStatus.SelectedItems.Count > 0)
            {
                ListViewItem lvi = listViewStatus.SelectedItems[0];
                lvi.SubItems[1].Text = textBoxName.Text;
                ((ExtendedStatus)lvi.Tag).Name = textBoxName.Text;
            }
            textBoxName.Focus();
        }

        private void listViewStatus_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem lvi = e.Item;
            ((ExtendedStatus)lvi.Tag).IsAlert = lvi.Checked;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            foreach (ExtendedStatus status in workList)
            {
                if (status.Name.Equals(UnNamed) && status.IsActive)
                {
                    MessageForm.Show(this, Resources.UnnamedStatusEntries);
                    return;
                }
            }
            foreach (ExtendedStatus status in workList)
            {
                if (status.IsNew && !status.IsActive) continue;
                if (status.IsNew) status.Id = 0;
                PlayerStatus ps = new PlayerStatus
                                  {
                                      Id = status.Id,
                                      IsActive = status.IsActive,
                                      IsAlert = status.IsAlert,
                                      Banned = status.IsBannedbool,
                                      Name = status.Name
                                  };
                try
                {
                    SetOperatorPlayerStatus.Save(OperatorId, ps);
                }
                catch(Exception ex)
                {
                    MessageForm.Show(this, ex.Message);
                }
            }
            PlayerManager.GetStatusCode();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void listViewStatus_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                textBoxName.Text = e.Item.SubItems[1].Text;
                ExtendedStatus es = (ExtendedStatus)e.Item.Tag;
                chkbxBanned.Checked = es.IsBannedbool;
                btnActive.Text = es.IsActive ? Resources.Deactivate : Resources.Activate;
                btnActive.Enabled = true;
            }
            else
            {
                btnActive.Enabled = false;
                textBoxName.Text = string.Empty;
            }
        }

        private void listViewStatus_MouseUp(object sender, MouseEventArgs e)
        {
            // Ensure the textbox has the focus.
            textBoxName.Focus();
            textBoxName.SelectAll();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (listViewStatus.SelectedItems.Count > 0)
            {
                ListViewItem lvi = listViewStatus.SelectedItems[0];
                lvi.SubItems[1].Text = ((ExtendedStatus)lvi.Tag).OrigName;
                textBoxName.Text = ((ExtendedStatus)lvi.Tag).OrigName;
                lvi.Checked = ((ExtendedStatus)lvi.Tag).OrigAlert;
                chkbxBanned.Checked = ((ExtendedStatus)lvi.Tag).OrigIsBannedbool;
                textBoxName.Select(textBoxName.Text.Length, 0);
            }
        }

        #region Nested type: ExtendedStatus
        public class ExtendedStatus
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool IsAlert { get; set; }
            public bool IsNew { get; set; }
            public bool IsActive { get; set; }
            public string OrigName { get; set; }
            public bool OrigAlert { get; set; }
            public bool OrigActive { get; set; }
            public string IsBannedstring { get; set; }
            public string OrigIsBannedstring { get; set; }
            public bool IsBannedbool { get; set; }
            public bool OrigIsBannedbool { get; set; }
        }
        #endregion

        private void chkbxBanned_CheckedChanged(object sender, EventArgs e)
        {
            if (listViewStatus.SelectedItems.Count > 0)
            {
                ListViewItem lvi = listViewStatus.SelectedItems[0];
                lvi.SubItems[2].Text = chkbxBanned.Checked == true ? "TRUE" : "FALSE";
                ((ExtendedStatus)lvi.Tag).IsBannedstring = chkbxBanned.Checked == true ? "TRUE" : "FALSE";
                ((ExtendedStatus)lvi.Tag).IsBannedbool = chkbxBanned.Checked;
            }
            chkbxBanned.Focus();   
        }
    }
}