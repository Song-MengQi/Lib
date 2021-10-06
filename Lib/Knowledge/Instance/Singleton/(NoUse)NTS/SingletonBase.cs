//namespace Lib
//{
//    public abstract class SingletonBase<T, IT>
//        where T : IT, new()
//    {
//        private static IT instance = default(T);
//        public static IT Instance
//        {
//            get { return ObjectExtends.DefaultThen(instance, ()=>instance = new T()); }
//            set { instance = value; }
//        }
//        public static void UnsetInstance() { instance = default(T); }
//    }
//    public abstract class SingletonBase<T>
//        where T : new()
//    {
//        private static T instance = default(T);
//        public static T Instance
//        {
//            get { return ObjectExtends.DefaultThen(instance, ()=>instance = new T()); }
//            set { instance = value; }
//        }
//        public static void UnsetInstance() { instance = default(T); }
//    }
//}