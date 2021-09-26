using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Lib
{
    /// <summary>
    /// 泛型IT的IoCManager
    /// 针对同一IT，存在不同的key，每个key都有自己的线程安全
    /// 如果不指定key，相当于IoC<IT>；特别地，如果key恰好为default，也相当于IoC<IT>
    /// 
    /// ps: 对于同一IT.Key（除default）的操作，会被同一个ILockable套住
    /// </summary>
    /// <typeparam name="IT">IoCManager的泛型</typeparam>
    public class IoCManager<IT>
        where IT : class
    {
        #region KeySerializable
        private static readonly ILockable lockableDicLockable = new Lockable();
        private static readonly IDictionary<string, ILockable> lockableDic = new HybridDictionary<string, ILockable>();
        private static ILockable GetLockable(string key)
        {
            return lockableDicLockable.Invoke(()=>{
                if (false == lockableDic.ContainsKey(key)) lockableDic.Add(key, new Lockable());
                return lockableDic[key];
            });
        }
        #endregion

        #region 基本操作
        public static readonly ConcurrentDictionary<string, IT> InstanceDic = new ConcurrentDictionary<string, IT>();

        private static void SetInstanceDirectly(string key, IT instance)
        {
            if (default(IT) == instance) UnsetInstanceDirectly(key);
            else InstanceDic[key] = instance;
        }
        private static void UnsetInstanceDirectly(string key)
        {
            IT _;
            InstanceDic.TryRemove(key, out _);
        }

        public static void SetInstance(string key, Func<IT> func)
        {
            if (default(string) == key) IoC<IT>.SetInstance(func);
            GetLockable(key).Invoke(() => SetInstanceDirectly(key, func()));
        }
        public static IT GetInstance(string key, Func<IT> func)
        {
            if (default(string) == key) return IoC<IT>.GetInstance(func);
            IT value;
            return InstanceDic.TryGetValue(key, out value)
                ? value
                : GetLockable(key).Invoke(()=>{
                    if (InstanceDic.TryGetValue(key, out value)) return value;
                    IT instance = func();
                    SetInstanceDirectly(key, instance);
                    return instance;
                });
        }
        public static void SetInstance(string key, IT instance)
        {
            SetInstance(key, ()=>instance);
        }
        public static IT GetInstance(string key)
        {
            if (default(string) == key) return IoC<IT>.Instance;
            IT value;
            return InstanceDic.TryGetValue(key, out value) ? value : default(IT);
        }
        public static void UnsetInstance(string key)
        {
            if (default(string) == key) IoC<IT>.UnsetInstance();
            else GetLockable(key).Invoke(() => UnsetInstanceDirectly(key));
        }
        public static bool Exist(string key)
        {
            return default(string) == key
                ? IoC<IT>.Exist
                : InstanceDic.ContainsKey(key);
        }
        public static string GetKey(IT instance)
        {
            return InstanceDic.Where(kv => kv.Value == instance).Select(kv => kv.Key).FirstOrDefault();
        }
        public static void Clear()
        {
            lockableDicLockable.Invoke(lockableDic.Clear);
            InstanceDic.Clear();
        }
        #endregion
        
        #region SetInstance
        public static void SetInstance<T>(string key)
            where T : IT, new()
        {
            SetInstance(key, new T());
        }
        public static void SetInstance(Func<IT> func)
        {
            IoC<IT>.SetInstance(func);
        }
        public static void SetInstance(IT instance)
        {
            IoC<IT>.Instance = instance;
        }
        public static void SetInstance<T>()
            where T : IT, new()
        {
            IoC<IT>.SetInstance<T>();
        }
        #endregion
        #region UnsetInstance
        public static void UnsetInstance()
        {
            IoC<IT>.UnsetInstance();
        }
        #endregion
        #region GetInstance
        public static IT GetInstance<T>(string key)
            where T : IT, new()
        {
            return GetInstance(key, () => new T());
        }
        public static IT GetInstance(Func<IT> func)
        {
            return IoC<IT>.GetInstance(func);
        }
        public static IT GetInstance()
        {
            return IoC<IT>.Instance;
        }
        public static IT GetInstance<T>()
            where T : IT, new()
        {
            return IoC<IT>.GetInstance<T>();
        }
        #endregion
        #region Exist
        public static bool Exist()
        {
            return IoC<IT>.Exist;
        }
        #endregion
    }
}