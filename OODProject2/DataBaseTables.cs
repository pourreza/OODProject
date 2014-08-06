using OODProject_2_.Docs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProject2
{
    public class DataBaseTables : System.Data.Entity.DbContext
    {
        //Docs package tables
        public DbSet<Convention> Conventions { get; set; }
        /*   protected override void OnModelCreating(DbModelBuilder modelBuilder)
           {
               modelBuilder.Entity<Convention>().Property(a => a.NormalDocId).HasKey(b => b.TrNo);

           }*/
        public DbSet<EnviromentalGoal> EnviromentalGoals { get; set; }
        public DbSet<EnvironmentalImpact> EnvironmentalImpacts { get; set; }
        public DbSet<LegalRequirement> LegalRequirements { get; set; }

        /*
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
