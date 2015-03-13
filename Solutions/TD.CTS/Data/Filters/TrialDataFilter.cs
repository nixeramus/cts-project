using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.CTS.Data.Entities;

namespace TD.CTS.Data.Filters
{
    public class TrialDataFilter : DataFilter<Trial>
    {
        public string Code { get; set; }

        public string Name { get; set; }

        //public string Status { get; set; }

        public DateTime? CreateDateBegin { get; set; }

        public DateTime? CreateDateEnd { get; set; }

        public bool? TaxiBooking { get; set; }

        public string TaxiService { get; set; }

        public bool OwnTrialsOnly { get; set; }
    }
}
