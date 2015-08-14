using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;
using TD.CTS.Data.Helpers;

namespace TD.CTS.MsSqlData.Builders
{
    internal class TrialVisitProcedureReportCommandBuilder : CommandBuilder<TrialVisitProcedureReport>
    {
        public override SqlCommand CreateGetCommand(SqlConnection connection, DataFilter<TrialVisitProcedureReport> filter)
        {
            var command = new SqlCommand("VisitProcedureReportGet", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            var entityFilter = (TrialVisitProcedureReportDataFilter)filter ?? new TrialVisitProcedureReportDataFilter();

            command.Parameters.AddWithValue("@ScheduleVisitID", entityFilter.ScheduleVisitID);

            return command;
        }

        public override SqlCommand CreateAddCommand(SqlConnection connection, TrialVisitProcedureReport entity)
        {
            throw new NotImplementedException();
        }

        public override SqlCommand CreateUpdateCommand(SqlConnection connection, TrialVisitProcedureReport entity)
        {
            throw new NotImplementedException();
        }

        public override SqlCommand CreateDeleteCommand(SqlConnection connection, TrialVisitProcedureReport entity)
        {
            throw new NotImplementedException();
        }

        public override void LoadEntityAttributes(SqlDataReader reader, TrialVisitProcedureReport entity)
        {
            entity.ProcedureCode = reader.GetString("ProcedureCode").TrimEnd();
            entity.ProcedureName = reader.GetString("ProcedureName");
            entity.Completed = reader.GetValue<bool>("Completed");
            //entity.Notes = reader.GetString("Notes");
            entity.Users = SerializeHelper.Deserialize<List<User>>(reader.GetString("Users"), "Users");
            entity.Date = reader.GetNullableValue<DateTime>("Date");
        }

        public override void LoadNewEntityAttributes(SqlDataReader reader, TrialVisitProcedureReport entity)
        {
            LoadEntityAttributes(reader, entity);
        }
       
    }
}
