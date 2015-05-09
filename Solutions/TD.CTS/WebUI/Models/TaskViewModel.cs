using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TD.CTS.Data.Entities;

namespace TD.CTS.WebUI.Models
{
    public class TaskViewModel
    {
        public int Id { get; set; }

        public string TrialCode {get;set;}

        public string TrialName {get;set;}

        public DateTime VisitDate{get;set;}

        public string ProcedureCode { get; set; }

        public string ProcedureName { get; set; }

        public int PatientId { get; set; }

        public string PatientFullName { get; set; }

        public string PatientShortName { get; set; }

        public bool IsDone { get; set; }

        public Task ToTask()
        {
            return new Task
            {
                Id = Id,
                IsDone = IsDone,
                PatientId = PatientId,
                PatientFullName = PatientFullName,
                ProcedureCode = ProcedureCode,
                TrialCode = TrialCode,
                VisitDate = VisitDate
            };
        }
    }
}