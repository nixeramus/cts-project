using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TD.CTS.Data;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;
using TD.CTS.MockData.Repositories;

namespace TD.CTS.MockData
{
    public class MockDataProvider : IDataProvider
    {
        private static Dictionary<Type, object> repositories;

        private static void AddRepositories(IDataProvider dataProvider)
        {
            var baseType = typeof(Repository<>);
            var repositoryTypes = Assembly.GetAssembly(baseType).GetTypes()
                .Where(t => t.BaseType.IsGenericType && t.BaseType.GetGenericTypeDefinition() == baseType)
                .Select(t => new { EntityType = t.BaseType.GenericTypeArguments[0], RepositoryType = t })
                .ToList();

            foreach (var repositoryType in repositoryTypes)
            {
                repositories.Add(repositoryType.EntityType, Activator.CreateInstance(repositoryType.RepositoryType, new object[] { dataProvider }));
            }
        }

        private IDataProvider dataProvider;

        public MockDataProvider(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
            if (repositories == null)
            {
                repositories = new Dictionary<Type, object>();
                AddRepositories(this);
            }
        }

        private static Repository<T> GetRepository<T>() where T : Entity
        {
            var type = typeof(T);
            if (repositories.ContainsKey(type))
            {
                return (Repository<T>)repositories[type];
            }

            return null;
        }

        public List<TEntity> GetList<TEntity>(DataFilter<TEntity> filter) where TEntity : Entity, new()
        {
            var repository = GetRepository<TEntity>();
            if (repository != null)
                return repository.Where(filter);

            return dataProvider.GetList(filter);
        }

        public TEntity GetItem<TEntity>(DataFilter<TEntity> filter) where TEntity : Entity, new()
        {
            var repository = GetRepository<TEntity>();
            if (repository != null)
                return repository.FirstOrDefault(filter);

            return dataProvider.GetItem(filter);
        }

        public void Add<TEntity>(TEntity entity) where TEntity : Entity
        {
            var repository = GetRepository<TEntity>();
            if (repository != null)
                repository.Add(entity);
            else
                dataProvider.Add(entity);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : Entity
        {
            var repository = GetRepository<TEntity>();
            if (repository != null)
                repository.Update(entity);
            else
                dataProvider.Update(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : Entity
        {
            var repository = GetRepository<TEntity>();
            if (repository != null)
                repository.Delete(entity);
            else
                dataProvider.Delete(entity);
        }
    }
}
