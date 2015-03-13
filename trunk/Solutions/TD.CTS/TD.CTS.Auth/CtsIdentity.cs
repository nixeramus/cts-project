using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TD.CTS.Data;
using TD.CTS.Data.Entities;

namespace TD.CTS.Auth
{
    public class CtsIdentity : IIdentity
    {
        public User User { get; private set; }

        public CtsIdentity(User user)
        {
            User = user;
        }

        public string AuthenticationType
        {
            get { return "CTS"; }
        }

        public bool IsAuthenticated
        {
            get { return User != null; }
        }

        public string Name
        {
            get
            {
                return User.Login; 
            }
        }
    }
}
