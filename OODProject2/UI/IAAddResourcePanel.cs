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
    public partial class IAAddResourcePanel : AddPanel
    {
        private Label askResource = new Label();
        private TextBox resourceName = new TextBox();
        private Label askNumber = new Label();
        private NumericUpDown resourceNumber = new NumericUpDown();
        private Label askType = new Label();
        private List<RadioButton> resourceType = new List<RadioButton>();

        private UserForm uf;
        private bool isEdit = false;
        private int index = 0;
        private Button back = new Button();
        private string nname;
        private int ncount;
        private string ntype;

        public IAAddResourcePanel()
        {
            InitializeComponent();

            askResource.Location = new Point(300, 50);
            askResource.Text = "نام منبع";
            askResource.Size = new Size(40, 20);

            resourceName.Location = new Point(72, 50);
            resourceName.Size = new Size(200, 20);

            askNumber.Location = new Point(290, 80);
            askNumber.Text = "تعداد منبع";
            askNumber.Size = new Size(50, 20);

            resourceNumber.Location = new Point(160, 80);
            resourceNumber.Size = new Size(110, 20);
            resourceNumber.Minimum = 1;

            askType.Location = new Point(300, 110);
            askType.Text = "نوع منبع";
            askType.Size = new Size(40, 20);

            Panel p1 = new Panel();
            p1.Location = new Point(160, 110);
            p1.Size = new Size(110, 50);
            p1.BorderStyle = BorderStyle.Fixed3D;

            RadioButton r1 = new RadioButton();
            r1.Location = new Point(0, 5);
            r1.Size = new Size(90, 10);
            r1.Text = "مالی";
            p1.Controls.Add(r1);
            resourceType.Add(r1);

            RadioButton r2 = new RadioButton();
            r2.Location = new Point(0, 20);
            r2.Size = new Size(90, 10);
            r2.Text = "تجهیزات";
            p1.Controls.Add(r2);
            resourceType.Add(r2);

            RadioButton r3 = new RadioButton();
            r3.Location = new Point(0, 35);
            r3.Size = new Size(90, 10);
            r3.Text = "مواد و ملزومات";
            p1.Controls.Add(r3);
            resourceType.Add(r3);
            

            registerButton.Location = new Point(200, 170);
            registerButton.Click += new System.EventHandler(this.onRegisterClick);

            headerLabel.Text = "لطفا منبع جدید موردنظر خود را وارد کنید: ";

            this.Controls.Add(askNumber);
            this.Controls.Add(askResource);
            this.Controls.Add(askType);
            this.Controls.Add(resourceName);
            this.Controls.Add(resourceNumber);
            this.Controls.Add(p1);
        }

        public IAAddResourcePanel(string initialData, UserForm u, int index)
        {
            isEdit = true;
            this.uf = u;
            this.index = index;

            InitializeComponent();

            Dictionary<string, string> data = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(initialData);

            askResource.Location = new Point(300, 50);
            askResource.Text = "نام منبع";
            askResource.Size = new Size(40, 20);

            resourceName.Location = new Point(72, 50);
            resourceName.Size = new Size(200, 20);
            resourceName.Text = data["نام منبع"];
            nname = data["نام منبع"];

            askNumber.Location = new Point(290, 80);
            askNumber.Text = "تعداد منبع";
            askNumber.Size = new Size(50, 20);

            resourceNumber.Location = new Point(160, 80);
            resourceNumber.Size = new Size(110, 20);
            resourceNumber.Minimum = 1;
            resourceNumber.Value = Convert.ToInt32(data["تعداد منبع"]);
            ncount = Convert.ToInt32(data["تعداد منبع"]);

            askType.Location = new Point(300, 110);
            askType.Text = "نوع منبع";
            askType.Size = new Size(40, 20);

            Panel p1 = new Panel();
            p1.Location = new Point(160, 110);
            p1.Size = new Size(110, 50);
            p1.BorderStyle = BorderStyle.Fixed3D;

            RadioButton r1 = new RadioButton();
            r1.Location = new Point(0, 5);
            r1.Size = new Size(90, 10);
            r1.Text = "مالی";
            p1.Controls.Add(r1);
            resourceType.Add(r1);

            RadioButton r2 = new RadioButton();
            r2.Location = new Point(0, 20);
            r2.Size = new Size(90, 10);
            r2.Text = "تجهیزات";
            p1.Controls.Add(r2);
            resourceType.Add(r2);

            RadioButton r3 = new RadioButton();
            r3.Location = new Point(0, 35);
            r3.Size = new Size(90, 10);
            r3.Text = "مواد و ملزومات";
            p1.Controls.Add(r3);
            resourceType.Add(r3);

            ntype = data["نوع منبع"];
            for (int i = 0; i < resourceType.Count; i++)
                if (resourceType[i].Text.Equals(ntype))
                    resourceType[i].Checked = true;

            registerButton.Location = new Point(200, 170);
            registerButton.Click += new System.EventHandler(this.onRegisterClick);

            headerLabel.Text = "منبع موردنظر خود را تغییر دهید: ";

            back.Location = new Point(135, 170);
            back.Size = new Size(60, 18);
            back.Text = "بازگشت";
            back.BackColor = Color.LightSkyBlue;
            back.Click += new System.EventHandler(this.onBackClick);
            this.Controls.Add(back);
            this.Controls.Add(askNumber);
            this.Controls.Add(askResource);
            this.Controls.Add(askType);
            this.Controls.Add(resourceName);
            this.Controls.Add(resourceNumber);
            this.Controls.Add(p1);
        }

        private void IAAddResourcePanel_Load(object sender, EventArgs e)
        {

        }

        private void onBackClick(object sender, EventArgs e)
        {
            uf.ChangeMainPanel(new DetailedViewPanel("با انتخاب منبع موردنظر خود از جدول زیر آن را ویرایش کنید:", "1Resources", true, false, uf));
        }

        private void onRegisterClick(object sender, EventArgs e)
        {
            int i = 0;
            string checkedBtn = "";
            foreach (RadioButton btn in resourceType)
                if (btn.Checked)
                {
                    checkedBtn = btn.Text;
                    i++;
                }

            if (resourceName.Text.Equals(""))
            {
                errorLable.Text = "لطفا عنوان منبع را وارد کنید!";
                errorLable.Show();
                errorLable.Location = new Point(205, 340);
                errorLable.Size = new Size(160, 20);
            }
            else if (i == 0)
            {
                errorLable.Text = "لطفا نوع منبع را وارد کنید!";
                errorLable.Show();
                errorLable.Location = new Point(205, 340);
                errorLable.Size = new Size(160, 20);
            }
            else
            {
                if (isEdit)
                {
                    if (ncount == resourceNumber.Value && nname.Equals(resourceName.Text) && ntype.Equals(checkedBtn))
                        MessageBox.Show(this, "!تغییری روی منبع صورت نگرفته است", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        Dictionary<string, string> data = new Dictionary<string, string>();
                        data.Add("title", resourceName.Text);
                        data.Add("number", resourceNumber.Value.ToString());
                        data.Add("type", checkedBtn);
                        string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                        Plannings.PlanningFacade.Update("Resources", index, jsonData);
                        MessageBox.Show(this, "!منبع با موفقیت تغییر یافت", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        uf.ChangeMainPanel(new DetailedViewPanel("با انتخاب منبع موردنظر خود از جدول زیر آن را ویرایش کنید:", "1Resources", true, false, uf));
                    }
                }
                else
                {
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add("title", resourceName.Text);
                    data.Add("number", resourceNumber.Value.ToString());
                    data.Add("type", checkedBtn);
                    string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    bool added = Plannings.PlanningFacade.AddDoc("Resources", jsonData);
                    if (!added)
                    {
                        MessageBox.Show(this, "!منبعی با عنوان یکسان قبلا در سامانه به ثبت رسیده است", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        errorLable.Hide();
                        this.Hide();
                        UserForm.Confirm("منبع موردنظر با موفقیت در سیستم به ثبت رسید.");
                    }
                }
            }
        }
    }
}
