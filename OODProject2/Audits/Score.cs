using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace OODProject_2_.Audits
{
    public class Score 
    {
        public DateTime date { get; private set; }
        [Key]
        public int ScoreId { get; set; }
        public void Update()
        {
        }
    }
}
