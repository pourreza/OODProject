using OODProject_2_.models;
using OODProject_2_.Plannings;
using OODProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OODProject_2_.Docs
{
    class DocFacade
    {
        const string TypeEnvGoals = "EnvGoals";
        const string TypeLegalRequi = "LegalRequi";
        const string TypeEnvImpacts = "EnvImpacts";
        const string TypeConvention = "Convention";
        const string TypeRelGoalRequi = "RelationEnvGoals-LegalRequi";
        const string TypeRelEnvGoalOpGoal = "RelationEnvGoals-OpGoals";
        const string TypeRelGoalImpact = "RelationEnvGoals-EnvImpacts";
        const string TypeRelRequiImpact = "RelationLegalRequi-EnvImpacts";

        static NormalCatalog ConvCatalog = new NormalCatalog { Type = TypeConvention};
        static NormalCatalog LegalRequiCatalog = new NormalCatalog { Type = TypeLegalRequi };
        static NormalCatalog EnvImpactCatalog = new NormalCatalog { Type = TypeEnvImpacts };
        static AuditableCatalog EnvGoalCatalog = new AuditableCatalog { Type = TypeEnvGoals};
        static AuditableCatalog OpGoalCatalog = new AuditableCatalog { Type = "OpGoals" };
        static AssociationCatalog GoalRequiCatalog = new AssociationCatalog { Type = TypeRelGoalRequi };
        static AssociationCatalog GoalImpactCatalog = new AssociationCatalog { Type = TypeRelGoalImpact };
        static AssociationCatalog RequiImpactCatalog = new AssociationCatalog { Type = TypeRelRequiImpact };


        
        public static Dictionary<string, List<string>> ViewEnvGoals()
        {
            Dictionary<string, List<string>> data = new Dictionary<string,List<string>>();
            List<DocInterface> result;
            result = EnvGoalCatalog.ViewDocs();
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
            
            return data;

        }
        public static Dictionary<string, List<string>> ViewLegalRequi()
        {
            Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
            List<DocInterface> result;
            result = LegalRequiCatalog.ViewDocs();
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

            return data;
        }
        public static Dictionary<string, List<string>> ViewEnvImpact()
        {
            Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
            List<DocInterface> result;
            result = EnvImpactCatalog.ViewDocs();
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
            return data;
        }

        public static Dictionary<string, List<string>> ViewConvention()
        {
            Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
            List<DocInterface> result;
            result = ConvCatalog.ViewDocs();
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
            return data;
        }
        public static Dictionary<string, List<string>> ViewRelRequiImpact()
        {
            Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
            List<AssociationDoc> result;
            result = RequiImpactCatalog.ViewDocs();
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
        public static string ViewDocs(string type)
        {
            Dictionary<string, List<string>> data = new Dictionary<string,List<string>>();
            //List<DocInterface> result;
            if (type.Equals(TypeEnvGoals))
            {
                data = ViewEnvGoals();
            }
            else if (type.Equals(TypeLegalRequi))
            {
                data = ViewLegalRequi();
            }
            else if (type.Equals(TypeEnvImpacts))
            {
                data = ViewEnvImpact();
            }
            else if (type.Equals(TypeConvention))
            {
                data = ViewConvention();
            }
            else if (type.Equals(TypeRelGoalRequi))
            {

            }
            //********************Later
            else if (type.Equals(TypeRelEnvGoalOpGoal))
            {
               
            }
            else if (type.Equals(TypeRelGoalImpact))
            {
                
            }
            else if (type.Equals(TypeRelRequiImpact))
            {
                data = ViewRelRequiImpact();
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        public static void deleteDocs(string type, List<int> indexes)
        {
        }

        public static bool update(string type, int index, string data)
        {
            return true;
        }

        public static bool AddDoc(string type, string data)
        {

            Dictionary <string, string> newDic = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(data);

            if (type.Equals(TypeEnvGoals))
            {
                EnviromentalGoal newDoc = new EnviromentalGoal { Title = newDic["goal"], 
                LastEditDate= DateTime.Now, LastEditor = "Maryam" };
                EnvGoalCatalog.AddDoc(newDoc);
            }
            else if (type.Equals(TypeLegalRequi))
            {
                LegalRequirement newDoc = new LegalRequirement { Title = newDic["title"], Type = newDic["type"],
                Year = newDic["year"], Fine = newDic["fine"], Description = newDic["description"],
                LastEditDate = DateTime.Now, LastEditor = "Maryam" };
                LegalRequiCatalog.AddDoc(newDoc);

            }
            else if (type.Equals(TypeEnvImpacts))
            {
                EnvironmentalImpact newDoc = new EnvironmentalImpact
                {
                    Title = newDic["title"],
                    AffectedSource = newDic["affectedSources"], Type = newDic["type"],
                    Duration = newDic["duration"], Magnitude = newDic["magnitude"], Location = newDic["location"], 
                    Source = newDic ["source"], Description = newDic["description"],
                    LastEditDate = DateTime.Now, LastEditor = "Maryam" };
                    EnvImpactCatalog.AddDoc(newDoc);

            }
            else if (type.Equals(TypeConvention))
            {
                Convention newDoc = new Convention {Title = newDic["title"], LastEditDate = DateTime.Now, LastEditor= "Maryam"};
                ConvCatalog.AddDoc(newDoc);
                
            }
            else if (type.Equals(TypeRelGoalRequi))
            {
                string[] relDocs = newDic["rels"].Split('-');
                AssociationDoc newDoc = new AssociationDoc {MainDoc = newDic["title"], RelatedDocs = relDocs , LastEditDate = DateTime.Now, LastEditor= "Maryam"};
                GoalRequiCatalog.AddDoc(newDoc);
            }
            //***********************************later
            else if (type.Equals(TypeRelEnvGoalOpGoal))
            {
                string[] relDocs = newDic["rels"].Split('-');
                AssociationDoc newDoc = new AssociationDoc { MainDoc = newDic["title"], RelatedDocs = relDocs, LastEditDate = DateTime.Now, LastEditor = "Maryam" };
                EnvGoalCatalog.AddDoc(newDoc);  
            }
            else if (type.Equals(TypeRelGoalImpact))
            {
                string[] relDocs = newDic["rels"].Split('-');
                AssociationDoc newDoc = new AssociationDoc { MainDoc = newDic["title"], RelatedDocs = relDocs, LastEditDate = DateTime.Now, LastEditor = "Maryam" };
                GoalImpactCatalog.AddDoc(newDoc);  
            }
            else if (type.Equals(TypeRelRequiImpact))
            {
                string[] relDocs = newDic["rels"].Split('-');
                AssociationDoc newDoc = new AssociationDoc { MainDoc = newDic["title"], RelatedDocs = relDocs, LastEditDate = DateTime.Now, LastEditor = "Maryam" };
                RequiImpactCatalog.AddDoc(newDoc);  
            }
            // age beshe add kard o tekrari nabashe true barmigardunim
            return true;
        }

        public static void DeleteRelations(string type, List<string> nodes)
        {

        }

        public static List<string> GetDocsNames(string type)
        {
            List<string> doc = new List<string>();
            List<DocInterface> result;
            if (type.Equals(TypeEnvGoals))
            {
                result = EnvGoalCatalog.ViewDocs();
                foreach (object o in result)
                {
                    doc.Add(((EnviromentalGoal)o).Title);
                }
               
            }
            else if (type.Equals(TypeLegalRequi))
            {
                result = LegalRequiCatalog.ViewDocs();
                foreach (object o in result)
                {
                    doc.Add(((LegalRequirement)o).Title);
                }
                
            }
            else if (type.Equals(TypeEnvImpacts))
            {
                result = EnvImpactCatalog.ViewDocs();
                foreach (object o in result)
                {
                    doc.Add(((EnvironmentalImpact)o).Title);
                }
            }
                //******************************************Later
            else if (type.Equals("OpGoals"))
            {
                result = OpGoalCatalog.ViewDocs();
                foreach (object o in result)
                {
                    //doc.Add(((OperationalGoal)o).Title);
                }
            }

            return doc;
        }

        public static string GetAssociation(string type1, string type2)
        {
            Dictionary<string, List<string>> rel = new Dictionary<string, List<string>>();
            List<string> t1 = new List<string>();
            t1.Add("کاهش دی اکسید کربن");
            t1.Add("کاهش آلودگی");
            rel.Add("کاهش آلاینده ها", t1);
            List<string> t2 = new List<string>();
            t2.Add("کاهش دی اکسید کربن آب");
            t2.Add("کاهش آلودگی هوا");
            rel.Add("کاهش بدی ها", t2);
            string data = Newtonsoft.Json.JsonConvert.SerializeObject(rel);
            return data;
        }

        public static string ReportDocs()
        {
            // reports should be sorted by date
            Dictionary<string, List<string>> data = new Dictionary<string,List<string>>();
            List<string> types = new List<string>();
            List<string> titles = new List<string>();
            List<string> dates = new List<string>();
            List<string> names = new List<string>();

            
            List<DocInterface> resultEnvGoals = EnvGoalCatalog.ViewDocs();
            foreach (object o in resultEnvGoals)
            {
                types.Add("هدف کلان");
                titles.Add(((EnviromentalGoal)o).Title);
                dates.Add(((EnviromentalGoal)o).LastEditDate.ToString());
                dates.Add(((EnviromentalGoal)o).LastEditor);
            }
            //**************************************Later
            types.Add("هدف اجرایی");



            List<DocInterface> resultConv = ConvCatalog.ViewDocs();
            foreach (object o in resultEnvGoals)
            {
                types.Add("میثاق نامه مدیریت محیطی");
                titles.Add(((Convention)o).Title);
                dates.Add(((Convention)o).LastEditDate.ToString());
                dates.Add(((Convention)o).LastEditor);
            }


            List<DocInterface> resultEnvImpacts = EnvImpactCatalog.ViewDocs();
            foreach (object o in resultEnvImpacts)
            {
                types.Add("تاثیر زیست محیطی");
                titles.Add(((EnvironmentalImpact)o).Title);
                dates.Add(((EnvironmentalImpact)o).LastEditDate.ToString());
                dates.Add(((EnvironmentalImpact)o).LastEditor);
            }


            List<DocInterface> resultLegalRequi = LegalRequiCatalog.ViewDocs();
            foreach (object o in resultLegalRequi)
            {
                types.Add("قانون زیست محیطی");
                titles.Add(((LegalRequirement)o).Title);
                dates.Add(((LegalRequirement)o).LastEditDate.ToString());
                dates.Add(((LegalRequirement)o).LastEditor);
            }
            data.Add("نوع مستند و پرونده الکترونیک", types);
            data.Add("عنوان مستند", titles);
            data.Add("تاریخ آخرین ویرایش", dates);
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        public static string GetReportDetail(string type, string title)
        {
            Dictionary<string, string> data = new Dictionary<string,string>();
            if (type.Equals("هدف کلان"))
            {
                DocInterface result;
                result = EnvGoalCatalog.getDetails(title);
                data.Add("عنوان هدف کلان", ((EnviromentalGoal)result).Title);
                data.Add("تاریخ آخرین ویرایش", ((EnviromentalGoal)result).LastEditDate.ToString());
                data.Add("آخرین ویرایشگر", ((EnviromentalGoal)result).LastEditor);

            }
            // ********************************DO later
            else if (type.Equals("هدف اجرایی"))
            {
            }
            else if (type.Equals("میثاق نامه مدیریت محیطی"))
            {
                DocInterface result;
                result = ConvCatalog.getDetails(title);
                data.Add("متن میثاق نامه", ((Convention)result).Title);
                data.Add("تاریخ آخرین ویرایش", ((Convention)result).LastEditDate.ToString());
                data.Add("آخرین ویرایشگر", ((Convention)result).LastEditor);
            }
            else if (type.Equals("قانون زیست محیطی"))
            {
                DocInterface result;
                result = LegalRequiCatalog.getDetails(title);
                data.Add("عنوان قانون", ((LegalRequirement)result).Title);
                data.Add("نوع قانون", ((LegalRequirement)result).Type);
                data.Add("سال تصویب", ((LegalRequirement)result).Year);
                data.Add("جریمه تخلف", ((LegalRequirement)result).Fine);
                data.Add("توضیح ماده قانونی", ((LegalRequirement)result).Description);
                data.Add("تاریخ آخرین ویرایش", ((LegalRequirement)result).LastEditDate.ToString());
                data.Add("آخرین ویرایشگر", ((LegalRequirement)result).LastEditor);
            }
            else if (type.Equals("تاثیر زیست محیطی"))
            {
                DocInterface result;
                result = EnvImpactCatalog.getDetails(title);
                data.Add("عنوان تاثیر", ((EnvironmentalImpact)result).Title);
                data.Add("تاثیر روی", ((EnvironmentalImpact)result).AffectedSource);
                data.Add("نوع تاثیر", ((EnvironmentalImpact)result).Type);
                data.Add("مدت تاثیر", ((EnvironmentalImpact)result).Duration);
                data.Add("شدت تاثیر", ((EnvironmentalImpact)result).Magnitude);
                data.Add("منطقه جغرافیایی", ((EnvironmentalImpact)result).Location);
                data.Add("منبع تاثیر", ((EnvironmentalImpact)result).Source);
                data.Add("توضیح", ((EnvironmentalImpact)result).Description);
                data.Add("تاریخ آخرین ویرایش", ((EnvironmentalImpact)result).LastEditDate.ToString());
                data.Add("آخرین ویرایشگر", ((EnvironmentalImpact)result).LastEditor);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
    }

}

