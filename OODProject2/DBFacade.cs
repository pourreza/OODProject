using OODProject_2_.Docs;
using OODProject_2_.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProject2
{
    class DBFacade
    {
        public static void insert(Object record, string tableType)
        {

            using (var db = new DataBaseTables())
            {
               // Console.WriteLine("Inserting");

                switch (tableType)
                {
                    case "EnvGoals":
                        db.EnviromentalGoals.Add((EnviromentalGoal)record);
                        break;
                    case "LegalRequi":
                        db.LegalRequirements.Add((LegalRequirement)record);
                        break;
                    case "EnvImpacts":
                        db.EnvironmentalImpacts.Add((EnvironmentalImpact)record);
                        break;
                    case "Convention":
                        db.Conventions.Add((Convention)record);
                        break;
                    default:
                        break;
                }
                db.SaveChanges();
            }
        }
        public static List<DocInterface> select(string tableType)
        {
            List<DocInterface> result = new List<DocInterface>();
            //Console.WriteLine("Selecting");
            using (var db = new DataBaseTables())
            {
                
                switch (tableType)
                {

                    case "EnvGoals":
                        var queryGoal = from c in db.EnviromentalGoals
                                select c;
                        foreach (var item in queryGoal)
                        {
                            result.Add(item);
                        }
                        break;
                    case "LegalRequi":
                        var queryRequi = from c in db.LegalRequirements
                                select c;
                        foreach (var item in queryRequi)
                        {
                            result.Add(item);
                        }
                        break;
                    case "EnvImpacts":
                        var queryImp = from c in db.EnvironmentalImpacts
                                       select c;
                        foreach (var item in queryImp)
                        {
                            result.Add(item);
                        }
                        break;
                    case "Convention":
                        var queryConv = from c in db.Conventions
                                       select c;
                        foreach (var item in queryConv)
                        {
                            result.Add(item);
                        }
                        break;
                    default:
                        break;
                }

                return result;
            }

        }
        public static void update(List<NormalDoc> records, short tableType)
        {
            List<int> deletedList = new List<int>();
            foreach (NormalDoc r in records)
                deletedList.Add(r.NormalDocId);
            delete(deletedList, 1);
            foreach (NormalDoc r in records)
                insert(r, "Convention");
        }
        public static void delete(List<int> recordIds, short tableType)
        {
            using (var db = new DataBaseTables())
            {
                Console.WriteLine("Deleting");

                foreach (int rId in recordIds)
                {
                    var result = from r in db.Conventions where r.NormalDocId == rId select r;

                    if (result.Count() > 0)
                    {
                        //  foreach (Convention conv in result)
                        //{
                        switch (tableType)
                        {
                            case 1:
                                db.Conventions.Remove(result.First());
                                break;
                            case 2:
                                break;
                            default:
                                break;
                        }

                        //Console.Write("delete shod");
                        //}
                    }
                    db.SaveChanges();
                }
            }
        }
    }

}
