namespace ScheduleCPU
{
    public class Result
    {
        public GanttChart GanttChart { get; set; }
        public Table Table { get; set; }

        public Result(GanttChart ganttChart, Table table)
        {
            GanttChart = ganttChart;
            Table = table;
        }
    }
}