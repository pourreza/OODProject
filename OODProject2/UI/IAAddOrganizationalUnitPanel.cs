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

        public IAAddOrganizationalUnitPanel(String unitNames)
        {
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
            p.Location = new Point(73,70);
            p.Size = new Size(197,110);
            
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

        private void IAAddOrganizationalUnitPanel_Load(object sender, EventArgs e)
        {

        }

        private void onRegisterClick(object sender, EventArgs e)
        {
            int i = 0;
            foreach (RadioButton indexChecked in parent)
                if (indexChecked.Checked)
                    i++;
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

                errorLable.Hide();
                this.Hide();
                UserForm.Confirm("واحد سازمانی موردنظر با موفقیت در سیستم به ثبت رسید.");
            }
        }
    }
}
