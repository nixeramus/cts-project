using System;

namespace TD.CTS.Data.Entities
{
    public class ProcedureEmployee : Entity
    {
        public int ScheduleID { get; set; }
        public int TrialVisitID { get; set; }
        public int TrialCenterID { get; set; }
        public int TrialVersionNo { get; set; }
        public string ProcedureCode { get; set; }
        public string SystemRoleCode { get; set; }
        public string ExecutorLogin { get; set; }
    }
}
