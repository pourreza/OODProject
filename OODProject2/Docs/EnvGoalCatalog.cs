using Newtonsoft.Json;
using OODProject_2_.Docs;
using OODProject_2_.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProject2.Docs
{
    class EnvGoalCatalog
    {
        const string Type = "EnvGoals";

        public static EnvGoalCatalog UniqueInstance { get; set; }
        public EnvGoalCatalog()
        {
            if (UniqueInstance == null)
                UniqueInstance = this;
        }


        public EnviromentalGoal StringToDoc(string jsonData)
        {
            Dictionary<string, string> newDic = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
            EnviromentalGoal newDoc = new EnviromentalGoal
            {
                Title = newDic["goal"],
                LastEditDate = DateTime.Now,
                LastEditor = "Maryam"
            };
            return newDoc;
        }

        public bool AddDoc(string jsonData)
        {
            EnviromentalGoal newDoc = StringToDoc(jsonData);
            if (DocDBFacade.find(Type, ((EnviromentalGoal)newDoc).Title) != null)
                return false;
            DocDBFacade.insert(newDoc, Type);
            return true;
        }

        public EnviromentalGoal getDetails(string searchString)
        {
            return (EnviromentalGoal)(DocDBFacade.find(Type, searchString));
        }

        public List<string> getTitles()
        {
            List<string> doc = new List<string>();
            List<DocInterface> result;
            result = Select();
            foreach (object o in result)
            {
                doc.Add(((EnviromentalGoal)o).Title);
            }
            return doc;
        }

        public List<DocInterface> Select()
        {
            return DocDBFacade.select(Type);
        }

        public string ViewDocs()
        {
            Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
            List<DocInterface> result;
            result = Select();
            List<string> goals = new List<string>();
            List<string> dates = new List<string>();
            List<string> names = new List<string>();
            foreach (object o in result)
            {
                goals.Add(((EnviromentalGoal)o).Title);
                dates.Add(((EnviromentalGoal)o).LastEditDate.ToString());
                names.Add(((EnviromentalGoal)o).LastEditor);
            }

            //        dates.Add(UI.PersianClass.ToPersianNumber("1393/4/2"));

            data.Add("عنوان هدف کلان", goals);
            data.Add("تاریخ آخرین ویرایش", dates);
            data.Add("آخرین ویرایشگر", names);
            return JsonConvert.SerializeObject(data);
        }

    }
}
