using OODProject_2_.Docs;
using OODProject_2_.Plannings;
using OODProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProject2.Docs
{
    public class GoalsAssociation : AssoDoc
    {
        public virtual EnviromentalGoal MainDoc { get; set; }
        public virtual OperationalGoal RelatedDoc { get; set; }
    }
}
