using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.CTS.Data.Entities
{
    public class TrialCenterProcedureRole : Entity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Исследовательский центр не выбран")]
        public int TrialCenterId { get; set; }

        [Required(ErrorMessage = "Процедура не выбрана")]
        public string ProcedureCode { get; set; }

        public string TrialCode { get; set; }

        public int TrialVersionId { get; set; }

        [Required(ErrorMessage = "Роль не выбрана")]
        public string RoleCode { get; set; }
    }
}
