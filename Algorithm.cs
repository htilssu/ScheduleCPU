using System;
using System.Collections.Generic;
using System.Linq;
namespace ScheduleCPU
{
    public enum Algo
    {
        FCFS,
        SJF,
        SRTF,
        PP,
        NPP,
        RR
    }

    public class SolveProblem
    {
        public static Result Solve(Algo type, int[] arrivalTime, int[] burstTime, int[] priority = null,
            int quantumTime = 0)
        {
            var processes = InitProcesses(arrivalTime, burstTime, priority);
            switch (type)
            {
                case Algo.FCFS:
                    return FCFS(processes);
                case Algo.SJF:
                    return SJF(processes);
                case Algo.SRTF:
                    return SRTF(processes);
                case Algo.PP:
                    return PP(processes);
                case Algo.NPP:
                    return NPP(processes);
                case Algo.RR:
                    return RR(processes, quantumTime);
                default:
                    return null;
            }
        }


        private static Result SRTF(Process[] processes)
        {
            var tableResult = new Table();
            var ganttChart = new GanttChart();
             processes = processes.OrderBy(process => process.ArrivalTime).ToArray();
            var processesQueue = new List<Process>();
            var index = 0;
            var currentTime = 0;

            processesQueue.Add(processes[0]);


            while (index < processes.Length && processesQueue.Count != 0)
            {
                var currentProcess = processesQueue[0];
                processesQueue.Remove(currentProcess);
                //Update lại currentTime nếu có khoảng thời gian trống
                if (currentTime < currentProcess.ArrivalTime)
                {
                    currentTime = currentProcess.ArrivalTime;
                }

                var pseudoExitTime = currentTime + currentProcess.BurstTime;

                //Thêm vào hàng đợi những process có arrivalTime bé hơn thời gian thoát (ảo) của process hiện tại
                AddToQueue(pseudoExitTime);

                if (processesQueue.Count > 0 &&
                    pseudoExitTime - processesQueue[0].ArrivalTime > processesQueue[0].BurstTime)
                {
                    ganttChart.AddItem(new GanttItem()
                    {
                        Start = currentTime,
                        Exit = processesQueue[0].ArrivalTime,
                        ProcessName = currentProcess.ProcessName
                    });
                    currentTime = processesQueue[0].ArrivalTime;
                    var newProcess = new Process()
                    {
                        ProcessName = currentProcess.ProcessName,
                        ArrivalTime = currentProcess.ArrivalTime,
                        BurstTime = pseudoExitTime - processesQueue[0].ArrivalTime
                    };
                    AddProcessToQueue(newProcess);
                }
                else
                {
                    ganttChart.AddItem(new GanttItem()
                    {
                        Start = currentTime,
                        Exit = pseudoExitTime,
                        ProcessName = currentProcess.ProcessName
                    });
                    currentTime = pseudoExitTime;
                }

                if (processesQueue.Count != 0) continue;

                if (index < processes.Length - 1)
                {
                    processesQueue.Add(processes[index + 1]);
                    ++index;
                }
            }

            //Adding to Table
            foreach (var process in processes.OrderBy(p => p.ArrivalTime))
            {
                var tableItem = new TableItem()
                {
                    ProcessName = process.ProcessName,
                    ArrivalTime = process.ArrivalTime,
                    BurstTime = process.BurstTime,
                    Priority = process.Priority
                };
                var exitTime = 0;
                for (var i = ganttChart.GanttItems.Count - 1; i >= 0; i--)
                {
                    if (ganttChart.GanttItems[i].ProcessName != process.ProcessName) continue;
                    exitTime = ganttChart.GanttItems[i].Exit;
                    break;
                }

                var firstComeTime =
                    (from t in ganttChart.GanttItems where t.ProcessName == process.ProcessName select t.Start)
                    .FirstOrDefault();

                tableItem.TurnAroundTime = exitTime - process.ArrivalTime;
                tableItem.WaitingTime = tableItem.TurnAroundTime - process.BurstTime;
                tableItem.ResponseTime = firstComeTime - process.ArrivalTime;
                tableResult.AddItem(tableItem);
            }

            return new Result(ganttChart, tableResult);

            void AddProcessToQueue(Process process)
            {
                processesQueue.Add(process);


                SortQueueByRemaining();
            }

            void AddToQueue(int time)
            {
                for (var i = index + 1; i < processes.Length; i++)
                {
                    if (processes[i].ArrivalTime <= time)
                    {
                        processesQueue.Add(processes[i]);
                        ++index;
                        continue;
                    }

                    break;
                }

                SortQueueByRemaining();
            }

            void SortQueueByRemaining()
            {
                //Burst time will decrease to be remaining time
                processesQueue = processesQueue.OrderBy(p => p.BurstTime).ToList();
            }
        }

