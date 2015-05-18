using System.Data.SqlClient;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;

namespace TD.CTS.MsSqlData.Builders
{
    internal class TrialVisitCommandBuilder : CommandBuilder<TrialVisit>
    {
        public override SqlCommand CreateGetCommand(SqlConnection connection, DataFilter<TrialVisit> filter)
        {
            var command = new SqlCommand("TrialVisitGet", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            var entityFilter = (TrialVisitDataFilter)filter ?? new TrialVisitDataFilter();

            command.Parameters.AddWithValue("@TrialVisitID", entityFilter.Id.GetNullableParameterValue());
            command.Parameters.AddWithValue("@TrialCode", entityFilter.TrialCode.GetNullableParameterValue());
            command.Parameters.AddWithValue("@TrialVersionNo", entityFilter.TrialVersion.GetNullableParameterValue());
                        
            return command;
        }

        public override SqlCommand CreateAddCommand(SqlConnection connection, TrialVisit entity)
        {
            var command = new SqlCommand("TrialVisitAdd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@TrialCode", entity.TrialCode);
            command.Parameters.AddWithValue("@TrialVersionNo", entity.TrialVersion);
            command.Parameters.AddWithValue("@TrialVisitName", entity.Name);
            command.Parameters.AddWithValue("@BaseDay", entity.Days);
            command.Parameters.AddWithValue("@Limit", entity.Punctuality);
            command.Parameters.AddWithValue("@VisitNo", entity.Number);
            
            return command;
        }

        public override SqlCommand CreateUpdateCommand(SqlConnection connection, TrialVisit entity)
        {
            var command = new SqlCommand("TrialVisitUpd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@TrialVisitID", entity.Id);
            command.Parameters.AddWithValue("@TrialVisitName", entity.Name);
            command.Parameters.AddWithValue("@BaseDay", entity.Days);
            command.Parameters.AddWithValue("@Limit", entity.Punctuality);
            command.Parameters.AddWithValue("@VisitNo", entity.Number);
            
            return command;
        }

        public override SqlCommand CreateDeleteCommand(SqlConnection connection, TrialVisit entity)
        {
            var command = new SqlCommand("TrialVisitDel", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@TrialVisitID", entity.Id);
            
            return command;
        }

        public override void LoadEntityAttributes(SqlDataReader reader, TrialVisit entity)
        {
            entity.Id = reader.GetValue<int>("TrialVisitID");
            entity.TrialCode = reader.GetString("TrialCode").TrimEnd();
            entity.TrialVersion = reader.GetValue<int>("TrialVersionNo");
            entity.Name = reader.GetString("TrialVisitName");
            entity.Days = reader.GetValue<int>("BaseDay");
            entity.Punctuality = reader.GetValue<int>("Limit");
            entity.Cost = reader.GetNullableValue<decimal>("Cost");
            entity.Number = reader.GetValue<int>("VisitNo");
        }

        public override void LoadNewEntityAttributes(SqlDataReader reader, TrialVisit entity)
        {
            entity.Id = reader.GetValue<int>("TrialVisitID");
        }
    }
}
