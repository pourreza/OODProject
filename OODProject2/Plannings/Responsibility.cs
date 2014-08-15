using OODProject_2_.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.Plannings
{
    public class Responsibility : AuditableDoc

    {
        //public string BeginTime { get; set; }
        //public string EndTime { get; set; }
        public virtual List<Plan> Plans { get; set; }
        public OrganizationalUnit OrgUnit { get; set; }
        public virtual int OrgUnitId { get; set; }

        public string getPlans()
        {
            string compressedPlans = "";
            int i = 0;
            foreach (Plan p in Plans)
            {
                compressedPlans += p.Title;
                if (i != Plans.Count())
                    compressedPlans += "-"; 
                i++;
            }
            return compressedPlans;
        }
        public void SetOrganizationalUnits(List<OrganizationalUnit> orUnits)
        {
        }

        public void UpdateOrganizationalUnits(List<OrganizationalUnit> orgUnits)
        {
        }

        public void RemoveOrganizationalUnits(List<OrganizationalUnit> orgUnits)
        {
        }

        public void RemoveTiming()
        {
        }

    }
}

