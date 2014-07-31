using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace OODProject_2_.UI
{
    public partial class UserForm : EMSForm
    {
        private Panel infoPanel;
        private MainPanel mp;
        private MenuPanel menu;
        private static ConfirmPanel confirmPanel = new ConfirmPanel();
        public string userName;

        public UserForm(MainPanel m, string title, string userName)
        {
            InitializeComponent();
            this.Size = new Size(720, 520);
            this.Title = title;
            this.Text = title;
            this.userName = userName;

            infoPanel = new Panel();
            infoPanel.Size = new Size(697, 34);
            infoPanel.Location = new Point(3, 3);
            infoPanel.BorderStyle = BorderStyle.FixedSingle;

            Label welcome = new Label();
            welcome.Text = "شما با نام کاربری ";
            welcome.Text +=userName;
            welcome.Text += " وارد سامانه شده اید.";
            welcome.Location = new Point(507, 7);
            welcome.Size = new Size(180, 18);
            welcome.Font = new Font("B Nazanin", 9);

            Label date = new Label();
            date.Text = "تاریخ امروز: ";
            PersianCalendar p = new PersianCalendar();
            date.Text += p.GetDayOfMonth(DateTime.Now);
            date.Text += " / ";
            date.Text += p.GetMonth(DateTime.Now);
            date.Text += " / ";
            date.Text += p.GetYear(DateTime.Now);
            date.Location = new Point(3, 7);
            date.Size = new Size(120, 18);
            date.Font = new Font("B Nazanin", 9);

            infoPanel.Controls.Add(welcome);
            infoPanel.Controls.Add(date);

            this.Controls.Add(infoPanel);

            mp = m;
            this.Controls.Add(mp);

            menu = new SAMenuPanel(this);
            this.Controls.Add(menu);

            this.Controls.Add(confirmPanel);
            confirmPanel.Hide();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {

        }

        public static void Confirm(String msg)
        {
            confirmPanel.Show();
            confirmPanel.setMsg(msg);
        }
    }
}
