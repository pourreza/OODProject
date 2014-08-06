using OODProject_2_.Audits;
using OODProject2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.models
{
    public class AuditableCatalog: CatalogInterface
    {
        public string Type { get; set; }

        public void AddDoc(DocInterface newDoc)
        {
            DBFacade.insert(newDoc, Type);
        }

        public void RemoveDocs(List<DocInterface> removeDocs)
        {
        }

        public List<DocInterface> ViewDocs()
        {
            return DBFacade.select(Type);
        }

        public void UpdateDocs()
        {
        }

        public void ViewReport()
        {
        }

        public void AddScores(List<Score> scores)
        {
        }

        public void UpdateLastScores()
        {
        }

        public void DeleteLastScores()
        {
        }

        public void GetLastScores()
        {
        }

        public void GetAuditByDate(DateTime date)
        {
        }

        public void GetAuditDates()
        {
        }
    }
}
