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
            this.m_imgbtnImport = new GTI.Controls.ImageButton();
            this.m_imgbtnDelete = new GTI.Controls.ImageButton();
            this.m_imgbtnSelect = new GTI.Controls.ImageButton();
            this.imgbtnCancel = new GTI.Controls.ImageButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // m_imgbtnImport
            // 
            this.m_imgbtnImport.BackColor = System.Drawing.Color.Transparent;
            this.m_imgbtnImport.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_imgbtnImport, "m_imgbtnImport");
            this.m_imgbtnImport.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_imgbtnImport.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_imgbtnImport.Name = "m_imgbtnImport";
            this.m_imgbtnImport.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_imgbtnImport.UseVisualStyleBackColor = false;
            this.m_imgbtnImport.Click += new System.EventHandler(this.m_imgbtnImport_Click);
            // 
            // m_imgbtnDelete
            // 
            this.m_imgbtnDelete.BackColor = System.Drawing.Color.Transparent;
            this.m_imgbtnDelete.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_imgbtnDelete, "m_imgbtnDelete");
            this.m_imgbtnDelete.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_imgbtnDelete.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_imgbtnDelete.Name = "m_imgbtnDelete";
            this.m_imgbtnDelete.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_imgbtnDelete.UseVisualStyleBackColor = false;
            // 
            // m_imgbtnSelect
            // 
            this.m_imgbtnSelect.BackColor = System.Drawing.Color.Transparent;
            this.m_imgbtnSelect.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_imgbtnSelect, "m_imgbtnSelect");
            this.m_imgbtnSelect.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_imgbtnSelect.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_imgbtnSelect.Name = "m_imgbtnSelect";
            this.m_imgbtnSelect.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_imgbtnSelect.UseVisualStyleBackColor = false;
            // 
            // imgbtnCancel
            // 
            this.imgbtnCancel.BackColor = System.Drawing.Color.Transparent;
            this.imgbtnCancel.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.imgbtnCancel, "imgbtnCancel");
            this.imgbtnCancel.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.imgbtnCancel.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.imgbtnCancel.Name = "imgbtnCancel";
            this.imgbtnCancel.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.imgbtnCancel.UseVisualStyleBackColor = false;
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
            this.groupBox1.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // PlayerLoyaltyTierIcon
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imgbtnCancel);
            this.Controls.Add(this.m_imgbtnImport);
            this.Controls.Add(this.m_imgbtnSelect);
            this.Controls.Add(this.m_imgbtnDelete);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PlayerLoyaltyTierIcon";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ImageButton m_imgbtnImport;
        private Controls.ImageButton m_imgbtnDelete;
        private Controls.ImageButton m_imgbtnSelect;
        private System.Windows.Forms.ImageList imageList1;
        private Controls.ImageButton imgbtnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}