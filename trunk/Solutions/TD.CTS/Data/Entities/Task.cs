using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.CTS.Data.Entities
{
    public class Task : Entity
    {
        private static string ExtractIni(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return string.Empty;
            string[] results = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            switch (results.Length)
            {
                case 1:
                    return results[0];
                case 2:
                    return string.Format("{0} {1}.", results[0], results[1][0]);
                default:
                    return string.Format("{0} {1}. {2}.", results[0], results[1][0], results[2][0]);
            }
        }

        public int Id { get; set; }

        public string TrialCode { get; set; }

        public int PatientId { get; set; }

        private string patientFullName;
        public string PatientFullName
        { 
            get { return patientFullName; }
            set
            { 
                patientFullName = value;
                PatientShortName = ExtractIni(value);
            }
        }

        public string PatientShortName { get; private set; }

        public string ProcedureCode { get; set; }

        public DateTime VisitDate { get; set; }

        public bool IsDone { get; set; }
    }
}
