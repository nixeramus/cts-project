using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.Common.Data.Attributes;
using TD.Common.Data.Entities;

namespace TD.Common.Data
{
    public static class EnumExtensions
    {
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }

        public static string GetDescription(this Enum enumVal)
        {
            var attribute = enumVal.GetAttributeOfType<EnumDescriptionAttribute>();

            return attribute == null ? enumVal.ToString() : attribute.Description;
        }

        public static IEnumerable<KeyValue<int, string>> GetDictionary(Type enumType)
        {
            if (!enumType.IsEnum)
                throw new NotSupportedException("Type not supported");

            return Enum.GetValues(enumType).OfType<Enum>()
                .Select(e => new KeyValue<int, string> { Key = (int)(object)e, Value = e.GetDescription() });
        }

        public static T GetByDescription<T>(string description)
        {
            if (!typeof(T).IsEnum)
                throw new NotSupportedException("Type not supported");

            foreach (var value in Enum.GetValues(typeof(T)).OfType<Enum>())
                if (value.GetDescription().Equals(description))
                    return (T)(object)value;

            return default(T);
        }
    }
}
