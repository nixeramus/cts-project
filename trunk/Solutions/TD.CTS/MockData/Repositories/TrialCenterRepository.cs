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
    class TrialCenterRepository : Repository<TrialCenter>
    {
        public TrialCenterRepository(IDataProvider dataProvider) : base(dataProvider)
        {}

        public override List<TrialCenter> GenerateData()
        {
            var list = new List<TrialCenter>();

            var trials = dataProvider.GetList(new TrialDataFilter());

            if (trials.Count < 1)
                return list;

            var users = dataProvider.GetList(new UserDataFilter());

            var hospitals = dataProvider.GetList(new HospitalDataFilter());

            Random rand = new Random();

            int id = 1;
            foreach (var trial in trials)
            {
                int count = rand.Next(0, hospitals.Count + 1);
                for (int i = 0; i < count; i++)
                {
                    list.Add(new TrialCenter { 
                        Id = id,
                        TrialCode = trial.Code,
                        Number = rand.Next(1000, 10000).ToString(),
                        HospitalId = hospitals[i].Id,
                        AnatomistLogin = users[rand.Next(0, users.Count)].Login,
                        CoordinatorLogin = users[rand.Next(0, users.Count)].Login
                    });
                    id++;
                }
            }

            return list;
        }

        protected override Func<TrialCenter, bool> GetFilterFunc(DataFilter<TrialCenter> filter)
        {
            TrialCenterDataFilter dataFilter = (TrialCenterDataFilter)filter;

            return e =>
                (dataFilter.TrialCode == null || e.TrialCode == dataFilter.TrialCode)
                && (dataFilter.Id == null || e.Id == dataFilter.Id);
                //&& (dataFilter.Number == null || dataFilter.Number.Equals(e.Number))
                //&& (dataFilter.AnatomistLogin == null || e.AnatomistLogin == dataFilter.AnatomistLogin)
                //&& (dataFilter.CoordinatorLogin == null || e.CoordinatorLogin == dataFilter.CoordinatorLogin)
                //&& (dataFilter.HospitalId == null || e.HospitalId == dataFilter.HospitalId);
        }

        protected override int GetItemIndex(TrialCenter item)
        {
            return Data.IndexOf(e => e.Id == item.Id);
        }

        protected override void SetNewValues(TrialCenter item)
        {
            item.Id = Data.Max(e => e.Id) + 1;
        }
    }
}
