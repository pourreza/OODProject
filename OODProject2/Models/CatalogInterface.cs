using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.models
{
    public interface CatalogInterface
    {
        void AddDoc(DocInterface newDoc);
        void RemoveDocs(List<DocInterface> removeDocs);
        void ViewDocs();
        void UpdateDocs();
        void ViewReport();
    }
}
