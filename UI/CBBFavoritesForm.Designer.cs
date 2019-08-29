namespace GTI.Modules.Shared
{
    partial class CBBFavoritesForm
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
            this.m_btnClose = new GTI.Controls.ImageButton();
            this.m_btnPrint = new GTI.Controls.ImageButton();
            this.m_lblTitle = new System.Windows.Forms.Label();
            this.m_btnDown = new GTI.Controls.ImageButton();
            this.m_btnUp = new GTI.Controls.ImageButton();
            this.m_clstFavorites = new GTI.Controls.ColorListBox();
            this.m_btnClearAllFavorites = new GTI.Controls.ImageButton();
            this.SuspendLayout();
            // 
            // m_btnClose
            // 
            this.m_btnClose.BackColor = System.Drawing.Color.Transparent;
            this.m_btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnClose.FocusColor = System.Drawing.Color.Black;
            this.m_btnClose.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_btnClose.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_btnClose.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_btnClose.Location = new System.Drawing.Point(647, 437);
            this.m_btnClose.MinimumSize = new System.Drawing.Size(30, 30);
            this.m_btnClose.Name = "m_btnClose";
            this.m_btnClose.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_btnClose.ShowFocus = false;
            this.m_btnClose.Size = new System.Drawing.Size(134, 51);
            this.m_btnClose.TabIndex = 5;
            this.m_btnClose.Text = "Close";
            this.m_btnClose.UseVisualStyleBackColor = false;
            // 
            // m_btnPrint
            // 
            this.m_btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.m_btnPrint.FocusColor = System.Drawing.Color.Black;
            this.m_btnPrint.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_btnPrint.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_btnPrint.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_btnPrint.Location = new System.Drawing.Point(12, 437);
            this.m_btnPrint.MinimumSize = new System.Drawing.Size(30, 30);
            this.m_btnPrint.Name = "m_btnPrint";
            this.m_btnPrint.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_btnPrint.ShowFocus = false;
            this.m_btnPrint.Size = new System.Drawing.Size(134, 51);
            this.m_btnPrint.TabIndex = 4;
            this.m_btnPrint.Text = "Print";
            this.m_btnPrint.UseVisualStyleBackColor = false;
            this.m_btnPrint.Click += new System.EventHandler(this.m_btnPrint_Click);
            // 
            // m_lblTitle
            // 
            this.m_lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.m_lblTitle.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblTitle.Location = new System.Drawing.Point(175, 13);
            this.m_lblTitle.Name = "m_lblTitle";
            this.m_lblTitle.Size = new System.Drawing.Size(442, 32);
            this.m_lblTitle.TabIndex = 3;
            this.m_lblTitle.Text = "Player\'s Crystal Ball Favorites";
            this.m_lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_btnDown
            // 
            this.m_btnDown.BackColor = System.Drawing.Color.Transparent;
            this.m_btnDown.FocusColor = System.Drawing.Color.Black;
            this.m_btnDown.ImageIcon = global::GTI.Modules.PlayerCenter.Properties.Resources.ArrowDown;
            this.m_btnDown.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_btnDown.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_btnDown.Location = new System.Drawing.Point(724, 162);
            this.m_btnDown.MinimumSize = new System.Drawing.Size(30, 30);
            this.m_btnDown.Name = "m_btnDown";
            this.m_btnDown.RepeatingIfHeld = true;
            this.m_btnDown.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_btnDown.ShowFocus = false;
            this.m_btnDown.Size = new System.Drawing.Size(57, 58);
            this.m_btnDown.TabIndex = 2;
            this.m_btnDown.UseVisualStyleBackColor = false;
            this.m_btnDown.Click += new System.EventHandler(this.m_btnDown_Click);
            // 
            // m_btnUp
            // 
            this.m_btnUp.BackColor = System.Drawing.Color.Transparent;
            this.m_btnUp.FocusColor = System.Drawing.Color.Black;
            this.m_btnUp.ImageIcon = global::GTI.Modules.PlayerCenter.Properties.Resources.ArrowUp;
            this.m_btnUp.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_btnUp.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_btnUp.Location = new System.Drawing.Point(724, 68);
            this.m_btnUp.MinimumSize = new System.Drawing.Size(30, 30);
            this.m_btnUp.Name = "m_btnUp";
            this.m_btnUp.RepeatingIfHeld = true;
            this.m_btnUp.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_btnUp.ShowFocus = false;
            this.m_btnUp.Size = new System.Drawing.Size(57, 58);
            this.m_btnUp.TabIndex = 1;
            this.m_btnUp.UseVisualStyleBackColor = false;
            this.m_btnUp.Click += new System.EventHandler(this.m_btnUp_Click);
            // 
            // m_clstFavorites
            // 
            this.m_clstFavorites.DownButton = this.m_btnDown;
            this.m_clstFavorites.DownIconBottomNotVisible = global::GTI.Modules.PlayerCenter.Properties.Resources.ArrowDownRed;
            this.m_clstFavorites.DownIconBottomVisible = global::GTI.Modules.PlayerCenter.Properties.Resources.ArrowDown;
            this.m_clstFavorites.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.m_clstFavorites.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_clstFavorites.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_clstFavorites.FormattingEnabled = true;
            this.m_clstFavorites.HighlightColor = System.Drawing.Color.Yellow;
            this.m_clstFavorites.ImageList = null;
            this.m_clstFavorites.IntegralHeight = false;
            this.m_clstFavorites.Location = new System.Drawing.Point(12, 68);
            this.m_clstFavorites.Name = "m_clstFavorites";
            this.m_clstFavorites.Size = new System.Drawing.Size(683, 348);
            this.m_clstFavorites.SuppressVerticalScroll = true;
            this.m_clstFavorites.TabIndex = 0;
            this.m_clstFavorites.TopIndexForScroll = 0;
            this.m_clstFavorites.UpButton = this.m_btnUp;
            this.m_clstFavorites.UpIconTopNotVisible = global::GTI.Modules.PlayerCenter.Properties.Resources.ArrowUpRed;
            this.m_clstFavorites.UpIconTopVisible = global::GTI.Modules.PlayerCenter.Properties.Resources.ArrowUp;
            // 
            // m_btnClearAllFavorites
            // 
            this.m_btnClearAllFavorites.BackColor = System.Drawing.Color.Transparent;
            this.m_btnClearAllFavorites.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnClearAllFavorites.FocusColor = System.Drawing.Color.Black;
            this.m_btnClearAllFavorites.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_btnClearAllFavorites.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.m_btnClearAllFavorites.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.m_btnClearAllFavorites.Location = new System.Drawing.Point(329, 437);
            this.m_btnClearAllFavorites.MinimumSize = new System.Drawing.Size(30, 30);
            this.m_btnClearAllFavorites.Name = "m_btnClearAllFavorites";
            this.m_btnClearAllFavorites.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_btnClearAllFavorites.ShowFocus = false;
            this.m_btnClearAllFavorites.Size = new System.Drawing.Size(134, 51);
            this.m_btnClearAllFavorites.TabIndex = 6;
            this.m_btnClearAllFavorites.Text = "Clear All\r\nFavorites";
            this.m_btnClearAllFavorites.UseVisualStyleBackColor = false;
            this.m_btnClearAllFavorites.Click += new System.EventHandler(this.m_btnClearAllFavorites_Click);
            // 
            // CBBFavoritesForm
            // 
            this.ClientSize = new System.Drawing.Size(793, 500);
            this.ControlBox = false;
            this.Controls.Add(this.m_btnClearAllFavorites);
            this.Controls.Add(this.m_btnClose);
            this.Controls.Add(this.m_btnPrint);
            this.Controls.Add(this.m_lblTitle);
            this.Controls.Add(this.m_btnDown);
            this.Controls.Add(this.m_btnUp);
            this.Controls.Add(this.m_clstFavorites);
            this.DrawAsGradient = true;
            this.DrawBorderOuterEdge = true;
            this.DrawRounded = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CBBFavoritesForm";
            this.OuterBorderEdgeColor = System.Drawing.Color.Black;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.CBBFavoritesForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ColorListBox m_clstFavorites;
        private Controls.ImageButton m_btnDown;
        private Controls.ImageButton m_btnUp;
        private System.Windows.Forms.Label m_lblTitle;
        private Controls.ImageButton m_btnPrint;
        private Controls.ImageButton m_btnClose;
        private Controls.ImageButton m_btnClearAllFavorites;
    }
}
