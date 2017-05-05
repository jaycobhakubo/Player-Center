namespace GTI.Modules.PlayerCenter.UI
{
    partial class PlayerManagementForm
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerManagementForm));
            this.m_magCard = new System.Windows.Forms.TextBox();
            this.m_LoginStatusImageLabel = new GTI.Controls.ImageLabel();
            this.m_ReceiptNumberColorListBox = new GTI.Controls.ColorListBox();
            this.m_virtualKeyboard = new GTI.Controls.VirtualKeyboard();
            this.m_firstName = new System.Windows.Forms.TextBox();
            this.m_middleInitial = new System.Windows.Forms.TextBox();
            this.m_lastName = new System.Windows.Forms.TextBox();
            this.m_socialSecurityNum = new System.Windows.Forms.TextBox();
            this.m_birthDate = new System.Windows.Forms.TextBox();
            this.m_email = new System.Windows.Forms.TextBox();
            this.m_playerIdent = new System.Windows.Forms.TextBox();
            this.m_phoneNum = new System.Windows.Forms.TextBox();
            this.m_address1 = new System.Windows.Forms.TextBox();
            this.m_address2 = new System.Windows.Forms.TextBox();
            this.m_city = new System.Windows.Forms.TextBox();
            this.m_state = new System.Windows.Forms.TextBox();
            this.m_zipCode = new System.Windows.Forms.TextBox();
            this.m_country = new System.Windows.Forms.TextBox();
            this.m_joinDate = new GTI.Controls.ImageLabel();
            this.m_lastVisit = new GTI.Controls.ImageLabel();
            this.m_pointsBalance = new GTI.Controls.ImageLabel();
            this.m_visitCount = new GTI.Controls.ImageLabel();
            this.m_playerPicture = new System.Windows.Forms.PictureBox();
            this.m_findPlayerButton = new GTI.Controls.ImageButton();
            this.m_playerId = new GTI.Controls.ImageLabel();
            this.m_newPlayerButton = new GTI.Controls.ImageButton();
            this.m_assignCardButton = new GTI.Controls.ImageButton();
            this.m_saveChangesButton = new GTI.Controls.ImageButton();
            this.m_cancelChangesButton = new GTI.Controls.ImageButton();
            this.m_setPlayerButton = new GTI.Controls.ImageButton();
            this.m_exitButton = new GTI.Controls.ImageButton();
            this.m_takePictureButton = new GTI.Controls.ImageButton();
            this.m_firstNameLabel = new System.Windows.Forms.Label();
            this.m_middleInitialLabel = new System.Windows.Forms.Label();
            this.m_lastNameLabel = new System.Windows.Forms.Label();
            this.m_birthDateLabel = new System.Windows.Forms.Label();
            this.m_genderLabel = new System.Windows.Forms.Label();
            this.m_phoneNumLabel = new System.Windows.Forms.Label();
            this.m_socialSecurityNumLabel = new System.Windows.Forms.Label();
            this.m_emailLabel = new System.Windows.Forms.Label();
            this.m_playerIdentLabel = new System.Windows.Forms.Label();
            this.m_commentsLabel = new System.Windows.Forms.Label();
            this.m_address1Label = new System.Windows.Forms.Label();
            this.m_address2Label = new System.Windows.Forms.Label();
            this.m_cityLabel = new System.Windows.Forms.Label();
            this.m_stateLabel = new System.Windows.Forms.Label();
            this.m_zipCodeLabel = new System.Windows.Forms.Label();
            this.m_countryLabel = new System.Windows.Forms.Label();
            this.m_pointsBalanceLabel = new System.Windows.Forms.Label();
            this.m_lastVisitLabel = new System.Windows.Forms.Label();
            this.m_joinDateLabel = new System.Windows.Forms.Label();
            this.m_visitCountLabel = new System.Windows.Forms.Label();
            this.m_playerIdLabel = new System.Windows.Forms.Label();
            this.m_playerTier = new GTI.Controls.ImageLabel();
            this.m_playerTierLabel = new System.Windows.Forms.Label();
            this.m_noPic = new System.Windows.Forms.PictureBox();
            this.takePINImageButton = new GTI.Controls.ImageButton();
            this.label1 = new System.Windows.Forms.Label();
            this.m_TotalSpend = new GTI.Controls.ImageLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_magCardNumLabel = new System.Windows.Forms.Label();
            this.tpdauReceiptLabel = new System.Windows.Forms.Label();
            this.m_comments = new System.Windows.Forms.TextBox();
            this.receiptUpImageButton = new GTI.Controls.ImageButton();
            this.receiptDownImageButton = new GTI.Controls.ImageButton();
            this.lblCredits = new System.Windows.Forms.Label();
            this.lblCreditNonRef = new System.Windows.Forms.Label();
            this.m_statusDownButton = new GTI.Controls.ImageButton();
            this.m_statusUpButton = new GTI.Controls.ImageButton();
            this.m_activeStatusList = new GTI.Controls.ColorListBox();
            this.m_genderCycleButton = new GTI.Controls.ImageButton();
            this.m_gender = new System.Windows.Forms.Label();
            this.m_credits = new GTI.Controls.ImageLabel();
            this.m_creditsNon = new GTI.Controls.ImageLabel();
            ((System.ComponentModel.ISupportInitialize)(this.m_playerPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_noPic)).BeginInit();
            this.SuspendLayout();
            // 
            // m_magCard
            // 
            this.m_magCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            this.m_magCard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.m_magCard, "m_magCard");
            this.m_magCard.ForeColor = System.Drawing.Color.Yellow;
            this.m_magCard.Name = "m_magCard";
            // 
            // m_LoginStatusImageLabel
            // 
            this.m_LoginStatusImageLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            resources.ApplyResources(this.m_LoginStatusImageLabel, "m_LoginStatusImageLabel");
            this.m_LoginStatusImageLabel.ForeColor = System.Drawing.Color.White;
            this.m_LoginStatusImageLabel.Name = "m_LoginStatusImageLabel";
            this.m_LoginStatusImageLabel.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.m_LoginStatusImageLabel.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // m_ReceiptNumberColorListBox
            // 
            this.m_ReceiptNumberColorListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            this.m_ReceiptNumberColorListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_ReceiptNumberColorListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            resources.ApplyResources(this.m_ReceiptNumberColorListBox, "m_ReceiptNumberColorListBox");
            this.m_ReceiptNumberColorListBox.ForeColor = System.Drawing.Color.White;
            this.m_ReceiptNumberColorListBox.FormattingEnabled = true;
            this.m_ReceiptNumberColorListBox.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            this.m_ReceiptNumberColorListBox.ImageList = null;
            this.m_ReceiptNumberColorListBox.Name = "m_ReceiptNumberColorListBox";
            this.m_ReceiptNumberColorListBox.SuppressVerticalScroll = true;
            this.m_ReceiptNumberColorListBox.TabStop = false;
            // 
            // m_virtualKeyboard
            // 
            this.m_virtualKeyboard.AltGrImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonUp;
            this.m_virtualKeyboard.AltGrImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonDown;
            this.m_virtualKeyboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(60)))), ((int)(((byte)(96)))));
            this.m_virtualKeyboard.BackspaceImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonUp;
            this.m_virtualKeyboard.BackspaceImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonDown;
            this.m_virtualKeyboard.ButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.m_virtualKeyboard.CapsLockImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonUp;
            this.m_virtualKeyboard.CapsLockImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonDown;
            this.m_virtualKeyboard.EnterImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonUp;
            this.m_virtualKeyboard.EnterImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonDown;
            resources.ApplyResources(this.m_virtualKeyboard, "m_virtualKeyboard");
            this.m_virtualKeyboard.KeyImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonUp;
            this.m_virtualKeyboard.KeyImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonDown;
            this.m_virtualKeyboard.Name = "m_virtualKeyboard";
            this.m_virtualKeyboard.ShiftImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonUp;
            this.m_virtualKeyboard.ShiftImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonDown;
            this.m_virtualKeyboard.ShowFocus = false;
            this.m_virtualKeyboard.SpaceImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonUp;
            this.m_virtualKeyboard.SpaceImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonDown;
            this.m_virtualKeyboard.TabPipeImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonUp;
            this.m_virtualKeyboard.TabPipeImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonDown;
            this.m_virtualKeyboard.TabStop = false;
            this.m_virtualKeyboard.KeyPressed += new GTI.Controls.KeyboardEventHandler(this.KeyboardKeyPressed);
            // 
            // m_firstName
            // 
            this.m_firstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            this.m_firstName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.m_firstName, "m_firstName");
            this.m_firstName.ForeColor = System.Drawing.Color.Yellow;
            this.m_firstName.Name = "m_firstName";
            this.m_firstName.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.m_firstName.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // m_middleInitial
            // 
            this.m_middleInitial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            this.m_middleInitial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.m_middleInitial, "m_middleInitial");
            this.m_middleInitial.ForeColor = System.Drawing.Color.Yellow;
            this.m_middleInitial.Name = "m_middleInitial";
            this.m_middleInitial.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.m_middleInitial.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // m_lastName
            // 
            this.m_lastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            this.m_lastName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.m_lastName, "m_lastName");
            this.m_lastName.ForeColor = System.Drawing.Color.Yellow;
            this.m_lastName.Name = "m_lastName";
            this.m_lastName.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.m_lastName.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // m_socialSecurityNum
            // 
            this.m_socialSecurityNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            this.m_socialSecurityNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.m_socialSecurityNum, "m_socialSecurityNum");
            this.m_socialSecurityNum.ForeColor = System.Drawing.Color.White;
            this.m_socialSecurityNum.Name = "m_socialSecurityNum";
            this.m_socialSecurityNum.ReadOnly = true;
            this.m_socialSecurityNum.UseSystemPasswordChar = true;
            this.m_socialSecurityNum.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.m_socialSecurityNum.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // m_birthDate
            // 
            this.m_birthDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            this.m_birthDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.m_birthDate, "m_birthDate");
            this.m_birthDate.ForeColor = System.Drawing.Color.Yellow;
            this.m_birthDate.Name = "m_birthDate";
            this.m_birthDate.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.m_birthDate.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // m_email
            // 
            this.m_email.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            this.m_email.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.m_email, "m_email");
            this.m_email.ForeColor = System.Drawing.Color.Yellow;
            this.m_email.Name = "m_email";
            this.m_email.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.m_email.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // m_playerIdent
            // 
            this.m_playerIdent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            this.m_playerIdent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.m_playerIdent, "m_playerIdent");
            this.m_playerIdent.ForeColor = System.Drawing.Color.White;
            this.m_playerIdent.Name = "m_playerIdent";
            this.m_playerIdent.ReadOnly = true;
            this.m_playerIdent.UseSystemPasswordChar = true;
            this.m_playerIdent.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.m_playerIdent.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // m_phoneNum
            // 
            this.m_phoneNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            this.m_phoneNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.m_phoneNum, "m_phoneNum");
            this.m_phoneNum.ForeColor = System.Drawing.Color.Yellow;
            this.m_phoneNum.Name = "m_phoneNum";
            this.m_phoneNum.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.m_phoneNum.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // m_address1
            // 
            this.m_address1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            this.m_address1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.m_address1, "m_address1");
            this.m_address1.ForeColor = System.Drawing.Color.Yellow;
            this.m_address1.Name = "m_address1";
            this.m_address1.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.m_address1.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // m_address2
            // 
            this.m_address2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            this.m_address2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.m_address2, "m_address2");
            this.m_address2.ForeColor = System.Drawing.Color.Yellow;
            this.m_address2.Name = "m_address2";
            this.m_address2.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.m_address2.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // m_city
            // 
            this.m_city.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            this.m_city.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.m_city, "m_city");
            this.m_city.ForeColor = System.Drawing.Color.Yellow;
            this.m_city.Name = "m_city";
            this.m_city.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.m_city.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // m_state
            // 
            this.m_state.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            this.m_state.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.m_state, "m_state");
            this.m_state.ForeColor = System.Drawing.Color.Yellow;
            this.m_state.Name = "m_state";
            this.m_state.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.m_state.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // m_zipCode
            // 
            this.m_zipCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            this.m_zipCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.m_zipCode, "m_zipCode");
            this.m_zipCode.ForeColor = System.Drawing.Color.Yellow;
            this.m_zipCode.Name = "m_zipCode";
            this.m_zipCode.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.m_zipCode.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // m_country
            // 
            this.m_country.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            this.m_country.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.m_country, "m_country");
            this.m_country.ForeColor = System.Drawing.Color.Yellow;
            this.m_country.Name = "m_country";
            this.m_country.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.m_country.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // m_joinDate
            // 
            this.m_joinDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            resources.ApplyResources(this.m_joinDate, "m_joinDate");
            this.m_joinDate.ForeColor = System.Drawing.Color.White;
            this.m_joinDate.Name = "m_joinDate";
            this.m_joinDate.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.m_joinDate.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // m_lastVisit
            // 
            this.m_lastVisit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            resources.ApplyResources(this.m_lastVisit, "m_lastVisit");
            this.m_lastVisit.ForeColor = System.Drawing.Color.White;
            this.m_lastVisit.Name = "m_lastVisit";
            this.m_lastVisit.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.m_lastVisit.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // m_pointsBalance
            // 
            this.m_pointsBalance.AutoEllipsis = true;
            this.m_pointsBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            resources.ApplyResources(this.m_pointsBalance, "m_pointsBalance");
            this.m_pointsBalance.ForeColor = System.Drawing.Color.White;
            this.m_pointsBalance.Name = "m_pointsBalance";
            this.m_pointsBalance.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.m_pointsBalance.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // m_visitCount
            // 
            this.m_visitCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            resources.ApplyResources(this.m_visitCount, "m_visitCount");
            this.m_visitCount.ForeColor = System.Drawing.Color.White;
            this.m_visitCount.Name = "m_visitCount";
            // 
            // m_playerPicture
            // 
            resources.ApplyResources(this.m_playerPicture, "m_playerPicture");
            this.m_playerPicture.Name = "m_playerPicture";
            this.m_playerPicture.TabStop = false;
            // 
            // m_findPlayerButton
            // 
            this.m_findPlayerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(60)))), ((int)(((byte)(96)))));
            this.m_findPlayerButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_findPlayerButton, "m_findPlayerButton");
            this.m_findPlayerButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_findPlayerButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("m_findPlayerButton.ImageNormal")));
            this.m_findPlayerButton.ImagePressed = ((System.Drawing.Image)(resources.GetObject("m_findPlayerButton.ImagePressed")));
            this.m_findPlayerButton.Name = "m_findPlayerButton";
            this.m_findPlayerButton.RepeatRate = 150;
            this.m_findPlayerButton.RepeatWhenHeldFor = 750;
            this.m_findPlayerButton.ShowFocus = false;
            this.m_findPlayerButton.TabStop = false;
            this.m_findPlayerButton.UseVisualStyleBackColor = false;
            this.m_findPlayerButton.Click += new System.EventHandler(this.FindPlayerClick);
            // 
            // m_playerId
            // 
            this.m_playerId.AutoEllipsis = true;
            this.m_playerId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            resources.ApplyResources(this.m_playerId, "m_playerId");
            this.m_playerId.ForeColor = System.Drawing.Color.White;
            this.m_playerId.Name = "m_playerId";
            this.m_playerId.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.m_playerId.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // m_newPlayerButton
            // 
            this.m_newPlayerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(60)))), ((int)(((byte)(96)))));
            this.m_newPlayerButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_newPlayerButton, "m_newPlayerButton");
            this.m_newPlayerButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_newPlayerButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("m_newPlayerButton.ImageNormal")));
            this.m_newPlayerButton.ImagePressed = ((System.Drawing.Image)(resources.GetObject("m_newPlayerButton.ImagePressed")));
            this.m_newPlayerButton.Name = "m_newPlayerButton";
            this.m_newPlayerButton.RepeatRate = 150;
            this.m_newPlayerButton.RepeatWhenHeldFor = 750;
            this.m_newPlayerButton.ShowFocus = false;
            this.m_newPlayerButton.TabStop = false;
            this.m_newPlayerButton.UseVisualStyleBackColor = false;
            this.m_newPlayerButton.Click += new System.EventHandler(this.NewPlayerClick);
            // 
            // m_assignCardButton
            // 
            this.m_assignCardButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(60)))), ((int)(((byte)(96)))));
            this.m_assignCardButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_assignCardButton, "m_assignCardButton");
            this.m_assignCardButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_assignCardButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("m_assignCardButton.ImageNormal")));
            this.m_assignCardButton.ImagePressed = ((System.Drawing.Image)(resources.GetObject("m_assignCardButton.ImagePressed")));
            this.m_assignCardButton.Name = "m_assignCardButton";
            this.m_assignCardButton.RepeatRate = 150;
            this.m_assignCardButton.RepeatWhenHeldFor = 750;
            this.m_assignCardButton.ShowFocus = false;
            this.m_assignCardButton.TabStop = false;
            this.m_assignCardButton.UseVisualStyleBackColor = false;
            this.m_assignCardButton.Click += new System.EventHandler(this.AssignCardClick);
            // 
            // m_saveChangesButton
            // 
            this.m_saveChangesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(60)))), ((int)(((byte)(96)))));
            this.m_saveChangesButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_saveChangesButton, "m_saveChangesButton");
            this.m_saveChangesButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_saveChangesButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("m_saveChangesButton.ImageNormal")));
            this.m_saveChangesButton.ImagePressed = ((System.Drawing.Image)(resources.GetObject("m_saveChangesButton.ImagePressed")));
            this.m_saveChangesButton.Name = "m_saveChangesButton";
            this.m_saveChangesButton.RepeatRate = 150;
            this.m_saveChangesButton.RepeatWhenHeldFor = 750;
            this.m_saveChangesButton.ShowFocus = false;
            this.m_saveChangesButton.TabStop = false;
            this.m_saveChangesButton.UseVisualStyleBackColor = false;
            this.m_saveChangesButton.Click += new System.EventHandler(this.SaveChangesClick);
            // 
            // m_cancelChangesButton
            // 
            this.m_cancelChangesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(60)))), ((int)(((byte)(96)))));
            this.m_cancelChangesButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_cancelChangesButton, "m_cancelChangesButton");
            this.m_cancelChangesButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_cancelChangesButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("m_cancelChangesButton.ImageNormal")));
            this.m_cancelChangesButton.ImagePressed = ((System.Drawing.Image)(resources.GetObject("m_cancelChangesButton.ImagePressed")));
            this.m_cancelChangesButton.Name = "m_cancelChangesButton";
            this.m_cancelChangesButton.RepeatRate = 150;
            this.m_cancelChangesButton.RepeatWhenHeldFor = 750;
            this.m_cancelChangesButton.ShowFocus = false;
            this.m_cancelChangesButton.TabStop = false;
            this.m_cancelChangesButton.UseVisualStyleBackColor = false;
            this.m_cancelChangesButton.Click += new System.EventHandler(this.CancelChangesClick);
            // 
            // m_setPlayerButton
            // 
            this.m_setPlayerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(60)))), ((int)(((byte)(96)))));
            resources.ApplyResources(this.m_setPlayerButton, "m_setPlayerButton");
            this.m_setPlayerButton.FocusColor = System.Drawing.Color.Black;
            this.m_setPlayerButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_setPlayerButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("m_setPlayerButton.ImageNormal")));
            this.m_setPlayerButton.ImagePressed = ((System.Drawing.Image)(resources.GetObject("m_setPlayerButton.ImagePressed")));
            this.m_setPlayerButton.Name = "m_setPlayerButton";
            this.m_setPlayerButton.RepeatRate = 150;
            this.m_setPlayerButton.RepeatWhenHeldFor = 750;
            this.m_setPlayerButton.ShowFocus = false;
            this.m_setPlayerButton.TabStop = false;
            this.m_setPlayerButton.UseVisualStyleBackColor = false;
            this.m_setPlayerButton.Click += new System.EventHandler(this.SetAsCurrentPlayerClick);
            // 
            // m_exitButton
            // 
            this.m_exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(60)))), ((int)(((byte)(96)))));
            this.m_exitButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_exitButton, "m_exitButton");
            this.m_exitButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_exitButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("m_exitButton.ImageNormal")));
            this.m_exitButton.ImagePressed = ((System.Drawing.Image)(resources.GetObject("m_exitButton.ImagePressed")));
            this.m_exitButton.Name = "m_exitButton";
            this.m_exitButton.RepeatRate = 150;
            this.m_exitButton.RepeatWhenHeldFor = 750;
            this.m_exitButton.ShowFocus = false;
            this.m_exitButton.TabStop = false;
            this.m_exitButton.UseVisualStyleBackColor = false;
            this.m_exitButton.Click += new System.EventHandler(this.ExitClick);
            // 
            // m_takePictureButton
            // 
            this.m_takePictureButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(60)))), ((int)(((byte)(96)))));
            this.m_takePictureButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_takePictureButton, "m_takePictureButton");
            this.m_takePictureButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_takePictureButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("m_takePictureButton.ImageNormal")));
            this.m_takePictureButton.ImagePressed = ((System.Drawing.Image)(resources.GetObject("m_takePictureButton.ImagePressed")));
            this.m_takePictureButton.Name = "m_takePictureButton";
            this.m_takePictureButton.RepeatRate = 150;
            this.m_takePictureButton.RepeatWhenHeldFor = 750;
            this.m_takePictureButton.ShowFocus = false;
            this.m_takePictureButton.TabStop = false;
            this.m_takePictureButton.UseVisualStyleBackColor = false;
            this.m_takePictureButton.Click += new System.EventHandler(this.TakePictureClick);
            // 
            // m_firstNameLabel
            // 
            this.m_firstNameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(179)))), ((int)(((byte)(213)))));
            resources.ApplyResources(this.m_firstNameLabel, "m_firstNameLabel");
            this.m_firstNameLabel.ForeColor = System.Drawing.Color.Black;
            this.m_firstNameLabel.Name = "m_firstNameLabel";
            // 
            // m_middleInitialLabel
            // 
            this.m_middleInitialLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(179)))), ((int)(((byte)(213)))));
            resources.ApplyResources(this.m_middleInitialLabel, "m_middleInitialLabel");
            this.m_middleInitialLabel.ForeColor = System.Drawing.Color.Black;
            this.m_middleInitialLabel.Name = "m_middleInitialLabel";
            // 
            // m_lastNameLabel
            // 
            this.m_lastNameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(179)))), ((int)(((byte)(213)))));
            resources.ApplyResources(this.m_lastNameLabel, "m_lastNameLabel");
            this.m_lastNameLabel.ForeColor = System.Drawing.Color.Black;
            this.m_lastNameLabel.Name = "m_lastNameLabel";
            // 
            // m_birthDateLabel
            // 
            this.m_birthDateLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(185)))), ((int)(((byte)(212)))));
            resources.ApplyResources(this.m_birthDateLabel, "m_birthDateLabel");
            this.m_birthDateLabel.ForeColor = System.Drawing.Color.Black;
            this.m_birthDateLabel.Name = "m_birthDateLabel";
            // 
            // m_genderLabel
            // 
            this.m_genderLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(185)))), ((int)(((byte)(212)))));
            resources.ApplyResources(this.m_genderLabel, "m_genderLabel");
            this.m_genderLabel.ForeColor = System.Drawing.Color.Black;
            this.m_genderLabel.Name = "m_genderLabel";
            // 
            // m_phoneNumLabel
            // 
            this.m_phoneNumLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(184)))), ((int)(((byte)(212)))));
            resources.ApplyResources(this.m_phoneNumLabel, "m_phoneNumLabel");
            this.m_phoneNumLabel.ForeColor = System.Drawing.Color.Black;
            this.m_phoneNumLabel.Name = "m_phoneNumLabel";
            // 
            // m_socialSecurityNumLabel
            // 
            this.m_socialSecurityNumLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(184)))), ((int)(((byte)(212)))));
            resources.ApplyResources(this.m_socialSecurityNumLabel, "m_socialSecurityNumLabel");
            this.m_socialSecurityNumLabel.ForeColor = System.Drawing.Color.Black;
            this.m_socialSecurityNumLabel.Name = "m_socialSecurityNumLabel";
            // 
            // m_emailLabel
            // 
            this.m_emailLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(184)))), ((int)(((byte)(212)))));
            resources.ApplyResources(this.m_emailLabel, "m_emailLabel");
            this.m_emailLabel.ForeColor = System.Drawing.Color.Black;
            this.m_emailLabel.Name = "m_emailLabel";
            // 
            // m_playerIdentLabel
            // 
            this.m_playerIdentLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(185)))), ((int)(((byte)(212)))));
            resources.ApplyResources(this.m_playerIdentLabel, "m_playerIdentLabel");
            this.m_playerIdentLabel.ForeColor = System.Drawing.Color.Black;
            this.m_playerIdentLabel.Name = "m_playerIdentLabel";
            // 
            // m_commentsLabel
            // 
            this.m_commentsLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(195)))), ((int)(((byte)(206)))));
            resources.ApplyResources(this.m_commentsLabel, "m_commentsLabel");
            this.m_commentsLabel.ForeColor = System.Drawing.Color.Black;
            this.m_commentsLabel.Name = "m_commentsLabel";
            // 
            // m_address1Label
            // 
            this.m_address1Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(179)))), ((int)(((byte)(212)))));
            resources.ApplyResources(this.m_address1Label, "m_address1Label");
            this.m_address1Label.ForeColor = System.Drawing.Color.Black;
            this.m_address1Label.Name = "m_address1Label";
            // 
            // m_address2Label
            // 
            this.m_address2Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(179)))), ((int)(((byte)(212)))));
            resources.ApplyResources(this.m_address2Label, "m_address2Label");
            this.m_address2Label.ForeColor = System.Drawing.Color.Black;
            this.m_address2Label.Name = "m_address2Label";
            // 
            // m_cityLabel
            // 
            this.m_cityLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(181)))), ((int)(((byte)(213)))));
            resources.ApplyResources(this.m_cityLabel, "m_cityLabel");
            this.m_cityLabel.ForeColor = System.Drawing.Color.Black;
            this.m_cityLabel.Name = "m_cityLabel";
            // 
            // m_stateLabel
            // 
            this.m_stateLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(181)))), ((int)(((byte)(213)))));
            resources.ApplyResources(this.m_stateLabel, "m_stateLabel");
            this.m_stateLabel.ForeColor = System.Drawing.Color.Black;
            this.m_stateLabel.Name = "m_stateLabel";
            // 
            // m_zipCodeLabel
            // 
            this.m_zipCodeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(181)))), ((int)(((byte)(213)))));
            resources.ApplyResources(this.m_zipCodeLabel, "m_zipCodeLabel");
            this.m_zipCodeLabel.ForeColor = System.Drawing.Color.Black;
            this.m_zipCodeLabel.Name = "m_zipCodeLabel";
            // 
            // m_countryLabel
            // 
            this.m_countryLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(181)))), ((int)(((byte)(213)))));
            resources.ApplyResources(this.m_countryLabel, "m_countryLabel");
            this.m_countryLabel.ForeColor = System.Drawing.Color.Black;
            this.m_countryLabel.Name = "m_countryLabel";
            // 
            // m_pointsBalanceLabel
            // 
            this.m_pointsBalanceLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(190)))), ((int)(((byte)(209)))));
            resources.ApplyResources(this.m_pointsBalanceLabel, "m_pointsBalanceLabel");
            this.m_pointsBalanceLabel.ForeColor = System.Drawing.Color.Black;
            this.m_pointsBalanceLabel.Name = "m_pointsBalanceLabel";
            // 
            // m_lastVisitLabel
            // 
            this.m_lastVisitLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(190)))), ((int)(((byte)(207)))));
            resources.ApplyResources(this.m_lastVisitLabel, "m_lastVisitLabel");
            this.m_lastVisitLabel.ForeColor = System.Drawing.Color.Black;
            this.m_lastVisitLabel.Name = "m_lastVisitLabel";
            // 
            // m_joinDateLabel
            // 
            this.m_joinDateLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(190)))), ((int)(((byte)(207)))));
            resources.ApplyResources(this.m_joinDateLabel, "m_joinDateLabel");
            this.m_joinDateLabel.ForeColor = System.Drawing.Color.Black;
            this.m_joinDateLabel.Name = "m_joinDateLabel";
            // 
            // m_visitCountLabel
            // 
            this.m_visitCountLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(190)))), ((int)(((byte)(207)))));
            resources.ApplyResources(this.m_visitCountLabel, "m_visitCountLabel");
            this.m_visitCountLabel.ForeColor = System.Drawing.Color.Black;
            this.m_visitCountLabel.Name = "m_visitCountLabel";
            // 
            // m_playerIdLabel
            // 
            this.m_playerIdLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(190)))), ((int)(((byte)(209)))));
            resources.ApplyResources(this.m_playerIdLabel, "m_playerIdLabel");
            this.m_playerIdLabel.ForeColor = System.Drawing.Color.Black;
            this.m_playerIdLabel.Name = "m_playerIdLabel";
            // 
            // m_playerTier
            // 
            this.m_playerTier.AutoEllipsis = true;
            this.m_playerTier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            resources.ApplyResources(this.m_playerTier, "m_playerTier");
            this.m_playerTier.ForeColor = System.Drawing.Color.White;
            this.m_playerTier.Name = "m_playerTier";
            this.m_playerTier.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.m_playerTier.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // m_playerTierLabel
            // 
            this.m_playerTierLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(190)))), ((int)(((byte)(209)))));
            resources.ApplyResources(this.m_playerTierLabel, "m_playerTierLabel");
            this.m_playerTierLabel.ForeColor = System.Drawing.Color.Black;
            this.m_playerTierLabel.Name = "m_playerTierLabel";
            // 
            // m_noPic
            // 
            this.m_noPic.Image = global::GTI.Modules.PlayerCenter.Properties.Resources.NoPic;
            resources.ApplyResources(this.m_noPic, "m_noPic");
            this.m_noPic.Name = "m_noPic";
            this.m_noPic.TabStop = false;
            // 
            // takePINImageButton
            // 
            this.takePINImageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(60)))), ((int)(((byte)(96)))));
            this.takePINImageButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.takePINImageButton, "takePINImageButton");
            this.takePINImageButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.takePINImageButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("takePINImageButton.ImageNormal")));
            this.takePINImageButton.ImagePressed = ((System.Drawing.Image)(resources.GetObject("takePINImageButton.ImagePressed")));
            this.takePINImageButton.Name = "takePINImageButton";
            this.takePINImageButton.RepeatRate = 150;
            this.takePINImageButton.RepeatWhenHeldFor = 750;
            this.takePINImageButton.ShowFocus = false;
            this.takePINImageButton.TabStop = false;
            this.takePINImageButton.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(190)))), ((int)(((byte)(209)))));
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Name = "label1";
            // 
            // m_TotalSpend
            // 
            this.m_TotalSpend.AutoEllipsis = true;
            this.m_TotalSpend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            resources.ApplyResources(this.m_TotalSpend, "m_TotalSpend");
            this.m_TotalSpend.ForeColor = System.Drawing.Color.White;
            this.m_TotalSpend.Name = "m_TotalSpend";
            this.m_TotalSpend.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.m_TotalSpend.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(190)))), ((int)(((byte)(207)))));
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Name = "label2";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(190)))), ((int)(((byte)(207)))));
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Name = "label3";
            // 
            // m_magCardNumLabel
            // 
            this.m_magCardNumLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(190)))), ((int)(((byte)(207)))));
            resources.ApplyResources(this.m_magCardNumLabel, "m_magCardNumLabel");
            this.m_magCardNumLabel.ForeColor = System.Drawing.Color.Black;
            this.m_magCardNumLabel.Name = "m_magCardNumLabel";
            // 
            // tpdauReceiptLabel
            // 
            this.tpdauReceiptLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(195)))), ((int)(((byte)(206)))));
            resources.ApplyResources(this.tpdauReceiptLabel, "tpdauReceiptLabel");
            this.tpdauReceiptLabel.ForeColor = System.Drawing.Color.Black;
            this.tpdauReceiptLabel.Name = "tpdauReceiptLabel";
            // 
            // m_comments
            // 
            this.m_comments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            this.m_comments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.m_comments, "m_comments");
            this.m_comments.ForeColor = System.Drawing.Color.Yellow;
            this.m_comments.Name = "m_comments";
            this.m_comments.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.m_comments.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // receiptUpImageButton
            // 
            this.receiptUpImageButton.BackColor = System.Drawing.Color.Transparent;
            this.receiptUpImageButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.receiptUpImageButton, "receiptUpImageButton");
            this.receiptUpImageButton.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.ArUp50x42UP;
            this.receiptUpImageButton.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.ArUp50x42DN;
            this.receiptUpImageButton.Name = "receiptUpImageButton";
            this.receiptUpImageButton.RepeatingIfHeld = true;
            this.receiptUpImageButton.RepeatRate = 150;
            this.receiptUpImageButton.RepeatWhenHeldFor = 750;
            this.receiptUpImageButton.ShowFocus = false;
            this.receiptUpImageButton.Stretch = false;
            this.receiptUpImageButton.TabStop = false;
            this.receiptUpImageButton.UseVisualStyleBackColor = false;
            this.receiptUpImageButton.Click += new System.EventHandler(this.receiptUpImageButton_Click);
            // 
            // receiptDownImageButton
            // 
            this.receiptDownImageButton.BackColor = System.Drawing.Color.Transparent;
            this.receiptDownImageButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.receiptDownImageButton, "receiptDownImageButton");
            this.receiptDownImageButton.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.ArDn50x42UP;
            this.receiptDownImageButton.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.ArDn50x42DN;
            this.receiptDownImageButton.Name = "receiptDownImageButton";
            this.receiptDownImageButton.RepeatingIfHeld = true;
            this.receiptDownImageButton.RepeatRate = 150;
            this.receiptDownImageButton.RepeatWhenHeldFor = 750;
            this.receiptDownImageButton.ShowFocus = false;
            this.receiptDownImageButton.Stretch = false;
            this.receiptDownImageButton.TabStop = false;
            this.receiptDownImageButton.UseVisualStyleBackColor = false;
            this.receiptDownImageButton.Click += new System.EventHandler(this.receiptDownImageButton_Click);
            // 
            // lblCredits
            // 
            this.lblCredits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(184)))), ((int)(((byte)(212)))));
            resources.ApplyResources(this.lblCredits, "lblCredits");
            this.lblCredits.ForeColor = System.Drawing.Color.Black;
            this.lblCredits.Name = "lblCredits";
            // 
            // lblCreditNonRef
            // 
            this.lblCreditNonRef.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(184)))), ((int)(((byte)(212)))));
            resources.ApplyResources(this.lblCreditNonRef, "lblCreditNonRef");
            this.lblCreditNonRef.ForeColor = System.Drawing.Color.Black;
            this.lblCreditNonRef.Name = "lblCreditNonRef";
            // 
            // m_statusDownButton
            // 
            this.m_statusDownButton.BackColor = System.Drawing.Color.Transparent;
            this.m_statusDownButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_statusDownButton, "m_statusDownButton");
            this.m_statusDownButton.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.ArDn50x42UP;
            this.m_statusDownButton.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.ArDn50x42DN;
            this.m_statusDownButton.Name = "m_statusDownButton";
            this.m_statusDownButton.RepeatingIfHeld = true;
            this.m_statusDownButton.RepeatRate = 150;
            this.m_statusDownButton.RepeatWhenHeldFor = 750;
            this.m_statusDownButton.ShowFocus = false;
            this.m_statusDownButton.Stretch = false;
            this.m_statusDownButton.TabStop = false;
            this.m_statusDownButton.UseVisualStyleBackColor = false;
            this.m_statusDownButton.Click += new System.EventHandler(this.StatusDownButtonClick);
            // 
            // m_statusUpButton
            // 
            this.m_statusUpButton.BackColor = System.Drawing.Color.Transparent;
            this.m_statusUpButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_statusUpButton, "m_statusUpButton");
            this.m_statusUpButton.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.ArUp50x42UP;
            this.m_statusUpButton.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.ArUp50x42DN;
            this.m_statusUpButton.Name = "m_statusUpButton";
            this.m_statusUpButton.RepeatingIfHeld = true;
            this.m_statusUpButton.RepeatRate = 150;
            this.m_statusUpButton.RepeatWhenHeldFor = 750;
            this.m_statusUpButton.ShowFocus = false;
            this.m_statusUpButton.Stretch = false;
            this.m_statusUpButton.TabStop = false;
            this.m_statusUpButton.UseVisualStyleBackColor = false;
            this.m_statusUpButton.Click += new System.EventHandler(this.StatusUpButtonClick);
            // 
            // m_activeStatusList
            // 
            this.m_activeStatusList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            this.m_activeStatusList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_activeStatusList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            resources.ApplyResources(this.m_activeStatusList, "m_activeStatusList");
            this.m_activeStatusList.ForeColor = System.Drawing.Color.Yellow;
            this.m_activeStatusList.FormattingEnabled = true;
            this.m_activeStatusList.HighlightColor = System.Drawing.Color.ForestGreen;
            this.m_activeStatusList.ImageList = null;
            this.m_activeStatusList.Name = "m_activeStatusList";
            this.m_activeStatusList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.m_activeStatusList.SuppressVerticalScroll = true;
            this.m_activeStatusList.TabStop = false;
            this.m_activeStatusList.SelectedIndexChanged += new System.EventHandler(this.ActiveStatusList_ItemSelectionChanged);
            // 
            // m_genderCycleButton
            // 
            this.m_genderCycleButton.BackColor = System.Drawing.Color.Transparent;
            this.m_genderCycleButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_genderCycleButton, "m_genderCycleButton");
            this.m_genderCycleButton.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.Reset50x42UP;
            this.m_genderCycleButton.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.Reset50x42DN;
            this.m_genderCycleButton.Name = "m_genderCycleButton";
            this.m_genderCycleButton.RepeatRate = 150;
            this.m_genderCycleButton.RepeatWhenHeldFor = 750;
            this.m_genderCycleButton.ShowFocus = false;
            this.m_genderCycleButton.Stretch = false;
            this.m_genderCycleButton.TabStop = false;
            this.m_genderCycleButton.UseVisualStyleBackColor = false;
            this.m_genderCycleButton.Click += new System.EventHandler(this.GenderCycleClick);
            // 
            // m_gender
            // 
            this.m_gender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            resources.ApplyResources(this.m_gender, "m_gender");
            this.m_gender.Name = "m_gender";
            this.m_gender.Click += new System.EventHandler(this.PlayerDataChanged);
            this.m_gender.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // m_credits
            // 
            this.m_credits.AutoEllipsis = true;
            this.m_credits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            resources.ApplyResources(this.m_credits, "m_credits");
            this.m_credits.ForeColor = System.Drawing.Color.White;
            this.m_credits.Name = "m_credits";
            this.m_credits.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // m_creditsNon
            // 
            this.m_creditsNon.AutoEllipsis = true;
            this.m_creditsNon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            resources.ApplyResources(this.m_creditsNon, "m_creditsNon");
            this.m_creditsNon.ForeColor = System.Drawing.Color.White;
            this.m_creditsNon.Name = "m_creditsNon";
            this.m_creditsNon.TextChanged += new System.EventHandler(this.PlayerDataChanged);
            this.m_creditsNon.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // PlayerManagementForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GTI.Modules.PlayerCenter.Properties.Resources.PlayerScreenCredits1024;
            this.Controls.Add(this.m_creditsNon);
            this.Controls.Add(this.m_credits);
            this.Controls.Add(this.m_gender);
            this.Controls.Add(this.m_genderCycleButton);
            this.Controls.Add(this.m_activeStatusList);
            this.Controls.Add(this.m_statusDownButton);
            this.Controls.Add(this.m_statusUpButton);
            this.Controls.Add(this.lblCreditNonRef);
            this.Controls.Add(this.lblCredits);
            this.Controls.Add(this.m_magCard);
            this.Controls.Add(this.m_LoginStatusImageLabel);
            this.Controls.Add(this.m_ReceiptNumberColorListBox);
            this.Controls.Add(this.receiptDownImageButton);
            this.Controls.Add(this.receiptUpImageButton);
            this.Controls.Add(this.m_comments);
            this.Controls.Add(this.tpdauReceiptLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_TotalSpend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.takePINImageButton);
            this.Controls.Add(this.m_noPic);
            this.Controls.Add(this.m_playerTierLabel);
            this.Controls.Add(this.m_playerTier);
            this.Controls.Add(this.m_magCardNumLabel);
            this.Controls.Add(this.m_playerIdLabel);
            this.Controls.Add(this.m_visitCountLabel);
            this.Controls.Add(this.m_joinDateLabel);
            this.Controls.Add(this.m_lastVisitLabel);
            this.Controls.Add(this.m_pointsBalanceLabel);
            this.Controls.Add(this.m_countryLabel);
            this.Controls.Add(this.m_zipCodeLabel);
            this.Controls.Add(this.m_stateLabel);
            this.Controls.Add(this.m_cityLabel);
            this.Controls.Add(this.m_address2Label);
            this.Controls.Add(this.m_address1Label);
            this.Controls.Add(this.m_commentsLabel);
            this.Controls.Add(this.m_playerIdentLabel);
            this.Controls.Add(this.m_emailLabel);
            this.Controls.Add(this.m_socialSecurityNumLabel);
            this.Controls.Add(this.m_phoneNumLabel);
            this.Controls.Add(this.m_genderLabel);
            this.Controls.Add(this.m_birthDateLabel);
            this.Controls.Add(this.m_lastNameLabel);
            this.Controls.Add(this.m_middleInitialLabel);
            this.Controls.Add(this.m_firstNameLabel);
            this.Controls.Add(this.m_takePictureButton);
            this.Controls.Add(this.m_exitButton);
            this.Controls.Add(this.m_setPlayerButton);
            this.Controls.Add(this.m_cancelChangesButton);
            this.Controls.Add(this.m_saveChangesButton);
            this.Controls.Add(this.m_assignCardButton);
            this.Controls.Add(this.m_newPlayerButton);
            this.Controls.Add(this.m_playerId);
            this.Controls.Add(this.m_findPlayerButton);
            this.Controls.Add(this.m_playerPicture);
            this.Controls.Add(this.m_visitCount);
            this.Controls.Add(this.m_pointsBalance);
            this.Controls.Add(this.m_lastVisit);
            this.Controls.Add(this.m_joinDate);
            this.Controls.Add(this.m_country);
            this.Controls.Add(this.m_zipCode);
            this.Controls.Add(this.m_state);
            this.Controls.Add(this.m_city);
            this.Controls.Add(this.m_address2);
            this.Controls.Add(this.m_address1);
            this.Controls.Add(this.m_phoneNum);
            this.Controls.Add(this.m_playerIdent);
            this.Controls.Add(this.m_email);
            this.Controls.Add(this.m_birthDate);
            this.Controls.Add(this.m_socialSecurityNum);
            this.Controls.Add(this.m_lastName);
            this.Controls.Add(this.m_middleInitial);
            this.Controls.Add(this.m_firstName);
            this.Controls.Add(this.m_virtualKeyboard);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Yellow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PlayerManagementForm";
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.m_playerPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_noPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GTI.Controls.VirtualKeyboard m_virtualKeyboard;
        private System.Windows.Forms.TextBox m_firstName;
        private System.Windows.Forms.TextBox m_middleInitial;
        private System.Windows.Forms.TextBox m_lastName;
        private System.Windows.Forms.TextBox m_socialSecurityNum;
        private System.Windows.Forms.TextBox m_birthDate;
        private System.Windows.Forms.TextBox m_email;
        private System.Windows.Forms.TextBox m_playerIdent;
        private System.Windows.Forms.TextBox m_phoneNum;
        private System.Windows.Forms.TextBox m_address1;
        private System.Windows.Forms.TextBox m_address2;
        private System.Windows.Forms.TextBox m_city;
        private System.Windows.Forms.TextBox m_state;
        private System.Windows.Forms.TextBox m_zipCode;
        private System.Windows.Forms.TextBox m_country;
        private GTI.Controls.ImageLabel m_joinDate;
        private GTI.Controls.ImageLabel m_lastVisit;
        private GTI.Controls.ImageLabel m_pointsBalance;
        private GTI.Controls.ImageLabel m_visitCount;
        private System.Windows.Forms.PictureBox m_playerPicture;
        private GTI.Controls.ImageButton m_findPlayerButton;
        private GTI.Controls.ImageLabel m_playerId;
        private GTI.Controls.ImageButton m_newPlayerButton;
        private GTI.Controls.ImageButton m_assignCardButton;
        private GTI.Controls.ImageButton m_saveChangesButton;
        private GTI.Controls.ImageButton m_cancelChangesButton;
        private GTI.Controls.ImageButton m_setPlayerButton;
        private GTI.Controls.ImageButton m_exitButton;
        private GTI.Controls.ImageButton m_takePictureButton;
        private System.Windows.Forms.Label m_firstNameLabel;
        private System.Windows.Forms.Label m_middleInitialLabel;
        private System.Windows.Forms.Label m_lastNameLabel;
        private System.Windows.Forms.Label m_birthDateLabel;
        private System.Windows.Forms.Label m_genderLabel;
        private System.Windows.Forms.Label m_phoneNumLabel;
        private System.Windows.Forms.Label m_socialSecurityNumLabel;
        private System.Windows.Forms.Label m_emailLabel;
        private System.Windows.Forms.Label m_playerIdentLabel;
        private System.Windows.Forms.Label m_commentsLabel;
        private System.Windows.Forms.Label m_address1Label;
        private System.Windows.Forms.Label m_address2Label;
        private System.Windows.Forms.Label m_cityLabel;
        private System.Windows.Forms.Label m_stateLabel;
        private System.Windows.Forms.Label m_zipCodeLabel;
        private System.Windows.Forms.Label m_countryLabel;
        private System.Windows.Forms.Label m_pointsBalanceLabel;
        private System.Windows.Forms.Label m_lastVisitLabel;
        private System.Windows.Forms.Label m_joinDateLabel;
        private System.Windows.Forms.Label m_visitCountLabel;
        private System.Windows.Forms.Label m_playerIdLabel;
        private GTI.Controls.ImageLabel m_playerTier;
        private System.Windows.Forms.Label m_playerTierLabel;
        private System.Windows.Forms.PictureBox m_noPic;
        private GTI.Controls.ImageButton takePINImageButton;
        private System.Windows.Forms.Label label1;
        private GTI.Controls.ImageLabel m_TotalSpend;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        
        private System.Windows.Forms.Label m_magCardNumLabel;
        private System.Windows.Forms.Label tpdauReceiptLabel;
        private System.Windows.Forms.TextBox m_comments;
        private GTI.Controls.ImageButton receiptUpImageButton;
        private GTI.Controls.ImageButton receiptDownImageButton;
        private GTI.Controls.ColorListBox m_ReceiptNumberColorListBox;
        private GTI.Controls.ImageLabel m_LoginStatusImageLabel;
//        private GTI.Controls.ImageLabel m_magCardImageLabel;
        private System.Windows.Forms.Label lblCredits;
        private System.Windows.Forms.Label lblCreditNonRef;
        private GTI.Controls.ImageButton m_statusDownButton;
        private GTI.Controls.ImageButton m_statusUpButton;
        private GTI.Controls.ColorListBox m_activeStatusList;
        private GTI.Controls.ImageButton m_genderCycleButton;
        private System.Windows.Forms.Label m_gender;
        private GTI.Controls.ImageLabel m_credits;
        private GTI.Controls.ImageLabel m_creditsNon;
        private System.Windows.Forms.TextBox m_magCard;

    }
}