        private static Process[] InitProcesses(IReadOnlyList<int> arrivalTime, IReadOnlyList<int> burstTime,
            IReadOnlyList<int> priority = null)
        {
            var processes = new Process[arrivalTime.Count];
            if (priority == null)
            {
                for (var i = 0; i < arrivalTime.Count; i++)
                {
                    processes[i] = new Process()
                    {
                        ProcessName = "P" + (i + 1),
                        ArrivalTime = arrivalTime[i],
                        BurstTime = burstTime[i]
                    };
                }
            }
            else
            {
                for (var i = 0; i < arrivalTime.Count; i++)
                {
                    processes[i] = new Process()
                    {
                        ProcessName = "P" + (i + 1),
                        ArrivalTime = arrivalTime[i],
                        BurstTime = burstTime[i],
                        Priority = priority[i]
                    };
                }
            }


            return processes;
        }


        private static Result FCFS(Process[] processes)
        {
            var tableResult = new Table();
            var ganttChart = new GanttChart();
            var processesClone = processes.OrderBy(process => process.ArrivalTime).ToArray();

            ganttChart.AddItem(new GanttItem()
            {
                Start = processesClone[0].ArrivalTime,
                Exit = processesClone[0].ArrivalTime + processesClone[0].BurstTime,
                ProcessName = processesClone[0].ProcessName
            });

            var currentTime = processesClone[0].ArrivalTime + processesClone[0].BurstTime;

            for (var i = 1; i < processesClone.Length; i++)
            {
                if (currentTime != 0 && currentTime >= processes[i].ArrivalTime)
                {
                    currentTime = ganttChart.GanttItems[i - 1].Exit + processesClone[i].BurstTime;
                    ganttChart.AddItem(new GanttItem()
                    {
                        Start = ganttChart.GanttItems[i - 1].Exit,
                        Exit = currentTime,
                        ProcessName = processesClone[i].ProcessName
                    });
                }
                else
                {
                    currentTime = processes[i].ArrivalTime + processesClone[i].BurstTime;

                    ganttChart.AddItem(new GanttItem()
                    {
                        Start = processes[i].ArrivalTime,
                        Exit = currentTime,
                        ProcessName = processesClone[i].ProcessName
                    });
                }
            }

            foreach (var gantt in ganttChart.GanttItems)
            {
                var process = processes.FirstOrDefault(p => p.ProcessName == gantt.ProcessName);
                if (process != null)
                    tableResult.AddItem(new TableItem()
                    {
                        ProcessName = gantt.ProcessName,
                        ArrivalTime = process.ArrivalTime,
                        BurstTime = process.BurstTime,
                        Priority = process.Priority,
                        TurnAroundTime = gantt.Exit - process.ArrivalTime,
                        WaitingTime = gantt.Start - process.ArrivalTime,
                        ResponseTime = gantt.Start - process.ArrivalTime,
                    });
            }

            return new Result(ganttChart, tableResult);
        }

