using System;
using System.Data.SqlClient;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;

namespace TD.CTS.MsSqlData.Builders
{
    internal class TrialCenterProcedureRoleCommandBuilder : CommandBuilder<TrialCenterProcedureRole>
    {
        public override SqlCommand CreateGetCommand(SqlConnection connection, DataFilter<TrialCenterProcedureRole> filter)
        {
            var command = new SqlCommand("ProcedureRoleGet", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            var entityFilter = (TrialCenterProcedureRoleDataFilter)filter ?? new TrialCenterProcedureRoleDataFilter { TrialCenterId = -1 };

            command.Parameters.AddWithValue("@TrialCenterID", entityFilter.TrialCenterId.GetNullableParameterValue());
            command.Parameters.AddWithValue("@ProcedureCode", entityFilter.ProcedureCode.GetNullableParameterValue());
            command.Parameters.AddWithValue("@SystemRoleCode", entityFilter.RoleCode.GetNullableParameterValue());
            command.Parameters.AddWithValue("@TrialCode", entityFilter.TrialCode.GetNullableParameterValue());
            command.Parameters.AddWithValue("@TrialVersionNo", entityFilter.TrialVersionId.GetNullableParameterValue());
            
            return command;
        }

        public override SqlCommand CreateAddCommand(SqlConnection connection, TrialCenterProcedureRole entity)
        {
            var command = new SqlCommand("ProcedureRoleAdd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@TrialCenterID", entity.TrialCenterId);
            command.Parameters.AddWithValue("@ProcedureCode", entity.ProcedureCode);
            command.Parameters.AddWithValue("@SystemRoleCode", entity.RoleCode);
            command.Parameters.AddWithValue("@TrialCode", entity.TrialCode);
            command.Parameters.AddWithValue("@TrialVersionNo", entity.TrialVersionId);
            
            return command;
        }

        public override SqlCommand CreateUpdateCommand(SqlConnection connection, TrialCenterProcedureRole entity)
        {
            throw new NotSupportedException();

            //var command = new SqlCommand("TrialCenterUpd", connection)
            //{
            //    CommandType = System.Data.CommandType.StoredProcedure,
            //    CommandTimeout = Settings.CommandTimeout
            //};

            //command.Parameters.AddWithValue("@TrialCenterID", entity.Id);
            //command.Parameters.AddWithValue("@TrialCenterName", entity.Number);
            //command.Parameters.AddWithValue("@PISystemLogin", entity.AnatomistLogin);
            //command.Parameters.AddWithValue("@COSystemLogin", entity.CoordinatorLogin.GetNullableParameterValue());
            
            //return command;
        }

        public override SqlCommand CreateDeleteCommand(SqlConnection connection, TrialCenterProcedureRole entity)
        {
            var command = new SqlCommand("ProcedureRoleDel", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@ProcedureRoleID", entity.Id);
            
            return command;
        }

        public override void LoadEntityAttributes(SqlDataReader reader, TrialCenterProcedureRole entity)
        {
            entity.Id = reader.GetValue<int>("ProcedureRoleID");
            entity.TrialCenterId = reader.GetValue<int>("TrialCenterID");
            entity.ProcedureCode = reader.GetString("ProcedureCode").TrimEnd();
            entity.TrialCode = reader.GetString("TrialCode").TrimEnd();
            entity.TrialVersionId = reader.GetValue<int>("TrialVersionNo");
            entity.RoleCode = reader.GetString("SystemRoleCode");
        }

        public override void LoadNewEntityAttributes(SqlDataReader reader, TrialCenterProcedureRole entity)
        {
            entity.Id = reader.GetValue<int>("ProcedureRoleID");
        }
    }
}
