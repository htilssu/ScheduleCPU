using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var arrivalTime = arrivalTimeTb.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var arrivalTimeInt = Array.ConvertAll(arrivalTime, int.Parse);
            var burstTime = burstTimeTb.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var burstTimeInt = Array.ConvertAll(burstTime, int.Parse);
            SolveProblem.Solve(Algo.FCFS, arrivalTimeInt, burstTimeInt);
        }
    }
}