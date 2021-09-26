using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Lib
{
    public static class AssemblyExtends
    {
        #region 只取直接引用
        //public static Assembly[] GetAssembliesByReferencedDirectly(string assemblyFullName)
        //{
        //    return AppDomain.CurrentDomain.GetAssemblies()
        //        .Where(assembly => assembly.GetReferencedAssemblies().Any(ra => ra.FullName == assemblyFullName))
        //        .ToArray();
        //}
        #endregion
        #region 也包括间接引用
        //若一开始就加载全部所需dll，则此后不会有变化
        public static Assembly[] Assemblies = AppDomain.CurrentDomain.GetAssemblies();
        public static Assembly[] GetAssembliesByReferencedDirectly(string assemblyFullName)
        {
            Assembly[] directAssemblies = Assemblies
                .Where(assembly => assembly.GetReferencedAssemblies().Any(ra => ra.FullName == assemblyFullName))
                .ToArray();
            #region 子树不缓存
            //return directAssemblies
            //    .Concat(directAssemblies.SelectMany(directAssembly => GetAssembliesByReferencedDirectly(directAssembly.FullName)))
            //    .Distinct()
            //    .ToArray();
            #endregion
            #region 子树也缓存
            return directAssemblies
                .Concat(directAssemblies.SelectMany(directAssembly => GetAssembliesByReferenced(directAssembly.FullName)))
                .Distinct()
                .ToArray();
            #endregion
        }
                
        #region 在不动态加载卸载程序集的情况下可以加缓存
        private static readonly Dictionary<string, Assembly[]> assembliesByReferencedDic = new Dictionary<string, Assembly[]>();
        public static Assembly[] GetAssembliesByReferenced(string assemblyFullName)
        {
            return assembliesByReferencedDic.ContainsKey(assemblyFullName)
                ? assembliesByReferencedDic[assemblyFullName]
                : (assembliesByReferencedDic[assemblyFullName] = GetAssembliesByReferencedDirectly(assemblyFullName));
        }
        #endregion
        #endregion

        public static Assembly[] GetAssembliesByReferenced(Assembly assembly) { return GetAssembliesByReferenced(assembly.FullName); }
        //public static Assembly[] GetAssembliesByReferenced(Type type) { return GetAssembliesByReferenced(type.Assembly); }
    }
}
