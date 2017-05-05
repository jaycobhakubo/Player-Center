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
            this.m_lastNameLabel = new System.Windows.Forms.Label();
            this.m_firstNameLabel = new System.Windows.Forms.Label();
            this.m_lastName = new System.Windows.Forms.TextBox();
            this.m_firstName = new System.Windows.Forms.TextBox();
            this.m_searchByCardButton = new GTI.Controls.ImageButton();
            this.m_cancelButton = new GTI.Controls.ImageButton();
            this.m_selectPlayerButton = new GTI.Controls.ImageButton();
            this.m_resultsList = new System.Windows.Forms.ListBox();
            this.m_searchButton = new GTI.Controls.ImageButton();
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
            resources.ApplyResources(this.m_searchByCardButton, "m_searchByCardButton");
            this.m_searchByCardButton.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_searchByCardButton.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_searchByCardButton.MinimumSize = new System.Drawing.Size(30, 30);
            this.m_searchByCardButton.Name = "m_searchByCardButton";
            this.m_searchByCardButton.UseVisualStyleBackColor = false;
            this.m_searchByCardButton.Click += new System.EventHandler(this.SearchByCardClick);
            // 
            // m_cancelButton
            // 
            this.m_cancelButton.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.m_cancelButton, "m_cancelButton");
            this.m_cancelButton.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_cancelButton.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_cancelButton.MinimumSize = new System.Drawing.Size(30, 30);
            this.m_cancelButton.Name = "m_cancelButton";
            this.m_cancelButton.UseVisualStyleBackColor = false;
            this.m_cancelButton.Click += new System.EventHandler(this.CancelClick);
            // 
            // m_selectPlayerButton
            // 
            this.m_selectPlayerButton.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.m_selectPlayerButton, "m_selectPlayerButton");
            this.m_selectPlayerButton.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_selectPlayerButton.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_selectPlayerButton.MinimumSize = new System.Drawing.Size(30, 30);
            this.m_selectPlayerButton.Name = "m_selectPlayerButton";
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
            resources.ApplyResources(this.m_searchButton, "m_searchButton");
            this.m_searchButton.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_searchButton.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_searchButton.MinimumSize = new System.Drawing.Size(30, 30);
            this.m_searchButton.Name = "m_searchButton";
            this.m_searchButton.UseVisualStyleBackColor = false;
            this.m_searchButton.Click += new System.EventHandler(this.SearchClick);
            // 
            // MCPFindPlayerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

       
    }
}