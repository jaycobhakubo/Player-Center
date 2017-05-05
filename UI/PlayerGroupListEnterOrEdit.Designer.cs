namespace GTI.Modules.PlayerCenter.UI
{
    partial class PlayerGroupListEnterOrEdit
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
            this.txtbxDefinitionName = new System.Windows.Forms.TextBox();
            this.btnSaveList = new GTI.Controls.ImageButton();
            this.imgbtnCancel = new GTI.Controls.ImageButton();
            this.lblPlayerListName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtbxDefinitionName
            // 
            this.txtbxDefinitionName.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxDefinitionName.Location = new System.Drawing.Point(12, 46);
            this.txtbxDefinitionName.MaxLength = 50;
            this.txtbxDefinitionName.Name = "txtbxDefinitionName";
            this.txtbxDefinitionName.Size = new System.Drawing.Size(258, 26);
            this.txtbxDefinitionName.TabIndex = 50;
            this.txtbxDefinitionName.TextChanged += new System.EventHandler(this.txtbxDefinitionName_TextChanged);
            this.txtbxDefinitionName.Validating += new System.ComponentModel.CancelEventHandler(this.txtbxDefinitionName_Validating);
            // 
            // btnSaveList
            // 
            this.btnSaveList.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveList.FocusColor = System.Drawing.Color.Black;
            this.btnSaveList.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveList.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.btnSaveList.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.btnSaveList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSaveList.Location = new System.Drawing.Point(12, 88);
            this.btnSaveList.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnSaveList.Name = "btnSaveList";
            this.btnSaveList.Size = new System.Drawing.Size(122, 30);
            this.btnSaveList.TabIndex = 54;
            this.btnSaveList.Tag = "1";
            this.btnSaveList.Text = "&Create";
            this.btnSaveList.UseVisualStyleBackColor = false;
            this.btnSaveList.Click += new System.EventHandler(this.btnSaveList_Click);
            // 
            // imgbtnCancel
            // 
            this.imgbtnCancel.BackColor = System.Drawing.Color.Transparent;
            this.imgbtnCancel.FocusColor = System.Drawing.Color.Black;
            this.imgbtnCancel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imgbtnCancel.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.imgbtnCancel.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.imgbtnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.imgbtnCancel.Location = new System.Drawing.Point(148, 88);
            this.imgbtnCancel.MinimumSize = new System.Drawing.Size(30, 30);
            this.imgbtnCancel.Name = "imgbtnCancel";
            this.imgbtnCancel.Size = new System.Drawing.Size(122, 30);
            this.imgbtnCancel.TabIndex = 55;
            this.imgbtnCancel.Tag = "1";
            this.imgbtnCancel.Text = "&Cancel";
            this.imgbtnCancel.UseVisualStyleBackColor = false;
            this.imgbtnCancel.Click += new System.EventHandler(this.imgbtnCancel_Click);
            // 
            // lblPlayerListName
            // 
            this.lblPlayerListName.AutoSize = true;
            this.lblPlayerListName.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerListName.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.lblPlayerListName.Location = new System.Drawing.Point(12, 9);
            this.lblPlayerListName.Name = "lblPlayerListName";
            this.lblPlayerListName.Size = new System.Drawing.Size(121, 22);
            this.lblPlayerListName.TabIndex = 56;
            this.lblPlayerListName.Text = "New Player List";
            // 
            // PlayerGroupListEnterOrEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 143);
            this.ControlBox = false;
            this.Controls.Add(this.lblPlayerListName);
            this.Controls.Add(this.imgbtnCancel);
            this.Controls.Add(this.btnSaveList);
            this.Controls.Add(this.txtbxDefinitionName);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlayerGroupListEnterOrEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Player List";
            this.Load += new System.EventHandler(this.PlayerGroupListEnterOrEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbxDefinitionName;
        private Controls.ImageButton btnSaveList;
        private Controls.ImageButton imgbtnCancel;
        private System.Windows.Forms.Label lblPlayerListName;
    }
}