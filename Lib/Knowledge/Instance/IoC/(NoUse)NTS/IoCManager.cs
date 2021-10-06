//using System;
//using System.Collections;
//using System.Collections.Specialized;

//namespace Lib
//{
//    public class IoCManager<IT>
//    {
//        private static readonly IDictionary instanceDic = new HybridDictionary();
//        private static void SetInstanceDirectly(string key, IT instance)
//        {
//            if (ObjectExtends.EqualsDefault(instance)) UnsetInstanceDirectly(key);
//            else instanceDic[key] = instance;
//        }
//        private static void UnsetInstanceDirectly(string key)
//        {
//            instanceDic.Remove(key);
//        }

//        public static void SetInstance(string key, IT instance)
//        {
//            if (default(string) == key) IoC<IT>.Instance = instance;
//            else SetInstanceDirectly(key, instance);
//        }
//        public static void UnsetInstance(string key)
//        {
//            if (default(string) == key) IoC<IT>.UnsetInstance();
//            else UnsetInstanceDirectly(key);
//        }
//        public static IT GetInstance(string key)
//        {
//            if (default(string) == key) return IoC<IT>.Instance;
//            return instanceDic.Contains(key) ? (IT)instanceDic[key] : default(IT);
//        }
//        public static IT GetInstance(string key, Func<IT> func)
//        {
//            if (default(string) == key) return IoC<IT>.GetInstance(func);
//            if (instanceDic.Contains(key)) return (IT)instanceDic[key];
//            IT instance = func();
//            SetInstance(key, instance);
//            return instance;
//        }

//        #region SetInstance
//        public static void SetInstance<T>(string key)
//            where T : IT, new()
//        {
//            SetInstance(key, new T());
//        }
//        public static void SetInstance(IT instance)
//        {
//            IoC<IT>.Instance = instance;
//        }
//        public static void SetInstance<T>()
//            where T : IT, new()
//        {
//            IoC<IT>.SetInstance<T>();
//        }
//        #endregion
//        #region UnsetInstance
//        public static void UnsetInstance()
//        {
//            IoC<IT>.UnsetInstance();
//        }
//        #endregion
//        #region GetInstance
//        public static IT GetInstance<T>(string key)
//            where T : IT, new()
//        {
//            return GetInstance(key, () => new T());
//        }
//        public static IT GetInstance(Func<IT> func)
//        {
//            return IoC<IT>.GetInstance(func);
//        }
//        public static IT GetInstance()
//        {
//            return IoC<IT>.Instance;
//        }
//        public static IT GetInstance<T>()
//            where T : IT, new()
//        {
//            return IoC<IT>.GetInstance<T>();
//        }
//        #endregion
//    }
//}