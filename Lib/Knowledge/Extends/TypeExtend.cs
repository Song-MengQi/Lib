using System;
using System.Linq;
using System.Reflection;

namespace Lib
{
    public static class TypeExtend
    {
        #region GetMethod
        public static MethodInfo GetMethod(this Type type, string name, BindingFlags bindingAttr, Type[] parameterTypes)
        {
            #region old
            //return type.GetMethods(BindingFlags.Public | BindingFlags.FlattenHierarchy | bindingAttr)//可能有多个重载
            //    .Single(methodInfo => name == methodInfo.Name
            //        && false == methodInfo.IsGenericMethod
            //        && TypeExtends.IsAssignable(methodInfo.GetParameters().Select(parameterInfo => parameterInfo.ParameterType).ToArray(), parameterTypes));
            #endregion
            return type.GetMethods(BindingFlags.Public | BindingFlags.FlattenHierarchy | bindingAttr)//可能有多个重载
                .Single(methodInfo => name == methodInfo.Name
                    && false == methodInfo.IsGenericMethod
                    && methodInfo.GetParameters().Length == parameterTypes.Length);
        }
        public static MethodInfo GetMethod(this Type type, string name, BindingFlags bindingAttr, object[] parameters)
        {
            return type.GetMethod(name, bindingAttr, parameters.Select(parameter => parameter.GetType()).ToArray());
        }

        public static MethodInfo GetGenericMethod(this Type type, string name, BindingFlags bindingAttr, Type[] genericTypes, Type[] parameterTypes)
        {
            #region old
            //return type.GetMethods(BindingFlags.Public | BindingFlags.FlattenHierarchy | bindingAttr)//可能有多个重载
            //    .Single(methodInfo => name == methodInfo.Name
            //        && methodInfo.IsGenericMethod
            //        && TypeExtends.IsAssignable(methodInfo.GetGenericArguments(), genericTypes)
            //        && TypeExtends.IsAssignable(methodInfo.GetParameters().Select(parameterInfo => parameterInfo.ParameterType).ToArray(), parameterTypes))
            //    .MakeGenericMethod(genericTypes);
            #endregion
            return type.GetMethods(BindingFlags.Public | BindingFlags.FlattenHierarchy | bindingAttr)//可能有多个重载
                .Single(methodInfo => name == methodInfo.Name
                    && methodInfo.IsGenericMethod
                    && methodInfo.GetGenericArguments().Length == genericTypes.Length
                    && methodInfo.GetParameters().Length == parameterTypes.Length)
                .MakeGenericMethod(genericTypes);
        }
        public static MethodInfo GetGenericMethod(this Type type, string name, BindingFlags bindingAttr, Type[] genericTypes, params object[] parameters)
        {
            return type.GetGenericMethod(name, bindingAttr, genericTypes, parameters.Select(parameter => parameter.GetType()).ToArray());
        }
        #endregion
        #region InvokeMethod
        private static object InvokeMethod(this Type type, string name, params object[] parameters)
        {
            return type.GetMethod(name, BindingFlags.Static, parameters).Invoke(default(object), parameters);
        }
        public static object InvokeGenericMethod(this Type type, string name, params Type[] genericTypes)
        {
            return type.GetGenericMethod(name, BindingFlags.Static, genericTypes)
                .Invoke(default(object), new object[] { });
        }
        public static object InvokeGenericMethod(this Type type, string name, Type[] genericTypes, params object[] parameters)
        {
            return type.GetGenericMethod(name, BindingFlags.Static, genericTypes, parameters)
                .Invoke(default(object), parameters);
        }
        #endregion
        #region IoC
        public static object GetInstance(this Type type)
        {
            PropertyInfo property = type.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static);
            return ObjectExtends.EqualsDefault(property)
                ? type.InvokeMethod("GetInstance")
                : property.GetValue(default(object));
        }
        public static IT GetInstance<IT>(this Type type)
        {
            return (IT)type.GetInstance();
        }
        public static object GetInstance(this Type type, string key)
        {
            return type.InvokeMethod("GetInstance", key);
        }
        public static IT GetInstance<IT>(this Type type, string key)
        {
            return (IT)type.GetInstance(key);
        }

        public static void SetInstance(this Type type, object value)
        {
            PropertyInfo property = type.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static);
            if (ObjectExtends.EqualsDefault(property)) type.InvokeMethod("SetInstance", value);
            else property.SetValue(default(object), value);
        }
        //public static void SetInstance<IT>(this Type type, IT value)
        //{
        //    type.SetInstance(value);
        //}
        public static void SetInstance(this Type type, string key, object value)
        {
            type.InvokeMethod("SetInstance", key, value);
        }
        //public static void SetInstance<IT>(this Type type, string key, IT value)
        //{
        //    type.GetInstance(key, value);
        //}


        public static void UnsetInstance(this Type type)
        {
            type.InvokeMethod("UnsetInstance");
        }
        public static void UnsetInstance(this Type type, string key)
        {
            #region old
            //type.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)//可能有多个重载
            //    .Where(methodInfo => "UnsetInstance" == methodInfo.Name)
            //    .Foreach(methodInfo => {
            //        ParameterInfo[] parameterInfos = methodInfo.GetParameters();
            //        if (0 == parameterInfos.Length) methodInfo.Invoke(default(object), new object[] { });
            //        else if(1 == parameterInfos.Length) methodInfo.Invoke(default(object), new object[] { key });
            //    });
            #endregion
            type.InvokeMethod("UnsetInstance", key);
        }

        public static bool Exist(this Type type)
        {
            return (bool)type.InvokeMethod("Exist");
        }
        public static bool Exist(this Type type, string key)
        {
            return (bool)type.InvokeMethod("Exist", key);
        }
        #endregion
    }
}