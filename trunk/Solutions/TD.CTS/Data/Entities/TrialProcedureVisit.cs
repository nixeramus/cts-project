using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.CTS.Data.Entities
{
    public class TrialProcedureVisit : Entity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Нет привязки к процедуре")]
        public string ProcedureCode { get; set; }

        [Required(ErrorMessage = "Нет привязки к визиту")]
        public int TrialVisitId { get; set; }

        public int TrialVersion { get; set; }

        public string TrialCode { get; set; }
    }
}
