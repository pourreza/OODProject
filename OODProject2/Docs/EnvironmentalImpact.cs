using OODProject_2_.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.Docs
{
    public class EnvironmentalImpact : NormalDoc
    {
        public string Title { get; set; }
        public string AffectedSource { get; set; }
        public string Type { get; set; }
        public string Duration { get; set; }
        public string Magnitude { get; set; }
        public string Location { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }
    }
}
