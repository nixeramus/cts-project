using System.Collections.Generic;

namespace TD.CTS.Data.Entities
{
    public class TrialVisitProcedureReport : Entity
    {
        public string ProcedureCode { get; set; }

        public string ProcedureName { get; set; }

        public bool Completed { get; set; }

        public string Notes { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
