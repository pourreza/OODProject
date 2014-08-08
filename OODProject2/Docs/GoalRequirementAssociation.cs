using OODProject_2_.Docs;
using OODProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProject2.Docs
{
    public class GoalRequirementAssociation : AssoDoc
    {
        public virtual EnviromentalGoal MainDoc { get; set; }
        public virtual LegalRequirement RelatedDoc { get; set; }
    }
}
