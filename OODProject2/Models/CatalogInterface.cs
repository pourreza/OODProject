using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.models
{
    public interface CatalogInterface
    {
        bool AddDoc(DocInterface newDoc);
        void RemoveDocs(List<int> removeDocs);
        List <DocInterface> ViewDocs();
        bool UpdateDocs(int index, DocInterface updatedDoc);
        void ViewReport();
    }
}
