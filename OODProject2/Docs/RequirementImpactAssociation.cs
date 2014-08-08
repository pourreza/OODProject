using OODProject_2_.Docs;
using OODProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProject2.Docs
{
    public class RequirementImpactAssociation : AssoDoc
    {

        public virtual LegalRequirement MainDoc { get; set; }
        public virtual EnvironmentalImpact RelatedDoc { get; set; }
    }
}
