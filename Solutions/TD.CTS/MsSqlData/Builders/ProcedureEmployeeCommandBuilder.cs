using System;
using System.Data.SqlClient;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;

namespace TD.CTS.MsSqlData.Builders
{
    internal class ProcedureEmployeeCommandBuilder : CommandBuilder<ProcedureEmployee>
    {
        public override SqlCommand CreateGetCommand(SqlConnection connection, DataFilter<ProcedureEmployee> filter)
        {
            var command = new SqlCommand("ProcedureEmployeeGet", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            var entityFilter = (ProcedureEmployeeDataFilter)filter;

            command.Parameters.AddWithValue("@ScheduleID", entityFilter.ScheduleID.GetNullableParameterValue());
            command.Parameters.AddWithValue("@TrialVisitID", entityFilter.TrialVisitID.GetNullableParameterValue());
            command.Parameters.AddWithValue("@ProcedureCode", entityFilter.ProcedureCode.GetNullableParameterValue());

            command.Parameters.AddWithValue("@TrialCenterID", entityFilter.TrialCenterID.GetNullableParameterValue());
            command.Parameters.AddWithValue("@TrialVersionNo", entityFilter.TrialVersionNo.GetNullableParameterValue());
           
            command.Parameters.AddWithValue("@SystemRoleCode", entityFilter.SystemRoleCode.GetNullableParameterValue());

            return command;
        }

        public override SqlCommand CreateAddCommand(SqlConnection connection, ProcedureEmployee entity)
        {
            throw new NotImplementedException();
        }

        public override SqlCommand CreateUpdateCommand(SqlConnection connection, ProcedureEmployee entity)
        {
            var command = new SqlCommand("ProcedureEmployeeUpd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };
            
            //command.Parameters.AddWithValue("@ScheduleID", entity.ScheduleID);
            //command.Parameters.AddWithValue("@TrialVisitID", entity.TrialVisitID);
            //command.Parameters.AddWithValue("@TrialCenterID", entity.TrialCenterID);
            //command.Parameters.AddWithValue("@TrialVersionNo", entity.TrialVersionNo);
            //command.Parameters.AddWithValue("@ProcedureCode", entity.ProcedureCode);
            //command.Parameters.AddWithValue("@SystemRoleCode", entity.SystemRoleCode);
            command.Parameters.AddWithValue("@ProcedureEmployeeID", entity.Id);
            command.Parameters.AddWithValue("@ExecutorLogin", entity.ExecutorLogin);
            return command;
        }

        public override SqlCommand CreateDeleteCommand(SqlConnection connection, ProcedureEmployee entity)
        {
            throw new NotImplementedException();
        }

        public override void LoadEntityAttributes(SqlDataReader reader, ProcedureEmployee entity)
        {
            entity.Id = reader.GetValue<int>("ProcedureEmployeeID");
            entity.ScheduleID = reader.GetValue<int>("ScheduleID");
            entity.TrialVisitID = reader.GetValue<int>("TrialVisitID");
            entity.TrialVersionNo = reader.GetValue<int>("TrialVersionNo");
            entity.ProcedureCode = reader.GetString("ProcedureCode").Trim();
            entity.SystemRoleCode = reader.GetString("SystemRoleCode").Trim();
            entity.TrialCenterID = reader.GetValue<int>("TrialCenterID");
            entity.ExecutorLogin = reader.GetNullableString("ExecutorLogin");
        }

        public override void LoadNewEntityAttributes(SqlDataReader reader, ProcedureEmployee entity)
        {
            LoadEntityAttributes(reader, entity);
        }
    }
}
