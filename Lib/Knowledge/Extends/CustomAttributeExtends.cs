using System;
using System.Reflection;

namespace Lib
{
    public static class AttributeExtends
    {
        public static bool IsDefined<T>(this MemberInfo memberInfo, bool inherit = true)
            where T : Attribute
        {
            return memberInfo.IsDefined(typeof(T), inherit);
        }
        //public static bool TryGetCustomAttribute<T>(this MemberInfo type, out T t)
        //    where T : Attribute
        //{
        //    t = type.GetCustomAttribute<T>();
        //    return default(T) != t;
        //}
    }
}