        private static Result SJF(Process[] processes)
        {
            var processesClone = (Process[])processes.Clone();
            var ganttChart = new GanttChart();
            var resultTable = new Table();
            var processQueue = new Queue<Process>();
            var index = 0;
            var currentTime = 0;

            processesClone = processesClone.OrderBy(p => p.ArrivalTime).ToArray();
            processQueue.Enqueue(processesClone[index]);
            while (index < processesClone.Length - 1 &&
                   processesClone[index].ArrivalTime == processesClone[index + 1].ArrivalTime)
            {
                processQueue.Enqueue(processesClone[++index]);
            }

            if (processQueue.Count > 1)
            {
                processQueue = new Queue<Process>(processQueue.OrderBy(p => p.BurstTime));
            }

            while (processQueue.Count != 0)
            {
                var currentProcess = processQueue.Dequeue();

                if (currentTime < currentProcess.ArrivalTime)
                {
                    currentTime = currentProcess.ArrivalTime;
                }

                ganttChart.AddItem(new GanttItem()
                {
                    Start = currentTime,
                    Exit = currentTime + currentProcess.BurstTime,
                    ProcessName = currentProcess.ProcessName
                });

                currentTime += currentProcess.BurstTime;

                if (processQueue.Count == 0 && index == processesClone.Length - 1)
                {
                    break;
                }

                if (index < processesClone.Length - 1)
                {
                    while (processQueue.Count == 0 || processesClone[index + 1].ArrivalTime <= currentTime)
                    {
                        processQueue.Enqueue(processesClone[++index]);
                        if (index == processesClone.Length - 1)
                        {
                            break;
                        }
                    }

                    processQueue = new Queue<Process>(processQueue.OrderBy(p => p.BurstTime));
                }
            }

            foreach (var tableItem in from ganttChartGanttItem in ganttChart.GanttItems
                     let process = processes.FirstOrDefault(p => p.ProcessName == ganttChartGanttItem.ProcessName)
                     where process != null
                     select new TableItem
                     {
                         ProcessName = ganttChartGanttItem.ProcessName,
                         ArrivalTime = process.ArrivalTime,
                         WaitingTime = ganttChartGanttItem.Start - process.ArrivalTime,
                         TurnAroundTime = ganttChartGanttItem.Exit - process.ArrivalTime,
                         ResponseTime = ganttChartGanttItem.Start - process.ArrivalTime,
                         Priority = process.Priority,
                         BurstTime = process.BurstTime
                     })
            {
                resultTable.AddItem(tableItem);
            }


            return new Result(ganttChart, resultTable);
        }

        private static Result NPP(Process[] processes)
        {
            var tableResult = new Table();
            var ganttChart = new GanttChart();
            var processesClone = (Process[])processes.Clone();
            processesClone = processesClone.OrderBy(p => p.ArrivalTime).ThenBy(p => p.Priority).ToArray();
            var index = 0;
            var currentTime = 0;

            var processQueue = new Queue<Process>();
            processQueue.Enqueue(processesClone[index]);

            if (index < processesClone.Length - 1 &&
                processesClone[index + 1].ArrivalTime == processesClone[index].ArrivalTime)
            {
                processQueue.Enqueue(processesClone[++index]);
            }


            while (processQueue.Count > 0)
            {
                var currentProcess = processQueue.Dequeue();
                if (currentTime < currentProcess.ArrivalTime)
                {
                    currentTime = currentProcess.ArrivalTime;
                }

                ganttChart.AddItem(new GanttItem()
                {
                    Exit = currentTime + currentProcess.BurstTime,
                    Start = currentTime,
                    ProcessName = currentProcess.ProcessName
                });

                currentTime += currentProcess.BurstTime;

                if (index == processesClone.Length - 1 && processQueue.Count == 0)
                {
                    break;
                }

                if (processQueue.Count == 0)
                {
                    processQueue.Enqueue(processesClone[++index]);
                    while (index < processesClone.Length - 1 &&
                           (processesClone[index + 1].ArrivalTime <= currentTime ||
                            processesClone[index].ArrivalTime ==
                            processesClone[index + 1].ArrivalTime))
                    {
                        processQueue.Enqueue(processesClone[++index]);
                    }


                    processQueue = new Queue<Process>(processQueue.OrderBy(p => p.Priority));
                }
            }

            foreach (var tableItem in from ganttChartGanttItem in ganttChart.GanttItems
                     let process = processes.FirstOrDefault(p => p.ProcessName == ganttChartGanttItem.ProcessName)
                     where process != null
                     select new TableItem
                     {
                         ProcessName = ganttChartGanttItem.ProcessName,
                         ArrivalTime = ganttChartGanttItem.Start,
                         WaitingTime = ganttChartGanttItem.Start - process.ArrivalTime,
                         TurnAroundTime = ganttChartGanttItem.Exit - process.ArrivalTime,
                         ResponseTime = ganttChartGanttItem.Start - process.ArrivalTime,
                         Priority = process.Priority,
                         BurstTime = process.BurstTime
                     })
            {
                tableResult.AddItem(tableItem);
            }

            return new Result(ganttChart, tableResult);
        }

