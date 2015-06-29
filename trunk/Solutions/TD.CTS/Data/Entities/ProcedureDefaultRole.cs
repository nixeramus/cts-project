using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.CTS.Data.Entities
{
    public class ProcedureDefaultRole : Entity
    {
        public string ProcedureCode { get; set; }
        
        [Required(ErrorMessage = "Роль не выбрана")]
        public string RoleCode { get; set; }
    }
}
