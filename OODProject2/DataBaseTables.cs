﻿using OODProject_2_.Docs;
using OODProject_2_.models;
using OODProject_2_.Plannings;
using OODProject2.Docs;
using OODProject2.Models;
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
        public DbSet<EnviromentalGoal> EnviromentalGoals { get; set; }
        public DbSet<EnvironmentalImpact> EnvironmentalImpacts { get; set; }
        public DbSet<LegalRequirement> LegalRequirements { get; set; }
        public DbSet<RequirementImpactAssociation> AssosRequiImpact { get; set; }
        public DbSet<GoalImpactAssociation> AssosGoalImpact { get; set; }
        public DbSet<GoalRequirementAssociation> AssosGoalRequi { get; set; }
        public DbSet<GoalsAssociation> AssosGoals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequirementImpactAssociation>().HasKey( ri=> new { ri.MainId, ri.RelatedId});
            modelBuilder.Entity<GoalImpactAssociation>().HasKey(ri => new { ri.MainId, ri.RelatedId });
            modelBuilder.Entity<GoalRequirementAssociation>().HasKey(ri => new { ri.MainId, ri.RelatedId });
            modelBuilder.Entity<GoalsAssociation>().HasKey(ri => new { ri.MainId, ri.RelatedId });



            modelBuilder.Entity<Resource>().HasMany(c => c.Plans).WithMany(p => p.Resources).
            Map(
            m =>
            {
                m.MapLeftKey("ResourceId");
                m.MapRightKey("PlanId");
                m.ToTable("PlansResources");
            });

            modelBuilder.Entity<Responsibility>().HasMany(c => c.Plans).WithMany(p => p.Responsibilities).
            Map(
            m =>
            {
                m.MapLeftKey("ResponsibilityId");
                m.MapRightKey("PlanId");
                m.ToTable("PlansResponsibilities");
            });


        }


         //Plannings package tables
         public DbSet<OperationalGoal> OperationalGoals { get; set; }
         public DbSet<Plan> Plans { get; set; }
         public DbSet<Resource> Resources { get; set; }
         public DbSet<OrganizationalUnit> OrganizationalUnits { get; set; }
         public DbSet<Responsibility> Responsibilities { get; set; }

        /*
         //Audits package tables
         public DbSet<OperationalScore> OperationalScores { get; set; }
         public DbSet<PercentageScore> PercentageScores { get; set; }
         public DbSet<PhysicalScore> PhysicalScores { get; set; }


         //Users package tables
         public DbSet<User> Users { get; set; }
         public DbSet<Role> Roles { get; set; }*/

    }
}
