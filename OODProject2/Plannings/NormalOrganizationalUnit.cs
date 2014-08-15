using OODProject_2_.Plannings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OODProject2.Plannings
{
    class NormalOrganizationalUnit : OrganizationalUnit
    {
        public virtual OrganizationalUnit ParentUnit { get; set; }
        public int ParentUnitID { get; set; }

        public List<int> FindList()
        {

            List<int> l2;
            try
            {
                l2 = ((NormalOrganizationalUnit)((OrganizationalUnit)PlanningDBFacade.findByID("OrgUnits", ParentUnitID))).FindList();
                l2.Add(PlanningDBFacade.FindRank((NormalOrganizationalUnit)((OrganizationalUnit)PlanningDBFacade.findByID("OrgUnits", ParentUnitID))));
            }
            catch
            {
                l2 = ((RootOrganizationalUnit)((OrganizationalUnit)PlanningDBFacade.findByID("OrgUnits", ParentUnitID))).FindList();
                l2.Add(0);
            }
            
            return l2;
        }
    }
}
