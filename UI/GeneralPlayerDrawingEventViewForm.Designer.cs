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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.imgBtnClose = new GTI.Controls.ImageButton();
            this.generalPlayerDrawingEventView1 = new GTI.Modules.PlayerCenter.UI.GeneralPlayerDrawingEventView();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.generalPlayerDrawingEventView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.imgBtnClose, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.55952F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.440476F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(704, 672);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // imgBtnClose
            // 
            this.imgBtnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.imgBtnClose.FocusColor = System.Drawing.Color.Black;
            this.imgBtnClose.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.imgBtnClose.ImageNormal = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonUp;
            this.imgBtnClose.ImagePressed = global::GTI.Modules.PlayerCenter.Properties.Resources.BlueButtonDown;
            this.imgBtnClose.Location = new System.Drawing.Point(600, 625);
            this.imgBtnClose.Margin = new System.Windows.Forms.Padding(3, 3, 12, 8);
            this.imgBtnClose.MinimumSize = new System.Drawing.Size(30, 30);
            this.imgBtnClose.Name = "imgBtnClose";
            this.imgBtnClose.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.imgBtnClose.Size = new System.Drawing.Size(92, 39);
            this.imgBtnClose.TabIndex = 43;
            this.imgBtnClose.Text = "Close";
            this.imgBtnClose.Click += new System.EventHandler(this.imgBtnClose_Click);
            // 
            // generalPlayerDrawingEventView1
            // 
            this.generalPlayerDrawingEventView1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.generalPlayerDrawingEventView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalPlayerDrawingEventView1.Location = new System.Drawing.Point(4, 5);
            this.generalPlayerDrawingEventView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 2);
            this.generalPlayerDrawingEventView1.Name = "generalPlayerDrawingEventView1";
            this.generalPlayerDrawingEventView1.Size = new System.Drawing.Size(696, 615);
            this.generalPlayerDrawingEventView1.TabIndex = 0;
            // 
            // GeneralPlayerDrawingEventViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(704, 672);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "GeneralPlayerDrawingEventViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "General Player Drawing Event";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GeneralPlayerDrawingEventView generalPlayerDrawingEventView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Controls.ImageButton imgBtnClose;
    }
}