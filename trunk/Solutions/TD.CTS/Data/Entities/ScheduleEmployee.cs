using System;

namespace TD.CTS.Data.Entities
{
    public class ScheduleEmployee : Entity
    {
        public int ScheduleID { get; set; }
        public string SystemRoleCode { get; set; }
        public string SystemLogin { get; set; }
    }
}
