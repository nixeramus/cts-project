using System;

namespace TD.CTS.Data.Entities
{
    public class ScheduleVisit : Entity
    {
        public int ScheduleID { get; set; }
        public int TrialVisitID { get; set; }
        public int TrialCenterID { get; set; }
        public string TrialCode { get; set; }
        public int TrialVersionNo { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public DateTime? ActualDate { get; set; }
        public string TrialVisitName { get; set; }
        public int VisitNo { get; set; }
        public int BaseDay { get; set; }
        public int Limit { get; set; }
    }
}
