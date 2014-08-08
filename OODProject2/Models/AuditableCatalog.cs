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

        public bool AddDoc(DocInterface newDoc)
        {
            if (DocDBFacade.find(Type, ((AuditableDoc)newDoc).Title)!=null)
                return false;
            DocDBFacade.insert(newDoc, Type);
            return true;
        }

        public void RemoveDocs(List<DocInterface> removeDocs)
        {
        }

        public List<DocInterface> ViewDocs()
        {
            return DocDBFacade.select(Type);
        }

        public void UpdateDocs()
        {
        }
        public DocInterface getDetails(string searchString)
        {
            return DocDBFacade.find(Type, searchString);
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
