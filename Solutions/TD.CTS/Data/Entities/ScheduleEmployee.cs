using System;
using System.ComponentModel.DataAnnotations;

namespace TD.CTS.Data.Entities
{
    public class ScheduleEmployee : Entity
    {
        public int? Id { get; set; }
        public int ScheduleID { get; set; }
        public string SystemRoleCode { get; set; }
        [Required(ErrorMessage = "Сотрудник не задан")]
        public string SystemLogin { get; set; }
    }
}
