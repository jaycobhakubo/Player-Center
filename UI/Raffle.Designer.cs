namespace GTI.Modules.PlayerCenter.UI
{
    partial class Raffle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Raffle));
            this.tbctrlRafle = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstBxRafflePrizes2 = new System.Windows.Forms.ListBox();
            this.imgbtnUpdate = new GTI.Controls.ImageButton();
            this.btnSetupDelete = new GTI.Controls.ImageButton();
            this.btnSetupNew = new GTI.Controls.ImageButton();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbxDisclaimer = new System.Windows.Forms.TextBox();
            this.lblSavedSuccessfully = new System.Windows.Forms.Label();
            this.txtbxSetupPrizeDescription = new System.Windows.Forms.TextBox();
            this.txtbxSetupNumberofWinners = new System.Windows.Forms.TextBox();
            this.txtbxSetupName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSetupSave = new GTI.Controls.ImageButton();
            this.btnSetupClose = new GTI.Controls.ImageButton();
            this.btnSetupCancel = new GTI.Controls.ImageButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbxPlayerList = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPlayerList = new System.Windows.Forms.Label();
            this.cmbxRaffle = new System.Windows.Forms.ComboBox();
            this.btnRunRaffle = new GTI.Controls.ImageButton();
            this.lblRaffleInfo = new System.Windows.Forms.Label();
            this.lstbxRaffleWinners2 = new System.Windows.Forms.ListBox();
            this.btnClearRaffle = new GTI.Controls.ImageButton();
            this.btnRaffleClose = new GTI.Controls.ImageButton();
            this.btnRaffleReprintVoucher = new GTI.Controls.ImageButton();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tbctrlRafle.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbctrlRafle
            // 
            this.tbctrlRafle.Controls.Add(this.tabPage1);
            this.tbctrlRafle.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tbctrlRafle, "tbctrlRafle");
            this.tbctrlRafle.Name = "tbctrlRafle";
            this.tbctrlRafle.SelectedIndex = 0;
            this.tbctrlRafle.Tag = "1";
            this.tbctrlRafle.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tbctrlRafle_Selecting);
            this.tbctrlRafle.Enter += new System.EventHandler(this.ClearErrorProvider);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(179)))), ((int)(((byte)(213)))));
            this.tabPage1.Controls.Add(this.splitContainer1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Tag = "1";
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.TabStop = false;
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.imgbtnUpdate);
            this.splitContainer2.Panel2.Controls.Add(this.btnSetupDelete);
            this.splitContainer2.Panel2.Controls.Add(this.btnSetupNew);
            this.splitContainer2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstBxRafflePrizes2);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // lstBxRafflePrizes2
            // 
            this.lstBxRafflePrizes2.FormattingEnabled = true;
            resources.ApplyResources(this.lstBxRafflePrizes2, "lstBxRafflePrizes2");
            this.lstBxRafflePrizes2.Name = "lstBxRafflePrizes2";
            this.lstBxRafflePrizes2.SelectedIndexChanged += new System.EventHandler(this.colorListBox1_SelectedIndexChanged);
            this.lstBxRafflePrizes2.Enter += new System.EventHandler(this.ClearErrorProvider);
            // 
            // imgbtnUpdate
            // 
            this.imgbtnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.imgbtnUpdate.FocusColor = System.Drawing.Color.Black;
            this.imgbtnUpdate.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.imgbtnUpdate.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            resources.ApplyResources(this.imgbtnUpdate, "imgbtnUpdate");
            this.imgbtnUpdate.Name = "imgbtnUpdate";
            this.imgbtnUpdate.UseVisualStyleBackColor = false;
            this.imgbtnUpdate.Click += new System.EventHandler(this.imgbtnUpdate_Click);
            // 
            // btnSetupDelete
            // 
            this.btnSetupDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnSetupDelete.FocusColor = System.Drawing.Color.Black;
            this.btnSetupDelete.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.btnSetupDelete.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            resources.ApplyResources(this.btnSetupDelete, "btnSetupDelete");
            this.btnSetupDelete.Name = "btnSetupDelete";
            this.btnSetupDelete.UseVisualStyleBackColor = false;
            this.btnSetupDelete.Click += new System.EventHandler(this.btnSetupDelete_Click);
            // 
            // btnSetupNew
            // 
            this.btnSetupNew.BackColor = System.Drawing.Color.Transparent;
            this.btnSetupNew.FocusColor = System.Drawing.Color.Black;
            this.btnSetupNew.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.btnSetupNew.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            resources.ApplyResources(this.btnSetupNew, "btnSetupNew");
            this.btnSetupNew.Name = "btnSetupNew";
            this.btnSetupNew.UseVisualStyleBackColor = false;
            this.btnSetupNew.Click += new System.EventHandler(this.btnSetupNew_Click);
            this.btnSetupNew.Enter += new System.EventHandler(this.ClearErrorProvider);
            // 
            // splitContainer3
            // 
            resources.ApplyResources(this.splitContainer3, "splitContainer3");
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btnSetupSave);
            this.splitContainer3.Panel2.Controls.Add(this.btnSetupClose);
            this.splitContainer3.Panel2.Controls.Add(this.btnSetupCancel);
            this.splitContainer3.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtbxDisclaimer);
            this.groupBox2.Controls.Add(this.lblSavedSuccessfully);
            this.groupBox2.Controls.Add(this.txtbxSetupPrizeDescription);
            this.groupBox2.Controls.Add(this.txtbxSetupNumberofWinners);
            this.groupBox2.Controls.Add(this.txtbxSetupName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtbxDisclaimer
            // 
            resources.ApplyResources(this.txtbxDisclaimer, "txtbxDisclaimer");
            this.txtbxDisclaimer.Name = "txtbxDisclaimer";
            this.txtbxDisclaimer.Enter += new System.EventHandler(this.ClearErrorProvider);
            this.txtbxDisclaimer.Validating += new System.ComponentModel.CancelEventHandler(this.txtbxDisclaimer_Validating);
            // 
            // lblSavedSuccessfully
            // 
            resources.ApplyResources(this.lblSavedSuccessfully, "lblSavedSuccessfully");
            this.lblSavedSuccessfully.Name = "lblSavedSuccessfully";
            // 
            // txtbxSetupPrizeDescription
            // 
            resources.ApplyResources(this.txtbxSetupPrizeDescription, "txtbxSetupPrizeDescription");
            this.txtbxSetupPrizeDescription.Name = "txtbxSetupPrizeDescription";
            this.txtbxSetupPrizeDescription.Enter += new System.EventHandler(this.ClearErrorProvider);
            this.txtbxSetupPrizeDescription.Validating += new System.ComponentModel.CancelEventHandler(this.txtbxSetupPrizeDescription_Validating);
            // 
            // txtbxSetupNumberofWinners
            // 
            resources.ApplyResources(this.txtbxSetupNumberofWinners, "txtbxSetupNumberofWinners");
            this.txtbxSetupNumberofWinners.Name = "txtbxSetupNumberofWinners";
            this.txtbxSetupNumberofWinners.Enter += new System.EventHandler(this.ClearErrorProvider);
            this.txtbxSetupNumberofWinners.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxSetupNumberofWinners_KeyPress);
            this.txtbxSetupNumberofWinners.Validating += new System.ComponentModel.CancelEventHandler(this.txtbxSetupNumberofWinners_Validating);
            // 
            // txtbxSetupName
            // 
            resources.ApplyResources(this.txtbxSetupName, "txtbxSetupName");
            this.txtbxSetupName.Name = "txtbxSetupName";
            this.txtbxSetupName.Enter += new System.EventHandler(this.ClearErrorProvider);
            this.txtbxSetupName.Validating += new System.ComponentModel.CancelEventHandler(this.txtbxSetupName_Validating);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnSetupSave
            // 
            this.btnSetupSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSetupSave.FocusColor = System.Drawing.Color.Black;
            this.btnSetupSave.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.btnSetupSave.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            resources.ApplyResources(this.btnSetupSave, "btnSetupSave");
            this.btnSetupSave.Name = "btnSetupSave";
            this.btnSetupSave.UseVisualStyleBackColor = false;
            this.btnSetupSave.Click += new System.EventHandler(this.btnSetupSave_Click);
            // 
            // btnSetupClose
            // 
            this.btnSetupClose.BackColor = System.Drawing.Color.Transparent;
            this.btnSetupClose.FocusColor = System.Drawing.Color.Black;
            this.btnSetupClose.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.btnSetupClose.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            resources.ApplyResources(this.btnSetupClose, "btnSetupClose");
            this.btnSetupClose.Name = "btnSetupClose";
            this.btnSetupClose.UseVisualStyleBackColor = false;
            this.btnSetupClose.Click += new System.EventHandler(this.btnSetupClose_Click);
            this.btnSetupClose.Enter += new System.EventHandler(this.ClearErrorProvider);
            // 
            // btnSetupCancel
            // 
            this.btnSetupCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnSetupCancel.FocusColor = System.Drawing.Color.Black;
            this.btnSetupCancel.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.btnSetupCancel.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            resources.ApplyResources(this.btnSetupCancel, "btnSetupCancel");
            this.btnSetupCancel.Name = "btnSetupCancel";
            this.btnSetupCancel.UseVisualStyleBackColor = false;
            this.btnSetupCancel.Click += new System.EventHandler(this.btnSetupCancel_Click);
            this.btnSetupCancel.Enter += new System.EventHandler(this.ClearErrorProvider);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(179)))), ((int)(((byte)(213)))));
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.lstbxRaffleWinners2);
            this.tabPage2.Controls.Add(this.btnClearRaffle);
            this.tabPage2.Controls.Add(this.btnRaffleClose);
            this.tabPage2.Controls.Add(this.btnRaffleReprintVoucher);
            this.tabPage2.Controls.Add(this.label6);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Tag = "2";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbxPlayerList);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.lblPlayerList);
            this.groupBox3.Controls.Add(this.cmbxRaffle);
            this.groupBox3.Controls.Add(this.btnRunRaffle);
            this.groupBox3.Controls.Add(this.lblRaffleInfo);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // cmbxPlayerList
            // 
            this.cmbxPlayerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxPlayerList.FormattingEnabled = true;
            resources.ApplyResources(this.cmbxPlayerList, "cmbxPlayerList");
            this.cmbxPlayerList.Name = "cmbxPlayerList";
            this.cmbxPlayerList.SelectedIndexChanged += new System.EventHandler(this.cmbxPlayerList_SelectedIndexChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // lblPlayerList
            // 
            resources.ApplyResources(this.lblPlayerList, "lblPlayerList");
            this.lblPlayerList.Name = "lblPlayerList";
            // 
            // cmbxRaffle
            // 
            this.cmbxRaffle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxRaffle.FormattingEnabled = true;
            resources.ApplyResources(this.cmbxRaffle, "cmbxRaffle");
            this.cmbxRaffle.Name = "cmbxRaffle";
            this.cmbxRaffle.SelectedIndexChanged += new System.EventHandler(this.cmbxRaffle_SelectedIndexChanged);
            this.cmbxRaffle.Enter += new System.EventHandler(this.ClearErrorProvider);
            this.cmbxRaffle.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxRaffle_Validating);
            // 
            // btnRunRaffle
            // 
            this.btnRunRaffle.BackColor = System.Drawing.Color.Transparent;
            this.btnRunRaffle.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnRunRaffle, "btnRunRaffle");
            this.btnRunRaffle.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.btnRunRaffle.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.btnRunRaffle.Name = "btnRunRaffle";
            this.btnRunRaffle.UseVisualStyleBackColor = false;
            this.btnRunRaffle.Click += new System.EventHandler(this.btnRunRaffle_Click);
            this.btnRunRaffle.Enter += new System.EventHandler(this.ClearErrorProvider);
            // 
            // lblRaffleInfo
            // 
            resources.ApplyResources(this.lblRaffleInfo, "lblRaffleInfo");
            this.lblRaffleInfo.Name = "lblRaffleInfo";
            // 
            // lstbxRaffleWinners2
            // 
            this.lstbxRaffleWinners2.FormattingEnabled = true;
            resources.ApplyResources(this.lstbxRaffleWinners2, "lstbxRaffleWinners2");
            this.lstbxRaffleWinners2.Name = "lstbxRaffleWinners2";
            this.lstbxRaffleWinners2.TabStop = false;
            this.lstbxRaffleWinners2.Enter += new System.EventHandler(this.ClearErrorProvider);
            // 
            // btnClearRaffle
            // 
            this.btnClearRaffle.BackColor = System.Drawing.Color.Transparent;
            this.btnClearRaffle.FocusColor = System.Drawing.Color.Black;
            this.btnClearRaffle.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.btnClearRaffle.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            resources.ApplyResources(this.btnClearRaffle, "btnClearRaffle");
            this.btnClearRaffle.Name = "btnClearRaffle";
            this.btnClearRaffle.UseVisualStyleBackColor = false;
            this.btnClearRaffle.Click += new System.EventHandler(this.btnClearRaffle_Click);
            this.btnClearRaffle.Enter += new System.EventHandler(this.ClearErrorProvider);
            // 
            // btnRaffleClose
            // 
            this.btnRaffleClose.BackColor = System.Drawing.Color.Transparent;
            this.btnRaffleClose.FocusColor = System.Drawing.Color.Black;
            this.btnRaffleClose.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.btnRaffleClose.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            resources.ApplyResources(this.btnRaffleClose, "btnRaffleClose");
            this.btnRaffleClose.Name = "btnRaffleClose";
            this.btnRaffleClose.UseVisualStyleBackColor = false;
            this.btnRaffleClose.Click += new System.EventHandler(this.btnRaffleClose_Click);
            this.btnRaffleClose.Enter += new System.EventHandler(this.ClearErrorProvider);
            // 
            // btnRaffleReprintVoucher
            // 
            this.btnRaffleReprintVoucher.BackColor = System.Drawing.Color.Transparent;
            this.btnRaffleReprintVoucher.FocusColor = System.Drawing.Color.Black;
            this.btnRaffleReprintVoucher.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.btnRaffleReprintVoucher.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            resources.ApplyResources(this.btnRaffleReprintVoucher, "btnRaffleReprintVoucher");
            this.btnRaffleReprintVoucher.Name = "btnRaffleReprintVoucher";
            this.btnRaffleReprintVoucher.UseVisualStyleBackColor = false;
            this.btnRaffleReprintVoucher.Click += new System.EventHandler(this.btnRaffleReprintVoucher_Click);
            this.btnRaffleReprintVoucher.Enter += new System.EventHandler(this.ClearErrorProvider);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Raffle
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tbctrlRafle);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Raffle";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Raffle_FormClosing);
            this.tbctrlRafle.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbctrlRafle;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.ImageButton btnSetupDelete;
        private Controls.ImageButton btnSetupNew;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtbxSetupPrizeDescription;
        private System.Windows.Forms.TextBox txtbxSetupNumberofWinners;
        private System.Windows.Forms.TextBox txtbxSetupName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Controls.ImageButton btnSetupSave;
        private Controls.ImageButton btnSetupClose;
        private Controls.ImageButton btnSetupCancel;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        public System.Windows.Forms.Label lblSavedSuccessfully;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblRaffleInfo;
        private Controls.ImageButton btnRaffleClose;
        private Controls.ImageButton btnRaffleReprintVoucher;
        private System.Windows.Forms.Label label6;
        private Controls.ImageButton btnRunRaffle;
        private System.Windows.Forms.ComboBox cmbxRaffle;
        private Controls.ImageButton btnClearRaffle;
        private System.Windows.Forms.TextBox txtbxDisclaimer;
        private System.Windows.Forms.ListBox lstBxRafflePrizes2;
        private System.Windows.Forms.ListBox lstbxRaffleWinners2;
        private System.Windows.Forms.Label label4;
        private Controls.ImageButton imgbtnUpdate;
        private System.Windows.Forms.ComboBox cmbxPlayerList;
        private System.Windows.Forms.Label lblPlayerList;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}