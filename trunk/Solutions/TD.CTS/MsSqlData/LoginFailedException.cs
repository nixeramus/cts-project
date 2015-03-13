using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.Common.Data.Exceptions;

namespace TD.CTS.MsSqlData
{
    public class LoginFailedException : DataException
    {
        public LoginFailedException(string message, Exception innerException) 
            : base(message, innerException)
        { }

        public LoginFailedException(string message)
            : base(message)
        { }
    }
}
