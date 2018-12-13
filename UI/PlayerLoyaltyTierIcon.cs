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
        int m_widthIconDistance = 10;
        int m_heightIconDistance = 2;
        List<string> files = new List<string>();
        int maxHeight = -1;
        private List<byte[]> m_lstbyteIconList = new List<byte[]>();

        #endregion

        #region CONSTRUCTOR
        public PlayerLoyaltyTierIcon()
        {
            InitializeComponent();
            DrawGradient = true;                 
            m_lstbyteIconList = GetPlayerTierIcon.Msg(13);
            PopulateTierIcon();
        }
        #endregion

        #region POPULATE ICON     
        
        private void PopulateTierIcon()
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


            foreach (byte[] data_ in m_lstbyteIconList)
            {
                MemoryStream mStream = new MemoryStream(data_);
                PictureBox pb = new PictureBox();
                Size _size = new Size(60, 60);
                pb.Size = _size;
                pb.Location = new Point(m_widthIconDistance, m_heightIconDistance);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Image = Image.FromStream(mStream);
                maxHeight = Math.Max(pb.Height, maxHeight);
                m_widthIconDistance += pb.Width + 10;
                if (m_widthIconDistance > this.ClientSize.Width - 60)
                {
                    m_widthIconDistance = 10;
                    m_heightIconDistance += maxHeight + 10;
                }

                m_pnlIconTier.Controls.Add(pb);
               
            }
        }    
        #endregion

  
        #region IMPORT IMAGE
        private void m_imgbtnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog  openFileDialog1= new OpenFileDialog();
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "JPG|*.jpg|JPEG|*.jpeg|GIF|*.gif|PNG|*.png";
         
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] _selectedImgIcon = openFileDialog1.FileNames;

                foreach (string _imgIcon in _selectedImgIcon)
                {
                    var pic = new PictureBox();
                    byte[] imageData;
                                   
                    Size _size = new Size(60, 60);
                    pic.Size = _size;
                    pic.Location = new Point(m_widthIconDistance, m_heightIconDistance);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Image = Image.FromFile(_imgIcon);

                    MemoryStream mStream = new MemoryStream();
                    pic.Image.Save(mStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    imageData = mStream.ToArray();   

                    m_widthIconDistance += pic.Width + 10;
                    maxHeight = Math.Max(pic.Height, maxHeight);

                    if (m_widthIconDistance > this.ClientSize.Width - 60)
                    {
                        m_widthIconDistance = 10;
                        m_heightIconDistance += maxHeight + 10;
                    }

                    m_pnlIconTier.Controls.Add(pic);
                    SetPlayerTierIcon.Msg(imageData);
                    m_lstbyteIconList.Add(imageData);
                }


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
         
            }
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


//#region HELPER
//private Color SetColor( string _hexColor)
//{
//    Color _color;
//    int argb = Int32.Parse(_hexColor.Replace("#", ""), NumberStyles.HexNumber);
//    _color = Color.FromArgb(argb);
//    return _color;
//}
//#endregion
