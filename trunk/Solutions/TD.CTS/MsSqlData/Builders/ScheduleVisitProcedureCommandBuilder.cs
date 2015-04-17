using System;
using System.Data.SqlClient;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;

namespace TD.CTS.MsSqlData.Builders
{
    internal class ScheduleVisitProcedureCommandBuilder : CommandBuilder<ScheduleVisitProcedure>
    {
        public override SqlCommand CreateGetCommand(SqlConnection connection, DataFilter<ScheduleVisitProcedure> filter)
        {
            var command = new SqlCommand("ScheduleVisitProcedureGet", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            var entityFilter = (ScheduleVisitProcedureDataFilter)filter;

            command.Parameters.AddWithValue("@ScheduleID", entityFilter.ScheduleID.GetNullableParameterValue());
            command.Parameters.AddWithValue("@TrialVisitID", entityFilter.TrialVisitID.GetNullableParameterValue());
            command.Parameters.AddWithValue("@ProcedureCode", entityFilter.ProcedureCode.GetNullableParameterValue());

            return command;
        }

        public override SqlCommand CreateAddCommand(SqlConnection connection, ScheduleVisitProcedure entity)
        {
            throw new NotImplementedException();
        }


        public override SqlCommand CreateUpdateCommand(SqlConnection connection, ScheduleVisitProcedure entity)
        {
            var command = new SqlCommand("ScheduleVisitUpd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@ScheduleID", entity.ScheduleID);
            command.Parameters.AddWithValue("@TrialVisitID", entity.TrialVisitID);
            command.Parameters.AddWithValue("@ProcedureCode", entity.ProcedureCode.GetNullableParameterValue());
            command.Parameters.AddWithValue("@TrialCode", entity.TrialCode);
            command.Parameters.AddWithValue("@TrialVersionNo", entity.TrialVersionNo);
            command.Parameters.AddWithValue("@TrialCenterID", entity.TrialCenterID);
            command.Parameters.AddWithValue("@Completed", entity.Completed);
            return command;
        }

        public override SqlCommand CreateDeleteCommand(SqlConnection connection, ScheduleVisitProcedure entity)
        {
            throw new NotImplementedException();
        }


        public override void LoadEntityAttributes(SqlDataReader reader, ScheduleVisitProcedure entity)
        {
            entity.ScheduleID = reader.GetValue<int>("ScheduleID");
            entity.TrialVisitID = reader.GetValue<int>("TrialVisitID");
            entity.ProcedureCode = reader.GetString("ProcedureCode").Trim();
            entity.TrialCode = reader.GetString("TrialCode");
            entity.TrialVersionNo = reader.GetValue<int>("TrialVersionNo");
            entity.TrialCenterID = reader.GetValue<int>("TrialCenterID");
            entity.ModificataorLogin = reader.GetNullableString("ModificataorLogin");
            entity.ModififcationDate = reader.GetNullableValue<DateTime>("ModififcationDate");
            entity.Completed = reader.GetValue<bool>("Completed");
        }

        public override void LoadNewEntityAttributes(SqlDataReader reader, ScheduleVisitProcedure entity)
        {
            LoadEntityAttributes(reader, entity);
        }
    }
}
