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
            this.drawingEventsLV = new System.Windows.Forms.ListView();
            this.drawingEventsLbl = new System.Windows.Forms.Label();
            this.imgbtnRefresh = new GTI.Controls.ImageButton();
            this.imgbtnAbortResult = new GTI.Controls.ImageButton();
            this.imgbtnInitiateResults = new GTI.Controls.ImageButton();
            this.imgbtnViewEntriesResult = new GTI.Controls.ImageButton();
            this.imgbtnExecute = new GTI.Controls.ImageButton();
            this.imgbtnReinstate = new GTI.Controls.ImageButton();
            this.imgbtnCancel = new GTI.Controls.ImageButton();
            this.imgbtnGenerateCurrent = new GTI.Controls.ImageButton();
            this.eventActionsFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.eventActionsFLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawingEventsLV
            // 
            this.drawingEventsLV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingEventsLV.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.drawingEventsLV.FullRowSelect = true;
            this.drawingEventsLV.HideSelection = false;
            this.drawingEventsLV.Location = new System.Drawing.Point(10, 86);
            this.drawingEventsLV.MultiSelect = false;
            this.drawingEventsLV.Name = "drawingEventsLV";
            this.drawingEventsLV.Size = new System.Drawing.Size(990, 492);
            this.drawingEventsLV.TabIndex = 28;
            this.drawingEventsLV.UseCompatibleStateImageBehavior = false;
            this.drawingEventsLV.View = System.Windows.Forms.View.Details;
            this.drawingEventsLV.SelectedIndexChanged += new System.EventHandler(this.drawingEventsLV_SelectedIndexChanged);
            // 
            // drawingEventsLbl
            // 
            this.drawingEventsLbl.AutoSize = true;
            this.drawingEventsLbl.BackColor = System.Drawing.Color.Transparent;
            this.drawingEventsLbl.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.drawingEventsLbl.Location = new System.Drawing.Point(11, 61);
            this.drawingEventsLbl.Name = "drawingEventsLbl";
            this.drawingEventsLbl.Size = new System.Drawing.Size(183, 22);
            this.drawingEventsLbl.TabIndex = 29;
            this.drawingEventsLbl.Text = "Recent Drawing Events";
            // 
            // imgbtnRefresh
            // 
            this.imgbtnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgbtnRefresh.FocusColor = System.Drawing.Color.Black;
            this.imgbtnRefresh.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.imgbtnRefresh.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.imgbtnRefresh.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.imgbtnRefresh.Location = new System.Drawing.Point(90, 3);
            this.imgbtnRefresh.MinimumSize = new System.Drawing.Size(30, 30);
            this.imgbtnRefresh.Name = "imgbtnRefresh";
            this.imgbtnRefresh.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.imgbtnRefresh.Size = new System.Drawing.Size(92, 45);
            this.imgbtnRefresh.TabIndex = 34;
            this.imgbtnRefresh.Text = "Referesh";
            this.imgbtnRefresh.Click += new System.EventHandler(this.refreshEventsListBtn_Click);
            // 
            // imgbtnAbortResult
            // 
            this.imgbtnAbortResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgbtnAbortResult.FocusColor = System.Drawing.Color.Black;
            this.imgbtnAbortResult.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.imgbtnAbortResult.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.imgbtnAbortResult.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.imgbtnAbortResult.Location = new System.Drawing.Point(145, 584);
            this.imgbtnAbortResult.MinimumSize = new System.Drawing.Size(30, 30);
            this.imgbtnAbortResult.Name = "imgbtnAbortResult";
            this.imgbtnAbortResult.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.imgbtnAbortResult.Size = new System.Drawing.Size(129, 45);
            this.imgbtnAbortResult.TabIndex = 35;
            this.imgbtnAbortResult.Text = "Abort Results Broadcast";
            this.imgbtnAbortResult.Click += new System.EventHandler(this.abortEventResultsBroadcastBtn_Click);
            // 
            // imgbtnInitiateResults
            // 
            this.imgbtnInitiateResults.FocusColor = System.Drawing.Color.Black;
            this.imgbtnInitiateResults.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.imgbtnInitiateResults.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.imgbtnInitiateResults.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.imgbtnInitiateResults.Location = new System.Drawing.Point(10, 584);
            this.imgbtnInitiateResults.MinimumSize = new System.Drawing.Size(30, 30);
            this.imgbtnInitiateResults.Name = "imgbtnInitiateResults";
            this.imgbtnInitiateResults.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.imgbtnInitiateResults.Size = new System.Drawing.Size(129, 45);
            this.imgbtnInitiateResults.TabIndex = 36;
            this.imgbtnInitiateResults.Text = "Initiate Results Broadcast";
            this.imgbtnInitiateResults.Click += new System.EventHandler(this.initiateEventResultsBroadcastBtn_Click);
            // 
            // imgbtnViewEntriesResult
            // 
            this.imgbtnViewEntriesResult.FocusColor = System.Drawing.Color.Black;
            this.imgbtnViewEntriesResult.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.imgbtnViewEntriesResult.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.imgbtnViewEntriesResult.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.imgbtnViewEntriesResult.Location = new System.Drawing.Point(280, 584);
            this.imgbtnViewEntriesResult.MinimumSize = new System.Drawing.Size(30, 30);
            this.imgbtnViewEntriesResult.Name = "imgbtnViewEntriesResult";
            this.imgbtnViewEntriesResult.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.imgbtnViewEntriesResult.Size = new System.Drawing.Size(129, 45);
            this.imgbtnViewEntriesResult.TabIndex = 37;
            this.imgbtnViewEntriesResult.Text = "View Entries & Results";
            this.imgbtnViewEntriesResult.Click += new System.EventHandler(this.viewEntriesAndResultsBtn_Click);
            // 
            // imgbtnExecute
            // 
            this.imgbtnExecute.FocusColor = System.Drawing.Color.Black;
            this.imgbtnExecute.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.imgbtnExecute.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.imgbtnExecute.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.imgbtnExecute.Location = new System.Drawing.Point(286, 3);
            this.imgbtnExecute.MinimumSize = new System.Drawing.Size(30, 30);
            this.imgbtnExecute.Name = "imgbtnExecute";
            this.imgbtnExecute.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.imgbtnExecute.Size = new System.Drawing.Size(92, 45);
            this.imgbtnExecute.TabIndex = 38;
            this.imgbtnExecute.Text = "Execute";
            this.imgbtnExecute.Click += new System.EventHandler(this.executeEventBtn_Click);
            // 
            // imgbtnReinstate
            // 
            this.imgbtnReinstate.FocusColor = System.Drawing.Color.Black;
            this.imgbtnReinstate.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.imgbtnReinstate.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.imgbtnReinstate.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.imgbtnReinstate.Location = new System.Drawing.Point(188, 3);
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
            this.imgbtnCancel.Location = new System.Drawing.Point(384, 3);
            this.imgbtnCancel.MinimumSize = new System.Drawing.Size(30, 30);
            this.imgbtnCancel.Name = "imgbtnCancel";
            this.imgbtnCancel.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.imgbtnCancel.Size = new System.Drawing.Size(92, 45);
            this.imgbtnCancel.TabIndex = 40;
            this.imgbtnCancel.Text = "Cancel";
            this.imgbtnCancel.Click += new System.EventHandler(this.cancelEventBtn_Click);
            // 
            // imgbtnGenerateCurrent
            // 
            this.imgbtnGenerateCurrent.FocusColor = System.Drawing.Color.Black;
            this.imgbtnGenerateCurrent.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.imgbtnGenerateCurrent.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.imgbtnGenerateCurrent.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.imgbtnGenerateCurrent.Location = new System.Drawing.Point(426, 28);
            this.imgbtnGenerateCurrent.MinimumSize = new System.Drawing.Size(30, 30);
            this.imgbtnGenerateCurrent.Name = "imgbtnGenerateCurrent";
            this.imgbtnGenerateCurrent.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.imgbtnGenerateCurrent.Size = new System.Drawing.Size(126, 52);
            this.imgbtnGenerateCurrent.TabIndex = 41;
            this.imgbtnGenerateCurrent.Text = "Generate Current";
            this.imgbtnGenerateCurrent.Click += new System.EventHandler(this.generateCurrentEventsBtn_Click);
            // 
            // eventActionsFLP
            // 
            this.eventActionsFLP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eventActionsFLP.AutoSize = true;
            this.eventActionsFLP.BackColor = System.Drawing.Color.Transparent;
            this.eventActionsFLP.Controls.Add(this.imgbtnCancel);
            this.eventActionsFLP.Controls.Add(this.imgbtnExecute);
            this.eventActionsFLP.Controls.Add(this.imgbtnReinstate);
            this.eventActionsFLP.Controls.Add(this.imgbtnRefresh);
            this.eventActionsFLP.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.eventActionsFLP.Location = new System.Drawing.Point(519, 579);
            this.eventActionsFLP.Name = "eventActionsFLP";
            this.eventActionsFLP.Size = new System.Drawing.Size(479, 58);
            this.eventActionsFLP.TabIndex = 42;
            // 
            // GeneralPlayerDrawingEventsTestForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1010, 641);
            this.Controls.Add(this.eventActionsFLP);
            this.Controls.Add(this.imgbtnGenerateCurrent);
            this.Controls.Add(this.imgbtnAbortResult);
            this.Controls.Add(this.imgbtnViewEntriesResult);
            this.Controls.Add(this.drawingEventsLbl);
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
            this.eventActionsFLP.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView drawingEventsLV;
        private System.Windows.Forms.Label drawingEventsLbl;
        private Controls.ImageButton imgbtnRefresh;
        private Controls.ImageButton imgbtnAbortResult;
        private Controls.ImageButton imgbtnInitiateResults;
        private Controls.ImageButton imgbtnViewEntriesResult;
        private Controls.ImageButton imgbtnExecute;
        private Controls.ImageButton imgbtnReinstate;
        private Controls.ImageButton imgbtnCancel;
        private Controls.ImageButton imgbtnGenerateCurrent;
        private System.Windows.Forms.FlowLayoutPanel eventActionsFLP;
    }
}