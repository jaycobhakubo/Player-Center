using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GTI.Modules.Shared.Data;
using GTI.Modules.Shared;

namespace GTI.Modules.Shared
{
    internal partial class CBBFavoritesForm : GTI.Modules.Shared.EliteGradientForm
    {
        private Player m_player;
        private string m_printerName;

        public CBBFavoritesForm(Player player, string printerName, bool allowClear = true):base()
        {
            InitializeComponent();

            m_player = player;
            m_printerName = printerName;

            if (!allowClear)
                m_btnClearAllFavorites.Visible = false;
        }

        private void CBBFavoritesForm_Load(object sender, EventArgs e)
        {
            if (m_player.CBBFavoriteNumbers.Count == 0)
            {
                m_clstFavorites.Items.Add("No favorites");
                m_btnClearAllFavorites.Enabled = false;
                m_btnPrint.Enabled = false;
            }
            else
            {
                m_clstFavorites.Items.AddRange(GenerateList(16).ToArray());
            }
        }

        private List<string> GenerateList(int splitAt)
        {
            List<string> ourText = new List<string>();
            int picks = 0;
            int favCnt = 0;

            foreach (string s in m_player.CBBFavoriteNumbers)
            {
                byte[] numbers = CBBUniqueItem.NumbersFromString(s);

                if (numbers.Length != picks)
                {
                    picks = numbers.Length;
                    favCnt = 0;
                    ourText.Add("Pick " + picks.ToString());
                }

                StringBuilder formattedNumbers = new StringBuilder((++favCnt).ToString().PadLeft(5) + ":  ");
                int cnt = 0;

                foreach (byte b in numbers)
                {
                    if (++cnt == splitAt + 1) //need to split lines
                    {
                        cnt = 0;
                        ourText.Add(formattedNumbers.ToString());
                        formattedNumbers.Clear();
                        formattedNumbers.Append(((b.ToString() + ",").PadLeft(12)));
                    }
                    else
                    {
                        formattedNumbers.Append((b.ToString() + ",").PadLeft(4));
                    }
                }

                formattedNumbers.Length--;

                ourText.Add(formattedNumbers.ToString());
            }

            return ourText;
        }

        private void m_btnUp_Click(object sender, EventArgs e)
        {
            m_clstFavorites.Up();
        }

        private void m_btnDown_Click(object sender, EventArgs e)
        {
            m_clstFavorites.Down();
        }

        private void m_btnPrint_Click(object sender, EventArgs e)
        {
            Printer printer = new Printer(m_printerName);

            printer.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);

            Font ourFont;
            
            if(printer.Using58mmPaper)
                ourFont = new Font("Lucida Console", 7F, FontStyle.Bold);
            else
                ourFont = new Font("Lucida Console", 9F, FontStyle.Bold);

            printer.AddLine("Crystal Ball Favorites", StringAlignment.Center, ourFont);
            printer.AddLine("for", StringAlignment.Center, ourFont);
            printer.AddLine(m_player.FirstName + " " + (!string.IsNullOrEmpty(m_player.MiddleInitial) ? m_player.MiddleInitial[0] + ". " : "") + m_player.LastName, StringAlignment.Center, ourFont);
            printer.AddLine(" ", StringAlignment.Center, ourFont);

            List<string> text = GenerateList(6);

            foreach(string s in text)
                printer.AddLine(s, StringAlignment.Near, ourFont);

            printer.AddLine(" ", StringAlignment.Center, ourFont);
            printer.AddLine(" ", StringAlignment.Center, ourFont);
            printer.AddLine(DateTime.Now.ToShortDateString() + "  " + DateTime.Now.ToShortTimeString(), StringAlignment.Center, ourFont);
            printer.AddLine(" ", StringAlignment.Center, ourFont);
            printer.AddLine(" ", StringAlignment.Center, ourFont);

            printer.Print();
        }

        private void m_btnClearAllFavorites_Click(object sender, EventArgs e)
        {
            if (MessageForm.Show("Are you sure you want to delete all of this player's favorites?", "Clear Favorites", MessageFormTypes.YesNo_DefNO) == System.Windows.Forms.DialogResult.Yes)
            {
                m_player.UpdateCBBFavoriteInfo(true);
                m_clstFavorites.Items.Clear();
                m_clstFavorites.Items.Add("No favorites");
                m_btnClearAllFavorites.Enabled = false;
                m_btnPrint.Enabled = false;
            }
        }
    }
}
