using GTI.Modules.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameTech.Elite.Base;
using GameTech.Elite.Client;
using System.Globalization;

namespace GTI.Modules.PlayerCenter.UI
{
    public partial class GeneralPlayerDrawingEventsTestForm : GradientForm
    {
        private List<GeneralPlayerDrawing> m_drawings;
        private string m_displayText;

        public GeneralPlayerDrawingEventsTestForm(List<GeneralPlayerDrawing> drawings, string displayText)
        {
            InitializeComponent();
            m_drawings = drawings ?? new List<GeneralPlayerDrawing>();
            m_displayText = displayText;

            LoadCurrentAndRecentDrawingEvents();
            SetBtnControlDisable(false);
            AppliedSystemSettingDisplayedText();                       
        }

        private void GenerateCurrentDrawing()
        {
            StringBuilder sb = new StringBuilder();
            var gResult = GenerateGeneralDrawingsEventsMessage.GenerateDrawingEvents(DateTime.Now.Date);
            var msg = EventsToString(gResult, m_drawings);
            var dr = MessageBox.Show(this, (msg ?? "No Events Generated") + Environment.NewLine + Environment.NewLine + "Reload Recent?", "Generated Events", MessageBoxButtons.YesNo);
            if (dr == System.Windows.Forms.DialogResult.Yes)
                LoadCurrentAndRecentDrawingEvents();         
        }

        private void AppliedSystemSettingDisplayedText()
        {
            drawingEventsLbl.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase("Scheduled " + m_displayText.ToLower() + "s");
            chkbx_showAvailableDrawing.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase("Show Available " + m_displayText.ToLower() + "s");
        }

        private void SetBtnControlDisable(bool set)
        {
            imgbtnViewEntriesResult.Enabled = set;
            imgbtnReinstate.Enabled = set;
            imgbtnExecute.Enabled = set;
            imgbtnCancel.Enabled = set;
        }

        private void LoadCurrentAndRecentDrawingEvents()
        {
            GeneralPlayerDrawingEvent prevSel = null;
            ListViewItem newSelLVI = null;
            if(drawingEventsLV.SelectedItems.Count == 1)
            prevSel = drawingEventsLV.SelectedItems[0].Tag as GeneralPlayerDrawingEvent;

            DataGridView dgvtest = new DataGridView();
            DataGridViewRow  dgvr = new DataGridViewRow();

            drawingEventsLV.Items.Clear();
            drawingEventsLV.Columns.Clear();

            drawingEventsLV.BeginUpdate();
            try
            {
                var drawingEvents = GetGeneralDrawingEventsMessage.GetEvents(0, 0, DateTime.Now.Date.AddDays(-14), DateTime.Now.Date, true, true);
                
                if(drawingEvents.Count == 0)
                {
                    drawingEventsLV.Columns.Add("");
                    drawingEventsLV.Items.Add("No Drawing Events Found");
                    drawingEventsLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
                else
                {
                    drawingEventsLV.Columns.Add(m_displayText);
                    drawingEventsLV.Columns.Add("Entries Begin");
                    drawingEventsLV.Columns.Add("Entries End");
                    drawingEventsLV.Columns.Add("Schedule For");
                    drawingEventsLV.Columns.Add("Held When");
                    drawingEventsLV.Columns.Add("Cancelled When");
                    drawingEventsLV.Columns.Add("Players");
                    drawingEventsLV.Columns.Add("Entries");
                    drawingEventsLV.Columns.Add("# Drawn");

                    bool heldPresent = false
                        , cancellationPresent = false;



                    foreach(GeneralPlayerDrawingEvent de in drawingEvents)
                    {
                        GeneralPlayerDrawing ed = m_drawings.FirstOrDefault((d) => d.Id == de.DrawingId);
                        var playersEntered = (from e in de.Entries
                                              select e.PlayerId).Distinct();
                        var totalEntries = (from e in de.Entries
                                            select e.EntryCount).Sum();

                        //default (true) show drawing that are currently available to run without any issues.
                        //Removed drawing that are already held, cancelled and if the minimum entries is greater than the current total entries.
                        if (chkbx_showAvailableDrawing.Checked)
                        {
                            if (de.HeldWhen.HasValue || de.CancelledWhen.HasValue || ed.MinimumEntries > totalEntries)
                            {
                                continue;
                            }
                            
                        }       

                        var lvi = drawingEventsLV.Items.Add(ed == null ? String.Format("[{0}]", de.DrawingId) : ed.Name);
                        lvi.Font = new Font(lvi.Font, FontStyle.Regular);
                        //lvi.SubItems.Add(ed == null ? String.Format("[{0}]", de.DrawingId) : ed.Name);
                        lvi.SubItems.Add(de.EntryPeriodBegin.ToShortDateString());
                        lvi.SubItems.Add(de.EntryPeriodEnd.ToShortDateString());
                        lvi.SubItems.Add(de.ScheduledForWhen.HasValue ? de.ScheduledForWhen.Value.ToShortDateString() : "(unspecified)");

                        heldPresent = heldPresent || de.HeldWhen.HasValue;
                        lvi.SubItems.Add(de.HeldWhen.HasValue
                            ? String.Format("{0} {1}", de.HeldWhen.Value.ToShortDateString(), de.HeldWhen.Value.ToShortTimeString())
                            : "never"
                            );

                        cancellationPresent = cancellationPresent || de.CancelledWhen.HasValue;
                        lvi.SubItems.Add(de.CancelledWhen.HasValue
                            ? String.Format("{0} {1}", de.CancelledWhen.Value.ToShortDateString(), de.CancelledWhen.Value.ToShortTimeString())
                            : "---"
                            );

             

                        lvi.SubItems.Add(playersEntered.Count().ToString());
                        lvi.SubItems.Add(totalEntries.ToString());
                        lvi.SubItems.Add(de.Results.Count.ToString());

                        lvi.Tag = de;

                        if(prevSel != null && de.EventId == prevSel.EventId)
                            newSelLVI = lvi;
                    }

                    if(newSelLVI != null)
                        newSelLVI.Selected = true;


                    drawingEventsLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    if(heldPresent)
                        drawingEventsLV.AutoResizeColumn(5, ColumnHeaderAutoResizeStyle.ColumnContent);
                    if(cancellationPresent)
                        drawingEventsLV.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.ColumnContent);
                }
            }
            finally
            {
                drawingEventsLV.EndUpdate();
            }
        }

