﻿using OODProject_2_.Audits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.models
{
    public class AuditableCatalog: CatalogInterface
    {
        public List<DocInterface> Docs { get; private set; }

        public void AddDoc(DocInterface newDoc)
        {
        }

        public void RemoveDocs(List<DocInterface> removeDocs)
        {
        }

        public void ViewDocs()
        {
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