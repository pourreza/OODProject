using OODProject_2_.Audits;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace OODProject_2_.models
{
    public class AuditableDoc: DocInterface
    {
        //public string LastEditor { get; set; }
        //public DateTime LastEditDate { get; set; }
        public List<Score> Scores { get; private set; }
        public string Title { get; set; }
        //[Key]
        //public int NormalDocId { get; set; }
        public void View() 
        { 
        }

        public void Update()
        {
        }

        public void AddScore(Score score)
        {
        }

        public void UpdateScore(Score newScore)
        {
        }

        public void DeleteScore(Score score)
        {
        }

        public Score GetScoreByDate(DateTime date)
        {
            return null;
        }
    }
}
