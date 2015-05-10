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
    class TrialVersionRepository : Repository<TrialVersion>
    {
        public TrialVersionRepository(IDataProvider dataProvider)
            : base(dataProvider)
        {}

        public override List<TrialVersion> GenerateData()
        {
            var list = new List<TrialVersion>();
            if (dataProvider == null)
                return list;

            var trial = dataProvider.GetItem(new TrialDataFilter());

            list.Add(new TrialVersion{ 
                Id = 1, 
                TrialCode = trial.Code, 
                AuthorLogin = trial.AuthorLogin, 
                VersionDate = trial.CreateDate, 
                VersionStatus = "Активная"
            });

            list.Add(new TrialVersion
            {
                Id = 2,
                TrialCode = trial.Code,
                AuthorLogin = trial.AuthorLogin,
                VersionDate = trial.CreateDate,
                VersionStatus = "Неактивная"
            });

            return list;
        }

        protected override Func<TrialVersion, bool> GetFilterFunc(DataFilter<TrialVersion> filter)
        {
            var dataFilter = (TrialVersionDataFilter)filter;

            return e =>
                (dataFilter.TrialCode == null || e.TrialCode == dataFilter.TrialCode)
                && (dataFilter.Id == null || e.Id == dataFilter.Id);
        }

        protected override int GetItemIndex(TrialVersion item)
        {
            return Data.IndexOf(e => e.Id == item.Id);
        }

        protected override void SetNewValues(TrialVersion item)
        {}

        public override void Add(TrialVersion item)
        {
            throw new NotSupportedException();
        }

        public override void Update(TrialVersion item)
        {
            throw new NotSupportedException();
        }

        public override void Delete(TrialVersion item)
        {
            throw new NotSupportedException();
        }
    }
}
