using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.CTS.Data.Entities
{
    public class TrialCenter : Entity
    {
        public int Id { get; set; }

        public string TrialCode { get; set; }

        [Required]
        public int HospitalId { get; set; }

        [Required]
        public string Number { get; set; }

        public string AnatomistLogin { get; set; }

        public string CoordinatorLogin { get; set; }
    }
}
