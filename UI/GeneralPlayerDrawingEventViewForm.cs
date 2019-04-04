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
    public partial class GeneralPlayerDrawingEventViewForm : Form
    {
        public GeneralPlayerDrawingEventViewForm(GeneralPlayerDrawingEvent drawingEvent, GeneralPlayerDrawing drawing)
        {
            InitializeComponent();
            generalPlayerDrawingEventView1.SetEvent(drawingEvent, drawing);
        }
    }
}
