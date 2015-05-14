using System.Collections.Generic;
using TD.CTS.Data.Entities;
using System.Linq;

namespace TD.CTS.WebUI.Models
{
    public class TrialProcedureViewModel : TrialProcedure
    {
        public static TrialProcedureViewModel Create(TrialProcedure trialProcedure, IEnumerable<TrialProcedureVisit> visits)
        {
            return new TrialProcedureViewModel
            {
                Id = trialProcedure.Id,
                ProcedureCode = trialProcedure.ProcedureCode,
                TrialCode = trialProcedure.TrialCode,
                TrialVersionId = trialProcedure.TrialVersionId,
                Visits = visits.Where(v => v.ProcedureCode == trialProcedure.ProcedureCode)
            };
        }

        public IEnumerable<TrialProcedureVisit> Visits { get; set; }
    }
}