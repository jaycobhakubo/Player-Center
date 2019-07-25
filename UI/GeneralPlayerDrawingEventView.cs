using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameTech.Elite.Base;

namespace GTI.Modules.PlayerCenter.UI
{
    public partial class GeneralPlayerDrawingEventView : UserControl
    {
        private GeneralPlayerDrawingEvent m_drawingEvent;
        private GeneralPlayerDrawing m_drawing;
        private string m_displayedText = "";

        public GeneralPlayerDrawingEventView()
        {
            InitializeComponent();
            displayTextSetting();
        }

        private string displayTextSetting()
        {
            m_displayedText = (raffle_Setting.RaffleTextSetting == 1) ? "Raffle" : "Drawing";
            drawingCaptionLbl.Text = m_displayedText;
            return m_displayedText;
        }


        public void SetEvent(GeneralPlayerDrawingEvent drawingEvent, GeneralPlayerDrawing drawing)
        {
            m_drawingEvent = drawingEvent;
            m_drawing = drawing;

            eventIdLbl.Text = m_drawingEvent.EventId.ToString();

            drawingLbl.Text = m_drawing.Name;
            createdWhenLbl.Text = m_drawingEvent.CreatedWhen.HasValue
                ? String.Format("{0} {1}", m_drawingEvent.CreatedWhen.Value.ToShortDateString(), m_drawingEvent.CreatedWhen.Value.ToShortTimeString())
                : "(unknown)"
                ;
            entryPeriodBeginLbl.Text = m_drawingEvent.EntryPeriodBegin.ToShortDateString();
            entryPeriodEndLbl.Text = m_drawingEvent.EntryPeriodEnd.ToShortDateString();
            scheduleForLbl.Text = m_drawingEvent.ScheduledForWhen.HasValue
                ? m_drawingEvent.ScheduledForWhen.Value.ToShortDateString()
                : "(unspecified)"
                ;
            cancelledWhenLbl.Text = m_drawingEvent.CancelledWhen.HasValue
                ? String.Format("{0} {1}", m_drawingEvent.CancelledWhen.Value.ToShortDateString(), m_drawingEvent.CancelledWhen.Value.ToShortTimeString())
                : "-"
                ;
            heldWhenLbl.Text = m_drawingEvent.HeldWhen.HasValue
                ? String.Format("{0} {1}", m_drawingEvent.HeldWhen.Value.ToShortDateString(), m_drawingEvent.HeldWhen.Value.ToShortTimeString())
                : "-"
                ;

            entriesLV.Items.Clear();
            entriesLV.Columns.Clear();

            resultsLV.Items.Clear();
            resultsLV.Columns.Clear();

            entriesLV.BeginUpdate();
            try
            {
                if(m_drawingEvent.Entries.Count == 0)
                {
                    entriesLV.Columns.Add("");
                    entriesLV.Items.Add("No Entries Found");
                }
                else
                {
                    entriesLV.Columns.Add("Player Id");
                    entriesLV.Columns.Add("Entry Count");
                    foreach(var entry in m_drawingEvent.Entries)
                    {
                        var lvi = entriesLV.Items.Add(entry.PlayerId.ToString());
                        lvi.SubItems.Add(entry.EntryCount.ToString());
                        lvi.Tag = entry;
                    }
                }
            }
            catch
            {
                entriesLV.Columns.Add("");
                entriesLV.Items.Add("Exception occurred");
            }
            finally
            {
                entriesLV.EndUpdate();
            }
            entriesLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            resultsLV.BeginUpdate();
            try
            {
                if(m_drawingEvent.Results.Count == 0)
                {
                    resultsLV.Columns.Add("");
                    resultsLV.Items.Add("No "+ m_displayedText +" Results Found");
                }
                else
                {
                    resultsLV.Columns.Add("Drawn Order");
                    resultsLV.Columns.Add("Player Id Drawn");
                    foreach(var result in m_drawingEvent.Results)
                    {
                        var lvi = resultsLV.Items.Add(result.DrawingPosition.ToString());
                        lvi.SubItems.Add(result.PlayerId.ToString());
                        lvi.Tag = result;
                    }
                }

            }
            catch
            {
                resultsLV.Columns.Add("");
                resultsLV.Items.Add("Exception occurred");
            }
            finally
            {
                resultsLV.EndUpdate();
            }
            resultsLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }
    }
}
