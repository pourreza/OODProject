using OODProject_2_.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.Plannings
{
    public class OrganizationalUnit : AuditableDoc
    {
        public List<Responsibility> Responsibilities { get; private set; }
        public OrganizationalUnit ParentUnit { get; private set; }
        public List<OrganizationalUnit> ChildrenUnits { get; private set; }

        public void AddResponsibility(Responsibility responsibility)
        {
        }

        public void removeResponsibility(Responsibility responsibility)
        {
        }

        public void ChangeParent(OrganizationalUnit newParent)
        {
        }

        public void AddChildUnit(OrganizationalUnit child)
        {
        }

        public void RemoveChildUnit(OrganizationalUnit child)
        {
        }


    }
}
