using OODProject_2_.Audits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.models
{
    public class TreeAuditableCatalog: CatalogInterface
    {
        public List<DocInterface> Docs { get; private set; }

        public bool AddDoc(DocInterface newDoc)
        {
            return true;
        }

        public void RemoveDocs(List<int> removeDocs)
        {
        }

        public List<DocInterface> ViewDocs()
        {
            return new List<DocInterface>();
        }

        public bool UpdateDocs(int index, DocInterface updatedDoc)
        {
            return true;
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
