using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.CTS.Data;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;
using TD.Common.Data;

namespace TD.CTS.MockData.Repositories
{
    class TrialVisitMaterialRepository : Repository<TrialVisitMaterial>
    {
        public TrialVisitMaterialRepository(IDataProvider dataProvider)
            : base(dataProvider)
        {}

        protected override Func<TrialVisitMaterial, bool> GetFilterFunc(DataFilter<TrialVisitMaterial> filter)
        {
            var dataFilter = (TrialVisitMaterialDataFilter)filter;

            return e =>
                (dataFilter.Id == null || e.Id == dataFilter.Id)
                && (string.IsNullOrEmpty(dataFilter.ProcedureCode) || e.ProcedureCode == dataFilter.ProcedureCode)
                && (dataFilter.TrialVisitId == null || e.TrialVisitId == dataFilter.TrialVisitId);
        }

        protected override int GetItemIndex(TrialVisitMaterial item)
        {
            return Data.IndexOf(e => e.Id == item.Id);
        }

        protected override void SetNewValues(TrialVisitMaterial item)
        {
            UpdateMaterialName(item); 
            item.Id = Data.Count > 0 ? Data.Max(e => e.Id) + 1 : 1;
        }

        public override void Update(TrialVisitMaterial item)
        {
            UpdateMaterialName(item);
            base.Update(item);
        }

        private void UpdateMaterialName(TrialVisitMaterial item)
        {
            var trialMaterial = dataProvider.GetItem(new TrialMaterialDataFilter { Id = item.TrialMaterialId });
            if (trialMaterial == null)
            {
                throw new ApplicationException("Материал не найден");
            }

            item.MaterialName = trialMaterial.Name;
        }
    }
}
