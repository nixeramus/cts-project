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
    internal class ProcedureCommandBuilder : CommandBuilder<Procedure>
    {
        public override SqlCommand CreateGetCommand(SqlConnection connection, DataFilter<Procedure> filter)
        {
            var command = new SqlCommand("ProcedureGet", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            var entityFilter = (ProcedureDataFilter)filter;

            command.Parameters.AddWithValue("@ProcedureCode", entityFilter.Code.GetNullableParameterValue());
            command.Parameters.AddWithValue("@ProcedureName", entityFilter.Name.GetLikeParameterValue());
            
            return command;
        }

        public override SqlCommand CreateAddCommand(SqlConnection connection, Procedure entity)
        {
            var command = new SqlCommand("ProcedureAdd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@ProcedureCode", entity.Code);
            command.Parameters.AddWithValue("@ProcedureName", entity.Name);
            
            return command;
        }

        public override SqlCommand CreateUpdateCommand(SqlConnection connection, Procedure entity)
        {
            var command = new SqlCommand("ProcedureUpd", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@ProcedureCode", entity.Code);
            command.Parameters.AddWithValue("@ProcedureName", entity.Name);
            
            return command;
        }

        public override SqlCommand CreateDeleteCommand(SqlConnection connection, Procedure entity)
        {
            var command = new SqlCommand("ProcedureDel", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };

            command.Parameters.AddWithValue("@ProcedureCode", entity.Code);
            
            return command;
        }

        public override void LoadEntityAttributes(SqlDataReader reader, Procedure entity)
        {
            entity.Code = reader.GetString("ProcedureCode").Trim();
            entity.Name = reader.GetString("ProcedureName");
       }

        public override void LoadNewEntityAttributes(SqlDataReader reader, Procedure entity)
        {}
    }
}
