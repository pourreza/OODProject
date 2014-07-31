using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Threading;

namespace OODProject_2_
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           // System.Threading.Thread.CurrentThread.CurrentCulture = new FarsiLibrary.Utils.PersianCultureInfo();
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new FarsiLibrary.Utils.PersianCultureInfo();
            
            System.Globalization.CultureInfo language = new System.Globalization.CultureInfo("fa-ir");

            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Dictionary<string,int> js = new Dictionary<string,int>();
            js.Add("کاهش مصرف انرژی", 20);
            js.Add("افزایش گازهای گلخانه ای",50);
            js.Add("کاهش مصرف برق",10);
            js.Add("کاهش گرمای هوا", 40);
            string jsonData = JsonConvert.SerializeObject(js);

            Dictionary<string, int> js2 = new Dictionary<string, int>();
            js2.Add("مجموع مصرف انرژی", 70);
            js2.Add("مجموع مصرف مواد", 80);
            js2.Add("مجموع زباله ها", 60);
            js2.Add("مجموع دفع گازهای گلخانه ای", 95);
            string jsonData2 = JsonConvert.SerializeObject(js2);
            
            /*try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("mm.pourreza@gmail.com");
                mail.To.Add("shiva.ketabi@gmail.com");
                mail.Subject = "اولین میل از کد سی شارپمون :دی";
                mail.Body = "می تونیم حالا به آدما میل هم از تو کدمون بفرستیم :دی";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("mm.pourreza", "456852753951");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }*/
            //Application.Run(new UI.UserForm(new UI.Dashboard("SA",true,"شیوا کتابی",jsonData,jsonData2), "زیرسامانه حسابرسی سازمان"));
            Dictionary<string, List<string>> rel = new Dictionary<string,List<string>>();
            List<string> t1 = new List<string>();
            t1.Add("کاهش دی اکسید کربن");
            t1.Add("کاهش آلودگی");
            rel.Add("کاهش آلاینده ها", t1);
            List<string> t2 = new List<string>();
            t2.Add("کاهش دی اکسید کربن آب");
            t2.Add("کاهش آلودگی هوا");
            rel.Add("کاهش بدی ها", t2);
            string data = JsonConvert.SerializeObject(rel);

            Dictionary<string, List<int>> structure = new Dictionary<string, List<int>>();
            List<int> n = new List<int>();
            
            structure.Add("مدیریت سازمان", n);
            n = new List<int>();
            n.Add(0);
            
            structure.Add("مدیریت مالی", n);
            n = new List<int>();
            n.Add(0);
            
            structure.Add("مدیریت تجهیزات", n);
            n = new List<int>();
            n.Add(0);
            n.Add(1);
            
            structure.Add("مدیریت کامپیوترها", n);

            Dictionary<int, string> orgs = new Dictionary<int, string>();
            orgs.Add(0, "مدیریت سازمان");
            orgs.Add(1, "مدیریت تجهیزات");
            orgs.Add(2, "مدیریت انسان ها");
            orgs.Add(3, "مدیریت کامپیوترها");
            orgs.Add(4, "مدیریت کارمندان بی تربیت");
            string orgNames = JsonConvert.SerializeObject(orgs);
            string data2 = JsonConvert.SerializeObject(structure);

            Dictionary<int, string> resp = new Dictionary<int, string>();
            resp.Add(0, "بهبود تجهیزات");
            resp.Add(1, "تولید انرژی خورشیدی");
            resp.Add(2, "کنترل پسماندهای خروجی");
            resp.Add(3, "کنترل دی اکسید کربن تولیدی");
            resp.Add(4, "تولید انرژی خورشیدی");
            resp.Add(5, "کنترل پسماندهای خروجی");
            resp.Add(6, "کنترل دی اکسید کربن تولیدی");
            string resps = JsonConvert.SerializeObject(resp);

            Dictionary<int, string> resou = new Dictionary<int, string>();
            resou.Add(0, "کامپیوتر بزرگ");
            resou.Add(1, "آدم های خوب");
            resou.Add(2, "دفترهای قشنگ");
            resou.Add(3, "اون خودکار رنگیا");
            resou.Add(4, "رنگ های انگشتی");
            resou.Add(5, "دفترهای قشنگ");
            resou.Add(6, "اون خودکار رنگیا");
            resou.Add(7, "رنگ های انگشتی");

            string resous = JsonConvert.SerializeObject(resou);

            Dictionary<int, string> goal = new Dictionary<int, string>();
            goal.Add(0, "کاهش آلودگی ها");
            goal.Add(1, "کاهش گرما");
            goal.Add(2, "افزایش کارایی");
            string goals = JsonConvert.SerializeObject(goal);
            //Application.Run(new UI.UserForm(new UI.IAAddResponsibilityPanel(orgNames), "زیرسامانه حسابرسی سازمان", "مریم"));
            //Application.Run(new UI.UserForm(new UI.IAAddSchedulePanel(), "زیرسامانه حسابرسی سازمان", "مریم"));
            Application.Run(new UI.LoginForm());

        }
    }
}
