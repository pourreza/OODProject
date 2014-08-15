using OODProject_2_.Docs;
using OODProject_2_.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.Plannings
{
    public class OperationalGoal: AuditableDoc
    {
        public string Date { get; set; }
        //public virtual EnviromentalGoal RelatedEnvGoal { get; set; }
        //public int RelatedEnvGoalId { get; set; }
    }
}
