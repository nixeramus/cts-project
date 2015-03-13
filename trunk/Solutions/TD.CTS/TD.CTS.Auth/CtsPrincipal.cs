using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TD.CTS.Auth
{
    public class CtsPrincipal : IPrincipal
    {
        private CtsIdentity identity;

        public CtsPrincipal(CtsIdentity identity)
        {
            this.identity = identity;
        }

        public IIdentity Identity
        {
            get { return identity; }
        }

        public bool IsInRole(string role)
        {
            return identity.User.Roles.Any(r => r.Name.Equals(role));
        }
    }
}
