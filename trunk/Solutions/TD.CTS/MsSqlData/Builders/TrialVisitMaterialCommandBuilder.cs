using System;
using System.Data.SqlClient;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;

namespace TD.CTS.MsSqlData.Builders
{
    internal class TrialVisitMaterialCommandBuilder : CommandBuilder<TrialVisitMaterial>
    {
        public override SqlCommand CreateGetCommand(SqlConnection connection, DataFilter<TrialVisitMaterial> filter)
        {
            var command = new SqlCommand("ProcedureMaterialGet", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            var entityFilter = (TrialVisitMaterialDataFilter)filter ?? new TrialVisitMaterialDataFilter();

            command.Parameters.AddWithValue("@ProcedureMaterialID", entityFilter.Id.GetNullableParameterValue());
            command.Parameters.AddWithValue("@TrialCode", entityFilter.TrialCode.GetNullableParameterValue());
            command.Parameters.AddWithValue("@TrialVisitProcedureID", entityFilter.TrialVisitProcedureId.GetNullableParameterValue());
            command.Parameters.AddWithValue("@MaterialID", entityFilter.TrialMaterialId.GetNullableParameterValue());
                        
            return command;
        }

        public override SqlCommand CreateAddCommand(SqlConnection connection, TrialVisitMaterial entity)
        {
            var command = new SqlCommand("ProcedureMaterialAdd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@TrialCode", entity.TrialCode);
            command.Parameters.AddWithValue("@TrialVisitProcedureID", entity.TrialVisitProcedureId);
            command.Parameters.AddWithValue("@MaterialID", entity.TrialMaterialId);
            
            return command;
        }

        public override SqlCommand CreateUpdateCommand(SqlConnection connection, TrialVisitMaterial entity)
        {
            throw new NotSupportedException();
        }

        public override SqlCommand CreateDeleteCommand(SqlConnection connection, TrialVisitMaterial entity)
        {
            var command = new SqlCommand("ProcedureMaterialDel", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@ProcedureMaterialID", entity.Id);
            
            return command;
        }

        public override void LoadEntityAttributes(SqlDataReader reader, TrialVisitMaterial entity)
        {
            entity.Id = reader.GetValue<int>("ProcedureMaterialID");
            entity.TrialCode = reader.GetString("TrialCode").TrimEnd();
            entity.TrialVisitProcedureId = reader.GetValue<int>("TrialVisitProcedureID");
            entity.TrialMaterialId = reader.GetValue<int>("MaterialID");
        }

        public override void LoadNewEntityAttributes(SqlDataReader reader, TrialVisitMaterial entity)
        {
            entity.Id = reader.GetValue<int>("ProcedureMaterialID");
        }
    }
}
