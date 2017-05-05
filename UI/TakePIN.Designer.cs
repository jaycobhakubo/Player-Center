namespace GTI.Modules.PlayerCenter.UI
{
    partial class TakePIN
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
            this.pinTextBox = new System.Windows.Forms.TextBox();
            this.pinNumberLabel = new System.Windows.Forms.Label();
            this.verifiedPINTextBox = new System.Windows.Forms.TextBox();
            this.verifiedPINLabel = new System.Windows.Forms.Label();
            this.cancelImageButton = new GTI.Controls.ImageButton();
            this.acceptImageButton = new GTI.Controls.ImageButton();
            this.lblErrorText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pinTextBox
            // 
            this.pinTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pinTextBox.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pinTextBox.Location = new System.Drawing.Point(20, 55);
            this.pinTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pinTextBox.Name = "pinTextBox";
            this.pinTextBox.PasswordChar = '*';
            this.pinTextBox.Size = new System.Drawing.Size(280, 20);
            this.pinTextBox.TabIndex = 0;
            this.pinTextBox.TextChanged += new System.EventHandler(this.PINTextBox_TextChanged);
            this.pinTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            this.pinTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pinTextBox_KeyUp);
            // 
            // pinNumberLabel
            // 
            this.pinNumberLabel.AutoSize = true;
            this.pinNumberLabel.BackColor = System.Drawing.Color.Transparent;
            this.pinNumberLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pinNumberLabel.Location = new System.Drawing.Point(16, 30);
            this.pinNumberLabel.Name = "pinNumberLabel";
            this.pinNumberLabel.Size = new System.Drawing.Size(108, 19);
            this.pinNumberLabel.TabIndex = 1;
            this.pinNumberLabel.Text = "PIN Number";
            // 
            // verifiedPINTextBox
            // 
            this.verifiedPINTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.verifiedPINTextBox.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verifiedPINTextBox.Location = new System.Drawing.Point(20, 108);
            this.verifiedPINTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.verifiedPINTextBox.Name = "verifiedPINTextBox";
            this.verifiedPINTextBox.PasswordChar = '*';
            this.verifiedPINTextBox.Size = new System.Drawing.Size(280, 20);
            this.verifiedPINTextBox.TabIndex = 1;
            this.verifiedPINTextBox.TextChanged += new System.EventHandler(this.PINTextBox_TextChanged);
            this.verifiedPINTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            // 
            // verifiedPINLabel
            // 
            this.verifiedPINLabel.AutoSize = true;
            this.verifiedPINLabel.BackColor = System.Drawing.Color.Transparent;
            this.verifiedPINLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verifiedPINLabel.Location = new System.Drawing.Point(16, 83);
            this.verifiedPINLabel.Name = "verifiedPINLabel";
            this.verifiedPINLabel.Size = new System.Drawing.Size(161, 19);
            this.verifiedPINLabel.TabIndex = 3;
            this.verifiedPINLabel.Text = "Verify PIN Number";
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
            this.acceptImageButton.Enabled = false;
            this.acceptImageButton.FocusColor = System.Drawing.Color.Black;
            this.acceptImageButton.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acceptImageButton.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonUp;
            this.acceptImageButton.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonDown;
            this.acceptImageButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.acceptImageButton.Location = new System.Drawing.Point(12, 169);
            this.acceptImageButton.MinimumSize = new System.Drawing.Size(30, 30);
            this.acceptImageButton.Name = "acceptImageButton";
            this.acceptImageButton.ShowFocus = false;
            this.acceptImageButton.Size = new System.Drawing.Size(133, 50);
            this.acceptImageButton.TabIndex = 2;
            this.acceptImageButton.Text = "&Accept";
            this.acceptImageButton.UseVisualStyleBackColor = false;
            this.acceptImageButton.Click += new System.EventHandler(this.acceptImageButton_Click);
            // 
            // lblErrorText
            // 
            this.lblErrorText.AutoSize = true;
            this.lblErrorText.BackColor = System.Drawing.Color.Transparent;
            this.lblErrorText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorText.ForeColor = System.Drawing.Color.Red;
            this.lblErrorText.Location = new System.Drawing.Point(16, 143);
            this.lblErrorText.Name = "lblErrorText";
            this.lblErrorText.Size = new System.Drawing.Size(111, 14);
            this.lblErrorText.TabIndex = 4;
            this.lblErrorText.Text = "Pins do not match.";
            this.lblErrorText.Visible = false;
            // 
            // TakePIN
            // 
            this.AcceptButton = this.acceptImageButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::GTI.Modules.PlayerCenter.Properties.Resources.MagCardBack;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.cancelImageButton;
            this.ClientSize = new System.Drawing.Size(320, 240);
            this.ControlBox = false;
            this.Controls.Add(this.lblErrorText);
            this.Controls.Add(this.cancelImageButton);
            this.Controls.Add(this.acceptImageButton);
            this.Controls.Add(this.verifiedPINLabel);
            this.Controls.Add(this.verifiedPINTextBox);
            this.Controls.Add(this.pinNumberLabel);
            this.Controls.Add(this.pinTextBox);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TakePIN";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Assign PIN";
            this.Load += new System.EventHandler(this.TakePIN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pinTextBox;
        private System.Windows.Forms.Label pinNumberLabel;
        private System.Windows.Forms.TextBox verifiedPINTextBox;
        private System.Windows.Forms.Label verifiedPINLabel;
        private GTI.Controls.ImageButton acceptImageButton;
        private GTI.Controls.ImageButton cancelImageButton;
        private System.Windows.Forms.Label lblErrorText;
    }
}