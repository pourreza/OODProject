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
    class EnvImpactCatalog
    {
        const string Type = "EnvImpacts";


        public EnvironmentalImpact StringToDoc(string jsonData)
        {
            Dictionary<string, string> newDic = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
            EnvironmentalImpact newDoc = new EnvironmentalImpact
            {
                Title = newDic["title"],
                AffectedSource = newDic["affectedSources"],
                Type = newDic["type"],
                Duration = newDic["duration"],
                Magnitude = newDic["magnitude"],
                Location = newDic["location"],
                Source = newDic["source"],
                Description = newDic["description"],
                LastEditDate = DateTime.Now,
                LastEditor = "Maryam"
            };
            return newDoc;
        }

        public bool AddDoc(string jsonData)
        {
            EnvironmentalImpact newDoc = StringToDoc(jsonData);
            if (DocDBFacade.find(Type, ((EnvironmentalImpact)newDoc).Title) != null)
                return false;
            DocDBFacade.insert(newDoc, Type);
            return true;
        }

        public EnvironmentalImpact getDetails(string searchString)
        {
            return (EnvironmentalImpact)(DocDBFacade.find(Type, searchString));
        }

        public List<string> getTitles()
        {
            List<string> doc = new List<string>();
            List<DocInterface> result;
            result = Select();
            foreach (object o in result)
            {
                doc.Add(((EnvironmentalImpact)o).Title);
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
            List<string> impactOn = new List<string>();
            List<string> impactType = new List<string>();
            List<string> duration = new List<string>();
            List<string> magnitude = new List<string>();
            List<string> location = new List<string>();
            List<string> source = new List<string>();
            List<string> description = new List<string>();
            List<string> dates = new List<string>();
            List<string> names = new List<string>();
            foreach (object o in result)
            {
                title.Add(((EnvironmentalImpact)o).Title);
                impactOn.Add(((EnvironmentalImpact)o).AffectedSource);
                impactType.Add(((EnvironmentalImpact)o).Type);
                duration.Add(((EnvironmentalImpact)o).Duration);
                magnitude.Add(((EnvironmentalImpact)o).Magnitude);
                location.Add(((EnvironmentalImpact)o).Location);
                source.Add(((EnvironmentalImpact)o).Source);
                description.Add(((EnvironmentalImpact)o).Description);
                dates.Add(((EnvironmentalImpact)o).LastEditDate.ToString());
                names.Add(((EnvironmentalImpact)o).LastEditor);
            }

            data.Add("عنوان تاثیر", title);
            data.Add("تاثیر روی", impactOn);
            data.Add("نوع تاثیر", impactType);
            data.Add("مدت تاثیر", duration);
            data.Add("شدت تاثیر", magnitude);
            data.Add("منطقه جغرافیایی", location);
            data.Add("منبع تاثیر", source);
            data.Add("توضیح", description);
            data.Add("تاریخ آخرین ویرایش", dates);
            data.Add("آخرین ویرایشگر", names);
            return JsonConvert.SerializeObject(data);
        }
    }
}
