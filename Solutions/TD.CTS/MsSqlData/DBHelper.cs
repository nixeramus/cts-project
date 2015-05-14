using System;
using System.Data.SqlClient;

namespace TD.CTS.MsSqlData
{
    public static class DBHelper
    {
        public static string GetString(this SqlDataReader reader, string name)
        {
            return (string)reader[name];
        }

        public static string GetNullableString(this SqlDataReader reader, string name)
        {
            object value = reader[name];
            return value == DBNull.Value ? null : (string)value;
        }

        public static T GetValue<T>(this SqlDataReader reader, string name) where T : struct
        {
            return (T)reader[name];
        }

        public static T? GetNullableValue<T>(this SqlDataReader reader, string name) where T : struct
        {
            object value = reader[name];
            return value == DBNull.Value ? null : (T?)value;
        }

        public static object GetNullableParameterValue(this object value)
        {
            return value ?? DBNull.Value;
        }

        public static object GetLikeParameterValue(this string value, LikeType type = LikeType.Contains)
        {
            if (value == null)
                return DBNull.Value;

            switch(type)
            {
                case LikeType.Contains:
                    return "%" + value + "%";
                case LikeType.Starts:
                    return value + "%";
                case LikeType.Ends:
                    return "%" + value;
                case LikeType.Equal:
                    return value;
            }

            return value;
        }

    }

    public enum LikeType
    {
        Contains,
        Starts, 
        Ends,
        Equal
    }
}
