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
    class OrgUnitCatalog
    {
        public static OrgUnitCatalog UniqueInstance { get; set; }
        public OrgUnitCatalog()
        {
            if (UniqueInstance == null)
                UniqueInstance = this;
        }

        const string Type = "OrgUnits";

        public OrganizationalUnit StringToDoc (string jsonData)
        {
            Dictionary<string, string> newDic = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
            OrganizationalUnit newDoc;

            if (newDic["parent"] == "ندارد")
            {
                newDoc = new RootOrganizationalUnit
                {
                    Title = newDic["title"],
                    LastEditDate = DateTime.Now,
                    LastEditor = "Maryam"
                };
            }
            else
            {
                OrganizationalUnit or =(OrganizationalUnit)OrgUnitCatalog.UniqueInstance.getDetails(newDic["parent"]);
                newDoc = new NormalOrganizationalUnit
                {
                    Title = newDic["title"],
                    ParentUnit = or,
                    ParentUnitID = or.DocId,
                    LastEditDate = DateTime.Now,
                    LastEditor = "Maryam"
                };
            }
            return newDoc;
        }
        public bool AddDoc(string jsonData)
        {
            OrganizationalUnit newDoc = StringToDoc(jsonData);
            if (PlanningDBFacade.find(Type, ((OrganizationalUnit)newDoc).Title) != null)
                return false;
            PlanningDBFacade.insert(newDoc, Type);
            return true;
        }
        public OrganizationalUnit getDetails(string searchString)
        {
            return (OrganizationalUnit)(PlanningDBFacade.find(Type, searchString));
        }
        public string getTitles()
        {
            Dictionary<int, string> data = new Dictionary<int, string>();
            List<DocInterface> result;
            int i = 0;
            result = Select();
            data.Add(0, "ندارد");
            
            foreach (object o in result)
            {
                i++;
                data.Add(i, ((OrganizationalUnit)o).Title);
            }
            return JsonConvert.SerializeObject(data);
        }
        public List<DocInterface> Select()
        {
            return PlanningDBFacade.select(Type);
        }

        public string ViewDocs()
        {
            Dictionary<string, List<int>> data = new Dictionary<string, List<int>>();
            List<DocInterface> result = Select();

            foreach (object o in result)
            {

                List<int> path;
                try
                {
                    path = ((NormalOrganizationalUnit)o).FindList();
                }
                catch
                {
                    path = ((RootOrganizationalUnit)o).FindList();
                }
                data.Add(((OrganizationalUnit)o).Title, path);
            }
           // MessageBox.Show(JsonConvert.SerializeObject(data));
            return JsonConvert.SerializeObject(data);
        }

        public void RemoveDocs(List<string> removeDocs)
        {
            PlanningDBFacade.DeleteOrgUnit(removeDocs);
        }

    }
}