        private static Result PP(Process[] processes)
        {
            var tableResult = new Table();
            var ganttChart = new GanttChart();
            var processQueue = new Queue<Process>();
            processes = processes.OrderBy(p => p.ArrivalTime).ThenBy(p => p.Priority).ToArray();

            var index = 0;
            var currentTime = 0;

            processQueue.Enqueue(processes[index]);
            while (index < processes.Length - 1 &&
                   processes[index].ArrivalTime == processes[index + 1].ArrivalTime)
            {
                processQueue.Enqueue(processes[++index]);
            }

            processQueue = new Queue<Process>(processQueue.OrderBy(p => p.Priority));

            while (processQueue.Count != 0)
            {
                var currentProcess = processQueue.Dequeue();
                if (currentTime < currentProcess.ArrivalTime)
                {
                    currentTime = currentProcess.ArrivalTime;
                }

                if (index < processes.Length - 1)
                {
                    var pseudoExitTime = currentTime + currentProcess.BurstTime;
                    var nextProcess = processes[index + 1];
                    if (pseudoExitTime > nextProcess.ArrivalTime && currentProcess.Priority > nextProcess.Priority)
                    {
                        ganttChart.AddItem(new GanttItem()
                        {
                            Start = currentTime,
                            Exit = nextProcess.ArrivalTime,
                            ProcessName = currentProcess.ProcessName
                        });
                        currentTime = nextProcess.ArrivalTime;
                        processQueue.Enqueue(nextProcess);
                        currentProcess.BurstTime = pseudoExitTime - currentTime;
                        processQueue.Enqueue(currentProcess);
                    }
                    else
                    {
                        ganttChart.AddItem(new GanttItem()
                        {
                            Start = currentTime,
                            Exit = currentTime + currentProcess.BurstTime,
                            ProcessName = currentProcess.ProcessName
                        });
                        currentTime += currentProcess.BurstTime;
                    }
                }
                else
                {
                    ganttChart.AddItem(new GanttItem()
                    {
                        Start = currentTime,
                        Exit = currentTime + currentProcess.BurstTime,
                        ProcessName = currentProcess.ProcessName
                    });
                    currentTime += currentProcess.BurstTime;
                }

                if (index == processes.Length - 1 && processQueue.Count == 0)
                {
                    break;
                }

                if (index < processes.Length - 1)
                {
                    if (processQueue.Count == 0)
                    {
                        ++index;
                        processQueue.Enqueue(processes[index]);
                        while (index < processes.Length - 1 &&
                               processes[index].ArrivalTime == processes[index + 1].ArrivalTime)
                        {
                            ++index;
                            processQueue.Enqueue(processes[index]);
                        }
                    }

                    while (index < processes.Length - 1 && processes[index + 1].ArrivalTime <= currentTime)
                    {
                        ++index;
                        processQueue.Enqueue(processes[index]);
                    }
                }

                processQueue = new Queue<Process>(processQueue.OrderBy(p => p.Priority));
            }

            foreach (var process in processes)
            {
                var realProcess = processes.First(p => p.ProcessName == process.ProcessName);
                var tableItem = new TableItem()
                {
                    ArrivalTime = process.ArrivalTime,
                    ProcessName = process.ProcessName,
                    BurstTime = realProcess.BurstTime,
                    Priority = process.Priority
                };
                var ExitTime = 0;
                for (var i = ganttChart.GanttItems.Count - 1; i >= 0; i--)
                {
                    if (ganttChart.GanttItems[i].ProcessName != process.ProcessName) continue;
                    ExitTime = ganttChart.GanttItems[i].Exit;
                    break;
                }

                var FirstCome =
                    (from ganttChartGanttItem in ganttChart.GanttItems
                        where ganttChartGanttItem.ProcessName == process.ProcessName
                        select ganttChartGanttItem.Start).FirstOrDefault();

                tableItem.TurnAroundTime = ExitTime - process.ArrivalTime;
                // TODO warning
                tableItem.WaitingTime = tableItem.TurnAroundTime - process.BurstTime;
                tableItem.ResponseTime = FirstCome - process.ArrivalTime;

                tableResult.AddItem(tableItem);
            }


            return new Result(ganttChart, tableResult);
        }

