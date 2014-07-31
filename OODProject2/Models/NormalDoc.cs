
using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace OODProject_2_.models
{
    public class NormalDoc: DocInterface
    {
        public string LastEditor { get; set; }
        public DateTime LastEditDate { get; set; }
       // [Key]
        public int NormalDocId { get; set;}

        public void View()
        {
        }

        public void Update()
        {
        }
    }
}
