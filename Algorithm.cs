using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ScheduleCPU
{
    public enum Algo
    {
        FCFS,
        SRTF,
        PP,
        NPP,
        RR
    }

    public class SolveProblem
    {
        public static void Solve(Algo type, int[] arrivalTime, int[] burstTime, int[] priority = null,
            int quantumTime = 0)
        {
            var processes = InitProcesses(arrivalTime, burstTime, priority);
            if (type == Algo.FCFS)
            {
                FCFS(processes);
            }
        }

        private static Process[] InitProcesses(IReadOnlyList<int> arrivalTime, IReadOnlyList<int> burstTime,
            IReadOnlyList<int> priority)
        {
            var processes = new Process[arrivalTime.Count];
            for (var i = 0; i < arrivalTime.Count; i++)
            {
                processes[i] = new Process()
                {
                    ArrivalTime = arrivalTime[i],
                    BurstTime = burstTime[i],
                    Priority = priority?[i]
                };
            }

            return processes;
        }

        private static void FCFS(Process[] processes)
        {
            var tableResult = new Table();
            var ganttChart = new GanttChart();
            var processesClone = processes.OrderBy(process => process.ArrivalTime).ToArray();

            ganttChart.AddItem(new GanttItem()
            {
                Start = 0,
                Exit = processesClone[0].BurstTime,
                Process = processesClone[0]
            });

            var currentTime = processesClone[0].BurstTime;

            for (var i = 1; i < processesClone.Length; i++)
            {
                if (currentTime == 0 || currentTime >= processes[i].ArrivalTime)
                {
                    currentTime = ganttChart.GanttItems[i - 1].Exit + processesClone[i].BurstTime;
                    ganttChart.AddItem(new GanttItem()
                    {
                        Start = ganttChart.GanttItems[i - 1].Exit,
                        Exit = currentTime,
                        Process = processesClone[i]
                    });
                    
                }
                else
                {
                    currentTime = processes[i].ArrivalTime + processesClone[i].BurstTime;

                    ganttChart.AddItem(new GanttItem()
                    {
                        Start = processes[i].ArrivalTime,
                        Exit = currentTime,
                        Process = processesClone[i]
                    });
                }
            }

            foreach (var gantt in ganttChart.GanttItems)
            {
                tableResult.AddItem(new TableItem()
                {
                    ProcessName = gantt.Process.ProcessName,
                    ArrivalTime = gantt.Process.ArrivalTime,
                    BurstTime = gantt.Process.BurstTime,
                    Priority = gantt.Process.Priority,
                    TurnAroundTime = gantt.Exit - gantt.Process.ArrivalTime,
                    WaitingTime = gantt.Start - gantt.Process.ArrivalTime,
                    ResponseTime = gantt.Start - gantt.Process.ArrivalTime,
                });
            }
        }
    }
}