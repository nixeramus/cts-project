using System;
using System.Data.SqlClient;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;

namespace TD.CTS.MsSqlData.Builders
{
    internal class PatientTrialCommandBuilder : CommandBuilder<PatientTrial>
    {
        public override SqlCommand CreateGetCommand(SqlConnection connection, DataFilter<PatientTrial> filter)
        {
            var command = new SqlCommand("PatientTrialRep", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            var entityFilter = (PatientTrialDataFilter)filter ?? new PatientTrialDataFilter();

            command.Parameters.AddWithValue("@PatientCode", entityFilter.PatientId.GetNullableParameterValue());
            
            return command;
        }

        public override SqlCommand CreateAddCommand(SqlConnection connection, PatientTrial entity)
        {
            throw new NotSupportedException();
        }

        public override SqlCommand CreateUpdateCommand(SqlConnection connection, PatientTrial entity)
        {
            throw new NotSupportedException();
        }

        public override SqlCommand CreateDeleteCommand(SqlConnection connection, PatientTrial entity)
        {
            throw new NotSupportedException();
        }

        public override void LoadEntityAttributes(SqlDataReader reader, PatientTrial entity)
        {
            entity.ScrNCode = reader.GetString("ScrNCode");
            entity.RandNCode = reader.GetString("RandNCode");
            entity.TrialCode = reader.GetString("TrialCode");
            entity.TrialName = reader.GetString("TrialName");
            entity.BeginDate = reader.GetNullableValue<DateTime>("BeginDate");
            entity.EndDate = reader.GetNullableValue<DateTime>("EndDate");
       }

        public override void LoadNewEntityAttributes(SqlDataReader reader, PatientTrial entity)
        {
        }
    }
}
