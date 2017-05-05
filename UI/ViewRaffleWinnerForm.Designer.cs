namespace GTI.Modules.PlayerCenter.UI
{
    partial class ViewRaffleWinnerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewRaffleWinnerForm));
            this.m_noPic = new System.Windows.Forms.PictureBox();
            this.m_firstName = new System.Windows.Forms.TextBox();
            this.m_lastName = new System.Windows.Forms.TextBox();
            this.m_close = new GTI.Controls.ImageButton();
            this.m_comments = new System.Windows.Forms.TextBox();
            this.m_clearRaffle = new GTI.Controls.ImageButton();
            this.m_runRaffle = new GTI.Controls.ImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.m_noPic)).BeginInit();
            this.SuspendLayout();
            // 
            // m_noPic
            // 
            this.m_noPic.AccessibleDescription = null;
            this.m_noPic.AccessibleName = null;
            resources.ApplyResources(this.m_noPic, "m_noPic");
            this.m_noPic.BackgroundImage = null;
            this.m_noPic.Font = null;
            this.m_noPic.Image = global::GTI.Modules.PlayerCenter.Properties.Resources.NoPic;
            this.m_noPic.ImageLocation = null;
            this.m_noPic.Name = "m_noPic";
            this.m_noPic.TabStop = false;
            // 
            // m_firstName
            // 
            this.m_firstName.AccessibleDescription = null;
            this.m_firstName.AccessibleName = null;
            resources.ApplyResources(this.m_firstName, "m_firstName");
            this.m_firstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(60)))), ((int)(((byte)(96)))));
            this.m_firstName.BackgroundImage = null;
            this.m_firstName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_firstName.ForeColor = System.Drawing.Color.Yellow;
            this.m_firstName.Name = "m_firstName";
            // 
            // m_lastName
            // 
            this.m_lastName.AccessibleDescription = null;
            this.m_lastName.AccessibleName = null;
            resources.ApplyResources(this.m_lastName, "m_lastName");
            this.m_lastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(60)))), ((int)(((byte)(96)))));
            this.m_lastName.BackgroundImage = null;
            this.m_lastName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_lastName.ForeColor = System.Drawing.Color.Yellow;
            this.m_lastName.Name = "m_lastName";
            // 
            // m_close
            // 
            this.m_close.AccessibleDescription = null;
            this.m_close.AccessibleName = null;
            resources.ApplyResources(this.m_close, "m_close");
            this.m_close.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.m_close.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_close.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_close.MinimumSize = new System.Drawing.Size(30, 30);
            this.m_close.Name = "m_close";
            this.m_close.UseVisualStyleBackColor = false;
            this.m_close.Click += new System.EventHandler(this.CloseClick);
            // 
            // m_comments
            // 
            this.m_comments.AccessibleDescription = null;
            this.m_comments.AccessibleName = null;
            resources.ApplyResources(this.m_comments, "m_comments");
            this.m_comments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(60)))), ((int)(((byte)(96)))));
            this.m_comments.BackgroundImage = null;
            this.m_comments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_comments.ForeColor = System.Drawing.Color.Yellow;
            this.m_comments.Name = "m_comments";
            // 
            // m_clearRaffle
            // 
            this.m_clearRaffle.AccessibleDescription = null;
            this.m_clearRaffle.AccessibleName = null;
            resources.ApplyResources(this.m_clearRaffle, "m_clearRaffle");
            this.m_clearRaffle.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.m_clearRaffle.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_clearRaffle.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_clearRaffle.MinimumSize = new System.Drawing.Size(30, 30);
            this.m_clearRaffle.Name = "m_clearRaffle";
            this.m_clearRaffle.UseVisualStyleBackColor = false;
            this.m_clearRaffle.Click += new System.EventHandler(this.ClearRaffleClick);
            // 
            // m_runRaffle
            // 
            this.m_runRaffle.AccessibleDescription = null;
            this.m_runRaffle.AccessibleName = null;
            resources.ApplyResources(this.m_runRaffle, "m_runRaffle");
            this.m_runRaffle.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.m_runRaffle.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_runRaffle.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_runRaffle.MinimumSize = new System.Drawing.Size(30, 30);
            this.m_runRaffle.Name = "m_runRaffle";
            this.m_runRaffle.UseVisualStyleBackColor = false;
            this.m_runRaffle.Click += new System.EventHandler(this.RunRaffleClick);
            // 
            // ViewRaffleWinnerForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = global::GTI.Modules.PlayerCenter.Properties.Resources.ViewRaffleWinnerBack;
            this.Controls.Add(this.m_runRaffle);
            this.Controls.Add(this.m_clearRaffle);
            this.Controls.Add(this.m_comments);
            this.Controls.Add(this.m_close);
            this.Controls.Add(this.m_lastName);
            this.Controls.Add(this.m_firstName);
            this.Controls.Add(this.m_noPic);
            this.DoubleBuffered = true;
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = null;
            this.KeyPreview = true;
            this.Name = "ViewRaffleWinnerForm";
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.m_noPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox m_noPic;
        private System.Windows.Forms.TextBox m_firstName;
        private System.Windows.Forms.TextBox m_lastName;
        private GTI.Controls.ImageButton m_close;
        private System.Windows.Forms.TextBox m_comments;
        private GTI.Controls.ImageButton m_clearRaffle;
        private GTI.Controls.ImageButton m_runRaffle;
    }
}