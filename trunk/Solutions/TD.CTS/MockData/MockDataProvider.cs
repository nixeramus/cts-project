using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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

        public static string FileName { get; set; }

        private static void AddRepositories(IDataProvider dataProvider)
        {
            var baseType = typeof(Repository<>);
            var repositoryTypes = Assembly.GetAssembly(baseType).GetTypes()
                .Where(t => t.BaseType.IsGenericType && t.BaseType.GetGenericTypeDefinition() == baseType)
                .Select(t => new { EntityType = t.BaseType.GenericTypeArguments[0], RepositoryType = t })
                .ToList();

            foreach (var repositoryType in repositoryTypes)
            {
                if (!repositories.ContainsKey(repositoryType.EntityType))
                    repositories.Add(repositoryType.EntityType, Activator.CreateInstance(repositoryType.RepositoryType, new object[] { dataProvider }));
                else
                    ((Repository)repositories[repositoryType.EntityType]).dataProvider = dataProvider;
            }
        }

        private IDataProvider dataProvider;

        public MockDataProvider(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
            if (repositories == null)
            {
                if (!string.IsNullOrEmpty(FileName) && File.Exists(FileName))
                {
                    repositories = SerializeHelper.Deserialize<Dictionary<Type, object>>(FileName); 
                }
                else
                {
                    repositories = new Dictionary<Type, object>();
                }

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

            SaveRepositories();
        }

        public void Update<TEntity>(TEntity entity) where TEntity : Entity
        {
            var repository = GetRepository<TEntity>();
            if (repository != null)
                repository.Update(entity);
            else
                dataProvider.Update(entity);

            SaveRepositories();
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : Entity
        {
            var repository = GetRepository<TEntity>();
            if (repository != null)
                repository.Delete(entity);
            else
                dataProvider.Delete(entity);

            SaveRepositories();
        }

        private static void SaveRepositories()
        {
            if (string.IsNullOrEmpty(FileName))
                return;

            SerializeHelper.Serialize(FileName, repositories);
        }


        public void Update(Trial entity)
        {
            dataProvider.Update(entity);
        }

        public void Calc(Schedule schedule)
        {
            dataProvider.Calc(schedule);
        }


        public void Calc(ScheduleVisit scheduleVisit)
        {
            dataProvider.Calc(scheduleVisit);
        }


        public void MargeTrialProcedures(string trialCode, int trialVersion, string[] procedureCodes)
        {
            dataProvider.MargeTrialProcedures(trialCode, trialVersion, procedureCodes);
        }

        public void LoadProcedureDefaultRoles(string trialCode, int trialVersion)
        {
            dataProvider.LoadProcedureDefaultRoles(trialCode, trialVersion);
        }
    }
}
