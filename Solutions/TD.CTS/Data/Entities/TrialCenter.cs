using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.CTS.Data.Entities
{
    public class TrialCenter : Entity
    {
        public int Id { get; set; }

        public string TrialCode { get; set; }

        public int TrialVersion { get; set; }

        [Required(ErrorMessage = "Мед. учериждение не выбрано")]
        public int HospitalId { get; set; }

        [Required(ErrorMessage = "Номер центра не задан")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Главный исследователь не выбран")]
        public string AnatomistLogin { get; set; }

        public string CoordinatorLogin { get; set; }
    }
}
