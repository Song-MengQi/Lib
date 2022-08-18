using System;
using System.Reflection;

namespace Lib
{
    public static class MemberInfoExtend
    {
        public static bool TryGetCustomAttribute<T>(this MemberInfo memberInfo, out T t, bool inherit = true)
            where T : Attribute
        {
            t = memberInfo.GetCustomAttribute<T>(inherit);
            return default(T) != t;
        }
        public static bool IsDefined<T>(this MemberInfo memberInfo, bool inherit = true)
            where T : Attribute
        {
            return memberInfo.IsDefined(typeof(T), inherit);
        }
    }
}