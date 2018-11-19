using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GTI.Modules.PlayerCenter.Data;

namespace GTI.Modules.PlayerCenter.UI
{
    public partial class PointPurgeForm : GTI.Modules.Shared.EliteGradientForm
    {
        private int m_playersChanged = 0;
        private string m_lastPurgeMethod = string.Empty;
        private string m_lastPurgeBy = string.Empty;
		private int m_lastPurgePlayersChanged = 0;
        private DateTime m_lastPurgeDate;
        private string m_lastPurgeReason = string.Empty;

        public PointPurgeForm(int staffID)
        {
            InitializeComponent();

            //get information from the last purge
            PlayerPointPurgeMessage ppm = new PlayerPointPurgeMessage();

            ppm.PurgeOperation = PlayerPointPurgeMessage.Operation.GetLastPurgeInfo;
            SendPurgeMessage(ppm);

            //set defaults
            dtpSinceDate.Value = DateTime.Now - TimeSpan.FromDays(365);
            dtpSinceDate.MaxDate = DateTime.Now.Date;
            cbPeriodType.SelectedIndex = 0;
            nudPeriodNumber.Value = 90;

            //parse the last purge method to populate the current method
            if (m_lastPurgePlayersChanged == 0) //no previous method, default to haven't played in a year
            {
                rbNoVisitsInPreviousPeriod.Checked = true;
                cbPeriodType.SelectedIndex = 2;
                nudPeriodNumber.Value = 1;
            }
            else if (m_lastPurgeMethod.Contains("All")) //all players
            {
                rbAllPlayers.Checked = true;
            }
            else if (m_lastPurgeMethod.Contains("since")) //has not visited since --
            {
                rbNoVisitsSince.Checked = true;

                DateTime dt = DateTime.Now;

                DateTime.TryParse(m_lastPurgeMethod.Substring(m_lastPurgeMethod.IndexOf("since") + 6), out dt);

                dtpSinceDate.Value = dt;
            }
            else //has not visited in the previous --
            {
                rbNoVisitsInPreviousPeriod.Checked = true;

                int number = 365;
                string work1 = m_lastPurgeMethod.Substring(m_lastPurgeMethod.IndexOf("previous") + 9);
                string work2 = work1.Substring(work1.IndexOf(" ") + 1);

                work1 = work1.Substring(0, work1.Length - work2.Length - 1);
                int.TryParse(work1, out number);

                nudPeriodNumber.Value = number;

                switch (work2[0])
                {
                    case 'd': //days
                    {
                        cbPeriodType.SelectedIndex = 0;
                    }
                    break;

                    case 'm': //months
                    {
                        cbPeriodType.SelectedIndex = 1;
                    }
                    break;

                    case 'y': //years
                    {
                        cbPeriodType.SelectedIndex = 2;
                    }
                    break;
                }
            }
        }

        private void SendPurgeMessage(PlayerPointPurgeMessage message)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            btnPurge.Enabled = false;
            btnClose.Enabled = false;
            btnUndo.Enabled = false;
            gbLastPurge.Enabled = false;
            gbMethod.Enabled = false;
            gbReason.Enabled = false;

            try
            {
                message.Send();
            }
            catch
            {
            }

            //update the member variables with the results
            m_playersChanged = message.PlayersChanged;
            m_lastPurgeMethod = message.LastPurgeMethod;
            m_lastPurgeReason = message.ReasonForLastPurge;
            m_lastPurgeBy = message.LastPurgedBy;
            m_lastPurgePlayersChanged = message.PlayersChangedByLastPurge;
            m_lastPurgeDate = message.LastPurgeDate;

            //update the last purge info
            lblLastPurgeInfo.Text = m_lastPurgePlayersChanged.ToString() + " players\r\n" + m_lastPurgeMethod + "\r\n" + "Performed on " + m_lastPurgeDate.ToShortDateString() + " at " + m_lastPurgeDate.ToShortTimeString() + "\r\nBy " + m_lastPurgeBy + "\r\nReason: " + m_lastPurgeReason;
            gbLastPurge.Visible = m_lastPurgePlayersChanged != 0;
            btnUndo.Enabled = m_lastPurgePlayersChanged != 0;
            btnPurge.Enabled = true;
            btnClose.Enabled = true;
            Cursor.Current = System.Windows.Forms.Cursors.Default;
            gbLastPurge.Enabled = true;
            gbMethod.Enabled = true;
            gbReason.Enabled = true;
        }

        private void btnPurge_Click(object sender, EventArgs e)
        {
            //find the date to purge before and generate the text for the purge method
            DateTime dt = DateTime.Now.Date;
            string method = string.Empty;

            if (rbAllPlayers.Checked)
            {
                dt = dt + TimeSpan.FromDays(1);
                method = "All players";
            }
            else if (rbNoVisitsSince.Checked)
            {
                dt = dtpSinceDate.Value.Date + TimeSpan.FromDays(1);
                method = "Players who had not visited since " + dtpSinceDate.Value.Date.ToShortDateString();
            }
            else //no visits in previous period
            {
                dt = dt - (TimeSpan.FromDays((int)nudPeriodNumber.Value * (cbPeriodType.SelectedIndex == 0 ? 1 : cbPeriodType.SelectedIndex == 1 ? 30 : 365))) + TimeSpan.FromDays(1);
                method = "Players who had not visited in the previous " + ((int)nudPeriodNumber.Value).ToString() + " " + cbPeriodType.SelectedItem.ToString();
            }
            
            PlayerPointPurgeMessage ppm = new PlayerPointPurgeMessage();

            ppm.PurgeOperation = PlayerPointPurgeMessage.Operation.Purge;
            ppm.PurgeIfLastVisitWasBeforeThisDate = dt;
            ppm.PurgeMethod = method;
            ppm.ReasonForPurge = string.IsNullOrWhiteSpace(txtManualPointAdjustReason.Text) ? "None" : txtManualPointAdjustReason.Text;

            SendPurgeMessage(ppm);
            GTI.Modules.Shared.MessageForm.Show(this, m_playersChanged == 0 ? "No players found with points to expire." : "Players with points expired: " + m_playersChanged.ToString(), "Expiring Results");
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            PlayerPointPurgeMessage ppm = new PlayerPointPurgeMessage();

            ppm.PurgeOperation = PlayerPointPurgeMessage.Operation.UndoPurge;
            ppm.ReasonForPurge = string.IsNullOrWhiteSpace(txtManualPointAdjustReason.Text) ? "None" : txtManualPointAdjustReason.Text;
            SendPurgeMessage(ppm);
            GTI.Modules.Shared.MessageForm.Show(this, m_playersChanged == 0 ? "No players affected by undo." : "Players affected by undo: " + m_playersChanged.ToString(), "Results for Expiring Undo");
        }

        private void SelectPurgeByPeriod(object sender, EventArgs e)
        {
            rbNoVisitsInPreviousPeriod.Checked = true;
        }

        private void SelectPurgeByDate(object sender, EventArgs e)
        {
            rbNoVisitsSince.Checked = true;
        }

        private void txtManualPointAdjustReason_TextChanged(object sender, EventArgs e)
        {
            lblManualPointsAdjustReasonCharactersLeft.Text = (txtManualPointAdjustReason.MaxLength - txtManualPointAdjustReason.TextLength).ToString();
        }
    }
}