        private static string EventsToString(List<GeneralPlayerDrawingEvent> drawingEvents, List<GeneralPlayerDrawing> drawings = null)
        {
            StringBuilder sb = new StringBuilder();
            if(drawingEvents == null || drawingEvents.Count == 0)
                return null;
            foreach(var de in drawingEvents)
            {
                GeneralPlayerDrawing ed = null;
                if(drawings != null)
                    ed = drawings.FirstOrDefault((d) => d.Id == de.DrawingId);

                var dName = ed == null ? String.Format("[{0}]", de.DrawingId) : ("'" + ed.Name + "'");
                sb.AppendFormat("Drawing {0}, Event Id {1}", dName, de.EventId);
                sb.AppendLine();

                if(de.EntryPeriodBegin.ToShortDateString() == de.EntryPeriodEnd.ToShortDateString())
                    sb.AppendFormat("- entry period on {0}", de.EntryPeriodBegin.ToShortDateString());
                else
                    sb.AppendFormat("- entry period from {0} to {1}", de.EntryPeriodBegin.ToShortDateString(), de.EntryPeriodEnd.ToShortDateString());
                sb.AppendLine();

                if(de.ScheduledForWhen.HasValue)
                    sb.AppendFormat("- scheduled to be held {0}.", de.ScheduledForWhen.Value.ToShortDateString());
                else
                    sb.Append("- scheduled data unspecified.");

                sb.AppendLine();
            }

            return sb.ToString();
        }

        private void drawingEventsLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectionMade = drawingEventsLV.SelectedItems.Count == 1;
            //eventActionsFLP.Enabled = selectionMade;
            SetBtnControlDisable(selectionMade);
        }

        private void generateCurrentEventsBtn_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            var gResult = GenerateGeneralDrawingsEventsMessage.GenerateDrawingEvents(DateTime.Now.Date);

