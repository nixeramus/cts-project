using System;
using System.Data.SqlClient;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;

namespace TD.CTS.MsSqlData.Builders
{
    internal class TrialProcedureCommandBuilder : CommandBuilder<TrialProcedure>
    {
        public override SqlCommand CreateGetCommand(SqlConnection connection, DataFilter<TrialProcedure> filter)
        {
            var command = new SqlCommand("TrialProcedureGet", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            var entityFilter = (TrialProcedureDataFilter)filter ?? new TrialProcedureDataFilter { Id = -1 };

            command.Parameters.AddWithValue("@TrialProcedureID", entityFilter.Id.GetNullableParameterValue());
            command.Parameters.AddWithValue("@TrialCode", entityFilter.TrialCode.GetNullableParameterValue());
            command.Parameters.AddWithValue("@TrialVersionNo", entityFilter.TrialVersionId.GetNullableParameterValue());
                        
            return command;
        }

        public override SqlCommand CreateAddCommand(SqlConnection connection, TrialProcedure entity)
        {
            var command = new SqlCommand("TrialProcedureAdd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@TrialCode", entity.TrialCode);
            command.Parameters.AddWithValue("@TrialVersionNo", entity.TrialVersionId);
            command.Parameters.AddWithValue("@ProcedureCode", entity.ProcedureCode);
            
            return command;
        }

        public override SqlCommand CreateUpdateCommand(SqlConnection connection, TrialProcedure entity)
        {
            throw new NotSupportedException();
        }

        public override SqlCommand CreateDeleteCommand(SqlConnection connection, TrialProcedure entity)
        {
            var command = new SqlCommand("TrialProcedureDel", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@TrialProcedureID", entity.Id);
            
            return command;
        }

        public override void LoadEntityAttributes(SqlDataReader reader, TrialProcedure entity)
        {
            entity.Id = reader.GetValue<int>("TrialProcedureID");
            entity.TrialCode = reader.GetString("TrialCode").TrimEnd();
            entity.TrialVersionId = reader.GetValue<int>("TrialVersionNo");
            entity.ProcedureCode = reader.GetString("ProcedureCode").TrimEnd();
        }

        public override void LoadNewEntityAttributes(SqlDataReader reader, TrialProcedure entity)
        {
            entity.Id = reader.GetValue<int>("TrialProcedureID");
        }
    }
}
