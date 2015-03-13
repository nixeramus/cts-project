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

        [Required]
        public string Name { get; set; }

        [Required]
        public int Days { get; set; }

        public int Punctuality { get; set; }
    }
}
