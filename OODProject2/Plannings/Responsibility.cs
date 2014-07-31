using OODProject_2_.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.Plannings
{
    public class Responsibility : AuditableDoc

    {
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<OrganizationalUnit> OrganizationalUnits { get; private set; }

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

