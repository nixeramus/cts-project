using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TD.CTS.Data.Entities;

namespace TD.CTS.Data.Filters
{
    public class ProcedureCountDataFilter : DataFilter<ProcedureCount>
    {
        public DateTime? VisitDateBegin { get; set; }

        public DateTime? VisitDateEnd { get; set; }
    }
}
