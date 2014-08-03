using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProject_2_.Docs
{
    class DocFacade
    {
        public static string ViewDocs(string type)
        {
            Dictionary<string, List<string>> data = new Dictionary<string,List<string>>();

            if (type.Equals("EnvGoals"))
            {
                List<string> goals = new List<string>();
                goals.Add("کاهش آلودگی ها");
                goals.Add("افزایش کارایی");
                goals.Add("کاهش آلاینده ها");

                List<string> dates = new List<string>();
                dates.Add(UI.PersianClass.ToPersianNumber("1393/4/2"));
                dates.Add(UI.PersianClass.ToPersianNumber("1393/4/3"));
                dates.Add(UI.PersianClass.ToPersianNumber("1393/4/1"));

                List<string> names = new List<string>();
                names.Add("مریم پوررضا");
                names.Add("مریم پوررضا");
                names.Add("زینب صادقی پور");

                data.Add("عنوان هدف کلان", goals);
                data.Add("تاریخ آخرین ویرایش", dates);
                data.Add("آخرین ویرایشگر", names);
            }
            else if (type.Equals("LegalRequi"))
            {
                List<string> title = new List<string>();
                title.Add("آیین نامه جلوگیری از آلودگی هوا");
                title.Add("آیین نامه جلوگیری از آلودگی آب");
                title.Add("آیین نامه جلوگیری از آلودگی خاک");

                List<string> dates = new List<string>();
                dates.Add(UI.PersianClass.ToPersianNumber("1393/4/2"));
                dates.Add(UI.PersianClass.ToPersianNumber("1393/4/3"));
                dates.Add(UI.PersianClass.ToPersianNumber("1393/4/1"));

                List<string> names = new List<string>();
                names.Add("مریم پوررضا");
                names.Add("مریم پوررضا");
                names.Add("زینب صادقی پور");

                List<string> ltype = new List<string>();
                ltype.Add("ملی");
                ltype.Add("بین المللی");
                ltype.Add("ملی");

                List<string> year = new List<string>();
                year.Add(UI.PersianClass.ToPersianNumber("1393"));
                year.Add(UI.PersianClass.ToPersianNumber("1393"));
                year.Add(UI.PersianClass.ToPersianNumber("1393"));

                List<string> fine = new List<string>();
                fine.Add("در پایان مهلت مقرر به درخواست سازمان محیط زیست و دستور مراجع قضایی ذیربط محل که بلافاصله توسط نیروی انتظامی به مورد اجرا گذاشته می شود.");
                fine.Add("در پایان مهلت مقرر به درخواست سازمان محیط زیست و دستور مراجع قضایی ذیربط محل که بلافاصله توسط نیروی انتظامی به مورد اجرا گذاشته می شود.");
                fine.Add("در پایان مهلت مقرر به درخواست سازمان محیط زیست و دستور مراجع قضایی ذیربط محل که بلافاصله توسط نیروی انتظامی به مورد اجرا گذاشته می شود.");

                List<string> despription = new List<string>();
                despription.Add(UI.PersianClass.ToPersianNumber("با نمونه برداری و نوع میزان آلودگی هر یک از منابع آلوده کننده، در صورت عدم رعایت استانداردهای مقرر، سازمان مراتب را کتبا اخطار و صریحا نوع آلودگی و میزان آن و همچنی"));
                despription.Add(UI.PersianClass.ToPersianNumber("با نمونه برداری و نوع میزان آلودگی هر یک از منابع آلوده کننده، در صورت عدم رعایت استانداردهای مقرر، سازمان مراتب را کتبا اخطار و صریحا نوع آ"));
                despription.Add(UI.PersianClass.ToPersianNumber("با نمونه برداری و نوع میزان آلودگی هر یک از منابع آلوده کننده، در صورت عدم رعایت استانداردهای مقرر، سازمان مراتب را کتبا "));

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

                title.Add("افزایش ذرات معلق هوا");
                title.Add("افزایش ذرات معلق هوا2");
                title.Add("افزایش ذرات معلق هوا3");

                impactOn.Add("هوا");
                impactOn.Add("خاک-آب");
                impactOn.Add("منابع معدنی-خاک-هوا");

                impactType.Add("تاثیر مفید");
                impactType.Add("تاثیر مخرب");
                impactType.Add("تاثیر مفید");

                duration.Add(UI.PersianClass.ToPersianNumber("کمتر از 5 سال"));
                duration.Add(UI.PersianClass.ToPersianNumber("5 الی 10 سال"));
                duration.Add(UI.PersianClass.ToPersianNumber("بیشتر از 100 سال"));

                magnitude.Add("کم");
                magnitude.Add("کم");
                magnitude.Add("خیلی زیاد");

                location.Add("اهواز و حومه");
                location.Add("اهواز و حومه");
                location.Add("اهواز و حومه");

                source.Add("فعالیت ها");
                source.Add("فعالیت ها");
                source.Add("فعالیت ها");

                description.Add("");
                description.Add("چه قدر خوب و عالی");
                description.Add("چه قدر خوب و عالی");

                dates.Add(UI.PersianClass.ToPersianNumber("1393/4/2"));
                dates.Add(UI.PersianClass.ToPersianNumber("1393/4/3"));
                dates.Add(UI.PersianClass.ToPersianNumber("1393/4/1"));

                names.Add("مریم پوررضا");
                names.Add("مریم پوررضا");
                names.Add("زینب صادقی پور");

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
                List<string> title = new List<string>();
                List<string> detail = new List<string>();
                List<string> dates = new List<string>();
                List<string> names = new List<string>();

                title.Add(UI.PersianClass.ToPersianNumber("میثاق نامه 1"));
                title.Add(UI.PersianClass.ToPersianNumber("میثاق نامه 2"));
                title.Add(UI.PersianClass.ToPersianNumber("میثاق نامه 3"));

                detail.Add("ما باید سعی کنیم انسان های خوبی برای جامعه باشیم.");
                detail.Add("ما باید سعی کنیم انسان های خوبی برای جامعه باشیم.");
                detail.Add("ما باید سعی کنیم انسان های خوبی برای جامعه باشیم.");

                dates.Add(UI.PersianClass.ToPersianNumber("1393/4/2"));
                dates.Add(UI.PersianClass.ToPersianNumber("1393/4/3"));
                dates.Add(UI.PersianClass.ToPersianNumber("1393/4/1"));

                names.Add("مریم پوررضا");
                names.Add("مریم پوررضا");
                names.Add("زینب صادقی پور");

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

        public static void update(string type, int index, string data)
        {
        }

        public static bool AddDoc(string type, string data)
        {
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

