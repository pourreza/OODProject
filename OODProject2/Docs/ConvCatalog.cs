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
    class ConvCatalog
    {
        const string Type = "Convention";


        public Convention StringToDoc(string jsonData)
        {
            Dictionary<string, string> newDic = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
            Convention newDoc = new Convention { Title = newDic["title"], LastEditDate = DateTime.Now, LastEditor = "Maryam" };
            return newDoc;
        }

        public bool AddDoc(string jsonData)
        {
            Convention newDoc = StringToDoc(jsonData);
            if (DocDBFacade.find(Type, ((Convention)newDoc).Title) != null)
                return false;
            DocDBFacade.insert(newDoc, Type);
            return true;
        }

        public Convention getDetails(string searchString)
        {
            return (Convention)(DocDBFacade.find(Type, searchString));
        }

        public List<string> getTitles()
        {
            List<string> doc = new List<string>();
            List<DocInterface> result;
            result = Select();
            foreach (object o in result)
            {
                doc.Add(((Convention)o).Title);
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
            List<string> detail = new List<string>();
            List<string> dates = new List<string>();
            List<string> names = new List<string>();
            foreach (object o in result)
            {
                detail.Add(((Convention)o).Title);
                dates.Add(((Convention)o).LastEditDate.ToString());
                names.Add(((Convention)o).LastEditor);
            }
            data.Add("متن میثاق نامه", detail);
            data.Add("تاریخ آخرین ویرایش", dates);
            data.Add("آخرین ویرایشگر", names);
            return JsonConvert.SerializeObject(data);
        }

    }
}
