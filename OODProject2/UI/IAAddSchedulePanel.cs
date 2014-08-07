using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FarsiLibrary.Win.Controls;

namespace OODProject_2_.UI
{
    public partial class IAAddSchedulePanel : AddPanel
    {
        private Label askPlan = new Label();
        private ComboBox relatedPlan = new ComboBox();
        private List<Label> resps = new List<Label>();
        private List<FADatePicker> beginDate = new List<FADatePicker>();
        private List<FADatePicker> finishDate = new List<FADatePicker>();
        private Panel respPanel = new Panel();
        private Label planDeadline = new Label();

        private bool planExists = false;
        private string planDate = "";

        private UserForm uf;
        private bool isEdit = false;
        private int index = 0;
        private Button back = new Button();
        private string nplan;
        private string[] nresps;
        private string[] nfirstDates;
        private string[] nsecondDates;

        public IAAddSchedulePanel()
        {
            headerLabel.Text = "ابتدا هدف مربوط به برنامه موردنظر خود را انتخاب کرده، سپس زمان بندی مسئولیت های آن\nرا مشخص کنید: ";
            headerLabel.Location = new Point(20, 10);
            headerLabel.Size = new Size(350, 28);
            InitializeComponent();

            askPlan.Location = new Point(310, 40);
            askPlan.Size = new System.Drawing.Size(60, 15);
            askPlan.Text = "برنامه مربوطه";
            this.Controls.Add(askPlan);

            Label showDeadline = new Label();
            showDeadline.Location = new Point(90, 42);
            showDeadline.Size = new Size(50, 15);
            showDeadline.Text = "موعد اجرا";
            this.Controls.Add(showDeadline);

            planDeadline.Location = new Point(30, 43);
            planDeadline.Size = new Size(60, 15);
            this.Controls.Add(planDeadline);

            relatedPlan.Location = new Point(140, 40);
            relatedPlan.Size = new System.Drawing.Size(160, 15);

            relatedPlan.Text = "برنامه را انتخاب کنید.";
            this.Controls.Add(relatedPlan);

            string planJSon = Plannings.PlanningFacade.GetDocs("Plans");
            Dictionary<int, string> plans = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<int, string>>(planJSon);
            int i = 0;
            foreach (KeyValuePair<int, string> entry in plans)
            {
                relatedPlan.Items.Add(entry.Value);
                planExists = true;
                i++;
            }
            if (i == 0)
                relatedPlan.Text = "برنامه ای به ثبت نرسیده است.";

            Label numHd = new Label();
            Label respHd = new Label();
            Label beginHd = new Label();
            Label endHd = new Label();

            numHd.Location = new Point(320, 70);
            respHd.Location = new Point(260, 70);
            beginHd.Location = new Point(100, 70);
            endHd.Location = new Point(30, 70);

            numHd.Font = new System.Drawing.Font("Nazanin", 11, FontStyle.Bold);
            respHd.Font = new System.Drawing.Font("Nazanin", 11, FontStyle.Bold);
            beginHd.Font = new System.Drawing.Font("Nazanin", 11, FontStyle.Bold);
            endHd.Font = new System.Drawing.Font("Nazanin", 11, FontStyle.Bold);

            numHd.Size = new Size(40, 15);
            respHd.Size = new Size(60, 15);
            beginHd.Size = new Size(60, 15);
            endHd.Size = new Size(60, 15);

            numHd.Text = "ردیف";
            respHd.Text = "مسئولیت ها";
            beginHd.Text = "زمان شروع";
            endHd.Text = "زمان پایان";

            this.Controls.Add(numHd);
            this.Controls.Add(respHd);
            this.Controls.Add(beginHd);
            this.Controls.Add(endHd);

            respPanel.Location = new Point(30, 75);
            respPanel.Size = new System.Drawing.Size(340, 120);
            respPanel.AutoScroll = true;
            this.Controls.Add(respPanel);

            relatedPlan.SelectionChangeCommitted += new EventHandler(this.relatedPlan_SelectedIndexChanged);

            registerButton.Location = new Point(230, 200);
            registerButton.Click += new System.EventHandler(this.onRegisterClick);    
        }

