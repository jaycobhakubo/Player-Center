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
            this.generationCurrentEventsBtn = new System.Windows.Forms.Button();
            this.executeEventBtn = new System.Windows.Forms.Button();
            this.cancelEventBtn = new System.Windows.Forms.Button();
            this.refreshEventsListBtn = new System.Windows.Forms.Button();
            this.drawingEventsLV = new System.Windows.Forms.ListView();
            this.drawingEventsLbl = new System.Windows.Forms.Label();
            this.viewEntriesBtn = new System.Windows.Forms.Button();
            this.reinstateEventBtn = new System.Windows.Forms.Button();
            this.eventActionsFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.initiateEventResultsBroadcastBtn = new System.Windows.Forms.Button();
            this.abortEventResultsBroadcastBtn = new System.Windows.Forms.Button();
            this.eventActionsFLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // generationCurrentEventsBtn
            // 
            this.generationCurrentEventsBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.generationCurrentEventsBtn.AutoSize = true;
            this.generationCurrentEventsBtn.Location = new System.Drawing.Point(439, 12);
            this.generationCurrentEventsBtn.Name = "generationCurrentEventsBtn";
            this.generationCurrentEventsBtn.Size = new System.Drawing.Size(133, 27);
            this.generationCurrentEventsBtn.TabIndex = 26;
            this.generationCurrentEventsBtn.Text = "Generate Current";
            this.generationCurrentEventsBtn.UseVisualStyleBackColor = true;
            this.generationCurrentEventsBtn.Click += new System.EventHandler(this.generateCurrentEventsBtn_Click);
            // 
            // executeEventBtn
            // 
            this.executeEventBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.executeEventBtn.Location = new System.Drawing.Point(460, 3);
            this.executeEventBtn.Name = "executeEventBtn";
            this.executeEventBtn.Size = new System.Drawing.Size(80, 27);
            this.executeEventBtn.TabIndex = 24;
            this.executeEventBtn.Text = "Execute";
            this.executeEventBtn.UseVisualStyleBackColor = true;
            this.executeEventBtn.Click += new System.EventHandler(this.executeEventBtn_Click);
            // 
            // cancelEventBtn
            // 
            this.cancelEventBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelEventBtn.Location = new System.Drawing.Point(632, 3);
            this.cancelEventBtn.Name = "cancelEventBtn";
            this.cancelEventBtn.Size = new System.Drawing.Size(80, 27);
            this.cancelEventBtn.TabIndex = 25;
            this.cancelEventBtn.Text = "Cancel";
            this.cancelEventBtn.UseVisualStyleBackColor = true;
            this.cancelEventBtn.Click += new System.EventHandler(this.cancelEventBtn_Click);
            // 
            // refreshEventsListBtn
            // 
            this.refreshEventsListBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.refreshEventsListBtn.Location = new System.Drawing.Point(8, 386);
            this.refreshEventsListBtn.Name = "refreshEventsListBtn";
            this.refreshEventsListBtn.Size = new System.Drawing.Size(90, 27);
            this.refreshEventsListBtn.TabIndex = 27;
            this.refreshEventsListBtn.Text = "Refresh";
            this.refreshEventsListBtn.UseVisualStyleBackColor = true;
            this.refreshEventsListBtn.Click += new System.EventHandler(this.refreshEventsListBtn_Click);
            // 
            // drawingEventsLV
            // 
            this.drawingEventsLV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingEventsLV.FullRowSelect = true;
            this.drawingEventsLV.HideSelection = false;
            this.drawingEventsLV.Location = new System.Drawing.Point(8, 78);
            this.drawingEventsLV.MultiSelect = false;
            this.drawingEventsLV.Name = "drawingEventsLV";
            this.drawingEventsLV.Size = new System.Drawing.Size(990, 298);
            this.drawingEventsLV.TabIndex = 28;
            this.drawingEventsLV.UseCompatibleStateImageBehavior = false;
            this.drawingEventsLV.View = System.Windows.Forms.View.Details;
            this.drawingEventsLV.SelectedIndexChanged += new System.EventHandler(this.drawingEventsLV_SelectedIndexChanged);
            // 
            // drawingEventsLbl
            // 
            this.drawingEventsLbl.AutoSize = true;
            this.drawingEventsLbl.Location = new System.Drawing.Point(12, 47);
            this.drawingEventsLbl.Name = "drawingEventsLbl";
            this.drawingEventsLbl.Size = new System.Drawing.Size(120, 13);
            this.drawingEventsLbl.TabIndex = 29;
            this.drawingEventsLbl.Text = "Recent Drawing Events";
            // 
            // viewEntriesBtn
            // 
            this.viewEntriesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.viewEntriesBtn.Location = new System.Drawing.Point(294, 3);
            this.viewEntriesBtn.Name = "viewEntriesBtn";
            this.viewEntriesBtn.Size = new System.Drawing.Size(160, 27);
            this.viewEntriesBtn.TabIndex = 30;
            this.viewEntriesBtn.Text = "View Entries && Results";
            this.viewEntriesBtn.UseVisualStyleBackColor = true;
            this.viewEntriesBtn.Click += new System.EventHandler(this.viewEntriesAndResultsBtn_Click);
            // 
            // reinstateEventBtn
            // 
            this.reinstateEventBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reinstateEventBtn.Location = new System.Drawing.Point(546, 3);
            this.reinstateEventBtn.Name = "reinstateEventBtn";
            this.reinstateEventBtn.Size = new System.Drawing.Size(80, 27);
            this.reinstateEventBtn.TabIndex = 31;
            this.reinstateEventBtn.Text = "Reinstate";
            this.reinstateEventBtn.UseVisualStyleBackColor = true;
            this.reinstateEventBtn.Click += new System.EventHandler(this.reinstateEventBtn_Click);
            // 
            // eventActionsFLP
            // 
            this.eventActionsFLP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.eventActionsFLP.Controls.Add(this.cancelEventBtn);
            this.eventActionsFLP.Controls.Add(this.reinstateEventBtn);
            this.eventActionsFLP.Controls.Add(this.executeEventBtn);
            this.eventActionsFLP.Controls.Add(this.viewEntriesBtn);
            this.eventActionsFLP.Controls.Add(this.initiateEventResultsBroadcastBtn);
            this.eventActionsFLP.Enabled = false;
            this.eventActionsFLP.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.eventActionsFLP.Location = new System.Drawing.Point(283, 379);
            this.eventActionsFLP.Name = "eventActionsFLP";
            this.eventActionsFLP.Size = new System.Drawing.Size(715, 34);
            this.eventActionsFLP.TabIndex = 32;
            // 
            // initiateEventResultsBroadcastBtn
            // 
            this.initiateEventResultsBroadcastBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.initiateEventResultsBroadcastBtn.Location = new System.Drawing.Point(128, 3);
            this.initiateEventResultsBroadcastBtn.Name = "initiateEventResultsBroadcastBtn";
            this.initiateEventResultsBroadcastBtn.Size = new System.Drawing.Size(160, 27);
            this.initiateEventResultsBroadcastBtn.TabIndex = 32;
            this.initiateEventResultsBroadcastBtn.Text = "Initiate Results Broadcast";
            this.initiateEventResultsBroadcastBtn.UseVisualStyleBackColor = true;
            this.initiateEventResultsBroadcastBtn.Click += new System.EventHandler(this.initiateEventResultsBroadcastBtn_Click);
            // 
            // abortEventResultsBroadcastBtn
            // 
            this.abortEventResultsBroadcastBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.abortEventResultsBroadcastBtn.Location = new System.Drawing.Point(104, 386);
            this.abortEventResultsBroadcastBtn.Name = "abortEventResultsBroadcastBtn";
            this.abortEventResultsBroadcastBtn.Size = new System.Drawing.Size(160, 27);
            this.abortEventResultsBroadcastBtn.TabIndex = 33;
            this.abortEventResultsBroadcastBtn.Text = "Abort Results Broadcast";
            this.abortEventResultsBroadcastBtn.UseVisualStyleBackColor = true;
            this.abortEventResultsBroadcastBtn.Click += new System.EventHandler(this.abortEventResultsBroadcastBtn_Click);
            // 
            // GeneralPlayerDrawingEventsTestForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1010, 419);
            this.Controls.Add(this.eventActionsFLP);
            this.Controls.Add(this.drawingEventsLbl);
            this.Controls.Add(this.drawingEventsLV);
            this.Controls.Add(this.generationCurrentEventsBtn);
            this.Controls.Add(this.refreshEventsListBtn);
            this.Controls.Add(this.abortEventResultsBroadcastBtn);
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

        private System.Windows.Forms.Button generationCurrentEventsBtn;
        private System.Windows.Forms.Button executeEventBtn;
        private System.Windows.Forms.Button cancelEventBtn;
        private System.Windows.Forms.Button refreshEventsListBtn;
        private System.Windows.Forms.ListView drawingEventsLV;
        private System.Windows.Forms.Label drawingEventsLbl;
        private System.Windows.Forms.Button viewEntriesBtn;
        private System.Windows.Forms.Button reinstateEventBtn;
        private System.Windows.Forms.FlowLayoutPanel eventActionsFLP;
        private System.Windows.Forms.Button initiateEventResultsBroadcastBtn;
        private System.Windows.Forms.Button abortEventResultsBroadcastBtn;
    }
}