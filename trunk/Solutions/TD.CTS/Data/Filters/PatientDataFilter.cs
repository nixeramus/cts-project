using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.CTS.Data.Entities;

namespace TD.CTS.Data.Filters
{
    public class PatientDataFilter : DataFilter<Patient>
    {
        public int? Id { get; set; }

        public string FullName { get; set; }

        public int? HospitalId { get; set; }

        private string sourceType;
        public string SourceType
        {
            get { return sourceType; }
            set { sourceType = Patient.SourceTypes.FirstOrDefault(s => s == value); }
        }

        public int? ReferalId { get; set; }

        public DateTime? BirthDateBegin { get; set; }

        public DateTime? BirthDateEnd { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string ContactRelatives { get; set; }

        public string Initials { get; set; }
    }
}
