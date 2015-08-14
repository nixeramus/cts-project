using System;
using System.Data.SqlClient;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;

namespace TD.CTS.MsSqlData.Builders
{
    internal class TrialVisitReportCommandBuilder : CommandBuilder<TrialVisitReport>
    {
        public override SqlCommand CreateGetCommand(SqlConnection connection, DataFilter<TrialVisitReport> filter)
        {
            var command = new SqlCommand("VisitReportGet", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            var entityFilter = (TrialVisitReportDataFilter)filter ?? new TrialVisitReportDataFilter();

            command.Parameters.AddWithValue("@DateBeg", entityFilter.DateBegin);
            command.Parameters.AddWithValue("@DateEnd", entityFilter.DateEnd);

            return command;
        }

        public override SqlCommand CreateAddCommand(SqlConnection connection, TrialVisitReport entity)
        {
            throw new NotImplementedException();
        }

        public override SqlCommand CreateUpdateCommand(SqlConnection connection, TrialVisitReport entity)
        {
            throw new NotImplementedException();
        }

        public override SqlCommand CreateDeleteCommand(SqlConnection connection, TrialVisitReport entity)
        {
            throw new NotImplementedException();
        }

        public override void LoadEntityAttributes(SqlDataReader reader, TrialVisitReport entity)
        {
            entity.TrialCode = reader.GetString("TrialCode").TrimEnd();
            entity.TrialVersion = reader.GetValue<int>("TrialVersionNo");
            entity.TrialName = reader.GetString("TrialName");
            entity.TrialVisitId = reader.GetValue<int>("TrialVisitID");
            entity.TrialVisitName = reader.GetString("TrialVisitName");
            entity.Date = reader.GetNullableValue<DateTime>("Date");
            entity.PatientId = reader.GetValue<int>("PatientCode");
            entity.PatientName = reader.GetString("PatientFullName");
            entity.Completed = reader.GetValue<bool>("Completed");
            entity.ScheduleVisitID = reader.GetValue<int>("ScheduleVisitID");
        }

        public override void LoadNewEntityAttributes(SqlDataReader reader, TrialVisitReport entity)
        {
            LoadEntityAttributes(reader, entity);
        }
    }
}
