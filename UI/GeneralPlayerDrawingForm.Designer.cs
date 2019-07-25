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
            this.txtbx_disclaimer = new System.Windows.Forms.TextBox();
            this.lbl_Disclaimer = new System.Windows.Forms.Label();
            this.txtbx_PrizeDescription = new System.Windows.Forms.TextBox();
            this.lbl_prizeDescription = new System.Windows.Forms.Label();
            this.drawingDescriptionLbl = new System.Windows.Forms.Label();
            this.entryLimitEventNoteLbl = new System.Windows.Forms.Label();
            this.maximumDrawsPerPlayerLbl = new System.Windows.Forms.Label();
            this.maximumDrawsPerPlayerTxt = new System.Windows.Forms.TextBox();
            this.drawingEntriesDrawnTxt = new System.Windows.Forms.TextBox();
            this.drawingEntriesDrawnLbl = new System.Windows.Forms.Label();
            this.drawingDescriptionTxt = new System.Windows.Forms.TextBox();
            this.entryLimitEventLbl = new System.Windows.Forms.Label();
            this.entryLimitEventTxt = new System.Windows.Forms.TextBox();
            this.minimumEntriesToRunLbl = new System.Windows.Forms.Label();
            this.playerPresenceRequiredChk = new System.Windows.Forms.CheckBox();
            this.showEntryCountOnReceiptsChk = new System.Windows.Forms.CheckBox();
            this.minimumEntriesToRunTxt = new System.Windows.Forms.TextBox();
            this.eventTP = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_imgbtnSelectAllSession = new GTI.Controls.ImageButton();
            this.entryPeriodLbl = new System.Windows.Forms.Label();
            this.initialEventEntryPeriodEndDTP = new System.Windows.Forms.DateTimePicker();
            this.initialEventEntryPeriodEndLbl = new System.Windows.Forms.Label();
            this.initialEventEntryPeriodBeginLbl = new System.Windows.Forms.Label();
            this.initialEventEntryPeriodBeginDTP = new System.Windows.Forms.DateTimePicker();
            this.entrySessionNumbersCL = new System.Windows.Forms.CheckedListBox();
            this.entrySessionsLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.eventRepeatsChk = new System.Windows.Forms.CheckBox();
            this.initialEventScheduledForLbl = new System.Windows.Forms.Label();
            this.eventRepeatDetailsPnl = new System.Windows.Forms.GroupBox();
            this.eventRepeatIncrementTxt = new System.Windows.Forms.TextBox();
            this.eventRepetitionRateLbl = new System.Windows.Forms.Label();
            this.eventRepetitionEndsLbl = new System.Windows.Forms.Label();
            this.eventExamplesLV = new System.Windows.Forms.ListView();
            this.eventRepeatIntervalCB = new System.Windows.Forms.ComboBox();
            this.eventRepetitionEndsDTP = new System.Windows.Forms.DateTimePicker();
            this.eventWindowExamplesLbl = new System.Windows.Forms.Label();
            this.initialEventScheduledForDTP = new System.Windows.Forms.DateTimePicker();
            this.entryMethodsTP = new System.Windows.Forms.TabPage();
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
            this.entrySpendGroupingNoneRB = new System.Windows.Forms.RadioButton();
            this.entrySpendGroupingBySessionRB = new System.Windows.Forms.RadioButton();
            this.entrySpendGroupingByDayRB = new System.Windows.Forms.RadioButton();
            this.entrySpendGroupingByTransactionRB = new System.Windows.Forms.RadioButton();
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
            this.testEventsBtn = new System.Windows.Forms.Button();
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
            this.drawingsLV.Location = new System.Drawing.Point(12, 40);
            this.drawingsLV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 8);
            this.drawingsLV.MultiSelect = false;
            this.drawingsLV.Name = "drawingsLV";
            this.drawingsLV.Size = new System.Drawing.Size(234, 438);
            this.drawingsLV.TabIndex = 2;
            this.drawingsLV.UseCompatibleStateImageBehavior = false;
            this.drawingsLV.View = System.Windows.Forms.View.Details;
            this.drawingsLV.SelectedIndexChanged += new System.EventHandler(this.drawingsLV_SelectedIndexChanged);
            // 
            // drawingsLbl
            // 
            this.drawingsLbl.AutoSize = true;
            this.drawingsLbl.BackColor = System.Drawing.Color.Transparent;
            this.drawingsLbl.Location = new System.Drawing.Point(8, 16);
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
            this.newDrawingBtn.Location = new System.Drawing.Point(59, 494);
            this.newDrawingBtn.Margin = new System.Windows.Forms.Padding(4, 8, 4, 4);
            this.newDrawingBtn.MinimumSize = new System.Drawing.Size(30, 30);
            this.newDrawingBtn.Name = "newDrawingBtn";
            this.newDrawingBtn.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.newDrawingBtn.Size = new System.Drawing.Size(140, 40);
            this.newDrawingBtn.TabIndex = 3;
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
            this.editDrawingBtn.Location = new System.Drawing.Point(59, 590);
            this.editDrawingBtn.Margin = new System.Windows.Forms.Padding(4);
            this.editDrawingBtn.MinimumSize = new System.Drawing.Size(30, 30);
            this.editDrawingBtn.Name = "editDrawingBtn";
            this.editDrawingBtn.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.editDrawingBtn.Size = new System.Drawing.Size(140, 40);
            this.editDrawingBtn.TabIndex = 5;
            this.editDrawingBtn.Text = "Edit";
            this.editDrawingBtn.UseVisualStyleBackColor = false;
            this.editDrawingBtn.Click += new System.EventHandler(this.editDrawingBtn_Click);
            // 
            // showInactiveDrawingsChk
            // 
            this.showInactiveDrawingsChk.AutoSize = true;
            this.showInactiveDrawingsChk.BackColor = System.Drawing.Color.Transparent;
            this.showInactiveDrawingsChk.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showInactiveDrawingsChk.Location = new System.Drawing.Point(134, 18);
            this.showInactiveDrawingsChk.Name = "showInactiveDrawingsChk";
            this.showInactiveDrawingsChk.Size = new System.Drawing.Size(112, 22);
            this.showInactiveDrawingsChk.TabIndex = 1;
            this.showInactiveDrawingsChk.Text = "Show Inactive";
            this.showInactiveDrawingsChk.UseVisualStyleBackColor = false;
            this.showInactiveDrawingsChk.CheckedChanged += new System.EventHandler(this.showInactiveDrawingsChk_CheckedChanged);
            // 
            // drawingDetailsGB
            // 
            this.drawingDetailsGB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingDetailsGB.BackColor = System.Drawing.Color.Transparent;
            this.drawingDetailsGB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.drawingDetailsGB.Controls.Add(this.drawingDetailsTC);
            this.drawingDetailsGB.Controls.Add(this.drawingActiveChk);
            this.drawingDetailsGB.Controls.Add(this.drawingNameTxt);
            this.drawingDetailsGB.Controls.Add(this.revertDrawingChangesBtn);
            this.drawingDetailsGB.Controls.Add(this.drawingNameLbl);
            this.drawingDetailsGB.Controls.Add(this.cancelDrawingChangesBtn);
            this.drawingDetailsGB.Controls.Add(this.saveDrawingChangesBtn);
            this.drawingDetailsGB.Location = new System.Drawing.Point(262, 16);
            this.drawingDetailsGB.Name = "drawingDetailsGB";
            this.drawingDetailsGB.Size = new System.Drawing.Size(734, 576);
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
            this.drawingDetailsTC.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.drawingDetailsTC.Location = new System.Drawing.Point(16, 70);
            this.drawingDetailsTC.Margin = new System.Windows.Forms.Padding(8);
            this.drawingDetailsTC.Name = "drawingDetailsTC";
            this.drawingDetailsTC.Padding = new System.Drawing.Point(0, 0);
            this.drawingDetailsTC.SelectedIndex = 0;
            this.drawingDetailsTC.Size = new System.Drawing.Size(702, 448);
            this.drawingDetailsTC.TabIndex = 7;
            this.drawingDetailsTC.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.drawingDetailsTC_DrawItem);
            // 
            // commonOptionsTP
            // 
            this.commonOptionsTP.BackColor = System.Drawing.Color.LightSteelBlue;
            this.commonOptionsTP.Controls.Add(this.txtbx_disclaimer);
            this.commonOptionsTP.Controls.Add(this.lbl_Disclaimer);
            this.commonOptionsTP.Controls.Add(this.txtbx_PrizeDescription);
            this.commonOptionsTP.Controls.Add(this.lbl_prizeDescription);
            this.commonOptionsTP.Controls.Add(this.drawingDescriptionLbl);
            this.commonOptionsTP.Controls.Add(this.entryLimitEventNoteLbl);
            this.commonOptionsTP.Controls.Add(this.maximumDrawsPerPlayerLbl);
            this.commonOptionsTP.Controls.Add(this.maximumDrawsPerPlayerTxt);
            this.commonOptionsTP.Controls.Add(this.drawingEntriesDrawnTxt);
            this.commonOptionsTP.Controls.Add(this.drawingEntriesDrawnLbl);
            this.commonOptionsTP.Controls.Add(this.drawingDescriptionTxt);
            this.commonOptionsTP.Controls.Add(this.entryLimitEventLbl);
            this.commonOptionsTP.Controls.Add(this.entryLimitEventTxt);
            this.commonOptionsTP.Controls.Add(this.minimumEntriesToRunLbl);
            this.commonOptionsTP.Controls.Add(this.playerPresenceRequiredChk);
            this.commonOptionsTP.Controls.Add(this.showEntryCountOnReceiptsChk);
            this.commonOptionsTP.Controls.Add(this.minimumEntriesToRunTxt);
            this.commonOptionsTP.Location = new System.Drawing.Point(4, 31);
            this.commonOptionsTP.Name = "commonOptionsTP";
            this.commonOptionsTP.Padding = new System.Windows.Forms.Padding(3);
            this.commonOptionsTP.Size = new System.Drawing.Size(694, 413);
            this.commonOptionsTP.TabIndex = 0;
            this.commonOptionsTP.Text = "Details";
            // 
            // txtbx_disclaimer
            // 
            this.txtbx_disclaimer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbx_disclaimer.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.txtbx_disclaimer.Location = new System.Drawing.Point(364, 324);
            this.txtbx_disclaimer.Margin = new System.Windows.Forms.Padding(8, 4, 8, 8);
            this.txtbx_disclaimer.MaxLength = 120;
            this.txtbx_disclaimer.Multiline = true;
            this.txtbx_disclaimer.Name = "txtbx_disclaimer";
            this.txtbx_disclaimer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbx_disclaimer.Size = new System.Drawing.Size(316, 60);
            this.txtbx_disclaimer.TabIndex = 9;
            // 
            // lbl_Disclaimer
            // 
            this.lbl_Disclaimer.AutoSize = true;
            this.lbl_Disclaimer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_Disclaimer.Location = new System.Drawing.Point(362, 300);
            this.lbl_Disclaimer.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lbl_Disclaimer.Name = "lbl_Disclaimer";
            this.lbl_Disclaimer.Size = new System.Drawing.Size(89, 22);
            this.lbl_Disclaimer.TabIndex = 35;
            this.lbl_Disclaimer.Text = "Disclaimer";
            // 
            // txtbx_PrizeDescription
            // 
            this.txtbx_PrizeDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbx_PrizeDescription.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx_PrizeDescription.Location = new System.Drawing.Point(364, 216);
            this.txtbx_PrizeDescription.Margin = new System.Windows.Forms.Padding(3, 3, 16, 3);
            this.txtbx_PrizeDescription.MaxLength = 255;
            this.txtbx_PrizeDescription.Multiline = true;
            this.txtbx_PrizeDescription.Name = "txtbx_PrizeDescription";
            this.txtbx_PrizeDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbx_PrizeDescription.Size = new System.Drawing.Size(316, 72);
            this.txtbx_PrizeDescription.TabIndex = 8;
            // 
            // lbl_prizeDescription
            // 
            this.lbl_prizeDescription.AutoSize = true;
            this.lbl_prizeDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_prizeDescription.Location = new System.Drawing.Point(362, 192);
            this.lbl_prizeDescription.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lbl_prizeDescription.Name = "lbl_prizeDescription";
            this.lbl_prizeDescription.Size = new System.Drawing.Size(140, 22);
            this.lbl_prizeDescription.TabIndex = 31;
            this.lbl_prizeDescription.Text = "Prize Description";
            // 
            // drawingDescriptionLbl
            // 
            this.drawingDescriptionLbl.AutoSize = true;
            this.drawingDescriptionLbl.BackColor = System.Drawing.Color.Transparent;
            this.drawingDescriptionLbl.Location = new System.Drawing.Point(12, 16);
            this.drawingDescriptionLbl.Name = "drawingDescriptionLbl";
            this.drawingDescriptionLbl.Size = new System.Drawing.Size(96, 22);
            this.drawingDescriptionLbl.TabIndex = 30;
            this.drawingDescriptionLbl.Text = "Description";
            // 
            // entryLimitEventNoteLbl
            // 
            this.entryLimitEventNoteLbl.AutoSize = true;
            this.entryLimitEventNoteLbl.BackColor = System.Drawing.Color.Transparent;
            this.entryLimitEventNoteLbl.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryLimitEventNoteLbl.Location = new System.Drawing.Point(92, 223);
            this.entryLimitEventNoteLbl.Name = "entryLimitEventNoteLbl";
            this.entryLimitEventNoteLbl.Size = new System.Drawing.Size(139, 18);
            this.entryLimitEventNoteLbl.TabIndex = 29;
            this.entryLimitEventNoteLbl.Text = "leave empty for no limit";
            // 
            // maximumDrawsPerPlayerLbl
            // 
            this.maximumDrawsPerPlayerLbl.BackColor = System.Drawing.Color.Transparent;
            this.maximumDrawsPerPlayerLbl.Location = new System.Drawing.Point(362, 80);
            this.maximumDrawsPerPlayerLbl.Name = "maximumDrawsPerPlayerLbl";
            this.maximumDrawsPerPlayerLbl.Size = new System.Drawing.Size(240, 22);
            this.maximumDrawsPerPlayerLbl.TabIndex = 27;
            this.maximumDrawsPerPlayerLbl.Text = "Maximum wins per player";
            // 
            // maximumDrawsPerPlayerTxt
            // 
            this.maximumDrawsPerPlayerTxt.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maximumDrawsPerPlayerTxt.Location = new System.Drawing.Point(364, 104);
            this.maximumDrawsPerPlayerTxt.Name = "maximumDrawsPerPlayerTxt";
            this.maximumDrawsPerPlayerTxt.Size = new System.Drawing.Size(65, 26);
            this.maximumDrawsPerPlayerTxt.TabIndex = 6;
            this.maximumDrawsPerPlayerTxt.TextChanged += new System.EventHandler(this.requiredUIntTxt_TextChanged);
            this.maximumDrawsPerPlayerTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.requiredIntTxt_KeyPress);
            // 
            // drawingEntriesDrawnTxt
            // 
            this.drawingEntriesDrawnTxt.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawingEntriesDrawnTxt.Location = new System.Drawing.Point(364, 40);
            this.drawingEntriesDrawnTxt.Name = "drawingEntriesDrawnTxt";
            this.drawingEntriesDrawnTxt.Size = new System.Drawing.Size(65, 26);
            this.drawingEntriesDrawnTxt.TabIndex = 5;
            this.drawingEntriesDrawnTxt.TextChanged += new System.EventHandler(this.requiredUIntTxt_TextChanged);
            this.drawingEntriesDrawnTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.requiredIntTxt_KeyPress);
            // 
            // drawingEntriesDrawnLbl
            // 
            this.drawingEntriesDrawnLbl.BackColor = System.Drawing.Color.Transparent;
            this.drawingEntriesDrawnLbl.Location = new System.Drawing.Point(362, 16);
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
            this.drawingDescriptionTxt.Location = new System.Drawing.Point(16, 40);
            this.drawingDescriptionTxt.MaxLength = 255;
            this.drawingDescriptionTxt.Multiline = true;
            this.drawingDescriptionTxt.Name = "drawingDescriptionTxt";
            this.drawingDescriptionTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.drawingDescriptionTxt.Size = new System.Drawing.Size(316, 72);
            this.drawingDescriptionTxt.TabIndex = 1;
            // 
            // entryLimitEventLbl
            // 
            this.entryLimitEventLbl.BackColor = System.Drawing.Color.Transparent;
            this.entryLimitEventLbl.Location = new System.Drawing.Point(12, 192);
            this.entryLimitEventLbl.Name = "entryLimitEventLbl";
            this.entryLimitEventLbl.Size = new System.Drawing.Size(240, 22);
            this.entryLimitEventLbl.TabIndex = 15;
            this.entryLimitEventLbl.Text = "Maximum entries per player";
            // 
            // entryLimitEventTxt
            // 
            this.entryLimitEventTxt.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryLimitEventTxt.Location = new System.Drawing.Point(16, 216);
            this.entryLimitEventTxt.Margin = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.entryLimitEventTxt.Name = "entryLimitEventTxt";
            this.entryLimitEventTxt.Size = new System.Drawing.Size(65, 26);
            this.entryLimitEventTxt.TabIndex = 3;
            this.entryLimitEventTxt.TextChanged += new System.EventHandler(this.entryLimitTxt_TextChanged);
            this.entryLimitEventTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.entryLimitTxt_KeyPress);
            // 
            // minimumEntriesToRunLbl
            // 
            this.minimumEntriesToRunLbl.BackColor = System.Drawing.Color.Transparent;
            this.minimumEntriesToRunLbl.Location = new System.Drawing.Point(12, 128);
            this.minimumEntriesToRunLbl.Name = "minimumEntriesToRunLbl";
            this.minimumEntriesToRunLbl.Size = new System.Drawing.Size(240, 22);
            this.minimumEntriesToRunLbl.TabIndex = 22;
            this.minimumEntriesToRunLbl.Text = "Minimum entries needed";
            // 
            // playerPresenceRequiredChk
            // 
            this.playerPresenceRequiredChk.AutoSize = true;
            this.playerPresenceRequiredChk.BackColor = System.Drawing.Color.Transparent;
            this.playerPresenceRequiredChk.Location = new System.Drawing.Point(364, 148);
            this.playerPresenceRequiredChk.Name = "playerPresenceRequiredChk";
            this.playerPresenceRequiredChk.Size = new System.Drawing.Size(254, 26);
            this.playerPresenceRequiredChk.TabIndex = 7;
            this.playerPresenceRequiredChk.Text = "Player must be present to win";
            this.playerPresenceRequiredChk.UseVisualStyleBackColor = false;
            // 
            // showEntryCountOnReceiptsChk
            // 
            this.showEntryCountOnReceiptsChk.AutoSize = true;
            this.showEntryCountOnReceiptsChk.BackColor = System.Drawing.Color.Transparent;
            this.showEntryCountOnReceiptsChk.Location = new System.Drawing.Point(16, 260);
            this.showEntryCountOnReceiptsChk.Name = "showEntryCountOnReceiptsChk";
            this.showEntryCountOnReceiptsChk.Size = new System.Drawing.Size(291, 26);
            this.showEntryCountOnReceiptsChk.TabIndex = 4;
            this.showEntryCountOnReceiptsChk.Text = "Print player entry count on receipt";
            this.showEntryCountOnReceiptsChk.UseVisualStyleBackColor = false;
            // 
            // minimumEntriesToRunTxt
            // 
            this.minimumEntriesToRunTxt.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimumEntriesToRunTxt.Location = new System.Drawing.Point(16, 152);
            this.minimumEntriesToRunTxt.Name = "minimumEntriesToRunTxt";
            this.minimumEntriesToRunTxt.Size = new System.Drawing.Size(65, 26);
            this.minimumEntriesToRunTxt.TabIndex = 2;
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
            this.eventTP.Size = new System.Drawing.Size(694, 413);
            this.eventTP.TabIndex = 1;
            this.eventTP.Text = "Scheduling ";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_imgbtnSelectAllSession);
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
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.eventRepeatsChk);
            this.splitContainer1.Panel2.Controls.Add(this.initialEventScheduledForLbl);
            this.splitContainer1.Panel2.Controls.Add(this.eventRepeatDetailsPnl);
            this.splitContainer1.Panel2.Controls.Add(this.initialEventScheduledForDTP);
            this.splitContainer1.Size = new System.Drawing.Size(688, 407);
            this.splitContainer1.SplitterDistance = 341;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // m_imgbtnSelectAllSession
            // 
            this.m_imgbtnSelectAllSession.BackColor = System.Drawing.Color.Transparent;
            this.m_imgbtnSelectAllSession.FocusColor = System.Drawing.Color.Black;
            this.m_imgbtnSelectAllSession.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_imgbtnSelectAllSession.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_imgbtnSelectAllSession.Location = new System.Drawing.Point(216, 336);
            this.m_imgbtnSelectAllSession.Margin = new System.Windows.Forms.Padding(4, 8, 16, 4);
            this.m_imgbtnSelectAllSession.MinimumSize = new System.Drawing.Size(30, 30);
            this.m_imgbtnSelectAllSession.Name = "m_imgbtnSelectAllSession";
            this.m_imgbtnSelectAllSession.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_imgbtnSelectAllSession.Size = new System.Drawing.Size(112, 32);
            this.m_imgbtnSelectAllSession.TabIndex = 4;
            this.m_imgbtnSelectAllSession.Text = "Select all";
            this.m_imgbtnSelectAllSession.UseVisualStyleBackColor = false;
            this.m_imgbtnSelectAllSession.Click += new System.EventHandler(this.m_imgbtnSelectAllSession_Click);
            // 
            // entryPeriodLbl
            // 
            this.entryPeriodLbl.BackColor = System.Drawing.Color.Transparent;
            this.entryPeriodLbl.Location = new System.Drawing.Point(12, 16);
            this.entryPeriodLbl.Name = "entryPeriodLbl";
            this.entryPeriodLbl.Size = new System.Drawing.Size(123, 22);
            this.entryPeriodLbl.TabIndex = 37;
            this.entryPeriodLbl.Text = "Entry period";
            // 
            // initialEventEntryPeriodEndDTP
            // 
            this.initialEventEntryPeriodEndDTP.CustomFormat = "ddd dd MMM yyyy";
            this.initialEventEntryPeriodEndDTP.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.initialEventEntryPeriodEndDTP.Location = new System.Drawing.Point(78, 80);
            this.initialEventEntryPeriodEndDTP.Name = "initialEventEntryPeriodEndDTP";
            this.initialEventEntryPeriodEndDTP.Size = new System.Drawing.Size(250, 26);
            this.initialEventEntryPeriodEndDTP.TabIndex = 2;
            this.initialEventEntryPeriodEndDTP.ValueChanged += new System.EventHandler(this.initialEventEntryPeriodEndDTP_ValueChanged);
            // 
            // initialEventEntryPeriodEndLbl
            // 
            this.initialEventEntryPeriodEndLbl.BackColor = System.Drawing.Color.Transparent;
            this.initialEventEntryPeriodEndLbl.Location = new System.Drawing.Point(12, 80);
            this.initialEventEntryPeriodEndLbl.Name = "initialEventEntryPeriodEndLbl";
            this.initialEventEntryPeriodEndLbl.Size = new System.Drawing.Size(54, 26);
            this.initialEventEntryPeriodEndLbl.TabIndex = 24;
            this.initialEventEntryPeriodEndLbl.Text = "Ends";
            this.initialEventEntryPeriodEndLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // initialEventEntryPeriodBeginLbl
            // 
            this.initialEventEntryPeriodBeginLbl.BackColor = System.Drawing.Color.Transparent;
            this.initialEventEntryPeriodBeginLbl.Location = new System.Drawing.Point(12, 48);
            this.initialEventEntryPeriodBeginLbl.Name = "initialEventEntryPeriodBeginLbl";
            this.initialEventEntryPeriodBeginLbl.Size = new System.Drawing.Size(60, 26);
            this.initialEventEntryPeriodBeginLbl.TabIndex = 21;
            this.initialEventEntryPeriodBeginLbl.Text = "Begins";
            this.initialEventEntryPeriodBeginLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // initialEventEntryPeriodBeginDTP
            // 
            this.initialEventEntryPeriodBeginDTP.CustomFormat = "ddd dd MMM yyyy";
            this.initialEventEntryPeriodBeginDTP.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.initialEventEntryPeriodBeginDTP.Location = new System.Drawing.Point(78, 48);
            this.initialEventEntryPeriodBeginDTP.Name = "initialEventEntryPeriodBeginDTP";
            this.initialEventEntryPeriodBeginDTP.Size = new System.Drawing.Size(250, 26);
            this.initialEventEntryPeriodBeginDTP.TabIndex = 1;
            this.initialEventEntryPeriodBeginDTP.ValueChanged += new System.EventHandler(this.initialEventEntryPeriodBeginDTP_ValueChanged);
            // 
            // entrySessionNumbersCL
            // 
            this.entrySessionNumbersCL.CheckOnClick = true;
            this.entrySessionNumbersCL.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entrySessionNumbersCL.FormattingEnabled = true;
            this.entrySessionNumbersCL.IntegralHeight = false;
            this.entrySessionNumbersCL.Location = new System.Drawing.Point(16, 144);
            this.entrySessionNumbersCL.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.entrySessionNumbersCL.MultiColumn = true;
            this.entrySessionNumbersCL.Name = "entrySessionNumbersCL";
            this.entrySessionNumbersCL.Size = new System.Drawing.Size(312, 184);
            this.entrySessionNumbersCL.TabIndex = 3;
            this.entrySessionNumbersCL.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.entrySessionNumbersCL_ItemCheck);
            // 
            // entrySessionsLbl
            // 
            this.entrySessionsLbl.BackColor = System.Drawing.Color.Transparent;
            this.entrySessionsLbl.Location = new System.Drawing.Point(12, 120);
            this.entrySessionsLbl.Name = "entrySessionsLbl";
            this.entrySessionsLbl.Size = new System.Drawing.Size(164, 22);
            this.entrySessionsLbl.TabIndex = 30;
            this.entrySessionsLbl.Text = "Entry session(s)";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 26);
            this.label1.TabIndex = 43;
            this.label1.Text = "Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // eventRepeatsChk
            // 
            this.eventRepeatsChk.AutoSize = true;
            this.eventRepeatsChk.Location = new System.Drawing.Point(16, 84);
            this.eventRepeatsChk.Name = "eventRepeatsChk";
            this.eventRepeatsChk.Size = new System.Drawing.Size(81, 26);
            this.eventRepeatsChk.TabIndex = 6;
            this.eventRepeatsChk.Text = "Repeat";
            this.eventRepeatsChk.UseVisualStyleBackColor = true;
            this.eventRepeatsChk.CheckedChanged += new System.EventHandler(this.eventRepeatsChk_CheckedChanged);
            // 
            // initialEventScheduledForLbl
            // 
            this.initialEventScheduledForLbl.BackColor = System.Drawing.Color.Transparent;
            this.initialEventScheduledForLbl.Location = new System.Drawing.Point(12, 16);
            this.initialEventScheduledForLbl.Name = "initialEventScheduledForLbl";
            this.initialEventScheduledForLbl.Size = new System.Drawing.Size(190, 22);
            this.initialEventScheduledForLbl.TabIndex = 36;
            this.initialEventScheduledForLbl.Text = "Scheduled to run on ";
            // 
            // eventRepeatDetailsPnl
            // 
            this.eventRepeatDetailsPnl.Controls.Add(this.eventRepeatIncrementTxt);
            this.eventRepeatDetailsPnl.Controls.Add(this.eventRepetitionRateLbl);
            this.eventRepeatDetailsPnl.Controls.Add(this.eventRepetitionEndsLbl);
            this.eventRepeatDetailsPnl.Controls.Add(this.eventExamplesLV);
            this.eventRepeatDetailsPnl.Controls.Add(this.eventRepeatIntervalCB);
            this.eventRepeatDetailsPnl.Controls.Add(this.eventRepetitionEndsDTP);
            this.eventRepeatDetailsPnl.Controls.Add(this.eventWindowExamplesLbl);
            this.eventRepeatDetailsPnl.Location = new System.Drawing.Point(8, 112);
            this.eventRepeatDetailsPnl.Margin = new System.Windows.Forms.Padding(0);
            this.eventRepeatDetailsPnl.Name = "eventRepeatDetailsPnl";
            this.eventRepeatDetailsPnl.Size = new System.Drawing.Size(338, 294);
            this.eventRepeatDetailsPnl.TabIndex = 42;
            this.eventRepeatDetailsPnl.TabStop = false;
            // 
            // eventRepeatIncrementTxt
            // 
            this.eventRepeatIncrementTxt.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventRepeatIncrementTxt.Location = new System.Drawing.Point(102, 20);
            this.eventRepeatIncrementTxt.Multiline = true;
            this.eventRepeatIncrementTxt.Name = "eventRepeatIncrementTxt";
            this.eventRepeatIncrementTxt.Size = new System.Drawing.Size(94, 30);
            this.eventRepeatIncrementTxt.TabIndex = 7;
            this.eventRepeatIncrementTxt.TextChanged += new System.EventHandler(this.eventRepeatIncrementTxt_TextChanged);
            this.eventRepeatIncrementTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.entryPeriodRepeatIncrementTxt_KeyPress);
            // 
            // eventRepetitionRateLbl
            // 
            this.eventRepetitionRateLbl.BackColor = System.Drawing.Color.Transparent;
            this.eventRepetitionRateLbl.Location = new System.Drawing.Point(4, 20);
            this.eventRepetitionRateLbl.Name = "eventRepetitionRateLbl";
            this.eventRepetitionRateLbl.Size = new System.Drawing.Size(54, 30);
            this.eventRepetitionRateLbl.TabIndex = 35;
            this.eventRepetitionRateLbl.Text = "Every";
            this.eventRepetitionRateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // eventRepetitionEndsLbl
            // 
            this.eventRepetitionEndsLbl.BackColor = System.Drawing.Color.Transparent;
            this.eventRepetitionEndsLbl.Location = new System.Drawing.Point(4, 60);
            this.eventRepetitionEndsLbl.Name = "eventRepetitionEndsLbl";
            this.eventRepetitionEndsLbl.Size = new System.Drawing.Size(86, 26);
            this.eventRepetitionEndsLbl.TabIndex = 29;
            this.eventRepetitionEndsLbl.Text = "Ending on";
            this.eventRepetitionEndsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // eventExamplesLV
            // 
            this.eventExamplesLV.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventExamplesLV.Location = new System.Drawing.Point(8, 120);
            this.eventExamplesLV.Margin = new System.Windows.Forms.Padding(8, 3, 16, 8);
            this.eventExamplesLV.Name = "eventExamplesLV";
            this.eventExamplesLV.Size = new System.Drawing.Size(320, 142);
            this.eventExamplesLV.TabIndex = 10;
            this.eventExamplesLV.UseCompatibleStateImageBehavior = false;
            this.eventExamplesLV.View = System.Windows.Forms.View.Details;
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
            this.eventRepeatIntervalCB.Location = new System.Drawing.Point(205, 20);
            this.eventRepeatIntervalCB.Name = "eventRepeatIntervalCB";
            this.eventRepeatIntervalCB.Size = new System.Drawing.Size(123, 30);
            this.eventRepeatIntervalCB.TabIndex = 8;
            this.eventRepeatIntervalCB.SelectedIndexChanged += new System.EventHandler(this.eventRepeatIntervalCB_SelectedIndexChanged);
            // 
            // eventRepetitionEndsDTP
            // 
            this.eventRepetitionEndsDTP.Checked = false;
            this.eventRepetitionEndsDTP.CustomFormat = "ddd dd MMM yyyy";
            this.eventRepetitionEndsDTP.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventRepetitionEndsDTP.Location = new System.Drawing.Point(102, 60);
            this.eventRepetitionEndsDTP.Margin = new System.Windows.Forms.Padding(3, 3, 16, 3);
            this.eventRepetitionEndsDTP.Name = "eventRepetitionEndsDTP";
            this.eventRepetitionEndsDTP.ShowCheckBox = true;
            this.eventRepetitionEndsDTP.Size = new System.Drawing.Size(226, 26);
            this.eventRepetitionEndsDTP.TabIndex = 9;
            this.eventRepetitionEndsDTP.ValueChanged += new System.EventHandler(this.eventRepetitionEndsDTP_ValueChanged);
            // 
            // eventWindowExamplesLbl
            // 
            this.eventWindowExamplesLbl.BackColor = System.Drawing.Color.Transparent;
            this.eventWindowExamplesLbl.Location = new System.Drawing.Point(4, 96);
            this.eventWindowExamplesLbl.Name = "eventWindowExamplesLbl";
            this.eventWindowExamplesLbl.Size = new System.Drawing.Size(212, 22);
            this.eventWindowExamplesLbl.TabIndex = 37;
            this.eventWindowExamplesLbl.Text = "Recurring schedule";
            // 
            // initialEventScheduledForDTP
            // 
            this.initialEventScheduledForDTP.Checked = false;
            this.initialEventScheduledForDTP.CustomFormat = "ddd dd MMM yyyy";
            this.initialEventScheduledForDTP.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.initialEventScheduledForDTP.Location = new System.Drawing.Point(82, 48);
            this.initialEventScheduledForDTP.Name = "initialEventScheduledForDTP";
            this.initialEventScheduledForDTP.ShowCheckBox = true;
            this.initialEventScheduledForDTP.Size = new System.Drawing.Size(254, 26);
            this.initialEventScheduledForDTP.TabIndex = 5;
            this.initialEventScheduledForDTP.ValueChanged += new System.EventHandler(this.initialEventScheduledForDTP_ValueChanged);
            // 
            // entryMethodsTP
            // 
            this.entryMethodsTP.BackColor = System.Drawing.Color.LightSteelBlue;
            this.entryMethodsTP.Controls.Add(this.entryMethodsTC);
            this.entryMethodsTP.Location = new System.Drawing.Point(4, 31);
            this.entryMethodsTP.Name = "entryMethodsTP";
            this.entryMethodsTP.Padding = new System.Windows.Forms.Padding(3);
            this.entryMethodsTP.Size = new System.Drawing.Size(694, 413);
            this.entryMethodsTP.TabIndex = 2;
            this.entryMethodsTP.Text = "Entry Methods ";
            // 
            // entryMethodsTC
            // 
            this.entryMethodsTC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.entryMethodsTC.Controls.Add(this.entryVisitsTP);
            this.entryMethodsTC.Controls.Add(this.entryPurchasesTP);
            this.entryMethodsTC.Controls.Add(this.entrySpendTP);
            this.entryMethodsTC.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.entryMethodsTC.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryMethodsTC.ItemSize = new System.Drawing.Size(79, 27);
            this.entryMethodsTC.Location = new System.Drawing.Point(-4, -6);
            this.entryMethodsTC.Margin = new System.Windows.Forms.Padding(8);
            this.entryMethodsTC.Name = "entryMethodsTC";
            this.entryMethodsTC.Padding = new System.Drawing.Point(0, 0);
            this.entryMethodsTC.SelectedIndex = 0;
            this.entryMethodsTC.Size = new System.Drawing.Size(702, 422);
            this.entryMethodsTC.TabIndex = 4;
            this.entryMethodsTC.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.entryMethodsTC_DrawItem);
            // 
            // entryVisitsTP
            // 
            this.entryVisitsTP.BackColor = System.Drawing.Color.LightSteelBlue;
            this.entryVisitsTP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.entryVisitsTP.Controls.Add(this.addEntryVisitTierBtn);
            this.entryVisitsTP.Controls.Add(this.entryVisitScaleDGV);
            this.entryVisitsTP.Controls.Add(this.entryVisitsTypeFLP);
            this.entryVisitsTP.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryVisitsTP.Location = new System.Drawing.Point(4, 31);
            this.entryVisitsTP.Name = "entryVisitsTP";
            this.entryVisitsTP.Padding = new System.Windows.Forms.Padding(3);
            this.entryVisitsTP.Size = new System.Drawing.Size(694, 387);
            this.entryVisitsTP.TabIndex = 1;
            this.entryVisitsTP.Text = "Visit";
            // 
            // addEntryVisitTierBtn
            // 
            this.addEntryVisitTierBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addEntryVisitTierBtn.FocusColor = System.Drawing.Color.Black;
            this.addEntryVisitTierBtn.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.addEntryVisitTierBtn.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.addEntryVisitTierBtn.Location = new System.Drawing.Point(582, 342);
            this.addEntryVisitTierBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addEntryVisitTierBtn.MinimumSize = new System.Drawing.Size(30, 30);
            this.addEntryVisitTierBtn.Name = "addEntryVisitTierBtn";
            this.addEntryVisitTierBtn.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.addEntryVisitTierBtn.Size = new System.Drawing.Size(64, 32);
            this.addEntryVisitTierBtn.TabIndex = 6;
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
            this.entryVisitScaleDGV.Location = new System.Drawing.Point(177, 16);
            this.entryVisitScaleDGV.Margin = new System.Windows.Forms.Padding(8);
            this.entryVisitScaleDGV.MultiSelect = false;
            this.entryVisitScaleDGV.Name = "entryVisitScaleDGV";
            this.entryVisitScaleDGV.RowHeadersVisible = false;
            this.entryVisitScaleDGV.RowTemplate.Height = 30;
            this.entryVisitScaleDGV.Size = new System.Drawing.Size(470, 318);
            this.entryVisitScaleDGV.TabIndex = 5;
            this.entryVisitScaleDGV.Tag = "2";
            this.entryVisitScaleDGV.Visible = false;
            this.entryVisitScaleDGV.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.entrySpendScaleDGV_EditingControlShowing);
            // 
            // entryVisitsTypeFLP
            // 
            this.entryVisitsTypeFLP.Controls.Add(this.entryVisitTypeNoneRB);
            this.entryVisitsTypeFLP.Controls.Add(this.entryVisitTypeSessionsPerDayRB);
            this.entryVisitsTypeFLP.Controls.Add(this.entryVisitTypeSessionsInEntryPeriodRB);
            this.entryVisitsTypeFLP.Controls.Add(this.entryVisitTypeDaysInEntryPeriodWindowRB);
            this.entryVisitsTypeFLP.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.entryVisitsTypeFLP.Location = new System.Drawing.Point(16, 16);
            this.entryVisitsTypeFLP.Name = "entryVisitsTypeFLP";
            this.entryVisitsTypeFLP.Size = new System.Drawing.Size(162, 313);
            this.entryVisitsTypeFLP.TabIndex = 6;
            this.entryVisitsTypeFLP.WrapContents = false;
            // 
            // entryVisitTypeNoneRB
            // 
            this.entryVisitTypeNoneRB.AutoSize = true;
            this.entryVisitTypeNoneRB.Location = new System.Drawing.Point(3, 3);
            this.entryVisitTypeNoneRB.Name = "entryVisitTypeNoneRB";
            this.entryVisitTypeNoneRB.Size = new System.Drawing.Size(67, 26);
            this.entryVisitTypeNoneRB.TabIndex = 1;
            this.entryVisitTypeNoneRB.Text = "None";
            this.entryVisitTypeNoneRB.UseVisualStyleBackColor = true;
            this.entryVisitTypeNoneRB.CheckedChanged += new System.EventHandler(this.entryVisitTypeRB_CheckedChanged);
            // 
            // entryVisitTypeSessionsPerDayRB
            // 
            this.entryVisitTypeSessionsPerDayRB.AutoSize = true;
            this.entryVisitTypeSessionsPerDayRB.Location = new System.Drawing.Point(3, 35);
            this.entryVisitTypeSessionsPerDayRB.Name = "entryVisitTypeSessionsPerDayRB";
            this.entryVisitTypeSessionsPerDayRB.Size = new System.Drawing.Size(151, 26);
            this.entryVisitTypeSessionsPerDayRB.TabIndex = 2;
            this.entryVisitTypeSessionsPerDayRB.Text = "Sessions per day";
            this.entryVisitTypeSessionsPerDayRB.UseVisualStyleBackColor = true;
            this.entryVisitTypeSessionsPerDayRB.CheckedChanged += new System.EventHandler(this.entryVisitTypeRB_CheckedChanged);
            // 
            // entryVisitTypeSessionsInEntryPeriodRB
            // 
            this.entryVisitTypeSessionsInEntryPeriodRB.AutoSize = true;
            this.entryVisitTypeSessionsInEntryPeriodRB.Location = new System.Drawing.Point(3, 67);
            this.entryVisitTypeSessionsInEntryPeriodRB.Name = "entryVisitTypeSessionsInEntryPeriodRB";
            this.entryVisitTypeSessionsInEntryPeriodRB.Size = new System.Drawing.Size(90, 26);
            this.entryVisitTypeSessionsInEntryPeriodRB.TabIndex = 3;
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
            this.entryVisitTypeDaysInEntryPeriodWindowRB.TabIndex = 4;
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
            this.entryPurchasesTP.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryPurchasesTP.Location = new System.Drawing.Point(4, 31);
            this.entryPurchasesTP.Name = "entryPurchasesTP";
            this.entryPurchasesTP.Padding = new System.Windows.Forms.Padding(3);
            this.entryPurchasesTP.Size = new System.Drawing.Size(694, 387);
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
            this.entryPurchaseGroupingFLP.Location = new System.Drawing.Point(6, 14);
            this.entryPurchaseGroupingFLP.Name = "entryPurchaseGroupingFLP";
            this.entryPurchaseGroupingFLP.Size = new System.Drawing.Size(141, 286);
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
            this.entryPurchaseSelectionsCL.Size = new System.Drawing.Size(412, 214);
            this.entryPurchaseSelectionsCL.TabIndex = 11;
            this.entryPurchaseSelectionsCL.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.entryPurchaseSelectionsCL_ItemCheck);
            // 
            // addEntryPurchaseTierBtn
            // 
            this.addEntryPurchaseTierBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addEntryPurchaseTierBtn.FocusColor = System.Drawing.Color.Black;
            this.addEntryPurchaseTierBtn.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.addEntryPurchaseTierBtn.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.addEntryPurchaseTierBtn.Location = new System.Drawing.Point(560, 179);
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
            this.entryPurchaseScaleDGV.Size = new System.Drawing.Size(485, 159);
            this.entryPurchaseScaleDGV.TabIndex = 9;
            this.entryPurchaseScaleDGV.Tag = "3";
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
            this.entryPurchaseTypeFLP.Size = new System.Drawing.Size(162, 146);
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
            this.entrySpendTP.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entrySpendTP.Location = new System.Drawing.Point(4, 31);
            this.entrySpendTP.Name = "entrySpendTP";
            this.entrySpendTP.Padding = new System.Windows.Forms.Padding(3);
            this.entrySpendTP.Size = new System.Drawing.Size(694, 387);
            this.entrySpendTP.TabIndex = 0;
            this.entrySpendTP.Text = "Spend";
            // 
            // addEntrySpendTierBtn
            // 
            this.addEntrySpendTierBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addEntrySpendTierBtn.FocusColor = System.Drawing.Color.Black;
            this.addEntrySpendTierBtn.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.addEntrySpendTierBtn.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.addEntrySpendTierBtn.Location = new System.Drawing.Point(582, 342);
            this.addEntrySpendTierBtn.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.addEntrySpendTierBtn.MinimumSize = new System.Drawing.Size(30, 30);
            this.addEntrySpendTierBtn.Name = "addEntrySpendTierBtn";
            this.addEntrySpendTierBtn.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.addEntrySpendTierBtn.Size = new System.Drawing.Size(64, 32);
            this.addEntrySpendTierBtn.TabIndex = 7;
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
            this.entrySpendScaleDGV.Location = new System.Drawing.Point(177, 16);
            this.entrySpendScaleDGV.Margin = new System.Windows.Forms.Padding(8, 16, 16, 0);
            this.entrySpendScaleDGV.MultiSelect = false;
            this.entrySpendScaleDGV.Name = "entrySpendScaleDGV";
            this.entrySpendScaleDGV.RowHeadersVisible = false;
            this.entrySpendScaleDGV.RowTemplate.Height = 30;
            this.entrySpendScaleDGV.Size = new System.Drawing.Size(470, 318);
            this.entrySpendScaleDGV.TabIndex = 6;
            this.entrySpendScaleDGV.Tag = "1";
            this.entrySpendScaleDGV.Visible = false;
            this.entrySpendScaleDGV.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.entrySpendScaleDGV_EditingControlShowing);
            // 
            // entrySpendGroupingFLP
            // 
            this.entrySpendGroupingFLP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entrySpendGroupingFLP.Controls.Add(this.entrySpendGroupingNoneRB);
            this.entrySpendGroupingFLP.Controls.Add(this.entrySpendGroupingBySessionRB);
            this.entrySpendGroupingFLP.Controls.Add(this.entrySpendGroupingByDayRB);
            this.entrySpendGroupingFLP.Controls.Add(this.entrySpendGroupingByTransactionRB);
            this.entrySpendGroupingFLP.Controls.Add(this.entrySpendGroupingEntryPeriodRB);
            this.entrySpendGroupingFLP.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.entrySpendGroupingFLP.Location = new System.Drawing.Point(16, 16);
            this.entrySpendGroupingFLP.Name = "entrySpendGroupingFLP";
            this.entrySpendGroupingFLP.Size = new System.Drawing.Size(161, 313);
            this.entrySpendGroupingFLP.TabIndex = 4;
            this.entrySpendGroupingFLP.WrapContents = false;
            // 
            // entrySpendGroupingNoneRB
            // 
            this.entrySpendGroupingNoneRB.AutoSize = true;
            this.entrySpendGroupingNoneRB.Location = new System.Drawing.Point(3, 3);
            this.entrySpendGroupingNoneRB.Name = "entrySpendGroupingNoneRB";
            this.entrySpendGroupingNoneRB.Size = new System.Drawing.Size(67, 26);
            this.entrySpendGroupingNoneRB.TabIndex = 1;
            this.entrySpendGroupingNoneRB.Text = "None";
            this.entrySpendGroupingNoneRB.UseVisualStyleBackColor = true;
            this.entrySpendGroupingNoneRB.CheckedChanged += new System.EventHandler(this.entrySpendGroupingRB_CheckedChanged);
            // 
            // entrySpendGroupingBySessionRB
            // 
            this.entrySpendGroupingBySessionRB.AutoSize = true;
            this.entrySpendGroupingBySessionRB.Location = new System.Drawing.Point(3, 35);
            this.entrySpendGroupingBySessionRB.Name = "entrySpendGroupingBySessionRB";
            this.entrySpendGroupingBySessionRB.Size = new System.Drawing.Size(83, 26);
            this.entrySpendGroupingBySessionRB.TabIndex = 2;
            this.entrySpendGroupingBySessionRB.Text = "Session";
            this.entrySpendGroupingBySessionRB.UseVisualStyleBackColor = true;
            this.entrySpendGroupingBySessionRB.CheckedChanged += new System.EventHandler(this.entrySpendGroupingRB_CheckedChanged);
            // 
            // entrySpendGroupingByDayRB
            // 
            this.entrySpendGroupingByDayRB.AutoSize = true;
            this.entrySpendGroupingByDayRB.Location = new System.Drawing.Point(3, 67);
            this.entrySpendGroupingByDayRB.Name = "entrySpendGroupingByDayRB";
            this.entrySpendGroupingByDayRB.Size = new System.Drawing.Size(55, 26);
            this.entrySpendGroupingByDayRB.TabIndex = 3;
            this.entrySpendGroupingByDayRB.Text = "Day";
            this.entrySpendGroupingByDayRB.UseVisualStyleBackColor = true;
            this.entrySpendGroupingByDayRB.CheckedChanged += new System.EventHandler(this.entrySpendGroupingRB_CheckedChanged);
            // 
            // entrySpendGroupingByTransactionRB
            // 
            this.entrySpendGroupingByTransactionRB.AutoSize = true;
            this.entrySpendGroupingByTransactionRB.Location = new System.Drawing.Point(3, 99);
            this.entrySpendGroupingByTransactionRB.Name = "entrySpendGroupingByTransactionRB";
            this.entrySpendGroupingByTransactionRB.Size = new System.Drawing.Size(118, 26);
            this.entrySpendGroupingByTransactionRB.TabIndex = 4;
            this.entrySpendGroupingByTransactionRB.Text = "Transaction";
            this.entrySpendGroupingByTransactionRB.UseVisualStyleBackColor = true;
            this.entrySpendGroupingByTransactionRB.CheckedChanged += new System.EventHandler(this.entrySpendGroupingRB_CheckedChanged);
            // 
            // entrySpendGroupingEntryPeriodRB
            // 
            this.entrySpendGroupingEntryPeriodRB.AutoSize = true;
            this.entrySpendGroupingEntryPeriodRB.Location = new System.Drawing.Point(3, 131);
            this.entrySpendGroupingEntryPeriodRB.Name = "entrySpendGroupingEntryPeriodRB";
            this.entrySpendGroupingEntryPeriodRB.Size = new System.Drawing.Size(121, 26);
            this.entrySpendGroupingEntryPeriodRB.TabIndex = 5;
            this.entrySpendGroupingEntryPeriodRB.Text = "Entry Period";
            this.entrySpendGroupingEntryPeriodRB.UseVisualStyleBackColor = true;
            this.entrySpendGroupingEntryPeriodRB.CheckedChanged += new System.EventHandler(this.entrySpendGroupingRB_CheckedChanged);
            // 
            // drawingActiveChk
            // 
            this.drawingActiveChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingActiveChk.AutoSize = true;
            this.drawingActiveChk.BackColor = System.Drawing.Color.Transparent;
            this.drawingActiveChk.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawingActiveChk.Location = new System.Drawing.Point(646, 30);
            this.drawingActiveChk.Name = "drawingActiveChk";
            this.drawingActiveChk.Size = new System.Drawing.Size(77, 26);
            this.drawingActiveChk.TabIndex = 6;
            this.drawingActiveChk.Text = "Active";
            this.drawingActiveChk.UseVisualStyleBackColor = false;
            // 
            // drawingNameTxt
            // 
            this.drawingNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingNameTxt.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawingNameTxt.Location = new System.Drawing.Point(70, 32);
            this.drawingNameTxt.Margin = new System.Windows.Forms.Padding(0);
            this.drawingNameTxt.MaxLength = 48;
            this.drawingNameTxt.Name = "drawingNameTxt";
            this.drawingNameTxt.Size = new System.Drawing.Size(565, 26);
            this.drawingNameTxt.TabIndex = 5;
            this.drawingNameTxt.TextChanged += new System.EventHandler(this.drawingNameTxt_TextChanged);
            // 
            // revertDrawingChangesBtn
            // 
            this.revertDrawingChangesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.revertDrawingChangesBtn.BackColor = System.Drawing.Color.Transparent;
            this.revertDrawingChangesBtn.FocusColor = System.Drawing.Color.Black;
            this.revertDrawingChangesBtn.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.revertDrawingChangesBtn.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.revertDrawingChangesBtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.revertDrawingChangesBtn.Location = new System.Drawing.Point(16, 526);
            this.revertDrawingChangesBtn.Margin = new System.Windows.Forms.Padding(16, 4, 4, 4);
            this.revertDrawingChangesBtn.MinimumSize = new System.Drawing.Size(30, 30);
            this.revertDrawingChangesBtn.Name = "revertDrawingChangesBtn";
            this.revertDrawingChangesBtn.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.revertDrawingChangesBtn.Size = new System.Drawing.Size(140, 40);
            this.revertDrawingChangesBtn.TabIndex = 8;
            this.revertDrawingChangesBtn.Text = "Revert";
            this.revertDrawingChangesBtn.UseVisualStyleBackColor = false;
            this.revertDrawingChangesBtn.Click += new System.EventHandler(this.revertDrawingChangesBtn_Click);
            // 
            // drawingNameLbl
            // 
            this.drawingNameLbl.BackColor = System.Drawing.Color.Transparent;
            this.drawingNameLbl.Location = new System.Drawing.Point(12, 32);
            this.drawingNameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.cancelDrawingChangesBtn.Location = new System.Drawing.Point(578, 526);
            this.cancelDrawingChangesBtn.Margin = new System.Windows.Forms.Padding(4);
            this.cancelDrawingChangesBtn.MinimumSize = new System.Drawing.Size(30, 30);
            this.cancelDrawingChangesBtn.Name = "cancelDrawingChangesBtn";
            this.cancelDrawingChangesBtn.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.cancelDrawingChangesBtn.Size = new System.Drawing.Size(140, 40);
            this.cancelDrawingChangesBtn.TabIndex = 10;
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
            this.saveDrawingChangesBtn.Location = new System.Drawing.Point(430, 526);
            this.saveDrawingChangesBtn.Margin = new System.Windows.Forms.Padding(4);
            this.saveDrawingChangesBtn.MinimumSize = new System.Drawing.Size(30, 30);
            this.saveDrawingChangesBtn.Name = "saveDrawingChangesBtn";
            this.saveDrawingChangesBtn.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.saveDrawingChangesBtn.Size = new System.Drawing.Size(140, 40);
            this.saveDrawingChangesBtn.TabIndex = 9;
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
            this.closeBtn.Location = new System.Drawing.Point(856, 597);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(3, 3, 16, 3);
            this.closeBtn.MinimumSize = new System.Drawing.Size(30, 30);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.closeBtn.Size = new System.Drawing.Size(140, 40);
            this.closeBtn.TabIndex = 12;
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
            this.copyDrawingBtn.Location = new System.Drawing.Point(59, 542);
            this.copyDrawingBtn.Margin = new System.Windows.Forms.Padding(4);
            this.copyDrawingBtn.MinimumSize = new System.Drawing.Size(30, 30);
            this.copyDrawingBtn.Name = "copyDrawingBtn";
            this.copyDrawingBtn.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.copyDrawingBtn.Size = new System.Drawing.Size(140, 40);
            this.copyDrawingBtn.TabIndex = 4;
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
            this.testEventsBtn.Location = new System.Drawing.Point(359, 604);
            this.testEventsBtn.Name = "testEventsBtn";
            this.testEventsBtn.Size = new System.Drawing.Size(131, 27);
            this.testEventsBtn.TabIndex = 24;
            this.testEventsBtn.Text = "Event Testing";
            this.testEventsBtn.UseVisualStyleBackColor = true;
            this.testEventsBtn.Visible = false;
            this.testEventsBtn.Click += new System.EventHandler(this.testEventsBtn_Click);
            // 
            // GeneralPlayerDrawingForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(1010, 643);
            this.ControlBox = false;
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GeneralPlayerDrawingForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
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
        private System.Windows.Forms.CheckedListBox entryPurchaseSelectionsCL;
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
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controls.ImageButton m_imgbtnSelectAllSession;
        private System.Windows.Forms.GroupBox eventRepeatDetailsPnl;
        private System.Windows.Forms.Label drawingDescriptionLbl;
        private System.Windows.Forms.TextBox txtbx_PrizeDescription;
        private System.Windows.Forms.Label lbl_prizeDescription;
        private System.Windows.Forms.Label lbl_Disclaimer;
        private System.Windows.Forms.TextBox txtbx_disclaimer;
        private System.Windows.Forms.Label label1;
    }
}