using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.CTS.Data.Entities;

namespace TD.CTS.Data.Filters
{
    public class ProcedureDefaultRoleDataFilter : DataFilter<ProcedureDefaultRole>
    {
        public string ProcedureCode { get; set; }

        public string RoleCode { get; set; }
    }
}
