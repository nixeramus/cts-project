using System.Data.SqlClient;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;

namespace TD.CTS.MsSqlData.Builders
{
    internal class ProcedureGroupCommandBuilder : CommandBuilder<ProcedureGroup>
    {
        public override SqlCommand CreateGetCommand(SqlConnection connection, DataFilter<ProcedureGroup> filter)
        {
            var command = new SqlCommand("ProcedureGroupGet", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            var entityFilter = (ProcedureGroupDataFilter)filter ?? new ProcedureGroupDataFilter();

            command.Parameters.AddWithValue("@ProcedureGroupID", entityFilter.Id.GetNullableParameterValue());
            command.Parameters.AddWithValue("@ProcedureGroupName", entityFilter.Name.GetLikeParameterValue());
            
            return command;
        }

        public override SqlCommand CreateAddCommand(SqlConnection connection, ProcedureGroup entity)
        {
            var command = new SqlCommand("ProcedureGroupAdd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@ProcedureGroupName", entity.Name);
            command.Parameters.AddWithValue("@Priority", entity.Priority);
            
            return command;
        }

        public override SqlCommand CreateUpdateCommand(SqlConnection connection, ProcedureGroup entity)
        {
            var command = new SqlCommand("ProcedureGroupUpd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@ProcedureGroupID", entity.Id);
            command.Parameters.AddWithValue("@ProcedureGroupName", entity.Name);
            command.Parameters.AddWithValue("@Priority", entity.Priority);
            
            return command;
        }

        public override SqlCommand CreateDeleteCommand(SqlConnection connection, ProcedureGroup entity)
        {
            var command = new SqlCommand("ProcedureGroupDel", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@ProcedureGroupID", entity.Id);
            
            return command;
        }

        public override void LoadEntityAttributes(SqlDataReader reader, ProcedureGroup entity)
        {
            entity.Id = reader.GetValue<int>("ProcedureGroupID");
            entity.Name = reader.GetString("ProcedureGroupName");
            entity.Priority = reader.GetValue<int>("Priority");
       }

        public override void LoadNewEntityAttributes(SqlDataReader reader, ProcedureGroup entity)
        {
            entity.Id = reader.GetValue<int>("ProcedureGroupID");
        }
    }
}
