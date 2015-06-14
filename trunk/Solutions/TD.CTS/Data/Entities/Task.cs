using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.CTS.Data.Entities
{
    public class Task : Entity
    {
        //private static string ExtractIni(string s)
        //{
        //    if (string.IsNullOrWhiteSpace(s))
        //        return string.Empty;
        //    string[] results = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        //    switch (results.Length)
        //    {
        //        case 1:
        //            return results[0];
        //        case 2:
        //            return string.Format("{0} {1}.", results[0], results[1][0]);
        //        default:
        //            return string.Format("{0} {1}. {2}.", results[0], results[1][0], results[2][0]);
        //    }
        //}

        private static string ExtractFirstName(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return string.Empty;
            int index = s.IndexOf(' ');
            if (index != -1)
                return s.Substring(0, index);

            return s;
        }

        public int Id { get; set; }

        public string TrialCode { get; set; }

        public int TrialVersion { get; set; }

        public int ScheduleId { get; set; }

        public int PatientId { get; set; }

        public string Initials { get; set; }

        private string patientFullName;
        public string PatientFullName
        { 
            get { return patientFullName; }
            set
            { 
                patientFullName = value;
                PatientShortName = ExtractFirstName(value) + Initials ?? string.Empty;
            }
        }

        public string PatientShortName { get; protected set; }

        public string ProcedureCode { get; set; }

        public DateTime VisitDate { get; set; }

        public bool IsDone { get; set; }

        public int TrialVisitId { get; set; }

        public int TrialVisitProcedureId { get; set; }
    }
}
