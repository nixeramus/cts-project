using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TD.CTS.Data.Helpers
{
    public class SerializeHelper
    {
        private static XmlSerializer CreateSerializer(Type type, string root)
        {
            return root == null ? new XmlSerializer(type) : new XmlSerializer(type, new XmlRootAttribute(root));
        }

        public static T Deserialize<T>(XmlReader reader, string root = null)
        {
            XmlSerializer serializer = CreateSerializer(typeof(T), root);
            return (T)serializer.Deserialize(reader);
        }

        public static T Deserialize<T>(string serializeValue, string root = null)
        {
            XmlSerializer serializer = CreateSerializer(typeof(T), root);
            using (StringReader reader = new StringReader(serializeValue))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        public static void Serialize(XmlWriter writer, object value, string root = null)
        {
            XmlSerializer serializer = CreateSerializer(value.GetType(), root);
            serializer.Serialize(writer, value);
        }

        public static Stream Serialize(object value, string root = null)
        {
            var stream = new MemoryStream();

            using (XmlWriter writer = XmlWriter.Create(stream))
            {
                Serialize(writer, value, root);
            }

            stream.Seek(0, SeekOrigin.Begin);

            return stream;
        }
    }
}
