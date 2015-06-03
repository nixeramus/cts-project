using TD.CTS.Data.Entities;
using System.Collections.Generic;
using TD.CTS.Data.Filters;

namespace TD.CTS.Data
{
    public interface IDataProvider
    {
        List<TEntity> GetList<TEntity>(DataFilter<TEntity> filter)
            where TEntity : Entity, new();
            //where TFilter : DataFilter<TEntity>;

        TEntity GetItem<TEntity>(DataFilter<TEntity> filter)
            where TEntity : Entity, new();
            
        void Add<TEntity>(TEntity entity) where TEntity : Entity;

        void Update<TEntity>(TEntity entity) where TEntity : Entity;

        void Delete<TEntity>(TEntity entity) where TEntity : Entity;

        void Update(Trial entity);

        void Calc(Schedule schedule);
    }
}
