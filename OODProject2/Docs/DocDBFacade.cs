using OODProject_2_.Docs;
using OODProject_2_.models;
using OODProject2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Validation;
using System.Diagnostics;
using OODProject2.Docs;
using OODProject_2_.Plannings;

namespace OODProject2
{
    class DocDBFacade
    {
        const string TypeEnvGoals = "EnvGoals";
        const string TypeLegalRequi = "LegalRequi";
        const string TypeEnvImpacts = "EnvImpacts";
        const string TypeConvention = "Convention";
        const string TypeRelGoalRequi = "RelationEnvGoals-LegalRequi";
        const string TypeRelEnvGoalOpGoal = "RelationEnvGoals-OpGoals";
        const string TypeRelGoalImpact = "RelationEnvGoals-EnvImpacts";
        const string TypeRelRequiImpact = "RelationLegalRequi-EnvImpacts";

        public static void insert(Object record, string tableType)
        {

            using (var db = new DataBaseTables())
            {
                switch (tableType)
                {
                    case TypeEnvGoals:
                        db.EnviromentalGoals.Add((EnviromentalGoal)record);
                        break;
                    case TypeLegalRequi:
                        db.LegalRequirements.Add((LegalRequirement)record);
                        break;
                    case TypeEnvImpacts:
                        db.EnvironmentalImpacts.Add((EnvironmentalImpact)record);
                        break;
                    case TypeConvention:
                        db.Conventions.Add((Convention)record);
                        break;
                    case TypeRelGoalRequi:
                        AssociationDoc AssGoalRequi = (AssociationDoc)record;
                        var GoalRequi = (EnviromentalGoal)find(TypeEnvGoals, AssGoalRequi.MainDoc);
                        foreach (string l in AssGoalRequi.RelatedDocs)
                        {
                            var LegalRequi = (LegalRequirement)find(TypeLegalRequi, l);
                            GoalRequirementAssociation a = new GoalRequirementAssociation { LastEditDate = AssGoalRequi.LastEditDate, LastEditor = AssGoalRequi.LastEditor, 
                               RelatedId = LegalRequi.DocId, RelatedDoc = LegalRequi, MainId = GoalRequi.DocId, MainDoc = GoalRequi};
                            db.AssosGoalRequi.Attach(a);
                            db.AssosGoalRequi.Add(a);
                           
                        }
                        break;
                    case TypeRelGoalImpact:
                        AssociationDoc AssGoalImpact = (AssociationDoc)record;
                        var GoalImpact = (EnviromentalGoal)find(TypeEnvGoals, AssGoalImpact.MainDoc);
                        foreach (string l in AssGoalImpact.RelatedDocs)
                        {
                            var EnvImpact = (EnvironmentalImpact)find(TypeEnvImpacts, l);
                            GoalImpactAssociation a = new GoalImpactAssociation { LastEditDate = AssGoalImpact.LastEditDate, LastEditor = AssGoalImpact.LastEditor, 
                                RelatedId = EnvImpact.DocId, RelatedDoc = EnvImpact, MainId = GoalImpact.DocId, MainDoc = GoalImpact};
                            db.AssosGoalImpact.Attach(a);
                            db.AssosGoalImpact.Add(a);
                           
                        }
                        break;
                    case TypeRelRequiImpact:
                        AssociationDoc AssRequiImpact = (AssociationDoc)record;
                        var EnvRequi = (LegalRequirement)find(TypeLegalRequi, AssRequiImpact.MainDoc);
                        foreach (string l in AssRequiImpact.RelatedDocs)
                        {
                            var EnvImpact = (EnvironmentalImpact)find(TypeEnvImpacts, l);
                            RequirementImpactAssociation a = new RequirementImpactAssociation { LastEditDate = AssRequiImpact.LastEditDate, LastEditor = AssRequiImpact.LastEditor, 
                                RelatedId = EnvImpact.DocId, RelatedDoc = EnvImpact, MainId = EnvRequi.DocId, MainDoc = EnvRequi};
                            db.AssosRequiImpact.Attach(a);
                            db.AssosRequiImpact.Add(a);
                        }
                        break;
                    case TypeRelEnvGoalOpGoal:
                        AssociationDoc AssEnvOpGoal = (AssociationDoc)record;
                        var EnvOpGoal = (EnviromentalGoal)find(TypeEnvGoals, AssEnvOpGoal.MainDoc);
                        foreach (string l in AssEnvOpGoal.RelatedDocs)
                        {
                            var OpGoal = (OperationalGoal)find("OpGoals", l);
                            GoalsAssociation a = new GoalsAssociation { LastEditDate = AssEnvOpGoal.LastEditDate, LastEditor = AssEnvOpGoal.LastEditor, 
                                RelatedId = OpGoal.DocId, RelatedDoc = OpGoal, MainId = EnvOpGoal.DocId, MainDoc =EnvOpGoal};
                            db.AssosGoals.Attach(a);
                            db.AssosGoals.Add(a);
                           
                        }
                        break;
                    default:
                        MessageBox.Show("Error!");
                        break;
                }
                try
                {
                    db.SaveChanges();
                }

                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            MessageBox.Show(validationError.ErrorMessage);
                            MessageBox.Show(validationError.PropertyName);
                            Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
            }
        }
        public static DocInterface find(string tableType, string searchString)
        {
            using (var db = new DataBaseTables())
            {
                DocInterface result = null ;
                switch (tableType)
                {

                    case TypeEnvGoals:
                        var queryGoal = from c in db.EnviromentalGoals where c.Title.Equals(searchString)
                                select c;
                        if (queryGoal.Count() == 0)
                            return null;
                        result = queryGoal.First();                        
                        break;
                    case TypeLegalRequi:
                        var queryRequi = from c in db.LegalRequirements where c.Title.Equals(searchString)
                                select c;
                        if (queryRequi.Count() == 0)
                            return null;
                        result = queryRequi.First();
                        break;
                    case TypeEnvImpacts:
                        var queryImp = from c in db.EnvironmentalImpacts where c.Title.Equals(searchString)
                                       select c;
                        if (queryImp.Count() == 0)
                            return null;
                        result = queryImp.First();
                        break;
                    case TypeConvention:
                        var queryConv = from c in db.Conventions where c.Title.Equals(searchString)
                                       select c;
                        if (queryConv.Count() == 0)
                            return null;
                        result = queryConv.First();
                        break;

                    //**********************************implement later
                    case "OpGoals":
                        result = null;
                        break;
                    default:
                        MessageBox.Show("Error!");
                        result = null;
                        break;
                }

                return result;
            }
        }
        public static List<AssociationDoc> selectRel (string tableType)
        {
            List<AssociationDoc> result = new List<AssociationDoc>();
            //Console.WriteLine("Selecting");
            using (var db = new DataBaseTables())
            {

                switch (tableType)
                {
                    case TypeRelGoalRequi:
                    
                        break;
                    case TypeRelGoalImpact:
                        
                        break;
                    case TypeRelRequiImpact:
                        var queryRequi= from c in db.EnviromentalGoals
                                                  select c;
                        foreach (var item in queryRequi)
                        {
                            var queryRequiInRequiImpact = from c in db.AssosRequiImpact
                                             where c.MainId == item.DocId
                                             select c;
                            
                            if (queryRequiInRequiImpact.Count() > 0)
                            {
                                AssociationDoc newAss = new AssociationDoc();
                                newAss.MainDoc = item.Title;
                                newAss.RelatedDocs = new string[queryRequiInRequiImpact.Count()];
                                int counter =0 ;
                                foreach (var r in queryRequiInRequiImpact)
                                {
                                    int relId = r.RelatedDoc.DocId;
                                    var ImpactTitle = from c in db.EnvironmentalImpacts
                                                      where c.DocId == relId
                                                      select c.Title;
                                    newAss.RelatedDocs[counter] = ImpactTitle.First();
                                    counter++;
                                }

                                newAss.LastEditor = queryRequiInRequiImpact.First().LastEditor;
                                newAss.LastEditDate = queryRequiInRequiImpact.First().LastEditDate;
                                result.Add(newAss);
                            }
                        }
                        break;
                    default:
                        MessageBox.Show("Error!");
                        break;
                }
            }
         
         return result;       
        }
        public static List<DocInterface> select(string tableType)
        {
            List<DocInterface> result = new List<DocInterface>();
            //Console.WriteLine("Selecting");
            using (var db = new DataBaseTables())
            {
                
                switch (tableType)
                {

                    case TypeEnvGoals:
                        var queryGoal = from c in db.EnviromentalGoals
                                select c;
                        foreach (var item in queryGoal)
                        {
                            result.Add(item);
                        }
                        break;
                    case TypeLegalRequi:
                        var queryRequi = from c in db.LegalRequirements
                                select c;
                        foreach (var item in queryRequi)
                        {
                            result.Add(item);
                        }
                        break;
                    case TypeEnvImpacts:
                        var queryImp = from c in db.EnvironmentalImpacts
                                       select c;
                        foreach (var item in queryImp)
                        {
                            result.Add(item);
                        }
                        break;
                    case TypeConvention:
                        var queryConv = from c in db.Conventions
                                       select c;
                        foreach (var item in queryConv)
                        {
                            result.Add(item);
                        }
                        break;
                   /* case TypeRelGoalRequi:
                        break;
                    case TypeRelGoalImpact:
                        break;
                    case TypeRelRequiImpact:
                        break;*/
                    default:
                        MessageBox.Show("Error!");
                        break;
                }

                return result;
            }

        }

        
    }

}
