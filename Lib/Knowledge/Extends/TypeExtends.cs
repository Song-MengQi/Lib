using System;
using System.Linq;
using System.Reflection;

namespace Lib
{
    public static class TypeExtends
    {
        public static Type[] GetTypes(Assembly[] assemblies) { return assemblies.SelectMany(assembly => assembly.GetTypes()).ToArray(); }
        public static Type FindTypeByName(string name, Type[] types)
        {
            if (name.Contains(",")) return Type.ReflectionOnlyGetType(name, true, false);
            if (name.Contains(".")) return types.Single(type => type.FullName == name);
            return types.Single(type => type.Name == name);
        }
        public static Type FindTypeByNameOrDefault(string name, Type[] types)
        {
            if (name.Contains(",")) return Type.ReflectionOnlyGetType(name, true, false);
            if (name.Contains(".")) return types.SingleOrDefault(type => type.FullName == name);
            return types.SingleOrDefault(type => type.Name == name);
        }

        //原生的IsAssignableFrom没有考虑Generic问题
        public static bool IsAssignable(Type from, Type to)
        {
            Func<Type, bool> isRawAssignableFunc = type => (type.IsGenericType ? type.GetGenericTypeDefinition() : type) == from;
            if (to.GetInterfaces().Any(isRawAssignableFunc)) return true;
            
            while (to != default(Type) && to != typeof(object))
            {
                if (isRawAssignableFunc(to)) return true;
                to = to.BaseType;
            }
            return false;
        }
        public static bool IsAssignable(Type[] froms, Type[] tos)
        {
            return froms.Length == tos.Length && tos.All((to, index) => IsAssignable(froms[index], to));
        }
        public static T ChangeType<T>(object obj)
        {
            return (T)Convert.ChangeType(obj, typeof(T));
        }
    }
}