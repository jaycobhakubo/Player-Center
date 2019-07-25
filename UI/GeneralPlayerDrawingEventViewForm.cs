using System.Windows.Forms;
using GameTech.Elite.Base;

namespace GTI.Modules.PlayerCenter.UI
{
    public partial class GeneralPlayerDrawingEventViewForm : Form
    {
        public GeneralPlayerDrawingEventViewForm(GeneralPlayerDrawingEvent drawingEvent, GeneralPlayerDrawing drawing)
        {
            InitializeComponent();
            this.Text = "General Player " + (raffle_Setting.RaffleTextSetting == 1 ? "Raffle" : "Drawing") + " Event";
            generalPlayerDrawingEventView1.SetEvent(drawingEvent, drawing);
        }
    }
}
