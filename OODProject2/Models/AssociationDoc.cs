using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.models
{
    public class AssociationDoc: DocInterface
    {
        public string LastEditor { get; private set; }
        public DateTime LastEditDate { get; private set; }
        public DocInterface MainDoc { get; private set; }
        public List<DocInterface> RelatedDocs { get; private set; }

        public void View()
        {
            
        }

        public void Update()
        {
        }
    }
}
