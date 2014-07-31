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
            if (passwordTextBox.Text.Equals("maryam"))
            {
                errorLable.Hide();
                this.Hide();
                UserForm form2 = new UserForm(new MainPanel(), "زیرسامانه حسابرسی","مریم");
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
