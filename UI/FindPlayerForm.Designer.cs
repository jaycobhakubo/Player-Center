namespace GTI.Modules.PlayerCenter.UI
{
    partial class FindPlayerForm
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
            if(disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindPlayerForm));
            this.m_virtualKeyboard = new GTI.Controls.VirtualKeyboard();
            this.m_firstName = new System.Windows.Forms.TextBox();
            this.m_lastName = new System.Windows.Forms.TextBox();
            this.m_searchButton = new GTI.Controls.ImageButton();
            this.m_resultsList = new GTI.Controls.ColorListBox();
            this.m_resultsListUp = new GTI.Controls.ImageButton();
            this.m_resultsListDown = new GTI.Controls.ImageButton();
            this.m_selectPlayerButton = new GTI.Controls.ImageButton();
            this.m_cancelButton = new GTI.Controls.ImageButton();
            this.m_searchByCardButton = new GTI.Controls.ImageButton();
            this.m_firstNameLabel = new System.Windows.Forms.Label();
            this.m_lastNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_virtualKeyboard
            // 
            this.m_virtualKeyboard.AltGrImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonUp;
            this.m_virtualKeyboard.AltGrImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonDown;
            this.m_virtualKeyboard.BackColor = System.Drawing.Color.Transparent;
            this.m_virtualKeyboard.BackspaceImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonUp;
            this.m_virtualKeyboard.BackspaceImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonDown;
            this.m_virtualKeyboard.ButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.m_virtualKeyboard.CapsLockImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonUp;
            this.m_virtualKeyboard.CapsLockImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonDown;
            this.m_virtualKeyboard.EnterImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonUp;
            this.m_virtualKeyboard.EnterImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonDown;
            resources.ApplyResources(this.m_virtualKeyboard, "m_virtualKeyboard");
            this.m_virtualKeyboard.KeyImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonUp;
            this.m_virtualKeyboard.KeyImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonDown;
            this.m_virtualKeyboard.Name = "m_virtualKeyboard";
            this.m_virtualKeyboard.ShiftImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonUp;
            this.m_virtualKeyboard.ShiftImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonDown;
            this.m_virtualKeyboard.ShowFocus = false;
            this.m_virtualKeyboard.SpaceImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonUp;
            this.m_virtualKeyboard.SpaceImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonDown;
            this.m_virtualKeyboard.TabPipeImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonUp;
            this.m_virtualKeyboard.TabPipeImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonDown;
            this.m_virtualKeyboard.TabStop = false;
            this.m_virtualKeyboard.KeyPressed += new GTI.Controls.KeyboardEventHandler(this.KeyboardKeyPressed);
            // 
            // m_firstName
            // 
            this.m_firstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(60)))), ((int)(((byte)(96)))));
            this.m_firstName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.m_firstName, "m_firstName");
            this.m_firstName.ForeColor = System.Drawing.Color.Yellow;
            this.m_firstName.Name = "m_firstName";
            this.m_firstName.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // m_lastName
            // 
            this.m_lastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(60)))), ((int)(((byte)(96)))));
            this.m_lastName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.m_lastName, "m_lastName");
            this.m_lastName.ForeColor = System.Drawing.Color.Yellow;
            this.m_lastName.Name = "m_lastName";
            this.m_lastName.Enter += new System.EventHandler(this.FocusChanged);
            // 
            // m_searchButton
            // 
            this.m_searchButton.BackColor = System.Drawing.Color.Transparent;
            this.m_searchButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_searchButton, "m_searchButton");
            this.m_searchButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("m_searchButton.ImageNormal")));
            this.m_searchButton.ImagePressed = ((System.Drawing.Image)(resources.GetObject("m_searchButton.ImagePressed")));
            this.m_searchButton.Name = "m_searchButton";
            this.m_searchButton.RepeatRate = 150;
            this.m_searchButton.RepeatWhenHeldFor = 750;
            this.m_searchButton.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_searchButton.ShowFocus = false;
            this.m_searchButton.TabStop = false;
            this.m_searchButton.UseVisualStyleBackColor = false;
            this.m_searchButton.Click += new System.EventHandler(this.SearchClick);
            // 
            // m_resultsList
            // 
            this.m_resultsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(53)))));
            this.m_resultsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_resultsList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            resources.ApplyResources(this.m_resultsList, "m_resultsList");
            this.m_resultsList.ForeColor = System.Drawing.Color.White;
            this.m_resultsList.FormattingEnabled = true;
            this.m_resultsList.HighlightColor = System.Drawing.Color.ForestGreen;
            this.m_resultsList.ImageList = null;
            this.m_resultsList.Name = "m_resultsList";
            this.m_resultsList.SuppressVerticalScroll = true;
            this.m_resultsList.TabStop = false;
            this.m_resultsList.TopIndexForScroll = 0;
            // 
            // m_resultsListUp
            // 
            this.m_resultsListUp.BackColor = System.Drawing.Color.Transparent;
            this.m_resultsListUp.FocusColor = System.Drawing.Color.Black;
            this.m_resultsListUp.ImageIcon = global::GTI.Modules.PlayerCenter.Properties.Resources.ArrowUp;
            this.m_resultsListUp.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonUp;
            this.m_resultsListUp.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonDown;
            resources.ApplyResources(this.m_resultsListUp, "m_resultsListUp");
            this.m_resultsListUp.Name = "m_resultsListUp";
            this.m_resultsListUp.RepeatingIfHeld = true;
            this.m_resultsListUp.RepeatRate = 150;
            this.m_resultsListUp.RepeatWhenHeldFor = 750;
            this.m_resultsListUp.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_resultsListUp.ShowFocus = false;
            this.m_resultsListUp.TabStop = false;
            this.m_resultsListUp.UseVisualStyleBackColor = false;
            this.m_resultsListUp.Click += new System.EventHandler(this.ResultsListUpClick);
            // 
            // m_resultsListDown
            // 
            this.m_resultsListDown.BackColor = System.Drawing.Color.Transparent;
            this.m_resultsListDown.FocusColor = System.Drawing.Color.Black;
            this.m_resultsListDown.ImageIcon = global::GTI.Modules.PlayerCenter.Properties.Resources.ArrowDown;
            this.m_resultsListDown.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonUp;
            this.m_resultsListDown.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.TouchBlueButtonDown;
            resources.ApplyResources(this.m_resultsListDown, "m_resultsListDown");
            this.m_resultsListDown.Name = "m_resultsListDown";
            this.m_resultsListDown.RepeatingIfHeld = true;
            this.m_resultsListDown.RepeatRate = 150;
            this.m_resultsListDown.RepeatWhenHeldFor = 750;
            this.m_resultsListDown.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_resultsListDown.ShowFocus = false;
            this.m_resultsListDown.TabStop = false;
            this.m_resultsListDown.UseVisualStyleBackColor = false;
            this.m_resultsListDown.Click += new System.EventHandler(this.ResultsListDownClick);
            // 
            // m_selectPlayerButton
            // 
            this.m_selectPlayerButton.BackColor = System.Drawing.Color.Transparent;
            this.m_selectPlayerButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_selectPlayerButton, "m_selectPlayerButton");
            this.m_selectPlayerButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("m_selectPlayerButton.ImageNormal")));
            this.m_selectPlayerButton.ImagePressed = ((System.Drawing.Image)(resources.GetObject("m_selectPlayerButton.ImagePressed")));
            this.m_selectPlayerButton.Name = "m_selectPlayerButton";
            this.m_selectPlayerButton.RepeatRate = 150;
            this.m_selectPlayerButton.RepeatWhenHeldFor = 750;
            this.m_selectPlayerButton.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_selectPlayerButton.ShowFocus = false;
            this.m_selectPlayerButton.TabStop = false;
            this.m_selectPlayerButton.UseVisualStyleBackColor = false;
            this.m_selectPlayerButton.Click += new System.EventHandler(this.SelectPlayerClick);
            // 
            // m_cancelButton
            // 
            this.m_cancelButton.BackColor = System.Drawing.Color.Transparent;
            this.m_cancelButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_cancelButton, "m_cancelButton");
            this.m_cancelButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("m_cancelButton.ImageNormal")));
            this.m_cancelButton.ImagePressed = ((System.Drawing.Image)(resources.GetObject("m_cancelButton.ImagePressed")));
            this.m_cancelButton.Name = "m_cancelButton";
            this.m_cancelButton.RepeatRate = 150;
            this.m_cancelButton.RepeatWhenHeldFor = 750;
            this.m_cancelButton.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_cancelButton.ShowFocus = false;
            this.m_cancelButton.TabStop = false;
            this.m_cancelButton.UseVisualStyleBackColor = false;
            this.m_cancelButton.Click += new System.EventHandler(this.CancelClick);
            // 
            // m_searchByCardButton
            // 
            this.m_searchByCardButton.BackColor = System.Drawing.Color.Transparent;
            this.m_searchByCardButton.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.m_searchByCardButton, "m_searchByCardButton");
            this.m_searchByCardButton.ImageNormal = ((System.Drawing.Image)(resources.GetObject("m_searchByCardButton.ImageNormal")));
            this.m_searchByCardButton.ImagePressed = ((System.Drawing.Image)(resources.GetObject("m_searchByCardButton.ImagePressed")));
            this.m_searchByCardButton.Name = "m_searchByCardButton";
            this.m_searchByCardButton.RepeatRate = 150;
            this.m_searchByCardButton.RepeatWhenHeldFor = 750;
            this.m_searchByCardButton.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.m_searchByCardButton.ShowFocus = false;
            this.m_searchByCardButton.TabStop = false;
            this.m_searchByCardButton.UseVisualStyleBackColor = false;
            this.m_searchByCardButton.Click += new System.EventHandler(this.SearchByCardClick);
            // 
            // m_firstNameLabel
            // 
            this.m_firstNameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(120)))), ((int)(((byte)(124)))));
            resources.ApplyResources(this.m_firstNameLabel, "m_firstNameLabel");
            this.m_firstNameLabel.ForeColor = System.Drawing.Color.White;
            this.m_firstNameLabel.Name = "m_firstNameLabel";
            // 
            // m_lastNameLabel
            // 
            this.m_lastNameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(120)))), ((int)(((byte)(124)))));
            resources.ApplyResources(this.m_lastNameLabel, "m_lastNameLabel");
            this.m_lastNameLabel.ForeColor = System.Drawing.Color.White;
            this.m_lastNameLabel.Name = "m_lastNameLabel";
            // 
            // FindPlayerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::GTI.Modules.PlayerCenter.Properties.Resources.FindPlayerBack800;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.m_lastNameLabel);
            this.Controls.Add(this.m_firstNameLabel);
            this.Controls.Add(this.m_searchByCardButton);
            this.Controls.Add(this.m_cancelButton);
            this.Controls.Add(this.m_selectPlayerButton);
            this.Controls.Add(this.m_resultsListDown);
            this.Controls.Add(this.m_resultsListUp);
            this.Controls.Add(this.m_resultsList);
            this.Controls.Add(this.m_searchButton);
            this.Controls.Add(this.m_lastName);
            this.Controls.Add(this.m_firstName);
            this.Controls.Add(this.m_virtualKeyboard);
            this.DrawBorderOuterEdge = true;
            this.DrawRounded = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FindPlayerForm";
            this.OuterBorderEdgeColor = System.Drawing.Color.DimGray;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GTI.Controls.VirtualKeyboard m_virtualKeyboard;
        private System.Windows.Forms.TextBox m_firstName;
        private System.Windows.Forms.TextBox m_lastName;
        private GTI.Controls.ImageButton m_searchButton;
        private GTI.Controls.ColorListBox m_resultsList;
        private GTI.Controls.ImageButton m_resultsListUp;
        private GTI.Controls.ImageButton m_resultsListDown;
        private GTI.Controls.ImageButton m_selectPlayerButton;
        private GTI.Controls.ImageButton m_cancelButton;
        private GTI.Controls.ImageButton m_searchByCardButton;
        private System.Windows.Forms.Label m_firstNameLabel;
        private System.Windows.Forms.Label m_lastNameLabel;
    }
}