using System.Collections.Generic;

namespace ScheduleCPU
{
    public  class TableItem
    {
        public string ProcessName { get; set; }
        public int ArrivalTime { get; set; }
        public int BurstTime { get; set; }
        public int ExitTime { get; set; }
        public int TurnAroundTime { get; set; }
        public int ResponseTime { get; set; }
        public int WaitingTime { get; set; }
        public int? Priority { get; set; }
    }

    public class Table
    {
        public List<TableItem> TableItems { get; set; }


        public void AddItem(TableItem tableItem)
        {
            TableItems.Add(tableItem);
        }
    }
}