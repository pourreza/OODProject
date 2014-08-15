using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OODProject_2_.models;
using OODProject_2_.Docs;
using System.Windows.Forms;
using OODProject2.Plannings;

namespace OODProject_2_.Plannings
{
    class PlanningFacade
    {
        const string TypeOpGoals = "OpGoals";
        const string TypeResourses = "Resources";
        const string TypePlans = "Plans";
        const string TypeResponsibility = "Responsibilities";
        const string TypeOrgUnits = "OrgUnits";


        static OpGoalCatalog OpGoalsCatalog = new OpGoalCatalog ();
        static ResourceCatalog ResourcesCatalog = new ResourceCatalog ();
        static PlanCatalog PlansCatalog = new PlanCatalog ();
        static  ResponCatalog ResponsCatalog = new ResponCatalog ();
        static OrgUnitCatalog OrgUnitsCatalog = new OrgUnitCatalog ();



        public static string ViewDocs(string type)
        {
            
            Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
            switch (type)
            {
                case TypeOpGoals:
                    return OpGoalsCatalog.ViewDocs();
                case TypeResourses:
                    return ResourcesCatalog.ViewDocs();
                case "Responsibilties":
                    return ResponsCatalog.ViewDocs();
               case TypePlans:
                    return PlansCatalog.ViewDocs();
                default:
                    MessageBox.Show("None of them");
                    break;
            }
            return JsonConvert.SerializeObject(data);
        }

        public static string GetDocs(string type)
        {
            switch (type)
            {
                case TypeOpGoals:
                    return OpGoalsCatalog.getTitles();
                case TypeResourses:
                    return ResourcesCatalog.getTitles();
                case TypeResponsibility:
                    return ResponsCatalog.getTitles();
                case TypePlans:
                    return PlansCatalog.getTitles();
                case TypeOrgUnits:
                    return OrgUnitsCatalog.getTitles();
                default:
                    return ResponsCatalog.getTitles();
            }
        }

        public static void DeleteOrganizationalUnits(List<string> nodes)
        {
            OrgUnitsCatalog.RemoveDocs(nodes);
        }

        public static string ViewOrganizationalStructure()
        {
            return OrgUnitsCatalog.ViewDocs();
        }

        public static bool Update(string type, int index, string jsonData)
        {
            Dictionary<string, string> newDic = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
            if (type.Equals(TypeOpGoals))
            {
                OperationalGoal updatedDoc = new OperationalGoal
                {
                    Title = newDic["title"],
                    Date = newDic["date"],
                    LastEditDate = DateTime.Now,
                    LastEditor = "Maryam"
                };
                return OpGoalsCatalog.UpdateDocs(index, updatedDoc);

            }
            else if (type.Equals(TypeResourses))
            {
                Resource updatedDoc = new Resource
                {
                    Title = newDic["title"],
                    Count = Convert.ToInt32(newDic["number"]),
                    Type = (ResourceType)Enum.Parse(typeof(ResourceType), newDic["type"], true),
                    LastEditDate = DateTime.Now,
                    LastEditor = "Maryam"
                };
                return ResourcesCatalog.UpdateDocs(index, updatedDoc);

            }
            return true;
        }

        public static bool AddDoc(string type, string jsonData)
        {
            switch (type)
            {
                case TypeOpGoals:
                    return OpGoalsCatalog.AddDoc(jsonData);
                case TypeResourses:
                    return ResourcesCatalog.AddDoc(jsonData);
                case TypeOrgUnits:
                    return OrgUnitsCatalog.AddDoc(jsonData);
                case TypeResponsibility:
                    return ResponsCatalog.AddDoc(jsonData);
                case TypePlans:
                    return PlansCatalog.AddDoc(jsonData);
                default:
                    return true;
            }       
        }

        public static void DeleteDocs(string type, List<int> indexes)
        {
            MessageBox.Show(type);
            switch (type)
            {
                case TypeOpGoals:
                    OpGoalsCatalog.RemoveDocs(indexes);
                    break;
                case TypeResourses:
                    ResourcesCatalog.RemoveDocs(indexes);
                    break;
                case "Responsibilties":
                    ResponsCatalog.RemoveDocs(indexes);
                    break;
                case TypePlans:
                    PlansCatalog.RemoveDocs(indexes);
                    break;            
                default:
                    MessageBox.Show("None of them");
                    break;
            }
        }

        public static string GetDeadline(string opGoalTitle)
        {
            return ((OperationalGoal)OpGoalsCatalog.getDetails(opGoalTitle)).Date;
        }

        public static string GetRelatedGoal(string planTitle)
        {
            return 
                ((OperationalGoal)(PlanningDBFacade.findByID(TypeOpGoals,((Plan)PlansCatalog.getDetails(planTitle)).OperationalGoalId))).Title;
            //return ((Plan) PlansCatalog.getDetails(planTitle)).OperationalGoal.Title;
        }

        public static List<string> GetRelatedResponsibilites(string planTitle)
        {
            List<string> re = new List<string>();
            List<Responsibility> reses = ((Plan)PlansCatalog.getDetails(planTitle)).Responsibilities;
            foreach (Responsibility r in reses)
            {
                re.Add(r.Title);
            }
            return re;
        }
    }
}
