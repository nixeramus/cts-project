using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.CTS.Data.Entities
{
    public class ProcedureCount : Entity
    {
        public string ProcedureCode { get; set; }

        public bool IsDone { get; set; }

        public int Count { get; set; }

        public DateTime VisitDate { get; set; }
    }
}
