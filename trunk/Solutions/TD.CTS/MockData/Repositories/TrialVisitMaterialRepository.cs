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

        public override List<TrialVisitMaterial> GenerateData()
        {
            var list = new List<TrialVisitMaterial>();

            //var trials = dataProvider.GetList(new TrialDataFilter());

            //if (trials.Count < 1)
            //    return list;

            //Random rand = new Random();

            //int id = 1;
            //foreach (var trial in trials)
            //{
            //    int count = rand.Next(1, 7);
            //    int days = 0;
            //    int maxPunctuality = 0;
            //    for (int i = 0; i < count; i++)
            //    {
            //        list.Add(new TrialVisit
            //        {
            //            Id = id,
            //            TrialCode = trial.Code,
            //            Name = "Визит " + (i + 1),
            //            Days = days,
            //            Punctuality = days == 0 ? 0 : rand.Next(1, maxPunctuality)
            //        });
            //        id++;
            //        maxPunctuality = rand.Next(1, 8);
            //        days = days + rand.Next(1, 8);
            //    }
            //}

            return list;
        }

        protected override Func<TrialVisitMaterial, bool> GetFilterFunc(DataFilter<TrialVisitMaterial> filter)
        {
            var dataFilter = (TrialVisitMaterialDataFilter)filter;

            return e =>
                (dataFilter.Id == null || e.Id == dataFilter.Id)
                && (dataFilter.TrialProcedureId == null || e.TrialProcedureId == dataFilter.TrialProcedureId)
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
            if (trialMaterial != null)
            {
                var material = dataProvider.GetItem(new MaterialDataFilter { Id = trialMaterial.MaterialId });
                if (material != null)
                {
                    item.MaterialName = material.Name;
                    return;
                }
            }

            throw new ApplicationException("Матереиал не найден");
        }
    }
}
