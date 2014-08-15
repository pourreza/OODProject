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
    class ResponCatalog
    {
        public static ResponCatalog UniqueInstance { get; set; }
        public ResponCatalog()
        {
            if (UniqueInstance == null)
                UniqueInstance = this;
        }

        const string Type = "Responsibilities";

        public Responsibility StringToDoc(string jsonData)
        {
            Dictionary<string, string> newDic = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
            OrganizationalUnit or =(OrganizationalUnit)OrgUnitCatalog.UniqueInstance.getDetails(newDic["orgUnit"]);
            Responsibility newDoc = new Responsibility
            {
                Plans = new List<Plan>(),
                Title = newDic["title"],
                OrgUnit = or,
                OrgUnitId = or.DocId,
                LastEditDate = DateTime.Now,
                LastEditor = "Maryam"
            };
            return newDoc;
        }

        public bool AddDoc(string jsonData)
        {
            Responsibility newDoc = StringToDoc(jsonData);
            if (PlanningDBFacade.find(Type, ((Responsibility)newDoc).Title) != null)
                return false;
            PlanningDBFacade.insert(newDoc, Type);
            return true;
        }

        public Responsibility getDetails(string searchString)
        {
            return (Responsibility)(PlanningDBFacade.find(Type, searchString));
        }

        public string getTitles()
        {
            Dictionary<int, string> data = new Dictionary<int, string>();
            List<DocInterface> result;
            int i = 0;
            result = Select();
            foreach (object o in result)
            {
                data.Add(i, ((Responsibility)o).Title);
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
            List<string> orgUnits = new List<string>();
            List<string> dates = new List<string>();
            List<string> names = new List<string>();
            foreach (object o in result)
            {
                //OrganizationalUnit or = ((Responsibility)o).OrgUnit;
                titles.Add(((Responsibility)o).Title);
                orgUnits.Add(((OrganizationalUnit)(PlanningDBFacade.findByID("OrgUnits", ((Responsibility)o).OrgUnitId))).Title);
                //orgUnits.Add(((Responsibility)o).OrgUnit.Title);
                dates.Add(((Responsibility)o).LastEditDate.ToString());
                names.Add(((Responsibility)o).LastEditor);

            }

            data.Add("عنوان مسئولیت", titles);
            data.Add("واحد مسئول", orgUnits);
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