        public IAAddSchedulePanel(string initialData, UserForm u, int index)
        {
            isEdit = true;
            this.uf = u;
            this.index = index;

            Dictionary<string, string> data = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(initialData);

            headerLabel.Text = "زمان بندی مسئولیت های برنامه ی موردنظر خود را تغییر دهید: ";
            headerLabel.Location = new Point(20, 10);
            headerLabel.Size = new Size(350, 28);
            InitializeComponent();

            askPlan.Location = new Point(310, 40);
            askPlan.Size = new System.Drawing.Size(60, 15);
            askPlan.Text = "برنامه مربوطه";
            this.Controls.Add(askPlan);

            Label showDeadline = new Label();
            showDeadline.Location = new Point(90, 42);
            showDeadline.Size = new Size(50, 15);
            showDeadline.Text = "موعد اجرا";
            this.Controls.Add(showDeadline);

            planDeadline.Location = new Point(30, 43);
            planDeadline.Size = new Size(60, 15);
            this.Controls.Add(planDeadline);
            planDate = Plannings.PlanningFacade.GetDeadline(Plannings.PlanningFacade.GetRelatedGoal(data["برنامه مربوطه"]));
            planDeadline.Text = planDate;

            Label relatedPlanLabel = new Label();
            relatedPlanLabel.Location = new Point(140, 40);
            relatedPlanLabel.Size = new System.Drawing.Size(160, 15);
            relatedPlanLabel.Text = data["برنامه مربوطه"];
            this.Controls.Add(relatedPlanLabel);
            
            Label numHd = new Label();
            Label respHd = new Label();
            Label beginHd = new Label();
            Label endHd = new Label();

            numHd.Location = new Point(320, 70);
            respHd.Location = new Point(260, 70);
            beginHd.Location = new Point(100, 70);
            endHd.Location = new Point(30, 70);

            numHd.Font = new System.Drawing.Font("Nazanin", 11, FontStyle.Bold);
            respHd.Font = new System.Drawing.Font("Nazanin", 11, FontStyle.Bold);
            beginHd.Font = new System.Drawing.Font("Nazanin", 11, FontStyle.Bold);
            endHd.Font = new System.Drawing.Font("Nazanin", 11, FontStyle.Bold);

            numHd.Size = new Size(40, 15);
            respHd.Size = new Size(60, 15);
            beginHd.Size = new Size(60, 15);
            endHd.Size = new Size(60, 15);

            numHd.Text = "ردیف";
            respHd.Text = "مسئولیت ها";
            beginHd.Text = "زمان شروع";
            endHd.Text = "زمان پایان";

            nresps = data["مسئولیت ها"].Split('-');
            nfirstDates = data["زمان شروع"].Split('-');
            nsecondDates = data["زمان پایان"].Split('-');

            respPanel.RightToLeft = RightToLeft.Yes;
            for (int i = 0; i < nresps.Length; i++)
            {
                Label count = new Label();
                count.Location = new Point(390, i * 20 + 25);
                count.Size = new Size(40, 15);
                count.Text = PersianClass.ToPersianNumber((i + 1).ToString());
                respPanel.Controls.Add(count);

                Label respName = new Label();
                respName.Location = new Point(195, i * 20 + 25);
                respName.Size = new Size(190, 20);
                respName.Text = PersianClass.ToPersianNumber(nresps[i]);
                resps.Add(respName);
                respPanel.Controls.Add(respName);

                FADatePicker begin = new FADatePicker();
                begin.Location = new Point(100, i * 20 + 25);
                begin.Size = new Size(85, 20);
                beginDate.Add(begin);
                respPanel.Controls.Add(begin);
                begin.SelectedDateTime = FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(Convert.ToDateTime(nfirstDates[i]));

                FADatePicker end = new FADatePicker();
                end.Location = new Point(6, i * 20 + 25);
                end.Size = new Size(85, 20);
                finishDate.Add(end);
                respPanel.Controls.Add(end);
                end.SelectedDateTime = FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(Convert.ToDateTime(nsecondDates[i]));
            }

            this.Controls.Add(numHd);
            this.Controls.Add(respHd);
            this.Controls.Add(beginHd);
            this.Controls.Add(endHd);

            respPanel.Location = new Point(30, 75);
            respPanel.Size = new System.Drawing.Size(340, 120);
            respPanel.AutoScroll = true;
            this.Controls.Add(respPanel);

            relatedPlan.SelectionChangeCommitted += new EventHandler(this.relatedPlan_SelectedIndexChanged);

            registerButton.Location = new Point(230, 200);
            registerButton.Click += new System.EventHandler(this.onRegisterClick);

            back.Location = new Point(135, 200);
            back.Size = new Size(60, 18);
            back.Text = "بازگشت";
            back.BackColor = Color.LightSkyBlue;
            back.Click += new System.EventHandler(this.onBackClick);
            this.Controls.Add(back);
        }

