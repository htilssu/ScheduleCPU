namespace ScheduleCPU
{
    public class Process
    {
        public string ProcessName { get; set; }
        public int ArrivalTime { get; set; }
        public int BurstTime { get; set; }
        public int? Priority { get; set; }
    }
}