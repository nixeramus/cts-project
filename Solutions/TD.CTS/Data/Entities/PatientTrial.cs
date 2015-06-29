using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.CTS.Data.Entities
{
    public class PatientTrial : Entity
    {
        public string ScrNCode { get; set; }

        public string RandNCode { get; set; }

        public string TrialCode { get; set; }

        public string TrialName { get; set; }

        public DateTime? BeginDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
