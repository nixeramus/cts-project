using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;
using TD.Common.Data;
using TD.CTS.Data;

namespace TD.CTS.MockData.Repositories
{
    class TaskRepository : Repository<Task>
    {
        public TaskRepository(IDataProvider dataProvider)
            : base(dataProvider)
        { }

        protected override Func<Task, bool> GetFilterFunc(DataFilter<Task> filter)
        {
            TaskDataFilter dataFilter = (TaskDataFilter)filter;

            return e =>
                (dataFilter.Id == null || e.Id == dataFilter.Id)
                && (dataFilter.VisitDateBegin == null || e.VisitDate >= dataFilter.VisitDateBegin)
                && (dataFilter.VisitDateEnd == null || e.VisitDate <= dataFilter.VisitDateEnd);
        }

        protected override int GetItemIndex(Task item)
        {
            return Data.IndexOf(t => t.Id == item.Id);
        }

        public override List<Task> GenerateData()
        {
            var list = new List<Task>();

            if (dataProvider == null)
                return list;
            
            var trial = dataProvider.GetItem(new TrialDataFilter());

            if (trial == null)
                return list;

            var patients = dataProvider.GetList(new PatientDataFilter()).Take(2).ToList();

            var trialProcedures = dataProvider.GetList(new TrialProcedureDataFilter { TrialCode = trial.Code });

            var beginDate = new DateTime(2015, 4, 3);
            Random rand = new Random();
            var id = 1;

            for (int i = 0; i < 10; i++)
            {
                foreach (var trialProcedure in trialProcedures)
                {
                    foreach (var trialVisitId in trialProcedure.VisitIds)
                    {
                        var trialVisit = dataProvider.GetItem(new TrialVisitDataFilter { Id = trialVisitId });
                        if (trialVisit == null)
                            continue;

                        foreach (var patient in patients)
                        {
                            var punctuality = rand.Next(-trialVisit.Punctuality, trialVisit.Punctuality);

                            var task = new Task
                            {
                                Id = id,
                                PatientId = patient.Id,
                                PatientFullName = patient.FullName,
                                ProcedureCode = trialProcedure.ProcedureCode,
                                TrialCode = trial.Code,
                                VisitDate = beginDate.AddDays(trialVisit.Days + punctuality)
                            };

                            list.Add(task);
                            id++;
                        }
                    }
                }

                beginDate = beginDate.AddDays(rand.Next(7, 10));
            }
                        
            return list;
        }

        protected override void SetNewValues(Task item)
        {
            throw new NotImplementedException();
        }

        public override void Add(Task item)
        {
            throw new NotSupportedException();
        }

        public override void Update(Task item)
        {
            var index = GetItemIndex(item);

            var current = Data[index];

            if (current.IsDone || !item.IsDone)
                return;

            current.IsDone = true;
            current.VisitDate = item.VisitDate;
        }

        public override void Delete(Task item)
        {
            throw new NotSupportedException();
        }
    }
}
