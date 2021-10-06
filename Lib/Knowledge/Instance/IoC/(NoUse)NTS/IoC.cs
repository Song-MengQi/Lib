//using System;

//namespace Lib
//{
//    public class IoC<IT>
//    {
//        public static IT Instance { get; set; }
//        public static void UnsetInstance() { Instance = default(IT); }
//        public static IT GetInstance(Func<IT> func)
//        {
//            return ObjectExtends.DefaultThen(Instance, ()=>Instance=func());
//        }
//        public static void SetInstance<T>()
//            where T : IT, new()
//        {
//            Instance = new T();
//        }
//        public static IT GetInstance<T>()
//            where T : IT, new()
//        {
//            return GetInstance(() => new T());
//        }
//    }
//}