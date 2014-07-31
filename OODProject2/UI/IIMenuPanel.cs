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
    public partial class IIMenuPanel : MenuPanel
    {
        private UserForm uf;
        private ToolStripMenuItem one1;
        private ToolStripMenuItem one2;
        private ToolStripMenuItem one3;
        private ToolStripMenuItem one4;

        private ToolStripMenuItem two1;
        private ToolStripMenuItem two2;
        private ToolStripMenuItem two3;
        private ToolStripMenuItem two4;
 
        private ToolStripMenuItem logoutItem;

        public IIMenuPanel(UserForm u)
        {
            uf = u;
            InitializeComponent();

            MenuStrip opAudit = new MenuStrip();
            MenuStrip respAudit = new MenuStrip();
            
            MenuStrip logout = new MenuStrip();
            logoutItem = new ToolStripMenuItem("خروج") { Image = OODProject2.Properties.Resources.LogoutImg2 };
            logoutItem.RightToLeft = RightToLeft.No;
            logout.Items.Add(logoutItem);
            logoutItem.Click += new System.EventHandler(this.logout_Click);

            List<MenuStrip> menus = new List<MenuStrip>();
            menus.Add(logout);
            menus.Add(respAudit);
            menus.Add(opAudit);
            
            ToolStripMenuItem one = new ToolStripMenuItem("حسابرسی اهداف اجرایی");
            opAudit.Items.Add(one);
            one1 = new ToolStripMenuItem("ثبت حسابرسی جدید اهداف اجرایی");
            one.DropDownItems.Add(one1);
            one1.Click += new System.EventHandler(this.one1_Click);
            one2 = new ToolStripMenuItem("مشاهده حسابرسی های اهداف اجرایی");
            one.DropDownItems.Add(one2);
            one2.Click += new System.EventHandler(this.one2_Click);
            one3 = new ToolStripMenuItem("ویرایش حسابرسی های اهداف اجرایی");
            one.DropDownItems.Add(one3);
            one3.Click += new System.EventHandler(this.one3_Click);
            one4 = new ToolStripMenuItem("حذف حسابرسی های اهداف اجرایی");
            one.DropDownItems.Add(one4);
            one3.Click += new System.EventHandler(this.one3_Click);

            ToolStripMenuItem two = new ToolStripMenuItem("حسابرسی مسئولیت ها");
            respAudit.Items.Add(two);
            two1 = new ToolStripMenuItem("ثبت حسابرسی جدید مسئولیت ها");
            two.DropDownItems.Add(two1);
            two1.Click += new System.EventHandler(this.two1_Click);
            two2 = new ToolStripMenuItem("مشاهده حسابرسی های مسئولیت ها");
            two.DropDownItems.Add(two2);
            two2.Click += new System.EventHandler(this.two2_Click);
            two3 = new ToolStripMenuItem("ویرایش حسابرسی های مسئولیت ها");
            two.DropDownItems.Add(two3);
            two3.Click += new System.EventHandler(this.two3_Click);
            two4 = new ToolStripMenuItem("حذف حسابرسی های مسئولیت ها");
            two.DropDownItems.Add(two4);
            two4.Click += new System.EventHandler(this.two4_Click);

            MenuItems = menus;

            addItems();
        }

        private void IIMenuPanel_Load(object sender, EventArgs e)
        {

        }


        private void one1_Click(object sender, EventArgs e)
        {
            uf.Hide();
            UserForm u = new UserForm(new MainPanel(), "زیرسامانه مدیریت محیطی", "مریم");
            u.ShowDialog();
            uf.Close();
        }

        private void one2_Click(object sender, EventArgs e)
        {
            uf.Hide();
            UserForm u = new UserForm(new MainPanel(), "زیرسامانه", "مریم");
            u.ShowDialog();
            uf.Close();
        }

        private void one3_Click(object sender, EventArgs e)
        {
            uf.Hide();
            UserForm u = new UserForm(new MainPanel(), "زیرسامانه مدیریت محیطی", "مریم");
            u.ShowDialog();
            uf.Close();
        }

        private void one4_Click(object sender, EventArgs e)
        {
            uf.Hide();
            UserForm u = new UserForm(new MainPanel(), "زیرسامانه مدیریت محیطی", "مریم");
            u.ShowDialog();
            uf.Close();
        }

        private void two1_Click(object sender, EventArgs e)
        {
            uf.Hide();
            UserForm u = new UserForm(new MainPanel(), "زیرسامانه مدیریت محیطی", "مریم");
            u.ShowDialog();
            uf.Close();
        }

        private void two2_Click(object sender, EventArgs e)
        {
            uf.Hide();
            UserForm u = new UserForm(new MainPanel(), "زیرسامانه مدیریت محیطی", "مریم");
            u.ShowDialog();
            uf.Close();
        }

        private void two3_Click(object sender, EventArgs e)
        {
            uf.Hide();
            UserForm u = new UserForm(new MainPanel(), "زیرسامانه مدیریت محیطی", "مریم");
            u.ShowDialog();
            uf.Close();
        }

        private void two4_Click(object sender, EventArgs e)
        {
            uf.Hide();
            UserForm u = new UserForm(new MainPanel(), "زیرسامانه مدیریت محیطی", "مریم");
            u.ShowDialog();
            uf.Close();
        }

        
        private void logout_Click(object sender, EventArgs e)
        {
            uf.Hide();
            LoginForm u = new LoginForm();
            u.ShowDialog();
            uf.Close();
        }
    }
}
