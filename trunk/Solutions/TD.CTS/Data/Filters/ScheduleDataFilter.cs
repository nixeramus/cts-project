using System;
using TD.CTS.Data.Entities;

namespace TD.CTS.Data.Filters
{
    public class ScheduleDataFilter: DataFilter<Schedule>
    {
        public DateTime? BeginDateBegin { get; set; }

        public DateTime? BeginDateEnd { get; set; }

        public DateTime? CreateDateBegin { get; set; }

        public DateTime? CreateDateEnd { get; set; }

        public int? ScheduleID { get; set; }
        public string TrialName { get; set; }
        public string TrialCenterName { get; set; }

        public string PatientFullName { get; set; }

        public string ScheduleStatus { get; set; }

        public bool OwnSchedulesOnly { get; set; }
    }
}
