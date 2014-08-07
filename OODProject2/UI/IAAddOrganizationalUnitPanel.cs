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
    public partial class IAAddOrganizationalUnitPanel : AddPanel
    {
        private List<RadioButton> parent = new List<RadioButton>();
        private Label askParent = new Label();
        private Label askName = new Label();
        private TextBox orgName = new TextBox();

        private UserForm uf;
        private bool isEdit = false;
        private int index = 0;
        private Button back = new Button();
        private string nname;
        private string nparent;

        public IAAddOrganizationalUnitPanel()
        {
            string unitNames = Plannings.PlanningFacade.GetDocs("OrgUnits");

            headerLabel.Text = "لطفا واحد سازمانی جدید موردنظر خود را وارد کنید: ";

            InitializeComponent();

            askName.Location = new Point(300, 50);
            askName.Text = "نام واحد سازمانی";
            askName.Size = new Size(40, 20);

            orgName.Location = new Point(72, 50);
            orgName.Size = new Size(200, 20);

            askParent.Location = new Point(280, 70);
            askParent.Text = "واحد بالادست";
            askParent.Size = new Size(60, 20);

            Panel p = new Panel();
            p.AutoScroll = true;
            //p.BackColor = Color.AliceBlue;
            p.Location = new Point(73, 70);
            p.Size = new Size(197, 110);

            Dictionary<int, string> names = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<int, string>>(unitNames);
            int i = 0;
            foreach (KeyValuePair<int, string> entry in names)
            {
                RadioButton n = new RadioButton();
                n.Location = new Point(55, i * 20);
                n.Size = new Size(140, 15);
                n.Text = entry.Value;
                p.Controls.Add(n);
                parent.Add(n);
                i++;
            }
            registerButton.Location = new Point(200, 180);
            registerButton.Click += new System.EventHandler(this.onRegisterClick);
            this.Controls.Add(askName);
            this.Controls.Add(askParent);
            this.Controls.Add(orgName);
            this.Controls.Add(p);
        }

        public IAAddOrganizationalUnitPanel(string initialData, UserForm u, int index)
        {
            isEdit = true;
            this.uf = u;
            this.index = index;

            Dictionary<string, string> data = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(initialData);
            
            string unitNames = Plannings.PlanningFacade.GetDocs("OrgUnits");

            headerLabel.Text = "واحد سازمانی موردنظر خود را تغییر دهید: ";

            InitializeComponent();

            askName.Location = new Point(300, 50);
            askName.Text = "نام واحد سازمانی";
            askName.Size = new Size(40, 20);
            
            orgName.Location = new Point(72, 50);
            orgName.Size = new Size(200, 20);
            orgName.Text = data["نام واحد سازمانی"];
            nname = orgName.Text;

            askParent.Location = new Point(280, 70);
            askParent.Text = "واحد بالادست";
            askParent.Size = new Size(60, 20);

            Panel p = new Panel();
            p.AutoScroll = true;
            //p.BackColor = Color.AliceBlue;
            p.Location = new Point(73, 70);
            p.Size = new Size(197, 110);

            Dictionary<int, string> names = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<int, string>>(unitNames);
            int i = 0;
            foreach (KeyValuePair<int, string> entry in names)
            {
                RadioButton n = new RadioButton();
                n.Location = new Point(55, i * 20);
                n.Size = new Size(140, 15);
                n.Text = entry.Value;
                p.Controls.Add(n);
                parent.Add(n);
                i++;
            }

            nparent = data["نام واحد بالادست"];
            for (int k = 0; k < parent.Count; k++)
                if (parent[i].Text.Equals(nparent))
                    parent[i].Checked = false;

            registerButton.Location = new Point(200, 180);
            registerButton.Click += new System.EventHandler(this.onRegisterClick);

            back.Location = new Point(135, 180);
            back.Size = new Size(60, 18);
            back.Text = "بازگشت";
            back.BackColor = Color.LightSkyBlue;
            back.Click += new System.EventHandler(this.onBackClick);
            this.Controls.Add(back);

            this.Controls.Add(askName);
            this.Controls.Add(askParent);
            this.Controls.Add(orgName);
            this.Controls.Add(p);
        }

        private void IAAddOrganizationalUnitPanel_Load(object sender, EventArgs e)
        {

        }

        private void onBackClick(object sender, EventArgs e)
        {
            uf.ChangeMainPanel(new DetailedViewPanel("جزء سازمانی موردنظر برای ویرایش را از لیست زیر انتخاب کنید:", "1OrgUnits", true, false, uf));
        }

        private void onRegisterClick(object sender, EventArgs e)
        {
            int i = 0;
            string pr = "";
            foreach (RadioButton indexChecked in parent)
                if (indexChecked.Checked)
                {
                    pr = indexChecked.Text;
                    i++;
                }

            if (orgName.Text.Equals(""))
            {
                errorLable.Text = "لطفا عنوان واحد سازمانی را وارد کنید!";
                errorLable.Show();
                errorLable.Location = new Point(180, 360);
                errorLable.Size = new Size(190, 20);
            }
            else if (i == 0)
            {
                errorLable.Text = "لطفا واحد بالادست را انتخاب کنید!";
                errorLable.Show();
                errorLable.Location = new Point(178, 360);
                errorLable.Size = new Size(190, 20);
            }
            else
            {
                if(isEdit)
                {
                    if (nname.Equals(orgName.Text) && nparent.Equals(pr))
                        MessageBox.Show(this, "!تغییری روی جزء سازمانی صورت نگرفته است", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        Dictionary<string, string> data = new Dictionary<string, string>();
                        data.Add("title", orgName.Text);
                        data.Add("parent", pr);
                        string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                        bool isUpdated = Plannings.PlanningFacade.Update("OrgUnits", index, jsonData);
                        if (!isUpdated)
                            MessageBox.Show(this, "!واحد سازمانی ای با عنوان یکسان قبلا در سامانه به ثبت رسیده است", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            MessageBox.Show(this, "!جزء سازمانی با موفقیت تغییر یافت", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            uf.ChangeMainPanel(new DetailedViewPanel("جزء سازمانی موردنظر برای ویرایش را از لیست زیر انتخاب کنید:", "1OrgUnits", true, false, uf));
                        }
                    }
                }
                else{
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add("title", orgName.Text);
                    data.Add("parent", pr);
                    string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    bool added = Plannings.PlanningFacade.AddDoc("OrgUnits", jsonData);
                    if (!added)
                    {
                        MessageBox.Show(this, "!واحد سازمانی ای با عنوان یکسان قبلا در سامانه به ثبت رسیده است", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        errorLable.Hide();
                        this.Hide();
                        UserForm.Confirm("واحد سازمانی موردنظر با موفقیت در سیستم به ثبت رسید.");
                    }
                }
            }
        }
    }
}
