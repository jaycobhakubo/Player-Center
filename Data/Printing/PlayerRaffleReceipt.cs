using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTech.Elite.Reports;
using System.Windows.Documents;
using System.IO;
using System.Windows.Controls;
using IDAutomation.NetAssembly;

namespace GTI.Modules.PlayerCenter.Data.Printing
{
    /// <summary>
    /// Represents a player's raffle ticket
    /// </summary>
    public class PlayerRaffleReceipt : Receipt
    {
        #region Constants

        /// <summary>
        /// The font size used when printing barcode.
        ///   Note: This is what the sales receipt uses.
        /// </summary>
        protected const double BARCODE_FONT_SIZE = 20;

        #endregion

        #region Private Members

        private string m_raffleName;
        private PlayerExportItem m_player;
        private bool m_printBarcode = true;
        //protected BarcodeGenerator128 m_barcodeGen = new BarcodeGenerator128(); // special barcode generator

        #endregion

        #region Public Properties

        /// <summary>
        /// The name of the raffle being run
        /// </summary>
        public string RaffleName
        {
            get { return m_raffleName; }
            set { m_raffleName = value; }
        }
        /// <summary>
        /// the player to print
        /// </summary>
        public PlayerExportItem Player
        {
            get { return m_player; }
            set
            {
                m_player = value;
            }
        }
        /// <summary>
        /// Whether or not to print the player's card as a barcode
        /// </summary>
        public bool PrintBarcode
        {
            get { return m_printBarcode; }
            set
            {
                m_printBarcode = value;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of the player raffle receipt
        /// </summary>
        /// <param name="player"></param>
        public PlayerRaffleReceipt(PlayerExportItem player, string raffleName = null)
        {
            m_raffleName = raffleName;
            m_player = player;
        }

        #endregion

        #region Printing Methods

        /// <summary>
        /// Prepares the receipt's header.
        /// </summary>
        protected override void PrintHeader() { } // no header

        /// <summary>
        /// Prepares the receipt's body.
        /// </summary>
        protected override void PrintBody()
        {
            Table playerRaffleInfo = new Table();
            playerRaffleInfo.RowGroups.Add(new TableRowGroup());
            TableRow row;
            TableCell cell;
            
            // Add the player name
            row = new TableRow();
            row.FontSize = FontBig;
            row.FontWeight = FontWeightBig;
            cell = new TableCell();
            cell.Blocks.Add(new Paragraph(new Run(m_player.Player.FirstName + " " + m_player.Player.LastName)));
            row.Cells.Add(cell);
            playerRaffleInfo.RowGroups[0].Rows.Add(row);

            // Add the player card
            if (m_printBarcode && !String.IsNullOrWhiteSpace(m_player.Player.MagneticCardNumber))
            {
                row = new TableRow();
                row.FontSize = BARCODE_FONT_SIZE;
                row.FontFamily = new System.Windows.Media.FontFamily(GTI.Modules.Shared.BarcodeHelper.SmallFontName);
                cell = new TableCell();
                FontEncoder fontEncoder = new FontEncoder();
                cell.Blocks.Add(new Paragraph(new Run(fontEncoder.Code128(m_player.Player.MagneticCardNumber))));
                row.Cells.Add(cell);
                playerRaffleInfo.RowGroups[0].Rows.Add(row);
            }
            row = new TableRow();
            row.FontSize = FontBig;
            cell = new TableCell();
            cell.Blocks.Add(new Paragraph(new Run(m_player.Player.MagneticCardNumber)));
            row.Cells.Add(cell);
            playerRaffleInfo.RowGroups[0].Rows.Add(row);
            
            // Raffle name
            if (!String.IsNullOrWhiteSpace(m_raffleName))
            {
                row = new TableRow();
                row.FontSize = FontSmall;
                cell = new TableCell();
                cell.Blocks.Add(new Paragraph(new Run(
                    String.Format("Raffle: {0}", m_raffleName)
                    )));
                row.Cells.Add(cell);
                playerRaffleInfo.RowGroups[0].Rows.Add(row);
            }

            // Put the print time on it
            row = new TableRow();
            row.FontSize = FontSmall;
            cell = new TableCell();
            cell.Blocks.Add(new Paragraph(new Run(
                String.Format("Printed: {0}", DateTime.Now.ToString())
                )));
            row.Cells.Add(cell);
            playerRaffleInfo.RowGroups[0].Rows.Add(row);

            // Add everything to the main flow document
            FlowDoc.Blocks.Add(playerRaffleInfo);
        }
        
        /// <summary>
        /// Prepares the receipt's footer.
        /// </summary>
        protected override void PrintFooter() { } // no footer
        #endregion

        #region Helper Methods

        /// <summary>
        /// prints the receipt id barcode to the receipt
        /// </summary>
        /// <param name="paragraph"></param>
        /// <param name="number">the number to be printed</param>
        /// <param name="identifier">the identifier to appear next to the number</param>
        protected void AddBarcode(Paragraph paragraph, string strToPrint, string identifier)
        {
            try //convert the winforms bitmap to wpf bitmap
            {
                //System.Drawing.Bitmap bitmap = m_barcodeGen.DrawBarcode(strToPrint.PadLeft(13, '0'));
                //MemoryStream ms = new MemoryStream();
                //bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                //System.Windows.Media.Imaging.BitmapImage bImg = new System.Windows.Media.Imaging.BitmapImage();
                //bImg.BeginInit();
                //bImg.StreamSource = new MemoryStream(ms.ToArray());
                //bImg.EndInit();

                //Image brush = new Image(); // note: this requires an STA thread
                //brush.Source = bImg;
                //paragraph.Inlines.Add(brush);
                //if (brush.Width > 400 || brush.Width == 0)
                //    brush.Width = 400;
                //paragraph.Inlines.Add(new LineBreak());
                //paragraph.Inlines.Add(new LineBreak());
                //if (!String.IsNullOrWhiteSpace(identifier))
                //{
                //    paragraph.Inlines.Add(new Run(String.Format(identifier, strToPrint)));
                //    paragraph.Inlines.Add(new LineBreak());
                //    paragraph.Inlines.Add(new LineBreak());
                //}
            }
            catch { }
        }
        #endregion
    }
}
