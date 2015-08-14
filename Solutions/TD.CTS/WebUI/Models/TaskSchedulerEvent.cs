using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using TD.CTS.Data.Entities;

namespace TD.CTS.WebUI.Models
{
    public class TaskSchedulerEvent : ISchedulerEvent
    {
        private IEnumerable<Task> tasks;
        private DateTime date;

        public TaskSchedulerEvent(DateTime date, IEnumerable<Task> tasks)
        {
            this.tasks = tasks;
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
                var groups = tasks.GroupBy(x => new { x.TrialCode, x.PatientId, x.PatientShortName });
                foreach (var group in groups)
                    sb.AppendLine(string.Format(@"<span class=""td-task td-task-{3}"" title=""{0} {1} ({2})"">{0} {1} ({2})</span>", group.Key.TrialCode, group.Key.PatientShortName, string.Join(", ", group.Select(x => x.ProcedureCode)), GetTasksStatus(group)));

                //foreach (var task in tasks)
                //    sb.AppendLine(string.Format(@"<a class=""td-task td-task-{3} k-link"" title=""{0} {1} ({2})"" href=""/{4}"">{0} {1} ({2})</a>", task.TrialCode, task.PatientShortName, task.ProcedureCode, GetTaskStatus(task), task.Id));
                return sb.ToString();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        private string GetTasksStatus(IEnumerable<Task> task)
        {
            if (tasks.All(x => x.IsDone))
                return "done";

            if (date < DateTime.Today)
                return "overdue";

            return "undone";
        }

        //private string GetTaskStatus(Task task)
        //{
        //    if (task.IsDone)
        //        return "done";

        //    if (date < DateTime.Today)
        //        return "overdue";

        //    return "undone";
        //}
    }
}