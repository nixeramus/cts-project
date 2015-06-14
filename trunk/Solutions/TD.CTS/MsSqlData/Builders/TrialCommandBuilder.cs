using System;
using System.Data.SqlClient;
using TD.Common.Data;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Enums;
using TD.CTS.Data.Filters;

namespace TD.CTS.MsSqlData.Builders
{
    internal class TrialCommandBuilder : CommandBuilder<Trial>
    {
        public override SqlCommand CreateGetCommand(SqlConnection connection, DataFilter<Trial> filter)
        {
            var command = new SqlCommand("TrialGet", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            var entityFilter = (TrialDataFilter)filter ?? new TrialDataFilter();

            command.Parameters.AddWithValue("@TrialCode", entityFilter.Code.GetNullableParameterValue());
            command.Parameters.AddWithValue("@TrialName", entityFilter.Name.GetLikeParameterValue());
            command.Parameters.AddWithValue("@TaxiBooking", entityFilter.TaxiBooking.GetNullableParameterValue());
            command.Parameters.AddWithValue("@TaxiService", entityFilter.TaxiService.GetLikeParameterValue());
            command.Parameters.AddWithValue("@CreateDateBeg", entityFilter.CreateDateBegin.GetNullableParameterValue());
            command.Parameters.AddWithValue("@CreateDateEnd", entityFilter.CreateDateEnd.GetNullableParameterValue());
            command.Parameters.AddWithValue("@OwnTrialsOnly", entityFilter.OwnTrialsOnly);
            
            return command;
        }

        public override SqlCommand CreateAddCommand(SqlConnection connection, Trial entity)
        {
            var command = new SqlCommand("TrialAdd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@TrialCode", entity.Code);
            command.Parameters.AddWithValue("@TrialName", entity.Name);
            command.Parameters.AddWithValue("@TaxiBooking", entity.TaxiBooking);
            command.Parameters.AddWithValue("@TaxiService", entity.TaxiService.GetNullableParameterValue());
            command.Parameters.AddWithValue("@UseRandN", entity.UseRandN);
            
            return command;
        }

        public override SqlCommand CreateUpdateCommand(SqlConnection connection, Trial entity)
        {
            var command = new SqlCommand("TrialUpd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@TrialCode", entity.Code);
            command.Parameters.AddWithValue("@TrialName", entity.Name);
            command.Parameters.AddWithValue("@TaxiBooking", entity.TaxiBooking);
            command.Parameters.AddWithValue("@TaxiService", entity.TaxiService.GetNullableParameterValue());
            command.Parameters.AddWithValue("@UseRandN", entity.UseRandN);
            
            return command;
        }

        public override SqlCommand CreateDeleteCommand(SqlConnection connection, Trial entity)
        {
            var command = new SqlCommand("TrialDel", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@TrialCode", entity.Code);
            
            return command;
        }

        public override void LoadEntityAttributes(SqlDataReader reader, Trial entity)
        {
            entity.Code = reader.GetString("TrialCode").TrimEnd();
            entity.Name = reader.GetString("TrialName");
            entity.AdministratorLogin = reader.GetString("AdministratorLogin");
            entity.AuthorLogin = reader.GetString("AuthorLogin");
            entity.CreateDate = reader.GetValue<DateTime>("CreateDate");
            entity.Status = EnumExtensions.GetByDescription<TrialStatus>(reader.GetString("TrialStatus"));
            entity.OriginalStatus = entity.Status;
            entity.TaxiBooking = reader.GetValue<bool>("TaxiBooking");
            entity.TaxiService = reader.GetNullableString("TaxiService");
            entity.Version = reader.GetValue<int>("TrialVersionNo");
            entity.VersionDate = reader.GetValue<DateTime>("VersionDate");
            entity.VersionStatus = reader.GetString("VersionStatus");
            entity.UseRandN = reader.GetValue<bool>("UseRandN");
       }

        public override void LoadNewEntityAttributes(SqlDataReader reader, Trial entity)
        {
            LoadEntityAttributes(reader, entity);
        }
    }
}
