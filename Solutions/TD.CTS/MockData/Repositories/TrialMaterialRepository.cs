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
    class TrialMaterialRepository : Repository<TrialMaterial>
    {
        public TrialMaterialRepository(IDataProvider dataProvider)
            : base(dataProvider)
        {}

        //public override List<TrialMaterial> GenerateData()
        //{
        //    var list = new List<TrialMaterial>();

        //    var trials = dataProvider.GetList(new TrialDataFilter());

        //    if (trials.Count < 1)
        //        return list;

        //    var materials = dataProvider.GetList(new MaterialDataFilter());

        //    Random rand = new Random();

        //    int id = 1;
        //    int materialsCount = materials.Count > 10 ? 10 : materials.Count;
        //    foreach (var trial in trials)
        //    {
        //        HashSet<int> set = rand.NextSet(rand.Next(0, materialsCount + 1), 0, materials.Count);

        //        list.AddRange(set.Select(i => new TrialMaterial
        //            {
        //                Id = id++,
        //                TrialCode = trial.Code,
        //                MaterialId = materials[i].Id
        //            }));

        //        //int count = rand.Next(0, materialsCount + 1);
        //        //HashSet<int> set = new HashSet<int>();
        //        //for (int i = 0; i < count; i++)
        //        //{
        //        //    var materialIndex = rand.Next(0, materials.Count);
        //        //    while (set.Contains(materialIndex))
        //        //    {
        //        //        materialIndex = rand.Next(0, materials.Count); ;
        //        //    }
        //        //    list.Add(new TrialMaterial
        //        //    { 
        //        //        Id = id,
        //        //        TrialCode = trial.Code,
        //        //        MaterialId = materials[materialIndex].Id
        //        //    });
        //        //    id++;
        //        //}
        //    }

        //    return list;
        //}

        protected override Func<TrialMaterial, bool> GetFilterFunc(DataFilter<TrialMaterial> filter)
        {
            TrialMaterialDataFilter dataFilter = (TrialMaterialDataFilter)filter;

            return e =>
                (dataFilter.TrialCode == null || e.TrialCode == dataFilter.TrialCode)
                && (dataFilter.Id == null || e.Id == dataFilter.Id)
                && (dataFilter.MaterialId == null || e.MaterialId == dataFilter.MaterialId);
        }

        protected override int GetItemIndex(TrialMaterial item)
        {
            return Data.IndexOf(e => e.Id == item.Id);
        }

        protected override void SetNewValues(TrialMaterial item)
        {
            item.Id = Data.Count > 0 ? Data.Max(e => e.Id) + 1 : 1;
        }
    }
}
