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
    class TrialIncomeArticleRepository : Repository<TrialIncomeArticle>
    {
        public TrialIncomeArticleRepository(IDataProvider dataProvider)
            : base(dataProvider)
        {}

        //public override List<TrialVisit> GenerateData()
        //{
        //    var list = new List<TrialVisit>();

        //    var trials = dataProvider.GetList(new TrialDataFilter());

        //    if (trials.Count < 1)
        //        return list;

        //    Random rand = new Random();

        //    int id = 1;
        //    foreach (var trial in trials)
        //    {
        //        int count = rand.Next(1, 7);
        //        int days = 0;
        //        int maxPunctuality = 0;
        //        for (int i = 0; i < count; i++)
        //        {
        //            list.Add(new TrialVisit
        //            {
        //                Id = id,
        //                TrialCode = trial.Code,
        //                Name = "Визит " + (i + 1),
        //                Days = days,
        //                Punctuality = days == 0 ? 0 : rand.Next(1, maxPunctuality)
        //            });
        //            id++;
        //            maxPunctuality = rand.Next(1, 8);
        //            days = days + rand.Next(1, 8);
        //        }
        //    }

        //    return list;
        //}

        protected override Func<TrialIncomeArticle, bool> GetFilterFunc(DataFilter<TrialIncomeArticle> filter)
        {
            TrialIncomeArticleDataFilter dataFilter = (TrialIncomeArticleDataFilter)filter;

            return e =>
                (dataFilter.TrialCode == null || e.TrialCode == dataFilter.TrialCode)
                && (dataFilter.Id == null || e.Id == dataFilter.Id)
                && (string.IsNullOrEmpty(dataFilter.Name) || e.Name.Contains(dataFilter.Name));
        }

        protected override int GetItemIndex(TrialIncomeArticle item)
        {
            return Data.IndexOf(e => e.Id == item.Id);
        }

        protected override void SetNewValues(TrialIncomeArticle item)
        {
            item.Id = Data.Count > 0 ? Data.Max(e => e.Id) + 1 : 1;
        }
    }
}
