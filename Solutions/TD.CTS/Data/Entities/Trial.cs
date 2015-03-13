using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.CTS.Data.Entities
{
    public class Trial : Entity
    {
        [Required]
        public string Code { get; set; }

        public int Version { get; set; }

        [Required]
        public string Name { get; set; }

        public string Status { get; set; }

        public DateTime CreateDate { get; set; }

        public string AdministratorLogin { get; set; }

        public bool TaxiBooking { get; set; }

        public string TaxiService { get; set; }

        public string AuthorLogin { get; set; }

        public DateTime VersionDate { get; set; }

        public string VersionStatus { get; set; }

        public bool Approved { get; set; }
    }
}
