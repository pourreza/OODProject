using OODProject2;
using OODProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.models
{
    public class AssociationCatalog
    {
        public string Type { get; set; }


        public AssociationDoc StringToDoc(string jsonData)
        {
            Dictionary<string, string> newDic = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
            string[] relDocs = newDic["rels"].Split('-');
            AssociationDoc newDoc = new AssociationDoc { MainDoc = newDic["title"], RelatedDocs = relDocs, LastEditDate = DateTime.Now, LastEditor = "Maryam" };
            return newDoc;
        }

        public bool AddDoc(string jsonData)
        {
            AssociationDoc newDoc = StringToDoc(jsonData);
            DocDBFacade.insert(newDoc, Type);
            return true;
        }

        public void RemoveDocs(List<DocInterface> removeDocs)
        {
        }

        public List<AssociationDoc> ViewDocs()
        {
            return DocDBFacade.selectRel(Type);
        }

        public Dictionary<string, List<string>> ViewRel()
        {
            Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
            List<AssociationDoc> result;
            result = ViewDocs();
            List<string> doc = new List<string>();
            List<string> rels = new List<string>();
            List<string> dates = new List<string>();
            List<string> names = new List<string>();


            foreach (AssociationDoc o in result)
            {
                doc.Add(o.MainDoc);
                string resStr = "";
                for (int i = 0; i < o.RelatedDocs.Count(); i++)
                {
                    resStr += o.RelatedDocs[i];
                    if (i < (o.RelatedDocs.Count() - 1))
                        resStr += "-";
                }
                rels.Add(resStr);
                dates.Add(o.LastEditDate.ToString());
                names.Add(o.LastEditor);
            }

            data.Add("سند اصلی", doc);
            data.Add("ارتباطات", rels);
            data.Add("تاریخ آخرین ویرایش", dates);
            data.Add("آخرین ویرایشگر", names);


            return data;
        }

        /*
        public Dictionary<string, List<string>> ViewRelGoalRequi()
        {
            Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
            List<AssociationDoc> result;
            result = ViewDocs();
            List<string> doc = new List<string>();
            List<string> rels = new List<string>();
            List<string> dates = new List<string>();
            List<string> names = new List<string>();


            foreach (AssociationDoc o in result)
            {
                doc.Add(o.MainDoc);
                string resStr = "";
                for (int i = 0; i < o.RelatedDocs.Count(); i++)
                {
                    resStr += o.RelatedDocs[i];
                    if (i < (o.RelatedDocs.Count() - 1))
                        resStr += "-";
                }
                rels.Add(resStr);
                dates.Add(o.LastEditDate.ToString());
                names.Add(o.LastEditor);
            }

            data.Add("قانون زیست محیطی", doc);
            data.Add("ارتباطات", rels);
            data.Add("تاریخ آخرین ویرایش", dates);
            data.Add("آخرین ویرایشگر", names);


            return data;
        }



        public Dictionary<string, List<string>> ViewRelGoalImpact()
        {
            Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
            List<AssociationDoc> result;
            result = ViewDocs();
            List<string> doc = new List<string>();
            List<string> rels = new List<string>();
            List<string> dates = new List<string>();
            List<string> names = new List<string>();


            foreach (AssociationDoc o in result)
            {
                doc.Add(o.MainDoc);
                string resStr = "";
                for (int i = 0; i < o.RelatedDocs.Count(); i++)
                {
                    resStr += o.RelatedDocs[i];
                    if (i < (o.RelatedDocs.Count() - 1))
                        resStr += "-";
                }
                rels.Add(resStr);
                dates.Add(o.LastEditDate.ToString());
                names.Add(o.LastEditor);
            }

            data.Add("قانون زیست محیطی", doc);
            data.Add("ارتباطات", rels);
            data.Add("تاریخ آخرین ویرایش", dates);
            data.Add("آخرین ویرایشگر", names);


            return data;
        }


        public Dictionary<string, List<string>> ViewRelGoals()
        {
            Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
            List<AssociationDoc> result;
            result = ViewDocs();
            List<string> doc = new List<string>();
            List<string> rels = new List<string>();
            List<string> dates = new List<string>();
            List<string> names = new List<string>();


            foreach (AssociationDoc o in result)
            {
                doc.Add(o.MainDoc);
                string resStr = "";
                for (int i = 0; i < o.RelatedDocs.Count(); i++)
                {
                    resStr += o.RelatedDocs[i];
                    if (i < (o.RelatedDocs.Count() - 1))
                        resStr += "-";
                }
                rels.Add(resStr);
                dates.Add(o.LastEditDate.ToString());
                names.Add(o.LastEditor);
            }

            data.Add("قانون زیست محیطی", doc);
            data.Add("ارتباطات", rels);
            data.Add("تاریخ آخرین ویرایش", dates);
            data.Add("آخرین ویرایشگر", names);


            return data;
        }*/

    }
}
