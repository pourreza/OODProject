using OODProject_2_.Audits;
using OODProject2;
using OODProject2.Plannings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.models
{
    public class AuditableCatalog: CatalogInterface
    {
        public string Type { get; set; }

        public bool AddDoc(DocInterface newDoc)
        {
            if (Type.Equals("EnvGoals"))
            {
                if (DocDBFacade.find(Type, ((AuditableDoc)newDoc).Title) != null)
                    return false;
                DocDBFacade.insert(newDoc, Type);
                return true;
            }
            else
            {
                if (PlanningDBFacade.find(Type, ((AuditableDoc)newDoc).Title) != null)
                    return false;
                PlanningDBFacade.insert(newDoc, Type);
                return true;
            }
        }


        public List<DocInterface> ViewDocs()
        {
            if (Type.Equals("EnvGoals"))
            {
                return DocDBFacade.select(Type);
            }
            else
                return PlanningDBFacade.select(Type);
        }

        public void RemoveDocs(List<int> removeDocs)
        {
            PlanningDBFacade.delete(removeDocs, Type);
        }
        public bool UpdateDocs(int index, DocInterface updatedDoc)
        {
            List<int> deletedList = new List<int>();
            deletedList.Add(index);
            PlanningDBFacade.delete(deletedList, Type);
            if (PlanningDBFacade.find(Type, ((AuditableDoc)updatedDoc).Title) != null)
                return false;
            PlanningDBFacade.insert(updatedDoc, Type);
            return true;

        }
        public DocInterface getDetails(string searchString)
        {
            if (Type.Equals("EnvGoals") )
                return DocDBFacade.find(Type, searchString);
            else
                return PlanningDBFacade.find(Type, searchString);
        }
        public void ViewReport()
        {
        }

        public void AddScores(List<Score> scores)
        {
        }

        public void UpdateLastScores()
        {
        }

        public void DeleteLastScores()
        {
        }

        public void GetLastScores()
        {
        }

        public void GetAuditByDate(DateTime date)
        {
        }

        public void GetAuditDates()
        {
        }
    }
}
