using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.CTS.Data.Enums;

namespace TD.CTS.Data.Entities
{
    public class Trial : Entity
    {
        [Required(ErrorMessage = "Код не задан")]
        public string Code { get; set; }

        public int Version { get; set; }

        [Required(ErrorMessage = "Наименование не задано")]
        public string Name { get; set; }

        public TrialStatus Status { get; set; }

        public DateTime CreateDate { get; set; }

        public string AdministratorLogin { get; set; }

        public bool TaxiBooking { get; set; }

        public string TaxiService { get; set; }

        public string AuthorLogin { get; set; }

        public DateTime VersionDate { get; set; }

        public string VersionStatus { get; set; }

        public TrialStatus OriginalStatus { get; set; }

        public bool UseRandN { get; set; }
    }
}
