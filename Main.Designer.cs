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
            this.AlgoCoB = new System.Windows.Forms.ComboBox();
            this.arrivalTimeTb = new System.Windows.Forms.TextBox();
            this.burstTimeTb = new System.Windows.Forms.TextBox();
            this.solveBtn = new System.Windows.Forms.Button();
            this.arrivalTimeLb = new System.Windows.Forms.Label();
            this.burstTimeLb = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
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
            // arrivalTimeTb
            // 
            this.arrivalTimeTb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.arrivalTimeTb.Location = new System.Drawing.Point(12, 64);
            this.arrivalTimeTb.Multiline = true;
            this.arrivalTimeTb.Name = "arrivalTimeTb";
            this.arrivalTimeTb.Size = new System.Drawing.Size(316, 37);
            this.arrivalTimeTb.TabIndex = 1;
            // 
            // burstTimeTb
            // 
            this.burstTimeTb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.burstTimeTb.Location = new System.Drawing.Point(12, 140);
            this.burstTimeTb.Multiline = true;
            this.burstTimeTb.Name = "burstTimeTb";
            this.burstTimeTb.Size = new System.Drawing.Size(316, 40);
            this.burstTimeTb.TabIndex = 2;
            // 
            // solveBtn
            // 
            this.solveBtn.Location = new System.Drawing.Point(12, 186);
            this.solveBtn.Name = "solveBtn";
            this.solveBtn.Size = new System.Drawing.Size(122, 40);
            this.solveBtn.TabIndex = 3;
            this.solveBtn.Text = "Tính";
            this.solveBtn.UseVisualStyleBackColor = true;
            // 
            // arrivalTimeLb
            // 
            this.arrivalTimeLb.Location = new System.Drawing.Point(12, 39);
            this.arrivalTimeLb.Name = "arrivalTimeLb";
            this.arrivalTimeLb.Size = new System.Drawing.Size(186, 22);
            this.arrivalTimeLb.TabIndex = 4;
            this.arrivalTimeLb.Text = "ArrivalTime";
            // 
            // burstTimeLb
            // 
            this.burstTimeLb.Location = new System.Drawing.Point(12, 115);
            this.burstTimeLb.Name = "burstTimeLb";
            this.burstTimeLb.Size = new System.Drawing.Size(186, 22);
            this.burstTimeLb.TabIndex = 4;
            this.burstTimeLb.Text = "BurstTime";
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.White;
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackColor = System.Drawing.Color.White;
            this.dataGrid1.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataGrid1.CaptionBackColor = System.Drawing.Color.Silver;
            this.dataGrid1.CaptionFont = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.dataGrid1.CaptionForeColor = System.Drawing.Color.Black;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Courier New", 9F);
            this.dataGrid1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.dataGrid1.GridLineColor = System.Drawing.Color.DarkGray;
            this.dataGrid1.HeaderBackColor = System.Drawing.Color.DarkGreen;
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.White;
            this.dataGrid1.LinkColor = System.Drawing.Color.DarkGreen;
            this.dataGrid1.Location = new System.Drawing.Point(357, 186);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.Black;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.DarkSeaGreen;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGrid1.Size = new System.Drawing.Size(707, 556);
            this.dataGrid1.TabIndex = 5;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 754);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.burstTimeLb);
            this.Controls.Add(this.arrivalTimeLb);
            this.Controls.Add(this.solveBtn);
            this.Controls.Add(this.burstTimeTb);
            this.Controls.Add(this.arrivalTimeTb);
            this.Controls.Add(this.AlgoCoB);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGrid dataGrid1;

        private System.Windows.Forms.Label arrivalTimeLb;
        private System.Windows.Forms.Label burstTimeLb;

        private System.Windows.Forms.Button solveBtn;

        private System.Windows.Forms.TextBox arrivalTimeTb;
        private System.Windows.Forms.TextBox burstTimeTb;

        private System.Windows.Forms.ComboBox AlgoCoB;

        #endregion
    }
}