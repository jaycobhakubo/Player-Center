namespace GTI.Modules.PlayerCenter.UI
{
    partial class PlayerLoyaltyForm
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
            if (disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerLoyaltyForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_btnEditTier = new GTI.Controls.ImageButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_lstboxTiers = new GTI.Controls.ColorListBox();
            this.m_btnDeleteTier = new GTI.Controls.ImageButton();
            this.m_btnAddTier = new GTI.Controls.ImageButton();
            this.m_btnCloseTier = new GTI.Controls.ImageButton();
            this.lbl_MessageSaved = new System.Windows.Forms.Label();
            this.m_lblTierColor = new System.Windows.Forms.Label();
            this.m_btnCancelTier = new GTI.Controls.ImageButton();
            this.m_btnSaveTier = new GTI.Controls.ImageButton();
            this.m_txtbxAwardPointsMultiplier = new System.Windows.Forms.TextBox();
            this.labelAwardPoints = new System.Windows.Forms.Label();
            this.m_cmbxQualifyingpoints = new System.Windows.Forms.ComboBox();
            this.m_cmbxQualfyingSpend = new System.Windows.Forms.ComboBox();
            this.m_txtbxPointStart = new System.Windows.Forms.TextBox();
            this.labelTierName = new System.Windows.Forms.Label();
            this.labelColor = new System.Windows.Forms.Label();
            this.m_txtbxSpendStart = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelPointsStart = new System.Windows.Forms.Label();
            this.labelPoints = new System.Windows.Forms.Label();
            this.labelSpendStart = new System.Windows.Forms.Label();
            this.labelSpend = new System.Windows.Forms.Label();
            this.m_txtbxTierName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_tbctrlPlayerLoyalty = new System.Windows.Forms.TabControl();
            this.m_tabPage_TierRule = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.m_btnCloseTierRule = new GTI.Controls.ImageButton();
            this.m_btnCancelTierRule = new GTI.Controls.ImageButton();
            this.m_btnEditSaveTierRule = new GTI.Controls.ImageButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_cmbxDowngradeToDefault = new System.Windows.Forms.ComboBox();
            this.m_lblTierRuleSavedSuccessNotification = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.m_cmbxDefaultTier = new System.Windows.Forms.ComboBox();
            this.labelRestart = new System.Windows.Forms.Label();
            this.m_datetimepickerQualifyingPeriodEnd = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.m_datetimepickerQualifyingPeriodStart = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.m_tabPageTier = new System.Windows.Forms.TabPage();
            this.m_errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.m_tbctrlPlayerLoyalty.SuspendLayout();
            this.m_tabPage_TierRule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.m_tabPageTier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(179)))), ((int)(((byte)(213)))));
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(179)))), ((int)(((byte)(213)))));
            this.splitContainer1.Panel1.Controls.Add(this.m_btnEditTier);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.m_btnDeleteTier);
            this.splitContainer1.Panel1.Controls.Add(this.m_btnAddTier);
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(179)))), ((int)(((byte)(213)))));
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.Controls.Add(this.m_btnCloseTier);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_MessageSaved);
            this.splitContainer1.Panel2.Controls.Add(this.m_lblTierColor);
            this.splitContainer1.Panel2.Controls.Add(this.m_btnCancelTier);
            this.splitContainer1.Panel2.Controls.Add(this.m_btnSaveTier);
            this.splitContainer1.Panel2.Controls.Add(this.m_txtbxAwardPointsMultiplier);
            this.splitContainer1.Panel2.Controls.Add(this.labelAwardPoints);
            this.splitContainer1.Panel2.Controls.Add(this.m_cmbxQualifyingpoints);
            this.splitContainer1.Panel2.Controls.Add(this.m_cmbxQualfyingSpend);
            this.splitContainer1.Panel2.Controls.Add(this.m_txtbxPointStart);
            this.splitContainer1.Panel2.Controls.Add(this.labelTierName);
            this.splitContainer1.Panel2.Controls.Add(this.labelColor);
            this.splitContainer1.Panel2.Controls.Add(this.m_txtbxSpendStart);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.labelPointsStart);
            this.splitContainer1.Panel2.Controls.Add(this.labelPoints);
            this.splitContainer1.Panel2.Controls.Add(this.labelSpendStart);
            this.splitContainer1.Panel2.Controls.Add(this.labelSpend);
            this.splitContainer1.Panel2.Controls.Add(this.m_txtbxTierName);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // m_btnEditTier
            // 
            this.m_btnEditTier.BackColor = System.Drawing.Color.Transparent;
            this.m_btnEditTier.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_btnEditTier, "m_btnEditTier");
            this.m_btnEditTier.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_btnEditTier.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_btnEditTier.Name = "m_btnEditTier";
            this.m_btnEditTier.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_btnEditTier.UseVisualStyleBackColor = false;
            this.m_btnEditTier.Click += new System.EventHandler(this.m_btnEditTier_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_lstboxTiers);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // m_lstboxTiers
            // 
            this.m_lstboxTiers.AllowDrop = true;
            this.m_lstboxTiers.BackColor = System.Drawing.Color.White;
            this.m_lstboxTiers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            resources.ApplyResources(this.m_lstboxTiers, "m_lstboxTiers");
            this.m_lstboxTiers.ForeColor = System.Drawing.Color.Black;
            this.m_lstboxTiers.FormattingEnabled = true;
            this.m_lstboxTiers.HighlightColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.m_lstboxTiers.ImageList = null;
            this.m_lstboxTiers.Name = "m_lstboxTiers";
            this.m_lstboxTiers.SuppressVerticalScroll = true;
            this.m_lstboxTiers.TabStop = false;
            this.m_lstboxTiers.TopIndexForScroll = 0;
            this.m_lstboxTiers.SelectedIndexChanged += new System.EventHandler(this.m_lstboxTiers_SelectedIndexChanged);
            // 
            // m_btnDeleteTier
            // 
            this.m_btnDeleteTier.BackColor = System.Drawing.Color.Transparent;
            this.m_btnDeleteTier.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_btnDeleteTier, "m_btnDeleteTier");
            this.m_btnDeleteTier.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_btnDeleteTier.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_btnDeleteTier.Name = "m_btnDeleteTier";
            this.m_btnDeleteTier.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_btnDeleteTier.TabStop = false;
            this.m_btnDeleteTier.UseVisualStyleBackColor = false;
            this.m_btnDeleteTier.Click += new System.EventHandler(this.m_btnDeleteTier_Click);
            // 
            // m_btnAddTier
            // 
            this.m_btnAddTier.BackColor = System.Drawing.Color.Transparent;
            this.m_btnAddTier.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_btnAddTier, "m_btnAddTier");
            this.m_btnAddTier.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_btnAddTier.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_btnAddTier.Name = "m_btnAddTier";
            this.m_btnAddTier.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_btnAddTier.UseVisualStyleBackColor = false;
            this.m_btnAddTier.Click += new System.EventHandler(this.m_btnAddTier_Click);
            // 
            // m_btnCloseTier
            // 
            this.m_btnCloseTier.BackColor = System.Drawing.Color.Transparent;
            this.m_btnCloseTier.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCloseTier.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_btnCloseTier, "m_btnCloseTier");
            this.m_btnCloseTier.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_btnCloseTier.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_btnCloseTier.Name = "m_btnCloseTier";
            this.m_btnCloseTier.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_btnCloseTier.UseVisualStyleBackColor = false;
            this.m_btnCloseTier.Click += new System.EventHandler(this.m_btnCloseTier_Click);
            // 
            // lbl_MessageSaved
            // 
            resources.ApplyResources(this.lbl_MessageSaved, "lbl_MessageSaved");
            this.lbl_MessageSaved.Name = "lbl_MessageSaved";
            // 
            // m_lblTierColor
            // 
            this.m_lblTierColor.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.m_lblTierColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.m_lblTierColor, "m_lblTierColor");
            this.m_lblTierColor.Name = "m_lblTierColor";
            this.m_lblTierColor.Click += new System.EventHandler(this.m_lblTierColor_Click);
            // 
            // m_btnCancelTier
            // 
            this.m_btnCancelTier.BackColor = System.Drawing.Color.Transparent;
            this.m_btnCancelTier.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_btnCancelTier, "m_btnCancelTier");
            this.m_btnCancelTier.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_btnCancelTier.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_btnCancelTier.Name = "m_btnCancelTier";
            this.m_btnCancelTier.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_btnCancelTier.UseVisualStyleBackColor = false;
            this.m_btnCancelTier.Click += new System.EventHandler(this.m_btnCancelTier_Click);
            // 
            // m_btnSaveTier
            // 
            this.m_btnSaveTier.BackColor = System.Drawing.Color.Transparent;
            this.m_btnSaveTier.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_btnSaveTier, "m_btnSaveTier");
            this.m_btnSaveTier.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_btnSaveTier.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_btnSaveTier.Name = "m_btnSaveTier";
            this.m_btnSaveTier.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_btnSaveTier.UseVisualStyleBackColor = false;
            this.m_btnSaveTier.Click += new System.EventHandler(this.m_btnSaveTier_Click);
            // 
            // m_txtbxAwardPointsMultiplier
            // 
            this.m_txtbxAwardPointsMultiplier.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.m_txtbxAwardPointsMultiplier, "m_txtbxAwardPointsMultiplier");
            this.m_txtbxAwardPointsMultiplier.Name = "m_txtbxAwardPointsMultiplier";
            this.m_txtbxAwardPointsMultiplier.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtbxAwardPointsMultiplier_KeyPress);
            this.m_txtbxAwardPointsMultiplier.Validating += new System.ComponentModel.CancelEventHandler(this.m_txtbxAwardPointsMultiplier_Validating);
            // 
            // labelAwardPoints
            // 
            resources.ApplyResources(this.labelAwardPoints, "labelAwardPoints");
            this.labelAwardPoints.BackColor = System.Drawing.Color.Transparent;
            this.labelAwardPoints.Name = "labelAwardPoints";
            // 
            // m_cmbxQualifyingpoints
            // 
            this.m_cmbxQualifyingpoints.BackColor = System.Drawing.SystemColors.Window;
            this.m_cmbxQualifyingpoints.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.m_cmbxQualifyingpoints, "m_cmbxQualifyingpoints");
            this.m_cmbxQualifyingpoints.FormattingEnabled = true;
            this.m_cmbxQualifyingpoints.Items.AddRange(new object[] {
            resources.GetString("m_cmbxQualifyingpoints.Items"),
            resources.GetString("m_cmbxQualifyingpoints.Items1")});
            this.m_cmbxQualifyingpoints.Name = "m_cmbxQualifyingpoints";
            this.m_cmbxQualifyingpoints.SelectionChangeCommitted += new System.EventHandler(this.m_cmbxQualifyingpoints_SelectionChangeCommitted);
            this.m_cmbxQualifyingpoints.Validating += new System.ComponentModel.CancelEventHandler(this.m_cmbxQualifyingpoints_Validating);
            // 
            // m_cmbxQualfyingSpend
            // 
            this.m_cmbxQualfyingSpend.BackColor = System.Drawing.SystemColors.Window;
            this.m_cmbxQualfyingSpend.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.m_cmbxQualfyingSpend, "m_cmbxQualfyingSpend");
            this.m_cmbxQualfyingSpend.FormattingEnabled = true;
            this.m_cmbxQualfyingSpend.Items.AddRange(new object[] {
            resources.GetString("m_cmbxQualfyingSpend.Items"),
            resources.GetString("m_cmbxQualfyingSpend.Items1")});
            this.m_cmbxQualfyingSpend.Name = "m_cmbxQualfyingSpend";
            this.m_cmbxQualfyingSpend.SelectionChangeCommitted += new System.EventHandler(this.m_cmbxQualfyingSpend_SelectionChangeCommitted);
            this.m_cmbxQualfyingSpend.Validating += new System.ComponentModel.CancelEventHandler(this.m_cmbxQualfyingSpend_Validating);
            // 
            // m_txtbxPointStart
            // 
            this.m_txtbxPointStart.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.m_txtbxPointStart, "m_txtbxPointStart");
            this.m_txtbxPointStart.Name = "m_txtbxPointStart";
            this.m_txtbxPointStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtbxAwardPointsMultiplier_KeyPress);
            this.m_txtbxPointStart.Validating += new System.ComponentModel.CancelEventHandler(this.m_txtbxPointStart_Validating);
            // 
            // labelTierName
            // 
            resources.ApplyResources(this.labelTierName, "labelTierName");
            this.labelTierName.BackColor = System.Drawing.Color.Transparent;
            this.labelTierName.Name = "labelTierName";
            // 
            // labelColor
            // 
            resources.ApplyResources(this.labelColor, "labelColor");
            this.labelColor.BackColor = System.Drawing.Color.Transparent;
            this.labelColor.Name = "labelColor";
            // 
            // m_txtbxSpendStart
            // 
            this.m_txtbxSpendStart.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.m_txtbxSpendStart, "m_txtbxSpendStart");
            this.m_txtbxSpendStart.ForeColor = System.Drawing.Color.Black;
            this.m_txtbxSpendStart.Name = "m_txtbxSpendStart";
            this.m_txtbxSpendStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtbxAwardPointsMultiplier_KeyPress);
            this.m_txtbxSpendStart.Validating += new System.ComponentModel.CancelEventHandler(this.m_txtbxSpendStart_Validating);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Name = "label2";
            // 
            // labelPointsStart
            // 
            resources.ApplyResources(this.labelPointsStart, "labelPointsStart");
            this.labelPointsStart.BackColor = System.Drawing.Color.Transparent;
            this.labelPointsStart.Name = "labelPointsStart";
            // 
            // labelPoints
            // 
            resources.ApplyResources(this.labelPoints, "labelPoints");
            this.labelPoints.BackColor = System.Drawing.Color.Transparent;
            this.labelPoints.Name = "labelPoints";
            // 
            // labelSpendStart
            // 
            resources.ApplyResources(this.labelSpendStart, "labelSpendStart");
            this.labelSpendStart.BackColor = System.Drawing.Color.Transparent;
            this.labelSpendStart.Name = "labelSpendStart";
            // 
            // labelSpend
            // 
            resources.ApplyResources(this.labelSpend, "labelSpend");
            this.labelSpend.BackColor = System.Drawing.Color.Transparent;
            this.labelSpend.Name = "labelSpend";
            // 
            // m_txtbxTierName
            // 
            this.m_txtbxTierName.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.m_txtbxTierName, "m_txtbxTierName");
            this.m_txtbxTierName.Name = "m_txtbxTierName";
            this.m_txtbxTierName.Validating += new System.ComponentModel.CancelEventHandler(this.m_txtbxTierName_Validating);
            // 
            // groupBox3
            // 
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // m_tbctrlPlayerLoyalty
            // 
            this.m_tbctrlPlayerLoyalty.Controls.Add(this.m_tabPage_TierRule);
            this.m_tbctrlPlayerLoyalty.Controls.Add(this.m_tabPageTier);
            resources.ApplyResources(this.m_tbctrlPlayerLoyalty, "m_tbctrlPlayerLoyalty");
            this.m_tbctrlPlayerLoyalty.Name = "m_tbctrlPlayerLoyalty";
            this.m_tbctrlPlayerLoyalty.SelectedIndex = 0;
            this.m_tbctrlPlayerLoyalty.Tag = "1";
            // 
            // m_tabPage_TierRule
            // 
            this.m_tabPage_TierRule.BackColor = System.Drawing.Color.Transparent;
            this.m_tabPage_TierRule.Controls.Add(this.splitContainer2);
            resources.ApplyResources(this.m_tabPage_TierRule, "m_tabPage_TierRule");
            this.m_tabPage_TierRule.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_tabPage_TierRule.Name = "m_tabPage_TierRule";
            this.m_tabPage_TierRule.Tag = "1";
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(60)))), ((int)(((byte)(96)))));
            this.splitContainer2.Panel1Collapsed = true;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(179)))), ((int)(((byte)(213)))));
            this.splitContainer2.Panel2.Controls.Add(this.checkBox1);
            this.splitContainer2.Panel2.Controls.Add(this.button2);
            this.splitContainer2.Panel2.Controls.Add(this.button1);
            this.splitContainer2.Panel2.Controls.Add(this.m_btnCloseTierRule);
            this.splitContainer2.Panel2.Controls.Add(this.m_btnCancelTierRule);
            this.splitContainer2.Panel2.Controls.Add(this.m_btnEditSaveTierRule);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // m_btnCloseTierRule
            // 
            this.m_btnCloseTierRule.BackColor = System.Drawing.Color.Transparent;
            this.m_btnCloseTierRule.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCloseTierRule.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_btnCloseTierRule, "m_btnCloseTierRule");
            this.m_btnCloseTierRule.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_btnCloseTierRule.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_btnCloseTierRule.Name = "m_btnCloseTierRule";
            this.m_btnCloseTierRule.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_btnCloseTierRule.UseVisualStyleBackColor = false;
            this.m_btnCloseTierRule.Click += new System.EventHandler(this.m_btnCloseTierRule_Click);
            // 
            // m_btnCancelTierRule
            // 
            this.m_btnCancelTierRule.BackColor = System.Drawing.Color.Transparent;
            this.m_btnCancelTierRule.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_btnCancelTierRule, "m_btnCancelTierRule");
            this.m_btnCancelTierRule.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_btnCancelTierRule.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_btnCancelTierRule.Name = "m_btnCancelTierRule";
            this.m_btnCancelTierRule.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_btnCancelTierRule.UseVisualStyleBackColor = false;
            this.m_btnCancelTierRule.Click += new System.EventHandler(this.m_btnCancelTierRule_Click);
            // 
            // m_btnEditSaveTierRule
            // 
            this.m_btnEditSaveTierRule.BackColor = System.Drawing.Color.Transparent;
            this.m_btnEditSaveTierRule.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_btnEditSaveTierRule, "m_btnEditSaveTierRule");
            this.m_btnEditSaveTierRule.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_btnEditSaveTierRule.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_btnEditSaveTierRule.Name = "m_btnEditSaveTierRule";
            this.m_btnEditSaveTierRule.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_btnEditSaveTierRule.UseVisualStyleBackColor = false;
            this.m_btnEditSaveTierRule.Click += new System.EventHandler(this.m_btnEditSaveTierRule_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(179)))), ((int)(((byte)(213)))));
            this.groupBox1.Controls.Add(this.m_cmbxDowngradeToDefault);
            this.groupBox1.Controls.Add(this.m_lblTierRuleSavedSuccessNotification);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.m_cmbxDefaultTier);
            this.groupBox1.Controls.Add(this.labelRestart);
            this.groupBox1.Controls.Add(this.m_datetimepickerQualifyingPeriodEnd);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.m_datetimepickerQualifyingPeriodStart);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // m_cmbxDowngradeToDefault
            // 
            this.m_cmbxDowngradeToDefault.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.m_cmbxDowngradeToDefault, "m_cmbxDowngradeToDefault");
            this.m_cmbxDowngradeToDefault.FormattingEnabled = true;
            this.m_cmbxDowngradeToDefault.Items.AddRange(new object[] {
            resources.GetString("m_cmbxDowngradeToDefault.Items"),
            resources.GetString("m_cmbxDowngradeToDefault.Items1")});
            this.m_cmbxDowngradeToDefault.Name = "m_cmbxDowngradeToDefault";
            // 
            // m_lblTierRuleSavedSuccessNotification
            // 
            resources.ApplyResources(this.m_lblTierRuleSavedSuccessNotification, "m_lblTierRuleSavedSuccessNotification");
            this.m_lblTierRuleSavedSuccessNotification.Name = "m_lblTierRuleSavedSuccessNotification";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // m_cmbxDefaultTier
            // 
            this.m_cmbxDefaultTier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.m_cmbxDefaultTier, "m_cmbxDefaultTier");
            this.m_cmbxDefaultTier.FormattingEnabled = true;
            this.m_cmbxDefaultTier.Name = "m_cmbxDefaultTier";
            // 
            // labelRestart
            // 
            resources.ApplyResources(this.labelRestart, "labelRestart");
            this.labelRestart.Name = "labelRestart";
            // 
            // m_datetimepickerQualifyingPeriodEnd
            // 
            resources.ApplyResources(this.m_datetimepickerQualifyingPeriodEnd, "m_datetimepickerQualifyingPeriodEnd");
            this.m_datetimepickerQualifyingPeriodEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_datetimepickerQualifyingPeriodEnd.Name = "m_datetimepickerQualifyingPeriodEnd";
            this.m_datetimepickerQualifyingPeriodEnd.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateTierRuleQualifyingPeriodDate);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // m_datetimepickerQualifyingPeriodStart
            // 
            resources.ApplyResources(this.m_datetimepickerQualifyingPeriodStart, "m_datetimepickerQualifyingPeriodStart");
            this.m_datetimepickerQualifyingPeriodStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_datetimepickerQualifyingPeriodStart.Name = "m_datetimepickerQualifyingPeriodStart";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // m_tabPageTier
            // 
            this.m_tabPageTier.Controls.Add(this.splitContainer1);
            resources.ApplyResources(this.m_tabPageTier, "m_tabPageTier");
            this.m_tabPageTier.Name = "m_tabPageTier";
            this.m_tabPageTier.Tag = "2";
            this.m_tabPageTier.UseVisualStyleBackColor = true;
            // 
            // m_errorProvider
            // 
            this.m_errorProvider.ContainerControl = this;
            // 
            // PlayerLoyaltyForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(179)))), ((int)(((byte)(213)))));
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.m_tbctrlPlayerLoyalty);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PlayerLoyaltyForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.m_tbctrlPlayerLoyalty.ResumeLayout(false);
            this.m_tabPage_TierRule.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.m_tabPageTier.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl m_tbctrlPlayerLoyalty;
        private System.Windows.Forms.TabPage m_tabPageTier;
        private System.Windows.Forms.TabPage m_tabPage_TierRule;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Controls.ImageButton m_btnCancelTierRule;
        private Controls.ImageButton m_btnEditSaveTierRule;
        private System.Windows.Forms.ComboBox m_cmbxDefaultTier;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker m_datetimepickerQualifyingPeriodEnd;
        private System.Windows.Forms.DateTimePicker m_datetimepickerQualifyingPeriodStart;
        private System.Windows.Forms.Label labelRestart;
        private System.Windows.Forms.ComboBox m_cmbxDowngradeToDefault;
        public System.Windows.Forms.Label m_lblTierRuleSavedSuccessNotification;
        private System.Windows.Forms.ErrorProvider m_errorProvider;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Controls.ColorListBox m_lstboxTiers;
        private Controls.ImageButton m_btnAddTier;
        private Controls.ImageButton m_btnEditTier;
        public System.Windows.Forms.Label lbl_MessageSaved;
        private System.Windows.Forms.Label m_lblTierColor;
        private Controls.ImageButton m_btnDeleteTier;
        private Controls.ImageButton m_btnCancelTier;
        private Controls.ImageButton m_btnSaveTier;
        private System.Windows.Forms.TextBox m_txtbxAwardPointsMultiplier;
        private System.Windows.Forms.Label labelAwardPoints;
        private System.Windows.Forms.ComboBox m_cmbxQualifyingpoints;
        private System.Windows.Forms.ComboBox m_cmbxQualfyingSpend;
        private System.Windows.Forms.TextBox m_txtbxPointStart;
        private System.Windows.Forms.Label labelTierName;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.TextBox m_txtbxSpendStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelPointsStart;
        private System.Windows.Forms.Label labelPoints;
        private System.Windows.Forms.Label labelSpendStart;
        private System.Windows.Forms.Label labelSpend;
        private System.Windows.Forms.TextBox m_txtbxTierName;
        private System.Windows.Forms.GroupBox groupBox3;
        private Controls.ImageButton m_btnCloseTierRule;
        private Controls.ImageButton m_btnCloseTier;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;



    }
}