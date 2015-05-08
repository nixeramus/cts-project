using System;
using System.Data.SqlClient;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;

namespace TD.CTS.MsSqlData.Builders
{
    internal class SchedulePlaningVisitCommandBuilder : CommandBuilder<SchedulePlaningVisit>
    {
        public override SqlCommand CreateGetCommand(SqlConnection connection, DataFilter<SchedulePlaningVisit> filter)
        {
            var command = new SqlCommand("SchedulePlaningVisitGet", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            var entityFilter = (SchedulePlaningVisitDataFilter)filter;

            //command.Parameters.AddWithValue("@ScheduleID", entityFilter.ScheduleID.GetNullableParameterValue());
            //command.Parameters.AddWithValue("@BeginDateBeg", entityFilter.BeginDateBegin.GetNullableParameterValue());
            //command.Parameters.AddWithValue("@BeginDateEnd", entityFilter.BeginDateEnd.GetNullableParameterValue());
            //command.Parameters.AddWithValue("@CreateDateBeg", entityFilter.CreateDateBegin.GetNullableParameterValue());
            //command.Parameters.AddWithValue("@CreateDateEnd", entityFilter.CreateDateEnd.GetNullableParameterValue());
            //command.Parameters.AddWithValue("@TrialName", entityFilter.TrialName.GetLikeParameterValue());
            //command.Parameters.AddWithValue("@TrialCenterName", entityFilter.TrialCenterName.GetLikeParameterValue());
            //command.Parameters.AddWithValue("@PatientFullName", entityFilter.PatientFullName.GetLikeParameterValue());
            //command.Parameters.AddWithValue("@OwnSchedulesOnly", entityFilter.OwnSchedulesOnly);

            return command;
        }

        public override SqlCommand CreateAddCommand(SqlConnection connection, SchedulePlaningVisit entity)
        {
            throw new NotImplementedException();
        }


        public override SqlCommand CreateUpdateCommand(SqlConnection connection, SchedulePlaningVisit entity)
        {
            var command = new SqlCommand("ScheduleVisitUpd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@ScheduleID", entity.ScheduleID);
            command.Parameters.AddWithValue("@TrialVisitID", entity.TrialVisitID);
            command.Parameters.AddWithValue("@TrialCenterID", entity.TrialCenterID);
            command.Parameters.AddWithValue("@TrialCode", entity.TrialCode);
            command.Parameters.AddWithValue("@TrialVersionNo", entity.TrialVersionNo);

            command.Parameters.AddWithValue("@ScheduleDate", entity.ScheduleDate.GetNullableParameterValue());
            command.Parameters.AddWithValue("@ActualDate", entity.ActualDate.GetNullableParameterValue());
            

            return command;
        }

        public override SqlCommand CreateDeleteCommand(SqlConnection connection, SchedulePlaningVisit entity)
        {
             var command = new SqlCommand("ScheduleVisitDel", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@ScheduleID", entity.ScheduleID);
            command.Parameters.AddWithValue("@TrialVisitID", entity.TrialVisitID);
            command.Parameters.AddWithValue("@TrialCenterID", entity.TrialCenterID);
            command.Parameters.AddWithValue("@TrialCode", entity.TrialCode);
            command.Parameters.AddWithValue("@TrialVersionNo", entity.TrialVersionNo);

            return command;
        }


        public override void LoadEntityAttributes(SqlDataReader reader, SchedulePlaningVisit entity)
        {
            entity.ScheduleID = reader.GetValue<int>("ScheduleID");
            entity.TrialVisitID = reader.GetValue<int>("TrialVisitID");
            entity.TrialCenterID = reader.GetValue<int>("TrialCenterID");
            entity.TrialCode = reader.GetString("TrialCode");
            entity.TrialName = reader.GetString("TrialName");
            entity.TrialVersionNo = reader.GetValue<int>("TrialVersionNo");
            entity.ScheduleDate = reader.GetNullableValue<DateTime>("ScheduleDate");
            entity.ActualDate = reader.GetNullableValue<DateTime>("ActualDate");
            entity.TrialVisitName = reader.GetString("TrialVisitName");
            entity.VisitNo = reader.GetValue<int>("VisitNo");
            entity.BaseDay = reader.GetValue<int>("BaseDay");
            entity.Limit = reader.GetValue<int>("Limit");
        }

        public override void LoadNewEntityAttributes(SqlDataReader reader, SchedulePlaningVisit entity)
        {
            LoadEntityAttributes(reader, entity);
        }
    }
}
