using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Lib
{
    public static class AssemblyExtends
    {
        #region 确保依赖树都加载完毕
        //例如：A<-B
        //由于dll加载是动态的，只有当B用到A时，才会把程序集加载到程序域
        //即使存在B显示地引用A，主要没执行到也不加载。
        //通过AppDomain.CurrentDomain.GetAssemblies()只能获取当前已加载的
        private static void Load(Assembly assembly, HashSet<string> loadedAssembliesHashSet, Func<AssemblyName, bool> func = default(Func<AssemblyName, bool>))
        {
            if (ObjectExtends.EqualsDefault(assembly)) return;
            if (loadedAssembliesHashSet.Contains(assembly.FullName)) return;
            loadedAssembliesHashSet.Add(assembly.FullName);
            #region Version1
            //assembly.GetReferencedAssemblies()
            //    .Foreach(assemblyName=>{
            //        if (FuncExtends.Invoke(func, assemblyName)) Load(Assembly.Load(assemblyName), loadedAssembliesHashSet, func);
            //    });
            #endregion
            AssemblyName[] assemblyNames = assembly.GetReferencedAssemblies();
            if (default(Func<AssemblyName, bool>) != func) assemblyNames = assemblyNames.Where(func).ToArray();
            assemblyNames.Foreach(assemblyName=>Load(Assembly.Load(assemblyName), loadedAssembliesHashSet, func));
        }
        public static void Load(Func<AssemblyName, bool> func = default(Func<AssemblyName, bool>))
        {
            Load(Assembly.GetEntryAssembly(), new HashSet<string>(), func);
        }
        #endregion
        #region 只取直接引用
        //public static Assembly[] GetAssembliesByReferencedDirectly(string assemblyFullName)
        //{
        //    return AppDomain.CurrentDomain.GetAssemblies()
        //        .Where(assembly => assembly.GetReferencedAssemblies().Any(ra => ra.FullName == assemblyFullName))
        //        .ToArray();
        //}
        #endregion
        #region 也包括间接引用
        #region 这样有Bug，因为加载到程序域的时机
        //若一开始就加载全部所需dll，则此后不会有变化
        //public static Assembly[] Assemblies = AppDomain.CurrentDomain.GetAssemblies();
        #endregion
        private static readonly Lockton<Assembly[]> assembliesLockton = new Lockton<Assembly[]>();
        public static Assembly[] Assemblies//确保调用过Load之后再用它
        {
            get
            {
                return assembliesLockton.GetInstance(()=>AppDomain.CurrentDomain.GetAssemblies());
            }
        }
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
