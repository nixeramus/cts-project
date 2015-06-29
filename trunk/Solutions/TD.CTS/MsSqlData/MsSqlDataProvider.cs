using NLog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using TD.Common.Data.Exceptions;
using TD.Common.Data;
using TD.CTS.Data;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;
using TD.CTS.MsSqlData.Builders;
using System.Linq;
using System.Data;

namespace TD.CTS.MsSqlData
{
    public class MsSqlDataProvider : IDataProvider
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private IExceptionManager exceptionManager;

        private static Dictionary<Type, object> builders;

        static MsSqlDataProvider()
        {
            builders = new Dictionary<Type, object>();
            
            AddBuilders();
        }

        private static void AddBuilders()
        {
            var baseType = typeof(CommandBuilder<>);
            var builderInfos = Assembly.GetAssembly(baseType).GetTypes()
                .Where(t => t.BaseType.IsGenericType && t.BaseType.GetGenericTypeDefinition() == baseType)
                .Select(t => new { EntityType = t.BaseType.GenericTypeArguments[0], BuilderType = t })
                .ToList();

            foreach(var builderInfo in builderInfos)
            {
                builders.Add(builderInfo.EntityType, Activator.CreateInstance(builderInfo.BuilderType));
            }
        }
        
        private string connectionString; 

        public MsSqlDataProvider(string connectionString, IExceptionManager exceptionManager = null)
        {
            this.connectionString = connectionString;

            this.exceptionManager = exceptionManager ?? new MsSqlExceptionManager();
        }

