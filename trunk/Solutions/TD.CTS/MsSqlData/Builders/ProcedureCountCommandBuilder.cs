using System;
using System.Data.SqlClient;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;

namespace TD.CTS.MsSqlData.Builders
{
    internal class ProcedureCountCommandBuilder : CommandBuilder<ProcedureCount>
    {
        public override SqlCommand CreateGetCommand(SqlConnection connection, DataFilter<ProcedureCount> filter)
        {
            var command = new SqlCommand("TaskProceduresGet", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            var entityFilter = (ProcedureCountDataFilter)filter ?? new ProcedureCountDataFilter();

            command.Parameters.AddWithValue("@ScheduleDateBegin", entityFilter.VisitDateBegin.GetNullableParameterValue());
            command.Parameters.AddWithValue("@ScheduleDateEnd", entityFilter.VisitDateEnd.GetNullableParameterValue());
            
            return command;
        }

        public override SqlCommand CreateAddCommand(SqlConnection connection, ProcedureCount entity)
        {
            throw new NotSupportedException();
        }

        public override SqlCommand CreateUpdateCommand(SqlConnection connection, ProcedureCount entity)
        {
            throw new NotSupportedException();
        }

        public override SqlCommand CreateDeleteCommand(SqlConnection connection, ProcedureCount entity)
        {
            throw new NotSupportedException();
        }

        public override void LoadEntityAttributes(SqlDataReader reader, ProcedureCount entity)
        {
            entity.IsDone = reader.GetValue<bool>("Completed");
            entity.ProcedureCode = reader.GetString("ProcedureCode").Trim();
            entity.VisitDate = reader.GetValue<DateTime>("ScheduleDate");
            entity.Count = reader.GetValue<int>("Count");
            
       }

        public override void LoadNewEntityAttributes(SqlDataReader reader, ProcedureCount entity)
        {
        }
    }
}
