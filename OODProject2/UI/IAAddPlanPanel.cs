using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OODProject_2_.UI
{
    public partial class IAAddPlanPanel : AddPanel
    {
        private Label askOpGoal = new Label();
        private ComboBox relatedGoal = new ComboBox();
        private Label askResponsibility = new Label();
        private Label askResource = new Label();
        private List<CheckBox> responsibilities = new List<CheckBox>();
        private List<CheckBox> resourcesList = new List<CheckBox>();

        private Boolean goalExists = false;

        public IAAddPlanPanel(string opGoals, string resources, string resps)
        {
            headerLabel.Text = "برنامه اقدام مربوط به هدف اجرایی موردنظر خود را مشخص کنید: ";
            headerLabel.Location = new Point(120, 10);
            headerLabel.Size = new Size(250, 18);

            InitializeComponent();

            askOpGoal.Text = "هدف اجرایی";
            askOpGoal.Location = new Point(310, 30);
            askOpGoal.Size = new Size(60, 20);

            relatedGoal.Location = new Point(140, 30);
            relatedGoal.Size = new Size(160, 7);
            relatedGoal.Text = "هدف اجرایی را انتخاب کنید.";

            Dictionary<int, string> goals = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<int, string>>(opGoals);
            int i = 0;
            foreach (KeyValuePair<int, string> entry in goals)
            {
                relatedGoal.Items.Add(entry.Value);
                goalExists = true;
                i++;
            }
            if (i == 0)
                relatedGoal.Text = "هدف اجرایی ای به ثبت نرسیده است.";

            Panel p1 = new Panel();
            p1.Location = new Point(208, 57);
            p1.Size = new Size(132, 110);
            p1.AutoScroll = true;

            Panel p2 = new Panel();
            p2.Location = new Point(13, 57);
            p2.Size = new Size(132, 110);
            p2.AutoScroll = true;

            Dictionary<int, string> ress = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<int, string>>(resps);
            int k = 0;
            foreach (KeyValuePair<int, string> entry in ress)
            {
                CheckBox c = new CheckBox();
                c.Text = entry.Value;
                c.Font = new Font("Nazanin", 10);
                c.Location = new Point(0, k * 20 + 3);
                c.Size = new Size(130, 15);
                responsibilities.Add(c);
                p2.Controls.Add(c);
                k++;
            }
            this.Controls.Add(p1);

            Dictionary<int, string> re = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<int, string>>(resources);
            int m = 0;
            foreach (KeyValuePair<int, string> entry in re)
            {
                CheckBox c = new CheckBox();
                c.Text = entry.Value;
                c.Location = new Point(0, m * 20 + 3);
                c.Size = new Size(130, 15);
                c.Font = new Font("Nazanin", 10);
                resourcesList.Add(c);
                p1.Controls.Add(c);
                m++;
            }
            this.Controls.Add(p2);

            askResource.Location = new Point(340, 60);
            askResource.Size = new Size(30, 20);
            askResource.Text = "منابع";

            askResponsibility.Location = new Point(150, 60);
            askResponsibility.Size = new Size(50, 20);
            askResponsibility.Text = "مسئولیت ها";

            registerButton.Location = new Point(230, 190);
            registerButton.Click += new System.EventHandler(this.onRegisterClick);

            this.Controls.Add(askOpGoal);
            this.Controls.Add(relatedGoal);
            this.Controls.Add(askResponsibility);
            this.Controls.Add(askResource);
            this.Controls.Add(p1);
            this.Controls.Add(p2);
        }

        private void IAAddPlanPanel_Load(object sender, EventArgs e)
        {

        }

        private void onRegisterClick(object sender, EventArgs e)
        {
            if (goalExists)
            {
                int i = 0;
                foreach (CheckBox indexChecked in responsibilities)
                    if (indexChecked.Checked)
                        i++;
                int j = 0;
                foreach (CheckBox index in resourcesList)
                    if (index.Checked)
                        j++;

                if (relatedGoal.SelectedItem == null)
                {
                    errorLable.Text = "لطفا هدف اجرایی مربوطه را انتخاب کنید!";
                    errorLable.Show();
                    errorLable.Location = new Point(185, 380);
                    errorLable.Size = new Size(220, 20);
                }
                else if (i == 0)
                {
                    errorLable.Text = "لطفا مسئولیت های مربوطه را انتخاب کنید!";
                    errorLable.Show();
                    errorLable.Location = new Point(185, 380);
                    errorLable.Size = new Size(220, 20);
                }
                else if (j == 0)
                {
                    errorLable.Text = "لطفا منابع مربوطه را انتخاب کنید!";
                    errorLable.Show();
                    errorLable.Location = new Point(185, 380);
                    errorLable.Size = new Size(220, 20);
                }
                else
                {
                    errorLable.Hide();
                    this.Hide();
                    UserForm.Confirm("برنامه موردنظر با موفقیت در سیستم به ثبت رسید.");
                }
            }
            else
            {
                errorLable.Show();
                errorLable.Text = "ابتدا هدف اجرایی باید به ثبت برسد!";
                errorLable.Location = new Point(210, 380);
                errorLable.Size = new Size(190, 20);
            }
        }

    }
}
