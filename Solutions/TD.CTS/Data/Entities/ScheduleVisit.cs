using System;
using System.ComponentModel.DataAnnotations;

namespace TD.CTS.Data.Entities
{
    public class ScheduleVisit : Entity
    {
        //nulable т.к. я возвращаюю и визиты запланированные и не запланированные
        public int? Id { get; set; }
        public int ScheduleID { get; set; }
        public int TrialVisitID { get; set; }
        public int TrialCenterID { get; set; }
        public string TrialCode { get; set; }
        public int TrialVersionNo { get; set; }
        //[Required(ErrorMessage = "Дата не задана")]
        public DateTime? ScheduleDate { get; set; }
        public DateTime? ActualDate { get; set; }
        public string TrialVisitName { get; set; }
        public int VisitNo { get; set; }
        public int BaseDay { get; set; }
        public int Limit { get; set; }

        public DateTime? MinDate { get; set; }
        public DateTime? MaxDate { get; set; }

        public bool Canceled { get; set; }
        
    }
}
