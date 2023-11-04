using System.ComponentModel;

namespace ScheduleCPU.UserControls
{
    partial class GanttItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Start = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.Label();
            this.ProcessName = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.Transparent;
            this.Start.Location = new System.Drawing.Point(0, 33);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(34, 30);
            this.Start.TabIndex = 1;
            this.Start.Text = "222";
            this.Start.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(40, 33);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(51, 30);
            this.Exit.TabIndex = 1;
            this.Exit.Text = "999";
            this.Exit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProcessName
            // 
            this.ProcessName.Location = new System.Drawing.Point(12, 3);
            this.ProcessName.Name = "ProcessName";
            this.ProcessName.Size = new System.Drawing.Size(57, 36);
            this.ProcessName.TabIndex = 2;
            this.ProcessName.Text = "P1";
            this.ProcessName.UseVisualStyleBackColor = true;
            // 
            // GanttItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ProcessName);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Start);
            this.Name = "GanttItem";
            this.Size = new System.Drawing.Size(81, 60);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label Start;
        private System.Windows.Forms.Button ProcessName;
        private System.Windows.Forms.Label Exit;

        #endregion
    }
}