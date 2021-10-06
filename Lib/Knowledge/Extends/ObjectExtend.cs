using System;
using System.Reflection;

namespace Lib
{
    public static class ObjectExtend
    {
        public static object InvokeMethod(this object obj, string name, params object[] parameters)
        {
            return obj.GetType().GetMethod(name, BindingFlags.Instance, parameters).Invoke(obj, parameters);
        }
        public static object InvokeGenericMethod(this object obj, string name, params Type[] genericTypes)
        {
            return obj.GetType().GetGenericMethod(name, BindingFlags.Instance, genericTypes)
                .Invoke(obj, new object[] { });
        }
        public static object InvokeGenericMethod(this object obj, string name, Type[] genericTypes, params object[] parameters)
        {
            return obj.GetType().GetGenericMethod(name, BindingFlags.Instance, genericTypes, parameters)
                .Invoke(obj, parameters);
        }
    }
}