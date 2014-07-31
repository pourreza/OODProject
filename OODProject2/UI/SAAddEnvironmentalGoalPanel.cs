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
    public partial class SAAddEnvironmentalGoalPanel : AddPanel
    {
        private Label askTitle = new Label();
        private TextBox goalTitle = new TextBox();

        public SAAddEnvironmentalGoalPanel()
        {
            headerLabel.Text = "لطفا هدف کلان جدید موردنظر خود را وارد کنید: ";
            InitializeComponent();

            askTitle.Location = new Point(260, 70);
            askTitle.Text = "عنوان هدف کلان:";

            goalTitle.Location = new Point(52, 70);
            goalTitle.Size = new Size(210, 20);

            registerButton.Location = new Point(190, 110);
            registerButton.Click += new System.EventHandler(this.onRegisterClick);
            this.Controls.Add(askTitle);
            this.Controls.Add(goalTitle);

        }

        private void SAAddEnvironmentalGoalPanel_Load(object sender, EventArgs e)
        {

        }

        private void onRegisterClick(object sender, EventArgs e)
        {
            if (goalTitle.Text.Equals(""))
            {
                errorLable.Text = "لطفا عنوان هدف کلان را وارد کنید!";
                errorLable.Location = new Point(135, 250);
                errorLable.Show();
            }
            else
            {
                errorLable.Hide();
                this.Hide();
                UserForm.Confirm("هدف کلان موردنظر با موفقیت در سیستم به ثبت رسید.");
            }
        }
    }
}
