using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;

namespace TD.CTS.MsSqlData.Builders
{
    internal abstract class CommandBuilder<TEntity>
        where TEntity : Entity
    {
        public abstract SqlCommand CreateGetCommand(SqlConnection connection, DataFilter<TEntity> filter);

        public abstract SqlCommand CreateAddCommand(SqlConnection connection, TEntity entity);

        public abstract SqlCommand CreateUpdateCommand(SqlConnection connection, TEntity entity);

        public abstract SqlCommand CreateDeleteCommand(SqlConnection connection, TEntity entity);

        public abstract void LoadEntityAttributes(SqlDataReader reader, TEntity entity);

        public abstract void LoadNewEntityAttributes(SqlDataReader reader, TEntity entity);
    }
}
