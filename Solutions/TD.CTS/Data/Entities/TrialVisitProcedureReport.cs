using System;
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

        public DateTime? Date { get; set; }

        public string Status
        {
            get
            {
                if (Completed)
                    return "Выполнен";
                if (Date < DateTime.Today)
                    return "Просрочен";
                return "Не выполнен";
            }
        }
    }
}
