using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GTI.Modules.Shared;

namespace GTI.Modules.PlayerCenter.UI
{
    public partial class PlayerGroupListEnterOrEdit : GradientForm
    {
        private int m_isNewOrEdit; //New = 1; Edit = 2
        private bool m_isAccept;
        private string m_ListName;

        public string ListName
        {
            get { return m_ListName; }
            set { m_ListName = value; }
        }

        public bool isAccept
        {
            get {return m_isAccept ;}
            set {m_isAccept = value;}
        }

        public int IsNewOrEdit
        {
            get { return m_isNewOrEdit; }
            set { m_isNewOrEdit = value; }
        }

        public PlayerGroupListEnterOrEdit()
        {
            InitializeComponent();
        }

        private void PlayerGroupListEnterOrEdit_Load(object sender, EventArgs e)
        {
            btnSaveList.Enabled = false;
            if (m_isNewOrEdit == 1)
            {
                //this.Text = "Enter a Name for this List:";
                this.Text = "New Player List";
                lblPlayerListName.Text = "Enter a name for this list";
            }
            else if (m_isNewOrEdit == 2)
            {
              //  this.Text = "Edit List Name";
                 this.Text = "Rename Player List";
                 lblPlayerListName.Text = "Enter a name for this list";
                txtbxDefinitionName.Text = m_ListName;
            }

            this.AcceptButton = btnSaveList;
            this.CancelButton = imgbtnCancel;

        }

        private void imgbtnCancel_Click(object sender, EventArgs e)
        {
            m_isAccept = false;
            this.Close();
        }

        private void btnSaveList_Click(object sender, EventArgs e)
        {
            m_ListName = txtbxDefinitionName.Text;
            m_isAccept = true;           
            this.Close();
        }

        /// <summary>
        /// Force user to enter a list name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtbxDefinitionName_Validating(object sender, CancelEventArgs e)
        {
            //if (string.IsNullOrEmpty(txtbxDefinitionName.Text))
            //{
            //    btnSaveList.Enabled = false;
            //}

        }

        private void txtbxDefinitionName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbxDefinitionName.Text))
            {
                if (btnSaveList.Enabled) btnSaveList.Enabled = false;
            }
            else
            {
                if (!btnSaveList.Enabled) btnSaveList.Enabled = true;
            }
        }




    }
}
