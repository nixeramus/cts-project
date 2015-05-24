using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using TD.CTS.Data.Entities;

namespace TD.CTS.WebUI.Models
{
    public class ProcedureCountSchedulerEvent : ISchedulerEvent
    {
        private IEnumerable<ProcedureCount> procedureCounts;
        private DateTime date;

        public ProcedureCountSchedulerEvent(DateTime date, IEnumerable<ProcedureCount> procedureCounts)
        {
            this.procedureCounts = procedureCounts;
            this.date = date;
        }

        public string Description
        {
            get
            {
                return null;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime End
        {
            get
            {
                return date;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string EndTimezone
        {
            get
            {
                return null;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool IsAllDay
        {
            get
            {
                return true;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string RecurrenceException
        {
            get
            {
                return null;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string RecurrenceRule
        {
            get
            {
                return null;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime Start
        {
            get
            {
                return date;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string StartTimezone
        {
            get
            {
                return null;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Title
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (var procedureCount in procedureCounts)
                    sb.AppendLine(string.Format(@"<span class=""td-task td-task-{2}"">({0}) - {1}</span>", procedureCount.ProcedureCode, procedureCount.Count, GetStatus(procedureCount)));
                return sb.ToString();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        private string GetStatus(ProcedureCount procedureCount)
        {
            if (procedureCount.IsDone)
                return "done";

            if (date < DateTime.Today)
                return "overdue";

            return "undone";
        }
    }
}