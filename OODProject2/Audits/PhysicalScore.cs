using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.Audits
{

    public class PhysicalScore : Score
    {
        public short Efficiency { get; set; }
        public short Expectations { get; set; }
        public short Regulations { get; set; }
        public short Reliability { get; set; }
    }
}
