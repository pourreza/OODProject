using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.models
{
    public class AssociationCatalog: CatalogInterface
    {
        public List<DocInterface> Docs { get; private set; }

        public void AddDoc(DocInterface newDoc)
        {
        }

        public void RemoveDocs(List<DocInterface> removeDocs)
        {
        }

        public List<DocInterface> ViewDocs()
        {
            return new List<DocInterface>();
        }

        public void UpdateDocs()
        {
        }

        public void ViewReport()
        {
        }
    }
}
