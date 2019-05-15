using System.Windows.Forms;
using GameTech.Elite.Base;

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
