using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace TD.CTS.MockData
{
    public static class SerializeHelper
    {
        public static void Serialize(string fileName, object value)
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(value, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
            }));
        }

        public static T Deserialize<T>(string fileName)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(fileName), new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
            });
        }

        //public static void Serialize(string fileName, object value)
        //{
        //    var serializer = new DataContractSerializer(value.GetType());
        //    using (var stream = new FileStream(fileName, FileMode.OpenOrCreate))
        //        serializer.WriteObject(stream, value);
        //}

        //public static T Deserialize<T>(string fileName)
        //{
        //    var serializer = new DataContractSerializer(typeof(T));
        //    using (var stream = new FileStream(fileName, FileMode.Open))
        //        return (T)serializer.ReadObject(stream);
        //}
    }
}
