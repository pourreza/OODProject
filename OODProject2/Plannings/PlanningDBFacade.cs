using OODProject_2_.models;
using OODProject_2_.Plannings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OODProject2.Plannings
{
    class PlanningDBFacade
    {
        const string TypeOpGoals = "OpGoals";
        const string TypeResourses = "Resources";
        const string TypePlans = "Plans";
        const string TypeResponsibility = "Responsibilities";
        const string TypeOrgUnits = "OrgUnits";

        public static void insert(Object record, string tableType)
        {

            using (var db = new DataBaseTables())
            {
                switch (tableType)
                {
                    case TypeOpGoals:
                        db.OperationalGoals.Add((OperationalGoal)record);
                        break;

                    case TypeResourses:
                        db.Resources.Add((Resource)record);
                        break;

                    case TypePlans:
                        db.Plans.Attach(((Plan)record));
                        db.Plans.Add((Plan)record);
                        break;

                    case TypeResponsibility:
                        //db.OrganizationalUnits.Attach(((Responsibility)record).OrgUnit);
                        db.Responsibilities.Attach((Responsibility)record);
                        db.Responsibilities.Add((Responsibility)record);
                        break;

                    case TypeOrgUnits:
                        try 
                        {
                            db.OrganizationalUnits.Attach(((NormalOrganizationalUnit)record).ParentUnit);
                        }
                        catch (Exception e)
                        {
                        }
                        db.OrganizationalUnits.Add((OrganizationalUnit)record);
                        
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


        public static int FindRank(NormalOrganizationalUnit org)
        {
            int counter = 0;
            
            using (var db = new DataBaseTables())
            {
                
                var queryOrg = from c in db.OrganizationalUnits
                               //where (((OrganizationalUnit)findByID(TypeOrgUnits, ((NormalOrganizationalUnit)c).ParentUnitID)).Title).
                               //Equals(((OrganizationalUnit)findByID(TypeOrgUnits, ((NormalOrganizationalUnit)org).ParentUnitID)).Title)
                                orderby c.LastEditDate
                                select c;
                List<NormalOrganizationalUnit> brothers = new List<NormalOrganizationalUnit>();

                foreach (object i in queryOrg)
                {
                    try
                    {
                        if ((((OrganizationalUnit)findByID(TypeOrgUnits, ((NormalOrganizationalUnit)i).ParentUnitID)).Title).
                               Equals(((OrganizationalUnit)findByID(TypeOrgUnits, ((NormalOrganizationalUnit)org).ParentUnitID)).Title))
                                brothers.Add((NormalOrganizationalUnit)i);
                        //MessageBox.Show((((OrganizationalUnit)findByID(TypeOrgUnits, ((NormalOrganizationalUnit)i).ParentUnitID)).Title));
                    }
                    catch(InvalidCastException e)
                    {
                       
                    }
                   
                }
                foreach (NormalOrganizationalUnit n in brothers)
                {
                    if (n.Title == org.Title)
                    {
                        break;
                    }
                    counter++;
                }
            }
            return counter;
        }


        public static DocInterface find(string tableType, string searchString)
        {
            using (var db = new DataBaseTables())
            {
                DocInterface result = null;
                
                switch (tableType)
                {

                    case TypeOpGoals:
                        var queryGoal = from c in db.OperationalGoals
                                        where c.Title.Equals(searchString)
                                        select c;
                        if (queryGoal.Count() == 0)
                            return null;
                        result = queryGoal.First();
                        break;

                    case TypeResourses:
                        var queryResource = from c in db.Resources
                                        where c.Title.Equals(searchString)
                                        select c;
                        if (queryResource.Count() == 0)
                            return null;
                        result = queryResource.First();
                        break;

                    case TypeResponsibility:
                        var queryResponsibility = from c in db.Responsibilities
                                            where c.Title.Equals(searchString)
                                            select c;
                        if (queryResponsibility.Count() == 0)
                            return null;
                        result = queryResponsibility.First();
                        break;

                    case TypePlans:
                        var queryPlan = from c in db.Plans
                                                  where c.Title.Equals(searchString)
                                                  select c;
                        if (queryPlan.Count() == 0)
                            return null;
                        result = queryPlan.First();

                        List<Resource> ResourcesCollec = new List<Resource>();
                        List<Responsibility> ResponsibilityCollec = new List<Responsibility>();
                           
                        foreach (var i in ((Plan)queryPlan.First()).Resources)
                        {
                            ResourcesCollec.Add(i);
                              //  MessageBox.Show(i.Title);
                        }
                        foreach (var i in ((Plan)queryPlan.First()).Responsibilities)
                        {
                            ResponsibilityCollec.Add(i);
                                //MessageBox.Show(i.Title);
                        }
                        result = new Plan
                        {
                            Title = queryPlan.First().Title,
                            OperationalGoal = queryPlan.First().OperationalGoal,
                            OperationalGoalId = queryPlan.First().OperationalGoalId,
                            Resources = ResourcesCollec,
                            Responsibilities = ResponsibilityCollec,
                            LastEditDate = queryPlan.First().LastEditDate,
                            LastEditor = queryPlan.First().LastEditor
                        };
                        
                        break;

                    case TypeOrgUnits:
                        var queryOrg = from c in db.OrganizationalUnits
                                                  where c.Title.Equals(searchString)
                                                  select c;
                        if (queryOrg.Count() == 0)
                            return null;
                        result = queryOrg.First();
                        break;

                    default:
                        MessageBox.Show("Error!");
                        result = null;
                        break;
                }

                return result;
            }
        }


        public static DocInterface findByID(string tableType, int id)
        {
            using (var db = new DataBaseTables())
            {
                DocInterface result = null;
                switch (tableType)
                {

                    case TypeOpGoals:
                        var queryGoal = from c in db.OperationalGoals
                                        where c.DocId.Equals(id)
                                        select c;
                        if (queryGoal.Count() == 0)
                            return null;
                        result = queryGoal.First();
                        break;

                    case TypeResourses:
                        var queryResource = from c in db.Resources
                                            where c.DocId.Equals(id)
                                            select c;
                        if (queryResource.Count() == 0)
                            return null;
                        result = queryResource.First();
                        break;

                    case TypeResponsibility:
                        var queryResponsibility = from c in db.Responsibilities
                                                  where c.DocId.Equals(id)
                                                  select c;
                        if (queryResponsibility.Count() == 0)
                            return null;
                        result = queryResponsibility.First();
                        break;

                    case TypePlans:
                        var queryPlan = from c in db.Plans
                                        where c.DocId.Equals(id)
                                        select c;
                        if (queryPlan.Count() == 0)
                            return null;
                        result = queryPlan.First();
                        break;

                    case TypeOrgUnits:
                        var queryOrg = from c in db.OrganizationalUnits
                                       where c.DocId.Equals(id)
                                       select c;
                        if (queryOrg.Count() == 0)
                            return null;
                        result = queryOrg.First();
                        break;

                    default:
                        MessageBox.Show("Error!");
                        result = null;
                        break;
                }

                return result;
            }
        }



        public static List<DocInterface> select(string tableType)
        {

            List<DocInterface> result = new List<DocInterface>();
            Plan p;
            //Console.WriteLine("Selecting");
            using (var db = new DataBaseTables())
            {

                switch (tableType)
                {

                    case TypeOpGoals:
                        var queryGoal = from c in db.OperationalGoals
                                        select c;
                        foreach (var item in queryGoal)
                        {
                            result.Add(item);
                        }
                        break;

                   case TypeResourses:
                        var queryResource = from c in db.Resources
                                        select c;
                        foreach (var item in queryResource)
                        {
                            result.Add(item);
                        }
                        break;

                    case TypeResponsibility:
                        var queryResponsibility = from c in db.Responsibilities
                                        select c;
                        foreach (var item in queryResponsibility)
                        {
                            result.Add(item);
                        }
                        break;

                    case TypePlans:
                        var queryPlans = from c in db.Plans
                                        select c;
                        foreach (var item in queryPlans)
                        {
                            List<Resource> ResourcesCollec = new List<Resource>();
                            List<Responsibility> ResponsibilityCollec = new List<Responsibility>();
                           
                            foreach (var i in ((Plan)item).Resources)
                            {
                                ResourcesCollec.Add(i);
                              //  MessageBox.Show(i.Title);
                            }
                            foreach (var i in ((Plan)item).Responsibilities)
                            {
                                ResponsibilityCollec.Add(i);
                                //MessageBox.Show(i.Title);
                            }
                            p = new Plan
                            {
                                Title = item.Title,
                                OperationalGoal = item.OperationalGoal,
                                OperationalGoalId = item.OperationalGoalId,
                                Resources = ResourcesCollec,
                                Responsibilities = ResponsibilityCollec,
                                LastEditDate = item.LastEditDate,
                                LastEditor = item.LastEditor
                            };
                            result.Add(p);
                        }
                        break;

                    case TypeOrgUnits:
                        var queryOrgUnits = from c in db.OrganizationalUnits
                                        select c;
                        foreach (var item in queryOrgUnits)
                        {
                            result.Add(item);
                        }
                        break;
                    default:
                        MessageBox.Show("Error!");
                        break;
                }

                return result;
            }

        }

        public static void DeleteOrgUnit(List<string> removeDocs)
        {
            foreach (string s in removeDocs)
            {
                try
                {
                    using (var db = new DataBaseTables())
                    {
                        NormalOrganizationalUnit org = (NormalOrganizationalUnit)find( TypeOrgUnits, s);
                        org.ParentUnit = null;
                        db.OrganizationalUnits.Attach(org);
                        db.Entry(org).State = EntityState.Modified;
                        db.SaveChanges();
                        db.OrganizationalUnits.Remove(org);
                        db.SaveChanges();
                    }
                }
                catch (InvalidCastException e)
                {
                    using (var db = new DataBaseTables())
                    {
                        RootOrganizationalUnit org = (RootOrganizationalUnit)find(TypeOrgUnits, s);
                        db.OrganizationalUnits.Remove(org);
                        db.SaveChanges();
                    }

                }

            }
        }

        public static void delete(List<int> recordIds, string tableType)
        {
            using (var db = new DataBaseTables())
            {
                int counter = 0;
                switch (tableType)
                {
                    case TypeOpGoals:
                        var queryGoal = from c in db.OperationalGoals select c;
                        List <OperationalGoal> ItemsGoal = queryGoal.ToList();
                        
                        for (int i = 0; i<recordIds.Count(); i++)
                        {
                            while (recordIds[i]!=counter)
                            {
                                counter++;
                            }
                            db.OperationalGoals.Remove(ItemsGoal[counter]);
                            counter++;
                        }
                        break;

                    case TypeResourses:
                        var queryResource = from c in db.Resources select c;
                        List<Resource> ItemsResource = queryResource.ToList();
                        counter = 0;
                        for (int i = 0; i < recordIds.Count(); i++)
                        {
                            while (recordIds[i] != counter)
                            {
                                counter++;
                            }
                            db.Resources.Remove(ItemsResource[counter]);
                            counter++;
                        }
                        break;

                    case TypeResponsibility:
                        MessageBox.Show("remove");
                        var queryResponsibility = from c in db.Responsibilities select c;
                        List<Responsibility> ItemsResponsibilties = queryResponsibility.ToList();
                        counter = 0;
                        for (int i = 0; i < recordIds.Count(); i++)
                        {
                            while (recordIds[i] != counter)
                            {
                                counter++;
                            }
                            ItemsResponsibilties[counter].OrgUnit = null;
                            db.Responsibilities.Attach(ItemsResponsibilties[counter]);
                            db.Entry(ItemsResponsibilties[counter]).State = EntityState.Modified;
                            db.SaveChanges();
                            //db.Entry(ItemsResponsibilties[counter]).State = EntityState.Deleted;
                            db.Responsibilities.Remove(ItemsResponsibilties[counter]);
                            
                            counter++;
                        }
                        break;

                    case TypePlans:
                        var queryPlans = from c in db.Plans select c;
                        List<Plan> ItemsPlans = queryPlans.ToList();
                        counter = 0;
                        for (int i = 0; i < recordIds.Count(); i++)
                        {
                            while (recordIds[i] != counter)
                            {
                                counter++;
                            }
                            db.Plans.Remove(ItemsPlans[counter]);
                            counter++;
                        }
                        break;

                    case TypeOrgUnits:
                        var queryOrgs = from c in db.OrganizationalUnits select c;
                        List<OrganizationalUnit> ItemsOrgs = queryOrgs.ToList();
                        counter = 0;
                        for (int i = 0; i < recordIds.Count(); i++)
                        {
                            while (recordIds[i] != counter)
                            {
                                counter++;
                            }
                            db.OrganizationalUnits.Remove(ItemsOrgs[counter]);
                            counter++;
                        }
                        break;

                    default:
                        MessageBox.Show("Error!");
                        break;
                }
                db.SaveChanges();
            }
        }

    }

}
