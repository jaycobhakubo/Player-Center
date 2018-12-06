namespace GTI.Modules.PlayerCenter.UI
{
    partial class PlayerLoyaltyTierIcon
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerLoyaltyTierIcon));
            this.imageButton1 = new GTI.Controls.ImageButton();
            this.imageButton2 = new GTI.Controls.ImageButton();
            this.imageButton3 = new GTI.Controls.ImageButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.imageButton4 = new GTI.Controls.ImageButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageButton1
            // 
            this.imageButton1.BackColor = System.Drawing.Color.Transparent;
            this.imageButton1.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.imageButton1, "imageButton1");
            this.imageButton1.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.imageButton1.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.imageButton1.Name = "imageButton1";
            this.imageButton1.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.imageButton1.UseVisualStyleBackColor = false;
            this.imageButton1.Click += new System.EventHandler(this.imageButton1_Click);
            // 
            // imageButton2
            // 
            this.imageButton2.BackColor = System.Drawing.Color.Transparent;
            this.imageButton2.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.imageButton2, "imageButton2");
            this.imageButton2.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.imageButton2.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.imageButton2.Name = "imageButton2";
            this.imageButton2.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.imageButton2.UseVisualStyleBackColor = false;
            // 
            // imageButton3
            // 
            this.imageButton3.BackColor = System.Drawing.Color.Transparent;
            this.imageButton3.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.imageButton3, "imageButton3");
            this.imageButton3.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.imageButton3.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.imageButton3.Name = "imageButton3";
            this.imageButton3.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.imageButton3.UseVisualStyleBackColor = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Controls.Add(this.listBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.imageButton4);
            this.splitContainer1.Panel2.Controls.Add(this.imageButton1);
            this.splitContainer1.Panel2.Controls.Add(this.imageButton3);
            this.splitContainer1.Panel2.Controls.Add(this.imageButton2);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.imageList1, "imageList1");
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            resources.ApplyResources(this.listBox1, "listBox1");
            this.listBox1.Name = "listBox1";
            // 
            // imageButton4
            // 
            this.imageButton4.BackColor = System.Drawing.Color.Transparent;
            this.imageButton4.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.imageButton4, "imageButton4");
            this.imageButton4.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.imageButton4.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.imageButton4.Name = "imageButton4";
            this.imageButton4.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.imageButton4.UseVisualStyleBackColor = false;
            this.imageButton4.Click += new System.EventHandler(this.imageButton4_Click);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // PlayerLoyaltyTierIcon
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.splitContainer1);
            this.DrawAsGradient = true;
            this.DrawBorderOuterEdge = true;
            this.DrawRounded = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.GradientBeginColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(34)))), ((int)(((byte)(60)))));
            this.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(114)))), ((int)(((byte)(160)))));
            this.Name = "PlayerLoyaltyTierIcon";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ImageButton imageButton1;
        private Controls.ImageButton imageButton2;
        private Controls.ImageButton imageButton3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListBox listBox1;
        private Controls.ImageButton imageButton4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
    }
}