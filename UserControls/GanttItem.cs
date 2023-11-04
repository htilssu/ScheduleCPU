using System.Windows.Forms;

namespace ScheduleCPU.UserControls
{
    public partial class GanttItem : UserControl
    {
        public GanttItem(string processName,string start, string exit)
        {
            InitializeComponent();
            ProcessName.Text = processName;
            Start.Text = start;
            Exit.Text = exit;
        }
    }
}