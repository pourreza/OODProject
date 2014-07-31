using OODProject_2_.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.Docs
{
    public class EnvironmentalImpact : NormalDoc
    {
        public int EnvironmentalImpactId { get; set; }
        public string Title { get; set; }
        public List<short> AffectedSource { get; set; }
        public bool Type { get; set; }
        public short Duration { get; set; }
        public short Magnitude { get; set; }
        public string Location { get; set; }
        public short Source { get; set; }
        public string Description { get; set; }
    }
}
