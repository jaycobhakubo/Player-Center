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
            this.imageButton4 = new GTI.Controls.ImageButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.imageList1, "imageList1");
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // PlayerLoyaltyTierIcon
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imageButton4);
            this.Controls.Add(this.imageButton1);
            this.Controls.Add(this.imageButton3);
            this.Controls.Add(this.imageButton2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PlayerLoyaltyTierIcon";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ImageButton imageButton1;
        private Controls.ImageButton imageButton2;
        private Controls.ImageButton imageButton3;
        private System.Windows.Forms.ImageList imageList1;
        private Controls.ImageButton imageButton4;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}