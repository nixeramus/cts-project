using System;

namespace TD.Common.Data.Exceptions
{
    public interface IExceptionManager
    {
        DataException CreateDataException(Exception exception);
    }
}
