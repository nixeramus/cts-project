using System;

namespace TD.CTS.Data.Entities
{
    public class Schedule : Entity
    {
        public int Id { get; set; }
        public int PatientCode { get; set; }
        public string PatientFullName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime CreateDate { get; set; }
        public int TrialCenterID { get; set; }
        public string TrialCode { get; set; }
        public string TrialCenterName { get; set; }
        public string TrialName { get; set; }
        
        public string AuthorLogin { get; set; }
        public string ModificatorLogin { get; set; }
        public DateTime ModificationDate { get; set; }
        public string Comment { get; set; }

        public string ScheduleStatus { get; set; }

    }
}
