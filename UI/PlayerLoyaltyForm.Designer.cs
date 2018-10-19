namespace GTI.Modules.PlayerCenter.UI
{
    partial class PlayerLoyaltyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerLoyaltyForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.colorListBoxTiers = new GTI.Controls.ColorListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.imageButtonRemoveTier = new GTI.Controls.ImageButton();
            this.imageButtonAddTier = new GTI.Controls.ImageButton();
            this.cboColor = new System.Windows.Forms.Label();
            this.m_cancelButton = new GTI.Controls.ImageButton();
            this.imageButtonSave = new GTI.Controls.ImageButton();
            this.textBoxAwardPoints = new System.Windows.Forms.TextBox();
            this.labelAwardPoints = new System.Windows.Forms.Label();
            this.comboBoxPoints = new System.Windows.Forms.ComboBox();
            this.comboBoxSpend = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxPointsStart = new System.Windows.Forms.TextBox();
            this.labelTierName = new System.Windows.Forms.Label();
            this.labelColor = new System.Windows.Forms.Label();
            this.textBoxSpendStart = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelPointsStart = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPoints = new System.Windows.Forms.Label();
            this.labelSpendStart = new System.Windows.Forms.Label();
            this.labelSpend = new System.Windows.Forms.Label();
            this.txtTierName = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.labelRestart = new System.Windows.Forms.Label();
            this.comboBoxRestart = new System.Windows.Forms.ComboBox();
            this.imageButton3 = new GTI.Controls.ImageButton();
            this.imageButton4 = new GTI.Controls.ImageButton();
            this.cmbx_DefaultTier = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(60)))), ((int)(((byte)(96)))));
            this.splitContainer1.Panel1.Controls.Add(this.colorListBoxTiers);
            this.splitContainer1.Panel1.Controls.Add(this.label15);
            this.splitContainer1.Panel1.Controls.Add(this.imageButtonRemoveTier);
            this.splitContainer1.Panel1.Controls.Add(this.imageButtonAddTier);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(179)))), ((int)(((byte)(213)))));
            this.splitContainer1.Panel2.Controls.Add(this.cboColor);
            this.splitContainer1.Panel2.Controls.Add(this.m_cancelButton);
            this.splitContainer1.Panel2.Controls.Add(this.imageButtonSave);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxAwardPoints);
            this.splitContainer1.Panel2.Controls.Add(this.labelAwardPoints);
            this.splitContainer1.Panel2.Controls.Add(this.comboBoxPoints);
            this.splitContainer1.Panel2.Controls.Add(this.comboBoxSpend);
            this.splitContainer1.Panel2.Controls.Add(this.label16);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxPointsStart);
            this.splitContainer1.Panel2.Controls.Add(this.labelTierName);
            this.splitContainer1.Panel2.Controls.Add(this.labelColor);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxSpendStart);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.labelPointsStart);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.labelPoints);
            this.splitContainer1.Panel2.Controls.Add(this.labelSpendStart);
            this.splitContainer1.Panel2.Controls.Add(this.labelSpend);
            this.splitContainer1.Panel2.Controls.Add(this.txtTierName);
            this.splitContainer1.Panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // colorListBoxTiers
            // 
            this.colorListBoxTiers.AllowDrop = true;
            this.colorListBoxTiers.BackColor = System.Drawing.Color.White;
            this.colorListBoxTiers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            resources.ApplyResources(this.colorListBoxTiers, "colorListBoxTiers");
            this.colorListBoxTiers.ForeColor = System.Drawing.Color.Black;
            this.colorListBoxTiers.FormattingEnabled = true;
            this.colorListBoxTiers.HighlightColor = System.Drawing.SystemColors.Highlight;
            this.colorListBoxTiers.ImageList = null;
            this.colorListBoxTiers.Items.AddRange(new object[] {
            resources.GetString("colorListBoxTiers.Items"),
            resources.GetString("colorListBoxTiers.Items1"),
            resources.GetString("colorListBoxTiers.Items2")});
            this.colorListBoxTiers.Name = "colorListBoxTiers";
            this.colorListBoxTiers.SuppressVerticalScroll = true;
            this.colorListBoxTiers.TabStop = false;
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Name = "label15";
            // 
            // imageButtonRemoveTier
            // 
            this.imageButtonRemoveTier.BackColor = System.Drawing.Color.Transparent;
            this.imageButtonRemoveTier.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.imageButtonRemoveTier, "imageButtonRemoveTier");
            this.imageButtonRemoveTier.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.imageButtonRemoveTier.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.imageButtonRemoveTier.Name = "imageButtonRemoveTier";
            this.imageButtonRemoveTier.TabStop = false;
            this.imageButtonRemoveTier.UseVisualStyleBackColor = false;
            // 
            // imageButtonAddTier
            // 
            this.imageButtonAddTier.BackColor = System.Drawing.Color.Transparent;
            this.imageButtonAddTier.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.imageButtonAddTier, "imageButtonAddTier");
            this.imageButtonAddTier.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.imageButtonAddTier.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.imageButtonAddTier.Name = "imageButtonAddTier";
            this.imageButtonAddTier.UseVisualStyleBackColor = false;
            this.imageButtonAddTier.Click += new System.EventHandler(this.imageButtonAddTier_Click);
            // 
            // cboColor
            // 
            this.cboColor.BackColor = System.Drawing.Color.Transparent;
            this.cboColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.cboColor, "cboColor");
            this.cboColor.Name = "cboColor";
            this.cboColor.Click += new System.EventHandler(this.cboColor_Click);
            // 
            // m_cancelButton
            // 
            this.m_cancelButton.BackColor = System.Drawing.Color.Transparent;
            this.m_cancelButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_cancelButton, "m_cancelButton");
            this.m_cancelButton.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_cancelButton.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_cancelButton.Name = "m_cancelButton";
            this.m_cancelButton.UseVisualStyleBackColor = false;
            // 
            // imageButtonSave
            // 
            this.imageButtonSave.BackColor = System.Drawing.Color.Transparent;
            this.imageButtonSave.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.imageButtonSave, "imageButtonSave");
            this.imageButtonSave.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.imageButtonSave.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.imageButtonSave.Name = "imageButtonSave";
            this.imageButtonSave.UseVisualStyleBackColor = false;
            this.imageButtonSave.Click += new System.EventHandler(this.imageButtonSave_Click);
            // 
            // textBoxAwardPoints
            // 
            this.textBoxAwardPoints.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.textBoxAwardPoints, "textBoxAwardPoints");
            this.textBoxAwardPoints.Name = "textBoxAwardPoints";
            // 
            // labelAwardPoints
            // 
            resources.ApplyResources(this.labelAwardPoints, "labelAwardPoints");
            this.labelAwardPoints.Name = "labelAwardPoints";
            // 
            // comboBoxPoints
            // 
            this.comboBoxPoints.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboBoxPoints, "comboBoxPoints");
            this.comboBoxPoints.FormattingEnabled = true;
            this.comboBoxPoints.Items.AddRange(new object[] {
            resources.GetString("comboBoxPoints.Items"),
            resources.GetString("comboBoxPoints.Items1")});
            this.comboBoxPoints.Name = "comboBoxPoints";
            this.comboBoxPoints.SelectedIndexChanged += new System.EventHandler(this.comboBoxPoints_SelectedIndexChanged);
            // 
            // comboBoxSpend
            // 
            this.comboBoxSpend.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboBoxSpend, "comboBoxSpend");
            this.comboBoxSpend.FormattingEnabled = true;
            this.comboBoxSpend.Items.AddRange(new object[] {
            resources.GetString("comboBoxSpend.Items"),
            resources.GetString("comboBoxSpend.Items1")});
            this.comboBoxSpend.Name = "comboBoxSpend";
            this.comboBoxSpend.SelectedIndexChanged += new System.EventHandler(this.comboBoxSpend_SelectedIndexChanged);
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Name = "label16";
            // 
            // textBoxPointsStart
            // 
            this.textBoxPointsStart.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.textBoxPointsStart, "textBoxPointsStart");
            this.textBoxPointsStart.Name = "textBoxPointsStart";
            this.textBoxPointsStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPointsStart_KeyPress);
            // 
            // labelTierName
            // 
            resources.ApplyResources(this.labelTierName, "labelTierName");
            this.labelTierName.Name = "labelTierName";
            // 
            // labelColor
            // 
            resources.ApplyResources(this.labelColor, "labelColor");
            this.labelColor.Name = "labelColor";
            // 
            // textBoxSpendStart
            // 
            this.textBoxSpendStart.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.textBoxSpendStart, "textBoxSpendStart");
            this.textBoxSpendStart.ForeColor = System.Drawing.Color.Black;
            this.textBoxSpendStart.Name = "textBoxSpendStart";
            this.textBoxSpendStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSpendStart_KeyPress);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Name = "label2";
            // 
            // labelPointsStart
            // 
            resources.ApplyResources(this.labelPointsStart, "labelPointsStart");
            this.labelPointsStart.Name = "labelPointsStart";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Name = "label1";
            // 
            // labelPoints
            // 
            resources.ApplyResources(this.labelPoints, "labelPoints");
            this.labelPoints.Name = "labelPoints";
            // 
            // labelSpendStart
            // 
            resources.ApplyResources(this.labelSpendStart, "labelSpendStart");
            this.labelSpendStart.Name = "labelSpendStart";
            // 
            // labelSpend
            // 
            resources.ApplyResources(this.labelSpend, "labelSpend");
            this.labelSpend.Name = "labelSpend";
            // 
            // txtTierName
            // 
            this.txtTierName.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.txtTierName, "txtTierName");
            this.txtTierName.Name = "txtTierName";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.splitContainer2);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(60)))), ((int)(((byte)(96)))));
            this.splitContainer2.Panel1Collapsed = true;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(179)))), ((int)(((byte)(213)))));
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Panel2.Controls.Add(this.labelRestart);
            this.splitContainer2.Panel2.Controls.Add(this.comboBoxRestart);
            this.splitContainer2.Panel2.Controls.Add(this.imageButton3);
            this.splitContainer2.Panel2.Controls.Add(this.imageButton4);
            this.splitContainer2.Panel2.Controls.Add(this.cmbx_DefaultTier);
            this.splitContainer2.Panel2.Controls.Add(this.label8);
            this.splitContainer2.Panel2.Controls.Add(this.label9);
            this.splitContainer2.Panel2.Controls.Add(this.label10);
            this.splitContainer2.Panel2.Controls.Add(this.dateTimePicker1);
            this.splitContainer2.Panel2.Controls.Add(this.dateTimePicker2);
            this.splitContainer2.Panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Name = "label3";
            // 
            // labelRestart
            // 
            resources.ApplyResources(this.labelRestart, "labelRestart");
            this.labelRestart.Name = "labelRestart";
            // 
            // comboBoxRestart
            // 
            resources.ApplyResources(this.comboBoxRestart, "comboBoxRestart");
            this.comboBoxRestart.FormattingEnabled = true;
            this.comboBoxRestart.Items.AddRange(new object[] {
            resources.GetString("comboBoxRestart.Items"),
            resources.GetString("comboBoxRestart.Items1")});
            this.comboBoxRestart.Name = "comboBoxRestart";
            // 
            // imageButton3
            // 
            this.imageButton3.BackColor = System.Drawing.Color.Transparent;
            this.imageButton3.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.imageButton3, "imageButton3");
            this.imageButton3.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.imageButton3.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.imageButton3.Name = "imageButton3";
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
            this.imageButton4.UseVisualStyleBackColor = false;
            this.imageButton4.Click += new System.EventHandler(this.imageButton4_Click);
            // 
            // cmbx_DefaultTier
            // 
            resources.ApplyResources(this.cmbx_DefaultTier, "cmbx_DefaultTier");
            this.cmbx_DefaultTier.FormattingEnabled = true;
            this.cmbx_DefaultTier.Items.AddRange(new object[] {
            resources.GetString("cmbx_DefaultTier.Items"),
            resources.GetString("cmbx_DefaultTier.Items1"),
            resources.GetString("cmbx_DefaultTier.Items2")});
            this.cmbx_DefaultTier.Name = "cmbx_DefaultTier";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // dateTimePicker1
            // 
            resources.ApplyResources(this.dateTimePicker1, "dateTimePicker1");
            this.dateTimePicker1.Name = "dateTimePicker1";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarForeColor = System.Drawing.Color.Yellow;
            this.dateTimePicker2.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(67)))), ((int)(((byte)(115)))));
            resources.ApplyResources(this.dateTimePicker2, "dateTimePicker2");
            this.dateTimePicker2.Name = "dateTimePicker2";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // PlayerLoyaltyForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(179)))), ((int)(((byte)(213)))));
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PlayerLoyaltyForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controls.ColorListBox colorListBoxTiers;
        private System.Windows.Forms.Label label15;
        private Controls.ImageButton imageButtonRemoveTier;
        private Controls.ImageButton imageButtonAddTier;
        private Controls.ImageButton m_cancelButton;
        private Controls.ImageButton imageButtonSave;
        private System.Windows.Forms.TextBox textBoxAwardPoints;
        private System.Windows.Forms.Label labelAwardPoints;
        private System.Windows.Forms.ComboBox comboBoxPoints;
        private System.Windows.Forms.ComboBox comboBoxSpend;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxPointsStart;
        private System.Windows.Forms.Label labelTierName;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.TextBox textBoxSpendStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelPointsStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPoints;
        private System.Windows.Forms.Label labelSpendStart;
        private System.Windows.Forms.Label labelSpend;
        private System.Windows.Forms.TextBox txtTierName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Controls.ImageButton imageButton3;
        private Controls.ImageButton imageButton4;
        private System.Windows.Forms.ComboBox cmbx_DefaultTier;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label labelRestart;
        private System.Windows.Forms.ComboBox comboBoxRestart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label cboColor;



    }
}