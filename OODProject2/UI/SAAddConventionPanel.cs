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
    public partial class SAAddConventionPanel : AddPanel
    {
        private Label askContent = new Label();
        private RichTextBox content = new RichTextBox();

        public SAAddConventionPanel()
        {
            headerLabel.Text = "لطفا متن میثاق نامه مدیریت محیطی جدید موردنظر خود را وارد کنید: ";
            headerLabel.Location = new Point(75, 10);
            headerLabel.Size = new Size(300, 15);
            InitializeComponent();

            askContent.Text = "متن میثاق نامه";
            askContent.Location = new Point(330, 30);
            askContent.Size = new Size(50, 15);

            content.Location = new Point(30, 30);
            content.Size = new Size(280, 200);

            registerButton.Location = new Point(240, 200);
            registerButton.Click += new System.EventHandler(this.onRegisterClick);

            this.Controls.Add(askContent);
            this.Controls.Add(content);

        }

        private void SAAddConventionPanel_Load(object sender, EventArgs e)
        {

        }

        private void onRegisterClick(object sender, EventArgs e)
        {
            if (content.Text.Equals(""))
            {
                errorLable.Text = "لطفا متن میثاق نامه را وارد کنید!";
                errorLable.Show();
            }
            else
            {
                errorLable.Hide();
                this.Hide();
                UserForm.Confirm("میثاق نامه موردنظر با موفقیت در سیستم به ثبت رسید.");
            }
        }
    }
}
