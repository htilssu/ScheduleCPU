using System.Collections.Generic;

namespace ScheduleCPU
{
    public class GanttChart
    {
        public List<GanttItem> GanttItems { get; set; } = new List<GanttItem>();

        public void AddItem(GanttItem ganttItem)
        {
            GanttItems.Add(ganttItem);
        }
    }

    public class GanttItem
    {
        public int Start { get; set; }
        public int Exit { get; set; }
        public string ProcessName { get; set; }
    }
}