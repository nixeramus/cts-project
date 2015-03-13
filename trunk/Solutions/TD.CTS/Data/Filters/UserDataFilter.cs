using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.CTS.Data.Entities;

namespace TD.CTS.Data.Filters
{
    public class UserDataFilter : DataFilter<User>
    {
        public UserDataFilter()
        {
            IsActualVersion = true;
        }

        public string Login { get; set; }
        
        public int? HospitalId { get; set; }
        
        public string RoleId { get; set; }
        
        public string FullName { get; set; }
        
        public string Email { get; set; }
        
        public string Phone { get; set; }
        
        public bool IsActualVersion { get; set; }
    }
}
