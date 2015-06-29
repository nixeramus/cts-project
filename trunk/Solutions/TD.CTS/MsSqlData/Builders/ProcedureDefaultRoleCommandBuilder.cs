using System;
using System.Data.SqlClient;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;

namespace TD.CTS.MsSqlData.Builders
{
    internal class ProcedureDefaultRoleCommandBuilder : CommandBuilder<ProcedureDefaultRole>
    {
        public override SqlCommand CreateGetCommand(SqlConnection connection, DataFilter<ProcedureDefaultRole> filter)
        {
            var command = new SqlCommand("ProcedureRoleDefaultGet", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            var entityFilter = (ProcedureDefaultRoleDataFilter)filter ?? new ProcedureDefaultRoleDataFilter();

            command.Parameters.AddWithValue("@ProcedureCode", entityFilter.ProcedureCode.GetNullableParameterValue());
            command.Parameters.AddWithValue("@SystemRoleCode", entityFilter.RoleCode.GetNullableParameterValue());
            
            return command;
        }

        public override SqlCommand CreateAddCommand(SqlConnection connection, ProcedureDefaultRole entity)
        {
            var command = new SqlCommand("ProcedureRoleDefaultAdd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@ProcedureCode", entity.ProcedureCode);
            command.Parameters.AddWithValue("@SystemRoleCode", entity.RoleCode);
            
            return command;
        }

        public override SqlCommand CreateUpdateCommand(SqlConnection connection, ProcedureDefaultRole entity)
        {
            throw new NotSupportedException();
        }

        public override SqlCommand CreateDeleteCommand(SqlConnection connection, ProcedureDefaultRole entity)
        {
            var command = new SqlCommand("ProcedureRoleDefaultDel", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@ProcedureCode", entity.ProcedureCode);
            command.Parameters.AddWithValue("@SystemRoleCode", entity.RoleCode);
            
            return command;
        }

        public override void LoadEntityAttributes(SqlDataReader reader, ProcedureDefaultRole entity)
        {
            entity.ProcedureCode = reader.GetString("ProcedureCode").Trim();
            entity.RoleCode = reader.GetString("SystemRoleCode");
       }

        public override void LoadNewEntityAttributes(SqlDataReader reader, ProcedureDefaultRole entity)
        {
        }
    }
}
