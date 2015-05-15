using TD.CTS.Data.Entities;

namespace TD.CTS.Data.Filters
{
    public class ScheduleVisitDataFilter: DataFilter<ScheduleVisit>
    {
        public int? ScheduleVisitID { get; set; }
        public int? ScheduleID { get; set; }
     
    }
}
