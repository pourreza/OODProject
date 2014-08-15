using Newtonsoft.Json;
using OODProject_2_.models;
using OODProject_2_.Plannings;
using OODProject2.Docs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OODProject2.Plannings
{
    class OpGoalCatalog
    {
        public static OpGoalCatalog UniqueInstance { get; set; }
        public OpGoalCatalog()
        {
            if (UniqueInstance == null)
                UniqueInstance = this;
        }


        const string Type = "OpGoals";

        public OperationalGoal StringToDoc(string jsonData)
        {
            Dictionary<string, string> newDic = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
            OperationalGoal newDoc = new OperationalGoal
            {
                Title = newDic["title"],
                Date = newDic["date"],
                LastEditDate = DateTime.Now,
                LastEditor = "Maryam"
            };
            return newDoc;
        }

        public bool AddDoc(string jsonData)
        {
            OperationalGoal newDoc = StringToDoc(jsonData);
            if (PlanningDBFacade.find(Type, ((OperationalGoal)newDoc).Title) != null)
                return false;
            PlanningDBFacade.insert(newDoc, Type);
            return true;
        }
        
        public OperationalGoal getDetails(string searchString)
        {
            return (OperationalGoal)(PlanningDBFacade.find(Type, searchString));
        }
        
        public string getTitles()
        {
            Dictionary<int, string> data = new Dictionary<int, string>();
            List<DocInterface> result;
            int i = 0;
            result = Select();
            foreach (object o in result)
            {
                data.Add(i, ((OperationalGoal)o).Title);
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
            List<string> goals = new List<string>();
            List<string> editDates = new List<string>();
            List<string> dates = new List<string>();
            List<string> names = new List<string>();
            foreach (object o in result)
            {
                goals.Add(((OperationalGoal)o).Title);
                editDates.Add(((OperationalGoal)o).Date);
                dates.Add(((OperationalGoal)o).LastEditDate.ToString());
                names.Add(((OperationalGoal)o).LastEditor);

            }

            data.Add("عنوان هدف اجرایی", goals);
            data.Add("موعد اجرای هدف", editDates);
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
