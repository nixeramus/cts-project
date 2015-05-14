using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.CTS.Data.Entities
{
    public class TrialVisitMaterial : Entity
    {
        public int Id { get; set; }

        public int TrialVisitProcedureId { get; set; }

        [Required(ErrorMessage="Материал не задан")]
        public int TrialMaterialId { get; set; }

        //[Required]
        //[Range(1, int.MaxValue, ErrorMessage="Количество должно быть больше 0")]
        //public int Quantity { get; set; }

        public string TrialCode { get; set; }
    }
}
