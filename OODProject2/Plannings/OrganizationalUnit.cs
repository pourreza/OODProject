using OODProject_2_.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.Plannings
{
    public class OrganizationalUnit : AuditableDoc
    {
        //public virtual List<Responsibility> Responsibilities { get; set; }
       
        //public ICollection<OrganizationalUnit> ChildrenUnits { get;set; }

        /*public List<int> FindList()
        {
            return new List<int>();
        }*/
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
