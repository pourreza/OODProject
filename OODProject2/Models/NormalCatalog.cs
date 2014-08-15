using OODProject_2_.Plannings;
using OODProject2;
using OODProject2.Plannings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.models
{
   public class NormalCatalog: CatalogInterface
    {
        public string Type{ get; set; }
        public bool AddDoc(DocInterface newDoc)
        {
            if (Type.Equals("Resources") || Type.Equals("Plans"))
            {
                if (PlanningDBFacade.find(Type, ((NormalDoc)newDoc).Title) != null)
                    return false;
                PlanningDBFacade.insert(newDoc, Type);

            }
            else
            {
                if (DocDBFacade.find(Type, ((NormalDoc)newDoc).Title) != null)
                    return false;
                DocDBFacade.insert(newDoc, Type);
            }
            return true;
        }

        public void RemoveDocs(List<int> removeDocs)
        {
            PlanningDBFacade.delete(removeDocs, Type);
        }

        public List<DocInterface> ViewDocs()
        {
            if (Type.Equals("Resources") || Type.Equals("Plans"))
            {
                return PlanningDBFacade.select(Type);
            }
            else
                return DocDBFacade.select(Type);
        }

        public bool UpdateDocs(int index, DocInterface updatedDoc)
        {
            List<int> deletedList = new List<int>();
            deletedList.Add(index);
            PlanningDBFacade.delete(deletedList, Type);
            if (PlanningDBFacade.find(Type, ((NormalDoc)updatedDoc).Title) != null)
                return false;
            PlanningDBFacade.insert(updatedDoc, Type);
            return true;
        }
        public DocInterface getDetails(string searchString)
        {
            if (Type.Equals("Resources") || Type.Equals("Plans"))
                return PlanningDBFacade.find(Type, searchString);
            else
                return DocDBFacade.find(Type, searchString);
        }
        public void ViewReport()
        {
        }
    }
}
