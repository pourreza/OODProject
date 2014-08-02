using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProject_2_.Docs
{
    class DocFacade
    {
        public static string ViewDocs(string type)
        {
            List<string> goals = new List<string>();
            goals.Add("کاهش آلودگی ها");
            goals.Add("افزایش کارایی");
            goals.Add("کاهش آلاینده ها");

            List<string> dates = new List<string>();
            dates.Add(UI.PersianClass.ToPersianNumber("1393/4/2"));
            dates.Add(UI.PersianClass.ToPersianNumber("1393/4/3"));
            dates.Add(UI.PersianClass.ToPersianNumber("1393/4/1"));

            List<string> names = new List<string>();
            names.Add("مریم پوررضا");
            names.Add("مریم پوررضا");
            names.Add("زینب صادقی پور");

            Dictionary<string, List<string>> data = new Dictionary<string,List<string>>();
            data.Add("عنوان هدف کلان", goals);
            data.Add("تاریخ آخرین ویرایش", dates);
            data.Add("آخرین ویرایشگر", names);

            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        public static void deleteDocs(string type, List<int> indexes)
        {
        }

        public static void update(string type, int index, string data)
        {
        }
    }

}
