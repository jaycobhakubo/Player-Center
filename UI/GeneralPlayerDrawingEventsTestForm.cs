using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeneralPlayerDrawing = GTI.Modules.Shared.Business.GeneralPlayerDrawing;
using GeneralPlayerDrawingEvent = GTI.Modules.Shared.Business.GeneralPlayerDrawingEvent;

namespace GTI.Modules.PlayerCenter.UI
{
    public partial class GeneralPlayerDrawingEventsTestForm : Form
    {
        private List<GeneralPlayerDrawing> m_drawings;

        public GeneralPlayerDrawingEventsTestForm(List<GeneralPlayerDrawing> drawings)
        {
            InitializeComponent();
            m_drawings = drawings ?? new List<GeneralPlayerDrawing>();
            LoadCurrentAndRecentDrawingEvents();
        }

        private void LoadCurrentAndRecentDrawingEvents()
        {
            GeneralPlayerDrawingEvent prevSel = null;
            ListViewItem newSelLVI = null;
            if(drawingEventsLV.SelectedItems.Count == 1)
                prevSel = drawingEventsLV.SelectedItems[0].Tag as GeneralPlayerDrawingEvent;

            drawingEventsLV.Items.Clear();
            drawingEventsLV.Columns.Clear();

            drawingEventsLV.BeginUpdate();
            try
            {
                var drawingEvents = GTI.Modules.Shared.Data.GetGeneralDrawingEventsMessage.GetEvents(0, 0, DateTime.Now.Date.AddDays(-14), DateTime.Now.Date, true, true);
                if(drawingEvents.Count == 0)
                {
                    drawingEventsLV.Columns.Add("");
                    drawingEventsLV.Items.Add("No Drawing Events Found");
                    drawingEventsLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
                else
                {
                    drawingEventsLV.Columns.Add("Event Id");
                    drawingEventsLV.Columns.Add("Drawing");
                    drawingEventsLV.Columns.Add("Entries Begin");
                    drawingEventsLV.Columns.Add("Entries End");
                    drawingEventsLV.Columns.Add("Schedule for");
                    drawingEventsLV.Columns.Add("Held when");
                    drawingEventsLV.Columns.Add("Cancelled when");
                    drawingEventsLV.Columns.Add("Players");
                    drawingEventsLV.Columns.Add("Entries");
                    drawingEventsLV.Columns.Add("# Drawn");

                    bool heldPresent = false
                        , cancellationPresent = false
                        ;

                    foreach(var de in drawingEvents)
                    {
                        var lvi = drawingEventsLV.Items.Add(de.EventId.ToString());
                        var ed = m_drawings.FirstOrDefault((d) => d.Id == de.DrawingId);
                        lvi.SubItems.Add(ed == null ? String.Format("[{0}]", de.DrawingId) : ed.Name);
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

                        var playersEntered = (from e in de.Entries
                                              select e.PlayerId).Distinct();
                        var totalEntries = (from e in de.Entries
                                            select e.EntryCount).Sum();

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
            eventActionsFLP.Enabled = selectionMade;
        }

        private void generateCurrentEventsBtn_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            var gResult = GTI.Modules.Shared.Data.GenerateGeneralDrawingsEventsMessage.GenerateDrawingEvents(DateTime.Now.Date);

            var msg = EventsToString(gResult, m_drawings);
            var dr = MessageBox.Show(this, (msg ?? "No Events Generated") + Environment.NewLine + Environment.NewLine + "Reload Recent?", "Generated Events", MessageBoxButtons.YesNo);
            if(dr == System.Windows.Forms.DialogResult.Yes)
                LoadCurrentAndRecentDrawingEvents();

        }

        private void refreshEventsListBtn_Click(object sender, EventArgs e)
        {
            LoadCurrentAndRecentDrawingEvents();

            //StringBuilder sb = new StringBuilder();
            //var gResult = GTI.Modules.Shared.Data.GetGeneralDrawingEventsMessage.GetEvents(0, 0, DateTime.Now.Date);

            //var msg = EventsToString(gResult, m_drawings);
            //MessageBox.Show(msg ?? "No Current Events", "Current Events");
        }

        private void executeEventBtn_Click(object sender, EventArgs e)
        {
            var drawingEvent = drawingEventsLV.SelectedItems[0].Tag as GeneralPlayerDrawingEvent;

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
                var eeResult = GTI.Modules.Shared.Data.ExecuteGeneralDrawingEventMessage.ExecuteEvent(eventId, true, true);
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
                var cd = GTI.Modules.Shared.Data.SetGeneralDrawingEventCancelledMessage.CancelEvent(eventId);

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
                var cd = GTI.Modules.Shared.Data.SetGeneralDrawingEventCancelledMessage.ReinstateEvent(eventId);

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
                var displayInitiated = GTI.Modules.Shared.Data.InitiateGeneralDrawingEventResultsNotificationsMessage.InitiateResultsNotifications(eventId);

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
            GTI.Modules.Shared.Data.AbortGeneralDrawingEventResultsNotificationsMessage.AbortResultsNotifications();
        }
    }
}
