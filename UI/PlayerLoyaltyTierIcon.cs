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
using GTI.Modules.PlayerCenter.Data;
using System.IO;

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
            LoadIcontTest();
            PopulateTierIcon();
        }
        #endregion

        #region POPULATE ICON

        private List<byte[]> m_lstbyteIconList = new List<byte[]>();
        
        private void PopulateTierIcon()
        {
            foreach (byte[] data_ in m_lstbyteIconList)
            {

                MemoryStream mStream = new MemoryStream(data_);
                PictureBox pb = new PictureBox();
                Size _size = new Size(60, 60);
                pb.Size = _size;
                pb.Location = new Point(_widthDistance, _heightDistance);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Image = Image.FromStream(mStream);
                m_pnlIconTier.Controls.Add(pb);
                _widthDistance += pb.Width + 10;
            }
        }


        private void LoadIcontTest()
        {
            m_lstbyteIconList = GetPlayerTierIcon.Msg(13);
        }


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


        private void ReLoadUI()
        {

        }


        //private void addImage(string imageToLoad)
        //{
        //    if (imageToLoad != "")
        //    {
        //        imageList1.Images.Add(Image.FromFile(imageToLoad));              
        //    }
        //}

        //private void showImage()
        //{
        //    if (imageList1.Images.Empty != true)
        //    {
        //        if (imageList1.Images.Count - 1 > currentImage)
        //        {
        //            currentImage++;
        //        }
        //        else
        //        {
        //            currentImage = 0;
        //        }

        //        imageList1.Draw(myGraphics, 5, 5, currentImage);
        //       // pictureBox1.Image = imageList1.Images[currentImage];
        //    }
        //}

        private void imageButton4_Click(object sender, EventArgs e)
        {
                     
        }
        /*x*/
        int _widthDistance = 10;
        /*y*/
        int _heightDistance = 2;
        List<string> files = new List<string>();
        int maxHeight = -1;


        #region IMPORT
        private void m_imgbtnImport_Click(object sender, EventArgs e)
        {
            //Varx = getCurrentIconTier();
            OpenFileDialog  openFileDialog1= new OpenFileDialog();
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "JPG|*.jpg|JPEG|*.jpeg|GIF|*.gif|PNG|*.png";
         

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string[] TestFiles = openFileDialog1.FileNames;

                PictureBox pic = new PictureBox();
                foreach(string img in TestFiles)
                {
                    byte[] imageData;
                    pic.Image = Image.FromFile(img);
                    MemoryStream mStream = new MemoryStream();
                    pic.Image.Save(mStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    imageData = mStream.ToArray();   
                    Size _size = new Size(60, 60);
                    pic.Size = _size;
                    pic.Image = Image.FromStream(mStream);
                    //pic.Image = Image.FromFile(img);
                    pic.Location = new Point(_widthDistance, _heightDistance);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    _widthDistance += pic.Width + 10;
                    maxHeight = Math.Max(pic.Height, maxHeight);
                    if (_widthDistance > this.ClientSize.Width - 60)
                    {
                        _widthDistance = 10;
                        _heightDistance += maxHeight + 10;
                    }
                    m_pnlIconTier.Controls.Add(pic);

                    SetPlayerTierIcon.Msg(imageData);
                    m_lstbyteIconList.Add(imageData);
                }

                if (TestFiles.Count() > 0)
                {
                    if (m_lstbyteIconList.Count() > 20)
                    {
                        Size _size = new Size(383, 301);
                        groupBox1.Size = _size;
                        groupBox1.Location = new Point(5, 3);
                        _size = new Size(377, 282);
                        m_pnlIconTier.Size = _size;
                    }
                    else
                    {
                        Size _size = new Size(366, 301);
                        groupBox1.Size = _size;
                        groupBox1.Location = new Point(15, 3);
                        _size = new Size(360, 282);
                        m_pnlIconTier.Size = _size;
                    }

                    //foreach (string img in files)
                    //{
                    //    PictureBox pic = new PictureBox();
                    //    pic.Click += new EventHandler(pictureBox1_Click);
                    //    Size _size = new Size(60, 60);
                    //    pic.Size = _size;
                    //    pic.Image = Image.FromFile(img);
                    //    pic.Location = new Point(_widthDistance, _heightDistance);
                    //    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    //    _widthDistance += pic.Width + 10;
                    //    maxHeight = Math.Max(pic.Height, maxHeight);
                    //    if (_widthDistance > this.ClientSize.Width - 60)
                    //    {
                    //        _widthDistance = 10;
                    //        _heightDistance += maxHeight + 10;
                    //    }
                    //    m_pnlIconTier.Controls.Add(pic);
                    //}
                }
                
                //files = openFileDialog1.FileNames.ToList();
               // foreach (string x in openFileDialog1.FileNames)
               // {
               //     files.Add(x);
               // }

               // // m_files = files;
               //// var count = m_files.Count();
           
               // int maxHeight = -1;

               // if (files.Count() > 20)
               // {
               //     Size _size = new Size(383, 301);
               //     groupBox1.Size = _size;
               //     groupBox1.Location = new Point(5, 3);
               //     _size = new Size(377, 282);
               //     m_pnlIconTier.Size = _size;
               // }
               // else
               // {
               //     Size _size = new Size(366, 301);
               //     groupBox1.Size = _size;
               //     groupBox1.Location = new Point(15, 3);
               //     _size = new Size(360, 282);
               //     m_pnlIconTier.Size = _size;
               // }

              
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

        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox pctbx = (PictureBox)sender;
           
        }

        private void imgbtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
