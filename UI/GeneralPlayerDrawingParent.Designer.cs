namespace GTI.Modules.PlayerCenter.UI
{
    partial class GeneralPlayerDrawingParent
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
            this.tc_PlayerDrawing = new System.Windows.Forms.TabControl();
            this.tp_PlayerDrawing = new System.Windows.Forms.TabPage();
            this.tp_PlayerDrawingSetup = new System.Windows.Forms.TabPage();
            this.tc_PlayerDrawing.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc_PlayerDrawing
            // 
            this.tc_PlayerDrawing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tc_PlayerDrawing.Controls.Add(this.tp_PlayerDrawing);
            this.tc_PlayerDrawing.Controls.Add(this.tp_PlayerDrawingSetup);
            this.tc_PlayerDrawing.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.tc_PlayerDrawing.Location = new System.Drawing.Point(0, 0);
            this.tc_PlayerDrawing.Name = "tc_PlayerDrawing";
            this.tc_PlayerDrawing.SelectedIndex = 0;
            this.tc_PlayerDrawing.Size = new System.Drawing.Size(1018, 678);
            this.tc_PlayerDrawing.TabIndex = 1;
            this.tc_PlayerDrawing.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tp_PlayerDrawing
            // 
            this.tp_PlayerDrawing.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tp_PlayerDrawing.Location = new System.Drawing.Point(4, 31);
            this.tp_PlayerDrawing.Name = "tp_PlayerDrawing";
            this.tp_PlayerDrawing.Padding = new System.Windows.Forms.Padding(3);
            this.tp_PlayerDrawing.Size = new System.Drawing.Size(1010, 643);
            this.tp_PlayerDrawing.TabIndex = 0;
            this.tp_PlayerDrawing.Text = "Drawing";
            // 
            // tp_PlayerDrawingSetup
            // 
            this.tp_PlayerDrawingSetup.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tp_PlayerDrawingSetup.Location = new System.Drawing.Point(4, 31);
            this.tp_PlayerDrawingSetup.Name = "tp_PlayerDrawingSetup";
            this.tp_PlayerDrawingSetup.Padding = new System.Windows.Forms.Padding(3);
            this.tp_PlayerDrawingSetup.Size = new System.Drawing.Size(1005, 643);
            this.tp_PlayerDrawingSetup.TabIndex = 1;
            this.tp_PlayerDrawingSetup.Text = "Setup";
            // 
            // GeneralPlayerDrawingParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 678);
            this.Controls.Add(this.tc_PlayerDrawing);
            this.IsMdiContainer = true;
            this.Name = "GeneralPlayerDrawingParent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Player Drawing";
            this.tc_PlayerDrawing.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tc_PlayerDrawing;
        private System.Windows.Forms.TabPage tp_PlayerDrawing;
        private System.Windows.Forms.TabPage tp_PlayerDrawingSetup;
    }
}