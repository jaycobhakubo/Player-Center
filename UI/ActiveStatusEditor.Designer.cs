namespace GTI.Modules.PlayerCenter.UI
{
    partial class ActiveStatusEditor
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
            this.btnAdd = new GTI.Controls.ImageButton();
            this.btnActive = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            this.btnCancel = new GTI.Controls.ImageButton();
            this.listViewStatus = new System.Windows.Forms.ListView();
            this.m_alertColumn = new System.Windows.Forms.ColumnHeader();
            this.m_nameColumn = new System.Windows.Forms.ColumnHeader();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.btnUndo = new GTI.Controls.ImageButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.FocusColor = System.Drawing.Color.Black;
            this.btnAdd.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdd.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.btnAdd.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdd.Location = new System.Drawing.Point(12, 383);
            this.btnAdd.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(67, 30);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "&Add";
            this.toolTip1.SetToolTip(this.btnAdd, "Add a new Operator Player Status to the list.");
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnActive
            // 
            this.btnActive.BackColor = System.Drawing.Color.Transparent;
            this.btnActive.FocusColor = System.Drawing.Color.Black;
            this.btnActive.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnActive.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnActive.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.btnActive.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.btnActive.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnActive.Location = new System.Drawing.Point(85, 383);
            this.btnActive.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(91, 30);
            this.btnActive.TabIndex = 3;
            this.btnActive.Text = "Dea&ctivate";
            this.toolTip1.SetToolTip(this.btnActive, "Toggles Activation for the currently selected Status.");
            this.btnActive.UseVisualStyleBackColor = false;
            this.btnActive.Click += new System.EventHandler(this.btnActive_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.FocusColor = System.Drawing.Color.Black;
            this.btnSave.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSave.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.btnSave.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(235, 383);
            this.btnSave.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 30);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.toolTip1.SetToolTip(this.btnSave, "Saves the Operator Player Status list and exits.");
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FocusColor = System.Drawing.Color.Black;
            this.btnCancel.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.btnCancel.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(320, 383);
            this.btnCancel.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.toolTip1.SetToolTip(this.btnCancel, "Exits without saving the Operator Player Status list.");
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // listViewStatus
            // 
            this.listViewStatus.CausesValidation = false;
            this.listViewStatus.CheckBoxes = true;
            this.listViewStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_alertColumn,
            this.m_nameColumn});
            this.listViewStatus.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.listViewStatus.FullRowSelect = true;
            this.listViewStatus.GridLines = true;
            this.listViewStatus.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewStatus.HideSelection = false;
            this.listViewStatus.LabelWrap = false;
            this.listViewStatus.Location = new System.Drawing.Point(12, 82);
            this.listViewStatus.MultiSelect = false;
            this.listViewStatus.Name = "listViewStatus";
            this.listViewStatus.Size = new System.Drawing.Size(387, 256);
            this.listViewStatus.TabIndex = 8;
            this.listViewStatus.UseCompatibleStateImageBehavior = false;
            this.listViewStatus.View = System.Windows.Forms.View.Details;
            this.listViewStatus.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewStatus_ItemChecked);
            this.listViewStatus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listViewStatus_MouseUp);
            this.listViewStatus.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewStatus_ItemSelectionChanged);
            // 
            // m_alertColumn
            // 
            this.m_alertColumn.Text = "Alert";
            this.m_alertColumn.Width = 50;
            // 
            // m_nameColumn
            // 
            this.m_nameColumn.Text = "Name";
            this.m_nameColumn.Width = 310;
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.HideSelection = false;
            this.textBoxName.Location = new System.Drawing.Point(12, 346);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(302, 26);
            this.textBoxName.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBoxName, "Make changes to the Status here.");
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // btnUndo
            // 
            this.btnUndo.BackColor = System.Drawing.Color.Transparent;
            this.btnUndo.FocusColor = System.Drawing.Color.Black;
            this.btnUndo.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnUndo.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.btnUndo.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.btnUndo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUndo.Location = new System.Drawing.Point(320, 344);
            this.btnUndo.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(79, 30);
            this.btnUndo.TabIndex = 1;
            this.btnUndo.Text = "&Undo";
            this.toolTip1.SetToolTip(this.btnUndo, "Undo changes to this Status");
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Location = new System.Drawing.Point(12, 9);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(387, 25);
            this.lblInfo.TabIndex = 6;
            this.lblInfo.Text = "Select a status to change";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9.5F);
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(387, 38);
            this.label1.TabIndex = 7;
            this.label1.Text = "Select an Alert check box to display the corresponding status on the main POS scr" +
                "een when the player\'s card is swiped.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ActiveStatusEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(411, 425);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.listViewStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnActive);
            this.Controls.Add(this.btnAdd);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ActiveStatusEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Operator Player Status Editor";
            this.Load += new System.EventHandler(this.ActiveStatusEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GTI.Controls.ImageButton btnAdd;
        private GTI.Controls.ImageButton btnActive;
        private GTI.Controls.ImageButton btnSave;
        private GTI.Controls.ImageButton btnCancel;
        private System.Windows.Forms.ListView listViewStatus;
        private System.Windows.Forms.ColumnHeader m_alertColumn;
        private System.Windows.Forms.TextBox textBoxName;
        private GTI.Controls.ImageButton btnUndo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ColumnHeader m_nameColumn;
        private System.Windows.Forms.Label label1;
    }
}