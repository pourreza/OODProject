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
    public partial class FirstMetricReport : MainPanel
    {
        private List<RadioButton> goals = new List<RadioButton>();
        private UserForm uf;

        public FirstMetricReport(UserForm uf)
        {
            this.uf = uf;
            InitializeComponent();

            this.goalPanel.AutoScroll = true;

            List<string> opGoals = Docs.DocFacade.GetDocsNames("OpGoals");
            for (int i = 0; i < opGoals.Count; i++)
            {
                RadioButton n = new RadioButton();
                n.Location = new Point(20, i * 20);
                n.Size = new Size(140, 15);
                n.Text = opGoals[i];
                this.goalPanel.Controls.Add(n);
                goals.Add(n);
            }

            headerLabel.Text = "برای مشاهده گزارش اندازه ها و متریک ها، هدف اجرایی موردنظر خود را انتخاب کنید:";
            headerLabel.Location = new Point(40, 10);
            headerLabel.Size = new Size(330, 15);

        }

        private void FirstMetricReport_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = -1;
            for (int i = 0; i < goals.Count; i++)
            {
                if (goals[i].Checked)
                    index = i;
            }
            if (index == -1)
                MessageBox.Show(this, "!هدف اجرایی ای برای مشاهده متریک ها انتخاب نشده است", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                string jsonData = Audits.AuditFacade.ReportDetailPlan(goals[index].Text);
                uf.ChangeMainPanel(new ChartReport(jsonData, true, uf));
            }
        }
    }
}
