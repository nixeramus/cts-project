using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TD.CTS.Data.Entities;

namespace TD.CTS.WebUI.Models
{
    public class ProcedureSelectModel : Procedure
    {
        public static ProcedureSelectModel Create(Procedure procedure, IEnumerable<TrialProcedure> trialProcedures)
        {
            return new ProcedureSelectModel
            {
                Code = procedure.Code,
                Name = procedure.Name,
                ProcedureGroupId = procedure.ProcedureGroupId,
                ProcedureGroupPriority = procedure.ProcedureGroupPriority,
                Selected = trialProcedures.Any(p => p.ProcedureCode == procedure.Code)
            };
        }

        public bool Selected { get; set; }
    }
}