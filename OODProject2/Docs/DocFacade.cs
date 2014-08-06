using OODProject_2_.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProject_2_.Docs
{
    class DocFacade
    {
        static NormalCatalog ConvCatalog = new NormalCatalog { Type = "Convention"};
        static NormalCatalog LegalRequiCatalog = new NormalCatalog { Type = "LegalRequi" };
        static NormalCatalog EnvImpactCatalog = new NormalCatalog { Type = "EnvImpacts" };
        static AuditableCatalog EnvGoalCatalog = new AuditableCatalog { Type = "EnvGoals" };
        public static string ViewDocs(string type)
        {
            Dictionary<string, List<string>> data = new Dictionary<string,List<string>>();
            List<DocInterface> result;
            if (type.Equals("EnvGoals"))
            {
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
            }
            else if (type.Equals("LegalRequi"))
            {
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
            }
            else if (type.Equals("EnvImpacts"))
            {
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

            }
            else if (type.Equals("Convention"))
            {
                result = ConvCatalog.ViewDocs();
                List<string> title = new List<string>();
                List<string> detail = new List<string>();
                List<string> dates = new List<string>();
                List<string> names = new List<string>();
                foreach (object o in result)
                {
                    detail.Add(((Convention)o).Content);
                    dates.Add(((Convention)o).LastEditDate.ToString());
                    names.Add(((Convention)o).LastEditor);
                }
                data.Add("عنوان", title);
                data.Add("متن میثاق نامه", detail);
                data.Add("تاریخ آخرین ویرایش", dates);
                data.Add("آخرین ویرایشگر", names);
            }
            else if (type.Equals("RelationEnvGoals-LegalRequi"))
            {
                List<string> goals = new List<string>();
                List<string> rels = new List<string>();
                List<string> dates = new List<string>();
                List<string> names = new List<string>();

                goals.Add("کاهش آلودگی ها");
                goals.Add("افزایش کارایی");
                goals.Add("کاهش آلاینده ها");

                rels.Add("قانون کاهش آلودگی های-قانون کاهش هوا");
                rels.Add("قانون کاهش آلودگی های-قانون کاهش هوا");
                rels.Add("قانون کاهش آلودگی های-قانون کاهش هوا-قانون کاهش اواودی");

                dates.Add(UI.PersianClass.ToPersianNumber("1393/4/2"));
                dates.Add(UI.PersianClass.ToPersianNumber("1393/4/3"));
                dates.Add(UI.PersianClass.ToPersianNumber("1393/4/1"));

                names.Add("مریم پوررضا");
                names.Add("مریم پوررضا");
                names.Add("زینب صادقی پور");

                data.Add("هدف کلان", goals);
                data.Add("ارتباطات", rels);
                data.Add("تاریخ آخرین ویرایش", dates);
                data.Add("آخرین ویرایشگر", names);
            }
            else if (type.Equals("RelationEnvGoals-OpGoals"))
            {
                List<string> goals = new List<string>();
                List<string> rels = new List<string>();
                List<string> dates = new List<string>();
                List<string> names = new List<string>();

                goals.Add("کاهش آلودگی ها");
                goals.Add("افزایش کارایی");
                goals.Add("کاهش آلاینده ها");

                rels.Add(UI.PersianClass.ToPersianNumber("تمام کردن هرچه زودتر اواودی-تمام کردن هرچه زودتر اواودی2"));
                rels.Add(UI.PersianClass.ToPersianNumber("تمام کردن هرچه زودتر اواودی"));
                rels.Add(UI.PersianClass.ToPersianNumber("تمام کردن هرچه زودتر اواودی-تمام کردن هرچه زودتر اواودی2-تمام کردن هرچه زودتر اواودی3"));
                
                dates.Add(UI.PersianClass.ToPersianNumber("1393/4/2"));
                dates.Add(UI.PersianClass.ToPersianNumber("1393/4/3"));
                dates.Add(UI.PersianClass.ToPersianNumber("1393/4/1"));

                names.Add("مریم پوررضا");
                names.Add("مریم پوررضا");
                names.Add("زینب صادقی پور");

                data.Add("هدف کلان", goals);
                data.Add("ارتباطات", rels);
                data.Add("تاریخ آخرین ویرایش", dates);
                data.Add("آخرین ویرایشگر", names);
            }
            else if (type.Equals("RelationEnvGoals-EnvImpacts"))
            {
                List<string> goals = new List<string>();
                List<string> rels = new List<string>();
                List<string> dates = new List<string>();
                List<string> names = new List<string>();

                goals.Add("کاهش آلودگی ها");
                goals.Add("افزایش کارایی");
                goals.Add("کاهش آلاینده ها");

                rels.Add(UI.PersianClass.ToPersianNumber("تاثیر دردآور اواودی"));
                rels.Add(UI.PersianClass.ToPersianNumber("تاثیر دردآور اواودی2"));
                rels.Add(UI.PersianClass.ToPersianNumber("تاثیر دردآور اواودی2-تاثیر دردآور اواودی3"));

                dates.Add(UI.PersianClass.ToPersianNumber("1393/4/2"));
                dates.Add(UI.PersianClass.ToPersianNumber("1393/4/3"));
                dates.Add(UI.PersianClass.ToPersianNumber("1393/4/1"));

                names.Add("مریم پوررضا");
                names.Add("مریم پوررضا");
                names.Add("زینب صادقی پور");

                data.Add("هدف کلان", goals);
                data.Add("ارتباطات", rels);
                data.Add("تاریخ آخرین ویرایش", dates);
                data.Add("آخرین ویرایشگر", names);
            }
            else if (type.Equals("RelationLegalRequi-EnvImpacts"))
            {
                List<string> doc = new List<string>();
                List<string> rels = new List<string>();
                List<string> dates = new List<string>();
                List<string> names = new List<string>();

                doc.Add("قانون کاهش آلودگی های");
                doc.Add("قانون کاهش هوا");
                doc.Add("قانون کاهش اواودی");

                rels.Add(UI.PersianClass.ToPersianNumber("تاثیر دردآور اواودی"));
                rels.Add(UI.PersianClass.ToPersianNumber("تاثیر دردآور اواودی2"));
                rels.Add(UI.PersianClass.ToPersianNumber("تاثیر دردآور اواودی2-تاثیر دردآور اواودی3"));

                dates.Add(UI.PersianClass.ToPersianNumber("1393/4/2"));
                dates.Add(UI.PersianClass.ToPersianNumber("1393/4/3"));
                dates.Add(UI.PersianClass.ToPersianNumber("1393/4/1"));

                names.Add("مریم پوررضا");
                names.Add("مریم پوررضا");
                names.Add("زینب صادقی پور");

                data.Add("قانون زیست محیطی", doc);
                data.Add("ارتباطات", rels);
                data.Add("تاریخ آخرین ویرایش", dates);
                data.Add("آخرین ویرایشگر", names);
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

            if (type.Equals("EnvGoals"))
            {
                EnviromentalGoal newDoc = new EnviromentalGoal { Title = newDic["goal"], 
                LastEditDate= DateTime.Now, LastEditor = "Maryam" };
                EnvGoalCatalog.AddDoc(newDoc);
            }
            else if (type.Equals("LegalRequi"))
            {
                LegalRequirement newDoc = new LegalRequirement { Title = newDic["title"], Type = newDic["type"],
                Year = newDic["year"], Fine = newDic["fine"], Description = newDic["description"],
                LastEditDate = DateTime.Now, LastEditor = "Maryam" };
                LegalRequiCatalog.AddDoc(newDoc);

            }
            else if (type.Equals("EnvImpacts"))
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
            else if (type.Equals("Convention"))
            {
                Convention newDoc = new Convention {Content = newDic["title"], LastEditDate = DateTime.Now, LastEditor= "Maryam"};
                ConvCatalog.AddDoc(newDoc);
                
            }
            else if (type.Equals("RelationEnvGoals-LegalRequi"))
            {
            }
            else if (type.Equals("RelationEnvGoals-OpGoals"))
            {
            }
            else if (type.Equals("RelationEnvGoals-EnvImpacts"))
            {
               
            }
            else if (type.Equals("RelationLegalRequi-EnvImpacts"))
            {
               
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
            if (type.Equals("EnvGoals"))
            {
                doc.Add("آلودگی هوا");
                doc.Add("آلودگی خاک");
                doc.Add("آلودگی محیط زیست");
            }
            else if (type.Equals("LegalRequi"))
            {
                doc.Add("قانون کاهش آلودگی های");
                doc.Add("قانون کاهش هوا");
                doc.Add("قانون کاهش اواودی");
                doc.Add("قانون کاهش آلودگی های");
                doc.Add("قانون کاهش هوا");
                doc.Add("قانون کاهش اواودی");
            }
            else if (type.Equals("EnvImpacts"))
            {
                doc.Add("تاثیر دردآور اواودی");
                doc.Add("تاثیر دردآور اواودی2");
                doc.Add("تاثیر دردآور اواودی3");
                doc.Add("تاثیر دردآور اواودی");
            }
            else if (type.Equals("OpGoals"))
            {
                doc.Add("تمام کردن هرچه زودتر اواودی");
                doc.Add("تمام کردن هرچه زودتر اواودی2");
                doc.Add("تمام کردن هرچه زودتر اواودی3");
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
            types.Add("هدف اجرایی");
            types.Add("هدف کلان");
            types.Add("میثاق نامه مدیریت محیطی");
            types.Add("قانون زیست محیطی");
            types.Add("تاثیر زیست محیطی");

            List<string> titles = new List<string>();
            titles.Add("کاهش آبهای زیرزمینی");
            titles.Add("کاهش آلودگی ها");
            titles.Add(UI.PersianClass.ToPersianNumber("میثاق نامه 1"));
            titles.Add("قانون حمایت از محیطی زیست");
            titles.Add("تاثیر وحشتناک اواودی بر روحیه دانشجو");

            List<string> dates = new List<string>();
            dates.Add(UI.PersianClass.ToPersianNumber("1393/4/2"));
            dates.Add(UI.PersianClass.ToPersianNumber("1393/4/3"));
            dates.Add(UI.PersianClass.ToPersianNumber("1393/4/1"));
            dates.Add(UI.PersianClass.ToPersianNumber("1393/4/3"));
            dates.Add(UI.PersianClass.ToPersianNumber("1393/4/1"));

            data.Add("نوع مستند و پرونده الکترونیک", types);
            data.Add("عنوان مستند", titles);
            data.Add("تاریخ آخرین ویرایش", dates);
            return "";
        }

        public static string GetReportDetail(string type, string title)
        {
            if (type.Equals("هدف کلان"))
            {
                // "goal"
            }
            else if (type.Equals("هدف اجرایی"))
            {
            }
            else if (type.Equals("میثاق نامه مدیریت محیطی"))
            {
            }
            else if (type.Equals("قانون زیست محیطی"))
            {
            }
            else if (type.Equals("تاثیر زیست محیطی"))
            {
            }
            return "";
        }
    }

}

