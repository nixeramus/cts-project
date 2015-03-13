using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.CTS.Data.Entities;

namespace TD.CTS.Data.Filters
{
    public class ReferalDataFilter : DataFilter<Referal>
    {
        public int? Id { get; set; }

        public string FullName { get; set; }

        public int? HospitalId { get; set; }

        public int? CityId { get; set; }

        public string WorkPlace { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
