using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.CTS.Data.Entities;

namespace TD.CTS.Data.Filters
{
    public class TrialProcedureVisitDataFilter : DataFilter<TrialProcedureVisit>
    {
        public int? Id { get; set; }

        public int? TrialVisitId { get; set; }

        public int? TrialVersionId { get; set; }

        public string TrialCode { get; set; }
    }
}
