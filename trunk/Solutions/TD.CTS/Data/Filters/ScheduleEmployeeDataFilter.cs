using TD.CTS.Data.Entities;

namespace TD.CTS.Data.Filters
{
    public class ScheduleEmployeeDataFilter : DataFilter<ScheduleEmployee>
    {
        public int? ScheduleID { get; set; }
        public string SystemRoleCode { get; set; }
        public string SystemLogin { get; set; }
    }
}
