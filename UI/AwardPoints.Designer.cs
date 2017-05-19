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
            this.txtbxPointsAwarded = new GTI.Controls.txtBxCcDecimalOrNumeric();
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
            this.cancelImageButton.Location = new System.Drawing.Point(175, 169);
            this.cancelImageButton.MinimumSize = new System.Drawing.Size(30, 30);
            this.cancelImageButton.Name = "cancelImageButton";
            this.cancelImageButton.RepeatRate = 150;
            this.cancelImageButton.RepeatWhenHeldFor = 750;
            this.cancelImageButton.ShowFocus = false;
            this.cancelImageButton.Size = new System.Drawing.Size(133, 50);
            this.cancelImageButton.TabIndex = 3;
            this.cancelImageButton.Text = "&Cancel";
            this.cancelImageButton.UseVisualStyleBackColor = false;
            this.cancelImageButton.Click += new System.EventHandler(this.cancelImageButton_Click);
            // 
            // acceptImageButton
            // 
            this.acceptImageButton.BackColor = System.Drawing.Color.Transparent;
            this.acceptImageButton.FocusColor = System.Drawing.Color.Black;
            this.acceptImageButton.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acceptImageButton.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonUp;
            this.acceptImageButton.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonDown;
            this.acceptImageButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.acceptImageButton.Location = new System.Drawing.Point(12, 169);
            this.acceptImageButton.MinimumSize = new System.Drawing.Size(30, 30);
            this.acceptImageButton.Name = "acceptImageButton";
            this.acceptImageButton.RepeatRate = 150;
            this.acceptImageButton.RepeatWhenHeldFor = 750;
            this.acceptImageButton.ShowFocus = false;
            this.acceptImageButton.Size = new System.Drawing.Size(133, 50);
            this.acceptImageButton.TabIndex = 2;
            this.acceptImageButton.Text = "Award Points";
            this.acceptImageButton.UseVisualStyleBackColor = false;
            this.acceptImageButton.Click += new System.EventHandler(this.acceptImageButton_Click);
            // 
            // lblPointsAwarded
            // 
            this.lblPointsAwarded.BackColor = System.Drawing.Color.Transparent;
            this.lblPointsAwarded.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointsAwarded.Location = new System.Drawing.Point(12, 72);
            this.lblPointsAwarded.Name = "lblPointsAwarded";
            this.lblPointsAwarded.Size = new System.Drawing.Size(155, 20);
            this.lblPointsAwarded.TabIndex = 3;
            this.lblPointsAwarded.Text = "Points to Award";
            // 
            // lblPlayerNameIndicator
            // 
            this.lblPlayerNameIndicator.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerNameIndicator.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerNameIndicator.Location = new System.Drawing.Point(12, 9);
            this.lblPlayerNameIndicator.Name = "lblPlayerNameIndicator";
            this.lblPlayerNameIndicator.Size = new System.Drawing.Size(296, 22);
            this.lblPlayerNameIndicator.TabIndex = 4;
            this.lblPlayerNameIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtbxPointsAwarded
            // 
            this.txtbxPointsAwarded.Location = new System.Drawing.Point(12, 95);
            this.txtbxPointsAwarded.Mask = GTI.Controls.txtBxCcDecimalOrNumeric.TextBoxType.Decimal;
            this.txtbxPointsAwarded.MaxLength = 16;
            this.txtbxPointsAwarded.Name = "txtbxPointsAwarded";
            this.txtbxPointsAwarded.Precision = 2;
            this.txtbxPointsAwarded.Size = new System.Drawing.Size(296, 23);
            this.txtbxPointsAwarded.TabIndex = 0;
            // 
            // AwardPoints
            // 
            this.AcceptButton = this.acceptImageButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::GTI.Modules.PlayerCenter.Properties.Resources.MagCardBack;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.cancelImageButton;
            this.ClientSize = new System.Drawing.Size(320, 240);
            this.ControlBox = false;
            this.Controls.Add(this.txtbxPointsAwarded);
            this.Controls.Add(this.lblPlayerNameIndicator);
            this.Controls.Add(this.cancelImageButton);
            this.Controls.Add(this.acceptImageButton);
            this.Controls.Add(this.lblPointsAwarded);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
        private Controls.txtBxCcDecimalOrNumeric txtbxPointsAwarded;
    }
}