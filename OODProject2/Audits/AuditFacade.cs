using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProject_2_.Audits
{
    class AuditFacade
    {
        public static string GetEnvironmentalGoalsAudit()
        {
            Dictionary<string, int> js = new Dictionary<string, int>();
            js.Add("کاهش مصرف انرژی", 20);
            js.Add("افزایش گازهای گلخانه ای", 50);
            js.Add("کاهش مصرف برق", 10);
            js.Add("کاهش گرمای هوا", 40);
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(js);
            return jsonData;
        }

        public static string GetOperationalGoalsAudit()
        {
            Dictionary<string, int> js = new Dictionary<string, int>();
            js.Add("کاهش مصرف انرژی", 20);
            js.Add("افزایش گازهای گلخانه ای", 50);
            js.Add("کاهش مصرف برق", 10);
            js.Add("کاهش گرمای هوا", 40);
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(js);
            return jsonData;
        }

        public static string GetMetricsAudit()
        {
            Dictionary<string, int> js2 = new Dictionary<string, int>();
            js2.Add("مجموع مصرف انرژی", 70);
            js2.Add("مجموع مصرف مواد", 80);
            js2.Add("مجموع زباله ها", 60);
            js2.Add("مجموع دفع گازهای گلخانه ای", 95);
            string jsonData2 = Newtonsoft.Json.JsonConvert.SerializeObject(js2);
            return jsonData2;
        }


    }
}