            var msg = EventsToString(gResult, m_drawings);
            var dr = MessageBox.Show(this, (msg ?? "No Events Generated") + Environment.NewLine + Environment.NewLine + "Reload Recent?", "Generated Events", MessageBoxButtons.YesNo);
            if(dr == System.Windows.Forms.DialogResult.Yes)
                LoadCurrentAndRecentDrawingEvents();
        }

        private void refreshEventsListBtn_Click(object sender, EventArgs e)
        {
            GenerateCurrentDrawing();      
        }

        private void executeEventBtn_Click(object sender, EventArgs e)
        {
            var drawingEvent = drawingEventsLV.SelectedItems[0].Tag as GeneralPlayerDrawingEvent;//get the selected item data

            if(drawingEvent.HeldWhen.HasValue)
            {
                MessageBox.Show(this, "Cannot hold an event that has already been held.", "Execution not permitted", MessageBoxButtons.OK);
                return;
            }
            else if(drawingEvent.CancelledWhen.HasValue)
            {
                MessageBox.Show(this, "Cannot hold an event that has been cancelled.", "Execution not permitted", MessageBoxButtons.OK);
                return;
            }
            else
            {
                int eventId = drawingEvent.EventId;

                bool showEvent = false;
                var eeResult = ExecuteGeneralDrawingEventMessage.ExecuteEvent(eventId, true, true);
                LoadCurrentAndRecentDrawingEvents();
                if(!eeResult.Item1)
                {
                    String msg = String.Empty;
                    if(eeResult.Item2.HeldWhen.HasValue)
                        msg = "Event was already held.";
                    else if(eeResult.Item2.CancelledWhen.HasValue)
                        msg = "Cannot hold a cancelled event.";
                    else
                        msg = "Event not executed.";

                    var dr = MessageBox.Show(this, msg + Environment.NewLine + "Show event details?", "Event Not Executed", MessageBoxButtons.YesNo);
                    showEvent = (dr == System.Windows.Forms.DialogResult.Yes);
                }
                else
                    showEvent = true;

                if(showEvent)
                {
                    var ed = m_drawings.FirstOrDefault((d) => d.Id == eeResult.Item2.DrawingId);
                    var f = new GeneralPlayerDrawingEventViewForm(eeResult.Item2, ed);
                    f.ShowDialog(this);
                    f.Dispose();
                    //Lets initiate the result broadcast
                    imgbtnInitiateResults.PerformClick();
                }
            }

        }

        private void cancelEventBtn_Click(object sender, EventArgs e)
        {
            var drawingEvent = drawingEventsLV.SelectedItems[0].Tag as GeneralPlayerDrawingEvent;

            if(drawingEvent.HeldWhen.HasValue)
            {
                MessageBox.Show(this, "Cannot cancel an event that has been held.", "Cancel not permitted", MessageBoxButtons.OK);
                return;
            }
            else if(drawingEvent.CancelledWhen.HasValue)
            {
                MessageBox.Show(this, "Cannot cancel an event that has already been cancelled.", "Event already cancelled", MessageBoxButtons.OK);
                return;
            }
            else
            {
                int eventId = drawingEvent.EventId;
                var cd = SetGeneralDrawingEventCancelledMessage.CancelEvent(eventId);

                string msg = null;
                if(cd.HasValue)
                    msg = String.Format("Event {0} cancelled {1}, {2}", eventId, cd.Value.ToShortDateString(), cd.Value.ToShortTimeString());
                else
                    msg = String.Format("Event {0} not cancelled.", eventId);

                var dr = MessageBox.Show(this, msg + Environment.NewLine + Environment.NewLine + "Reload Recent?", "Cancel Results", MessageBoxButtons.YesNo);
                if(dr == System.Windows.Forms.DialogResult.Yes)
                    LoadCurrentAndRecentDrawingEvents();
            }
        }

        private void reinstateEventBtn_Click(object sender, EventArgs e)
        {
            var drawingEvent = drawingEventsLV.SelectedItems[0].Tag as GeneralPlayerDrawingEvent;

            if(!drawingEvent.CancelledWhen.HasValue)
            {
                MessageBox.Show(this, "Cannot reinstate an event that is not cancelled.", "Event not cancelled", MessageBoxButtons.OK);
                return;
            }
            else
            {
                int eventId = drawingEvent.EventId;
                var cd = SetGeneralDrawingEventCancelledMessage.ReinstateEvent(eventId);

                string msg = null;
                if(cd.HasValue)
                    msg = String.Format("Event {0} not reinstated; still cancelled as of {1}, {2}.", eventId, cd.Value.ToShortDateString(), cd.Value.ToShortTimeString());
                else
                    msg = String.Format("Event {0} reinstated.", eventId);

                var dr = MessageBox.Show(this, msg + Environment.NewLine + Environment.NewLine + "Reload Recent?", "Reinstate Results", MessageBoxButtons.YesNo);
                if(dr == System.Windows.Forms.DialogResult.Yes)
                    LoadCurrentAndRecentDrawingEvents();
            }
        }

        private void viewEntriesAndResultsBtn_Click(object sender, EventArgs e)
        {
            var selEvent = drawingEventsLV.SelectedItems[0].Tag as GeneralPlayerDrawingEvent;
            int eventId = selEvent.EventId;

            var ed = m_drawings.FirstOrDefault((d) => d.Id == selEvent.DrawingId);
            var f = new GeneralPlayerDrawingEventViewForm(selEvent, ed);
            f.ShowDialog(this);
            f.Dispose();
        }

        private void initiateEventResultsBroadcastBtn_Click(object sender, EventArgs e)
        {
            var drawingEvent = drawingEventsLV.SelectedItems[0].Tag as GeneralPlayerDrawingEvent;

            if(!drawingEvent.HeldWhen.HasValue)
            {
                MessageBox.Show(this, "Cannot initiate broadcast for an event that has not been held.", "Event not held", MessageBoxButtons.OK);
                return;
            }
            else
            {
                int eventId = drawingEvent.EventId;
                var displayInitiated = InitiateGeneralDrawingEventResultsNotificationsMessage.InitiateResultsNotifications(eventId);

                string msg = null;
                if(displayInitiated)
                    msg = String.Format("Event {0} broadcast initiated.", eventId);
                else
                    msg = String.Format("Event {0} broadcast not initiated.", eventId);

                MessageBox.Show(this, msg, "Initiate Broadcast results", MessageBoxButtons.OK);
            }
        }

        private void abortEventResultsBroadcastBtn_Click(object sender, EventArgs e)
        {
            AbortGeneralDrawingEventResultsNotificationsMessage.AbortResultsNotifications();
        }

        private void imgBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkbx_showAvailableDrawing_CheckedChanged(object sender, EventArgs e)
        {
            LoadCurrentAndRecentDrawingEvents();
        }
    }
}
