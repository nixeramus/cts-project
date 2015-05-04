using System;
using System.Collections.Generic;

namespace TD.CTS.Data.Entities
{
    public class ScheduleStatus : Entity
    {
        public string ScheduleStatusName { get; set; }

        public static List<ScheduleStatus> GetScheduleStatuses()
        {
            return new List<ScheduleStatus>
            {
                new ScheduleStatus {ScheduleStatusName = "Новое"},
                new ScheduleStatus {ScheduleStatusName = "В работе"},
                new ScheduleStatus {ScheduleStatusName = "Завершено"},
                new ScheduleStatus {ScheduleStatusName = "Прервано"}
            };
        }
    }
}
