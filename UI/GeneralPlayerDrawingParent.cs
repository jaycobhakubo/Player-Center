using GTI.Modules.Shared;
using GTI.Modules.Shared.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameTech.Elite.Base;

namespace GTI.Modules.PlayerCenter.UI
{
    public partial class GeneralPlayerDrawingParent : GradientForm
    {

        private List<GeneralPlayerDrawing> m_drawings;
        private GeneralPlayerDrawingForm m_genPlayerDrawing;
        private GeneralPlayerDrawingEventsTestForm m_genPlayerDrawingEvent;

        public GeneralPlayerDrawingParent()
        {
            InitializeComponent();
            m_genPlayerDrawing = new GeneralPlayerDrawingForm();
            m_drawings = m_genPlayerDrawing.Drawings;
            m_genPlayerDrawingEvent = new GeneralPlayerDrawingEventsTestForm(m_drawings);
            m_genPlayerDrawingEvent.MdiParent = this;
            m_genPlayerDrawingEvent.Dock = DockStyle.Fill;
            m_genPlayerDrawing.FormClosed += new FormClosedEventHandler(closedPlayerDrawing);
            m_genPlayerDrawingEvent.FormClosed += new FormClosedEventHandler(closedPlayerDrawing);
            tc_PlayerDrawing.SelectedTab.Controls.Add(m_genPlayerDrawingEvent);
            m_genPlayerDrawingEvent.Show();
        }

        private void playerDrawingTabControlSelectedIndexChanged(object sender, EventArgs e)
        {

            TabPage tp = tc_PlayerDrawing.SelectedTab;

            if (tc_PlayerDrawing.SelectedIndex == 1)
            {
                m_genPlayerDrawing.MdiParent = this;
                m_genPlayerDrawing.Dock = DockStyle.Fill;
                m_genPlayerDrawing.Show();
                tp.Controls.Add(m_genPlayerDrawing);          
            }
            else
                if (tc_PlayerDrawing.SelectedIndex == 0)
                {          
                    m_genPlayerDrawingEvent.MdiParent = this;
                    m_genPlayerDrawingEvent.Dock = DockStyle.Fill;
                   
                    tp.Controls.Add(m_genPlayerDrawingEvent);
                    m_genPlayerDrawingEvent.Show();
                }
        }

         private  void closedPlayerDrawing(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
