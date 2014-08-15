using OODProject_2_.models;
using OODProject_2_.Plannings;
using OODProject2.Docs;
using OODProject2.Models;
using OODProject2.Plannings;
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


        static ConvCatalog ConvsCatalog = new ConvCatalog {};
        static RequiCatalog LegalRequisCatalog = new RequiCatalog {};
        static EnvImpactCatalog EnvImpactsCatalog = new EnvImpactCatalog {};
        static EnvGoalCatalog EnvGoalsCatalog = new EnvGoalCatalog {};
        
        static AssociationCatalog GoalRequiCatalog = new AssociationCatalog { Type = TypeRelGoalRequi };
        static AssociationCatalog GoalImpactCatalog = new AssociationCatalog { Type = TypeRelGoalImpact };
        static AssociationCatalog RequiImpactCatalog = new AssociationCatalog { Type = TypeRelRequiImpact };
        static AssociationCatalog EnvOpGoalCatalog = new AssociationCatalog { Type = TypeRelEnvGoalOpGoal };

        
 
        public static string ViewDocs(string type)
        {
            switch (type)
            {
                case TypeEnvGoals:
                    return EnvGoalsCatalog.ViewDocs();
                case TypeEnvImpacts:
                    return EnvImpactsCatalog.ViewDocs();
                case TypeConvention:
                    return ConvsCatalog.ViewDocs();
                case TypeLegalRequi:
                    return LegalRequisCatalog.ViewDocs();
                default:
                    MessageBox.Show("None of the types");
                    return "";
            }
            
        }


        public static bool AddDoc(string type, string data)
        {
            
            switch (type)
            {
                case "EnvGoal":
                    return EnvGoalsCatalog.AddDoc(data);
                case TypeLegalRequi:
                    return LegalRequisCatalog.AddDoc(data);
                case TypeConvention:
                    return ConvsCatalog.AddDoc(data);
                case TypeEnvImpacts:
                    return EnvImpactsCatalog.AddDoc(data);
                case TypeRelEnvGoalOpGoal:
                    return EnvOpGoalCatalog.AddDoc(data);
                case TypeRelGoalImpact:
                    return GoalImpactCatalog.AddDoc(data);
                case TypeRelGoalRequi:
                    return GoalRequiCatalog.AddDoc(data);
                case TypeRelRequiImpact:
                    return RequiImpactCatalog.AddDoc(data);
                default:
                    MessageBox.Show("None of the types");
                    return true;
            }
        }

        public static List<string> GetDocsNames(string type)
        {
            switch (type)
            {
                case TypeEnvGoals:
                    return EnvGoalsCatalog.getTitles();
                case TypeLegalRequi:
                    return LegalRequisCatalog.getTitles();
                case TypeConvention:
                    return ConvsCatalog.getTitles();
                case TypeEnvImpacts:
                    return EnvImpactsCatalog.getTitles();
                default:
                    MessageBox.Show("None of the types");
                    return new List<string>();

            }
           
        }

        public static string GetAssociation(string type1, string type2)
        {


            return Newtonsoft.Json.JsonConvert.SerializeObject(RequiImpactCatalog.ViewRel());
            /*
            if (type1.Equals() && type2.Equals())
                return Newtonsoft.Json.JsonConvert.SerializeObject(RequiImpactCatalog.ViewRelRequiImpact());
            else if (type1.Equals() && type2.Equals())
                return Newtonsoft.Json.JsonConvert.SerializeObject(GoalImpactCatalog.ViewRelGoalRequi());
            else if (type1.Equals() && type2.Equals())
                return Newtonsoft.Json.JsonConvert.SerializeObject(RequiImpactCatalog.ViewRelGoalImpact());
            else if (type1.Equals() && type2.Equals())
                return Newtonsoft.Json.JsonConvert.SerializeObject(EnvOpGoalCatalog.ViewRelGoals());*/
      
        }

        public static void deleteDocs(string type, List<int> indexes)
        {
        }

        public static bool update(string type, int index, string data)
        {
            return true;
        }
        public static void DeleteRelations(string type, List<string> nodes)
        {

        }
        public static string ReportDocs()
        {
            // reports should be sorted by date
            Dictionary<string, List<string>> data = new Dictionary<string,List<string>>();
            List<string> types = new List<string>();
            List<string> titles = new List<string>();
            List<string> dates = new List<string>();
            List<string> names = new List<string>();

            
            List<DocInterface> resultEnvGoals = EnvGoalsCatalog.Select();
            foreach (object o in resultEnvGoals)
            {
                types.Add("هدف کلان");
                titles.Add(((EnviromentalGoal)o).Title);
                dates.Add(((EnviromentalGoal)o).LastEditDate.ToString());
                dates.Add(((EnviromentalGoal)o).LastEditor);
            }
            //**************************************Later
            types.Add("هدف اجرایی");



            List<DocInterface> resultConv = ConvsCatalog.Select();
            foreach (object o in resultEnvGoals)
            {
                types.Add("میثاق نامه مدیریت محیطی");
                titles.Add(((Convention)o).Title);
                dates.Add(((Convention)o).LastEditDate.ToString());
                dates.Add(((Convention)o).LastEditor);
            }


            List<DocInterface> resultEnvImpacts = EnvImpactsCatalog.Select();
            foreach (object o in resultEnvImpacts)
            {
                types.Add("تاثیر زیست محیطی");
                titles.Add(((EnvironmentalImpact)o).Title);
                dates.Add(((EnvironmentalImpact)o).LastEditDate.ToString());
                dates.Add(((EnvironmentalImpact)o).LastEditor);
            }


            List<DocInterface> resultLegalRequi = LegalRequisCatalog.Select();
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
                result = EnvGoalsCatalog.getDetails(title);
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
                result = ConvsCatalog.getDetails(title);
                data.Add("متن میثاق نامه", ((Convention)result).Title);
                data.Add("تاریخ آخرین ویرایش", ((Convention)result).LastEditDate.ToString());
                data.Add("آخرین ویرایشگر", ((Convention)result).LastEditor);
            }
            else if (type.Equals("قانون زیست محیطی"))
            {
                DocInterface result;
                result = LegalRequisCatalog.getDetails(title);
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
                result = EnvImpactsCatalog.getDetails(title);
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

