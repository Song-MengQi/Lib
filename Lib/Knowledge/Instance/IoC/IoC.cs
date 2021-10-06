using System;

namespace Lib
{
    /// <summary>
    /// 泛型IT的专属IoC
    /// 针对同一IT，不存在特殊的key
    /// 针对不同IT，每个IoC<IT>都有自己的线程安全
    /// </summary>
    /// <typeparam name="IT">IoC的泛型</typeparam>
    public class IoC<IT>
    {
        private static readonly ILockable lockable = new Lockable();
        private static IT instance = default(IT);
        public static void SetInstance(Func<IT> func)
        {
            lockable.Invoke(() => instance = func());
        }
        public static IT GetInstance(Func<IT> func)
        {
            return ObjectExtends.DefaultThen(instance, () => lockable.Invoke(() => ObjectExtends.DefaultThen(instance, () => instance = func())));
        }
        public static IT Instance
        {
            get { return instance; }
            set { SetInstance(() => value); }
        }
        public static void UnsetInstance() { Instance = default(IT); }
        public static void SetInstance<T>()
            where T : IT, new()
        {
            SetInstance(() => new T());
        }
        public static IT GetInstance<T>()
            where T : IT, new()
        {
            return GetInstance(() => new T());
        }
        public static bool Exist { get { return false == ObjectExtends.EqualsDefault(instance); } }
    }
}