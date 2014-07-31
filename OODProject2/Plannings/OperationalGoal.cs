using OODProject_2_.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.Plannings
{
    public class OperationalGoal: AuditableDoc
    {
        public Plan plan { get; private set; }

        public void setPlan(Plan newPlan)
        {
        }
    }
}
