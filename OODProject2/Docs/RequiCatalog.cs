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
    class RequiCatalog
    {
        const string Type = "LegalRequi";



        public LegalRequirement StringToDoc(string jsonData)
        {
            Dictionary<string, string> newDic = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
            LegalRequirement newDoc = new LegalRequirement
            {
                Title = newDic["title"],
                Type = newDic["type"],
                Year = newDic["year"],
                Fine = newDic["fine"],
                Description = newDic["description"],
                LastEditDate = DateTime.Now,
                LastEditor = "Maryam"
            };
            return newDoc;
        }

        public bool AddDoc(string jsonData)
        {
            LegalRequirement newDoc = StringToDoc(jsonData);
            if (DocDBFacade.find(Type, ((LegalRequirement)newDoc).Title) != null)
                return false;
            DocDBFacade.insert(newDoc, Type);
            return true;
        }

        public LegalRequirement getDetails(string searchString)
        {
            return (LegalRequirement)(DocDBFacade.find(Type, searchString));
        }

        public List<string> getTitles()
        {
            List<string> doc = new List<string>();
            List<DocInterface> result;
            result = Select();
            foreach (object o in result)
            {
                doc.Add(((LegalRequirement)o).Title);
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
            List<string> title = new List<string>();
            List<string> dates = new List<string>();
            List<string> names = new List<string>();
            List<string> ltype = new List<string>();
            List<string> year = new List<string>();
            List<string> fine = new List<string>();
            List<string> despription = new List<string>();
            foreach (object o in result)
            {
                title.Add(((LegalRequirement)o).Title);
                ltype.Add(((LegalRequirement)o).Type);
                year.Add(((LegalRequirement)o).Year);
                fine.Add(((LegalRequirement)o).Fine);
                despription.Add(((LegalRequirement)o).Description);
                dates.Add(((LegalRequirement)o).LastEditDate.ToString());
                names.Add(((LegalRequirement)o).LastEditor);
            }
            data.Add("عنوان قانون", title);
            data.Add("نوع قانون", ltype);
            data.Add("سال تصویب", year);
            data.Add("جریمه تخلف", fine);
            data.Add("توضیح ماده قانونی", despription);
            data.Add("تاریخ آخرین ویرایش", dates);
            data.Add("آخرین ویرایشگر", names);

            return JsonConvert.SerializeObject(data);

        }
    }
}
