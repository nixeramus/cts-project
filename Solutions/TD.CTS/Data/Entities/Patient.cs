using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.CTS.Data.Entities
{
    public class Patient : Entity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Имя не задано")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Мед. учреждение не выбрано")]
        public int HospitalId { get; set; }

        [Required(ErrorMessage = "Источник не задан")]
        public string SourceType { get; set; }

        public int? ReferalId { get; set; }

        public DateTime BirthDate { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string ContactRelatives { get; set; }
    }
}
