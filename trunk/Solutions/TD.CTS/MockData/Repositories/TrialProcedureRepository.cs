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
    class TrialProcedureRepository : Repository<TrialProcedure>
    {
        public TrialProcedureRepository(IDataProvider dataProvider)
            : base(dataProvider)
        {}
        
        public override List<TrialProcedure> GenerateData()
        {
            var list = new List<TrialProcedure>();

            //var trials = dataProvider.GetList(new TrialDataFilter());

            //var procedures = dataProvider.GetList(new ProcedureDataFilter()).Where(p => p.Code != "ОВ").ToList();

            //if (trials.Count < 1)
            //    return list;

            //Random rand = new Random();

            //int id = 1;
            //foreach (var trial in trials)
            //{
            //    var visits = dataProvider.GetList(new TrialVisitDataFilter { TrialCode = trial.Code });
            //    HashSet<int> visitIndexes = rand.NextSet(rand.Next(0, visits.Count), 1, visits.Count);
                
            //    var procedure = new TrialProcedure
            //    {
            //        Id = id++,
            //        TrialCode = trial.Code,
            //        ProcedureCode = "ОВ",
            //        VisitIds = new List<int>()
            //    };

            //    procedure.VisitIds.Add(visits.First(v => v.Days == 0).Id);
            //    procedure.VisitIds.AddRange(visitIndexes.Select(i => visits[i].Id));

            //    list.Add(procedure);

            //    HashSet<int> procedureIndexes = rand.NextSet(rand.Next(0, procedures.Count), 0, procedures.Count);

            //    foreach (var index in procedureIndexes)
            //    {
            //        visitIndexes = rand.NextSet(rand.Next(0, visits.Count), 1, visits.Count);

            //        procedure = new TrialProcedure
            //        {
            //            Id = id++,
            //            TrialCode = trial.Code,
            //            ProcedureCode = procedures[index].Code,
            //            VisitIds = visitIndexes.Select(i => visits[i].Id).ToList()
            //        };

            //        list.Add(procedure);
            //    }
            //}

            return list;
        }

        protected override Func<TrialProcedure, bool> GetFilterFunc(DataFilter<TrialProcedure> filter)
        {
            TrialProcedureDataFilter dataFilter = (TrialProcedureDataFilter)filter;

            return e =>
                (dataFilter.TrialCode == null || e.TrialCode == dataFilter.TrialCode)
                && (dataFilter.Id == null || e.Id == dataFilter.Id)
                && (string.IsNullOrEmpty(dataFilter.ProcedureCode) || e.ProcedureCode == dataFilter.ProcedureCode);
        }

        protected override int GetItemIndex(TrialProcedure item)
        {
            return Data.IndexOf(e => e.Id == item.Id);
        }

        protected override void SetNewValues(TrialProcedure item)
        {
            item.Id = Data.Count > 0 ? Data.Max(e => e.Id) + 1 : 1;
        }
    }
}
