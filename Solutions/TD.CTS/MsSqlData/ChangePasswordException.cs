using System;
using TD.Common.Data.Exceptions;

namespace TD.CTS.MsSqlData
{
    public class ChangePasswordException : DataException
    {
        public ChangePasswordException(string message, Exception innerException) 
            : base(message, innerException)
        { }

        public ChangePasswordException(string message)
            : base(message)
        { }
    }
}
