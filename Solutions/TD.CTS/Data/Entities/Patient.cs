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
        public static readonly List<string> SourceTypes = new List<string>() { "Реферал", "База пациентов", "Реклама", "Прочее" };

        public int Id { get; set; }

        [Required(ErrorMessage = "Имя не задано")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Мед. учреждение не выбрано")]
        public int HospitalId { get; set; }

        private string sourceType;
        [Required(ErrorMessage = "Источник не задан")]
        public string SourceType 
        {
            get { return sourceType; }
            set { sourceType = SourceTypes.FirstOrDefault(s => s == value); }
        }

        public int? ReferalId { get; set; }

        public DateTime BirthDate { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string ContactRelatives { get; set; }

        [StringLength(3, ErrorMessage="Максимальная длинна инициалов 3 символа")]
        public string Initials { get; set; }
    }
}
