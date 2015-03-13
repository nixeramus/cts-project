using System;

namespace TD.Common.Data.Exceptions
{
    public class DataException : ApplicationException
    {
        public DataException(string message)
            : base(message)
        { }

        public DataException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
