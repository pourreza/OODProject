using OODProject_2_.Docs;
using OODProject_2_.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProject2.Models
{
    public class AssoDoc 
    {
        public string LastEditor { get; set; }
        public DateTime LastEditDate { get; set; }
        public int MainId { get; set; }
        public int RelatedId { get; set; }

    }
}
