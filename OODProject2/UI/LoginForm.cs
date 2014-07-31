using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OODProject_2_.UI
{
    public partial class LoginForm : EMSForm
    {
        private Label errorLable = new Label();
        private string error = "نام کاربری ویا رمزعبور اشتباه هستند!";


        public LoginForm()
        {
            InitializeComponent();
            this.Controls.Add(errorLable);
            this.Text = Title;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            errorLable.Hide();
            string res = Users.UserFacade.IsAuthenticated(usernameTextBox.Text, passwordTextBox.Text);
            if (res.Equals("docs"))
            {
                errorLable.Hide();
                this.Hide();
                Dashboard d = new Dashboard("SA", Users.UserFacade.GetUserGender(usernameTextBox.Text), Users.UserFacade.GetUserFullName(usernameTextBox.Text));
                UserForm form2 = new UserForm(d, "زیرسامانه سند مدیریت محیطی", usernameTextBox.Text, "SA");
                form2.ShowDialog();
                this.Close();
            }
            else if (res.Equals("planning"))
            {
                errorLable.Hide();
                this.Hide();
                UserForm form2 = new UserForm(new Dashboard("IA", Users.UserFacade.GetUserGender(usernameTextBox.Text), Users.UserFacade.GetUserFullName(usernameTextBox.Text)), "زیرسامانه برنامه ریزی مدیریت محیطی", usernameTextBox.Text, "IA");
                form2.ShowDialog();
                this.Close();
            }
            else if (res.Equals("i audit"))
            {
                errorLable.Hide();
                this.Hide();
                UserForm form2 = new UserForm(new Dashboard("I", Users.UserFacade.GetUserGender(usernameTextBox.Text), Users.UserFacade.GetUserFullName(usernameTextBox.Text)), "زیرسامانه حسابرسی و بازرسی", usernameTextBox.Text, "II");
                form2.ShowDialog();
                this.Close();
            }
            else if (res.Equals("e audit"))
            {
                errorLable.Hide();
                this.Hide();
                UserForm form2 = new UserForm(new Dashboard("I", Users.UserFacade.GetUserGender(usernameTextBox.Text), Users.UserFacade.GetUserFullName(usernameTextBox.Text)), "زیرسامانه حسابرسی و بازرسی", usernameTextBox.Text, "OI");
                form2.ShowDialog();
                this.Close();
            }
            else
            {
                onLoginFailure();
            }
        }

        private void onLoginFailure()
        {
            errorLable.Size = new Size(400, 100);
            errorLable.Text = error;
            errorLable.Location = new Point(120, 213);
            errorLable.ForeColor = Color.Red;
            errorLable.Show();
            passwordTextBox.Text = "";
        }
    }
}
