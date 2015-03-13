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
    internal class RoleCommandBuilder : CommandBuilder<Role>
    {
        public override SqlCommand CreateGetCommand(SqlConnection connection, DataFilter<Role> filter)
        {
            var command = new SqlCommand("SystemRoleGet", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandTimeout = Settings.CommandTimeout
            };
            
            return command;
        }

        public override SqlCommand CreateAddCommand(SqlConnection connection, Role entity)
        {
            throw new NotImplementedException();
        }

        public override SqlCommand CreateUpdateCommand(SqlConnection connection, Role entity)
        {
            throw new NotImplementedException();
        }

        public override SqlCommand CreateDeleteCommand(SqlConnection connection, Role entity)
        {
            throw new NotImplementedException();
        }

        public override void LoadEntityAttributes(SqlDataReader reader, Role entity)
        {
            entity.Code = reader.GetString("SystemRoleCode");
            entity.Name = reader.GetString("SystemRoleName");
       }

        public override void LoadNewEntityAttributes(SqlDataReader reader, Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
