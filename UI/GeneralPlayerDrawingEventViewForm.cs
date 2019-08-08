using System.Windows.Forms;
using GameTech.Elite.Base;
using GTI.Modules.Shared;

namespace GTI.Modules.PlayerCenter.UI
{
    public partial class GeneralPlayerDrawingEventViewForm : GradientForm
    {
        public GeneralPlayerDrawingEventViewForm(GeneralPlayerDrawingEvent drawingEvent, GeneralPlayerDrawing drawing)
        {
            InitializeComponent();
            this.Text = "General Player " + (raffle_Setting.RaffleTextSetting == 1 ? "Raffle" : "Drawing") + " Event";
            generalPlayerDrawingEventView1.SetEvent(drawingEvent, drawing);
        }
    }
}
