using System;
using System.Data.SqlClient;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;

namespace TD.CTS.MsSqlData.Builders
{
    internal class ScheduleCommandBuilder : CommandBuilder<Schedule>
    {
        public override SqlCommand CreateGetCommand(SqlConnection connection, DataFilter<Schedule> filter)
        {
            var command = new SqlCommand("ScheduleGet", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            var entityFilter = (ScheduleDataFilter)filter;

            command.Parameters.AddWithValue("@ScheduleID", entityFilter.ScheduleID.GetNullableParameterValue());
            command.Parameters.AddWithValue("@BeginDateBeg", entityFilter.BeginDateBegin.GetNullableParameterValue());
            command.Parameters.AddWithValue("@BeginDateEnd", entityFilter.BeginDateEnd.GetNullableParameterValue());
            command.Parameters.AddWithValue("@CreateDateBeg", entityFilter.CreateDateBegin.GetNullableParameterValue());
            command.Parameters.AddWithValue("@CreateDateEnd", entityFilter.CreateDateEnd.GetNullableParameterValue());
            command.Parameters.AddWithValue("@TrialName", entityFilter.TrialName.GetLikeParameterValue());
            command.Parameters.AddWithValue("@TrialCenterName", entityFilter.TrialCenterName.GetLikeParameterValue());
            command.Parameters.AddWithValue("@PatientFullName", entityFilter.PatientFullName.GetLikeParameterValue());
            command.Parameters.AddWithValue("@OwnSchedulesOnly", entityFilter.OwnSchedulesOnly);

            return command;
        }

        public override SqlCommand CreateAddCommand(SqlConnection connection, Schedule entity)
        {
            var command = new SqlCommand("ScheduleAdd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };
            //command.Parameters.AddWithValue("@ScheduleID", entity.Id);
            command.Parameters.AddWithValue("@PatientCode", entity.PatientCode);
            command.Parameters.AddWithValue("@TrialCenterID", entity.TrialCenterID);
            //command.Parameters.AddWithValue("@TrialCode", entity.TrialCode);
            //command.Parameters.AddWithValue("@BeginDate", entity.BeginDate);
            command.Parameters.AddWithValue("@Comment", entity.Comment.GetNullableParameterValue());
            command.Parameters.AddWithValue("@ScheduleStatus", entity.ScheduleStatus);
            return command;
        }

        public override SqlCommand CreateUpdateCommand(SqlConnection connection, Schedule entity)
        {
            var command = new SqlCommand("ScheduleUpd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@ScheduleID", entity.Id);
            command.Parameters.AddWithValue("@PatientCode", entity.PatientCode);
            command.Parameters.AddWithValue("@TrialCenterID", entity.TrialCenterID);
            //command.Parameters.AddWithValue("@TrialCode", entity.TrialCode);
            //command.Parameters.AddWithValue("@BeginDate", entity.BeginDate);
            command.Parameters.AddWithValue("@Comment", entity.Comment.GetNullableParameterValue());
            command.Parameters.AddWithValue("@ScheduleStatus", entity.ScheduleStatus);
            command.Parameters.AddWithValue("@RandN", entity.RandN.GetNullableParameterValue());
            command.Parameters.AddWithValue("@ScrN", entity.ScrN.GetNullableParameterValue());
            return command;
        }

        public override SqlCommand CreateDeleteCommand(SqlConnection connection, Schedule entity)
        {
            var command = new SqlCommand("ScheduleDel", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@ScheduleID", entity.Id);

            return command;
        }

        public override void LoadEntityAttributes(SqlDataReader reader, Schedule entity)
        {
            entity.Id = reader.GetValue<int>("ScheduleID");
            entity.PatientCode = reader.GetValue<int>("PatientCode");
            entity.PatientFullName = reader.GetString("PatientFullName");
            entity.BirthDate = reader.GetValue<DateTime>("BirthDate");
            entity.BeginDate = reader.GetNullableValue<DateTime>("BeginDate");
            entity.CreateDate = reader.GetValue<DateTime>("CreateDate");
            entity.TrialCenterID = reader.GetValue<int>("TrialCenterID");
            entity.TrialCode = reader.GetString("TrialCode").TrimEnd();
            entity.TrialCenterName = reader.GetString("TrialCenterName");
            entity.TrialName = reader.GetString("TrialName").TrimEnd();
            entity.AuthorLogin = reader.GetString("AuthorLogin");
            entity.ModificatorLogin = reader.GetString("ModificatorLogin");
            entity.ModificationDate = reader.GetValue<DateTime>("ModificationDate");
            entity.Comment = reader.GetNullableString("Comment");
            entity.ScheduleStatus = reader.GetString("ScheduleStatus");
            entity.TrialVersionNo = reader.GetValue<int>("TrialVersionNo");
            entity.RandN = reader.GetNullableValue<decimal>("RandN");
            entity.ScrN = reader.GetNullableValue<decimal>("ScrN");
            entity.UseRandN = reader.GetValue<bool>("UseRandN");

        }

        public override void LoadNewEntityAttributes(SqlDataReader reader, Schedule entity)
        {
            LoadEntityAttributes(reader, entity);
        }
    }
}
