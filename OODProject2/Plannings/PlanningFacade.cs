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

        public static void Update(string type, int index, string jsonData)
        {
        }

        public static bool AddDoc(string type, string jsonData)
        {
            return true;
        }

        public static void DeleteDocs(string type, List<int> indexes)
        {
        }
    }
}
