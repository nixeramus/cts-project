using TD.CTS.Data.Entities;

namespace TD.CTS.Data.Filters
{
    public class ScheduleVisitProcedureDataFilter: DataFilter<ScheduleVisitProcedure>
    {
        public int ScheduleID { get; set; }
        public int? TrialVisitID { get; set; }
        public string ProcedureCode { get; set; }
    }
}