        private void IAAddSchedulePanel_Load(object sender, EventArgs e)
        {

        }

        private void onBackClick(object sender, EventArgs e)
        {
            uf.ChangeMainPanel(new DetailedViewPanel("زمان بندی موردنظر خود را برای ویرایش از لیست زیر انتخاب کنید:", "1Schedules", true, false, uf));
        }

        private void relatedPlan_SelectedIndexChanged(Object sender, EventArgs e)
        {
            string plan = relatedPlan.SelectedItem.ToString();
            planDate = Plannings.PlanningFacade.GetDeadline(Plannings.PlanningFacade.GetRelatedGoal(plan));
            planDeadline.Text = PersianClass.ToPersianNumber(planDate);
            List<string> ress = Plannings.PlanningFacade.GetRelatedResponsibilites(plan);
            respPanel.RightToLeft = RightToLeft.Yes;
            for (int i = 0; i < ress.Count; i++)
            {
                Label count = new Label();
                count.Location = new Point(390,i*20+25);
                count.Size = new Size(40, 15);
                count.Text = PersianClass.ToPersianNumber((i + 1).ToString());
                respPanel.Controls.Add(count);

                Label respName = new Label();
                respName.Location = new Point(195, i * 20 + 25);
                respName.Size = new Size(190, 20);
                respName.Text = PersianClass.ToPersianNumber(ress[i]);
                resps.Add(respName);
                respPanel.Controls.Add(respName);

                FADatePicker begin = new FADatePicker();
                begin.Location = new Point(100, i * 20 + 25);
                begin.Size = new Size(85, 20);
                beginDate.Add(begin);
                respPanel.Controls.Add(begin);
                begin.SelectedDateTime = FarsiLibrary.Utils.PersianDate.Now;

                FADatePicker end = new FADatePicker();
                end.Location = new Point(6, i * 20 + 25);
                end.Size = new Size(85, 20);
                finishDate.Add(end);
                respPanel.Controls.Add(end);
                end.SelectedDateTime = FarsiLibrary.Utils.PersianDate.Now;
            }
        }

