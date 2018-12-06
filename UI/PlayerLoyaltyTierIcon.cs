using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GTI.Modules.Shared;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace GTI.Modules.PlayerCenter.UI
{
    public partial class PlayerLoyaltyTierIcon : GradientForm//EliteGradientForm
    {
        #region Member Variables
         //imageList1.ImageSize = new System.Drawing.Size(16, 16);
         //   imageList1.TransparentColor = System.Drawing.Color.Transparent;
        private int currentImage = 0;
        protected Graphics myGraphics;
        #endregion

        #region CONSTRUCTOR
        public PlayerLoyaltyTierIcon()
        {
            InitializeComponent();
            DrawGradient = true;          
            imageList1.ImageSize = new Size(255, 255);
            imageList1.TransparentColor = Color.White;
            myGraphics = Graphics.FromHwnd(groupBox1.Handle);
          //  LoadPictureBoxTest();
	
        
        }
        #endregion

        #region POPULATE ICON
        private void LoadPictureBoxTest()
        {
            //pictureBox1.Image = Image.FromFile("C:\\Users\\Administrator\\Downloads\\icon\\1.png");
            //pictureBox2.Image = Image.FromFile("C:\\Users\\Administrator\\Downloads\\icon\\2.jpg");
            //pictureBox3.Image = Image.FromFile("C:\\Users\\Administrator\\Downloads\\icon\\3.jpg");
            //pictureBox4.Image = Image.FromFile("C:\\Users\\Administrator\\Downloads\\icon\\4.jpg");
        }
        #endregion


        #region HELPER
        private Color SetColor( string _hexColor)
        {
            Color _color;
            int argb = Int32.Parse(_hexColor.Replace("#", ""), NumberStyles.HexNumber);
            _color = Color.FromArgb(argb);
            return _color;
        }
        #endregion

    

        private void addImage(string imageToLoad)
        {
            if (imageToLoad != "")
            {
                imageList1.Images.Add(Image.FromFile(imageToLoad));              
            }
        }

        private void showImage()
        {
            if (imageList1.Images.Empty != true)
            {
                if (imageList1.Images.Count - 1 > currentImage)
                {
                    currentImage++;
                }
                else
                {
                    currentImage = 0;
                }

                imageList1.Draw(myGraphics, 5, 5, currentImage);
                pictureBox1.Image = imageList1.Images[currentImage];
            }
        }

        private void imageButton4_Click(object sender, EventArgs e)
        {
                     
        }


        private void m_imgbtnImport_Click(object sender, EventArgs e)
        {
          OpenFileDialog  openFileDialog1= new OpenFileDialog();
             openFileDialog1.Multiselect = true;
             openFileDialog1.Filter = "JPG|*.jpg|JPEG|*.jpeg|GIF|*.gif|PNG|*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] files = openFileDialog1.FileNames;
                int x_ = 20;
                int y_ = 20;
                int maxHeight = -1;

                foreach (string img in files)
                {
                    PictureBox pic = new PictureBox();
                    pic.Image = Image.FromFile(img);
                    pic.Location = new Point(x_, y_);
                    x_ += pic.Width + 10;
                    maxHeight = Math.Max(pic.Height, maxHeight);
                    if (x_ > this.ClientSize.Width - 100)
                    {
                        x_ = 20;
                        y_ += maxHeight + 10;
                    }
                    groupBox1.Controls.Add(pic);
                }
            }



            //Sol. B using Drawing
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    if (openFileDialog1.FileNames != null)
            //    {
            //        for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
            //        {
            //            addImage(openFileDialog1.FileNames[i]);
            //        }
            //    }
            //    else
            //        addImage(openFileDialog1.FileName);
            //}
            //showImage();
        }
    }
}
