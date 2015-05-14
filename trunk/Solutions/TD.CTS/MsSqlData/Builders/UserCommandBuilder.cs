using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;
using TD.CTS.Data.Helpers;

namespace TD.CTS.MsSqlData.Builders
{
    internal class UserCommandBuilder : CommandBuilder<User>
    {
        public override SqlCommand CreateGetCommand(SqlConnection connection, DataFilter<User> filter)
        {
            var command = new SqlCommand("UserGet", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            var entityFilter = (UserDataFilter)filter ?? new UserDataFilter();

            command.Parameters.AddWithValue("@SystemLogin", entityFilter.Login.GetNullableParameterValue());
            command.Parameters.AddWithValue("@HospitalID", entityFilter.HospitalId.GetNullableParameterValue());
            command.Parameters.AddWithValue("@SystemRoleCode", entityFilter.RoleId.GetNullableParameterValue());
            command.Parameters.AddWithValue("@UserFullName", entityFilter.FullName.GetLikeParameterValue());
            command.Parameters.AddWithValue("@EMail", entityFilter.Email.GetLikeParameterValue());
            command.Parameters.AddWithValue("@PhoneNumber", entityFilter.Phone.GetLikeParameterValue());
            
            return command;
        }

        public override SqlCommand CreateAddCommand(SqlConnection connection, User entity)
        {
            var command = new SqlCommand("UserAdd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@SystemLogin", entity.Login);
            command.Parameters.AddWithValue("@Passwd", entity.Password);
            command.Parameters.AddWithValue("@HospitalID", entity.HospitalId);
            command.Parameters.AddWithValue("@UserFullName", entity.FullName);
            command.Parameters.AddWithValue("@EMail", entity.Email);
            command.Parameters.AddWithValue("@PhoneNumber", entity.Phone.GetNullableParameterValue());

            var stream = SerializeHelper.Serialize(entity.Roles, "Roles");
            
            command.Parameters.AddWithValue("@Roles", new SqlXml(stream));

            return command;
        }

        public override SqlCommand CreateUpdateCommand(SqlConnection connection, User entity)
        {
            var command = new SqlCommand("UserUpd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@SystemLogin", entity.Login);
            command.Parameters.AddWithValue("@HospitalID", entity.HospitalId);
            command.Parameters.AddWithValue("@UserFullName", entity.FullName);
            command.Parameters.AddWithValue("@EMail", entity.Email);
            command.Parameters.AddWithValue("@PhoneNumber", entity.Phone.GetNullableParameterValue());

            var stream = SerializeHelper.Serialize(entity.Roles, "Roles");

            command.Parameters.AddWithValue("@Roles", new SqlXml(stream));

            return command;
        }

        public override SqlCommand CreateDeleteCommand(SqlConnection connection, User entity)
        {
            var command = new SqlCommand("UserDel", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@SystemLogin", entity.Login);
            
            return command;
        }

        public override void LoadEntityAttributes(SqlDataReader reader, User entity)
        {
            entity.FullName = reader.GetString("UserFullName");
            entity.Login = reader.GetString("SystemLogin");
            entity.HospitalId = reader.GetValue<int>("HospitalID");
            entity.Email = reader.GetString("EMail");
            entity.Phone = reader.GetNullableString("PhoneNumber");
            entity.Roles = SerializeHelper.Deserialize<List<Role>>(reader.GetString("Roles"), "Roles");
            entity.NeedChangePassword = reader.GetValue<bool>("NeedChangePassword");
       }

        public override void LoadNewEntityAttributes(SqlDataReader reader, User entity)
        {            
        }
    }
}
