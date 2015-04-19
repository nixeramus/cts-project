using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TD.CTS.WebUI.Models
{
    public class ScheduleProcedure
    {
        public int ScheduleID { get; set; }

        public string TrialCode { get; set; }
        public int TrialCenterId { get; set; }
        public int TrialVersionNo { get; set; }

        [Required]
        public string ProcedureCode { get; set; }

        public List<int> VisitIds { get; set; }
    }
}