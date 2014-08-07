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
        private Label askTitle = new Label();
        private TextBox title = new TextBox();
        private Label askOpGoal = new Label();
        private ComboBox relatedGoal = new ComboBox();
        private Label askResponsibility = new Label();
        private Label askResource = new Label();
        private List<CheckBox> responsibilities = new List<CheckBox>();
        private List<CheckBox> resourcesList = new List<CheckBox>();
        private Label showDeadline = new Label();
        private Label deadline = new Label();

        private Boolean goalExists = false;

        private UserForm uf;
        private bool isEdit = false;
        private int index = 0;
        private Button back = new Button();
        private string ntitle;
        private string ngoal;
        private string[] nresources;
        private string[] nresps;

        public IAAddPlanPanel(string opGoals, string resources, string resps)
        {
            headerLabel.Text = "برنامه اقدام مربوط به هدف اجرایی موردنظر خود را مشخص کنید: ";
            headerLabel.Location = new Point(120, 10);
            headerLabel.Size = new Size(250, 18);

            InitializeComponent();

            askTitle.Location = new Point(310, 30);
            askTitle.Size = new Size(60, 15);
            askTitle.Text = "عنوان برنامه";

            title.Location = new Point(140, 30);
            title.Size = new System.Drawing.Size(160, 10);

            showDeadline.Location = new Point(80,52);
            showDeadline.Size = new System.Drawing.Size(60, 15);
            showDeadline.Text = "موعد اجرا";

            deadline.Location = new Point(20, 54);
            deadline.Size = new System.Drawing.Size(65, 15);
            deadline.Text = "1393/3/3";

            askOpGoal.Text = "هدف اجرایی";
            askOpGoal.Location = new Point(310, 50);
            askOpGoal.Size = new Size(60, 20);

            relatedGoal.Location = new Point(140, 50);
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

            relatedGoal.SelectionChangeCommitted += new EventHandler(this.selectionGoalChanged);

            Panel p1 = new Panel();
            p1.Location = new Point(208, 70);
            p1.Size = new Size(132, 110);
            p1.AutoScroll = true;
            
            Panel p2 = new Panel();
            p2.Location = new Point(13, 70);
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

            askResource.Location = new Point(340, 73);
            askResource.Size = new Size(30, 20);
            askResource.Text = "منابع";

            askResponsibility.Location = new Point(150, 73);
            askResponsibility.Size = new Size(50, 20);
            askResponsibility.Text = "مسئولیت ها";

            registerButton.Location = new Point(230, 193);
            registerButton.Click += new System.EventHandler(this.onRegisterClick);

            this.Controls.Add(askTitle);
            this.Controls.Add(title);
            this.Controls.Add(showDeadline);
            this.Controls.Add(deadline);
            this.Controls.Add(askOpGoal);
            this.Controls.Add(relatedGoal);
            this.Controls.Add(askResponsibility);
            this.Controls.Add(askResource);
            this.Controls.Add(p1);
            this.Controls.Add(p2);
        }

        public IAAddPlanPanel(string initialData, UserForm u, int index)
        {
            isEdit = true;
            this.uf = u;
            this.index = index;

            InitializeComponent();

            Dictionary<string, string> data = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(initialData);
            string opGoals = Plannings.PlanningFacade.GetDocs("OpGoals");
            string resources = Plannings.PlanningFacade.GetDocs("Resources");
            string resps = Plannings.PlanningFacade.GetDocs("Responsibilites");

            headerLabel.Text = "برنامه اقدام موردنظر خود را تغییر دهید: ";
            headerLabel.Location = new Point(120, 10);
            headerLabel.Size = new Size(250, 18);

            askTitle.Location = new Point(310, 30);
            askTitle.Size = new Size(60, 15);
            askTitle.Text = "عنوان برنامه";

            title.Location = new Point(140, 30);
            title.Size = new System.Drawing.Size(160, 10);
            title.Text = data["عنوان برنامه"];
            ntitle = title.Text;

            showDeadline.Location = new Point(80, 52);
            showDeadline.Size = new System.Drawing.Size(60, 15);
            showDeadline.Text = "موعد اجرا";

            deadline.Location = new Point(20, 54);
            deadline.Size = new System.Drawing.Size(65, 15);
            deadline.Text = "1393/3/3";

            askOpGoal.Text = "هدف اجرایی";
            askOpGoal.Location = new Point(310, 50);
            askOpGoal.Size = new Size(60, 20);

            relatedGoal.Location = new Point(140,50);
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
            
            int mm = 0;
            for (mm = 0; mm < relatedGoal.Items.Count; mm++)
                if (data["هدف مربوطه"].Equals(relatedGoal.Items[mm].ToString()))
                    break;

            relatedGoal.SelectedIndex = mm;
            relatedGoal.SelectionChangeCommitted += new EventHandler(this.selectionGoalChanged);
            ngoal = data["هدف مربوطه"];

            Panel p1 = new Panel();
            p1.Location = new Point(208, 70);
            p1.Size = new Size(132, 110);
            p1.AutoScroll = true;

            Panel p2 = new Panel();
            p2.Location = new Point(13, 70);
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

            nresps = data["مسئولیت ها"].Split('-');
            for (int l = 0; l<nresps.Length; l++)
                for (int kk=0; kk<responsibilities.Count; kk++)
                    if (nresps[l].Equals(responsibilities[kk].Text))
                        responsibilities[kk].Checked = true;

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

            nresources = data["منابع"].Split('-');
            for (int l = 0; l<nresources.Length; l++)
                for (int kk=0; kk<resourcesList.Count; kk++)
                    if (nresources[l].Equals(resourcesList[kk].Text))
                        resourcesList[kk].Checked = true;

            askResource.Location = new Point(340, 70);
            askResource.Size = new Size(30, 20);
            askResource.Text = "منابع";

            askResponsibility.Location = new Point(150, 70);
            askResponsibility.Size = new Size(50, 20);
            askResponsibility.Text = "مسئولیت ها";

            registerButton.Location = new Point(230, 193);
            registerButton.Click += new System.EventHandler(this.onRegisterClick);

            back.Location = new Point(135, 193);
            back.Size = new Size(60, 18);
            back.Text = "بازگشت";
            back.BackColor = Color.LightSkyBlue;
            back.Click += new System.EventHandler(this.onBackClick);
            this.Controls.Add(back);

            this.Controls.Add(askTitle);
            this.Controls.Add(title);
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

        private void selectionGoalChanged(object sender, EventArgs e)
        {
            string time = Plannings.PlanningFacade.GetDeadline(relatedGoal.SelectedItem.ToString());
            deadline.Text = PersianClass.ToPersianNumber(time);
        }

        private void onBackClick(object sender, EventArgs e)
        {
            uf.ChangeMainPanel(new DetailedViewPanel("برنامه موردنظر خود را برای ویرایش از لیست زیر انتخاب کنید:", "1Plans", true, false, uf));
        }

        private void onRegisterClick(object sender, EventArgs e)
        {
            if (goalExists)
            {
                int i = 0;
                List<string> selectedResps = new List<string>();
                string compressedResps = "";
                foreach (CheckBox indexChecked in responsibilities)
                    if (indexChecked.Checked)
                    {
                        selectedResps.Add(indexChecked.Text);
                        if (i == 0)
                            compressedResps += indexChecked.Text;
                        else
                            compressedResps = compressedResps + "-" + indexChecked.Text;
                        i++;
                    }


                int j = 0;
                List<string> selectedResources = new List<string>();
                string compressedResources = "";
                foreach (CheckBox index in resourcesList)
                    if (index.Checked)
                    {
                        selectedResources.Add(index.Text);
                        if (j == 0)
                            compressedResources += index.Text;
                        else
                            compressedResources = compressedResources + "-" + index.Text;
                        j++;
                    }

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
                    if (isEdit)
                    {
                        bool equal1 = true;
                        for (int k = 0; k < nresources.Length; k++)
                        {
                            bool found = false;
                            for (int kk = 0; kk < selectedResources.Count; kk++)
                                if (nresources[k].Equals(selectedResources[kk]))
                                    found = true;
                            if (!found)
                            {
                                equal1 = false;
                                break;
                            }
                        }
                        for (int k = 0; k < selectedResources.Count; k++)
                        {
                            bool found = false;
                            for (int kk=0; kk<nresources.Length; kk++)
                                if (nresources[kk].Equals(selectedResources[k]))
                                    found = true;
                            if (!found)
                            {
                                equal1 = false;
                                break;
                            }
                        }

                        bool equal2 = true;
                        for (int k = 0; k < nresps.Length; k++)
                        {
                            bool found = false;
                            for (int kk = 0; kk < selectedResps.Count; kk++)
                                if (nresps[k].Equals(selectedResps[kk]))
                                    found = true;
                            if (!found)
                            {
                                equal2 = false;
                                break;
                            }
                        }
                        for (int k = 0; k < selectedResps.Count; k++)
                        {
                            bool found = false;
                            for (int kk = 0; kk < nresps.Length; kk++)
                                if (nresps[kk].Equals(selectedResps[k]))
                                    found = true;
                            if (!found)
                            {
                                equal2 = false;
                                break;
                            }
                        }

                        if (equal1 && equal2 && ngoal.Equals(relatedGoal.SelectedItem.ToString()) && ntitle.Equals(title.Text))
                            MessageBox.Show(this, "!تغییری روی برنامه صورت نگرفته است", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            Dictionary<string, string> data = new Dictionary<string, string>();
                            data.Add("title", title.Text);
                            data.Add("opGoal", relatedGoal.SelectedItem.ToString());
                            data.Add("resources", compressedResources);
                            data.Add("responsibilities", compressedResps);
                            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                            bool isUpdated = Plannings.PlanningFacade.Update("Plans", index, jsonData);
                            if (!isUpdated)
                                MessageBox.Show(this, "!برنامه ای با عنوان یکسان قبلا در سامانه به ثبت رسیده است", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                                MessageBox.Show(this, "!برنامه با موفقیت تغییر یافت", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                uf.ChangeMainPanel(new DetailedViewPanel("برنامه موردنظر خود را برای ویرایش از لیست زیر انتخاب کنید:", "1Plans", true, false, uf));
                            }
                        }
                    }
                    else
                    {
                        Dictionary<string, string> data = new Dictionary<string, string>();
                        data.Add("title", title.Text);
                        data.Add("opGoal", relatedGoal.SelectedItem.ToString());
                        data.Add("resources", compressedResources);
                        data.Add("responsibilities", compressedResps);
                        string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                        bool added = Plannings.PlanningFacade.AddDoc("Plans", jsonData);
                        if (!added)
                        {
                            MessageBox.Show(this, "!برنامه ای با عنوان یکسان قبلا در سامانه به ثبت رسیده است", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            errorLable.Hide();
                            this.Hide();
                            UserForm.Confirm("برنامه موردنظر با موفقیت در سیستم به ثبت رسید.");
                        }
                    }
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
