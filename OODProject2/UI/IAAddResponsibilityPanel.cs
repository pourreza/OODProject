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
    public partial class IAAddResponsibilityPanel : AddPanel
    {
        private List<RadioButton> orgUnits = new List<RadioButton>();
        private Label askOrg = new Label();
        private Label askTitle = new Label();
        private TextBox title = new TextBox();

        private UserForm uf;
        private bool isEdit = false;
        private int index = 0;
        private Button back = new Button();
        private string ntitle;
        private string nOrg;

        public IAAddResponsibilityPanel(string orgs)
        {
            headerLabel.Text = "لطفا مسئولیت جدید موردنظر خود را وارد کنید: ";

            InitializeComponent();

            askTitle.Location = new Point(300, 50);
            askTitle.Text = "عنوان مسئولیت";
            askTitle.Size = new Size(40, 20);

            title.Location = new Point(72, 50);
            title.Size = new Size(200, 20);

            askOrg.Location = new Point(280, 70);
            askOrg.Text = "واحد مسئول";
            askOrg.Size = new Size(60, 20);

            Panel p = new Panel();
            p.AutoScroll = true;
            //p.BackColor = Color.AliceBlue;
            p.Location = new Point(73, 70);
            p.Size = new Size(197, 110);

            Dictionary<int, string> names = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<int, string>>(orgs);
            int i = 0;
            foreach (KeyValuePair<int, string> entry in names)
            {
                RadioButton n = new RadioButton();
                n.Location = new Point(55, i * 20);
                n.Size = new Size(140, 15);
                n.Text = entry.Value;
                p.Controls.Add(n);
                orgUnits.Add(n);
                i++;
            }
            registerButton.Location = new Point(200, 180);
            registerButton.Click += new System.EventHandler(this.onRegisterClick);
            this.Controls.Add(askTitle);
            this.Controls.Add(askOrg);
            this.Controls.Add(title);
            this.Controls.Add(p);
        }

        public IAAddResponsibilityPanel(string initialData, UserForm u, int index)
        {
            isEdit = true;
            this.uf = u;
            this.index = index;

            InitializeComponent();

            Dictionary<string, string> data = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(initialData);

            headerLabel.Text = "مسئولیت موردنظر خود را تغییر دهید: ";

            askTitle.Location = new Point(300, 50);
            askTitle.Text = "عنوان مسئولیت";
            askTitle.Size = new Size(40, 20);

            title.Location = new Point(72, 50);
            title.Size = new Size(200, 20);
            title.Text = data["عنوان مسئولیت"];
            ntitle = title.Text;

            askOrg.Location = new Point(280, 70);
            askOrg.Text = "واحد مسئول";
            askOrg.Size = new Size(60, 20);

            Panel p = new Panel();
            p.AutoScroll = true;
            //p.BackColor = Color.AliceBlue;
            p.Location = new Point(73, 70);
            p.Size = new Size(197, 110);

            string orgs = Plannings.PlanningFacade.GetDocs("OrgUnits");
            Dictionary<int, string> names = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<int, string>>(orgs);
            int i = 0;
            foreach (KeyValuePair<int, string> entry in names)
            {
                RadioButton n = new RadioButton();
                n.Location = new Point(55, i * 20);
                n.Size = new Size(140, 15);
                n.Text = entry.Value;
                p.Controls.Add(n);
                orgUnits.Add(n);
                i++;
            }

            for (int k = 0; k < orgUnits.Count; k++)
                if (data["واحد مسئول"].Equals(orgUnits[k].Text))
                    orgUnits[k].Checked = true;
            nOrg = data["واحد مسئول"];

            registerButton.Location = new Point(200, 180);
            registerButton.Click += new System.EventHandler(this.onRegisterClick);

            back.Location = new Point(135, 180);
            back.Size = new Size(60, 18);
            back.Text = "بازگشت";
            back.BackColor = Color.LightSkyBlue;
            back.Click += new System.EventHandler(this.onBackClick);
            this.Controls.Add(back);

            this.Controls.Add(askTitle);
            this.Controls.Add(askOrg);
            this.Controls.Add(title);
            this.Controls.Add(p);
        }

        private void IAAddResponsibilityPanel_Load(object sender, EventArgs e)
        {

        }

        private void onBackClick(object sender, EventArgs e)
        {
            uf.ChangeMainPanel(new DetailedViewPanel("مسئولیت موردنظر خود را برای ویرایش از لیست زیر انتخاب کنید:", "1Responsibilties", true, false, uf));
        }

        private void onRegisterClick(object sender, EventArgs e)
        {
            int i = 0;
            string checkedOrg = "";
            foreach (RadioButton indexChecked in orgUnits)
                if (indexChecked.Checked)
                {
                    checkedOrg = indexChecked.Text;
                    i++;
                }

            if (title.Text.Equals(""))
            {
                errorLable.Text = "لطفا عنوان مسئولیت را وارد کنید!";
                errorLable.Show();
                errorLable.Location = new Point(180, 360);
                errorLable.Size = new Size(190, 20);
            }
            else if (i == 0)
            {
                errorLable.Text = "لطفا واحد مسئول را انتخاب کنید!";
                errorLable.Show();
                errorLable.Location = new Point(178, 360);
                errorLable.Size = new Size(190, 20);
            }
            else
            {
                if (isEdit)
                {
                    if (ntitle.Equals(title.Text) && nOrg.Equals(checkedOrg))
                        MessageBox.Show(this, "!تغییری روی مسئولیت صورت نگرفته است", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        Dictionary<string, string> data = new Dictionary<string, string>();
                        data.Add("title", title.Text);
                        data.Add("orgUnit", checkedOrg);
                        string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                        bool isUpdated = Plannings.PlanningFacade.Update("Responsibilities", index, jsonData);
                        if (!isUpdated)
                            MessageBox.Show(this, "!مسئولیتی با عنوان یکسان قبلا در سامانه به ثبت رسیده است", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            MessageBox.Show(this, "!مسئولیت با موفقیت تغییر یافت", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            uf.ChangeMainPanel(new DetailedViewPanel("مسئولیت موردنظر خود را برای ویرایش از لیست زیر انتخاب کنید:", "1Responsibilties", true, false, uf));
                        }
                    }
                }
                else
                {
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add("title", title.Text);
                    data.Add("orgUnit", checkedOrg);
                    string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    bool added = Plannings.PlanningFacade.AddDoc("Responsibilities", jsonData);
                    if (!added)
                    {
                        MessageBox.Show(this, "!مسئولیتی با عنوان یکسان قبلا در سامانه به ثبت رسیده است", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        errorLable.Hide();
                        this.Hide();
                        UserForm.Confirm("مسئولیت موردنظر با موفقیت در سیستم به ثبت رسید.");
                    }
                }
            }
        }
    }
}
