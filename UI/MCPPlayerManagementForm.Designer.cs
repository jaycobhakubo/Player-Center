namespace GTI.Modules.PlayerCenter.UI
{
    partial class MCPPlayerManagementForm
    {
        #region Controls

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtMiddleInitial;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtSocialSecurityNum;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPlayerIdent;
        private System.Windows.Forms.TextBox txtPhoneNum;
        private System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.TextBox txCity;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.TextBox txtZipCode;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.PictureBox m_playerPicture;
        private System.Windows.Forms.TextBox txtComments;
        private GTI.Controls.ImageButton m_findPlayerButton;
        private GTI.Controls.ImageButton m_newPlayerButton;
        private GTI.Controls.ImageButton m_cancelChangesButton;
        private System.Windows.Forms.Label lblFirstNameLabel;
        private System.Windows.Forms.Label lblMiddleInitialLabel;
        private System.Windows.Forms.Label lblLastNameLabel;
        private System.Windows.Forms.Label lblBirthDateLabel;
        private System.Windows.Forms.Label lblGenderLabel;
        private System.Windows.Forms.Label lblPhoneNumLabel;
        private System.Windows.Forms.Label lblSocialSecurityNumLabel;
        private System.Windows.Forms.Label lblEmailLabel;
        private System.Windows.Forms.Label lblPlayerIdentLabel;
        private System.Windows.Forms.Label lblAddress1Label;
        private System.Windows.Forms.Label lblAddress2Label;
        private System.Windows.Forms.Label lblCityLabel;
        private System.Windows.Forms.Label lblStateLabel;
        private System.Windows.Forms.Label lblZipCodeLabel;
        private System.Windows.Forms.Label lblCountryLabel;
        private System.Windows.Forms.Label lblMagCardNumLabel;
        private System.Windows.Forms.PictureBox m_noPic;
        private System.Windows.Forms.GroupBox personalInfoGroupBox;
        private System.Windows.Forms.ListBox lstReceiptNumber;
        private System.Windows.Forms.TextBox txtBirthDate;
        private System.Windows.Forms.GroupBox commentsGroupBox;
        private System.Windows.Forms.GroupBox receiptGroupBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox loyalityGroupBox;
        private GTI.Controls.ImageLabel m_IsLogInStatusImageLabel;
        private GTI.Controls.ImageLabel m_pointsBalanceUI;
        private System.Windows.Forms.Label m_pointsBalanceLabel;
        private GTI.Controls.ImageLabel m_lastVisit;
        private System.Windows.Forms.Label m_lastVisitLabel;
        private System.Windows.Forms.Label isLoginLabel;
        private GTI.Controls.ImageLabel m_joinDate;
        private System.Windows.Forms.Label m_joinDateLabel;
        private System.Windows.Forms.Label spendLabel;
        private GTI.Controls.ImageLabel m_SpendDataImageLabel;
        private GTI.Controls.ImageLabel m_visitCount;
        private System.Windows.Forms.Label m_visitCountLabel;
        private GTI.Controls.ImageLabel m_playerId;
        private System.Windows.Forms.Label m_playerTierLabel;
        private System.Windows.Forms.Label m_playerIdLabel;
        private GTI.Controls.ImageLabel m_playerTier;
        private GTI.Controls.ImageButton m_saveChangesButton;
        private GTI.Controls.ImageButton m_takePictureButton;
        private GTI.Controls.ImageButton m_assignCardButton;
        private GTI.Controls.ImageButton takePINImageButton;
        private System.Windows.Forms.GroupBox groupBox1;




        #endregion

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblCreditsNonRef;
        private System.Windows.Forms.Label lblCredits;


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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MCPPlayerManagementForm));
            this.m_findPlayerButton = new GTI.Controls.ImageButton();
            this.m_newPlayerButton = new GTI.Controls.ImageButton();
            this.m_cancelChangesButton = new GTI.Controls.ImageButton();
            this.lstReceiptNumber = new System.Windows.Forms.ListBox();
            this.lblMagCardNumLabel = new System.Windows.Forms.Label();
            this.personalInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.txtMagCard = new System.Windows.Forms.TextBox();
            this.m_creditNonRef = new GTI.Controls.ImageLabel();
            this.m_credits = new GTI.Controls.ImageLabel();
            this.m_genderList = new System.Windows.Forms.ComboBox();
            this.lblCreditsNonRef = new System.Windows.Forms.Label();
            this.lblCredits = new System.Windows.Forms.Label();
            this.txtBirthDate = new System.Windows.Forms.TextBox();
            this.lblFirstNameLabel = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtMiddleInitial = new System.Windows.Forms.TextBox();
            this.lblMiddleInitialLabel = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastNameLabel = new System.Windows.Forms.Label();
            this.lblBirthDateLabel = new System.Windows.Forms.Label();
            this.lblGenderLabel = new System.Windows.Forms.Label();
            this.lblPhoneNumLabel = new System.Windows.Forms.Label();
            this.txtPhoneNum = new System.Windows.Forms.TextBox();
            this.txtSocialSecurityNum = new System.Windows.Forms.TextBox();
            this.lblSocialSecurityNumLabel = new System.Windows.Forms.Label();
            this.lblCountryLabel = new System.Windows.Forms.Label();
            this.lblEmailLabel = new System.Windows.Forms.Label();
            this.lblZipCodeLabel = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblStateLabel = new System.Windows.Forms.Label();
            this.txtPlayerIdent = new System.Windows.Forms.TextBox();
            this.lblCityLabel = new System.Windows.Forms.Label();
            this.lblPlayerIdentLabel = new System.Windows.Forms.Label();
            this.lblAddress2Label = new System.Windows.Forms.Label();
            this.lblAddress1Label = new System.Windows.Forms.Label();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.txCity = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.m_noPic = new System.Windows.Forms.PictureBox();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.m_playerPicture = new System.Windows.Forms.PictureBox();
            this.commentsGroupBox = new System.Windows.Forms.GroupBox();
            this.receiptGroupBox = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerPointPurgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loyalityGroupBox = new System.Windows.Forms.GroupBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.lvActiveStatus = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_IsLogInStatusImageLabel = new GTI.Controls.ImageLabel();
            this.m_pointsBalanceUI = new GTI.Controls.ImageLabel();
            this.m_pointsBalanceLabel = new System.Windows.Forms.Label();
            this.m_lastVisit = new GTI.Controls.ImageLabel();
            this.m_lastVisitLabel = new System.Windows.Forms.Label();
            this.isLoginLabel = new System.Windows.Forms.Label();
            this.m_joinDate = new GTI.Controls.ImageLabel();
            this.m_joinDateLabel = new System.Windows.Forms.Label();
            this.spendLabel = new System.Windows.Forms.Label();
            this.m_SpendDataImageLabel = new GTI.Controls.ImageLabel();
            this.m_visitCount = new GTI.Controls.ImageLabel();
            this.m_visitCountLabel = new System.Windows.Forms.Label();
            this.m_playerId = new GTI.Controls.ImageLabel();
            this.m_playerTierLabel = new System.Windows.Forms.Label();
            this.m_playerIdLabel = new System.Windows.Forms.Label();
            this.m_playerTier = new GTI.Controls.ImageLabel();
            this.m_saveChangesButton = new GTI.Controls.ImageButton();
            this.m_takePictureButton = new GTI.Controls.ImageButton();
            this.m_assignCardButton = new GTI.Controls.ImageButton();
            this.takePINImageButton = new GTI.Controls.ImageButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_btnImgAwardPointManual = new GTI.Controls.ImageButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.personalInfoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_noPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_playerPicture)).BeginInit();
            this.commentsGroupBox.SuspendLayout();
            this.receiptGroupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.loyalityGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_findPlayerButton
            // 
            this.m_findPlayerButton.BackColor = System.Drawing.Color.Transparent;
            this.m_findPlayerButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_findPlayerButton, "m_findPlayerButton");
            this.m_findPlayerButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_findPlayerButton.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_findPlayerButton.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_findPlayerButton.Name = "m_findPlayerButton";
            this.m_findPlayerButton.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_findPlayerButton.UseVisualStyleBackColor = false;
            this.m_findPlayerButton.Click += new System.EventHandler(this.FindPlayerClick);
            // 
            // m_newPlayerButton
            // 
            this.m_newPlayerButton.BackColor = System.Drawing.Color.Transparent;
            this.m_newPlayerButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_newPlayerButton, "m_newPlayerButton");
            this.m_newPlayerButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_newPlayerButton.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_newPlayerButton.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_newPlayerButton.Name = "m_newPlayerButton";
            this.m_newPlayerButton.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_newPlayerButton.UseVisualStyleBackColor = false;
            this.m_newPlayerButton.Click += new System.EventHandler(this.NewPlayerClick);
            // 
            // m_cancelChangesButton
            // 
            this.m_cancelChangesButton.BackColor = System.Drawing.Color.Transparent;
            this.m_cancelChangesButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_cancelChangesButton, "m_cancelChangesButton");
            this.m_cancelChangesButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_cancelChangesButton.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_cancelChangesButton.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_cancelChangesButton.Name = "m_cancelChangesButton";
            this.m_cancelChangesButton.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_cancelChangesButton.UseVisualStyleBackColor = false;
            this.m_cancelChangesButton.Click += new System.EventHandler(this.CancelChangesClick);
            // 
            // lstReceiptNumber
            // 
            this.lstReceiptNumber.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lstReceiptNumber, "lstReceiptNumber");
            this.lstReceiptNumber.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lstReceiptNumber.FormattingEnabled = true;
            this.lstReceiptNumber.Name = "lstReceiptNumber";
            this.lstReceiptNumber.SelectionMode = System.Windows.Forms.SelectionMode.None;
            // 
            // lblMagCardNumLabel
            // 
            resources.ApplyResources(this.lblMagCardNumLabel, "lblMagCardNumLabel");
            this.lblMagCardNumLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(182)))), ((int)(((byte)(205)))));
            this.lblMagCardNumLabel.ForeColor = System.Drawing.Color.Black;
            this.lblMagCardNumLabel.Name = "lblMagCardNumLabel";
            // 
            // personalInfoGroupBox
            // 
            this.personalInfoGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.personalInfoGroupBox.Controls.Add(this.txtMagCard);
            this.personalInfoGroupBox.Controls.Add(this.m_creditNonRef);
            this.personalInfoGroupBox.Controls.Add(this.m_credits);
            this.personalInfoGroupBox.Controls.Add(this.m_genderList);
            this.personalInfoGroupBox.Controls.Add(this.lblCreditsNonRef);
            this.personalInfoGroupBox.Controls.Add(this.lblCredits);
            this.personalInfoGroupBox.Controls.Add(this.txtBirthDate);
            this.personalInfoGroupBox.Controls.Add(this.lblFirstNameLabel);
            this.personalInfoGroupBox.Controls.Add(this.txtFirstName);
            this.personalInfoGroupBox.Controls.Add(this.txtMiddleInitial);
            this.personalInfoGroupBox.Controls.Add(this.lblMiddleInitialLabel);
            this.personalInfoGroupBox.Controls.Add(this.txtLastName);
            this.personalInfoGroupBox.Controls.Add(this.lblLastNameLabel);
            this.personalInfoGroupBox.Controls.Add(this.lblBirthDateLabel);
            this.personalInfoGroupBox.Controls.Add(this.lblGenderLabel);
            this.personalInfoGroupBox.Controls.Add(this.lblMagCardNumLabel);
            this.personalInfoGroupBox.Controls.Add(this.lblPhoneNumLabel);
            this.personalInfoGroupBox.Controls.Add(this.txtPhoneNum);
            this.personalInfoGroupBox.Controls.Add(this.txtSocialSecurityNum);
            this.personalInfoGroupBox.Controls.Add(this.lblSocialSecurityNumLabel);
            this.personalInfoGroupBox.Controls.Add(this.lblCountryLabel);
            this.personalInfoGroupBox.Controls.Add(this.lblEmailLabel);
            this.personalInfoGroupBox.Controls.Add(this.lblZipCodeLabel);
            this.personalInfoGroupBox.Controls.Add(this.txtEmail);
            this.personalInfoGroupBox.Controls.Add(this.lblStateLabel);
            this.personalInfoGroupBox.Controls.Add(this.txtPlayerIdent);
            this.personalInfoGroupBox.Controls.Add(this.lblCityLabel);
            this.personalInfoGroupBox.Controls.Add(this.lblPlayerIdentLabel);
            this.personalInfoGroupBox.Controls.Add(this.lblAddress2Label);
            this.personalInfoGroupBox.Controls.Add(this.lblAddress1Label);
            this.personalInfoGroupBox.Controls.Add(this.txtAddress1);
            this.personalInfoGroupBox.Controls.Add(this.txtAddress2);
            this.personalInfoGroupBox.Controls.Add(this.txCity);
            this.personalInfoGroupBox.Controls.Add(this.txtState);
            this.personalInfoGroupBox.Controls.Add(this.txtZipCode);
            this.personalInfoGroupBox.Controls.Add(this.txtCountry);
            resources.ApplyResources(this.personalInfoGroupBox, "personalInfoGroupBox");
            this.personalInfoGroupBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.personalInfoGroupBox.Name = "personalInfoGroupBox";
            this.personalInfoGroupBox.TabStop = false;
            // 
            // txtMagCard
            // 
            this.txtMagCard.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtMagCard, "txtMagCard");
            this.txtMagCard.ForeColor = System.Drawing.Color.Black;
            this.txtMagCard.Name = "txtMagCard";
            this.txtMagCard.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.txtMagCard.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // m_creditNonRef
            // 
            this.m_creditNonRef.BackColor = System.Drawing.Color.Transparent;
            this.m_creditNonRef.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.m_creditNonRef, "m_creditNonRef");
            this.m_creditNonRef.ForeColor = System.Drawing.Color.Black;
            this.m_creditNonRef.Name = "m_creditNonRef";
            // 
            // m_credits
            // 
            this.m_credits.BackColor = System.Drawing.Color.Transparent;
            this.m_credits.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.m_credits, "m_credits");
            this.m_credits.ForeColor = System.Drawing.Color.Black;
            this.m_credits.Name = "m_credits";
            // 
            // m_genderList
            // 
            this.m_genderList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.m_genderList, "m_genderList");
            this.m_genderList.FormattingEnabled = true;
            this.m_genderList.Name = "m_genderList";
            this.m_genderList.SelectedIndexChanged += new System.EventHandler(this.PlayerDataChanged);
            // 
            // lblCreditsNonRef
            // 
            resources.ApplyResources(this.lblCreditsNonRef, "lblCreditsNonRef");
            this.lblCreditsNonRef.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(183)))), ((int)(((byte)(203)))));
            this.lblCreditsNonRef.ForeColor = System.Drawing.Color.Black;
            this.lblCreditsNonRef.Name = "lblCreditsNonRef";
            // 
            // lblCredits
            // 
            resources.ApplyResources(this.lblCredits, "lblCredits");
            this.lblCredits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(183)))), ((int)(((byte)(203)))));
            this.lblCredits.ForeColor = System.Drawing.Color.Black;
            this.lblCredits.Name = "lblCredits";
            // 
            // txtBirthDate
            // 
            this.txtBirthDate.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtBirthDate, "txtBirthDate");
            this.txtBirthDate.ForeColor = System.Drawing.Color.Black;
            this.txtBirthDate.Name = "txtBirthDate";
            this.txtBirthDate.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            // 
            // lblFirstNameLabel
            // 
            resources.ApplyResources(this.lblFirstNameLabel, "lblFirstNameLabel");
            this.lblFirstNameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(179)))), ((int)(((byte)(213)))));
            this.lblFirstNameLabel.ForeColor = System.Drawing.Color.Black;
            this.lblFirstNameLabel.Name = "lblFirstNameLabel";
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtFirstName, "txtFirstName");
            this.txtFirstName.ForeColor = System.Drawing.Color.Black;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.txtFirstName.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // txtMiddleInitial
            // 
            this.txtMiddleInitial.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtMiddleInitial, "txtMiddleInitial");
            this.txtMiddleInitial.ForeColor = System.Drawing.Color.Black;
            this.txtMiddleInitial.Name = "txtMiddleInitial";
            this.txtMiddleInitial.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.txtMiddleInitial.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // lblMiddleInitialLabel
            // 
            resources.ApplyResources(this.lblMiddleInitialLabel, "lblMiddleInitialLabel");
            this.lblMiddleInitialLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(179)))), ((int)(((byte)(213)))));
            this.lblMiddleInitialLabel.ForeColor = System.Drawing.Color.Black;
            this.lblMiddleInitialLabel.Name = "lblMiddleInitialLabel";
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtLastName, "txtLastName");
            this.txtLastName.ForeColor = System.Drawing.Color.Black;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.txtLastName.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // lblLastNameLabel
            // 
            resources.ApplyResources(this.lblLastNameLabel, "lblLastNameLabel");
            this.lblLastNameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(179)))), ((int)(((byte)(213)))));
            this.lblLastNameLabel.ForeColor = System.Drawing.Color.Black;
            this.lblLastNameLabel.Name = "lblLastNameLabel";
            // 
            // lblBirthDateLabel
            // 
            resources.ApplyResources(this.lblBirthDateLabel, "lblBirthDateLabel");
            this.lblBirthDateLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(182)))), ((int)(((byte)(205)))));
            this.lblBirthDateLabel.ForeColor = System.Drawing.Color.Black;
            this.lblBirthDateLabel.Name = "lblBirthDateLabel";
            // 
            // lblGenderLabel
            // 
            resources.ApplyResources(this.lblGenderLabel, "lblGenderLabel");
            this.lblGenderLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(182)))), ((int)(((byte)(205)))));
            this.lblGenderLabel.ForeColor = System.Drawing.Color.Black;
            this.lblGenderLabel.Name = "lblGenderLabel";
            // 
            // lblPhoneNumLabel
            // 
            resources.ApplyResources(this.lblPhoneNumLabel, "lblPhoneNumLabel");
            this.lblPhoneNumLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(181)))), ((int)(((byte)(206)))));
            this.lblPhoneNumLabel.ForeColor = System.Drawing.Color.Black;
            this.lblPhoneNumLabel.Name = "lblPhoneNumLabel";
            // 
            // txtPhoneNum
            // 
            this.txtPhoneNum.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtPhoneNum, "txtPhoneNum");
            this.txtPhoneNum.ForeColor = System.Drawing.Color.Black;
            this.txtPhoneNum.Name = "txtPhoneNum";
            this.txtPhoneNum.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.txtPhoneNum.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // txtSocialSecurityNum
            // 
            this.txtSocialSecurityNum.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtSocialSecurityNum, "txtSocialSecurityNum");
            this.txtSocialSecurityNum.ForeColor = System.Drawing.Color.Black;
            this.txtSocialSecurityNum.Name = "txtSocialSecurityNum";
            this.txtSocialSecurityNum.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.txtSocialSecurityNum.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // lblSocialSecurityNumLabel
            // 
            resources.ApplyResources(this.lblSocialSecurityNumLabel, "lblSocialSecurityNumLabel");
            this.lblSocialSecurityNumLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(183)))), ((int)(((byte)(203)))));
            this.lblSocialSecurityNumLabel.ForeColor = System.Drawing.Color.Black;
            this.lblSocialSecurityNumLabel.Name = "lblSocialSecurityNumLabel";
            // 
            // lblCountryLabel
            // 
            resources.ApplyResources(this.lblCountryLabel, "lblCountryLabel");
            this.lblCountryLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(181)))), ((int)(((byte)(208)))));
            this.lblCountryLabel.ForeColor = System.Drawing.Color.Black;
            this.lblCountryLabel.Name = "lblCountryLabel";
            // 
            // lblEmailLabel
            // 
            resources.ApplyResources(this.lblEmailLabel, "lblEmailLabel");
            this.lblEmailLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(181)))), ((int)(((byte)(206)))));
            this.lblEmailLabel.ForeColor = System.Drawing.Color.Black;
            this.lblEmailLabel.Name = "lblEmailLabel";
            // 
            // lblZipCodeLabel
            // 
            resources.ApplyResources(this.lblZipCodeLabel, "lblZipCodeLabel");
            this.lblZipCodeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(181)))), ((int)(((byte)(208)))));
            this.lblZipCodeLabel.ForeColor = System.Drawing.Color.Black;
            this.lblZipCodeLabel.Name = "lblZipCodeLabel";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtEmail, "txtEmail");
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.txtEmail.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // lblStateLabel
            // 
            resources.ApplyResources(this.lblStateLabel, "lblStateLabel");
            this.lblStateLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(181)))), ((int)(((byte)(208)))));
            this.lblStateLabel.ForeColor = System.Drawing.Color.Black;
            this.lblStateLabel.Name = "lblStateLabel";
            // 
            // txtPlayerIdent
            // 
            this.txtPlayerIdent.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtPlayerIdent, "txtPlayerIdent");
            this.txtPlayerIdent.ForeColor = System.Drawing.Color.Black;
            this.txtPlayerIdent.Name = "txtPlayerIdent";
            this.txtPlayerIdent.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.txtPlayerIdent.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // lblCityLabel
            // 
            resources.ApplyResources(this.lblCityLabel, "lblCityLabel");
            this.lblCityLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(181)))), ((int)(((byte)(208)))));
            this.lblCityLabel.ForeColor = System.Drawing.Color.Black;
            this.lblCityLabel.Name = "lblCityLabel";
            // 
            // lblPlayerIdentLabel
            // 
            resources.ApplyResources(this.lblPlayerIdentLabel, "lblPlayerIdentLabel");
            this.lblPlayerIdentLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(183)))), ((int)(((byte)(203)))));
            this.lblPlayerIdentLabel.ForeColor = System.Drawing.Color.Black;
            this.lblPlayerIdentLabel.Name = "lblPlayerIdentLabel";
            // 
            // lblAddress2Label
            // 
            resources.ApplyResources(this.lblAddress2Label, "lblAddress2Label");
            this.lblAddress2Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.lblAddress2Label.ForeColor = System.Drawing.Color.Black;
            this.lblAddress2Label.Name = "lblAddress2Label";
            // 
            // lblAddress1Label
            // 
            this.lblAddress1Label.AutoEllipsis = true;
            resources.ApplyResources(this.lblAddress1Label, "lblAddress1Label");
            this.lblAddress1Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.lblAddress1Label.ForeColor = System.Drawing.Color.Black;
            this.lblAddress1Label.Name = "lblAddress1Label";
            // 
            // txtAddress1
            // 
            this.txtAddress1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtAddress1, "txtAddress1");
            this.txtAddress1.ForeColor = System.Drawing.Color.Black;
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.txtAddress1.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // txtAddress2
            // 
            this.txtAddress2.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtAddress2, "txtAddress2");
            this.txtAddress2.ForeColor = System.Drawing.Color.Black;
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.txtAddress2.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // txCity
            // 
            this.txCity.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txCity, "txCity");
            this.txCity.ForeColor = System.Drawing.Color.Black;
            this.txCity.Name = "txCity";
            this.txCity.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.txCity.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // txtState
            // 
            this.txtState.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtState, "txtState");
            this.txtState.ForeColor = System.Drawing.Color.Black;
            this.txtState.Name = "txtState";
            this.txtState.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.txtState.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // txtZipCode
            // 
            this.txtZipCode.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtZipCode, "txtZipCode");
            this.txtZipCode.ForeColor = System.Drawing.Color.Black;
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.txtZipCode.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // txtCountry
            // 
            this.txtCountry.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtCountry, "txtCountry");
            this.txtCountry.ForeColor = System.Drawing.Color.Black;
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.txtCountry.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // m_noPic
            // 
            this.m_noPic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(180)))), ((int)(((byte)(212)))));
            this.m_noPic.Image = global::GTI.Modules.PlayerCenter.Properties.Resources.NoPic;
            resources.ApplyResources(this.m_noPic, "m_noPic");
            this.m_noPic.Name = "m_noPic";
            this.m_noPic.TabStop = false;
            // 
            // txtComments
            // 
            this.txtComments.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtComments, "txtComments");
            this.txtComments.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtComments.Name = "txtComments";
            this.txtComments.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.txtComments.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // m_playerPicture
            // 
            resources.ApplyResources(this.m_playerPicture, "m_playerPicture");
            this.m_playerPicture.Name = "m_playerPicture";
            this.m_playerPicture.TabStop = false;
            // 
            // commentsGroupBox
            // 
            this.commentsGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.commentsGroupBox.Controls.Add(this.txtComments);
            resources.ApplyResources(this.commentsGroupBox, "commentsGroupBox");
            this.commentsGroupBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.commentsGroupBox.Name = "commentsGroupBox";
            this.commentsGroupBox.TabStop = false;
            // 
            // receiptGroupBox
            // 
            this.receiptGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.receiptGroupBox.Controls.Add(this.lstReceiptNumber);
            resources.ApplyResources(this.receiptGroupBox, "receiptGroupBox");
            this.receiptGroupBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.receiptGroupBox.Name = "receiptGroupBox";
            this.receiptGroupBox.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(222)))), ((int)(((byte)(237)))));
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerListToolStripMenuItem,
            this.playerStatusToolStripMenuItem,
            this.playerPointPurgeToolStripMenuItem});
            this.viewToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            resources.ApplyResources(this.viewToolStripMenuItem, "viewToolStripMenuItem");
            // 
            // playerListToolStripMenuItem
            // 
            this.playerListToolStripMenuItem.Name = "playerListToolStripMenuItem";
            resources.ApplyResources(this.playerListToolStripMenuItem, "playerListToolStripMenuItem");
            this.playerListToolStripMenuItem.Click += new System.EventHandler(this.playerListToolStripMenuItem_Click);
            // 
            // playerStatusToolStripMenuItem
            // 
            this.playerStatusToolStripMenuItem.Name = "playerStatusToolStripMenuItem";
            resources.ApplyResources(this.playerStatusToolStripMenuItem, "playerStatusToolStripMenuItem");
            this.playerStatusToolStripMenuItem.Click += new System.EventHandler(this.playerStatusToolStripMenuItem_Click);
            // 
            // playerPointPurgeToolStripMenuItem
            // 
            this.playerPointPurgeToolStripMenuItem.Name = "playerPointPurgeToolStripMenuItem";
            resources.ApplyResources(this.playerPointPurgeToolStripMenuItem, "playerPointPurgeToolStripMenuItem");
            this.playerPointPurgeToolStripMenuItem.Click += new System.EventHandler(this.playerPointPurgeToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // loyalityGroupBox
            // 
            this.loyalityGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.loyalityGroupBox.Controls.Add(this.statusLabel);
            this.loyalityGroupBox.Controls.Add(this.lvActiveStatus);
            this.loyalityGroupBox.Controls.Add(this.m_IsLogInStatusImageLabel);
            this.loyalityGroupBox.Controls.Add(this.m_pointsBalanceUI);
            this.loyalityGroupBox.Controls.Add(this.m_pointsBalanceLabel);
            this.loyalityGroupBox.Controls.Add(this.m_lastVisit);
            this.loyalityGroupBox.Controls.Add(this.m_lastVisitLabel);
            this.loyalityGroupBox.Controls.Add(this.isLoginLabel);
            this.loyalityGroupBox.Controls.Add(this.m_joinDate);
            this.loyalityGroupBox.Controls.Add(this.m_joinDateLabel);
            this.loyalityGroupBox.Controls.Add(this.spendLabel);
            this.loyalityGroupBox.Controls.Add(this.m_SpendDataImageLabel);
            this.loyalityGroupBox.Controls.Add(this.m_visitCount);
            this.loyalityGroupBox.Controls.Add(this.m_visitCountLabel);
            this.loyalityGroupBox.Controls.Add(this.m_playerId);
            this.loyalityGroupBox.Controls.Add(this.m_playerTierLabel);
            this.loyalityGroupBox.Controls.Add(this.m_playerIdLabel);
            this.loyalityGroupBox.Controls.Add(this.m_playerTier);
            resources.ApplyResources(this.loyalityGroupBox, "loyalityGroupBox");
            this.loyalityGroupBox.ForeColor = System.Drawing.Color.Black;
            this.loyalityGroupBox.Name = "loyalityGroupBox";
            this.loyalityGroupBox.TabStop = false;
            // 
            // statusLabel
            // 
            resources.ApplyResources(this.statusLabel, "statusLabel");
            this.statusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(183)))), ((int)(((byte)(201)))));
            this.statusLabel.ForeColor = System.Drawing.Color.Black;
            this.statusLabel.Name = "statusLabel";
            // 
            // lvActiveStatus
            // 
            this.lvActiveStatus.AutoArrange = false;
            this.lvActiveStatus.CheckBoxes = true;
            this.lvActiveStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName});
            resources.ApplyResources(this.lvActiveStatus, "lvActiveStatus");
            this.lvActiveStatus.FullRowSelect = true;
            this.lvActiveStatus.GridLines = true;
            this.lvActiveStatus.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvActiveStatus.MultiSelect = false;
            this.lvActiveStatus.Name = "lvActiveStatus";
            this.lvActiveStatus.UseCompatibleStateImageBehavior = false;
            this.lvActiveStatus.View = System.Windows.Forms.View.Details;
            this.lvActiveStatus.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvActiveStatus_ItemSelectionChanged);
            this.lvActiveStatus.Click += new System.EventHandler(this.PlayerDataChanged);
            // 
            // columnName
            // 
            resources.ApplyResources(this.columnName, "columnName");
            // 
            // m_IsLogInStatusImageLabel
            // 
            this.m_IsLogInStatusImageLabel.BackColor = System.Drawing.Color.Transparent;
            this.m_IsLogInStatusImageLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.m_IsLogInStatusImageLabel, "m_IsLogInStatusImageLabel");
            this.m_IsLogInStatusImageLabel.ForeColor = System.Drawing.Color.Black;
            this.m_IsLogInStatusImageLabel.Name = "m_IsLogInStatusImageLabel";
            // 
            // m_pointsBalanceUI
            // 
            this.m_pointsBalanceUI.BackColor = System.Drawing.Color.Transparent;
            this.m_pointsBalanceUI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.m_pointsBalanceUI, "m_pointsBalanceUI");
            this.m_pointsBalanceUI.ForeColor = System.Drawing.Color.Black;
            this.m_pointsBalanceUI.Name = "m_pointsBalanceUI";
            // 
            // m_pointsBalanceLabel
            // 
            resources.ApplyResources(this.m_pointsBalanceLabel, "m_pointsBalanceLabel");
            this.m_pointsBalanceLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(183)))), ((int)(((byte)(201)))));
            this.m_pointsBalanceLabel.ForeColor = System.Drawing.Color.Black;
            this.m_pointsBalanceLabel.Name = "m_pointsBalanceLabel";
            // 
            // m_lastVisit
            // 
            this.m_lastVisit.BackColor = System.Drawing.Color.Transparent;
            this.m_lastVisit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.m_lastVisit, "m_lastVisit");
            this.m_lastVisit.ForeColor = System.Drawing.Color.Black;
            this.m_lastVisit.Name = "m_lastVisit";
            // 
            // m_lastVisitLabel
            // 
            resources.ApplyResources(this.m_lastVisitLabel, "m_lastVisitLabel");
            this.m_lastVisitLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(184)))), ((int)(((byte)(199)))));
            this.m_lastVisitLabel.ForeColor = System.Drawing.Color.Black;
            this.m_lastVisitLabel.Name = "m_lastVisitLabel";
            // 
            // isLoginLabel
            // 
            resources.ApplyResources(this.isLoginLabel, "isLoginLabel");
            this.isLoginLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(184)))), ((int)(((byte)(199)))));
            this.isLoginLabel.ForeColor = System.Drawing.Color.Black;
            this.isLoginLabel.Name = "isLoginLabel";
            // 
            // m_joinDate
            // 
            this.m_joinDate.BackColor = System.Drawing.Color.Transparent;
            this.m_joinDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.m_joinDate, "m_joinDate");
            this.m_joinDate.ForeColor = System.Drawing.Color.Black;
            this.m_joinDate.Name = "m_joinDate";
            // 
            // m_joinDateLabel
            // 
            resources.ApplyResources(this.m_joinDateLabel, "m_joinDateLabel");
            this.m_joinDateLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(184)))), ((int)(((byte)(199)))));
            this.m_joinDateLabel.ForeColor = System.Drawing.Color.Black;
            this.m_joinDateLabel.Name = "m_joinDateLabel";
            // 
            // spendLabel
            // 
            resources.ApplyResources(this.spendLabel, "spendLabel");
            this.spendLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(183)))), ((int)(((byte)(201)))));
            this.spendLabel.ForeColor = System.Drawing.Color.Black;
            this.spendLabel.Name = "spendLabel";
            // 
            // m_SpendDataImageLabel
            // 
            this.m_SpendDataImageLabel.BackColor = System.Drawing.Color.Transparent;
            this.m_SpendDataImageLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.m_SpendDataImageLabel, "m_SpendDataImageLabel");
            this.m_SpendDataImageLabel.ForeColor = System.Drawing.Color.Black;
            this.m_SpendDataImageLabel.Name = "m_SpendDataImageLabel";
            // 
            // m_visitCount
            // 
            this.m_visitCount.BackColor = System.Drawing.Color.Transparent;
            this.m_visitCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.m_visitCount, "m_visitCount");
            this.m_visitCount.ForeColor = System.Drawing.Color.Black;
            this.m_visitCount.Name = "m_visitCount";
            // 
            // m_visitCountLabel
            // 
            resources.ApplyResources(this.m_visitCountLabel, "m_visitCountLabel");
            this.m_visitCountLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(184)))), ((int)(((byte)(199)))));
            this.m_visitCountLabel.ForeColor = System.Drawing.Color.Black;
            this.m_visitCountLabel.Name = "m_visitCountLabel";
            // 
            // m_playerId
            // 
            this.m_playerId.BackColor = System.Drawing.Color.Transparent;
            this.m_playerId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.m_playerId, "m_playerId");
            this.m_playerId.ForeColor = System.Drawing.Color.Black;
            this.m_playerId.Name = "m_playerId";
            // 
            // m_playerTierLabel
            // 
            resources.ApplyResources(this.m_playerTierLabel, "m_playerTierLabel");
            this.m_playerTierLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(183)))), ((int)(((byte)(201)))));
            this.m_playerTierLabel.ForeColor = System.Drawing.Color.Black;
            this.m_playerTierLabel.Name = "m_playerTierLabel";
            // 
            // m_playerIdLabel
            // 
            resources.ApplyResources(this.m_playerIdLabel, "m_playerIdLabel");
            this.m_playerIdLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(183)))), ((int)(((byte)(201)))));
            this.m_playerIdLabel.ForeColor = System.Drawing.Color.Black;
            this.m_playerIdLabel.Name = "m_playerIdLabel";
            // 
            // m_playerTier
            // 
            this.m_playerTier.BackColor = System.Drawing.Color.Transparent;
            this.m_playerTier.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.m_playerTier, "m_playerTier");
            this.m_playerTier.ForeColor = System.Drawing.Color.Black;
            this.m_playerTier.Name = "m_playerTier";
            // 
            // m_saveChangesButton
            // 
            this.m_saveChangesButton.BackColor = System.Drawing.Color.Transparent;
            this.m_saveChangesButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_saveChangesButton, "m_saveChangesButton");
            this.m_saveChangesButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_saveChangesButton.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_saveChangesButton.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_saveChangesButton.Name = "m_saveChangesButton";
            this.m_saveChangesButton.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_saveChangesButton.UseVisualStyleBackColor = false;
            this.m_saveChangesButton.Click += new System.EventHandler(this.SaveChangesClick);
            // 
            // m_takePictureButton
            // 
            this.m_takePictureButton.BackColor = System.Drawing.Color.Transparent;
            this.m_takePictureButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_takePictureButton, "m_takePictureButton");
            this.m_takePictureButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_takePictureButton.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_takePictureButton.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_takePictureButton.Name = "m_takePictureButton";
            this.m_takePictureButton.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_takePictureButton.UseVisualStyleBackColor = false;
            this.m_takePictureButton.Click += new System.EventHandler(this.TakePictureClick);
            // 
            // m_assignCardButton
            // 
            this.m_assignCardButton.BackColor = System.Drawing.Color.Transparent;
            this.m_assignCardButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_assignCardButton, "m_assignCardButton");
            this.m_assignCardButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_assignCardButton.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_assignCardButton.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_assignCardButton.Name = "m_assignCardButton";
            this.m_assignCardButton.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_assignCardButton.UseVisualStyleBackColor = false;
            this.m_assignCardButton.Click += new System.EventHandler(this.AssignCardClick);
            // 
            // takePINImageButton
            // 
            this.takePINImageButton.BackColor = System.Drawing.Color.Transparent;
            this.takePINImageButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.takePINImageButton, "takePINImageButton");
            this.takePINImageButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.takePINImageButton.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.takePINImageButton.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.takePINImageButton.Name = "takePINImageButton";
            this.takePINImageButton.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.takePINImageButton.UseVisualStyleBackColor = false;
            this.takePINImageButton.Click += new System.EventHandler(this.takePINImageButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.m_noPic);
            this.groupBox1.Controls.Add(this.m_playerPicture);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // m_btnImgAwardPointManual
            // 
            this.m_btnImgAwardPointManual.BackColor = System.Drawing.Color.Transparent;
            this.m_btnImgAwardPointManual.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_btnImgAwardPointManual, "m_btnImgAwardPointManual");
            this.m_btnImgAwardPointManual.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_btnImgAwardPointManual.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_btnImgAwardPointManual.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_btnImgAwardPointManual.Name = "m_btnImgAwardPointManual";
            this.m_btnImgAwardPointManual.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_btnImgAwardPointManual.UseVisualStyleBackColor = false;
            this.m_btnImgAwardPointManual.Click += new System.EventHandler(this.AwardPointsImageButton_Click);
            // 
            // MCPPlayerManagementForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_saveChangesButton);
            this.Controls.Add(this.takePINImageButton);
            this.Controls.Add(this.m_findPlayerButton);
            this.Controls.Add(this.m_takePictureButton);
            this.Controls.Add(this.m_assignCardButton);
            this.Controls.Add(this.m_newPlayerButton);
            this.Controls.Add(this.commentsGroupBox);
            this.Controls.Add(this.receiptGroupBox);
            this.Controls.Add(this.m_cancelChangesButton);
            this.Controls.Add(this.loyalityGroupBox);
            this.Controls.Add(this.personalInfoGroupBox);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.m_btnImgAwardPointManual);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MCPPlayerManagementForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.personalInfoGroupBox.ResumeLayout(false);
            this.personalInfoGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_noPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_playerPicture)).EndInit();
            this.commentsGroupBox.ResumeLayout(false);
            this.commentsGroupBox.PerformLayout();
            this.receiptGroupBox.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.loyalityGroupBox.ResumeLayout(false);
            this.loyalityGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerListToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ListView lvActiveStatus;
        private System.Windows.Forms.ToolStripMenuItem playerStatusToolStripMenuItem;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ComboBox m_genderList;
//        private GTI.Controls.ImageLabel m_magCardNum;
        private GTI.Controls.ImageLabel m_credits;
        private GTI.Controls.ImageLabel m_creditNonRef;
        private System.Windows.Forms.TextBox txtMagCard;
        private Controls.ImageButton m_btnImgAwardPointManual;
        private System.Windows.Forms.ToolStripMenuItem playerPointPurgeToolStripMenuItem;

       
       
    }
}