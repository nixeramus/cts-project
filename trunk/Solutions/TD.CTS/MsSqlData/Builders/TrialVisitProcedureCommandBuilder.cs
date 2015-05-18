using System;
using System.Data.SqlClient;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;

namespace TD.CTS.MsSqlData.Builders
{
    internal class TrialVisitProcedureCommandBuilder : CommandBuilder<TrialProcedureVisit>
    {
        public override SqlCommand CreateGetCommand(SqlConnection connection, DataFilter<TrialProcedureVisit> filter)
        {
            var command = new SqlCommand("TrialVisitProcedureGet", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            var entityFilter = (TrialProcedureVisitDataFilter)filter ?? new TrialProcedureVisitDataFilter();

            command.Parameters.AddWithValue("@TrialVisitProcedureID", entityFilter.Id.GetNullableParameterValue());
            command.Parameters.AddWithValue("@TrialVisitID", entityFilter.TrialVisitId.GetNullableParameterValue());
            command.Parameters.AddWithValue("@TrialCode", entityFilter.TrialCode.GetNullableParameterValue());
            command.Parameters.AddWithValue("@TrialVersionNo", entityFilter.TrialVersion.GetNullableParameterValue());
                        
            return command;
        }

        public override SqlCommand CreateAddCommand(SqlConnection connection, TrialProcedureVisit entity)
        {
            var command = new SqlCommand("TrialVisitProcedureAdd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@TrialVisitID", entity.TrialVisitId);
            command.Parameters.AddWithValue("@ProcedureCode", entity.ProcedureCode);
            command.Parameters.AddWithValue("@TrialCode", entity.TrialCode);
            command.Parameters.AddWithValue("@TrialVersionNo", entity.TrialVersion);
            
            return command;
        }

        public override SqlCommand CreateUpdateCommand(SqlConnection connection, TrialProcedureVisit entity)
        {
            throw new NotSupportedException();
        }

        public override SqlCommand CreateDeleteCommand(SqlConnection connection, TrialProcedureVisit entity)
        {
            var command = new SqlCommand("TrialVisitProcedureDel", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@TrialVisitProcedureID", entity.Id);
            
            return command;
        }

        public override void LoadEntityAttributes(SqlDataReader reader, TrialProcedureVisit entity)
        {
            entity.Id = reader.GetValue<int>("TrialVisitProcedureID");
            entity.TrialVisitId = reader.GetValue<int>("TrialVisitID");
            entity.ProcedureCode = reader.GetString("ProcedureCode").TrimEnd();
            entity.TrialCode = reader.GetString("TrialCode").TrimEnd();
            entity.TrialVersion = reader.GetValue<int>("TrialVersionNo");
        }

        public override void LoadNewEntityAttributes(SqlDataReader reader, TrialProcedureVisit entity)
        {
            entity.Id = reader.GetValue<int>("TrialVisitProcedureID");
        }
    }
}
