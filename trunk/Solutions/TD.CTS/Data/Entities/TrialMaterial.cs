using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.CTS.Data.Entities
{
    public class TrialMaterial : Entity
    {
        public int Id { get; set; }

        public string TrialCode { get; set; }

        [Required(ErrorMessage = "Материал не выбран")]
        public int MaterialId { get; set; }
    }
}
