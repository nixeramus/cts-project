using System;

namespace TD.CTS.Data.Entities
{
    public class ScheduleVisitProcedure : Entity
    {
        public int ScheduleID { get; set; }
        public int TrialVisitID { get; set; }
        public string ProcedureCode { get; set; }
        public string TrialCode { get; set; }
        public int TrialVersionNo { get; set; }
        public int TrialCenterID { get; set; }
        public string ModificataorLogin { get; set; }
        public DateTime? ModififcationDate { get; set; }
        public bool Completed{ get; set; }
    }
}
