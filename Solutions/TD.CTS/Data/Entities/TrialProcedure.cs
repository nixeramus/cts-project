using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.CTS.Data.Entities
{
    public class TrialProcedure : Entity
    {
        public int Id { get; set; }

        public string TrialCode { get; set; }

        public int TrialVersionId { get; set; }

        [Required(ErrorMessage = "Процедура не выбрана")]
        public string ProcedureCode { get; set; }

        //public List<int> VisitIds { get; set; }
    }
}
