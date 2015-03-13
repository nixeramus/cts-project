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
    internal class ReferalCommandBuilder : CommandBuilder<Referal>
    {
        public override SqlCommand CreateGetCommand(SqlConnection connection, DataFilter<Referal> filter)
        {
            var command = new SqlCommand("ReferalGet", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            var entityFilter = (ReferalDataFilter)filter;

            command.Parameters.AddWithValue("@ReferalCode", entityFilter.Id.GetNullableParameterValue());
            command.Parameters.AddWithValue("@HospitalID", entityFilter.HospitalId.GetNullableParameterValue());
            command.Parameters.AddWithValue("@CityID", entityFilter.CityId.GetNullableParameterValue());
            command.Parameters.AddWithValue("@ReferalFullName", entityFilter.FullName.GetLikeParameterValue());
            command.Parameters.AddWithValue("@WorkPlace", entityFilter.WorkPlace.GetLikeParameterValue());
            command.Parameters.AddWithValue("@Email", entityFilter.Email.GetLikeParameterValue());
            command.Parameters.AddWithValue("@PhoneNumber", entityFilter.Phone.GetLikeParameterValue());
            
            return command;
        }

        public override SqlCommand CreateAddCommand(SqlConnection connection, Referal entity)
        {
            var command = new SqlCommand("ReferalAdd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@HospitalID", entity.HospitalId);
            command.Parameters.AddWithValue("@CityID", entity.CityId.GetNullableParameterValue());
            command.Parameters.AddWithValue("@ReferalFullName", entity.FullName);
            command.Parameters.AddWithValue("@WorkPlace", entity.WorkPlace);
            command.Parameters.AddWithValue("@Email", entity.Email.GetNullableParameterValue());
            command.Parameters.AddWithValue("@PhoneNumber", entity.Phone.GetNullableParameterValue());
            
            return command;
        }

        public override SqlCommand CreateUpdateCommand(SqlConnection connection, Referal entity)
        {
            var command = new SqlCommand("ReferalUpd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@ReferalCode", entity.Id);
            command.Parameters.AddWithValue("@HospitalID", entity.HospitalId);
            command.Parameters.AddWithValue("@CityID", entity.CityId.GetNullableParameterValue());
            command.Parameters.AddWithValue("@ReferalFullName", entity.FullName);
            command.Parameters.AddWithValue("@WorkPlace", entity.WorkPlace);
            command.Parameters.AddWithValue("@Email", entity.Email.GetNullableParameterValue());
            command.Parameters.AddWithValue("@PhoneNumber", entity.Phone.GetNullableParameterValue());
            
            return command;
        }

        public override SqlCommand CreateDeleteCommand(SqlConnection connection, Referal entity)
        {
            var command = new SqlCommand("ReferalDel", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@ReferalCode", entity.Id);
            
            return command;
        }

        public override void LoadEntityAttributes(SqlDataReader reader, Referal entity)
        {
            entity.Id = reader.GetValue<int>("ReferalCode");
            entity.HospitalId = reader.GetValue<int>("HospitalID");
            entity.FullName = reader.GetString("ReferalFullName");
            entity.CityId = reader.GetNullableValue<int>("CityID");
            entity.WorkPlace = reader.GetString("WorkPlace");
            entity.Email = reader.GetString("Email");
            entity.Phone = reader.GetString("PhoneNumber");
       }

        public override void LoadNewEntityAttributes(SqlDataReader reader, Referal entity)
        {
            entity.Id = reader.GetValue<int>("ReferalCode");
        }
    }
}
