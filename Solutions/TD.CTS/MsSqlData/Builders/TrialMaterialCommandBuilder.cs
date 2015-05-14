using System.Data.SqlClient;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;

namespace TD.CTS.MsSqlData.Builders
{
    internal class TrialMaterialCommandBuilder : CommandBuilder<TrialMaterial>
    {
        public override SqlCommand CreateGetCommand(SqlConnection connection, DataFilter<TrialMaterial> filter)
        {
            var command = new SqlCommand("MaterialGet", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            var entityFilter = (TrialMaterialDataFilter)filter ?? new TrialMaterialDataFilter { Id = -1 };

            command.Parameters.AddWithValue("@MaterialID", entityFilter.Id.GetNullableParameterValue());
            command.Parameters.AddWithValue("@TrialCode", entityFilter.TrialCode.GetNullableParameterValue());
                        
            return command;
        }

        public override SqlCommand CreateAddCommand(SqlConnection connection, TrialMaterial entity)
        {
            var command = new SqlCommand("MaterialAdd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@TrialCode", entity.TrialCode);
            command.Parameters.AddWithValue("@MaterialName", entity.Name);
            
            return command;
        }

        public override SqlCommand CreateUpdateCommand(SqlConnection connection, TrialMaterial entity)
        {
            var command = new SqlCommand("MaterialUpd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@MaterialID", entity.Id);
            command.Parameters.AddWithValue("@MaterialName", entity.Name);
            
            return command;
        }

        public override SqlCommand CreateDeleteCommand(SqlConnection connection, TrialMaterial entity)
        {
            var command = new SqlCommand("MaterialDel", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@MaterialID", entity.Id);
            
            return command;
        }

        public override void LoadEntityAttributes(SqlDataReader reader, TrialMaterial entity)
        {
            entity.Id = reader.GetValue<int>("MaterialID");
            entity.TrialCode = reader.GetString("TrialCode").TrimEnd();
            entity.Name = reader.GetString("MaterialName");
        }

        public override void LoadNewEntityAttributes(SqlDataReader reader, TrialMaterial entity)
        {
            entity.Id = reader.GetValue<int>("MaterialID");
        }
    }
}
