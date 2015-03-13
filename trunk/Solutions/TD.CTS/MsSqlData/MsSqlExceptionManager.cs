using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.Common.Data.Exceptions;

namespace TD.CTS.MsSqlData
{
    public class MsSqlExceptionManager : IExceptionManager
    {
        private readonly Dictionary<string, ConstraintMessage> constraints = new Dictionary<string, ConstraintMessage>();

        public Dictionary<string, ConstraintMessage> Constraints
        {
            get
            {
                return constraints;
            }
        }

        public void AddConstraint(ConstraintMessage constraint)
        {
            constraints.Add(constraint.Name, constraint);
        }

        public void AddConstraint(IEnumerable<ConstraintMessage> constraints)
        {
            foreach (var constrain in constraints)
                AddConstraint(constrain);
        }

        public DataException CreateDataException(Exception exception)
        {
            var sqlEx = exception as SqlException;
            if (sqlEx != null)
            {
                if (sqlEx.Class > 19)
                {
                    return new DataException("Ошибка подключения к серверу базы данных", exception);
                }

                if (sqlEx.Number == 18456 || sqlEx.Number == 4060)
                {
                    return new LoginFailedException("Неверный логин и/или пароль", sqlEx);
                }

                if (sqlEx.Number == 15151)
                {
                    return new ChangePasswordException("Ошибка смены пароля", sqlEx);
                }
                
                if (sqlEx.Number > 49999)
                {
                    return new DataException(sqlEx.Errors[0].Message, exception);
                }

                string message = exception.Message;
                var constraint = constraints.FirstOrDefault(c => message.Contains(c.Key)).Value;
                if (constraint != null)
                {
                    if (message.Contains("REFERENCE")
                        && !message.Contains("COLUMN REFERENCE")
                        && !message.Contains("TABLE REFERENCE")
                        && !string.IsNullOrEmpty(constraint.ChildTableMessage))
                    {
                        return new DataException(constraint.ChildTableMessage, exception);
                    }

                    return new DataException(constraint.ParentTableMessage, exception);
                }

                return new DataException("Ошибка базы данных", exception);
            }

            return new DataException("Ошибка работы с данными", exception); ;
        }

        //public static DBExceptionManager CreateSqlDBExceptionManager(string connectionString, 
        //    string procedureName = "Constraint_Message_GetList",
        //    string constraintNameField = "Constraint_Name",
        //    string parentTableMessageField = "Parent_Table_Message",
        //    string childTableMessageField = "Child_Table_Message")
        //{
        //    var exceptionManager = new DBExceptionManager();

        //    var connection = new SqlConnection(connectionString);
        //    var command = new SqlCommand(procedureName, connection)
        //    {
        //        CommandType = CommandType.StoredProcedure
        //    };

        //    try
        //    {
        //        command.Connection.Open();
        //        using (var r = command.ExecuteReader())
        //        {
        //            while (r.Read())
        //            {
        //                exceptionManager.AddConstraint(new ConstraintMessage
        //                {
        //                    Name = (String) r[constraintNameField],
        //                    ParentTableMessage =
        //                        DBHelper.ConvertFromNullableString(r[parentTableMessageField]),
        //                    ChildTableMessage =
        //                        DBHelper.ConvertFromNullableString(r[childTableMessageField])
        //                }
        //                    );
        //            }
        //        }
        //    }
        //    finally
        //    {
        //        command.Connection.Close();
        //    }

        //    return exceptionManager;
        //}

    }
}
