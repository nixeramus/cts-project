using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.CTS.Data.Entities
{
    public class Referal : Entity
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public int HospitalId { get; set; }

        public int? CityId { get; set; }

        public string WorkPlace { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
