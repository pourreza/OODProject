using OODProject2;
using OODProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.models
{
    public class AssociationCatalog
    {
        public string Type { get; set; }

        public void AddDoc(DocInterface newDoc)
        {
            DocDBFacade.insert( newDoc,"RelationLegalRequi-EnvImpacts");
        }

        public void RemoveDocs(List<DocInterface> removeDocs)
        {
        }

        public List<AssociationDoc> ViewDocs()
        {
            return DocDBFacade.selectRel(Type);
        }

        public void UpdateDocs()
        {
        }

        public void ViewReport()
        {
        }
    }
}
