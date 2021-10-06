using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Lib
{
    public static class NameValueCollectionExtend
    {
        public static Dictionary<string, string> ToDictionary(this NameValueCollection nvc)
        {
            return nvc.AllKeys.ToDictionary(key=>key, key=>nvc[key]);
        }
        //public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this NameValueCollection nvc)
        //{
        //    TypeConverter keyConverter = TypeDescriptor.GetConverter(typeof(TKey));
        //    TypeConverter valueConverter = TypeDescriptor.GetConverter(typeof(TValue));
        //    return nvc.AllKeys.ToDictionary(
        //        key => (TKey)keyConverter.ConvertFromString(key),
        //        key => (TValue)valueConverter.ConvertFromString(nvc[key]));
        //}
    }
}