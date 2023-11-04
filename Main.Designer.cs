namespace ScheduleCPU
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.AlgoCoB = new System.Windows.Forms.ComboBox();
            this.solveBtn = new System.Windows.Forms.Button();
            this.tableResult = new System.Windows.Forms.DataGridView();
            this.ProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArrivalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BurstTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlGantt = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.tableResult)).BeginInit();
            this.SuspendLayout();
            // 
            // AlgoCoB
            // 
            this.AlgoCoB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AlgoCoB.FormattingEnabled = true;
            this.AlgoCoB.Location = new System.Drawing.Point(12, 12);
            this.AlgoCoB.Name = "AlgoCoB";
            this.AlgoCoB.Size = new System.Drawing.Size(316, 24);
            this.AlgoCoB.TabIndex = 0;
            // 
            // solveBtn
            // 
            this.solveBtn.Location = new System.Drawing.Point(12, 42);
            this.solveBtn.Name = "solveBtn";
            this.solveBtn.Size = new System.Drawing.Size(316, 40);
            this.solveBtn.TabIndex = 3;
            this.solveBtn.Text = "Tính";
            this.solveBtn.UseVisualStyleBackColor = true;
            this.solveBtn.Click += new System.EventHandler(this.solveBtn_Click);
            // 
            // tableResult
            // 
            this.tableResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tableResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableResult.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tableResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.ProcessName, this.ArrivalTime, this.BurstTime });
            this.tableResult.Location = new System.Drawing.Point(12, 352);
            this.tableResult.Name = "tableResult";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableResult.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tableResult.RowTemplate.Height = 24;
            this.tableResult.Size = new System.Drawing.Size(1052, 390);
            this.tableResult.TabIndex = 5;
            // 
            // ProcessName
            // 
            this.ProcessName.HeaderText = "ProcessName";
            this.ProcessName.Name = "ProcessName";
            // 
            // ArrivalTime
            // 
            this.ArrivalTime.HeaderText = "ArrivalTime";
            this.ArrivalTime.Name = "ArrivalTime";
            // 
            // BurstTime
            // 
            this.BurstTime.HeaderText = "BurstTime";
            this.BurstTime.Name = "BurstTime";
            // 
            // pnlGantt
            // 
            this.pnlGantt.Location = new System.Drawing.Point(14, 88);
            this.pnlGantt.Name = "pnlGantt";
            this.pnlGantt.Size = new System.Drawing.Size(1050, 245);
            this.pnlGantt.TabIndex = 6;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 754);
            this.Controls.Add(this.pnlGantt);
            this.Controls.Add(this.tableResult);
            this.Controls.Add(this.solveBtn);
            this.Controls.Add(this.AlgoCoB);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.tableResult)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.FlowLayoutPanel pnlGantt;

        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArrivalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn BurstTime;

        private System.Windows.Forms.DataGridView tableResult;

        private System.Windows.Forms.Button solveBtn;

        private System.Windows.Forms.ComboBox AlgoCoB;

        #endregion
    }
}