using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.models
{
    public interface CatalogInterface
    {
        bool AddDoc(DocInterface newDoc);
        void RemoveDocs(List<DocInterface> removeDocs);
        List <DocInterface> ViewDocs();
        void UpdateDocs();
        void ViewReport();
    }
}
