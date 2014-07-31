﻿using OODProject_2_.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.Docs
{
    public class LegalRequirement:NormalDoc
    {
        public string Title { get; set; }
        public short Type { get; set; }
        public short Year { get; set; }
        public string Fine { get; set; }
        public string Description { get; set; }
    }
}