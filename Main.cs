using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            var priority = ReadPriority();

            int.TryParse(tbQuantumTime.Text, out var quantumTime);
            var algoSelected = (Algo)AlgoCoB.SelectedItem;
            var result = SolveProblem.Solve(algoSelected, arrivalTime, burstTime, priority,
                quantumTime);
            WipeData();

            var bindingSource = new BindingSource();
            bindingSource.DataSource = result.Table.TableItems;
            tableResult.DataSource = bindingSource;
            InitGanttChart(result.GanttChart);
        }

        private int[] ReadArrivalTime()
        {
            return (from DataGridViewRow tableResultRow
                    in tableResult.Rows
                select tableResultRow.Cells[1].Value?.ToString()
                into value
                where value != null
                select int.Parse(value)).ToArray();
        }

        private int[] ReadBurstTime()
        {
            return (from DataGridViewRow tableResultRow
                    in tableResult.Rows
                select tableResultRow.Cells[2].Value?.ToString()
                into value
                where value != null
                select int.Parse(value)).ToArray();
        }

        private int[] ReadPriority()
        {
            List<int> list = new List<int>();
            foreach (DataGridViewRow row in tableResult.Rows)
            {
                var value = row.Cells[3].Value?.ToString();
                list.Add(value != null ? int.Parse(value) : 0);
            }

            list.RemoveAt(list.Count - 1);
            return list.ToArray();
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
                pnlGantt.Controls.Add(new UserControls.GanttItem(item.ProcessName, item.Start.ToString(),
                    item.Exit.ToString()));
            }
        }


        private void HideQuantumTb()
        {
            tbQuantumTime.Visible = false;
        }

        private void ShowQuantumTb()
        {
            tbQuantumTime.Visible = true;
        }

        private void ChangeAlgoSelection(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            if ((Algo)comboBox.SelectedItem == Algo.RR)
            {
                ShowQuantumTb();
            }
            else
            {
                HideQuantumTb();
            }
        }
    }
}