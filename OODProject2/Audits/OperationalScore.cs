using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.Audits
{
    public class OperationalScore : Score
    {
        public short Efficiency { get; set; }
        public short Cooperation { get; set; }
        public short Commitment { get; set; }
        public short LawFault { get; set; }
        public short OnTime { get; set; }
    }
}
