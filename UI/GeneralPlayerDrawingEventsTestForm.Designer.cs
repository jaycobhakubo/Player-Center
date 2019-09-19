namespace GTI.Modules.PlayerCenter.UI
{
    partial class GeneralPlayerDrawingEventsTestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralPlayerDrawingEventsTestForm));
            this.drawingEventsLV = new System.Windows.Forms.ListView();
            this.imgbtnRefresh = new GTI.Controls.ImageButton();
            this.imgbtnAbortResult = new GTI.Controls.ImageButton();
            this.imgbtnInitiateResults = new GTI.Controls.ImageButton();
            this.imgbtnViewEntriesResult = new GTI.Controls.ImageButton();
            this.imgbtnExecute = new GTI.Controls.ImageButton();
            this.imgbtnReinstate = new GTI.Controls.ImageButton();
            this.imgbtnCancel = new GTI.Controls.ImageButton();
            this.imgBtnClose = new GTI.Controls.ImageButton();
            this.cmbxAvailableRaffles = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // drawingEventsLV
            // 
            this.drawingEventsLV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingEventsLV.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawingEventsLV.FullRowSelect = true;
            this.drawingEventsLV.HideSelection = false;
            this.drawingEventsLV.Location = new System.Drawing.Point(10, 37);
            this.drawingEventsLV.MultiSelect = false;
            this.drawingEventsLV.Name = "drawingEventsLV";
            this.drawingEventsLV.Size = new System.Drawing.Size(990, 541);
            this.drawingEventsLV.TabIndex = 28;
            this.drawingEventsLV.UseCompatibleStateImageBehavior = false;
            this.drawingEventsLV.View = System.Windows.Forms.View.Details;
            this.drawingEventsLV.SelectedIndexChanged += new System.EventHandler(this.drawingEventsLV_SelectedIndexChanged);
            // 
            // imgbtnRefresh
            // 
            this.imgbtnRefresh.FocusColor = System.Drawing.Color.Black;
            this.imgbtnRefresh.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.imgbtnRefresh.ImageIcon = ((System.Drawing.Image)(resources.GetObject("imgbtnRefresh.ImageIcon")));
            this.imgbtnRefresh.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.imgbtnRefresh.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.imgbtnRefresh.Location = new System.Drawing.Point(811, 587);
            this.imgbtnRefresh.MinimumSize = new System.Drawing.Size(30, 30);
            this.imgbtnRefresh.Name = "imgbtnRefresh";
            this.imgbtnRefresh.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.imgbtnRefresh.Size = new System.Drawing.Size(92, 45);
            this.imgbtnRefresh.TabIndex = 41;
            this.imgbtnRefresh.Click += new System.EventHandler(this.refreshEventsListBtn_Click);
            // 
            // imgbtnAbortResult
            // 
            this.imgbtnAbortResult.FocusColor = System.Drawing.Color.Black;
            this.imgbtnAbortResult.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.imgbtnAbortResult.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.imgbtnAbortResult.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.imgbtnAbortResult.Location = new System.Drawing.Point(10, 587);
            this.imgbtnAbortResult.MinimumSize = new System.Drawing.Size(30, 30);
            this.imgbtnAbortResult.Name = "imgbtnAbortResult";
            this.imgbtnAbortResult.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.imgbtnAbortResult.Size = new System.Drawing.Size(129, 45);
            this.imgbtnAbortResult.TabIndex = 35;
            this.imgbtnAbortResult.Text = "Cancel Winner Display";
            this.imgbtnAbortResult.Click += new System.EventHandler(this.abortEventResultsBroadcastBtn_Click);
            // 
            // imgbtnInitiateResults
            // 
            this.imgbtnInitiateResults.FocusColor = System.Drawing.Color.Black;
            this.imgbtnInitiateResults.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.imgbtnInitiateResults.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.imgbtnInitiateResults.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.imgbtnInitiateResults.Location = new System.Drawing.Point(280, 587);
            this.imgbtnInitiateResults.MinimumSize = new System.Drawing.Size(30, 30);
            this.imgbtnInitiateResults.Name = "imgbtnInitiateResults";
            this.imgbtnInitiateResults.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.imgbtnInitiateResults.Size = new System.Drawing.Size(129, 45);
            this.imgbtnInitiateResults.TabIndex = 37;
            this.imgbtnInitiateResults.Text = "Initiate Results Broadcast";
            this.imgbtnInitiateResults.Visible = false;
            this.imgbtnInitiateResults.Click += new System.EventHandler(this.initiateEventResultsBroadcastBtn_Click);
            // 
            // imgbtnViewEntriesResult
            // 
            this.imgbtnViewEntriesResult.FocusColor = System.Drawing.Color.Black;
            this.imgbtnViewEntriesResult.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.imgbtnViewEntriesResult.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.imgbtnViewEntriesResult.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.imgbtnViewEntriesResult.Location = new System.Drawing.Point(145, 587);
            this.imgbtnViewEntriesResult.MinimumSize = new System.Drawing.Size(30, 30);
            this.imgbtnViewEntriesResult.Name = "imgbtnViewEntriesResult";
            this.imgbtnViewEntriesResult.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.imgbtnViewEntriesResult.Size = new System.Drawing.Size(129, 45);
            this.imgbtnViewEntriesResult.TabIndex = 36;
            this.imgbtnViewEntriesResult.Text = "View Entries && Results";
            this.imgbtnViewEntriesResult.Click += new System.EventHandler(this.viewEntriesAndResultsBtn_Click);
            // 
            // imgbtnExecute
            // 
            this.imgbtnExecute.FocusColor = System.Drawing.Color.Black;
            this.imgbtnExecute.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.imgbtnExecute.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.imgbtnExecute.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.imgbtnExecute.Location = new System.Drawing.Point(713, 587);
            this.imgbtnExecute.MinimumSize = new System.Drawing.Size(30, 30);
            this.imgbtnExecute.Name = "imgbtnExecute";
            this.imgbtnExecute.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.imgbtnExecute.Size = new System.Drawing.Size(92, 45);
            this.imgbtnExecute.TabIndex = 40;
            this.imgbtnExecute.Text = "Run";
            this.imgbtnExecute.Click += new System.EventHandler(this.executeEventBtn_Click);
            // 
            // imgbtnReinstate
            // 
            this.imgbtnReinstate.FocusColor = System.Drawing.Color.Black;
            this.imgbtnReinstate.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.imgbtnReinstate.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.imgbtnReinstate.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.imgbtnReinstate.Location = new System.Drawing.Point(615, 587);
            this.imgbtnReinstate.MinimumSize = new System.Drawing.Size(30, 30);
            this.imgbtnReinstate.Name = "imgbtnReinstate";
            this.imgbtnReinstate.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.imgbtnReinstate.Size = new System.Drawing.Size(92, 45);
            this.imgbtnReinstate.TabIndex = 39;
            this.imgbtnReinstate.Text = "Reinstate";
            this.imgbtnReinstate.Click += new System.EventHandler(this.reinstateEventBtn_Click);
            // 
            // imgbtnCancel
            // 
            this.imgbtnCancel.FocusColor = System.Drawing.Color.Black;
            this.imgbtnCancel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.imgbtnCancel.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.imgbtnCancel.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.imgbtnCancel.Location = new System.Drawing.Point(518, 587);
            this.imgbtnCancel.MinimumSize = new System.Drawing.Size(30, 30);
            this.imgbtnCancel.Name = "imgbtnCancel";
            this.imgbtnCancel.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.imgbtnCancel.Size = new System.Drawing.Size(92, 45);
            this.imgbtnCancel.TabIndex = 38;
            this.imgbtnCancel.Text = "Cancel";
            this.imgbtnCancel.Click += new System.EventHandler(this.cancelEventBtn_Click);
            // 
            // imgBtnClose
            // 
            this.imgBtnClose.FocusColor = System.Drawing.Color.Black;
            this.imgBtnClose.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.imgBtnClose.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.imgBtnClose.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.imgBtnClose.Location = new System.Drawing.Point(908, 587);
            this.imgBtnClose.MinimumSize = new System.Drawing.Size(30, 30);
            this.imgBtnClose.Name = "imgBtnClose";
            this.imgBtnClose.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.imgBtnClose.Size = new System.Drawing.Size(92, 45);
            this.imgBtnClose.TabIndex = 42;
            this.imgBtnClose.Text = "Close";
            this.imgBtnClose.Click += new System.EventHandler(this.imgBtnClose_Click);
            // 
            // cmbxAvailableRaffles
            // 
            this.cmbxAvailableRaffles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxAvailableRaffles.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxAvailableRaffles.FormattingEnabled = true;
            this.cmbxAvailableRaffles.Items.AddRange(new object[] {
            "Current",
            "Completed",
            "Cancel",
            "All"});
            this.cmbxAvailableRaffles.Location = new System.Drawing.Point(10, 3);
            this.cmbxAvailableRaffles.Name = "cmbxAvailableRaffles";
            this.cmbxAvailableRaffles.Size = new System.Drawing.Size(247, 30);
            this.cmbxAvailableRaffles.TabIndex = 44;
            this.cmbxAvailableRaffles.SelectedIndexChanged += new System.EventHandler(this.m_genderList_SelectedIndexChanged);
            // 
            // GeneralPlayerDrawingEventsTestForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1010, 641);
            this.Controls.Add(this.cmbxAvailableRaffles);
            this.Controls.Add(this.imgBtnClose);
            this.Controls.Add(this.imgbtnCancel);
            this.Controls.Add(this.imgbtnExecute);
            this.Controls.Add(this.imgbtnAbortResult);
            this.Controls.Add(this.imgbtnReinstate);
            this.Controls.Add(this.imgbtnViewEntriesResult);
            this.Controls.Add(this.imgbtnRefresh);
            this.Controls.Add(this.imgbtnInitiateResults);
            this.Controls.Add(this.drawingEventsLV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GeneralPlayerDrawingEventsTestForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView drawingEventsLV;
        private Controls.ImageButton imgbtnRefresh;
        private Controls.ImageButton imgbtnAbortResult;
        private Controls.ImageButton imgbtnInitiateResults;
        private Controls.ImageButton imgbtnViewEntriesResult;
        private Controls.ImageButton imgbtnExecute;
        private Controls.ImageButton imgbtnReinstate;
        private Controls.ImageButton imgbtnCancel;
        private Controls.ImageButton imgBtnClose;
        private System.Windows.Forms.ComboBox cmbxAvailableRaffles;
    }
}