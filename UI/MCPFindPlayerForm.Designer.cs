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
            this.m_searchButton = new GTI.Controls.ImageButton();
            this.label1 = new System.Windows.Forms.Label();
            this.m_searchByCardButton = new GTI.Controls.ImageButton();
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
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtbxLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtbxFirstName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtbxMagCard = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvResultsList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            // m_selectPlayerButton
            // 
            this.m_selectPlayerButton.BackColor = System.Drawing.Color.Transparent;
            this.m_selectPlayerButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_selectPlayerButton, "m_selectPlayerButton");
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
            this.m_cancelButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_cancelButton, "m_cancelButton");
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
            this.PlayerId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PlayerId.DataPropertyName = "Id";
            resources.ApplyResources(this.PlayerId, "PlayerId");
            this.PlayerId.Name = "PlayerId";
            this.PlayerId.ReadOnly = true;
            this.PlayerId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PlayerId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // m_clmnhdrFirstName
            // 
            this.m_clmnhdrFirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
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
            this.m_clmnhdrMiddleName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.m_clmnhdrMiddleName.DataPropertyName = "MiddleInitial";
            resources.ApplyResources(this.m_clmnhdrMiddleName, "m_clmnhdrMiddleName");
            this.m_clmnhdrMiddleName.MaxInputLength = 4;
            this.m_clmnhdrMiddleName.Name = "m_clmnhdrMiddleName";
            this.m_clmnhdrMiddleName.ReadOnly = true;
            this.m_clmnhdrMiddleName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // m_clmnhdrLastName
            // 
            this.m_clmnhdrLastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
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
            this.m_clmnhdrMagCard.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.m_clmnhdrMagCard.DataPropertyName = "MagCard";
            resources.ApplyResources(this.m_clmnhdrMagCard, "m_clmnhdrMagCard");
            this.m_clmnhdrMagCard.Name = "m_clmnhdrMagCard";
            this.m_clmnhdrMagCard.ReadOnly = true;
            this.m_clmnhdrMagCard.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // m_clmnhdrPlayerIdentity
            // 
            this.m_clmnhdrPlayerIdentity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.m_clmnhdrPlayerIdentity.DataPropertyName = "PlayerIdentity";
            resources.ApplyResources(this.m_clmnhdrPlayerIdentity, "m_clmnhdrPlayerIdentity");
            this.m_clmnhdrPlayerIdentity.Name = "m_clmnhdrPlayerIdentity";
            this.m_clmnhdrPlayerIdentity.ReadOnly = true;
            this.m_clmnhdrPlayerIdentity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // m_dgvclmnBirthDay
            // 
            this.m_dgvclmnBirthDay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.m_dgvclmnBirthDay.DataPropertyName = "BirthDate";
            resources.ApplyResources(this.m_dgvclmnBirthDay, "m_dgvclmnBirthDay");
            this.m_dgvclmnBirthDay.Name = "m_dgvclmnBirthDay";
            this.m_dgvclmnBirthDay.ReadOnly = true;
            this.m_dgvclmnBirthDay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // m_dgvclmnLastVisitDate
            // 
            this.m_dgvclmnLastVisitDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.m_dgvclmnLastVisitDate.DataPropertyName = "LastVisitDate";
            resources.ApplyResources(this.m_dgvclmnLastVisitDate, "m_dgvclmnLastVisitDate");
            this.m_dgvclmnLastVisitDate.Name = "m_dgvclmnLastVisitDate";
            this.m_dgvclmnLastVisitDate.ReadOnly = true;
            this.m_dgvclmnLastVisitDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // m_txtbxLastName
            // 
            resources.ApplyResources(this.m_txtbxLastName, "m_txtbxLastName");
            this.m_txtbxLastName.Name = "m_txtbxLastName";
            this.m_txtbxLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtbx_KeyPressEnter);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // m_txtbxFirstName
            // 
            resources.ApplyResources(this.m_txtbxFirstName, "m_txtbxFirstName");
            this.m_txtbxFirstName.Name = "m_txtbxFirstName";
            this.m_txtbxFirstName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtbx_KeyPressEnter);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // m_txtbxMagCard
            // 
            resources.ApplyResources(this.m_txtbxMagCard, "m_txtbxMagCard");
            this.m_txtbxMagCard.Name = "m_txtbxMagCard";
            this.m_txtbxMagCard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtbx_KeyPressEnter);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.m_txtbxMagCard);
            this.groupBox1.Controls.Add(this.m_searchButton);
            this.groupBox1.Controls.Add(this.m_txtbxLastName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.m_txtbxFirstName);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // MCPFindPlayerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.m_cancelButton);
            this.Controls.Add(this.m_selectPlayerButton);
            this.Controls.Add(this.m_searchByCardButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_dgvResultsList);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MCPFindPlayerForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Shown += new System.EventHandler(this.MCPFindPlayerForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvResultsList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.DataGridView m_dgvResultsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_txtbxLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox m_txtbxFirstName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox m_txtbxMagCard;
        private System.Windows.Forms.GroupBox groupBox1;
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