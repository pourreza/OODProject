using Newtonsoft.Json;
using OODProject_2_.models;
using OODProject_2_.Plannings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProject2.Plannings
{
    class ResourceCatalog 
    {
        public static ResourceCatalog UniqueInstance { get; set; }
        public ResourceCatalog()
        {
            if (UniqueInstance == null)
                UniqueInstance = this;
        }

        const string Type = "Resources";

        public Resource StringToDoc(string jsonData)
        {
            Dictionary<string, string> newDic = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
            Resource newDoc = new Resource
            {
                Plans = new List<Plan>(),
                Title = newDic["title"],
                Count = Convert.ToInt32(newDic["number"]),
                Type = (ResourceType)Enum.Parse(typeof(ResourceType), newDic["type"], true),
                LastEditDate = DateTime.Now,
                LastEditor = "Maryam"
            };
            
            return newDoc;
        }

        public bool AddDoc(string jsonData)
        {
            Resource newDoc = StringToDoc(jsonData);
            if (PlanningDBFacade.find(Type, ((Resource)newDoc).Title) != null)
                return false;
            PlanningDBFacade.insert(newDoc, Type);
            return true;
        }

        public Resource getDetails(string searchString)
        {
            return (Resource)(PlanningDBFacade.find(Type, searchString));
        }

        public string getTitles()
        {
            Dictionary<int, string> data = new Dictionary<int, string>();
            List<DocInterface> result;
            int i = 0;
            result = Select();
          
            foreach (object o in result)
            {
                data.Add(i, ((Resource)o).Title);
                i++;
            }
            return JsonConvert.SerializeObject(data);
        }

        public string ViewDocs()
        {
            Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
            List<DocInterface> result;
            result = Select();
            List<string> titles = new List<string>();
            List<string> numbers = new List<string>();
            List<string> types = new List<string>();
            List<string> dates = new List<string>();
            List<string> names = new List<string>();
            foreach (object o in result)
            {
                titles.Add(((Resource)o).Title);
                numbers.Add(((Resource)o).Count.ToString());
                types.Add(((Resource)o).Type.ToString());
                dates.Add(((Resource)o).LastEditDate.ToString());
                names.Add(((Resource)o).LastEditor);

            }

            data.Add("نام منبع", titles);
            data.Add("تعداد منبع", numbers);
            data.Add("نوع منبع", types);
            data.Add("تاریخ آخرین ویرایش", dates);
            data.Add("آخرین ویرایشگر", names);

            return JsonConvert.SerializeObject(data);
        }

        public List<DocInterface> Select()
        {
            return PlanningDBFacade.select(Type);
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
