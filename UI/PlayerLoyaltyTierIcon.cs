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
        //protected Graphics myGraphics;
        #endregion


        public PlayerLoyaltyTierIcon()
        {
            InitializeComponent();
            DrawGradient = true;
            //GradientBeginColor = SetColor("#FF0A223C");
            //GradientEndColor = SetColor("#FF5072A0");
            //imageList1.ImageSize = new System.Drawing.Size(16, 16);
            //imageList1.TransparentColor = System.Drawing.Color.Transparent;

            //imageList1.ImageSize = new Size(255, 255);
            //imageList1.TransparentColor = Color.White;

            // Assigns the graphics object to use in the draw options.
        //    myGraphics = Graphics.FromHwnd(splitContainer1.Panel1.Handle);
            LoadPictureBoxTest();
	
        
        }


        private void LoadPictureBoxTest()
        {
            //pictureBox1.Image = Image.FromFile("C:\\Users\\Administrator\\Downloads\\icon\\1.png");
            //pictureBox2.Image = Image.FromFile("C:\\Users\\Administrator\\Downloads\\icon\\2.jpg");
            //pictureBox3.Image = Image.FromFile("C:\\Users\\Administrator\\Downloads\\icon\\3.jpg");
            //pictureBox4.Image = Image.FromFile("C:\\Users\\Administrator\\Downloads\\icon\\4.jpg");
        }

        private Color SetColor( string _hexColor)
        {
            Color _color;
            //var t_hexColor = "#FF0A223C";
            int argb = Int32.Parse(_hexColor.Replace("#", ""), NumberStyles.HexNumber);
            _color = Color.FromArgb(argb);
            return _color;
        }

        //#endregion

        //#region Member Properties
        ///// <summary>
        ///// Gets or sets whether to draw the gradient background.
        ///// </summary>
        //[Description("Whether to draw the gradient background.")]
        //[Category("Appearance")]
        //[DefaultValue(true)]
        //public bool DrawGradient
        //{
        //    get
        //    {
        //        return m_drawGradient;
        //    }
        //    set
        //    {
        //        m_drawGradient = value;
        //        Invalidate();
        //    }
        //}

        private void imageButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
               openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileNames != null)
                {
                    for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                    {
                        addImage(openFileDialog1.FileNames[i]);
                    }
                }
                else
                    addImage(openFileDialog1.FileName);
            }
        }

        private void addImage(string imageToLoad)
        {
            if (imageToLoad != "")
            {
                imageList1.Images.Add(Image.FromFile(imageToLoad));
                //listBox1.BeginUpdate();
                //listBox1.Items.Add(imageToLoad);
                //listBox1.EndUpdate();
            }
        }

        private void imageButton4_Click(object sender, EventArgs e)
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
  

                // Draw the image in the panel.
               // imageList1.Draw(myGraphics, 10, 10, currentImage);

                // Show the image in the PictureBox.
                //pictureBox1.Image = imageList1.Images[currentImage];
                //label3.Text = "Current image is " + currentImage;
                //listBox1.SelectedIndex = currentImage;
                //label5.Text = "Image is " + listBox1.Text;
            }
        }

        ///// <summary>
        ///// Gets or sets the background gradient's mode.
        ///// </summary>
        //[Description("The background gradient's mode.")]
        //[Category("Appearance")]
        //[DefaultValue(LinearGradientMode.Vertical)]
        //public LinearGradientMode GradientMode
        //{
        //    get
        //    {
        //        return m_gradientMode;
        //    }
        //    set
        //    {
        //        m_gradientMode = value;
        //        Invalidate();
        //    }
        //}

        ///// <summary>
        ///// Gets or sets the gradient's start color.
        ///// </summary>
        //[Description("The background gradient's start color.")]
        //[Category("Appearance")]
        //public Color GradientBeginColor
        //{
        //    get
        //    {
        //        return m_beginColor;
        //    }
        //    set
        //    {
        //        m_beginColor = value;
        //        Invalidate();
        //    }
        //}

        ///// <summary>
        ///// Gets or sets the gradient's end color.
        ///// </summary>
        //[Description("The background gradient's end color.")]
        //[Category("Appearance")]
        //public Color GradientEndColor
        //{
        //    get
        //    {
        //        return m_endColor;
        //    }
        //    set
        //    {
        //        m_endColor = value;
        //        Invalidate();
        //    }
        //}
    }
}
