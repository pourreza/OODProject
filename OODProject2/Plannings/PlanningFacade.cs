using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OODProject_2_.Plannings
{
    class PlanningFacade
    {
        public static string ViewDocs(string type)
        {
            Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
            return JsonConvert.SerializeObject(data);
        }

        public static string GetDocs(string type)
        {
            Dictionary<int, string> data = new Dictionary<int, string>();
            switch (type)
            {
                case "OpGoals":
                    data.Add(0, "کاهش آلودگی اجرایی");
                    data.Add(1, "افزایش هوای اجرایی");
                    break;
                case "Plans":
                    data.Add(0, "برنامه اول");
                    data.Add(1, "برنامه دوم");
                    break;
                default:
                    break;
            }
            return JsonConvert.SerializeObject(data);
        }

        public static void DeleteOrganizationalUnits(List<string> nodes)
        {
        }

        public static string ViewOrganizationalStructure()
        {
            Dictionary<string, List<int>> data = new Dictionary<string, List<int>>();
            return JsonConvert.SerializeObject(data);
        }

        public static bool Update(string type, int index, string jsonData)
        {
            return true;
        }

        public static bool AddDoc(string type, string jsonData)
        {
            return true;
        }

        public static void DeleteDocs(string type, List<int> indexes)
        {
        }

        public static string GetDeadline(string opGoalTitle)
        {
            return "1393/2/13";
        }

        public static string GetRelatedGoal(string planTitle)
        {
            return "کاهش آلودگی ها";
        }

        public static List<string> GetRelatedResponsibilites(string planTitle)
        {
            List<string> res = new List<string>();
            res.Add("بهبود قطعات");
            res.Add("تولید انرژی خورشیدی");

            return res;
        }
    }
}
