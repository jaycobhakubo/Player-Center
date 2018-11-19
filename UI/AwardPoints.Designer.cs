namespace GTI.Modules.PlayerCenter.UI
{
    partial class AwardPoints
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
            this.cancelImageButton = new GTI.Controls.ImageButton();
            this.acceptImageButton = new GTI.Controls.ImageButton();
            this.lblPointsAwarded = new System.Windows.Forms.Label();
            this.lblPlayerNameIndicator = new System.Windows.Forms.Label();
            this.txtbxPointsAwarded = new GTI.Controls.TextBoxNumeric2();
            this.txtManualPointAdjustReason = new System.Windows.Forms.TextBox();
            this.lblManualPointAdjustReasonCharactersLeftTitle = new System.Windows.Forms.Label();
            this.lblManualPointsAdjustReasonCharactersLeft = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelImageButton
            // 
            this.cancelImageButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelImageButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelImageButton.FocusColor = System.Drawing.Color.Black;
            this.cancelImageButton.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelImageButton.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonUp;
            this.cancelImageButton.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonDown;
            this.cancelImageButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cancelImageButton.Location = new System.Drawing.Point(257, 262);
            this.cancelImageButton.MinimumSize = new System.Drawing.Size(30, 30);
            this.cancelImageButton.Name = "cancelImageButton";
            this.cancelImageButton.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.cancelImageButton.ShowFocus = false;
            this.cancelImageButton.Size = new System.Drawing.Size(133, 50);
            this.cancelImageButton.TabIndex = 8;
            this.cancelImageButton.Text = "&Cancel";
            this.cancelImageButton.UseVisualStyleBackColor = false;
            this.cancelImageButton.Click += new System.EventHandler(this.cancelImageButton_Click);
            // 
            // acceptImageButton
            // 
            this.acceptImageButton.BackColor = System.Drawing.Color.Transparent;
            this.acceptImageButton.Enabled = false;
            this.acceptImageButton.FocusColor = System.Drawing.Color.Black;
            this.acceptImageButton.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acceptImageButton.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonUp;
            this.acceptImageButton.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonDown;
            this.acceptImageButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.acceptImageButton.Location = new System.Drawing.Point(12, 262);
            this.acceptImageButton.MinimumSize = new System.Drawing.Size(30, 30);
            this.acceptImageButton.Name = "acceptImageButton";
            this.acceptImageButton.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.acceptImageButton.ShowFocus = false;
            this.acceptImageButton.Size = new System.Drawing.Size(133, 50);
            this.acceptImageButton.TabIndex = 7;
            this.acceptImageButton.Text = "Award Points";
            this.acceptImageButton.UseVisualStyleBackColor = false;
            this.acceptImageButton.Click += new System.EventHandler(this.acceptImageButton_Click);
            // 
            // lblPointsAwarded
            // 
            this.lblPointsAwarded.BackColor = System.Drawing.Color.Transparent;
            this.lblPointsAwarded.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointsAwarded.Location = new System.Drawing.Point(8, 61);
            this.lblPointsAwarded.Name = "lblPointsAwarded";
            this.lblPointsAwarded.Size = new System.Drawing.Size(143, 20);
            this.lblPointsAwarded.TabIndex = 1;
            this.lblPointsAwarded.Text = "Points to Award";
            // 
            // lblPlayerNameIndicator
            // 
            this.lblPlayerNameIndicator.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerNameIndicator.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerNameIndicator.ForeColor = System.Drawing.Color.Black;
            this.lblPlayerNameIndicator.Location = new System.Drawing.Point(12, 9);
            this.lblPlayerNameIndicator.Name = "lblPlayerNameIndicator";
            this.lblPlayerNameIndicator.Size = new System.Drawing.Size(378, 46);
            this.lblPlayerNameIndicator.TabIndex = 0;
            this.lblPlayerNameIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtbxPointsAwarded
            // 
            this.txtbxPointsAwarded.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxPointsAwarded.Location = new System.Drawing.Point(157, 58);
            this.txtbxPointsAwarded.Mask = GTI.Controls.TextBoxNumeric2.TextBoxType.Decimal;
            this.txtbxPointsAwarded.MaxLength = 10;
            this.txtbxPointsAwarded.Name = "txtbxPointsAwarded";
            this.txtbxPointsAwarded.Precision = 2;
            this.txtbxPointsAwarded.Size = new System.Drawing.Size(137, 26);
            this.txtbxPointsAwarded.TabIndex = 2;
            this.txtbxPointsAwarded.TextChanged += new System.EventHandler(this.txtbxPointsAwarded_TextChanged);
            this.txtbxPointsAwarded.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtbxPointsAwarded_PreviewKeyDown);
            // 
            // txtManualPointAdjustReason
            // 
            this.txtManualPointAdjustReason.AcceptsReturn = true;
            this.txtManualPointAdjustReason.Location = new System.Drawing.Point(12, 130);
            this.txtManualPointAdjustReason.MaxLength = 500;
            this.txtManualPointAdjustReason.Multiline = true;
            this.txtManualPointAdjustReason.Name = "txtManualPointAdjustReason";
            this.txtManualPointAdjustReason.Size = new System.Drawing.Size(378, 106);
            this.txtManualPointAdjustReason.TabIndex = 4;
            this.txtManualPointAdjustReason.TextChanged += new System.EventHandler(this.txtManualPointAdjustReason_TextChanged);
            // 
            // lblManualPointAdjustReasonCharactersLeftTitle
            // 
            this.lblManualPointAdjustReasonCharactersLeftTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblManualPointAdjustReasonCharactersLeftTitle.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManualPointAdjustReasonCharactersLeftTitle.ForeColor = System.Drawing.Color.Black;
            this.lblManualPointAdjustReasonCharactersLeftTitle.Location = new System.Drawing.Point(243, 239);
            this.lblManualPointAdjustReasonCharactersLeftTitle.Name = "lblManualPointAdjustReasonCharactersLeftTitle";
            this.lblManualPointAdjustReasonCharactersLeftTitle.Size = new System.Drawing.Size(108, 15);
            this.lblManualPointAdjustReasonCharactersLeftTitle.TabIndex = 5;
            this.lblManualPointAdjustReasonCharactersLeftTitle.Text = "Characters left:";
            this.lblManualPointAdjustReasonCharactersLeftTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblManualPointsAdjustReasonCharactersLeft
            // 
            this.lblManualPointsAdjustReasonCharactersLeft.BackColor = System.Drawing.Color.Transparent;
            this.lblManualPointsAdjustReasonCharactersLeft.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManualPointsAdjustReasonCharactersLeft.ForeColor = System.Drawing.Color.Black;
            this.lblManualPointsAdjustReasonCharactersLeft.Location = new System.Drawing.Point(357, 239);
            this.lblManualPointsAdjustReasonCharactersLeft.Name = "lblManualPointsAdjustReasonCharactersLeft";
            this.lblManualPointsAdjustReasonCharactersLeft.Size = new System.Drawing.Size(37, 15);
            this.lblManualPointsAdjustReasonCharactersLeft.TabIndex = 6;
            this.lblManualPointsAdjustReasonCharactersLeft.Text = "500";
            this.lblManualPointsAdjustReasonCharactersLeft.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(382, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Reason for awarding points:";
            // 
            // AwardPoints
            // 
            this.AcceptButton = this.acceptImageButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::GTI.Modules.PlayerCenter.Properties.Resources.MagCardBack;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.cancelImageButton;
            this.ClientSize = new System.Drawing.Size(402, 324);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblManualPointsAdjustReasonCharactersLeft);
            this.Controls.Add(this.lblManualPointAdjustReasonCharactersLeftTitle);
            this.Controls.Add(this.txtManualPointAdjustReason);
            this.Controls.Add(this.txtbxPointsAwarded);
            this.Controls.Add(this.lblPlayerNameIndicator);
            this.Controls.Add(this.cancelImageButton);
            this.Controls.Add(this.acceptImageButton);
            this.Controls.Add(this.lblPointsAwarded);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AwardPoints";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Award Points";
            this.Load += new System.EventHandler(this.ManualAwardPoints_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GTI.Controls.ImageButton acceptImageButton;
        private GTI.Controls.ImageButton cancelImageButton;
        private System.Windows.Forms.Label lblPointsAwarded;
        private System.Windows.Forms.Label lblPlayerNameIndicator;
        private Controls.TextBoxNumeric2 txtbxPointsAwarded;
        private System.Windows.Forms.TextBox txtManualPointAdjustReason;
        private System.Windows.Forms.Label lblManualPointAdjustReasonCharactersLeftTitle;
        private System.Windows.Forms.Label lblManualPointsAdjustReasonCharactersLeft;
        private System.Windows.Forms.Label label2;
    }
}