using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace OODProject_2_.models
{
    public class AssociationDoc: DocInterface
    {
        //public string LastEditor { get; private set; }
        //public DateTime LastEditDate { get; private set; }
        public string MainDoc { get; set; }
        public string[] RelatedDocs { get; set; }
        //[Key]
        //public int AssDocId { get; set; }
        public void View()
        {
            
        }

        public void Update()
        {
        }
    }
}