        private void onRegisterClick(object sender, EventArgs e)
        {
            if (planExists)
            {
                bool acceptedTime = true;
                for (int i=0; i<beginDate.Count; i++)
                {
                    if (!(beginDate[i].SelectedDateTime.CompareTo(FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(Convert.ToDateTime(planDate)))<=0 && (FarsiLibrary.Utils.PersianDate.Now).CompareTo(FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(beginDate[i].SelectedDateTime))<=0 &(FarsiLibrary.Utils.PersianDate.Now).CompareTo(FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(finishDate[i].SelectedDateTime))<=0 && finishDate[i].SelectedDateTime.CompareTo(FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(Convert.ToDateTime(planDate)))<=0 && beginDate[i].SelectedDateTime.CompareTo(finishDate[i].SelectedDateTime)<=0))
                        acceptedTime = false;
                }
                if (relatedPlan.SelectedItem == null)
                {
                    errorLable.Show();
                    errorLable.Text = "ابتدا باید برنامه ی موردنظر را انتخاب کنید!";
                    errorLable.Location = new Point(180, 390);
                    errorLable.Size = new Size(230, 20);
                }
                else if (!acceptedTime)
                {
                    errorLable.Show();
                    errorLable.Text = "زمان تعیین شده برای مسئولیت ها باید بین زمان حال تا موعد اجرای برنامه و \nهمچنین زمان های شروع پیش از زمان های پایان باشند!";
                    errorLable.Location = new Point(25, 385);
                    errorLable.Size = new Size(380, 45);
                }
                else
                {
                    bool equal = true;
                    string selectedFirstDates = "";
                    string selectedEndDates = "";
                    for (int m = 0; m < nfirstDates.Length; m++)
                    {
                        if (m == 0)
                        {
                            selectedEndDates += finishDate[m].SelectedDateTime.ToShortTimeString();
                            selectedFirstDates += beginDate[m].SelectedDateTime.ToShortTimeString();
                        }
                        else
                        {
                            selectedEndDates += "-" + finishDate[m].SelectedDateTime.ToShortTimeString();
                            selectedFirstDates += "-" + beginDate[m].SelectedDateTime.ToShortTimeString();
                        }

                        if (beginDate[m].SelectedDateTime.CompareTo(FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(Convert.ToDateTime(nfirstDates[m]))) != 0)
                            equal = false;
                        if (finishDate[m].SelectedDateTime.CompareTo(FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(Convert.ToDateTime(nsecondDates[m]))) != 0)
                            equal = false;
                    }

                    if (isEdit)
                    {
                        if (equal)
                        {
                            MessageBox.Show(this, "!تغییری روی زمان بندی صورت نگرفته است", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            Dictionary<string, string> data = new Dictionary<string, string>();
                            data.Add("plan", nplan);
                            data.Add("beginDates", selectedFirstDates);
                            data.Add("endDates", selectedEndDates);
                            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                            bool isUpdated = Plannings.PlanningFacade.Update("Schedules", index, jsonData);
                            if (!isUpdated)
                                MessageBox.Show(this, "!زمان بندی تغییر نیافت", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                                MessageBox.Show(this, "!زمان بندی با موفقیت تغییر یافت", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                uf.ChangeMainPanel(new DetailedViewPanel("زمان بندی موردنظر خود را برای ویرایش از لیست زیر انتخاب کنید:", "1Schedules", true, false, uf));
                            }
                        }
                    }
                    else
                    {
                        Dictionary<string, string> data = new Dictionary<string, string>();
                        data.Add("title", relatedPlan.SelectedItem.ToString());
                        data.Add("beginDates", selectedFirstDates);
                        data.Add("endDates", selectedEndDates);
                        string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                        bool added = Plannings.PlanningFacade.AddDoc("Schedules", jsonData);
                        if (!added)
                        {
                            MessageBox.Show(this, "!زمان بندی برای این برنامه قبلا در سامانه به ثبت رسیده است", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            errorLable.Hide();
                            this.Hide();
                            UserForm.Confirm("زمان بندی موردنظر با موفقیت در سیستم به ثبت رسید.");
                        }
                    }
                }
            }
            else
            {
                errorLable.Show();
                errorLable.Text = "ابتدا برنامه ای باید به ثبت برسد!";
                errorLable.Location = new Point(180, 390);
                errorLable.Size = new Size(230, 20);
            }
        }
    }
}

