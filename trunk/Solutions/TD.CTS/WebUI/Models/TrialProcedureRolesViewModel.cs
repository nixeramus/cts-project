using System.Collections.Generic;
using TD.CTS.Data.Entities;
using System.Linq;

namespace TD.CTS.WebUI.Models
{
    public class TrialProcedureRolesViewModel : TrialProcedure
    {
        public static TrialProcedureRolesViewModel Create(TrialProcedure trialProcedure, IEnumerable<TrialCenterProcedureRole> roles)
        {
            return new TrialProcedureRolesViewModel
            {
                Id = trialProcedure.Id,
                ProcedureCode = trialProcedure.ProcedureCode,
                TrialCode = trialProcedure.TrialCode,
                TrialVersion = trialProcedure.TrialVersion,
                Roles = roles.Where(v => v.ProcedureCode == trialProcedure.ProcedureCode)
            };
        }

        public IEnumerable<TrialCenterProcedureRole> Roles { get; set; }
    }
}