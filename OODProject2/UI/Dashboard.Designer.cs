namespace OODProject_2_.UI
{
    partial class Dashboard
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
        /// 
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.envGoalChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.metricChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.envGoalChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metricChart)).BeginInit();
            this.SuspendLayout();
            // 
            // envGoalChart
            // 
            chartArea1.Name = "ChartArea1";
            this.envGoalChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.envGoalChart.Legends.Add(legend1);
            this.envGoalChart.Location = new System.Drawing.Point(57, 48);
            this.envGoalChart.Name = "envGoalChart";
            this.envGoalChart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.envGoalChart.Series.Add(series1);
            this.envGoalChart.Size = new System.Drawing.Size(272, 91);
            this.envGoalChart.TabIndex = 1;
            this.envGoalChart.Text = "میزان پیشرفت اهداف کلان";
            // 
            // metricChart
            // 
            chartArea2.Name = "ChartArea1";
            this.metricChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.metricChart.Legends.Add(legend2);
            this.metricChart.Location = new System.Drawing.Point(57, 145);
            this.metricChart.Name = "metricChart";
            this.metricChart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.metricChart.Series.Add(series2);
            this.metricChart.Size = new System.Drawing.Size(270, 93);
            this.metricChart.TabIndex = 2;
            this.metricChart.Text = "chart1";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metricChart);
            this.Controls.Add(this.envGoalChart);
            this.Name = "D";
            this.Size = new System.Drawing.Size(387, 247);
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.Controls.SetChildIndex(this.envGoalChart, 0);
            this.Controls.SetChildIndex(this.metricChart, 0);
            this.Controls.SetChildIndex(this.headerLabel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.envGoalChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metricChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.DataVisualization.Charting.Chart envGoalChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart metricChart;
             
            
    }
}
