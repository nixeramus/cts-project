using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TD.CTS.Data.Entities
{
    public class SchedulePlaningVisit : Entity
    {
        public SchedulePlaningVisit()
        {
            VisitEmployees = new List<User>();
        }
        public int ScheduleID { get; set; }
        public int TrialVisitID { get; set; }
        public int TrialCenterID { get; set; }
        public string TrialCode { get; set; }
        public string TrialName { get; set; }

        public int PatientCode { get; set; }
        public string PatientFullName { get; set; }
        public int TrialVersionNo { get; set; }
        [Required(ErrorMessage = "Дата не задана")]
        public DateTime? ScheduleDate { get; set; }
        public DateTime? ActualDate { get; set; }
        public string TrialVisitName { get; set; }
        public int VisitNo { get; set; }

        public DateTime BeginDate { get; set; }
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }

        //public string VisitEmployees { get; set; }
        public IEnumerable<User> VisitEmployees { get; set; }


        public String VisitEmployeesString
        {
            get
            {
                return VisitEmployees==null? String.Empty:String.Join(",", VisitEmployees.Select(e=>e.FullName).ToArray());
            }
        }


        public int BaseDay { get; set; }
        public int Limit { get; set; }
        public int? Id { get; set; }

        //0-запланированный 1-началочь окно -2 кончилось окно 3- еще не началось
        public int RankState { get; set; }
    }
}
