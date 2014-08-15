using OODProject_2_.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.Plannings
{
    public enum ResourceType { مالی, تجهیزات, مواد };

    public class Resource : NormalDoc
    {
        public int Count { get;  set; }
        public ResourceType Type { get; set; }
        public virtual List<Plan> Plans { get; set; }
        
        public void update()
        {
        }

    }
}
