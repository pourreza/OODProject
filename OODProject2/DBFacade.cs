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
        public void insert(Object record, short tableType)
        {

            using (var db = new DataBase())
            {
                Console.WriteLine("Inserting");

                switch (tableType)
                {
                    case 1:
                        db.Conventions.Add((Convention)record);
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
                db.SaveChanges();
            }
        }
        public List<Object> select(short tableType)
        {
            List<Object> result = new List<object>();
            Console.WriteLine("Selecting");
            using (var db = new DataBase())
            {
                var query = from c in db.Conventions
                            select c;
                switch (tableType)
                {

                    case 1:
                        query = from c in db.Conventions
                                select c;
                        break;
                    case 2:
                        query = from c in db.Conventions
                                select c;
                        break;
                    default:
                        break;
                }
                foreach (var item in query)
                {
                    result.Add(item);
                }

                return result;

            }

        }
        public void update(List<NormalDoc> records, short tableType)
        {
            List<int> deletedList = new List<int>();
            foreach (NormalDoc r in records)
                deletedList.Add(r.NormalDocId);
            this.delete(deletedList, 1);
            foreach (NormalDoc r in records)
                this.insert(r, 1);
        }
        public void delete(List<int> recordIds, short tableType)
        {
            using (var db = new DataBase())
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

   public class DataBase : System.Data.Entity.DbContext
    {
        //Docs package tables
        public DbSet<Convention> Conventions { get; set; }
     /*   protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Convention>().Property(a => a.NormalDocId).HasKey(b => b.TrNo);

        }*/
       // public DbSet<EnviromentalGoal> EnviromentalGoals { get; set; }
       public DbSet<EnvironmentalImpact> EnvironmentalImpacts { get; set; }
       /* public DbSet<LegalRequirement> LegalRequirements { get; set; }


        //Plannings package tables
        public DbSet<OperationalGoal> OperationalGoals { get; set; }
        public DbSet<OrganizationalUnit> OrganizationalUnits { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Responsibility> Responsibilities { get; set; }


        //Audits package tables
        public DbSet<OperationalScore> OperationalScores { get; set; }
        public DbSet<PercentageScore> PercentageScores { get; set; }
        public DbSet<PhysicalScore> PhysicalScores { get; set; }


        //Users package tables
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }*/
 
    }
}