        public void Update(Trial entity)
        {
            dynamic builder = builders[typeof(Trial)];

            var connection = new SqlConnection(connectionString);

            SqlCommand command = builder.CreateUpdateCommand(connection, entity);

            SqlCommand statusCommand = null;
            SqlTransaction tran = null;
            if (entity.OriginalStatus != entity.Status)
            {
                statusCommand = new SqlCommand("TrialChangeStatus", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = Settings.CommandTimeout
                };

                statusCommand.Parameters.AddWithValue("@TrialCode", entity.Code);
                statusCommand.Parameters.AddWithValue("@NewTrialStatus", entity.Status.GetDescription());
            }

            try
            {
                connection.Open();
                if (statusCommand == null)
                {
                    command.ExecuteNonQuery();
                }
                else
                {
                    tran = connection.BeginTransaction();
                    command.Transaction = tran;
                    statusCommand.Transaction = tran;
                    command.ExecuteNonQuery();
                    statusCommand.ExecuteNonQuery();

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                if (tran != null)
                    tran.Rollback();

                throw LogException(MethodBase.GetCurrentMethod().Name, typeof(Trial), ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public void Calc(Schedule schedule)
        {
            var connection = new SqlConnection(connectionString);
            var calcCommand = new SqlCommand("ScheduleCalc", connection)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            calcCommand.Parameters.AddWithValue("@ScheduleID", schedule.Id);

            try
            {
                connection.Open();
                calcCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw LogException(MethodBase.GetCurrentMethod().Name, typeof(Schedule), ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public List<TEntity> GetList<TEntity>(DataFilter<TEntity> filter)
            where TEntity : Entity, new()
        {
            List<TEntity> list = new List<TEntity>();

            dynamic builder = builders[typeof(TEntity)];

            var connection = new SqlConnection(connectionString);

            SqlCommand command = builder.CreateGetCommand(connection, filter);

            try
            {
                connection.Open();

                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var entity = new TEntity();
                        builder.LoadEntityAttributes(reader, entity);
                        list.Add(entity);
                    }
                }
            }
            catch(Exception ex)
            {
                throw LogException(MethodBase.GetCurrentMethod().Name, typeof(TEntity), ex);
            }
            finally
            {
                connection.Close();
            }

            return list;
        }

        public TEntity GetItem<TEntity>(DataFilter<TEntity> filter)
            where TEntity : Entity, new()
        {
            TEntity entity = null;

            dynamic builder = builders[typeof(TEntity)];

            var connection = new SqlConnection(connectionString);

            SqlCommand command = builder.CreateGetCommand(connection, filter);

            try
            {
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        entity = new TEntity();
                        builder.LoadEntityAttributes(reader, entity);
                    }
                }
            }
            catch (Exception ex)
            {
                throw LogException(MethodBase.GetCurrentMethod().Name, typeof(TEntity), ex);
            }
            finally
            {
                connection.Close();
            }

            return entity;
        }

        public void Add<TEntity>(TEntity entity) where TEntity : Entity
        {
            dynamic builder = builders[typeof(TEntity)];

            var connection = new SqlConnection(connectionString);

            SqlCommand command = builder.CreateAddCommand(connection, entity);

            try
            {
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        builder.LoadNewEntityAttributes(reader, entity);
                    }
                }
            }
            catch (Exception ex)
            {
                throw LogException(MethodBase.GetCurrentMethod().Name, typeof(TEntity), ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public void Update<TEntity>(TEntity entity) where TEntity : Entity
        {
            dynamic builder = builders[typeof(TEntity)];

            var connection = new SqlConnection(connectionString);

            SqlCommand command = builder.CreateUpdateCommand(connection, entity);

            try
            {
                connection.Open();

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw LogException(MethodBase.GetCurrentMethod().Name, typeof(TEntity), ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : Entity
        {
            dynamic builder = builders[typeof(TEntity)];

            var connection = new SqlConnection(connectionString);

            SqlCommand command = builder.CreateDeleteCommand(connection, entity);

            try
            {
                connection.Open();

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw LogException(MethodBase.GetCurrentMethod().Name, typeof(TEntity), ex);
            }
            finally
            {
                connection.Close();
            }
        }

        private Exception LogException(string methodName, Type entityType, Exception ex)
        {
            var dataException = exceptionManager.CreateDataException(ex);

            logger.Error("Exception in TD.CTS.MsSqlData.DataProvider." + methodName + "<" + entityType.Name + ">" + "()", dataException);

            return dataException;
        }

        private Exception LogException(string methodName, Exception ex)
        {
            var dataException = exceptionManager.CreateDataException(ex);

            logger.Error("Exception in TD.CTS.MsSqlData.DataProvider." + methodName + "()", dataException);

            return dataException;
        }

        public bool TestConnection()
        {
            var connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
            }
            catch(Exception ex)
            {
                var dataException = LogException(MethodBase.GetCurrentMethod().Name, ex);
               
                if (dataException is LoginFailedException)
                    return false;

                throw dataException;
            }
            finally
            {
                connection.Close();
            }

            return true;
        }

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("UserChangePwd", connection)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@OldPasswd", oldPassword);
            command.Parameters.AddWithValue("@NewPasswd", newPassword);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                var dataException = LogException(MethodBase.GetCurrentMethod().Name, ex);

                if (dataException is ChangePasswordException)
                    return false;

                throw dataException;
            }
            finally
            {
                connection.Close();
            }

            return true;
        }

        public void MargeTrialProcedures(string trialCode, int trialVersion, string[] procedureCodes)
        {
            var trialProcedures = GetList(new TrialProcedureDataFilter { TrialCode = trialCode, TrialVersion = trialVersion });

            var deletedProcedures = trialProcedures.Where(x => !procedureCodes.Contains(x.ProcedureCode)).ToArray();

            var addedProcedures = procedureCodes.Where(x => !trialProcedures.Any(y => y.ProcedureCode == x))
                .Select(x => new TrialProcedure
                {
                    TrialCode = trialCode,
                    TrialVersion = trialVersion,
                    ProcedureCode = x
                }).ToArray();

            if (deletedProcedures.Length == 0 && addedProcedures.Length == 0)
                return;

            var connection = new SqlConnection(connectionString);

            dynamic builder = builders[typeof(TrialProcedure)];

            SqlTransaction tran = null;
            try
            {
                connection.Open();
                tran = connection.BeginTransaction();

                foreach(var procedure in deletedProcedures)
                {
                    var command = builder.CreateDeleteCommand(connection, procedure);
                    command.Transaction = tran;
                    command.ExecuteNonQuery();
                }

                foreach (var procedure in addedProcedures)
                {
                    var command = builder.CreateAddCommand(connection, procedure);
                    command.Transaction = tran;
                    command.ExecuteNonQuery();
                }

                tran.Commit();
            }
            catch (Exception ex)
            {
                if (tran != null)
                    tran.Rollback();

                throw LogException(MethodBase.GetCurrentMethod().Name, typeof(TrialProcedure), ex);
            }
            finally
            {
                connection.Close();
            }
        }
        
        public void LoadProcedureDefaultRoles(string trialCode, int trialVersion)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("", connection)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@", trialCode);
            command.Parameters.AddWithValue("@", trialVersion);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                var dataException = LogException(MethodBase.GetCurrentMethod().Name, ex);

                throw dataException;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
