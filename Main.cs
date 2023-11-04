using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScheduleCPU
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            AddAlgoItem(AlgoCoB);
            AlgoCoB.SelectedItem = AlgoCoB.Items[0];
        }

        private static void AddAlgoItem(ComboBox comboBox)
        {
            foreach (var value in Enum.GetValues(typeof(Algo)))
            {
                comboBox.Items.Add(value);
            }
        }

        private void solveBtn_Click(object sender, EventArgs e)
        {
            var arrivalTime = ReadArrivalTime();
            var burstTime = ReadBurstTime();


            var algoSelected = (Algo)AlgoCoB.SelectedItem;
            var result = SolveProblem.Solve(algoSelected, arrivalTime, burstTime);
            WipeData();

            var bindingSource = new BindingSource();
            bindingSource.DataSource = result.Table.TableItems;
            tableResult.DataSource = bindingSource;
            InitGanttChart(result.GanttChart);
           
        }

        private int[] ReadArrivalTime()
        {
            var arrivalTime = new List<int>();
            foreach (DataGridViewRow tableResultRow in tableResult.Rows)
            {
                var value = tableResultRow.Cells[1].Value?.ToString();
                if (value != null)
                {
                    arrivalTime.Add(int.Parse(value));
                }
            }

            return arrivalTime.ToArray();
        }

        private int[] ReadBurstTime()
        {
            var burstTime = new List<int>();
            foreach (DataGridViewRow tableResultRow in tableResult.Rows)
            {
                var value = tableResultRow.Cells[2].Value?.ToString();
                if (value != null)
                {
                    burstTime.Add(int.Parse(value));
                }
            }

            return burstTime.ToArray();
        }

        private void WipeData()
        {
            tableResult.DataSource = null;

            tableResult.Rows.Clear();
            tableResult.Columns.Clear();
            pnlGantt.Controls.Clear();
            
        }

        private void InitGanttChart(GanttChart ganttChart)
        {
            foreach (var item in ganttChart.GanttItems)
            {
                pnlGantt.Controls.Add(new UserControls.GanttItem(item.ProcessName,item.Start.ToString(),item.Exit.ToString()));
            }
        }
        
    }
}