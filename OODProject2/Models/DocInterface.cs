using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace OODProject_2_.models
{
    
    public abstract class DocInterface
    {
        public string LastEditor { get; set; }
        public DateTime LastEditDate { get; set; }
        [Key]
        public int DocId { get; set; }
        

    }
}
