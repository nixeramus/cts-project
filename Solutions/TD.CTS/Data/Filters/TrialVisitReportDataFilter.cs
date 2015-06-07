using System;
using TD.CTS.Data.Entities;

namespace TD.CTS.Data.Filters
{
    public class TrialVisitReportDataFilter : DataFilter<TrialVisitReport>
    {
        public TrialVisitReportDataFilter()
            : this(DateTime.Today)
        { }

        public TrialVisitReportDataFilter(DateTime date)
        {
            DateBegin = date;
            DateEnd = date;
        }

        public DateTime DateBegin { get; set; }

        public DateTime DateEnd { get; set; }
    }
}
