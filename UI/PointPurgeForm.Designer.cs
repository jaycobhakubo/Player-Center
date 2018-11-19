namespace GTI.Modules.PlayerCenter.UI
{
    partial class PointPurgeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.rbAllPlayers = new System.Windows.Forms.RadioButton();
            this.rbNoVisitsInPreviousPeriod = new System.Windows.Forms.RadioButton();
            this.nudPeriodNumber = new System.Windows.Forms.NumericUpDown();
            this.cbPeriodType = new System.Windows.Forms.ComboBox();
            this.btnClose = new GTI.Controls.ImageButton();
            this.btnPurge = new GTI.Controls.ImageButton();
            this.btnUndo = new GTI.Controls.ImageButton();
            this.rbNoVisitsSince = new System.Windows.Forms.RadioButton();
            this.dtpSinceDate = new System.Windows.Forms.DateTimePicker();
            this.lblLastPurgeInfo = new System.Windows.Forms.Label();
            this.gbLastPurge = new System.Windows.Forms.GroupBox();
            this.lblManualPointsAdjustReasonCharactersLeft = new System.Windows.Forms.Label();
            this.lblManualPointAdjustReasonCharactersLeftTitle = new System.Windows.Forms.Label();
            this.txtManualPointAdjustReason = new System.Windows.Forms.TextBox();
            this.gbReason = new System.Windows.Forms.GroupBox();
            this.gbMethod = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.nudPeriodNumber)).BeginInit();
            this.gbLastPurge.SuspendLayout();
            this.gbReason.SuspendLayout();
            this.gbMethod.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(570, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Expiring player points will set the point\r\nbalance to zero for the selected playe" +
    "rs.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // rbAllPlayers
            // 
            this.rbAllPlayers.BackColor = System.Drawing.Color.Transparent;
            this.rbAllPlayers.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAllPlayers.Location = new System.Drawing.Point(6, 25);
            this.rbAllPlayers.Name = "rbAllPlayers";
            this.rbAllPlayers.Size = new System.Drawing.Size(373, 24);
            this.rbAllPlayers.TabIndex = 0;
            this.rbAllPlayers.TabStop = true;
            this.rbAllPlayers.Text = "All players";
            this.rbAllPlayers.UseVisualStyleBackColor = false;
            // 
            // rbNoVisitsInPreviousPeriod
            // 
            this.rbNoVisitsInPreviousPeriod.BackColor = System.Drawing.Color.Transparent;
            this.rbNoVisitsInPreviousPeriod.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNoVisitsInPreviousPeriod.Location = new System.Drawing.Point(6, 68);
            this.rbNoVisitsInPreviousPeriod.Name = "rbNoVisitsInPreviousPeriod";
            this.rbNoVisitsInPreviousPeriod.Size = new System.Drawing.Size(353, 24);
            this.rbNoVisitsInPreviousPeriod.TabIndex = 1;
            this.rbNoVisitsInPreviousPeriod.TabStop = true;
            this.rbNoVisitsInPreviousPeriod.Text = "Players who have not visited in the previous";
            this.rbNoVisitsInPreviousPeriod.UseVisualStyleBackColor = false;
            // 
            // nudPeriodNumber
            // 
            this.nudPeriodNumber.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPeriodNumber.Location = new System.Drawing.Point(365, 67);
            this.nudPeriodNumber.Maximum = new decimal(new int[] {
            364,
            0,
            0,
            0});
            this.nudPeriodNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPeriodNumber.Name = "nudPeriodNumber";
            this.nudPeriodNumber.Size = new System.Drawing.Size(79, 26);
            this.nudPeriodNumber.TabIndex = 2;
            this.nudPeriodNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPeriodNumber.ValueChanged += new System.EventHandler(this.SelectPurgeByPeriod);
            // 
            // cbPeriodType
            // 
            this.cbPeriodType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPeriodType.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPeriodType.FormattingEnabled = true;
            this.cbPeriodType.Items.AddRange(new object[] {
            "day(s)",
            "month(s)",
            "year(s)"});
            this.cbPeriodType.Location = new System.Drawing.Point(477, 66);
            this.cbPeriodType.Name = "cbPeriodType";
            this.cbPeriodType.Size = new System.Drawing.Size(99, 30);
            this.cbPeriodType.TabIndex = 3;
            this.cbPeriodType.SelectedIndexChanged += new System.EventHandler(this.SelectPurgeByPeriod);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.FocusColor = System.Drawing.Color.Black;
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.btnClose.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.btnClose.Location = new System.Drawing.Point(459, 547);
            this.btnClose.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnClose.Name = "btnClose";
            this.btnClose.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnClose.Size = new System.Drawing.Size(135, 41);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // btnPurge
            // 
            this.btnPurge.BackColor = System.Drawing.Color.Transparent;
            this.btnPurge.FocusColor = System.Drawing.Color.Black;
            this.btnPurge.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPurge.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.btnPurge.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.btnPurge.Location = new System.Drawing.Point(12, 547);
            this.btnPurge.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnPurge.Name = "btnPurge";
            this.btnPurge.PulseRate = 500;
            this.btnPurge.RepeatWhenHeldFor = 1500;
            this.btnPurge.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnPurge.Size = new System.Drawing.Size(135, 41);
            this.btnPurge.TabIndex = 4;
            this.btnPurge.Text = "Expire Points\r\n(Hold to execute)";
            this.btnPurge.UseVisualStyleBackColor = false;
            this.btnPurge.ButtonHeld += new System.EventHandler(this.btnPurge_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.BackColor = System.Drawing.Color.Transparent;
            this.btnUndo.Enabled = false;
            this.btnUndo.FocusColor = System.Drawing.Color.Black;
            this.btnUndo.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndo.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.btnUndo.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.btnUndo.Location = new System.Drawing.Point(236, 547);
            this.btnUndo.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.PulseRate = 500;
            this.btnUndo.RepeatWhenHeldFor = 1500;
            this.btnUndo.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnUndo.Size = new System.Drawing.Size(135, 41);
            this.btnUndo.TabIndex = 5;
            this.btnUndo.Text = "Undo Last Expiring\r\n(Hold to execute)";
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.ButtonHeld += new System.EventHandler(this.btnUndo_Click);
            // 
            // rbNoVisitsSince
            // 
            this.rbNoVisitsSince.BackColor = System.Drawing.Color.Transparent;
            this.rbNoVisitsSince.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNoVisitsSince.Location = new System.Drawing.Point(6, 108);
            this.rbNoVisitsSince.Name = "rbNoVisitsSince";
            this.rbNoVisitsSince.Size = new System.Drawing.Size(294, 24);
            this.rbNoVisitsSince.TabIndex = 4;
            this.rbNoVisitsSince.TabStop = true;
            this.rbNoVisitsSince.Text = "Players who have not visited since";
            this.rbNoVisitsSince.UseVisualStyleBackColor = false;
            // 
            // dtpSinceDate
            // 
            this.dtpSinceDate.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSinceDate.Location = new System.Drawing.Point(283, 108);
            this.dtpSinceDate.Name = "dtpSinceDate";
            this.dtpSinceDate.Size = new System.Drawing.Size(293, 26);
            this.dtpSinceDate.TabIndex = 5;
            this.dtpSinceDate.ValueChanged += new System.EventHandler(this.SelectPurgeByDate);
            // 
            // lblLastPurgeInfo
            // 
            this.lblLastPurgeInfo.AutoSize = true;
            this.lblLastPurgeInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblLastPurgeInfo.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastPurgeInfo.Location = new System.Drawing.Point(6, 5);
            this.lblLastPurgeInfo.Name = "lblLastPurgeInfo";
            this.lblLastPurgeInfo.Size = new System.Drawing.Size(350, 100);
            this.lblLastPurgeInfo.TabIndex = 0;
            this.lblLastPurgeInfo.Text = "1000 players\r\nPlayers who had not visited in the previous 90 days\r\nPerformed on 1" +
    "1/08/2018\r\nBy Richard Kappele\r\nReason: None";
            this.lblLastPurgeInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbLastPurge
            // 
            this.gbLastPurge.BackColor = System.Drawing.Color.Transparent;
            this.gbLastPurge.Controls.Add(this.panel1);
            this.gbLastPurge.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLastPurge.Location = new System.Drawing.Point(12, 375);
            this.gbLastPurge.Name = "gbLastPurge";
            this.gbLastPurge.Size = new System.Drawing.Size(582, 149);
            this.gbLastPurge.TabIndex = 3;
            this.gbLastPurge.TabStop = false;
            this.gbLastPurge.Text = "Last Expiring";
            // 
            // lblManualPointsAdjustReasonCharactersLeft
            // 
            this.lblManualPointsAdjustReasonCharactersLeft.BackColor = System.Drawing.Color.Transparent;
            this.lblManualPointsAdjustReasonCharactersLeft.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManualPointsAdjustReasonCharactersLeft.ForeColor = System.Drawing.Color.Black;
            this.lblManualPointsAdjustReasonCharactersLeft.Location = new System.Drawing.Point(543, 134);
            this.lblManualPointsAdjustReasonCharactersLeft.Name = "lblManualPointsAdjustReasonCharactersLeft";
            this.lblManualPointsAdjustReasonCharactersLeft.Size = new System.Drawing.Size(37, 15);
            this.lblManualPointsAdjustReasonCharactersLeft.TabIndex = 2;
            this.lblManualPointsAdjustReasonCharactersLeft.Text = "500";
            this.lblManualPointsAdjustReasonCharactersLeft.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblManualPointAdjustReasonCharactersLeftTitle
            // 
            this.lblManualPointAdjustReasonCharactersLeftTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblManualPointAdjustReasonCharactersLeftTitle.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManualPointAdjustReasonCharactersLeftTitle.ForeColor = System.Drawing.Color.Black;
            this.lblManualPointAdjustReasonCharactersLeftTitle.Location = new System.Drawing.Point(429, 134);
            this.lblManualPointAdjustReasonCharactersLeftTitle.Name = "lblManualPointAdjustReasonCharactersLeftTitle";
            this.lblManualPointAdjustReasonCharactersLeftTitle.Size = new System.Drawing.Size(108, 15);
            this.lblManualPointAdjustReasonCharactersLeftTitle.TabIndex = 1;
            this.lblManualPointAdjustReasonCharactersLeftTitle.Text = "Characters left:";
            this.lblManualPointAdjustReasonCharactersLeftTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtManualPointAdjustReason
            // 
            this.txtManualPointAdjustReason.AcceptsReturn = true;
            this.txtManualPointAdjustReason.Location = new System.Drawing.Point(6, 25);
            this.txtManualPointAdjustReason.MaxLength = 500;
            this.txtManualPointAdjustReason.Multiline = true;
            this.txtManualPointAdjustReason.Name = "txtManualPointAdjustReason";
            this.txtManualPointAdjustReason.Size = new System.Drawing.Size(570, 106);
            this.txtManualPointAdjustReason.TabIndex = 0;
            this.txtManualPointAdjustReason.TextChanged += new System.EventHandler(this.txtManualPointAdjustReason_TextChanged);
            // 
            // gbReason
            // 
            this.gbReason.BackColor = System.Drawing.Color.Transparent;
            this.gbReason.Controls.Add(this.txtManualPointAdjustReason);
            this.gbReason.Controls.Add(this.lblManualPointsAdjustReasonCharactersLeft);
            this.gbReason.Controls.Add(this.lblManualPointAdjustReasonCharactersLeftTitle);
            this.gbReason.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbReason.Location = new System.Drawing.Point(12, 215);
            this.gbReason.Name = "gbReason";
            this.gbReason.Size = new System.Drawing.Size(582, 154);
            this.gbReason.TabIndex = 2;
            this.gbReason.TabStop = false;
            this.gbReason.Text = "Reason for expiring points";
            // 
            // gbMethod
            // 
            this.gbMethod.BackColor = System.Drawing.Color.Transparent;
            this.gbMethod.Controls.Add(this.rbAllPlayers);
            this.gbMethod.Controls.Add(this.rbNoVisitsInPreviousPeriod);
            this.gbMethod.Controls.Add(this.nudPeriodNumber);
            this.gbMethod.Controls.Add(this.dtpSinceDate);
            this.gbMethod.Controls.Add(this.cbPeriodType);
            this.gbMethod.Controls.Add(this.rbNoVisitsSince);
            this.gbMethod.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMethod.Location = new System.Drawing.Point(12, 67);
            this.gbMethod.Name = "gbMethod";
            this.gbMethod.Size = new System.Drawing.Size(582, 142);
            this.gbMethod.TabIndex = 1;
            this.gbMethod.TabStop = false;
            this.gbMethod.Text = "Method";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lblLastPurgeInfo);
            this.panel1.Location = new System.Drawing.Point(6, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(570, 121);
            this.panel1.TabIndex = 0;
            // 
            // PointPurgeForm
            // 
            this.ClientSize = new System.Drawing.Size(606, 600);
            this.ControlBox = false;
            this.Controls.Add(this.gbMethod);
            this.Controls.Add(this.gbReason);
            this.Controls.Add(this.gbLastPurge);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnPurge);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.DrawAsGradient = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "PointPurgeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Player Point Expiring";
            ((System.ComponentModel.ISupportInitialize)(this.nudPeriodNumber)).EndInit();
            this.gbLastPurge.ResumeLayout(false);
            this.gbReason.ResumeLayout(false);
            this.gbReason.PerformLayout();
            this.gbMethod.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbAllPlayers;
        private System.Windows.Forms.RadioButton rbNoVisitsInPreviousPeriod;
        private System.Windows.Forms.NumericUpDown nudPeriodNumber;
        private System.Windows.Forms.ComboBox cbPeriodType;
        private Controls.ImageButton btnClose;
        private Controls.ImageButton btnPurge;
        private Controls.ImageButton btnUndo;
        private System.Windows.Forms.RadioButton rbNoVisitsSince;
        private System.Windows.Forms.DateTimePicker dtpSinceDate;
        private System.Windows.Forms.Label lblLastPurgeInfo;
        private System.Windows.Forms.GroupBox gbLastPurge;
        private System.Windows.Forms.Label lblManualPointsAdjustReasonCharactersLeft;
        private System.Windows.Forms.Label lblManualPointAdjustReasonCharactersLeftTitle;
        private System.Windows.Forms.TextBox txtManualPointAdjustReason;
        private System.Windows.Forms.GroupBox gbReason;
        private System.Windows.Forms.GroupBox gbMethod;
        private System.Windows.Forms.Panel panel1;
    }
}
