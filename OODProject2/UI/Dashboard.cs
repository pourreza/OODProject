using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace OODProject_2_.UI
{
    public partial class Dashboard : MainPanel
    {
        private string welcome;
       
        public Dashboard(String userType, Boolean gender, String fullName, String jsonDataGoal, String jsonDataMetric)
        {
            /*
            InitializeComponent();
            if (gender == true) // if user is female
                welcome = "کاربر گرامی سرکار خانم ";
            else
                welcome = "کاربر گرامی جناب آقای ";
            welcome += fullName;

            Label info = new Label();
            info.Location = new Point(120, 30);
            info.Size = new Size(260, 18);
            this.Controls.Add(info);

            if (userType.Equals("SA"))
            {
                // if user is Senior Authority
                this.envGoalChart.Titles.Add("میزان پیشرفت در تحقق اهداف کلان به درصد");
                welcome += " به زیر سامانه سند مدیریت محیطی خوش آمدید.";
                info.Text = "دو نمودار زیر آخرین تغییرات ثبت شده در سامانه را نشان می دهند:";
            }
            else if (userType.Equals("IA"))
            {
                //if user is Intermediate Authority
                this.envGoalChart.Titles.Add("میزان پیشرفت در تحقق اهداف اجرایی به درصد");
                welcome += " به زیر سامانه برنامه ریزی مدیریت محیطی خوش آمدید.";
                info.Text = "دو نمودار زیر آخرین تغییرات ثبت شده در سامانه را نشان می دهند:";
            }
            else if (userType.Equals("I"))
            {
                // if user is Inspector
                welcome += " به زیرسامانه حسابرسی و بازرسی خوش آمدید.";
                info.Text ="نمودار زیر آخرین درصد اندازه گیری شده برای متریک ها را نشان می دهد:";
                info.Location = new Point(100, 30);
                info.Size = new Size(280, 18);
                metricChart.Location = new Point(49, 68);
                metricChart.Size = new Size(300, 120);
            }
            this.metricChart.Titles.Add("آخرین درصدهای اندازه گیری شده ی متریک ها");

            headerLabel.Text = welcome;
            headerLabel.Location = new Point(70, 10);
            headerLabel.Size = new Size(310, 18);
            envGoalChart.Hide();
            if (userType != "I")
            {
                envGoalChart.Show();
                Dictionary<string, int> goals = JsonConvert.DeserializeObject<Dictionary<string, int>>(jsonDataGoal);
                List<int> y = new List<int>();
                List<string> x = new List<string>();
                foreach (KeyValuePair<string, int> entry in goals)
                {
                    y.Add(entry.Value);
                    x.Add(entry.Key);
                }


                int[] yValues = y.ToArray();
                string[] xValues = x.ToArray();

                // Set palette.
                this.envGoalChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;

                // Set title.
                envGoalChart.Series.RemoveAt(0);
                // Add series.
                for (int i = 0; i < xValues.Length; i++)
                {
                    // Add series.
                    System.Windows.Forms.DataVisualization.Charting.Series series = this.envGoalChart.Series.Add(xValues[i]);

                    // Add point.
                    series.Points.Add(yValues[i]);
                }
            }
            Dictionary<string, int> metrics = JsonConvert.DeserializeObject<Dictionary<string, int>>(jsonDataMetric);
            List<int> y2 = new List<int>();
            List<string> x2 = new List<string>();
            foreach (KeyValuePair<string, int> entry in metrics)
            {
                y2.Add(entry.Value);
                x2.Add(entry.Key);
            }


            int[] yValues2 = y2.ToArray();
            string[] xValues2 = x2.ToArray();

            // Set palette.
            this.metricChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;

            // Set title.
            metricChart.Series.RemoveAt(0);
            // Add series.
            for (int i = 0; i < xValues2.Length; i++)
            {
                // Add series.
                System.Windows.Forms.DataVisualization.Charting.Series series = this.metricChart.Series.Add(xValues2[i]);

                // Add point.
                series.Points.Add(yValues2[i]);
            }
            
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
*/
        }
    }
}
