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
    internal class CityCommandBuilder : CommandBuilder<City>
    {
        public override SqlCommand CreateGetCommand(SqlConnection connection, DataFilter<City> filter)
        {
            var command = new SqlCommand("CityGet", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            var entityFilter = (CityDataFilter)filter;

            command.Parameters.AddWithValue("@CityID", entityFilter.Id.GetNullableParameterValue());
            command.Parameters.AddWithValue("@CityName", entityFilter.Name.GetLikeParameterValue());
            
            return command;
        }

        public override SqlCommand CreateAddCommand(SqlConnection connection, City entity)
        {
            var command = new SqlCommand("CityAdd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@CityName", entity.Name);
            
            return command;
        }

        public override SqlCommand CreateUpdateCommand(SqlConnection connection, City entity)
        {
            var command = new SqlCommand("CityUpd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@CityID", entity.Id);
            command.Parameters.AddWithValue("@CityName", entity.Name);
            
            return command;
        }

        public override SqlCommand CreateDeleteCommand(SqlConnection connection, City entity)
        {
            var command = new SqlCommand("CityDel", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@CityID", entity.Id);
            
            return command;
        }

        public override void LoadEntityAttributes(SqlDataReader reader, City entity)
        {
            entity.Id = reader.GetValue<int>("CityID");
            entity.Name = reader.GetString("CityName");
       }

        public override void LoadNewEntityAttributes(SqlDataReader reader, City entity)
        {
            entity.Id = reader.GetValue<int>("CityID");
        }
    }
}
