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
    public partial class IAMenuPanel : MenuPanel
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

        private ToolStripMenuItem three1;
        private ToolStripMenuItem three2;
        private ToolStripMenuItem three3;
        private ToolStripMenuItem three4;

        private ToolStripMenuItem four1;
        private ToolStripMenuItem four2;
        private ToolStripMenuItem four3;
        private ToolStripMenuItem four4;

        private ToolStripMenuItem five1;
        private ToolStripMenuItem five2;
        private ToolStripMenuItem five3;
        private ToolStripMenuItem five4;

        private ToolStripMenuItem six1;
        private ToolStripMenuItem six2;
        private ToolStripMenuItem six3;
        private ToolStripMenuItem six4;

        private ToolStripMenuItem sev1;
        private ToolStripMenuItem sev2;
        private ToolStripMenuItem sev3;
        private ToolStripMenuItem sev4;

        private ToolStripMenuItem eig1;
        private ToolStripMenuItem eig2;
        private ToolStripMenuItem eig3;

        private ToolStripMenuItem logoutItem;

        public IAMenuPanel(UserForm u)
        {
            uf = u;
            InitializeComponent();

            MenuStrip resource = new MenuStrip();
            MenuStrip orgStructure = new MenuStrip();
            MenuStrip opGoals = new MenuStrip();
            MenuStrip relation = new MenuStrip();
            MenuStrip responsibility = new MenuStrip();
            MenuStrip plan = new MenuStrip();
            MenuStrip schedule = new MenuStrip();
            MenuStrip report = new MenuStrip();
            MenuStrip logout = new MenuStrip();
            logoutItem = new ToolStripMenuItem("خروج از سامانه") { Image = OODProject2.Properties.Resources.LogoutImg };
            logoutItem.RightToLeft = RightToLeft.No;
            logout.Items.Add(logoutItem);

            logoutItem.Click += new System.EventHandler(this.logout_Click);

            List<MenuStrip> menus = new List<MenuStrip>();
            menus.Add(logout);
            menus.Add(report);
            menus.Add(schedule);
            menus.Add(plan);
            menus.Add(responsibility);
            menus.Add(relation);
            menus.Add(opGoals);
            menus.Add(orgStructure);
            menus.Add(resource);

            ToolStripMenuItem one = new ToolStripMenuItem("تعریف منابع");
            resource.Items.Add(one);
            one1 = new ToolStripMenuItem("ثبت منبع");
            one.DropDownItems.Add(one1);
            //  one1.Click += new System.EventHandler(this.one1_Click);
            one2 = new ToolStripMenuItem("مشاهده منابع");
            one.DropDownItems.Add(one2);
            //  one2.Click += new System.EventHandler(this.one2_Click);
            one3 = new ToolStripMenuItem("ویرایش منابع");
            one.DropDownItems.Add(one3);
            // one3.Click += new System.EventHandler(this.one3_Click);
            one4 = new ToolStripMenuItem("حذف منابع");
            one.DropDownItems.Add(one4);
            //            one4.Click += new System.EventHandler(this.one4_Click);

            ToolStripMenuItem two = new ToolStripMenuItem("تعریف ساختار سازمانی");
            orgStructure.Items.Add(two);
            two1 = new ToolStripMenuItem("ثبت جزء جدید");
            two.DropDownItems.Add(two1);
            //        two1.Click += new System.EventHandler(this.two1_Click);
            two2 = new ToolStripMenuItem("مشاهده ساختار سازمانی");
            two.DropDownItems.Add(two2);
            //      two2.Click += new System.EventHandler(this.two2_Click);
            two3 = new ToolStripMenuItem("ویرایش ساختار سازمانی");
            two.DropDownItems.Add(two3);
            //    two3.Click += new System.EventHandler(this.two3_Click);
            two4 = new ToolStripMenuItem("حذف اجزاء");
            two.DropDownItems.Add(two4);
            //  two4.Click += new System.EventHandler(this.two4_Click);

            ToolStripMenuItem three = new ToolStripMenuItem("تعریف اهداف اجرایی");
            opGoals.Items.Add(three);
            three1 = new ToolStripMenuItem("ثبت هدف جدید");
            three.DropDownItems.Add(three1);
            //            three1.Click += new System.EventHandler(this.three1_Click);
            three2 = new ToolStripMenuItem("مشاهده اهداف اجرایی");
            three.DropDownItems.Add(three2);
            //          three2.Click += new System.EventHandler(this.three2_Click);
            three3 = new ToolStripMenuItem("ویرایش اهداف");
            three.DropDownItems.Add(three3);
            //        three3.Click += new System.EventHandler(this.three3_Click);
            three4 = new ToolStripMenuItem("حذف اهداف اجرایی");
            three.DropDownItems.Add(three4);
            //      three4.Click += new System.EventHandler(this.three4_Click);

            ToolStripMenuItem four = new ToolStripMenuItem("ارتباط اهداف");
            relation.Items.Add(four);
            four1 = new ToolStripMenuItem("ثبت ارتباط جدید اهداف کلان و اجرایی");
            four.DropDownItems.Add(four1);
            //four1.Click += new System.EventHandler(this.four1_Click);
            four2 = new ToolStripMenuItem("مشاهده ارتباط اهداف اجرایی و کلان");
            four.DropDownItems.Add(four2);
            //four2.Click += new System.EventHandler(this.four2_Click);
            four3 = new ToolStripMenuItem("ویرایش ارتباطات اهداف کلان و اجرایی");
            four.DropDownItems.Add(four3);
            //four3.Click += new System.EventHandler(this.four3_Click);
            four4 = new ToolStripMenuItem("حذف ارتباطات اهداف اجرایی و کلان");
            four.DropDownItems.Add(four4);
            //four4.Click += new System.EventHandler(this.four4_Click);

            ToolStripMenuItem five = new ToolStripMenuItem("تعریف مسئولیت");
            responsibility.Items.Add(five);
            five1 = new ToolStripMenuItem("ثبت مسئولیت جدید");
            five.DropDownItems.Add(five1);
            //five1.Click += new System.EventHandler(this.five1_Click);
            five2 = new ToolStripMenuItem("مشاهده مسئولیت ها");
            five.DropDownItems.Add(five2);
            //five2.Click += new System.EventHandler(this.five2_Click);
            five3 = new ToolStripMenuItem("ویرایش مسئولیت ها");
            five.DropDownItems.Add(five3);
            //five3.Click += new System.EventHandler(this.five3_Click);
            five4 = new ToolStripMenuItem("حذف مسئولیت ها");
            five.DropDownItems.Add(five4);
            //five4.Click += new System.EventHandler(this.five4_Click);

            ToolStripMenuItem six = new ToolStripMenuItem("تعریف برنامه اقدام");
            plan.Items.Add(six);
            six1 = new ToolStripMenuItem("ثبت برنامه جدید");
            six.DropDownItems.Add(six1);
            //six1.Click += new System.EventHandler(this.six1_Click);
            six2 = new ToolStripMenuItem("مشاهده برنامه های اقدام");
            six.DropDownItems.Add(six2);
            //six2.Click += new System.EventHandler(this.six2_Click);
            six3 = new ToolStripMenuItem("ویرایش برنامه ها");
            six.DropDownItems.Add(six3);
            //six3.Click += new System.EventHandler(this.six3_Click);
            six4 = new ToolStripMenuItem("حذف برنامه ها");
            six.DropDownItems.Add(six4);
            //six4.Click += new System.EventHandler(this.six4_Click);

            ToolStripMenuItem sev = new ToolStripMenuItem("زمان بندی برنامه اقدام");
            schedule.Items.Add(sev);
            sev1 = new ToolStripMenuItem("ثبت زمان بندی جدید");
            sev.DropDownItems.Add(sev1);
            //sev1.Click += new System.EventHandler(this.sev1_Click);
            sev2 = new ToolStripMenuItem("مشاهده زمان بندی های برنامه ها");
            sev.DropDownItems.Add(sev2);
            //sev2.Click += new System.EventHandler(this.sev2_Click);
            sev3 = new ToolStripMenuItem("ویرایش زمان بندی ها");
            sev.DropDownItems.Add(sev3);
            //sev3.Click += new System.EventHandler(this.sev3_Click);
            sev4 = new ToolStripMenuItem("حذف زمان بندی های برنامه ها");
            sev.DropDownItems.Add(sev4);
            //sev4.Click += new System.EventHandler(this.sev4_Click);

            ToolStripMenuItem eig = new ToolStripMenuItem("گزارش گیری");
            report.Items.Add(eig);
            eig1 = new ToolStripMenuItem("گزارش روندهای زمانی");
            eig.DropDownItems.Add(eig1);
            eig1.Click += new System.EventHandler(this.eig1_Click);
            eig2 = new ToolStripMenuItem("گزارش اندازه ها و متریک های برنامه اقدام");
            eig.DropDownItems.Add(eig2);
            eig2.Click += new System.EventHandler(this.eig2_Click);
            eig3 = new ToolStripMenuItem("گزارش مستندات و پرونده الکترونیک");
            eig.DropDownItems.Add(eig3);
            eig3.Click += new System.EventHandler(this.eig3_Click);

            MenuItems = menus;

            addItems();

        }

        private void IAMenuPanel_Load(object sender, EventArgs e)
        {

        }


        /*        private void one1_Click(object sender, EventArgs e)
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

                private void three1_Click(object sender, EventArgs e)
                {
                    uf.Hide();
                    UserForm u = new UserForm(new MainPanel(), "زیرسامانه مدیریت محیطی", "مریم");
                    u.ShowDialog();
                    uf.Close();
                }

                private void three2_Click(object sender, EventArgs e)
                {
                    uf.Hide();
                    UserForm u = new UserForm(new MainPanel(), "زیرسامانه مدیریت محیطی", "مریم");
                    u.ShowDialog();
                    uf.Close();
                }

                private void three3_Click(object sender, EventArgs e)
                {
                    uf.Hide();
                    UserForm u = new UserForm(new MainPanel(), "زیرسامانه مدیریت محیطی", "مریم");
                    u.ShowDialog();
                    uf.Close();
                }

                private void three4_Click(object sender, EventArgs e)
                {
                    uf.Hide();
                    UserForm u = new UserForm(new MainPanel(), "زیرسامانه مدیریت محیطی", "مریم");
                    u.ShowDialog();
                    uf.Close();
                }

                private void four1_Click(object sender, EventArgs e)
                {
                    uf.Hide();
                    UserForm u = new UserForm(new MainPanel(), "زیرسامانه مدیریت محیطی", "مریم");
                    u.ShowDialog();
                    uf.Close();
                }

                private void four2_Click(object sender, EventArgs e)
                {
                    uf.Hide();
                    UserForm u = new UserForm(new MainPanel(), "زیرسامانه مدیریت محیطی", "مریم");
                    u.ShowDialog();
                    uf.Close();
                }

                private void four3_Click(object sender, EventArgs e)
                {
                    uf.Hide();
                    UserForm u = new UserForm(new MainPanel(), "زیرسامانه مدیریت محیطی", "مریم");
                    u.ShowDialog();
                    uf.Close();
                }

                private void four4_Click(object sender, EventArgs e)
                {
                    uf.Hide();
                    UserForm u = new UserForm(new MainPanel(), "زیرسامانه مدیریت محیطی", "مریم");
                    u.ShowDialog();
                    uf.Close();
                }

                private void five1_Click(object sender, EventArgs e)
                {
                    uf.Hide();
                    UserForm u = new UserForm(new MainPanel(), "زیرسامانه مدیریت محیطی", "مریم");
                    u.ShowDialog();
                    uf.Close();
                }

                private void five2_Click(object sender, EventArgs e)
                {
                    uf.Hide();
                    UserForm u = new UserForm(new MainPanel(), "زیرسامانه مدیریت محیطی", "مریم");
                    u.ShowDialog();
                    uf.Close();
                }

                private void five3_Click(object sender, EventArgs e)
                {
                    uf.Hide();
                    UserForm u = new UserForm(new MainPanel(), "زیرسامانه مدیریت محیطی", "مریم");
                    u.ShowDialog();
                    uf.Close();
                }

                private void five4_Click(object sender, EventArgs e)
                {
                    uf.Hide();
                    UserForm u = new UserForm(new MainPanel(), "زیرسامانه مدیریت محیطی", "مریم");
                    u.ShowDialog();
                    uf.Close();
                }

                private void six1_Click(object sender, EventArgs e)
                {
                    uf.Hide();
                    UserForm u = new UserForm(new MainPanel(), "زیرسامانه مدیریت محیطی", "مریم");
                    u.ShowDialog();
                    uf.Close();
                }

                private void six2_Click(object sender, EventArgs e)
                {
                    uf.Hide();
                    UserForm u = new UserForm(new MainPanel(), "زیرسامانه مدیریت محیطی", "مریم");
                    u.ShowDialog();
                    uf.Close();
                }

                private void six3_Click(object sender, EventArgs e)
                {
                    uf.Hide();
                    UserForm u = new UserForm(new MainPanel(), "زیرسامانه مدیریت محیطی", "مریم");
                    u.ShowDialog();
                    uf.Close();
                }

                private void six4_Click(object sender, EventArgs e)
                {
                    uf.Hide();
                    UserForm u = new UserForm(new MainPanel(), "زیرسامانه مدیریت محیطی", "مریم");
                    u.ShowDialog();
                    uf.Close();
                }

                private void sev1_Click(object sender, EventArgs e)
                {
                    uf.Hide();
                    UserForm u = new UserForm(new MainPanel(), "زیرسامانه مدیریت محیطی", "مریم");
                    u.ShowDialog();
                    uf.Close();
                }

                private void sev2_Click(object sender, EventArgs e)
                {
                    uf.Hide();
                    UserForm u = new UserForm(new MainPanel(), "زیرسامانه مدیریت محیطی", "مریم");
                    u.ShowDialog();
                    uf.Close();
                }

                private void sev3_Click(object sender, EventArgs e)
                {
                    uf.Hide();
                    UserForm u = new UserForm(new MainPanel(), "زیرسامانه مدیریت محیطی", "مریم");
                    u.ShowDialog();
                    uf.Close();
                }

                private void sev4_Click(object sender, EventArgs e)
                {
                    uf.Hide();
                    UserForm u = new UserForm(new MainPanel(), "زیرسامانه مدیریت محیطی", "مریم");
                    u.ShowDialog();
                    uf.Close();
                }
        */
        private void eig1_Click(object sender, EventArgs e)
        {
            uf.ChangeMainPanel(new FirstViewReport(false, uf));
        }

        private void eig2_Click(object sender, EventArgs e)
        {
            uf.ChangeMainPanel(new FirstMetricReport(uf));
        }

        private void eig3_Click(object sender, EventArgs e)
        {
            uf.ChangeMainPanel(new FirstViewReport(true, uf));
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
