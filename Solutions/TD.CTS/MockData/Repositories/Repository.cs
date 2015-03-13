using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.CTS.Data;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;

namespace TD.CTS.MockData.Repositories
{
    public abstract class Repository<T> where T : Entity
    {
        protected IDataProvider dataProvider;

        public Repository(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }
        
        private List<T> data;

        public List<T> Data
        {
            get
            {
                if (data == null)
                {
                    data = GenerateData();
                }
                return data;
            }
        }

        public virtual List<T> Where(DataFilter<T> filter)
        {
            return Data.Where(GetFilterFunc(filter)).ToList();
        }

        public virtual T FirstOrDefault(DataFilter<T> filter)
        {
            return Data.FirstOrDefault(GetFilterFunc(filter));
        }

        public virtual void Add(T item)
        {
            SetNewValues(item);
            Data.Add(item);
        }

        public virtual void Update(T item)
        {
            var index = GetItemIndex(item);

            Data[index] = item;
        }

        public virtual void Delete(T item)
        {
            var index = GetItemIndex(item);

            Data.RemoveAt(index);
        }

        public abstract List<T> GenerateData();

        protected abstract Func<T, bool> GetFilterFunc(DataFilter<T> filter);

        protected abstract int GetItemIndex(T item);

        protected abstract void SetNewValues(T item);
    }
}
