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

namespace GTI.Modules.PlayerCenter.UI
{
    public partial class GeneralPlayerDrawingParent : GradientForm
    {

        private List<GeneralPlayerDrawing> m_drawings;
        private GeneralPlayerDrawingForm m_gdf;
        GeneralPlayerDrawingEventsTestForm m_gpde;

        public GeneralPlayerDrawingParent()
        {
            InitializeComponent();
            m_gdf = new GeneralPlayerDrawingForm();
            m_drawings = m_gdf.Drawings;
            m_gpde = new GeneralPlayerDrawingEventsTestForm(m_drawings);
            m_gpde.MdiParent = this;
            m_gpde.Dock = DockStyle.Fill; 
            m_gdf.FormClosed +=new FormClosedEventHandler (formClosedEvent);
            m_gpde.FormClosed += new FormClosedEventHandler(formClosedEvent);
            tc_PlayerDrawing.SelectedTab.Controls.Add(m_gpde);
            m_gpde.Show();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            TabPage tp = tc_PlayerDrawing.SelectedTab;

            if (tc_PlayerDrawing.SelectedIndex == 1)
            {               
                m_gdf.MdiParent = this;
                m_gdf.Dock = DockStyle.Fill;
                m_gdf.Show();
                tp.Controls.Add(m_gdf);          
            }
            else
                if (tc_PlayerDrawing.SelectedIndex == 0)
                {          
                    m_gpde.MdiParent = this;
                    m_gpde.Dock = DockStyle.Fill;
                   
                    tp.Controls.Add(m_gpde);
                    m_gpde.Show();
                }
        }

         private  void formClosedEvent(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
