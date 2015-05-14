using System;
using System.Data.SqlClient;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;

namespace TD.CTS.MsSqlData.Builders
{
    internal class PatientCommandBuilder : CommandBuilder<Patient>
    {
        public override SqlCommand CreateGetCommand(SqlConnection connection, DataFilter<Patient> filter)
        {
            var command = new SqlCommand("PatientGet", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            var entityFilter = (PatientDataFilter)filter ?? new PatientDataFilter();

            command.Parameters.AddWithValue("@PatientCode", entityFilter.Id.GetNullableParameterValue());
            command.Parameters.AddWithValue("@HospitalID", entityFilter.HospitalId.GetNullableParameterValue());
            command.Parameters.AddWithValue("@PatientFullName", entityFilter.FullName.GetLikeParameterValue());
            command.Parameters.AddWithValue("@SourceType", entityFilter.SourceType.GetLikeParameterValue());
            command.Parameters.AddWithValue("@ReferalCode", entityFilter.ReferalId.GetNullableParameterValue());
            command.Parameters.AddWithValue("@BirthDateBeg", entityFilter.BirthDateBegin.GetNullableParameterValue());
            command.Parameters.AddWithValue("@BirthDateEnd", entityFilter.BirthDateEnd.GetNullableParameterValue());
            command.Parameters.AddWithValue("@PhoneNumber", entityFilter.Phone.GetNullableParameterValue());
            command.Parameters.AddWithValue("@Email", entityFilter.Email.GetLikeParameterValue());
            command.Parameters.AddWithValue("@PhysicalAddress", entityFilter.Address.GetLikeParameterValue());
            command.Parameters.AddWithValue("@ContactRelatives", entityFilter.ContactRelatives.GetLikeParameterValue());
            
            return command;
        }

        public override SqlCommand CreateAddCommand(SqlConnection connection, Patient entity)
        {
            var command = new SqlCommand("PatientAdd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@PatientFullName", entity.FullName);
            command.Parameters.AddWithValue("@HospitalID", entity.HospitalId);
            command.Parameters.AddWithValue("@SourceType", entity.SourceType);
            command.Parameters.AddWithValue("@ReferalCode", entity.ReferalId.GetNullableParameterValue());
            command.Parameters.AddWithValue("@BirthDate", entity.BirthDate);
            command.Parameters.AddWithValue("@PhoneNumber", entity.Phone);
            command.Parameters.AddWithValue("@Email", entity.Email.GetNullableParameterValue());
            command.Parameters.AddWithValue("@PhysicalAddress", entity.Address);
            command.Parameters.AddWithValue("@ContactRelatives", entity.ContactRelatives.GetNullableParameterValue());
            
            return command;
        }

        public override SqlCommand CreateUpdateCommand(SqlConnection connection, Patient entity)
        {
            var command = new SqlCommand("PatientUpd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@PatientCode", entity.Id);
            command.Parameters.AddWithValue("@PatientFullName", entity.FullName);
            command.Parameters.AddWithValue("@HospitalID", entity.HospitalId);
            command.Parameters.AddWithValue("@SourceType", entity.SourceType);
            command.Parameters.AddWithValue("@ReferalCode", entity.ReferalId.GetNullableParameterValue());
            command.Parameters.AddWithValue("@BirthDate", entity.BirthDate);
            command.Parameters.AddWithValue("@PhoneNumber", entity.Phone);
            command.Parameters.AddWithValue("@Email", entity.Email.GetNullableParameterValue());
            command.Parameters.AddWithValue("@PhysicalAddress", entity.Address);
            command.Parameters.AddWithValue("@ContactRelatives", entity.ContactRelatives.GetNullableParameterValue());
            
            return command;
        }

        public override SqlCommand CreateDeleteCommand(SqlConnection connection, Patient entity)
        {
            var command = new SqlCommand("PatientDel", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@PatientCode", entity.Id);
            
            return command;
        }

        public override void LoadEntityAttributes(SqlDataReader reader, Patient entity)
        {
            entity.Id = reader.GetValue<int>("PatientCode");
            entity.HospitalId = reader.GetValue<int>("HospitalID");
            entity.FullName = reader.GetString("PatientFullName");
            entity.SourceType = reader.GetString("SourceType");
            entity.ReferalId = reader.GetNullableValue<int>("ReferalCode");
            entity.BirthDate = reader.GetValue<DateTime>("BirthDate");
            entity.Phone = reader.GetString("PhoneNumber");
            entity.Email = reader.GetNullableString("Email");
            entity.Address = reader.GetString("PhysicalAddress");
            entity.ContactRelatives = reader.GetNullableString("ContactRelatives");
       }

        public override void LoadNewEntityAttributes(SqlDataReader reader, Patient entity)
        {
            entity.Id = reader.GetValue<int>("PatientCode");
        }
    }
}
