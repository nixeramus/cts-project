using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TD.CTS.Data.Entities;

namespace TD.CTS.WebUI.Models
{
    public class TaskViewModel : Task
    {
        public static TaskViewModel Create(Task task, string trialName, string procedureName)
        {
            return new TaskViewModel
            {
                Id = task.Id,
                IsDone = task.IsDone,
                PatientFullName = task.PatientFullName,
                PatientId = task.PatientId,
                PatientShortName = task.PatientShortName,
                ProcedureCode = task.ProcedureCode,
                ProcedureName = procedureName,
                TrialCode = task.TrialCode,
                TrialName = trialName,
                VisitDate = task.VisitDate,
                ScheduleId = task.ScheduleId,
                TrialVisitId = task.TrialVisitId,
                TrialVersion = task.TrialVersion,
                TrialVisitProcedureId = task.TrialVisitProcedureId
            };
        }

        public string TrialName { get; set; }

        public string ProcedureName { get; set; }
    }
}