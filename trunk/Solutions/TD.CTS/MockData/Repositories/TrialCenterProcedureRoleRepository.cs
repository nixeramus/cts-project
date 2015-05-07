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
    class TrialCenterProcedureRoleRepository : Repository<TrialCenterProcedureRole>
    {
        public TrialCenterProcedureRoleRepository(IDataProvider dataProvider)
            : base(dataProvider)
        {}

        //public override List<TrialCenter> GenerateData()
        //{
        //    var list = new List<TrialCenter>();

        //    var trials = dataProvider.GetList(new TrialDataFilter());

        //    if (trials.Count < 1)
        //        return list;

        //    var users = dataProvider.GetList(new UserDataFilter());

        //    var hospitals = dataProvider.GetList(new HospitalDataFilter());

        //    Random rand = new Random();

        //    int id = 1;
        //    foreach (var trial in trials)
        //    {
        //        int count = rand.Next(0, hospitals.Count + 1);
        //        for (int i = 0; i < count; i++)
        //        {
        //            list.Add(new TrialCenter { 
        //                Id = id,
        //                TrialCode = trial.Code,
        //                Number = rand.Next(1000, 10000).ToString(),
        //                HospitalId = hospitals[i].Id,
        //                AnatomistLogin = users[rand.Next(0, users.Count)].Login,
        //                CoordinatorLogin = users[rand.Next(0, users.Count)].Login
        //            });
        //            id++;
        //        }
        //    }

        //    return list;
        //}

        protected override Func<TrialCenterProcedureRole, bool> GetFilterFunc(DataFilter<TrialCenterProcedureRole> filter)
        {
            TrialCenterProcedureRoleDataFilter dataFilter = (TrialCenterProcedureRoleDataFilter)filter;

            return e =>
                (dataFilter.TrialCenterId == null || e.TrialCenterId == dataFilter.TrialCenterId)
                && (dataFilter.TrialProcedureId == null || e.TrialProcedureId == dataFilter.TrialProcedureId)
                && (dataFilter.RoleCode == null || e.RoleCode == dataFilter.RoleCode)
                && (dataFilter.Id == null || e.Id == dataFilter.Id);
        }

        protected override int GetItemIndex(TrialCenterProcedureRole item)
        {
            return Data.IndexOf(e => e.Id == item.Id);
        }

        protected override void SetNewValues(TrialCenterProcedureRole item)
        {
            item.Id = Data.Count > 0 ? Data.Max(e => e.Id) + 1 : 1;
        }
    }
}
