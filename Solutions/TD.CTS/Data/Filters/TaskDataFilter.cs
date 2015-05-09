using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TD.CTS.Data.Entities;

namespace TD.CTS.Data.Filters
{
    public class TaskDataFilter : DataFilter<Task>
    {
        public int? Id { get; set; }

        public DateTime? VisitDateBegin { get; set; }

        public DateTime? VisitDateEnd { get; set; }
    }
}
