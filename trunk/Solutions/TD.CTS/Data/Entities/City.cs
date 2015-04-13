using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.CTS.Data.Entities
{
    public class City : Entity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Наименование не задано")]
        public string Name { get; set; }
    }
}
