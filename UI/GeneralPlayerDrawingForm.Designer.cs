namespace GTI.Modules.PlayerCenter.UI
{
    partial class GeneralPlayerDrawingForm
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
            this.components = new System.ComponentModel.Container();
            this.drawingsLV = new System.Windows.Forms.ListView();
            this.drawingsLbl = new System.Windows.Forms.Label();
            this.newDrawingBtn = new GTI.Controls.ImageButton();
            this.editDrawingBtn = new GTI.Controls.ImageButton();
            this.showInactiveDrawingsChk = new System.Windows.Forms.CheckBox();
            this.drawingDetailsGB = new System.Windows.Forms.GroupBox();
            this.drawingDetailsTC = new System.Windows.Forms.TabControl();
            this.commonOptionsTP = new System.Windows.Forms.TabPage();
            this.entryLimitEventNoteLbl = new System.Windows.Forms.Label();
            this.maximumDrawsPerPlayerLbl = new System.Windows.Forms.Label();
            this.maximumDrawsPerPlayerTxt = new System.Windows.Forms.TextBox();
            this.drawingEntriesDrawnTxt = new System.Windows.Forms.TextBox();
            this.drawingEntriesDrawnLbl = new System.Windows.Forms.Label();
            this.drawingDescriptionTxt = new System.Windows.Forms.TextBox();
            this.entryLimitEventLbl = new System.Windows.Forms.Label();
            this.entryLimitEventTxt = new System.Windows.Forms.TextBox();
            this.drawingDescriptionLbl = new System.Windows.Forms.Label();
            this.minimumEntriesToRunLbl = new System.Windows.Forms.Label();
            this.playerPresenceRequiredChk = new System.Windows.Forms.CheckBox();
            this.showEntryCountOnReceiptsChk = new System.Windows.Forms.CheckBox();
            this.minimumEntriesToRunTxt = new System.Windows.Forms.TextBox();
            this.eventTP = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.entryPeriodLbl = new System.Windows.Forms.Label();
            this.initialEventEntryPeriodEndDTP = new System.Windows.Forms.DateTimePicker();
            this.initialEventEntryPeriodEndLbl = new System.Windows.Forms.Label();
            this.initialEventEntryPeriodBeginLbl = new System.Windows.Forms.Label();
            this.initialEventEntryPeriodBeginDTP = new System.Windows.Forms.DateTimePicker();
            this.entrySessionNumbersCL = new System.Windows.Forms.CheckedListBox();
            this.entrySessionsLbl = new System.Windows.Forms.Label();
            this.initialEventScheduledForLbl = new System.Windows.Forms.Label();
            this.m_pnlHideRepeats = new System.Windows.Forms.Panel();
            this.eventRepeatsChk = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.eventRepeatDetailsPnl = new System.Windows.Forms.Panel();
            this.eventRepeatIncrementTxt = new System.Windows.Forms.TextBox();
            this.eventRepetitionRateLbl = new System.Windows.Forms.Label();
            this.eventRepeatIntervalCB = new System.Windows.Forms.ComboBox();
            this.eventRepetitionEndsDTP = new System.Windows.Forms.DateTimePicker();
            this.eventRepetitionEndsLbl = new System.Windows.Forms.Label();
            this.eventExamplesLV = new System.Windows.Forms.ListView();
            this.initialEventScheduledForDTP = new System.Windows.Forms.DateTimePicker();
            this.eventWindowExamplesLbl = new System.Windows.Forms.Label();
            this.entryMethodsTP = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdobtnBoth = new System.Windows.Forms.RadioButton();
            this.rdobtnVisit = new System.Windows.Forms.RadioButton();
            this.rdobtn_Spend = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.entryMethodsTC = new System.Windows.Forms.TabControl();
            this.entryVisitsTP = new System.Windows.Forms.TabPage();
            this.addEntryVisitTierBtn = new GTI.Controls.ImageButton();
            this.entryVisitScaleDGV = new System.Windows.Forms.DataGridView();
            this.entryVisitsTypeFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.entryVisitTypeNoneRB = new System.Windows.Forms.RadioButton();
            this.entryVisitTypeSessionsPerDayRB = new System.Windows.Forms.RadioButton();
            this.entryVisitTypeSessionsInEntryPeriodRB = new System.Windows.Forms.RadioButton();
            this.entryVisitTypeDaysInEntryPeriodWindowRB = new System.Windows.Forms.RadioButton();
            this.entryPurchasesTP = new System.Windows.Forms.TabPage();
            this.entryPurchaseGroupingFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.entryPurchaseGroupingByTransactionRB = new System.Windows.Forms.RadioButton();
            this.entryPurchaseGroupingBySessionRB = new System.Windows.Forms.RadioButton();
            this.entryPurchaseGroupingByDayRB = new System.Windows.Forms.RadioButton();
            this.entryPurchaseGroupingEntryPeriodRB = new System.Windows.Forms.RadioButton();
            this.entryPurchaseSelectionsCL = new System.Windows.Forms.CheckedListBox();
            this.addEntryPurchaseTierBtn = new GTI.Controls.ImageButton();
            this.entryPurchaseScaleDGV = new System.Windows.Forms.DataGridView();
            this.entryPurchaseTypeFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.entryPurchaseTypeNoneRB = new System.Windows.Forms.RadioButton();
            this.entryPurchaseTypePackageRB = new System.Windows.Forms.RadioButton();
            this.entryPurchaseTypeProductRB = new System.Windows.Forms.RadioButton();
            this.entrySpendTP = new System.Windows.Forms.TabPage();
            this.addEntrySpendTierBtn = new GTI.Controls.ImageButton();
            this.entrySpendScaleDGV = new System.Windows.Forms.DataGridView();
            this.entrySpendGroupingFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.entrySpendGroupingBySessionRB = new System.Windows.Forms.RadioButton();
            this.entrySpendGroupingNoneRB = new System.Windows.Forms.RadioButton();
            this.entrySpendGroupingByTransactionRB = new System.Windows.Forms.RadioButton();
            this.entrySpendGroupingByDayRB = new System.Windows.Forms.RadioButton();
            this.entrySpendGroupingEntryPeriodRB = new System.Windows.Forms.RadioButton();
            this.drawingActiveChk = new System.Windows.Forms.CheckBox();
            this.drawingNameTxt = new System.Windows.Forms.TextBox();
            this.revertDrawingChangesBtn = new GTI.Controls.ImageButton();
            this.drawingNameLbl = new System.Windows.Forms.Label();
            this.cancelDrawingChangesBtn = new GTI.Controls.ImageButton();
            this.saveDrawingChangesBtn = new GTI.Controls.ImageButton();
            this.closeBtn = new GTI.Controls.ImageButton();
            this.copyDrawingBtn = new GTI.Controls.ImageButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.testEventsBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.drawingDetailsGB.SuspendLayout();
            this.drawingDetailsTC.SuspendLayout();
            this.commonOptionsTP.SuspendLayout();
            this.eventTP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.eventRepeatDetailsPnl.SuspendLayout();
            this.entryMethodsTP.SuspendLayout();
            this.panel3.SuspendLayout();
            this.entryMethodsTC.SuspendLayout();
            this.entryVisitsTP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entryVisitScaleDGV)).BeginInit();
            this.entryVisitsTypeFLP.SuspendLayout();
            this.entryPurchasesTP.SuspendLayout();
            this.entryPurchaseGroupingFLP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entryPurchaseScaleDGV)).BeginInit();
            this.entryPurchaseTypeFLP.SuspendLayout();
            this.entrySpendTP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entrySpendScaleDGV)).BeginInit();
            this.entrySpendGroupingFLP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // drawingsLV
            // 
            this.drawingsLV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.drawingsLV.Location = new System.Drawing.Point(10, 40);
            this.drawingsLV.MultiSelect = false;
            this.drawingsLV.Name = "drawingsLV";
            this.drawingsLV.Size = new System.Drawing.Size(263, 491);
            this.drawingsLV.TabIndex = 0;
            this.drawingsLV.UseCompatibleStateImageBehavior = false;
            this.drawingsLV.View = System.Windows.Forms.View.Details;
            this.drawingsLV.SelectedIndexChanged += new System.EventHandler(this.drawingsLV_SelectedIndexChanged);
            // 
            // drawingsLbl
            // 
            this.drawingsLbl.AutoSize = true;
            this.drawingsLbl.BackColor = System.Drawing.Color.Transparent;
            this.drawingsLbl.Location = new System.Drawing.Point(6, 9);
            this.drawingsLbl.Name = "drawingsLbl";
            this.drawingsLbl.Size = new System.Drawing.Size(80, 22);
            this.drawingsLbl.TabIndex = 1;
            this.drawingsLbl.Text = "Drawings";
            // 
            // newDrawingBtn
            // 
            this.newDrawingBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newDrawingBtn.BackColor = System.Drawing.Color.Transparent;
            this.newDrawingBtn.FocusColor = System.Drawing.Color.Black;
            this.newDrawingBtn.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.newDrawingBtn.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.newDrawingBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.newDrawingBtn.Location = new System.Drawing.Point(10, 539);
            this.newDrawingBtn.MinimumSize = new System.Drawing.Size(30, 30);
            this.newDrawingBtn.Name = "newDrawingBtn";
            this.newDrawingBtn.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.newDrawingBtn.Size = new System.Drawing.Size(260, 40);
            this.newDrawingBtn.TabIndex = 13;
            this.newDrawingBtn.Text = "New";
            this.newDrawingBtn.UseVisualStyleBackColor = false;
            this.newDrawingBtn.Click += new System.EventHandler(this.newDrawingBtn_Click);
            // 
            // editDrawingBtn
            // 
            this.editDrawingBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editDrawingBtn.BackColor = System.Drawing.Color.Transparent;
            this.editDrawingBtn.Enabled = false;
            this.editDrawingBtn.FocusColor = System.Drawing.Color.Black;
            this.editDrawingBtn.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.editDrawingBtn.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.editDrawingBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.editDrawingBtn.Location = new System.Drawing.Point(10, 632);
            this.editDrawingBtn.MinimumSize = new System.Drawing.Size(30, 30);
            this.editDrawingBtn.Name = "editDrawingBtn";
            this.editDrawingBtn.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.editDrawingBtn.Size = new System.Drawing.Size(260, 40);
            this.editDrawingBtn.TabIndex = 14;
            this.editDrawingBtn.Text = "Edit";
            this.editDrawingBtn.UseVisualStyleBackColor = false;
            this.editDrawingBtn.Click += new System.EventHandler(this.editDrawingBtn_Click);
            // 
            // showInactiveDrawingsChk
            // 
            this.showInactiveDrawingsChk.AutoSize = true;
            this.showInactiveDrawingsChk.BackColor = System.Drawing.Color.Transparent;
            this.showInactiveDrawingsChk.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showInactiveDrawingsChk.Location = new System.Drawing.Point(157, 12);
            this.showInactiveDrawingsChk.Name = "showInactiveDrawingsChk";
            this.showInactiveDrawingsChk.Size = new System.Drawing.Size(112, 22);
            this.showInactiveDrawingsChk.TabIndex = 15;
            this.showInactiveDrawingsChk.Text = "Show Inactive";
            this.showInactiveDrawingsChk.UseVisualStyleBackColor = false;
            this.showInactiveDrawingsChk.CheckedChanged += new System.EventHandler(this.showInactiveDrawingsChk_CheckedChanged);
            // 
            // drawingDetailsGB
            // 
            this.drawingDetailsGB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingDetailsGB.BackgroundImage = global::GTI.Modules.PlayerCenter.Properties.Resources.BG00;
            this.drawingDetailsGB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.drawingDetailsGB.Controls.Add(this.drawingDetailsTC);
            this.drawingDetailsGB.Controls.Add(this.drawingActiveChk);
            this.drawingDetailsGB.Controls.Add(this.drawingNameTxt);
            this.drawingDetailsGB.Controls.Add(this.revertDrawingChangesBtn);
            this.drawingDetailsGB.Controls.Add(this.drawingNameLbl);
            this.drawingDetailsGB.Controls.Add(this.cancelDrawingChangesBtn);
            this.drawingDetailsGB.Controls.Add(this.saveDrawingChangesBtn);
            this.drawingDetailsGB.Location = new System.Drawing.Point(284, 12);
            this.drawingDetailsGB.Name = "drawingDetailsGB";
            this.drawingDetailsGB.Size = new System.Drawing.Size(722, 608);
            this.drawingDetailsGB.TabIndex = 16;
            this.drawingDetailsGB.TabStop = false;
            this.drawingDetailsGB.Text = "Details";
            this.drawingDetailsGB.Visible = false;
            // 
            // drawingDetailsTC
            // 
            this.drawingDetailsTC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingDetailsTC.Controls.Add(this.commonOptionsTP);
            this.drawingDetailsTC.Controls.Add(this.eventTP);
            this.drawingDetailsTC.Controls.Add(this.entryMethodsTP);
            this.drawingDetailsTC.Location = new System.Drawing.Point(14, 69);
            this.drawingDetailsTC.Name = "drawingDetailsTC";
            this.drawingDetailsTC.SelectedIndex = 0;
            this.drawingDetailsTC.Size = new System.Drawing.Size(695, 484);
            this.drawingDetailsTC.TabIndex = 19;
            // 
            // commonOptionsTP
            // 
            this.commonOptionsTP.BackColor = System.Drawing.Color.LightSteelBlue;
            this.commonOptionsTP.Controls.Add(this.entryLimitEventNoteLbl);
            this.commonOptionsTP.Controls.Add(this.maximumDrawsPerPlayerLbl);
            this.commonOptionsTP.Controls.Add(this.maximumDrawsPerPlayerTxt);
            this.commonOptionsTP.Controls.Add(this.drawingEntriesDrawnTxt);
            this.commonOptionsTP.Controls.Add(this.drawingEntriesDrawnLbl);
            this.commonOptionsTP.Controls.Add(this.drawingDescriptionTxt);
            this.commonOptionsTP.Controls.Add(this.entryLimitEventLbl);
            this.commonOptionsTP.Controls.Add(this.entryLimitEventTxt);
            this.commonOptionsTP.Controls.Add(this.drawingDescriptionLbl);
            this.commonOptionsTP.Controls.Add(this.minimumEntriesToRunLbl);
            this.commonOptionsTP.Controls.Add(this.playerPresenceRequiredChk);
            this.commonOptionsTP.Controls.Add(this.showEntryCountOnReceiptsChk);
            this.commonOptionsTP.Controls.Add(this.minimumEntriesToRunTxt);
            this.commonOptionsTP.Location = new System.Drawing.Point(4, 31);
            this.commonOptionsTP.Name = "commonOptionsTP";
            this.commonOptionsTP.Padding = new System.Windows.Forms.Padding(3);
            this.commonOptionsTP.Size = new System.Drawing.Size(687, 449);
            this.commonOptionsTP.TabIndex = 0;
            this.commonOptionsTP.Text = "Common";
            // 
            // entryLimitEventNoteLbl
            // 
            this.entryLimitEventNoteLbl.AutoSize = true;
            this.entryLimitEventNoteLbl.BackColor = System.Drawing.Color.Transparent;
            this.entryLimitEventNoteLbl.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryLimitEventNoteLbl.Location = new System.Drawing.Point(324, 220);
            this.entryLimitEventNoteLbl.Name = "entryLimitEventNoteLbl";
            this.entryLimitEventNoteLbl.Size = new System.Drawing.Size(165, 18);
            this.entryLimitEventNoteLbl.TabIndex = 29;
            this.entryLimitEventNoteLbl.Text = "leave empty for no limit";
            // 
            // maximumDrawsPerPlayerLbl
            // 
            this.maximumDrawsPerPlayerLbl.BackColor = System.Drawing.Color.Transparent;
            this.maximumDrawsPerPlayerLbl.Location = new System.Drawing.Point(6, 186);
            this.maximumDrawsPerPlayerLbl.Name = "maximumDrawsPerPlayerLbl";
            this.maximumDrawsPerPlayerLbl.Size = new System.Drawing.Size(240, 22);
            this.maximumDrawsPerPlayerLbl.TabIndex = 27;
            this.maximumDrawsPerPlayerLbl.Text = "Maximum wins per player";
            // 
            // maximumDrawsPerPlayerTxt
            // 
            this.maximumDrawsPerPlayerTxt.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maximumDrawsPerPlayerTxt.Location = new System.Drawing.Point(252, 184);
            this.maximumDrawsPerPlayerTxt.Name = "maximumDrawsPerPlayerTxt";
            this.maximumDrawsPerPlayerTxt.Size = new System.Drawing.Size(65, 26);
            this.maximumDrawsPerPlayerTxt.TabIndex = 28;
            this.maximumDrawsPerPlayerTxt.TextChanged += new System.EventHandler(this.requiredUIntTxt_TextChanged);
            this.maximumDrawsPerPlayerTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.requiredIntTxt_KeyPress);
            // 
            // drawingEntriesDrawnTxt
            // 
            this.drawingEntriesDrawnTxt.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawingEntriesDrawnTxt.Location = new System.Drawing.Point(252, 120);
            this.drawingEntriesDrawnTxt.Name = "drawingEntriesDrawnTxt";
            this.drawingEntriesDrawnTxt.Size = new System.Drawing.Size(65, 26);
            this.drawingEntriesDrawnTxt.TabIndex = 26;
            this.drawingEntriesDrawnTxt.TextChanged += new System.EventHandler(this.requiredUIntTxt_TextChanged);
            this.drawingEntriesDrawnTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.requiredIntTxt_KeyPress);
            this.drawingEntriesDrawnTxt.Validating += new System.ComponentModel.CancelEventHandler(this.drawingEntriesDrawnTxt_Validating);
            // 
            // drawingEntriesDrawnLbl
            // 
            this.drawingEntriesDrawnLbl.BackColor = System.Drawing.Color.Transparent;
            this.drawingEntriesDrawnLbl.Location = new System.Drawing.Point(6, 122);
            this.drawingEntriesDrawnLbl.Name = "drawingEntriesDrawnLbl";
            this.drawingEntriesDrawnLbl.Size = new System.Drawing.Size(240, 22);
            this.drawingEntriesDrawnLbl.TabIndex = 25;
            this.drawingEntriesDrawnLbl.Text = "Number of winners";
            // 
            // drawingDescriptionTxt
            // 
            this.drawingDescriptionTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingDescriptionTxt.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawingDescriptionTxt.Location = new System.Drawing.Point(252, 14);
            this.drawingDescriptionTxt.Multiline = true;
            this.drawingDescriptionTxt.Name = "drawingDescriptionTxt";
            this.drawingDescriptionTxt.Size = new System.Drawing.Size(423, 100);
            this.drawingDescriptionTxt.TabIndex = 20;
            // 
            // entryLimitEventLbl
            // 
            this.entryLimitEventLbl.BackColor = System.Drawing.Color.Transparent;
            this.entryLimitEventLbl.Location = new System.Drawing.Point(7, 218);
            this.entryLimitEventLbl.Name = "entryLimitEventLbl";
            this.entryLimitEventLbl.Size = new System.Drawing.Size(240, 22);
            this.entryLimitEventLbl.TabIndex = 15;
            this.entryLimitEventLbl.Text = "Maximum entries per player";
            // 
            // entryLimitEventTxt
            // 
            this.entryLimitEventTxt.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryLimitEventTxt.Location = new System.Drawing.Point(252, 216);
            this.entryLimitEventTxt.Margin = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.entryLimitEventTxt.Name = "entryLimitEventTxt";
            this.entryLimitEventTxt.Size = new System.Drawing.Size(65, 26);
            this.entryLimitEventTxt.TabIndex = 0;
            this.entryLimitEventTxt.TextChanged += new System.EventHandler(this.entryLimitTxt_TextChanged);
            this.entryLimitEventTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.entryLimitTxt_KeyPress);
            this.entryLimitEventTxt.Validating += new System.ComponentModel.CancelEventHandler(this.entryLimitEventTxt_Validating);
            // 
            // drawingDescriptionLbl
            // 
            this.drawingDescriptionLbl.BackColor = System.Drawing.Color.Transparent;
            this.drawingDescriptionLbl.Location = new System.Drawing.Point(6, 17);
            this.drawingDescriptionLbl.Name = "drawingDescriptionLbl";
            this.drawingDescriptionLbl.Size = new System.Drawing.Size(98, 22);
            this.drawingDescriptionLbl.TabIndex = 20;
            this.drawingDescriptionLbl.Text = "Description";
            // 
            // minimumEntriesToRunLbl
            // 
            this.minimumEntriesToRunLbl.BackColor = System.Drawing.Color.Transparent;
            this.minimumEntriesToRunLbl.Location = new System.Drawing.Point(6, 154);
            this.minimumEntriesToRunLbl.Name = "minimumEntriesToRunLbl";
            this.minimumEntriesToRunLbl.Size = new System.Drawing.Size(240, 22);
            this.minimumEntriesToRunLbl.TabIndex = 22;
            this.minimumEntriesToRunLbl.Text = "Minimum entries needed";
            // 
            // playerPresenceRequiredChk
            // 
            this.playerPresenceRequiredChk.AutoSize = true;
            this.playerPresenceRequiredChk.BackColor = System.Drawing.Color.Transparent;
            this.playerPresenceRequiredChk.Location = new System.Drawing.Point(10, 252);
            this.playerPresenceRequiredChk.Name = "playerPresenceRequiredChk";
            this.playerPresenceRequiredChk.Size = new System.Drawing.Size(254, 26);
            this.playerPresenceRequiredChk.TabIndex = 24;
            this.playerPresenceRequiredChk.Text = "Player must be present to win";
            this.playerPresenceRequiredChk.UseVisualStyleBackColor = false;
            // 
            // showEntryCountOnReceiptsChk
            // 
            this.showEntryCountOnReceiptsChk.AutoSize = true;
            this.showEntryCountOnReceiptsChk.BackColor = System.Drawing.Color.Transparent;
            this.showEntryCountOnReceiptsChk.Location = new System.Drawing.Point(10, 291);
            this.showEntryCountOnReceiptsChk.Name = "showEntryCountOnReceiptsChk";
            this.showEntryCountOnReceiptsChk.Size = new System.Drawing.Size(291, 26);
            this.showEntryCountOnReceiptsChk.TabIndex = 16;
            this.showEntryCountOnReceiptsChk.Text = "Print player entry count on receipt";
            this.showEntryCountOnReceiptsChk.UseVisualStyleBackColor = false;
            // 
            // minimumEntriesToRunTxt
            // 
            this.minimumEntriesToRunTxt.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimumEntriesToRunTxt.Location = new System.Drawing.Point(252, 152);
            this.minimumEntriesToRunTxt.Name = "minimumEntriesToRunTxt";
            this.minimumEntriesToRunTxt.Size = new System.Drawing.Size(65, 26);
            this.minimumEntriesToRunTxt.TabIndex = 23;
            this.minimumEntriesToRunTxt.TextChanged += new System.EventHandler(this.requiredUIntTxt_TextChanged);
            this.minimumEntriesToRunTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.requiredIntTxt_KeyPress);
            // 
            // eventTP
            // 
            this.eventTP.BackColor = System.Drawing.Color.LightSteelBlue;
            this.eventTP.Controls.Add(this.splitContainer1);
            this.eventTP.Location = new System.Drawing.Point(4, 31);
            this.eventTP.Name = "eventTP";
            this.eventTP.Padding = new System.Windows.Forms.Padding(3);
            this.eventTP.Size = new System.Drawing.Size(687, 449);
            this.eventTP.TabIndex = 1;
            this.eventTP.Text = "Scheduling";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.entryPeriodLbl);
            this.splitContainer1.Panel1.Controls.Add(this.initialEventEntryPeriodEndDTP);
            this.splitContainer1.Panel1.Controls.Add(this.initialEventEntryPeriodEndLbl);
            this.splitContainer1.Panel1.Controls.Add(this.initialEventEntryPeriodBeginLbl);
            this.splitContainer1.Panel1.Controls.Add(this.initialEventEntryPeriodBeginDTP);
            this.splitContainer1.Panel1.Controls.Add(this.entrySessionNumbersCL);
            this.splitContainer1.Panel1.Controls.Add(this.entrySessionsLbl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.initialEventScheduledForLbl);
            this.splitContainer1.Panel2.Controls.Add(this.m_pnlHideRepeats);
            this.splitContainer1.Panel2.Controls.Add(this.eventRepeatsChk);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.eventRepeatDetailsPnl);
            this.splitContainer1.Panel2.Controls.Add(this.eventExamplesLV);
            this.splitContainer1.Panel2.Controls.Add(this.initialEventScheduledForDTP);
            this.splitContainer1.Panel2.Controls.Add(this.eventWindowExamplesLbl);
            this.splitContainer1.Size = new System.Drawing.Size(681, 443);
            this.splitContainer1.SplitterDistance = 340;
            this.splitContainer1.TabIndex = 42;
            // 
            // entryPeriodLbl
            // 
            this.entryPeriodLbl.BackColor = System.Drawing.Color.Transparent;
            this.entryPeriodLbl.Location = new System.Drawing.Point(3, 16);
            this.entryPeriodLbl.Name = "entryPeriodLbl";
            this.entryPeriodLbl.Size = new System.Drawing.Size(123, 22);
            this.entryPeriodLbl.TabIndex = 37;
            this.entryPeriodLbl.Text = "Entry period";
            // 
            // initialEventEntryPeriodEndDTP
            // 
            this.initialEventEntryPeriodEndDTP.CustomFormat = "ddd dd MMM yyyy";
            this.initialEventEntryPeriodEndDTP.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.initialEventEntryPeriodEndDTP.Location = new System.Drawing.Point(141, 75);
            this.initialEventEntryPeriodEndDTP.Name = "initialEventEntryPeriodEndDTP";
            this.initialEventEntryPeriodEndDTP.Size = new System.Drawing.Size(192, 26);
            this.initialEventEntryPeriodEndDTP.TabIndex = 23;
            this.initialEventEntryPeriodEndDTP.ValueChanged += new System.EventHandler(this.initialEventEntryPeriodEndDTP_ValueChanged);
            this.initialEventEntryPeriodEndDTP.Validating += new System.ComponentModel.CancelEventHandler(this.initialEventEntryPeriodEndDTP_Validating);
            // 
            // initialEventEntryPeriodEndLbl
            // 
            this.initialEventEntryPeriodEndLbl.BackColor = System.Drawing.Color.Transparent;
            this.initialEventEntryPeriodEndLbl.Location = new System.Drawing.Point(44, 79);
            this.initialEventEntryPeriodEndLbl.Name = "initialEventEntryPeriodEndLbl";
            this.initialEventEntryPeriodEndLbl.Size = new System.Drawing.Size(54, 22);
            this.initialEventEntryPeriodEndLbl.TabIndex = 24;
            this.initialEventEntryPeriodEndLbl.Text = "Ends";
            // 
            // initialEventEntryPeriodBeginLbl
            // 
            this.initialEventEntryPeriodBeginLbl.BackColor = System.Drawing.Color.Transparent;
            this.initialEventEntryPeriodBeginLbl.Location = new System.Drawing.Point(44, 47);
            this.initialEventEntryPeriodBeginLbl.Name = "initialEventEntryPeriodBeginLbl";
            this.initialEventEntryPeriodBeginLbl.Size = new System.Drawing.Size(60, 22);
            this.initialEventEntryPeriodBeginLbl.TabIndex = 21;
            this.initialEventEntryPeriodBeginLbl.Text = "Begins";
            // 
            // initialEventEntryPeriodBeginDTP
            // 
            this.initialEventEntryPeriodBeginDTP.CustomFormat = "ddd dd MMM yyyy";
            this.initialEventEntryPeriodBeginDTP.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.initialEventEntryPeriodBeginDTP.Location = new System.Drawing.Point(143, 43);
            this.initialEventEntryPeriodBeginDTP.Name = "initialEventEntryPeriodBeginDTP";
            this.initialEventEntryPeriodBeginDTP.Size = new System.Drawing.Size(190, 26);
            this.initialEventEntryPeriodBeginDTP.TabIndex = 22;
            this.initialEventEntryPeriodBeginDTP.ValueChanged += new System.EventHandler(this.initialEventEntryPeriodBeginDTP_ValueChanged);
            this.initialEventEntryPeriodBeginDTP.Validating += new System.ComponentModel.CancelEventHandler(this.initialEventEntryPeriodBeginDTP_Validating);
            // 
            // entrySessionNumbersCL
            // 
            this.entrySessionNumbersCL.CheckOnClick = true;
            this.entrySessionNumbersCL.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entrySessionNumbersCL.FormattingEnabled = true;
            this.entrySessionNumbersCL.IntegralHeight = false;
            this.entrySessionNumbersCL.Location = new System.Drawing.Point(9, 145);
            this.entrySessionNumbersCL.MultiColumn = true;
            this.entrySessionNumbersCL.Name = "entrySessionNumbersCL";
            this.entrySessionNumbersCL.Size = new System.Drawing.Size(324, 214);
            this.entrySessionNumbersCL.TabIndex = 0;
            this.entrySessionNumbersCL.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.entrySessionNumbersCL_ItemCheck);
            // 
            // entrySessionsLbl
            // 
            this.entrySessionsLbl.BackColor = System.Drawing.Color.Transparent;
            this.entrySessionsLbl.Location = new System.Drawing.Point(6, 123);
            this.entrySessionsLbl.Name = "entrySessionsLbl";
            this.entrySessionsLbl.Size = new System.Drawing.Size(112, 22);
            this.entrySessionsLbl.TabIndex = 30;
            this.entrySessionsLbl.Text = "Session(s)";
            // 
            // initialEventScheduledForLbl
            // 
            this.initialEventScheduledForLbl.BackColor = System.Drawing.Color.Transparent;
            this.initialEventScheduledForLbl.Location = new System.Drawing.Point(9, 16);
            this.initialEventScheduledForLbl.Name = "initialEventScheduledForLbl";
            this.initialEventScheduledForLbl.Size = new System.Drawing.Size(123, 22);
            this.initialEventScheduledForLbl.TabIndex = 36;
            this.initialEventScheduledForLbl.Text = "Scheduled for";
            // 
            // m_pnlHideRepeats
            // 
            this.m_pnlHideRepeats.Location = new System.Drawing.Point(31, 107);
            this.m_pnlHideRepeats.Name = "m_pnlHideRepeats";
            this.m_pnlHideRepeats.Size = new System.Drawing.Size(304, 106);
            this.m_pnlHideRepeats.TabIndex = 41;
            // 
            // eventRepeatsChk
            // 
            this.eventRepeatsChk.AutoSize = true;
            this.eventRepeatsChk.Location = new System.Drawing.Point(9, 83);
            this.eventRepeatsChk.Name = "eventRepeatsChk";
            this.eventRepeatsChk.Size = new System.Drawing.Size(88, 26);
            this.eventRepeatsChk.TabIndex = 25;
            this.eventRepeatsChk.Text = "Repeats";
            this.eventRepeatsChk.UseVisualStyleBackColor = true;
            this.eventRepeatsChk.CheckedChanged += new System.EventHandler(this.eventRepeatsChk_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(14, 326);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(278, 78);
            this.panel2.TabIndex = 40;
            // 
            // eventRepeatDetailsPnl
            // 
            this.eventRepeatDetailsPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.eventRepeatDetailsPnl.Controls.Add(this.eventRepeatIncrementTxt);
            this.eventRepeatDetailsPnl.Controls.Add(this.eventRepetitionRateLbl);
            this.eventRepeatDetailsPnl.Controls.Add(this.eventRepeatIntervalCB);
            this.eventRepeatDetailsPnl.Controls.Add(this.eventRepetitionEndsDTP);
            this.eventRepeatDetailsPnl.Controls.Add(this.eventRepetitionEndsLbl);
            this.eventRepeatDetailsPnl.Enabled = false;
            this.eventRepeatDetailsPnl.Location = new System.Drawing.Point(30, 110);
            this.eventRepeatDetailsPnl.Name = "eventRepeatDetailsPnl";
            this.eventRepeatDetailsPnl.Size = new System.Drawing.Size(286, 83);
            this.eventRepeatDetailsPnl.TabIndex = 34;
            // 
            // eventRepeatIncrementTxt
            // 
            this.eventRepeatIncrementTxt.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventRepeatIncrementTxt.Location = new System.Drawing.Point(81, 10);
            this.eventRepeatIncrementTxt.Multiline = true;
            this.eventRepeatIncrementTxt.Name = "eventRepeatIncrementTxt";
            this.eventRepeatIncrementTxt.Size = new System.Drawing.Size(106, 30);
            this.eventRepeatIncrementTxt.TabIndex = 38;
            this.eventRepeatIncrementTxt.TextChanged += new System.EventHandler(this.eventRepeatIncrementTxt_TextChanged);
            this.eventRepeatIncrementTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.entryPeriodRepeatIncrementTxt_KeyPress);
            this.eventRepeatIncrementTxt.Validating += new System.ComponentModel.CancelEventHandler(this.eventRepeatIncrementTxt_Validating);
            // 
            // eventRepetitionRateLbl
            // 
            this.eventRepetitionRateLbl.BackColor = System.Drawing.Color.Transparent;
            this.eventRepetitionRateLbl.Location = new System.Drawing.Point(3, 14);
            this.eventRepetitionRateLbl.Name = "eventRepetitionRateLbl";
            this.eventRepetitionRateLbl.Size = new System.Drawing.Size(54, 22);
            this.eventRepetitionRateLbl.TabIndex = 35;
            this.eventRepetitionRateLbl.Text = "Every";
            // 
            // eventRepeatIntervalCB
            // 
            this.eventRepeatIntervalCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventRepeatIntervalCB.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventRepeatIntervalCB.FormattingEnabled = true;
            this.eventRepeatIntervalCB.Items.AddRange(new object[] {
            "year",
            "quarter",
            "month",
            "day",
            "week"});
            this.eventRepeatIntervalCB.Location = new System.Drawing.Point(192, 10);
            this.eventRepeatIntervalCB.Name = "eventRepeatIntervalCB";
            this.eventRepeatIntervalCB.Size = new System.Drawing.Size(82, 30);
            this.eventRepeatIntervalCB.TabIndex = 27;
            this.eventRepeatIntervalCB.SelectedIndexChanged += new System.EventHandler(this.eventRepeatIntervalCB_SelectedIndexChanged);
            // 
            // eventRepetitionEndsDTP
            // 
            this.eventRepetitionEndsDTP.Checked = false;
            this.eventRepetitionEndsDTP.CustomFormat = "ddd dd MMM yyyy";
            this.eventRepetitionEndsDTP.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventRepetitionEndsDTP.Location = new System.Drawing.Point(82, 43);
            this.eventRepetitionEndsDTP.Name = "eventRepetitionEndsDTP";
            this.eventRepetitionEndsDTP.ShowCheckBox = true;
            this.eventRepetitionEndsDTP.Size = new System.Drawing.Size(192, 26);
            this.eventRepetitionEndsDTP.TabIndex = 28;
            this.eventRepetitionEndsDTP.ValueChanged += new System.EventHandler(this.eventRepetitionEndsDTP_ValueChanged);
            // 
            // eventRepetitionEndsLbl
            // 
            this.eventRepetitionEndsLbl.BackColor = System.Drawing.Color.Transparent;
            this.eventRepetitionEndsLbl.Location = new System.Drawing.Point(4, 47);
            this.eventRepetitionEndsLbl.Name = "eventRepetitionEndsLbl";
            this.eventRepetitionEndsLbl.Size = new System.Drawing.Size(54, 22);
            this.eventRepetitionEndsLbl.TabIndex = 29;
            this.eventRepetitionEndsLbl.Text = "Until";
            // 
            // eventExamplesLV
            // 
            this.eventExamplesLV.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventExamplesLV.Location = new System.Drawing.Point(21, 353);
            this.eventExamplesLV.Name = "eventExamplesLV";
            this.eventExamplesLV.Size = new System.Drawing.Size(242, 46);
            this.eventExamplesLV.TabIndex = 39;
            this.eventExamplesLV.UseCompatibleStateImageBehavior = false;
            this.eventExamplesLV.View = System.Windows.Forms.View.Details;
            // 
            // initialEventScheduledForDTP
            // 
            this.initialEventScheduledForDTP.Checked = false;
            this.initialEventScheduledForDTP.CustomFormat = "ddd dd MMM yyyy";
            this.initialEventScheduledForDTP.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.initialEventScheduledForDTP.Location = new System.Drawing.Point(133, 12);
            this.initialEventScheduledForDTP.Name = "initialEventScheduledForDTP";
            this.initialEventScheduledForDTP.ShowCheckBox = true;
            this.initialEventScheduledForDTP.Size = new System.Drawing.Size(192, 26);
            this.initialEventScheduledForDTP.TabIndex = 35;
            this.initialEventScheduledForDTP.ValueChanged += new System.EventHandler(this.initialEventScheduledForDTP_ValueChanged);
            this.initialEventScheduledForDTP.Validating += new System.ComponentModel.CancelEventHandler(this.initialEventScheduledForDTP_Validating);
            // 
            // eventWindowExamplesLbl
            // 
            this.eventWindowExamplesLbl.BackColor = System.Drawing.Color.Transparent;
            this.eventWindowExamplesLbl.Location = new System.Drawing.Point(16, 331);
            this.eventWindowExamplesLbl.Name = "eventWindowExamplesLbl";
            this.eventWindowExamplesLbl.Size = new System.Drawing.Size(141, 22);
            this.eventWindowExamplesLbl.TabIndex = 37;
            this.eventWindowExamplesLbl.Text = "Event examples";
            // 
            // entryMethodsTP
            // 
            this.entryMethodsTP.BackColor = System.Drawing.Color.LightSteelBlue;
            this.entryMethodsTP.Controls.Add(this.panel3);
            this.entryMethodsTP.Controls.Add(this.label1);
            this.entryMethodsTP.Controls.Add(this.entryMethodsTC);
            this.entryMethodsTP.Location = new System.Drawing.Point(4, 31);
            this.entryMethodsTP.Name = "entryMethodsTP";
            this.entryMethodsTP.Padding = new System.Windows.Forms.Padding(3);
            this.entryMethodsTP.Size = new System.Drawing.Size(687, 449);
            this.entryMethodsTP.TabIndex = 2;
            this.entryMethodsTP.Text = "Entry Methods";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rdobtnBoth);
            this.panel3.Controls.Add(this.rdobtnVisit);
            this.panel3.Controls.Add(this.rdobtn_Spend);
            this.panel3.Location = new System.Drawing.Point(248, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(401, 30);
            this.panel3.TabIndex = 6;
            // 
            // rdobtnBoth
            // 
            this.rdobtnBoth.AutoSize = true;
            this.rdobtnBoth.Location = new System.Drawing.Point(211, 3);
            this.rdobtnBoth.Name = "rdobtnBoth";
            this.rdobtnBoth.Size = new System.Drawing.Size(63, 26);
            this.rdobtnBoth.TabIndex = 2;
            this.rdobtnBoth.Tag = "3";
            this.rdobtnBoth.Text = "Both";
            this.rdobtnBoth.UseVisualStyleBackColor = true;
            this.rdobtnBoth.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rdobtnVisit
            // 
            this.rdobtnVisit.AutoSize = true;
            this.rdobtnVisit.Location = new System.Drawing.Point(117, 3);
            this.rdobtnVisit.Name = "rdobtnVisit";
            this.rdobtnVisit.Size = new System.Drawing.Size(61, 26);
            this.rdobtnVisit.TabIndex = 1;
            this.rdobtnVisit.Tag = "2";
            this.rdobtnVisit.Text = "Visit";
            this.rdobtnVisit.UseVisualStyleBackColor = true;
            this.rdobtnVisit.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rdobtn_Spend
            // 
            this.rdobtn_Spend.AutoSize = true;
            this.rdobtn_Spend.Location = new System.Drawing.Point(16, 3);
            this.rdobtn_Spend.Name = "rdobtn_Spend";
            this.rdobtn_Spend.Size = new System.Drawing.Size(72, 26);
            this.rdobtn_Spend.TabIndex = 0;
            this.rdobtn_Spend.Tag = "1";
            this.rdobtn_Spend.Text = "Spend";
            this.rdobtn_Spend.UseVisualStyleBackColor = true;
            this.rdobtn_Spend.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter players based on";
            // 
            // entryMethodsTC
            // 
            this.entryMethodsTC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entryMethodsTC.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.entryMethodsTC.Controls.Add(this.entryVisitsTP);
            this.entryMethodsTC.Controls.Add(this.entryPurchasesTP);
            this.entryMethodsTC.Controls.Add(this.entrySpendTP);
            this.entryMethodsTC.ItemSize = new System.Drawing.Size(0, 1);
            this.entryMethodsTC.Location = new System.Drawing.Point(7, 44);
            this.entryMethodsTC.Name = "entryMethodsTC";
            this.entryMethodsTC.SelectedIndex = 0;
            this.entryMethodsTC.Size = new System.Drawing.Size(671, 318);
            this.entryMethodsTC.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.entryMethodsTC.TabIndex = 4;
            // 
            // entryVisitsTP
            // 
            this.entryVisitsTP.BackColor = System.Drawing.Color.LightSteelBlue;
            this.entryVisitsTP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.entryVisitsTP.Controls.Add(this.addEntryVisitTierBtn);
            this.entryVisitsTP.Controls.Add(this.entryVisitScaleDGV);
            this.entryVisitsTP.Controls.Add(this.entryVisitsTypeFLP);
            this.entryVisitsTP.Location = new System.Drawing.Point(4, 5);
            this.entryVisitsTP.Name = "entryVisitsTP";
            this.entryVisitsTP.Padding = new System.Windows.Forms.Padding(3);
            this.entryVisitsTP.Size = new System.Drawing.Size(663, 309);
            this.entryVisitsTP.TabIndex = 1;
            this.entryVisitsTP.Text = "Visit";
            // 
            // addEntryVisitTierBtn
            // 
            this.addEntryVisitTierBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addEntryVisitTierBtn.FocusColor = System.Drawing.Color.Black;
            this.addEntryVisitTierBtn.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.addEntryVisitTierBtn.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.addEntryVisitTierBtn.Location = new System.Drawing.Point(561, 269);
            this.addEntryVisitTierBtn.MinimumSize = new System.Drawing.Size(30, 30);
            this.addEntryVisitTierBtn.Name = "addEntryVisitTierBtn";
            this.addEntryVisitTierBtn.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.addEntryVisitTierBtn.Size = new System.Drawing.Size(75, 30);
            this.addEntryVisitTierBtn.TabIndex = 8;
            this.addEntryVisitTierBtn.Text = "+";
            this.addEntryVisitTierBtn.Visible = false;
            this.addEntryVisitTierBtn.Click += new System.EventHandler(this.addEntryVisitTierBtn_Click);
            // 
            // entryVisitScaleDGV
            // 
            this.entryVisitScaleDGV.AllowUserToAddRows = false;
            this.entryVisitScaleDGV.AllowUserToDeleteRows = false;
            this.entryVisitScaleDGV.AllowUserToResizeRows = false;
            this.entryVisitScaleDGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.entryVisitScaleDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.entryVisitScaleDGV.Location = new System.Drawing.Point(151, 14);
            this.entryVisitScaleDGV.MultiSelect = false;
            this.entryVisitScaleDGV.Name = "entryVisitScaleDGV";
            this.entryVisitScaleDGV.RowHeadersVisible = false;
            this.entryVisitScaleDGV.RowTemplate.Height = 30;
            this.entryVisitScaleDGV.Size = new System.Drawing.Size(502, 245);
            this.entryVisitScaleDGV.TabIndex = 7;
            this.entryVisitScaleDGV.Visible = false;
            this.entryVisitScaleDGV.Validating += new System.ComponentModel.CancelEventHandler(this.entrySpendScaleDGV_Validating);
            // 
            // entryVisitsTypeFLP
            // 
            this.entryVisitsTypeFLP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entryVisitsTypeFLP.Controls.Add(this.entryVisitTypeNoneRB);
            this.entryVisitsTypeFLP.Controls.Add(this.entryVisitTypeSessionsPerDayRB);
            this.entryVisitsTypeFLP.Controls.Add(this.entryVisitTypeSessionsInEntryPeriodRB);
            this.entryVisitsTypeFLP.Controls.Add(this.entryVisitTypeDaysInEntryPeriodWindowRB);
            this.entryVisitsTypeFLP.Location = new System.Drawing.Point(6, 14);
            this.entryVisitsTypeFLP.Name = "entryVisitsTypeFLP";
            this.entryVisitsTypeFLP.Size = new System.Drawing.Size(138, 326);
            this.entryVisitsTypeFLP.TabIndex = 6;
            // 
            // entryVisitTypeNoneRB
            // 
            this.entryVisitTypeNoneRB.AutoSize = true;
            this.entryVisitTypeNoneRB.Location = new System.Drawing.Point(3, 3);
            this.entryVisitTypeNoneRB.Name = "entryVisitTypeNoneRB";
            this.entryVisitTypeNoneRB.Size = new System.Drawing.Size(67, 26);
            this.entryVisitTypeNoneRB.TabIndex = 6;
            this.entryVisitTypeNoneRB.Text = "None";
            this.entryVisitTypeNoneRB.UseVisualStyleBackColor = true;
            this.entryVisitTypeNoneRB.CheckedChanged += new System.EventHandler(this.entryVisitTypeRB_CheckedChanged);
            // 
            // entryVisitTypeSessionsPerDayRB
            // 
            this.entryVisitTypeSessionsPerDayRB.AutoSize = true;
            this.entryVisitTypeSessionsPerDayRB.Location = new System.Drawing.Point(3, 35);
            this.entryVisitTypeSessionsPerDayRB.Name = "entryVisitTypeSessionsPerDayRB";
            this.entryVisitTypeSessionsPerDayRB.Size = new System.Drawing.Size(123, 26);
            this.entryVisitTypeSessionsPerDayRB.TabIndex = 4;
            this.entryVisitTypeSessionsPerDayRB.Text = "Sessions/Day";
            this.entryVisitTypeSessionsPerDayRB.UseVisualStyleBackColor = true;
            this.entryVisitTypeSessionsPerDayRB.CheckedChanged += new System.EventHandler(this.entryVisitTypeRB_CheckedChanged);
            // 
            // entryVisitTypeSessionsInEntryPeriodRB
            // 
            this.entryVisitTypeSessionsInEntryPeriodRB.AutoSize = true;
            this.entryVisitTypeSessionsInEntryPeriodRB.Location = new System.Drawing.Point(3, 67);
            this.entryVisitTypeSessionsInEntryPeriodRB.Name = "entryVisitTypeSessionsInEntryPeriodRB";
            this.entryVisitTypeSessionsInEntryPeriodRB.Size = new System.Drawing.Size(90, 26);
            this.entryVisitTypeSessionsInEntryPeriodRB.TabIndex = 7;
            this.entryVisitTypeSessionsInEntryPeriodRB.Text = "Sessions";
            this.entryVisitTypeSessionsInEntryPeriodRB.UseVisualStyleBackColor = true;
            this.entryVisitTypeSessionsInEntryPeriodRB.CheckedChanged += new System.EventHandler(this.entryVisitTypeRB_CheckedChanged);
            // 
            // entryVisitTypeDaysInEntryPeriodWindowRB
            // 
            this.entryVisitTypeDaysInEntryPeriodWindowRB.AutoSize = true;
            this.entryVisitTypeDaysInEntryPeriodWindowRB.Location = new System.Drawing.Point(3, 99);
            this.entryVisitTypeDaysInEntryPeriodWindowRB.Name = "entryVisitTypeDaysInEntryPeriodWindowRB";
            this.entryVisitTypeDaysInEntryPeriodWindowRB.Size = new System.Drawing.Size(62, 26);
            this.entryVisitTypeDaysInEntryPeriodWindowRB.TabIndex = 5;
            this.entryVisitTypeDaysInEntryPeriodWindowRB.Text = "Days";
            this.entryVisitTypeDaysInEntryPeriodWindowRB.UseVisualStyleBackColor = true;
            this.entryVisitTypeDaysInEntryPeriodWindowRB.CheckedChanged += new System.EventHandler(this.entryVisitTypeRB_CheckedChanged);
            // 
            // entryPurchasesTP
            // 
            this.entryPurchasesTP.BackColor = System.Drawing.Color.LightSteelBlue;
            this.entryPurchasesTP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.entryPurchasesTP.Controls.Add(this.entryPurchaseGroupingFLP);
            this.entryPurchasesTP.Controls.Add(this.entryPurchaseSelectionsCL);
            this.entryPurchasesTP.Controls.Add(this.addEntryPurchaseTierBtn);
            this.entryPurchasesTP.Controls.Add(this.entryPurchaseScaleDGV);
            this.entryPurchasesTP.Controls.Add(this.entryPurchaseTypeFLP);
            this.entryPurchasesTP.Location = new System.Drawing.Point(4, 5);
            this.entryPurchasesTP.Name = "entryPurchasesTP";
            this.entryPurchasesTP.Padding = new System.Windows.Forms.Padding(3);
            this.entryPurchasesTP.Size = new System.Drawing.Size(663, 318);
            this.entryPurchasesTP.TabIndex = 2;
            this.entryPurchasesTP.Text = "Purchase";
            // 
            // entryPurchaseGroupingFLP
            // 
            this.entryPurchaseGroupingFLP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entryPurchaseGroupingFLP.Controls.Add(this.entryPurchaseGroupingByTransactionRB);
            this.entryPurchaseGroupingFLP.Controls.Add(this.entryPurchaseGroupingBySessionRB);
            this.entryPurchaseGroupingFLP.Controls.Add(this.entryPurchaseGroupingByDayRB);
            this.entryPurchaseGroupingFLP.Controls.Add(this.entryPurchaseGroupingEntryPeriodRB);
            this.entryPurchaseGroupingFLP.Location = new System.Drawing.Point(12, 14);
            this.entryPurchaseGroupingFLP.Name = "entryPurchaseGroupingFLP";
            this.entryPurchaseGroupingFLP.Size = new System.Drawing.Size(144, 286);
            this.entryPurchaseGroupingFLP.TabIndex = 12;
            // 
            // entryPurchaseGroupingByTransactionRB
            // 
            this.entryPurchaseGroupingByTransactionRB.AutoSize = true;
            this.entryPurchaseGroupingByTransactionRB.Location = new System.Drawing.Point(3, 3);
            this.entryPurchaseGroupingByTransactionRB.Name = "entryPurchaseGroupingByTransactionRB";
            this.entryPurchaseGroupingByTransactionRB.Size = new System.Drawing.Size(118, 26);
            this.entryPurchaseGroupingByTransactionRB.TabIndex = 1;
            this.entryPurchaseGroupingByTransactionRB.Text = "Transaction";
            this.entryPurchaseGroupingByTransactionRB.UseVisualStyleBackColor = true;
            this.entryPurchaseGroupingByTransactionRB.CheckedChanged += new System.EventHandler(this.entryPurchaseGroupingRB_CheckedChanged);
            // 
            // entryPurchaseGroupingBySessionRB
            // 
            this.entryPurchaseGroupingBySessionRB.AutoSize = true;
            this.entryPurchaseGroupingBySessionRB.Location = new System.Drawing.Point(3, 35);
            this.entryPurchaseGroupingBySessionRB.Name = "entryPurchaseGroupingBySessionRB";
            this.entryPurchaseGroupingBySessionRB.Size = new System.Drawing.Size(83, 26);
            this.entryPurchaseGroupingBySessionRB.TabIndex = 2;
            this.entryPurchaseGroupingBySessionRB.Text = "Session";
            this.entryPurchaseGroupingBySessionRB.UseVisualStyleBackColor = true;
            this.entryPurchaseGroupingBySessionRB.CheckedChanged += new System.EventHandler(this.entryPurchaseGroupingRB_CheckedChanged);
            // 
            // entryPurchaseGroupingByDayRB
            // 
            this.entryPurchaseGroupingByDayRB.AutoSize = true;
            this.entryPurchaseGroupingByDayRB.Location = new System.Drawing.Point(3, 67);
            this.entryPurchaseGroupingByDayRB.Name = "entryPurchaseGroupingByDayRB";
            this.entryPurchaseGroupingByDayRB.Size = new System.Drawing.Size(55, 26);
            this.entryPurchaseGroupingByDayRB.TabIndex = 3;
            this.entryPurchaseGroupingByDayRB.Text = "Day";
            this.entryPurchaseGroupingByDayRB.UseVisualStyleBackColor = true;
            this.entryPurchaseGroupingByDayRB.CheckedChanged += new System.EventHandler(this.entryPurchaseGroupingRB_CheckedChanged);
            // 
            // entryPurchaseGroupingEntryPeriodRB
            // 
            this.entryPurchaseGroupingEntryPeriodRB.AutoSize = true;
            this.entryPurchaseGroupingEntryPeriodRB.Location = new System.Drawing.Point(3, 99);
            this.entryPurchaseGroupingEntryPeriodRB.Name = "entryPurchaseGroupingEntryPeriodRB";
            this.entryPurchaseGroupingEntryPeriodRB.Size = new System.Drawing.Size(121, 26);
            this.entryPurchaseGroupingEntryPeriodRB.TabIndex = 3;
            this.entryPurchaseGroupingEntryPeriodRB.Text = "Entry Period";
            this.entryPurchaseGroupingEntryPeriodRB.UseVisualStyleBackColor = true;
            this.entryPurchaseGroupingEntryPeriodRB.CheckedChanged += new System.EventHandler(this.entryPurchaseGroupingRB_CheckedChanged);
            // 
            // entryPurchaseSelectionsCL
            // 
            this.entryPurchaseSelectionsCL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entryPurchaseSelectionsCL.CheckOnClick = true;
            this.entryPurchaseSelectionsCL.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryPurchaseSelectionsCL.FormattingEnabled = true;
            this.entryPurchaseSelectionsCL.IntegralHeight = false;
            this.entryPurchaseSelectionsCL.Location = new System.Drawing.Point(153, 130);
            this.entryPurchaseSelectionsCL.Name = "entryPurchaseSelectionsCL";
            this.entryPurchaseSelectionsCL.Size = new System.Drawing.Size(381, 152);
            this.entryPurchaseSelectionsCL.TabIndex = 11;
            this.entryPurchaseSelectionsCL.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.entryPurchaseSelectionsCL_ItemCheck);
            // 
            // addEntryPurchaseTierBtn
            // 
            this.addEntryPurchaseTierBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addEntryPurchaseTierBtn.FocusColor = System.Drawing.Color.Black;
            this.addEntryPurchaseTierBtn.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.addEntryPurchaseTierBtn.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.addEntryPurchaseTierBtn.Location = new System.Drawing.Point(560, 117);
            this.addEntryPurchaseTierBtn.MinimumSize = new System.Drawing.Size(30, 30);
            this.addEntryPurchaseTierBtn.Name = "addEntryPurchaseTierBtn";
            this.addEntryPurchaseTierBtn.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.addEntryPurchaseTierBtn.Size = new System.Drawing.Size(75, 30);
            this.addEntryPurchaseTierBtn.TabIndex = 10;
            this.addEntryPurchaseTierBtn.Text = "+";
            this.addEntryPurchaseTierBtn.Visible = false;
            this.addEntryPurchaseTierBtn.Click += new System.EventHandler(this.addEntryPurchaseTierBtn_Click);
            // 
            // entryPurchaseScaleDGV
            // 
            this.entryPurchaseScaleDGV.AllowUserToAddRows = false;
            this.entryPurchaseScaleDGV.AllowUserToDeleteRows = false;
            this.entryPurchaseScaleDGV.AllowUserToResizeRows = false;
            this.entryPurchaseScaleDGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.entryPurchaseScaleDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.entryPurchaseScaleDGV.Location = new System.Drawing.Point(150, 14);
            this.entryPurchaseScaleDGV.MultiSelect = false;
            this.entryPurchaseScaleDGV.Name = "entryPurchaseScaleDGV";
            this.entryPurchaseScaleDGV.RowHeadersVisible = false;
            this.entryPurchaseScaleDGV.RowTemplate.Height = 30;
            this.entryPurchaseScaleDGV.Size = new System.Drawing.Size(485, 97);
            this.entryPurchaseScaleDGV.TabIndex = 9;
            this.entryPurchaseScaleDGV.Visible = false;
            // 
            // entryPurchaseTypeFLP
            // 
            this.entryPurchaseTypeFLP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entryPurchaseTypeFLP.Controls.Add(this.entryPurchaseTypeNoneRB);
            this.entryPurchaseTypeFLP.Controls.Add(this.entryPurchaseTypePackageRB);
            this.entryPurchaseTypeFLP.Controls.Add(this.entryPurchaseTypeProductRB);
            this.entryPurchaseTypeFLP.Location = new System.Drawing.Point(150, 153);
            this.entryPurchaseTypeFLP.Name = "entryPurchaseTypeFLP";
            this.entryPurchaseTypeFLP.Size = new System.Drawing.Size(131, 146);
            this.entryPurchaseTypeFLP.TabIndex = 8;
            // 
            // entryPurchaseTypeNoneRB
            // 
            this.entryPurchaseTypeNoneRB.AutoSize = true;
            this.entryPurchaseTypeNoneRB.Location = new System.Drawing.Point(3, 3);
            this.entryPurchaseTypeNoneRB.Name = "entryPurchaseTypeNoneRB";
            this.entryPurchaseTypeNoneRB.Size = new System.Drawing.Size(67, 26);
            this.entryPurchaseTypeNoneRB.TabIndex = 8;
            this.entryPurchaseTypeNoneRB.TabStop = true;
            this.entryPurchaseTypeNoneRB.Text = "None";
            this.entryPurchaseTypeNoneRB.UseVisualStyleBackColor = true;
            this.entryPurchaseTypeNoneRB.CheckedChanged += new System.EventHandler(this.entryPurchaseTypeRB_CheckedChanged);
            // 
            // entryPurchaseTypePackageRB
            // 
            this.entryPurchaseTypePackageRB.AutoSize = true;
            this.entryPurchaseTypePackageRB.Location = new System.Drawing.Point(3, 35);
            this.entryPurchaseTypePackageRB.Name = "entryPurchaseTypePackageRB";
            this.entryPurchaseTypePackageRB.Size = new System.Drawing.Size(98, 26);
            this.entryPurchaseTypePackageRB.TabIndex = 6;
            this.entryPurchaseTypePackageRB.TabStop = true;
            this.entryPurchaseTypePackageRB.Text = "Packages";
            this.entryPurchaseTypePackageRB.UseVisualStyleBackColor = true;
            this.entryPurchaseTypePackageRB.CheckedChanged += new System.EventHandler(this.entryPurchaseTypeRB_CheckedChanged);
            // 
            // entryPurchaseTypeProductRB
            // 
            this.entryPurchaseTypeProductRB.AutoSize = true;
            this.entryPurchaseTypeProductRB.Location = new System.Drawing.Point(3, 67);
            this.entryPurchaseTypeProductRB.Name = "entryPurchaseTypeProductRB";
            this.entryPurchaseTypeProductRB.Size = new System.Drawing.Size(94, 26);
            this.entryPurchaseTypeProductRB.TabIndex = 7;
            this.entryPurchaseTypeProductRB.TabStop = true;
            this.entryPurchaseTypeProductRB.Text = "Products";
            this.entryPurchaseTypeProductRB.UseVisualStyleBackColor = true;
            this.entryPurchaseTypeProductRB.CheckedChanged += new System.EventHandler(this.entryPurchaseTypeRB_CheckedChanged);
            // 
            // entrySpendTP
            // 
            this.entrySpendTP.BackColor = System.Drawing.Color.LightSteelBlue;
            this.entrySpendTP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.entrySpendTP.Controls.Add(this.addEntrySpendTierBtn);
            this.entrySpendTP.Controls.Add(this.entrySpendScaleDGV);
            this.entrySpendTP.Controls.Add(this.entrySpendGroupingFLP);
            this.entrySpendTP.Location = new System.Drawing.Point(4, 5);
            this.entrySpendTP.Name = "entrySpendTP";
            this.entrySpendTP.Padding = new System.Windows.Forms.Padding(3);
            this.entrySpendTP.Size = new System.Drawing.Size(663, 318);
            this.entrySpendTP.TabIndex = 0;
            this.entrySpendTP.Text = "Spend";
            // 
            // addEntrySpendTierBtn
            // 
            this.addEntrySpendTierBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addEntrySpendTierBtn.FocusColor = System.Drawing.Color.Black;
            this.addEntrySpendTierBtn.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.addEntrySpendTierBtn.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.addEntrySpendTierBtn.Location = new System.Drawing.Point(578, 278);
            this.addEntrySpendTierBtn.MinimumSize = new System.Drawing.Size(30, 30);
            this.addEntrySpendTierBtn.Name = "addEntrySpendTierBtn";
            this.addEntrySpendTierBtn.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.addEntrySpendTierBtn.Size = new System.Drawing.Size(75, 30);
            this.addEntrySpendTierBtn.TabIndex = 6;
            this.addEntrySpendTierBtn.Text = "+";
            this.addEntrySpendTierBtn.Visible = false;
            this.addEntrySpendTierBtn.Click += new System.EventHandler(this.addEntrySpendTierBtn_Click);
            // 
            // entrySpendScaleDGV
            // 
            this.entrySpendScaleDGV.AllowUserToAddRows = false;
            this.entrySpendScaleDGV.AllowUserToDeleteRows = false;
            this.entrySpendScaleDGV.AllowUserToResizeRows = false;
            this.entrySpendScaleDGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.entrySpendScaleDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.entrySpendScaleDGV.Location = new System.Drawing.Point(150, 6);
            this.entrySpendScaleDGV.MultiSelect = false;
            this.entrySpendScaleDGV.Name = "entrySpendScaleDGV";
            this.entrySpendScaleDGV.RowHeadersVisible = false;
            this.entrySpendScaleDGV.RowTemplate.Height = 30;
            this.entrySpendScaleDGV.Size = new System.Drawing.Size(503, 266);
            this.entrySpendScaleDGV.TabIndex = 5;
            this.entrySpendScaleDGV.Visible = false;
            this.entrySpendScaleDGV.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.entrySpendScaleDGV_CellBeginEdit);
            this.entrySpendScaleDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.entrySpendScaleDGV_CellClick);
            this.entrySpendScaleDGV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.entrySpendScaleDGV_CellEndEdit);
            this.entrySpendScaleDGV.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.entrySpendScaleDGV_CellEnter);
            this.entrySpendScaleDGV.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.entrySpendScaleDGV_CellLeave);
            this.entrySpendScaleDGV.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.entrySpendScaleDGV_CellValueChanged);
            this.entrySpendScaleDGV.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.entrySpendScaleDGV_EditingControlShowing);
            this.entrySpendScaleDGV.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.entrySpendScaleDGV_RowsAdded);
            this.entrySpendScaleDGV.Validating += new System.ComponentModel.CancelEventHandler(this.entrySpendScaleDGV_Validating);
            // 
            // entrySpendGroupingFLP
            // 
            this.entrySpendGroupingFLP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entrySpendGroupingFLP.Controls.Add(this.entrySpendGroupingBySessionRB);
            this.entrySpendGroupingFLP.Controls.Add(this.entrySpendGroupingNoneRB);
            this.entrySpendGroupingFLP.Controls.Add(this.entrySpendGroupingByTransactionRB);
            this.entrySpendGroupingFLP.Controls.Add(this.entrySpendGroupingByDayRB);
            this.entrySpendGroupingFLP.Controls.Add(this.entrySpendGroupingEntryPeriodRB);
            this.entrySpendGroupingFLP.Location = new System.Drawing.Point(6, 6);
            this.entrySpendGroupingFLP.Name = "entrySpendGroupingFLP";
            this.entrySpendGroupingFLP.Size = new System.Drawing.Size(138, 338);
            this.entrySpendGroupingFLP.TabIndex = 4;
            // 
            // entrySpendGroupingBySessionRB
            // 
            this.entrySpendGroupingBySessionRB.AutoSize = true;
            this.entrySpendGroupingBySessionRB.Location = new System.Drawing.Point(3, 3);
            this.entrySpendGroupingBySessionRB.Name = "entrySpendGroupingBySessionRB";
            this.entrySpendGroupingBySessionRB.Size = new System.Drawing.Size(83, 26);
            this.entrySpendGroupingBySessionRB.TabIndex = 2;
            this.entrySpendGroupingBySessionRB.Text = "Session";
            this.entrySpendGroupingBySessionRB.UseVisualStyleBackColor = true;
            this.entrySpendGroupingBySessionRB.CheckedChanged += new System.EventHandler(this.entrySpendGroupingRB_CheckedChanged);
            this.entrySpendGroupingBySessionRB.Validating += new System.ComponentModel.CancelEventHandler(this.entrySpendGrouping_Validating);
            // 
            // entrySpendGroupingNoneRB
            // 
            this.entrySpendGroupingNoneRB.AutoSize = true;
            this.entrySpendGroupingNoneRB.Location = new System.Drawing.Point(3, 35);
            this.entrySpendGroupingNoneRB.Name = "entrySpendGroupingNoneRB";
            this.entrySpendGroupingNoneRB.Size = new System.Drawing.Size(67, 26);
            this.entrySpendGroupingNoneRB.TabIndex = 4;
            this.entrySpendGroupingNoneRB.Text = "None";
            this.entrySpendGroupingNoneRB.UseVisualStyleBackColor = true;
            this.entrySpendGroupingNoneRB.CheckedChanged += new System.EventHandler(this.entrySpendGroupingRB_CheckedChanged);
            this.entrySpendGroupingNoneRB.Validating += new System.ComponentModel.CancelEventHandler(this.entrySpendGrouping_Validating);
            // 
            // entrySpendGroupingByTransactionRB
            // 
            this.entrySpendGroupingByTransactionRB.AutoSize = true;
            this.entrySpendGroupingByTransactionRB.Location = new System.Drawing.Point(3, 67);
            this.entrySpendGroupingByTransactionRB.Name = "entrySpendGroupingByTransactionRB";
            this.entrySpendGroupingByTransactionRB.Size = new System.Drawing.Size(118, 26);
            this.entrySpendGroupingByTransactionRB.TabIndex = 1;
            this.entrySpendGroupingByTransactionRB.Text = "Transaction";
            this.entrySpendGroupingByTransactionRB.UseVisualStyleBackColor = true;
            this.entrySpendGroupingByTransactionRB.CheckedChanged += new System.EventHandler(this.entrySpendGroupingRB_CheckedChanged);
            this.entrySpendGroupingByTransactionRB.Validating += new System.ComponentModel.CancelEventHandler(this.entrySpendGrouping_Validating);
            // 
            // entrySpendGroupingByDayRB
            // 
            this.entrySpendGroupingByDayRB.AutoSize = true;
            this.entrySpendGroupingByDayRB.Location = new System.Drawing.Point(3, 99);
            this.entrySpendGroupingByDayRB.Name = "entrySpendGroupingByDayRB";
            this.entrySpendGroupingByDayRB.Size = new System.Drawing.Size(55, 26);
            this.entrySpendGroupingByDayRB.TabIndex = 3;
            this.entrySpendGroupingByDayRB.Text = "Day";
            this.entrySpendGroupingByDayRB.UseVisualStyleBackColor = true;
            this.entrySpendGroupingByDayRB.CheckedChanged += new System.EventHandler(this.entrySpendGroupingRB_CheckedChanged);
            this.entrySpendGroupingByDayRB.Validating += new System.ComponentModel.CancelEventHandler(this.entrySpendGrouping_Validating);
            // 
            // entrySpendGroupingEntryPeriodRB
            // 
            this.entrySpendGroupingEntryPeriodRB.AutoSize = true;
            this.entrySpendGroupingEntryPeriodRB.Location = new System.Drawing.Point(3, 131);
            this.entrySpendGroupingEntryPeriodRB.Name = "entrySpendGroupingEntryPeriodRB";
            this.entrySpendGroupingEntryPeriodRB.Size = new System.Drawing.Size(121, 26);
            this.entrySpendGroupingEntryPeriodRB.TabIndex = 3;
            this.entrySpendGroupingEntryPeriodRB.Text = "Entry Period";
            this.entrySpendGroupingEntryPeriodRB.UseVisualStyleBackColor = true;
            this.entrySpendGroupingEntryPeriodRB.CheckedChanged += new System.EventHandler(this.entrySpendGroupingRB_CheckedChanged);
            this.entrySpendGroupingEntryPeriodRB.Validating += new System.ComponentModel.CancelEventHandler(this.entrySpendGrouping_Validating);
            // 
            // drawingActiveChk
            // 
            this.drawingActiveChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingActiveChk.AutoSize = true;
            this.drawingActiveChk.BackColor = System.Drawing.Color.Transparent;
            this.drawingActiveChk.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawingActiveChk.Location = new System.Drawing.Point(634, 30);
            this.drawingActiveChk.Name = "drawingActiveChk";
            this.drawingActiveChk.Size = new System.Drawing.Size(77, 26);
            this.drawingActiveChk.TabIndex = 15;
            this.drawingActiveChk.Text = "Active";
            this.drawingActiveChk.UseVisualStyleBackColor = false;
            // 
            // drawingNameTxt
            // 
            this.drawingNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingNameTxt.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawingNameTxt.Location = new System.Drawing.Point(75, 28);
            this.drawingNameTxt.Name = "drawingNameTxt";
            this.drawingNameTxt.Size = new System.Drawing.Size(553, 26);
            this.drawingNameTxt.TabIndex = 12;
            // 
            // revertDrawingChangesBtn
            // 
            this.revertDrawingChangesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.revertDrawingChangesBtn.BackColor = System.Drawing.Color.Transparent;
            this.revertDrawingChangesBtn.FocusColor = System.Drawing.Color.Black;
            this.revertDrawingChangesBtn.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.revertDrawingChangesBtn.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.revertDrawingChangesBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.revertDrawingChangesBtn.Location = new System.Drawing.Point(14, 560);
            this.revertDrawingChangesBtn.MinimumSize = new System.Drawing.Size(30, 30);
            this.revertDrawingChangesBtn.Name = "revertDrawingChangesBtn";
            this.revertDrawingChangesBtn.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.revertDrawingChangesBtn.Size = new System.Drawing.Size(152, 40);
            this.revertDrawingChangesBtn.TabIndex = 10;
            this.revertDrawingChangesBtn.Text = "Revert";
            this.revertDrawingChangesBtn.UseVisualStyleBackColor = false;
            this.revertDrawingChangesBtn.Click += new System.EventHandler(this.revertDrawingChangesBtn_Click);
            // 
            // drawingNameLbl
            // 
            this.drawingNameLbl.BackColor = System.Drawing.Color.Transparent;
            this.drawingNameLbl.Location = new System.Drawing.Point(15, 31);
            this.drawingNameLbl.Name = "drawingNameLbl";
            this.drawingNameLbl.Size = new System.Drawing.Size(54, 22);
            this.drawingNameLbl.TabIndex = 11;
            this.drawingNameLbl.Text = "Name";
            // 
            // cancelDrawingChangesBtn
            // 
            this.cancelDrawingChangesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelDrawingChangesBtn.BackColor = System.Drawing.Color.Transparent;
            this.cancelDrawingChangesBtn.FocusColor = System.Drawing.Color.Black;
            this.cancelDrawingChangesBtn.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.cancelDrawingChangesBtn.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.cancelDrawingChangesBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cancelDrawingChangesBtn.Location = new System.Drawing.Point(555, 560);
            this.cancelDrawingChangesBtn.MinimumSize = new System.Drawing.Size(30, 30);
            this.cancelDrawingChangesBtn.Name = "cancelDrawingChangesBtn";
            this.cancelDrawingChangesBtn.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.cancelDrawingChangesBtn.Size = new System.Drawing.Size(152, 40);
            this.cancelDrawingChangesBtn.TabIndex = 9;
            this.cancelDrawingChangesBtn.Text = "Cancel";
            this.cancelDrawingChangesBtn.UseVisualStyleBackColor = false;
            this.cancelDrawingChangesBtn.Click += new System.EventHandler(this.cancelDrawingChangesBtn_Click);
            // 
            // saveDrawingChangesBtn
            // 
            this.saveDrawingChangesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveDrawingChangesBtn.BackColor = System.Drawing.Color.Transparent;
            this.saveDrawingChangesBtn.FocusColor = System.Drawing.Color.Black;
            this.saveDrawingChangesBtn.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.saveDrawingChangesBtn.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.saveDrawingChangesBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.saveDrawingChangesBtn.Location = new System.Drawing.Point(395, 560);
            this.saveDrawingChangesBtn.MinimumSize = new System.Drawing.Size(30, 30);
            this.saveDrawingChangesBtn.Name = "saveDrawingChangesBtn";
            this.saveDrawingChangesBtn.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.saveDrawingChangesBtn.Size = new System.Drawing.Size(152, 40);
            this.saveDrawingChangesBtn.TabIndex = 8;
            this.saveDrawingChangesBtn.Text = "Save";
            this.saveDrawingChangesBtn.UseVisualStyleBackColor = false;
            this.saveDrawingChangesBtn.Click += new System.EventHandler(this.saveDrawingChangesBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.FocusColor = System.Drawing.Color.Black;
            this.closeBtn.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.closeBtn.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.closeBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.closeBtn.Location = new System.Drawing.Point(854, 631);
            this.closeBtn.MinimumSize = new System.Drawing.Size(30, 30);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.closeBtn.Size = new System.Drawing.Size(152, 40);
            this.closeBtn.TabIndex = 17;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // copyDrawingBtn
            // 
            this.copyDrawingBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.copyDrawingBtn.BackColor = System.Drawing.Color.Transparent;
            this.copyDrawingBtn.Enabled = false;
            this.copyDrawingBtn.FocusColor = System.Drawing.Color.Black;
            this.copyDrawingBtn.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.copyDrawingBtn.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.copyDrawingBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.copyDrawingBtn.Location = new System.Drawing.Point(10, 586);
            this.copyDrawingBtn.MinimumSize = new System.Drawing.Size(30, 30);
            this.copyDrawingBtn.Name = "copyDrawingBtn";
            this.copyDrawingBtn.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.copyDrawingBtn.Size = new System.Drawing.Size(260, 40);
            this.copyDrawingBtn.TabIndex = 19;
            this.copyDrawingBtn.Text = "Copy";
            this.copyDrawingBtn.UseVisualStyleBackColor = false;
            this.copyDrawingBtn.Click += new System.EventHandler(this.copyDrawingBtn_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // testEventsBtn
            // 
            this.testEventsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.testEventsBtn.Font = new System.Drawing.Font("Trebuchet MS", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testEventsBtn.Location = new System.Drawing.Point(312, 633);
            this.testEventsBtn.Name = "testEventsBtn";
            this.testEventsBtn.Size = new System.Drawing.Size(131, 27);
            this.testEventsBtn.TabIndex = 24;
            this.testEventsBtn.Text = "Event Testing";
            this.testEventsBtn.UseVisualStyleBackColor = true;
            this.testEventsBtn.Click += new System.EventHandler(this.testEventsBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(302, 630);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(366, 37);
            this.panel1.TabIndex = 25;
            // 
            // GeneralPlayerDrawingForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(1018, 678);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.testEventsBtn);
            this.Controls.Add(this.copyDrawingBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.drawingDetailsGB);
            this.Controls.Add(this.showInactiveDrawingsChk);
            this.Controls.Add(this.editDrawingBtn);
            this.Controls.Add(this.newDrawingBtn);
            this.Controls.Add(this.drawingsLbl);
            this.Controls.Add(this.drawingsLV);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "GeneralPlayerDrawingForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "General Player Drawing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GeneralPlayerDrawingForm_FormClosing);
            this.drawingDetailsGB.ResumeLayout(false);
            this.drawingDetailsGB.PerformLayout();
            this.drawingDetailsTC.ResumeLayout(false);
            this.commonOptionsTP.ResumeLayout(false);
            this.commonOptionsTP.PerformLayout();
            this.eventTP.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.eventRepeatDetailsPnl.ResumeLayout(false);
            this.eventRepeatDetailsPnl.PerformLayout();
            this.entryMethodsTP.ResumeLayout(false);
            this.entryMethodsTP.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.entryMethodsTC.ResumeLayout(false);
            this.entryVisitsTP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.entryVisitScaleDGV)).EndInit();
            this.entryVisitsTypeFLP.ResumeLayout(false);
            this.entryVisitsTypeFLP.PerformLayout();
            this.entryPurchasesTP.ResumeLayout(false);
            this.entryPurchaseGroupingFLP.ResumeLayout(false);
            this.entryPurchaseGroupingFLP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entryPurchaseScaleDGV)).EndInit();
            this.entryPurchaseTypeFLP.ResumeLayout(false);
            this.entryPurchaseTypeFLP.PerformLayout();
            this.entrySpendTP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.entrySpendScaleDGV)).EndInit();
            this.entrySpendGroupingFLP.ResumeLayout(false);
            this.entrySpendGroupingFLP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView drawingsLV;
        private System.Windows.Forms.Label drawingsLbl;
        private Controls.ImageButton newDrawingBtn;
        private Controls.ImageButton editDrawingBtn;
        private System.Windows.Forms.CheckBox showInactiveDrawingsChk;
        private System.Windows.Forms.GroupBox drawingDetailsGB;
        private Controls.ImageButton closeBtn;
        private Controls.ImageButton revertDrawingChangesBtn;
        private Controls.ImageButton cancelDrawingChangesBtn;
        private Controls.ImageButton saveDrawingChangesBtn;
        private System.Windows.Forms.TextBox drawingNameTxt;
        private System.Windows.Forms.Label drawingNameLbl;
        private System.Windows.Forms.CheckBox drawingActiveChk;
        private System.Windows.Forms.CheckBox showEntryCountOnReceiptsChk;
        private Controls.ImageButton copyDrawingBtn;
        private System.Windows.Forms.TabControl drawingDetailsTC;
        private System.Windows.Forms.TabPage commonOptionsTP;
        private System.Windows.Forms.TabPage eventTP;
        private System.Windows.Forms.TabPage entryMethodsTP;
        private System.Windows.Forms.RadioButton entryVisitTypeDaysInEntryPeriodWindowRB;
        private System.Windows.Forms.RadioButton entryVisitTypeSessionsPerDayRB;
        private System.Windows.Forms.RadioButton entrySpendGroupingByDayRB;
        private System.Windows.Forms.RadioButton entrySpendGroupingBySessionRB;
        private System.Windows.Forms.RadioButton entrySpendGroupingEntryPeriodRB;
        private System.Windows.Forms.RadioButton entrySpendGroupingByTransactionRB;
        private System.Windows.Forms.RadioButton entryPurchaseTypeProductRB;
        private System.Windows.Forms.RadioButton entryPurchaseTypePackageRB;
        private System.Windows.Forms.TextBox minimumEntriesToRunTxt;
        private System.Windows.Forms.Label minimumEntriesToRunLbl;
        private System.Windows.Forms.TextBox entryLimitEventTxt;
        private System.Windows.Forms.Label entryLimitEventLbl;
        private System.Windows.Forms.CheckBox playerPresenceRequiredChk;
        private System.Windows.Forms.Label eventRepetitionEndsLbl;
        private System.Windows.Forms.DateTimePicker eventRepetitionEndsDTP;
        private System.Windows.Forms.ComboBox eventRepeatIntervalCB;
        private System.Windows.Forms.CheckBox eventRepeatsChk;
        private System.Windows.Forms.Label initialEventEntryPeriodEndLbl;
        private System.Windows.Forms.DateTimePicker initialEventEntryPeriodEndDTP;
        private System.Windows.Forms.DateTimePicker initialEventEntryPeriodBeginDTP;
        private System.Windows.Forms.Label initialEventEntryPeriodBeginLbl;
        private System.Windows.Forms.Label entrySessionsLbl;
        private System.Windows.Forms.CheckedListBox entrySessionNumbersCL;
        private System.Windows.Forms.TabControl entryMethodsTC;
        private System.Windows.Forms.TabPage entrySpendTP;
        private System.Windows.Forms.TabPage entryVisitsTP;
        private System.Windows.Forms.TabPage entryPurchasesTP;
        private System.Windows.Forms.FlowLayoutPanel entrySpendGroupingFLP;
        private System.Windows.Forms.FlowLayoutPanel entryVisitsTypeFLP;
        private System.Windows.Forms.FlowLayoutPanel entryPurchaseTypeFLP;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox drawingDescriptionTxt;
        private System.Windows.Forms.Label drawingDescriptionLbl;
        private System.Windows.Forms.TextBox drawingEntriesDrawnTxt;
        private System.Windows.Forms.Label drawingEntriesDrawnLbl;
        private System.Windows.Forms.Label maximumDrawsPerPlayerLbl;
        private System.Windows.Forms.TextBox maximumDrawsPerPlayerTxt;
        private System.Windows.Forms.RadioButton entrySpendGroupingNoneRB;
        private System.Windows.Forms.RadioButton entryVisitTypeNoneRB;
        private System.Windows.Forms.RadioButton entryPurchaseTypeNoneRB;
        private System.Windows.Forms.DataGridView entrySpendScaleDGV;
        private System.Windows.Forms.DataGridView entryVisitScaleDGV;
        private System.Windows.Forms.DataGridView entryPurchaseScaleDGV;
        private Controls.ImageButton addEntrySpendTierBtn;
        private Controls.ImageButton addEntryVisitTierBtn;
        private Controls.ImageButton addEntryPurchaseTierBtn;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckedListBox entryPurchaseSelectionsCL;
        private System.Windows.Forms.Panel eventRepeatDetailsPnl;
        private System.Windows.Forms.Label eventRepetitionRateLbl;
        private System.Windows.Forms.Label eventWindowExamplesLbl;
        private System.Windows.Forms.TextBox eventRepeatIncrementTxt;
        private System.Windows.Forms.Label entryLimitEventNoteLbl;
        private System.Windows.Forms.RadioButton entryVisitTypeSessionsInEntryPeriodRB;
        private System.Windows.Forms.FlowLayoutPanel entryPurchaseGroupingFLP;
        private System.Windows.Forms.RadioButton entryPurchaseGroupingByTransactionRB;
        private System.Windows.Forms.RadioButton entryPurchaseGroupingBySessionRB;
        private System.Windows.Forms.RadioButton entryPurchaseGroupingByDayRB;
        private System.Windows.Forms.RadioButton entryPurchaseGroupingEntryPeriodRB;
        private System.Windows.Forms.Label initialEventScheduledForLbl;
        private System.Windows.Forms.DateTimePicker initialEventScheduledForDTP;
        private System.Windows.Forms.Label entryPeriodLbl;
        private System.Windows.Forms.ListView eventExamplesLV;
        private System.Windows.Forms.Button testEventsBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel m_pnlHideRepeats;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rdobtnVisit;
        private System.Windows.Forms.RadioButton rdobtn_Spend;
        private System.Windows.Forms.RadioButton rdobtnBoth;
    }
}