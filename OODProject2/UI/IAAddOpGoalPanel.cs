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
    public partial class IAAddOpGoalPanel : AddPanel
    {
        private Label askTitle = new Label();
        private TextBox goalTitle = new TextBox();
        private Label askDate = new Label();
        //private DateTimePicker date = new DateTimePicker();
        private FarsiLibrary.Win.Controls.FADatePicker date = new FarsiLibrary.Win.Controls.FADatePicker();

        public IAAddOpGoalPanel()
        {
            headerLabel.Text = "لطفا هدف اجرایی جدید موردنظر خود را وارد کنید: ";
            InitializeComponent();

            askTitle.Location = new Point(270, 70);
            askTitle.Text = "عنوان هدف اجرایی";

            goalTitle.Location = new Point(72, 70);
            goalTitle.Size = new Size(200, 20);

            askDate.Location = new Point(270, 100);
            askDate.Text = "موعد اجرای هدف";

            date.Location = new Point(122, 100);
            date.Size = new Size(150, 15);
            string t = FarsiLibrary.Utils.PersianDate.Now.Year.ToString() + "/" + FarsiLibrary.Utils.PersianDate.Now.Month.ToString() + "/" + FarsiLibrary.Utils.PersianDate.Now.Day.ToString();
            date.Text = t;

            registerButton.Location = new Point(200, 150);
            registerButton.Click += new System.EventHandler(this.onRegisterClick);
            this.Controls.Add(askTitle);
            this.Controls.Add(askDate);
            this.Controls.Add(goalTitle);
            this.Controls.Add(date);
        }

        private void IAAddOpGoalPanel_Load(object sender, EventArgs e)
        {

        }

        private void onRegisterClick(object sender, EventArgs e)
        {
            if (goalTitle.Text.Equals(""))
            {
                errorLable.Text = "لطفا عنوان هدف اجرایی را وارد کنید!";
                errorLable.Show();
            }
            else
            {
                errorLable.Hide();
                this.Hide();
                UserForm.Confirm("هدف اجرایی موردنظر با موفقیت در سیستم به ثبت رسید.");
            }
        }


    }
}
