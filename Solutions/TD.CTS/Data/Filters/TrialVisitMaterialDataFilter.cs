﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.CTS.Data.Entities;

namespace TD.CTS.Data.Filters
{
    public class TrialVisitMaterialDataFilter : DataFilter<TrialVisitMaterial>
    {
        public int? Id { get; set; }

        public string TrialCode { get; set; }

        public int? TrialVisitProcedureId { get; set; }

        public int? TrialMaterialId { get; set; }
    }
}
