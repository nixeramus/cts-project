using System.Data.SqlClient;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;

namespace TD.CTS.MsSqlData.Builders
{
    internal class HospitalCommandBuilder : CommandBuilder<Hospital>
    {
        public override SqlCommand CreateGetCommand(SqlConnection connection, DataFilter<Hospital> filter)
        {
            var command = new SqlCommand("HospitalGet", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            var entityFilter = (HospitalDataFilter)filter ?? new HospitalDataFilter();

            command.Parameters.AddWithValue("@HospitalID", entityFilter.Id.GetNullableParameterValue());
            command.Parameters.AddWithValue("@HospitalName", entityFilter.Name.GetLikeParameterValue());
            command.Parameters.AddWithValue("@CityID", entityFilter.CityId.GetNullableParameterValue());

            return command;
        }

        public override SqlCommand CreateAddCommand(SqlConnection connection, Hospital entity)
        {
            var command = new SqlCommand("HospitalAdd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@HospitalName", entity.Name);
            command.Parameters.AddWithValue("@CityID", entity.CityId);

            return command;
        }

        public override SqlCommand CreateUpdateCommand(SqlConnection connection, Hospital entity)
        {
            var command = new SqlCommand("HospitalUpd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@HospitalID", entity.Id);
            command.Parameters.AddWithValue("@HospitalName", entity.Name);
            command.Parameters.AddWithValue("@CityID", entity.CityId);

            return command;
        }

        public override SqlCommand CreateDeleteCommand(SqlConnection connection, Hospital entity)
        {
            var command = new SqlCommand("HospitalDel", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@HospitalID", entity.Id);
            
            return command;
        }

        public override void LoadEntityAttributes(SqlDataReader reader, Hospital entity)
        {
            entity.Id = reader.GetValue<int>("HospitalID");
            entity.Name = reader.GetString("HospitalName");
            entity.CityId = reader.GetValue<int>("CityID");
       }

        public override void LoadNewEntityAttributes(SqlDataReader reader, Hospital entity)
        {
            entity.Id = reader.GetValue<int>("HospitalID");
        }
    }
}
