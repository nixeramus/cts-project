using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.CTS.Data.Entities
{
    public class User : Entity
    {
        public User()
        {
            Roles = new List<Role>();
        }

        [Required]
        public string Login { get; set; }

        [Required]
        public int HospitalId { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }

        public bool NeedChangePassword { get; set; } 

        public List<Role> Roles { get; set; }
    }
}
