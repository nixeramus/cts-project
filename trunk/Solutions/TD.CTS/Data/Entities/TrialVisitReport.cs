using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.CTS.Data.Entities
{
    public class TrialVisitReport : Entity
    {
        public string TrialCode { get; set; }

        public int TrialVersion { get; set; }

        public string TrialName { get; set; }

        public int TrialVisitId { get; set; }

        public string TrialVisitName { get; set; }

        public DateTime Date { get; set; }

        public int PatientId { get; set; }

        public string PatientName { get; set; }

        public string Status { get; set; }
    }
}
