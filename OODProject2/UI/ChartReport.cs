using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OODProject_2_.UI
{
    public partial class ChartReport : MainPanel
    {
        private bool isMetric = false;
        private UserForm uf;

        public ChartReport(string jsonData, bool isMetric, UserForm uf)
        {
            this.isMetric = isMetric;
            this.uf = uf;

            InitializeComponent();

            headerLabel.Location = new Point(90, 10);
            headerLabel.Size = new Size(280, 15);
            if (isMetric)
            {
                headerLabel.Text = "درصد اندازه گیری شده برای متریک های هدف انتخاب شده به صورت زیر است:";
                this.reportChart.Titles.Add("درصد اندازه گیری شده متریک های هدف");
            }
            else
            {
                headerLabel.Text = "میزان پیشرفت مسئولیت های برنامه انتخاب شده به صورت زیر است:";
                this.reportChart.Titles.Add("درصد پیشرفت مسئولیت های برنامه");
            }

            Dictionary<string, int> reportData = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, int>>(jsonData);
            List<int> y = new List<int>();
            List<string> x = new List<string>();
            foreach (KeyValuePair<string, int> entry in reportData)
            {
                y.Add(entry.Value);
                x.Add(entry.Key);
            }


            int[] yValues = y.ToArray();
            string[] xValues = x.ToArray();

            // Set palette.
            this.reportChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;

            reportChart.Series.RemoveAt(0);
            // Add series.
            for (int i = 0; i < xValues.Length; i++)
            {
                // Add series.
                System.Windows.Forms.DataVisualization.Charting.Series series = this.reportChart.Series.Add(xValues[i]);

                // Add point.
                series.Points.Add(yValues[i]);
            }
            
        }

        private void ChartReport_Load(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            if (isMetric)
            {
                uf.ChangeMainPanel(new FirstMetricReport(uf));
            }
            else
            {
                uf.ChangeMainPanel(new FirstViewReport(false, uf));
            }
        }
    }
}