        private static Result RR(Process[] processes, int quantumTime)
        {
            var tableResult = new Table();
            var ganttChart = new GanttChart();
            processes = processes.OrderBy(p => p.ArrivalTime).ToArray();
            var processQueue = new Queue<Process>(processes);

            var currentTime = 0;

            while (processQueue.Count > 0)
            {
                var currentProcess = processQueue.Dequeue();
                if (currentTime < currentProcess.ArrivalTime)
                {
                    currentTime = currentProcess.ArrivalTime;
                }

                var pseudoExitTime = currentTime + currentProcess.BurstTime;
                var isOutOfTime = !(currentTime + quantumTime >= pseudoExitTime);

                if (!isOutOfTime)
                {
                    ganttChart.AddItem(new GanttItem()
                    {
                        Start = currentTime,
                        Exit = pseudoExitTime,
                        ProcessName = currentProcess.ProcessName
                    });
                    currentTime += pseudoExitTime;
                }
                else
                {
                    ganttChart.AddItem(new GanttItem()
                    {
                        Start = currentTime,
                        Exit = currentTime + quantumTime,
                        ProcessName = currentProcess.ProcessName
                    });

                    currentTime += quantumTime;
                    var newProcess = new Process()
                    {
                        ProcessName = currentProcess.ProcessName,
                        ArrivalTime = currentProcess.ArrivalTime,
                        BurstTime = currentProcess.BurstTime - quantumTime
                    };
                   
                    processQueue.Enqueue(newProcess);
                }
            }

            foreach (var process in processes)
            {
                var tableItem = new TableItem()
                {
                    ProcessName = process.ProcessName,
                    ArrivalTime = process.ArrivalTime,
                    BurstTime = process.BurstTime,
                    Priority = process.Priority,
                };
                var exitTime = 0;
                for (var i = ganttChart.GanttItems.Count - 1; i >= 0; i--)
                {
                    var ganttChartGanttItem = ganttChart.GanttItems[i];
                    if (ganttChartGanttItem.ProcessName != process.ProcessName) continue;
                    exitTime = ganttChartGanttItem.Exit;
                    break;
                }

                var firstCome =
                    (from ganttChartGanttItem in ganttChart.GanttItems
                        where ganttChartGanttItem.ProcessName == process.ProcessName
                        select ganttChartGanttItem.Start).FirstOrDefault();
                tableItem.TurnAroundTime = exitTime - process.ArrivalTime;
                tableItem.WaitingTime = tableItem.TurnAroundTime - tableItem.BurstTime;
                tableItem.ResponseTime = firstCome - tableItem.ArrivalTime;
                
                tableResult.AddItem(tableItem);
            }


            return new Result(ganttChart, tableResult);
        }
    }
}