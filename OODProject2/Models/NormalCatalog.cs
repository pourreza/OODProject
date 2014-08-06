using OODProject2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.models
{
   public class NormalCatalog: CatalogInterface
    {
        public string Type{ get; set; }
        public void AddDoc(DocInterface newDoc)
        {
            DBFacade.insert( newDoc, Type);
        }

        public void RemoveDocs(List<DocInterface> removeDocs)
        {
        }

        public List<DocInterface> ViewDocs()
        {
            return DBFacade.select(Type);
        }

        public void UpdateDocs()
        {
        }

        public void ViewReport()
        {
        }
    }
}
