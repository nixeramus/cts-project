using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.CTS.Data.Entities
{
    public class TrialVisit : Entity
    {
        public int Id { get; set; }

        public string TrialCode { get; set; }

        public int TrialVersion { get; set; }

        public int Number { get; set; }

        [Required(ErrorMessage = "Наименование не задано")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Смещение не задано")]
        public int Days { get; set; }

        public int Punctuality { get; set; }

        public decimal? Cost { get; set; }
    }
}
