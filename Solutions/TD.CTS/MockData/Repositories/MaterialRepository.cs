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
    class MaterialRepository : Repository<Material>
    {
        private int count; 
        public MaterialRepository(IDataProvider dataProvider)
            : base(dataProvider)
        {
            this.count = 50;
        }

        public override List<Material> GenerateData()
        {
            var list = new List<Material>();

            for (int i = 1; i <= count; i++)
            {
                list.Add(new Material { Id = i, Name = "Комплект" + i });
            }

            return list;
        }

        protected override Func<Material, bool> GetFilterFunc(DataFilter<Material> filter)
        {
            MaterialDataFilter dataFilter = (MaterialDataFilter)filter;

            return e =>
                (dataFilter.Id == null || e.Id == dataFilter.Id.Value)
                && (string.IsNullOrEmpty(dataFilter.Name) || e.Name.Contains(dataFilter.Name));
        }

        protected override int GetItemIndex(Material item)
        {
            return Data.IndexOf(e => e.Id == item.Id);
        }

        protected override void SetNewValues(Material item)
        {
            item.Id = Data.Max(e => e.Id) + 1;
        }
    }
}
