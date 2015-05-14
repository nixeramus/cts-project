using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TD.CTS.Data.Entities;

namespace TD.CTS.WebUI.Models
{
    public class TrialVisitMaterialViewModel : TrialVisitMaterial
    {
        public static TrialVisitMaterialViewModel Create(TrialVisitMaterial material, string materialName)
        {
            return new TrialVisitMaterialViewModel
            {
                Id = material.Id,
                MaterialName = materialName,
                //Quantity = material.Quantity,
                TrialCode = material.TrialCode,
                TrialMaterialId = material.TrialMaterialId,
                TrialVisitProcedureId = material.TrialVisitProcedureId
            };
        }

        public string MaterialName { get; set; }
    }
}