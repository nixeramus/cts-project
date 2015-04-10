using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;
using TD.CTS.Data.Helpers;

namespace TD.CTS.MsSqlData.Builders
{
    internal class TrialCenterCommandBuilder : CommandBuilder<TrialCenter>
    {
        public override SqlCommand CreateGetCommand(SqlConnection connection, DataFilter<TrialCenter> filter)
        {
            var command = new SqlCommand("TrialCenterGet", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            var entityFilter = (TrialCenterDataFilter)filter;

            command.Parameters.AddWithValue("@TrialCode", entityFilter.TrialCode.GetNullableParameterValue());
            command.Parameters.AddWithValue("@TrialCenterID", entityFilter.Id.GetNullableParameterValue());
            
            return command;
        }

        public override SqlCommand CreateAddCommand(SqlConnection connection, TrialCenter entity)
        {
            var command = new SqlCommand("TrialCenterAdd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@TrialCode", entity.TrialCode);
            command.Parameters.AddWithValue("@TrialCenterName", entity.Number);
            command.Parameters.AddWithValue("@HospitalID", entity.HospitalId);
            command.Parameters.AddWithValue("@PISystemLogin", entity.AnatomistLogin);
            command.Parameters.AddWithValue("@COSystemLogin", entity.CoordinatorLogin.GetNullableParameterValue());
            
            return command;
        }

        public override SqlCommand CreateUpdateCommand(SqlConnection connection, TrialCenter entity)
        {
            var command = new SqlCommand("TrialCenterUpd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@TrialCenterID", entity.Id);
            command.Parameters.AddWithValue("@TrialCenterName", entity.Number);
            command.Parameters.AddWithValue("@PISystemLogin", entity.AnatomistLogin);
            command.Parameters.AddWithValue("@COSystemLogin", entity.CoordinatorLogin.GetNullableParameterValue());
            
            return command;
        }

        public override SqlCommand CreateDeleteCommand(SqlConnection connection, TrialCenter entity)
        {
            var command = new SqlCommand("TrialCenterDel", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@TrialCenterID", entity.Id);
            
            return command;
        }

        public override void LoadEntityAttributes(SqlDataReader reader, TrialCenter entity)
        {
            entity.Id = reader.GetValue<int>("TrialCenterID");
            entity.TrialCode = reader.GetString("TrialCode").TrimEnd();
            entity.Number = reader.GetString("TrialCenterName");
            entity.HospitalId = reader.GetValue<int>("HospitalID");
            entity.AnatomistLogin = reader.GetString("PISystemLogin");
            entity.CoordinatorLogin = reader.GetNullableString("COSystemLogin");
        }

        public override void LoadNewEntityAttributes(SqlDataReader reader, TrialCenter entity)
        {
            entity.Id = reader.GetValue<int>("TrialCenterID");
        }
    }
}
