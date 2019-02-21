namespace GTI.Modules.PlayerCenter.UI
{
    partial class MCPFindPlayerForm
    {

        #region Controls

        private System.Windows.Forms.TextBox m_firstName;
        private System.Windows.Forms.TextBox m_lastName;
        private GTI.Controls.ImageButton m_searchButton;
        private System.Windows.Forms.ListBox m_resultsList;
        private GTI.Controls.ImageButton m_selectPlayerButton;
        private GTI.Controls.ImageButton m_cancelButton;
        private GTI.Controls.ImageButton m_searchByCardButton;
        private System.Windows.Forms.Label m_firstNameLabel;
        private System.Windows.Forms.Label m_lastNameLabel;



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
            this.m_lastNameLabel = new System.Windows.Forms.Label();
            this.m_firstNameLabel = new System.Windows.Forms.Label();
            this.m_lastName = new System.Windows.Forms.TextBox();
            this.m_firstName = new System.Windows.Forms.TextBox();
            this.m_searchByCardButton = new GTI.Controls.ImageButton();
            this.m_cancelButton = new GTI.Controls.ImageButton();
            this.m_selectPlayerButton = new GTI.Controls.ImageButton();
            this.m_resultsList = new System.Windows.Forms.ListBox();
            this.m_searchButton = new GTI.Controls.ImageButton();
            this.m_dgvResultsList = new System.Windows.Forms.DataGridView();
            this.m_clmnhdrFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_clmnhdrLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvResultsList)).BeginInit();
            this.SuspendLayout();
            // 
            // m_lastNameLabel
            // 
            resources.ApplyResources(this.m_lastNameLabel, "m_lastNameLabel");
            this.m_lastNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.m_lastNameLabel.ForeColor = System.Drawing.Color.Black;
            this.m_lastNameLabel.Name = "m_lastNameLabel";
            // 
            // m_firstNameLabel
            // 
            resources.ApplyResources(this.m_firstNameLabel, "m_firstNameLabel");
            this.m_firstNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.m_firstNameLabel.ForeColor = System.Drawing.Color.Black;
            this.m_firstNameLabel.Name = "m_firstNameLabel";
            // 
            // m_lastName
            // 
            this.m_lastName.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.m_lastName, "m_lastName");
            this.m_lastName.ForeColor = System.Drawing.Color.Black;
            this.m_lastName.Name = "m_lastName";
            this.m_lastName.Enter += new System.EventHandler(this.FocusChanged);
            this.m_lastName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NameKeyDown);
            // 
            // m_firstName
            // 
            this.m_firstName.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.m_firstName, "m_firstName");
            this.m_firstName.ForeColor = System.Drawing.Color.Black;
            this.m_firstName.Name = "m_firstName";
            this.m_firstName.Enter += new System.EventHandler(this.FocusChanged);
            this.m_firstName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NameKeyDown);
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
            // m_resultsList
            // 
            this.m_resultsList.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.m_resultsList, "m_resultsList");
            this.m_resultsList.ForeColor = System.Drawing.Color.Black;
            this.m_resultsList.FormattingEnabled = true;
            this.m_resultsList.Name = "m_resultsList";
            this.m_resultsList.DoubleClick += new System.EventHandler(this.PlayerResultsDoubleClick);
            this.m_resultsList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PlayerResultsEnter);
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
            this.m_clmnhdrFirstName,
            this.m_clmnhdrLastName});
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
            this.m_dgvResultsList.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.m_dgvResultsList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.m_dgvResultsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // m_clmnhdrFirstName
            // 
            this.m_clmnhdrFirstName.DataPropertyName = "FirstName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.m_clmnhdrFirstName.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.m_clmnhdrFirstName, "m_clmnhdrFirstName");
            this.m_clmnhdrFirstName.Name = "m_clmnhdrFirstName";
            // 
            // m_clmnhdrLastName
            // 
            this.m_clmnhdrLastName.DataPropertyName = "LastName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.m_clmnhdrLastName.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.m_clmnhdrLastName, "m_clmnhdrLastName");
            this.m_clmnhdrLastName.Name = "m_clmnhdrLastName";
            // 
            // MCPFindPlayerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.m_dgvResultsList);
            this.Controls.Add(this.m_lastNameLabel);
            this.Controls.Add(this.m_firstNameLabel);
            this.Controls.Add(this.m_searchByCardButton);
            this.Controls.Add(this.m_cancelButton);
            this.Controls.Add(this.m_selectPlayerButton);
            this.Controls.Add(this.m_resultsList);
            this.Controls.Add(this.m_searchButton);
            this.Controls.Add(this.m_lastName);
            this.Controls.Add(this.m_firstName);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MCPFindPlayerForm";
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvResultsList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.DataGridView m_dgvResultsList;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_clmnhdrFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_clmnhdrLastName;

       
    }
}