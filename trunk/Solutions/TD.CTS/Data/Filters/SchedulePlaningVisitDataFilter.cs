﻿using TD.CTS.Data.Entities;

namespace TD.CTS.Data.Filters
{
    public class SchedulePlaningVisitDataFilter: DataFilter<SchedulePlaningVisit>
    {
        public int? ScheduleVisitID { get; set; }
    }
}
