namespace GTI.Modules.PlayerCenter.UI
{
    partial class GeneralPlayerDrawingEventViewForm
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
            this.generalPlayerDrawingEventView1 = new GTI.Modules.PlayerCenter.UI.GeneralPlayerDrawingEventView();
            this.SuspendLayout();
            // 
            // generalPlayerDrawingEventView1
            // 
            this.generalPlayerDrawingEventView1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.generalPlayerDrawingEventView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalPlayerDrawingEventView1.Location = new System.Drawing.Point(0, 0);
            this.generalPlayerDrawingEventView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.generalPlayerDrawingEventView1.Name = "generalPlayerDrawingEventView1";
            this.generalPlayerDrawingEventView1.Size = new System.Drawing.Size(657, 704);
            this.generalPlayerDrawingEventView1.TabIndex = 0;
            // 
            // GeneralPlayerDrawingEventViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(657, 704);
            this.Controls.Add(this.generalPlayerDrawingEventView1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "GeneralPlayerDrawingEventViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "General Player Drawing Event";
            this.ResumeLayout(false);

        }

        #endregion

        private GeneralPlayerDrawingEventView generalPlayerDrawingEventView1;
    }
}