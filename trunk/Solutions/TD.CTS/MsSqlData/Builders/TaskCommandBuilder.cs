using System;
using System.Data.SqlClient;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;

namespace TD.CTS.MsSqlData.Builders
{
    internal class TaskCommandBuilder : CommandBuilder<Task>
    {
        public override SqlCommand CreateGetCommand(SqlConnection connection, DataFilter<Task> filter)
        {
            var command = new SqlCommand("TaskGet", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            var entityFilter = (TaskDataFilter)filter ?? new TaskDataFilter();

            command.Parameters.AddWithValue("@ScheduleVisitProcedureID", entityFilter.Id.GetNullableParameterValue());
            command.Parameters.AddWithValue("@ScheduleDateBegin", entityFilter.VisitDateBegin.GetNullableParameterValue());
            command.Parameters.AddWithValue("@ScheduleDateEnd", entityFilter.VisitDateEnd.GetNullableParameterValue());
            command.Parameters.AddWithValue("@AllUsers", entityFilter.AllUsers);
            
            return command;
        }

        public override SqlCommand CreateAddCommand(SqlConnection connection, Task entity)
        {
            throw new NotSupportedException();
        }

        public override SqlCommand CreateUpdateCommand(SqlConnection connection, Task entity)
        {
            var command = new SqlCommand("TaskUpd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@ScheduleVisitProcedureID", entity.Id);
            command.Parameters.AddWithValue("@Completed", entity.IsDone);
            command.Parameters.AddWithValue("@ActualDate", entity.VisitDate);
            
            return command;
        }

        public override SqlCommand CreateDeleteCommand(SqlConnection connection, Task entity)
        {
            throw new NotSupportedException();
        }

        public override void LoadEntityAttributes(SqlDataReader reader, Task entity)
        {
            entity.Id = reader.GetValue<int>("ScheduleVisitProcedureID");
            entity.IsDone = reader.GetValue<bool>("Completed");
            entity.PatientFullName = reader.GetString("PatientFullName");
            entity.PatientId = reader.GetValue<int>("PatientCode");
            entity.ProcedureCode = reader.GetString("ProcedureCode").Trim();
            entity.TrialCode = reader.GetString("TrialCode").Trim();
            entity.VisitDate = reader.GetValue<DateTime>("ScheduleDate");
            entity.ScheduleId = reader.GetValue<int>("ScheduleID");
            entity.TrialVisitId = reader.GetValue<int>("TrialVisitID");
            entity.TrialVersion = reader.GetValue<int>("TrialVersionNo");
            entity.TrialVisitProcedureId = reader.GetValue<int>("TrialVisitProcedureID");
       }

        public override void LoadNewEntityAttributes(SqlDataReader reader, Task entity)
        {
        }
    }
}
