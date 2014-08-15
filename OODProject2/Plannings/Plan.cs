using OODProject_2_.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.Plannings
{
    public class Plan : NormalDoc
    {
        public virtual OperationalGoal OperationalGoal { get; set; }
        public virtual int OperationalGoalId { get; set; }

        public virtual List<Responsibility> Responsibilities { get; set; }
        public virtual List<Resource> Resources { get; set; }
        //public DateTime DueTime { get; set; }

        public void AddResponsibility(Responsibility res)
        {
        }

        public void UpdateResponsibilities(List<Responsibility> res)
        {
        }

        public void AddResource(Resource res)
        {
        }

        public void UpdateResources(List<Resource> res)
        {
        }

        public void RemoveSchedule()
        {
        }


        public void ViewSchedule()
        {
        }

        public void UpdateSchedule(DateTime date)
        {
        }

        
    }
}
