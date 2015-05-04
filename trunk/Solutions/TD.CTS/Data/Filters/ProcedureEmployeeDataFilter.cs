using TD.CTS.Data.Entities;

namespace TD.CTS.Data.Filters
{
    public class ProcedureEmployeeDataFilter : DataFilter<ProcedureEmployee>
    {
        public int? ScheduleID { get; set; }
        public int? TrialVisitID { get; set; }
        public int? TrialCenterID { get; set; }
        public int? TrialVersionNo { get; set; }
        public string ProcedureCode { get; set; }
        public string SystemRoleCode { get; set; }
    }
}
