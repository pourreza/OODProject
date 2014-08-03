namespace OODProject_2_.UI
{
    partial class ChartReport
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.reportChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.reportChart)).BeginInit();
            this.SuspendLayout();
            // 
            // reportChart
            // 
            chartArea2.Name = "ChartArea1";
            this.reportChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.reportChart.Legends.Add(legend2);
            this.reportChart.Location = new System.Drawing.Point(54, 46);
            this.reportChart.Name = "reportChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.reportChart.Series.Add(series2);
            this.reportChart.Size = new System.Drawing.Size(286, 143);
            this.reportChart.TabIndex = 1;
            this.reportChart.Text = "chart1";
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.LightSkyBlue;
            this.back.Location = new System.Drawing.Point(173, 204);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(60, 20);
            this.back.TabIndex = 2;
            this.back.Text = "بازگشت";
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // ChartReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.back);
            this.Controls.Add(this.reportChart);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ChartReport";
            this.Size = new System.Drawing.Size(385, 247);
            this.Load += new System.EventHandler(this.ChartReport_Load);
            this.Controls.SetChildIndex(this.headerLabel, 0);
            this.Controls.SetChildIndex(this.reportChart, 0);
            this.Controls.SetChildIndex(this.back, 0);
            ((System.ComponentModel.ISupportInitialize)(this.reportChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart reportChart;
        private System.Windows.Forms.Button back;
    }
}
