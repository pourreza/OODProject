using OODProject_2_.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.Plannings
{
    public enum ResourceType { Financial, Equipment, Materials };

    public class Resource : NormalDoc
    {
        public string Name { get; set; }
        public int Count { get; private set; }
        public ResourceType Type { get; set; }

        public void update()
        {
        }

    }
}
