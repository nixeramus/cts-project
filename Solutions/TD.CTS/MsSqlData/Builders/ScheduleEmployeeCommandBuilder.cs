using System;
using System.Data.SqlClient;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;

namespace TD.CTS.MsSqlData.Builders
{
    internal class ScheduleEmployeeCommandBuilder : CommandBuilder<ScheduleEmployee>
    {
        public override SqlCommand CreateGetCommand(SqlConnection connection, DataFilter<ScheduleEmployee> filter)
        {
            var command = new SqlCommand("ScheduleEmployeeGet", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            var entityFilter = (ScheduleEmployeeDataFilter)filter;

            command.Parameters.AddWithValue("@ScheduleID", entityFilter.ScheduleID.GetNullableParameterValue());
            command.Parameters.AddWithValue("@SystemRoleCode", entityFilter.SystemRoleCode.GetNullableParameterValue());
            command.Parameters.AddWithValue("@SystemLogin", entityFilter.SystemLogin.GetNullableParameterValue());


            return command;
        }

        public override SqlCommand CreateAddCommand(SqlConnection connection, ScheduleEmployee entity)
        {
            throw new NotImplementedException();
        }

        public override SqlCommand CreateUpdateCommand(SqlConnection connection, ScheduleEmployee entity)
        {
            var command = new SqlCommand("ScheduleEmployeeUpd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@ScheduleID", entity.ScheduleID);
            command.Parameters.AddWithValue("@SystemRoleCode", entity.SystemRoleCode);
            command.Parameters.AddWithValue("@SystemLogin", entity.SystemLogin);
            return command;
        }

        public override SqlCommand CreateDeleteCommand(SqlConnection connection, ScheduleEmployee entity)
        {
            var command = new SqlCommand("ScheduleEmployeeDel", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@ScheduleEmployeeID", entity.Id);
            command.Parameters.AddWithValue("@ScheduleID", entity.ScheduleID);
            return command;
        }

        public override void LoadEntityAttributes(SqlDataReader reader, ScheduleEmployee entity)
        {
            entity.Id = reader.GetNullableValue<int>("ScheduleEmployeeID");
            entity.ScheduleID = reader.GetValue<int>("ScheduleID");
            entity.SystemRoleCode = reader.GetString("SystemRoleCode").Trim();
            entity.SystemLogin = reader.GetNullableString("SystemLogin");
        }

        public override void LoadNewEntityAttributes(SqlDataReader reader, ScheduleEmployee entity)
        {
            LoadEntityAttributes(reader, entity);
        }
    }
}
