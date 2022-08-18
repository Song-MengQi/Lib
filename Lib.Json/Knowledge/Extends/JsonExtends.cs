using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Lib.Json
{
    public class JsonExtends
    {
        private static string Serialize<T>(IEnumerable<T> values)
        {
            //若直接用JsonConvert，则小数至少1位
            return string.Format("[{0}]", string.Join(",", values));
        }
        public static string Serialize(object value)
        {
            if (value is IEnumerable<float>) return Serialize(value as IEnumerable<float>);
            if (value is IEnumerable<double>) return Serialize(value as IEnumerable<double>);
            if (value is IEnumerable<decimal>) return Serialize(value as IEnumerable<decimal>);
            return JsonConvert.SerializeObject(value);
        }
        public static T Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
        public static object Deserialize(string value, Type type)
        {
            return JsonConvert.DeserializeObject(value, type);
        }
        public static T TryDeserialize<T>(string json)
        {
            try { return Deserialize<T>(json); }
            catch { return default(T); }
        }
        public static bool TryDeserialize<T>(string json, out T t)
        {
            t = default(T);
            try { t = Deserialize<T>(json); }
            catch { return false; }
            return true;
        }

        public static T Convert<T>(object value)
        {
            return Deserialize<T>(Serialize(value));
        }
        public static object Convert(object value, Type type)
        {
            return Deserialize(Serialize(value), type);
        }
        public static T TryConvert<T>(object value)
        {
            string json = Serialize(value);
            return TryDeserialize<T>(json);
        }
        public static bool TryConvert<T>(object value, out T t)
        {
            string json = Serialize(value);
            return TryDeserialize<T>(json, out t);
        }
        public static T Clone<T>(T t)
        {
            return Convert<T>(t);
        }
    }
}