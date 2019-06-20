namespace GTI.Modules.PlayerCenter.UI
{
    partial class MCPFindPlayerForm
    {

        #region Controls

        private GTI.Controls.ImageButton m_searchButton;
        private GTI.Controls.ImageButton m_selectPlayerButton;
        private GTI.Controls.ImageButton m_cancelButton;
        private GTI.Controls.ImageButton m_searchByCardButton;

        #endregion

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MCPFindPlayerForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.m_txtbxSearchCategory = new System.Windows.Forms.TextBox();
            this.m_searchButton = new GTI.Controls.ImageButton();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.m_searchByCardButton = new GTI.Controls.ImageButton();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.m_selectPlayerButton = new GTI.Controls.ImageButton();
            this.m_cancelButton = new GTI.Controls.ImageButton();
            this.m_dgvResultsList = new System.Windows.Forms.DataGridView();
            this.PlayerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_clmnhdrFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_clmnhdrMiddleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_clmnhdrLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_clmnhdrMagCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_clmnhdrPlayerIdentity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvclmnBirthDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgvclmnLastVisitDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvResultsList)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer4
            // 
            this.splitContainer4.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.splitContainer4, "splitContainer4");
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.m_txtbxSearchCategory);
            this.splitContainer4.Panel1.Controls.Add(this.m_searchButton);
            // 
            // splitContainer4.Panel2
            // 
            resources.ApplyResources(this.splitContainer4.Panel2, "splitContainer4.Panel2");
            // 
            // m_txtbxSearchCategory
            // 
            this.m_txtbxSearchCategory.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.m_txtbxSearchCategory, "m_txtbxSearchCategory");
            this.m_txtbxSearchCategory.ForeColor = System.Drawing.Color.Black;
            this.m_txtbxSearchCategory.Name = "m_txtbxSearchCategory";
            this.m_txtbxSearchCategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtbxSearchCategory_KeyPress);
            // 
            // m_searchButton
            // 
            this.m_searchButton.BackColor = System.Drawing.Color.Transparent;
            this.m_searchButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_searchButton, "m_searchButton");
            this.m_searchButton.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_searchButton.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_searchButton.Name = "m_searchButton";
            this.m_searchButton.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_searchButton.UseVisualStyleBackColor = false;
            this.m_searchButton.Click += new System.EventHandler(this.SearchClick);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Name = "label1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.m_searchByCardButton);
            // 
            // m_searchByCardButton
            // 
            this.m_searchByCardButton.BackColor = System.Drawing.Color.Transparent;
            this.m_searchByCardButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_searchByCardButton, "m_searchByCardButton");
            this.m_searchByCardButton.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_searchByCardButton.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_searchByCardButton.Name = "m_searchByCardButton";
            this.m_searchByCardButton.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_searchByCardButton.UseVisualStyleBackColor = false;
            this.m_searchByCardButton.Click += new System.EventHandler(this.SearchByCardClick);
            // 
            // splitContainer3
            // 
            resources.ApplyResources(this.splitContainer3, "splitContainer3");
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.m_selectPlayerButton);
            this.splitContainer3.Panel2.Controls.Add(this.m_cancelButton);
            // 
            // m_selectPlayerButton
            // 
            this.m_selectPlayerButton.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.m_selectPlayerButton, "m_selectPlayerButton");
            this.m_selectPlayerButton.FocusColor = System.Drawing.Color.Black;
            this.m_selectPlayerButton.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_selectPlayerButton.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_selectPlayerButton.Name = "m_selectPlayerButton";
            this.m_selectPlayerButton.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_selectPlayerButton.UseVisualStyleBackColor = false;
            this.m_selectPlayerButton.Click += new System.EventHandler(this.SelectPlayerClick);
            // 
            // m_cancelButton
            // 
            this.m_cancelButton.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.m_cancelButton, "m_cancelButton");
            this.m_cancelButton.FocusColor = System.Drawing.Color.Black;
            this.m_cancelButton.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_cancelButton.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_cancelButton.Name = "m_cancelButton";
            this.m_cancelButton.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_cancelButton.UseVisualStyleBackColor = false;
            this.m_cancelButton.Click += new System.EventHandler(this.CancelClick);
            // 
            // m_dgvResultsList
            // 
            this.m_dgvResultsList.AllowUserToAddRows = false;
            this.m_dgvResultsList.AllowUserToDeleteRows = false;
            this.m_dgvResultsList.AllowUserToResizeColumns = false;
            this.m_dgvResultsList.AllowUserToResizeRows = false;
            this.m_dgvResultsList.BackgroundColor = System.Drawing.Color.White;
            this.m_dgvResultsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_dgvResultsList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgvResultsList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgvResultsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvResultsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlayerId,
            this.m_clmnhdrFirstName,
            this.m_clmnhdrMiddleName,
            this.m_clmnhdrLastName,
            this.m_clmnhdrMagCard,
            this.m_clmnhdrPlayerIdentity,
            this.m_dgvclmnBirthDay,
            this.m_dgvclmnLastVisitDate});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgvResultsList.DefaultCellStyle = dataGridViewCellStyle4;
            this.m_dgvResultsList.GridColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.m_dgvResultsList, "m_dgvResultsList");
            this.m_dgvResultsList.MultiSelect = false;
            this.m_dgvResultsList.Name = "m_dgvResultsList";
            this.m_dgvResultsList.ReadOnly = true;
            this.m_dgvResultsList.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.m_dgvResultsList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.m_dgvResultsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvResultsList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvResultsList_CellContentClick);
            this.m_dgvResultsList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvResultsList_CellDoubleClick);
            this.m_dgvResultsList.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dgvResultsList_ColumnHeaderMouseClick);
            this.m_dgvResultsList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_dgvResultsList_KeyDown);
            this.m_dgvResultsList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_dgvResultsList_KeyPress);
            this.m_dgvResultsList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_dgvResultsList_KeyUp);
            // 
            // PlayerId
            // 
            this.PlayerId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PlayerId.DataPropertyName = "Id";
            resources.ApplyResources(this.PlayerId, "PlayerId");
            this.PlayerId.Name = "PlayerId";
            this.PlayerId.ReadOnly = true;
            this.PlayerId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PlayerId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // m_clmnhdrFirstName
            // 
            this.m_clmnhdrFirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.m_clmnhdrFirstName.DataPropertyName = "FirstName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.m_clmnhdrFirstName.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.m_clmnhdrFirstName, "m_clmnhdrFirstName");
            this.m_clmnhdrFirstName.Name = "m_clmnhdrFirstName";
            this.m_clmnhdrFirstName.ReadOnly = true;
            this.m_clmnhdrFirstName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // m_clmnhdrMiddleName
            // 
            this.m_clmnhdrMiddleName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.m_clmnhdrMiddleName.DataPropertyName = "MiddleInitial";
            resources.ApplyResources(this.m_clmnhdrMiddleName, "m_clmnhdrMiddleName");
            this.m_clmnhdrMiddleName.MaxInputLength = 4;
            this.m_clmnhdrMiddleName.Name = "m_clmnhdrMiddleName";
            this.m_clmnhdrMiddleName.ReadOnly = true;
            this.m_clmnhdrMiddleName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // m_clmnhdrLastName
            // 
            this.m_clmnhdrLastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.m_clmnhdrLastName.DataPropertyName = "LastName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.m_clmnhdrLastName.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.m_clmnhdrLastName, "m_clmnhdrLastName");
            this.m_clmnhdrLastName.Name = "m_clmnhdrLastName";
            this.m_clmnhdrLastName.ReadOnly = true;
            this.m_clmnhdrLastName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // m_clmnhdrMagCard
            // 
            this.m_clmnhdrMagCard.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.m_clmnhdrMagCard.DataPropertyName = "MagCard";
            resources.ApplyResources(this.m_clmnhdrMagCard, "m_clmnhdrMagCard");
            this.m_clmnhdrMagCard.Name = "m_clmnhdrMagCard";
            this.m_clmnhdrMagCard.ReadOnly = true;
            this.m_clmnhdrMagCard.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // m_clmnhdrPlayerIdentity
            // 
            this.m_clmnhdrPlayerIdentity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.m_clmnhdrPlayerIdentity.DataPropertyName = "PlayerIdentity";
            resources.ApplyResources(this.m_clmnhdrPlayerIdentity, "m_clmnhdrPlayerIdentity");
            this.m_clmnhdrPlayerIdentity.Name = "m_clmnhdrPlayerIdentity";
            this.m_clmnhdrPlayerIdentity.ReadOnly = true;
            this.m_clmnhdrPlayerIdentity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // m_dgvclmnBirthDay
            // 
            this.m_dgvclmnBirthDay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.m_dgvclmnBirthDay.DataPropertyName = "BirthDate";
            resources.ApplyResources(this.m_dgvclmnBirthDay, "m_dgvclmnBirthDay");
            this.m_dgvclmnBirthDay.Name = "m_dgvclmnBirthDay";
            this.m_dgvclmnBirthDay.ReadOnly = true;
            this.m_dgvclmnBirthDay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // m_dgvclmnLastVisitDate
            // 
            this.m_dgvclmnLastVisitDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.m_dgvclmnLastVisitDate.DataPropertyName = "LastVisitDate";
            resources.ApplyResources(this.m_dgvclmnLastVisitDate, "m_dgvclmnLastVisitDate");
            this.m_dgvclmnLastVisitDate.Name = "m_dgvclmnLastVisitDate";
            this.m_dgvclmnLastVisitDate.ReadOnly = true;
            this.m_dgvclmnLastVisitDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // MCPFindPlayerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.m_dgvResultsList);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MCPFindPlayerForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Shown += new System.EventHandler(this.MCPFindPlayerForm_Shown);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvResultsList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.DataGridView m_dgvResultsList;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_txtbxSearchCategory;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_clmnhdrFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_clmnhdrMiddleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_clmnhdrLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_clmnhdrMagCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_clmnhdrPlayerIdentity;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvclmnBirthDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_dgvclmnLastVisitDate;

       
    }
}