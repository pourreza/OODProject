using Newtonsoft.Json;
using OODProject_2_.models;
using OODProject_2_.Plannings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OODProject2.Plannings
{
    class PlanCatalog 
    {
        public static PlanCatalog UniqueInstance { get; set; }
        public PlanCatalog()
        {
            if (UniqueInstance == null)
                UniqueInstance = this;
        }

        const string Type = "Plans";

        public Plan StringToDoc(string jsonData)
        {
            Dictionary<string, string> newDic = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
            string[] resources = newDic["resources"].Split('-');
            List<Resource> ResourcesCollec = new List<Resource>();
            foreach (string r in resources)
            {
                ResourcesCollec.Add((Resource)ResourceCatalog.UniqueInstance.getDetails(r));
            }

            string[] responsibilities = newDic["responsibilities"].Split('-');
            List<Responsibility> ResponsibilityCollec = new List<Responsibility>();
            foreach (string r in responsibilities)
            {
                ResponsibilityCollec.Add((Responsibility)ResponCatalog.UniqueInstance.getDetails(r));
            }

            OperationalGoal op = (OperationalGoal)OpGoalCatalog.UniqueInstance.getDetails(newDic["opGoal"]);
            Plan newDoc = new Plan
            {
                Title = newDic["title"],
                OperationalGoal = op,
                OperationalGoalId = op.DocId,
                Resources = ResourcesCollec,
                Responsibilities = ResponsibilityCollec,
                LastEditDate = DateTime.Now,
                LastEditor = "Maryam"
            };
            return newDoc;
        }

        public bool AddDoc(string jsonData)
        {
            Plan newDoc = StringToDoc(jsonData);
            if (PlanningDBFacade.find(Type, ((Plan)newDoc).Title) != null)
                return false;
            PlanningDBFacade.insert(newDoc, Type);
            return true;
        }

        public Plan getDetails(string searchString)
        {
            return (Plan)(PlanningDBFacade.find(Type, searchString));
        }

        public string getTitles()
        {
            Dictionary<int, string> data = new Dictionary<int, string>();
            List<DocInterface> result;
            int i = 0;
            result = Select();
            foreach (object o in result)
            {    
                data.Add(i, ((Plan)o).Title);
                i++;
            }
            return JsonConvert.SerializeObject(data);
        }

        public List<DocInterface> Select()
        {
            return PlanningDBFacade.select(Type);
        }

        public string ViewDocs()
        {
            Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
            List<DocInterface> result;
            result = Select();
            List<string> titles = new List<string>();
            List<string> opGoal = new List<string>();
            List<string> respons = new List<string>();
            List<string> resources = new List<string>();
            List<string> dates = new List<string>();
            List<string> names = new List<string>();



            foreach (object o in result)
            {
                titles.Add(((Plan)o).Title);

                opGoal.Add(((OperationalGoal)(PlanningDBFacade.findByID("OpGoals", (((Plan)o).OperationalGoalId)))).Title);
               // opGoal.Add(((Plan)o).OperationalGoal.Title);


                List<Resource> resou = ((Plan)o).Resources;
                List<Responsibility> respo = ((Plan)o).Responsibilities;
                
                string respoString = "";
                string resouString = "";
                for (int i = 0; i < respo.Count() ; i++)
                {
                    respoString += respo[i].Title;
                    if (i < (respo.Count - 1))
                        respoString += "-";
                }
                for (int i = 0; i < resou.Count(); i++)
                {
                    resouString += resou[i].Title;
                    if (i < (resou.Count - 1))
                        resouString += "-";
                }
                respons.Add(respoString);
                resources.Add(resouString);
                dates.Add(((Plan)o).LastEditDate.ToString());
                names.Add(((Plan)o).LastEditor);
            }


            data.Add("نام منبع", titles);
            data.Add("هدف اجرایی", opGoal);
            data.Add("مسئولیت ها", respons);
            data.Add("منابع", resources);
            data.Add("تاریخ آخرین ویرایش", dates);
            data.Add("آخرین ویرایشگر", names);

            return JsonConvert.SerializeObject(data);
        }

        public void RemoveDocs(List<int> removeDocs)
        {
            PlanningDBFacade.delete(removeDocs, Type);
        }

        public bool UpdateDocs(int index, DocInterface updatedDoc)
        {
            if (PlanningDBFacade.find(Type, ((AuditableDoc)updatedDoc).Title) != null)
                return false;
            List<int> deletedList = new List<int>();
            deletedList.Add(index);
            PlanningDBFacade.delete(deletedList, Type);
            PlanningDBFacade.insert(updatedDoc, Type);
            return true;
        }
    }
}
