using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.CTS.Data;
using TD.CTS.Data.Entities;

namespace TD.CTS.MockData.ValueCreators
{
    public abstract class BaseCreator<T>  where T : Entity, new()
    {
        protected IDataProvider dataProvider;

        public BaseCreator(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        public static T Create(Dictionary<string, object> values)
        {
            var type = typeof(T);

            var properties = type.GetProperties();

            var instance = new T();

            foreach (var property in properties)
            {
                if (values.ContainsKey(property.Name))
                {
                    property.SetValue(instance, values[property.Name]);
                }
            }

            return instance;
        }

        public abstract object Create(object key);

        public abstract List<T> CreateList(int count = 10);
    }
}
