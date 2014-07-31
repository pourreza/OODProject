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
        private static ConfirmPanel confirmPanel = new ConfirmPanel();
        public string userName;

        public UserForm(Dashboard dashBoard, string title, string userName, string type)
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
            welcome.Text += PersianClass.ToPersianNumber(userName);
            welcome.Text += " وارد سامانه شده اید.";
            welcome.Location = new Point(460, 7);
            welcome.Size = new Size(230, 18);
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

            this.Controls.Add(dashBoard);

            if (type.Equals("SA"))
                this.Controls.Add(new SAMenuPanel(this));
            else if (type.Equals("IA"))
                this.Controls.Add(new IAMenuPanel(this));
            else if (type.Equals("II"))
                this.Controls.Add(new IIMenuPanel(this));
            else
                this.Controls.Add(new OIMenuPanel(this));
            
            this.Controls.Add(confirmPanel);
            confirmPanel.Hide();
        }


        private void UserForm_Load(object sender, EventArgs e)
        {

        }

        public void ChangeMainPanel(MainPanel mp)
        {
            while (this.Controls.ContainsKey("D"))
            {
                this.Controls.RemoveByKey("D");
            }
            mp.Name = "D";
            this.Controls.Add(mp);
        }

        public static void Confirm(String msg)
        {
            confirmPanel.Show();
            confirmPanel.Name = "D";
            confirmPanel.setMsg(msg);
        }
    }
}
