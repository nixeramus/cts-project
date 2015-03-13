using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.CTS.Data.Entities;

namespace TD.CTS.Data.Filters
{
    public class ProcedureDataFilter : DataFilter<Procedure>
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
