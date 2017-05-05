namespace GTI.Modules.PlayerCenter.UI
{
    partial class ReportForm
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
            this.m_reportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.m_menuStrip = new System.Windows.Forms.MenuStrip();
            this.m_closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_reportViewer
            // 
            this.m_reportViewer.ActiveViewIndex = -1;
            this.m_reportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_reportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_reportViewer.Location = new System.Drawing.Point(0, 30);
            this.m_reportViewer.Name = "m_reportViewer";
            this.m_reportViewer.SelectionFormula = "";
            this.m_reportViewer.ShowCloseButton = false;
            this.m_reportViewer.ShowGroupTreeButton = false;
            this.m_reportViewer.ShowParameterPanelButton = false;
            this.m_reportViewer.ShowRefreshButton = false;
            this.m_reportViewer.Size = new System.Drawing.Size(1018, 710);
            this.m_reportViewer.TabIndex = 0;
            this.m_reportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.m_reportViewer.ViewTimeSelectionFormula = "";
            // 
            // m_menuStrip
            // 
            this.m_menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(222)))), ((int)(((byte)(237)))));
            this.m_menuStrip.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.m_menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_closeMenuItem});
            this.m_menuStrip.Location = new System.Drawing.Point(0, 0);
            this.m_menuStrip.Name = "m_menuStrip";
            this.m_menuStrip.Size = new System.Drawing.Size(1018, 30);
            this.m_menuStrip.TabIndex = 1;
            // 
            // m_closeMenuItem
            // 
            this.m_closeMenuItem.Name = "m_closeMenuItem";
            this.m_closeMenuItem.Size = new System.Drawing.Size(62, 26);
            this.m_closeMenuItem.Text = "&Close";
            this.m_closeMenuItem.Click += new System.EventHandler(this.CloseClick);
            // 
            // ReportForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1018, 740);
            this.ControlBox = false;
            this.Controls.Add(this.m_reportViewer);
            this.Controls.Add(this.m_menuStrip);
            this.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.m_menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.Name = "ReportForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.m_menuStrip.ResumeLayout(false);
            this.m_menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer m_reportViewer;
        private System.Windows.Forms.MenuStrip m_menuStrip;
        private System.Windows.Forms.ToolStripMenuItem m_closeMenuItem;
    }
}