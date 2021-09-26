using System;

namespace Lib
{
    public abstract class SingletonBase<T, IT>
        where T : IT, new()
    {
        private static readonly ILockable lockable = new Lockable();
        private static IT instance = default(T);
        public static void SetInstance(Func<IT> func)
        {
            lockable.Invoke(() => instance = func());
        }
        public static IT GetInstance(Func<IT> func)
        {
            return ObjectExtends.DefaultThen(instance, () => lockable.Invoke(() => ObjectExtends.DefaultThen(instance, ()=>instance = func())));
        }
        public static IT Instance
        {
            get { return GetInstance(()=> new T()); }
            set { SetInstance(()=>value); }
        }
        public static void UnsetInstance() { Instance = default(T); }
        public static bool Exist { get { return false == ObjectExtends.EqualsDefault(instance); } }
    }
    public abstract class SingletonBase<T>
        where T : new()
    {
        private static readonly ILockable lockable = new Lockable();
        private static T instance = default(T);
        public static void SetInstance(Func<T> func)
        {
            lockable.Invoke(() => instance = func());
        }
        public static T GetInstance(Func<T> func)
        {
            return ObjectExtends.DefaultThen(instance, () => lockable.Invoke(() => ObjectExtends.DefaultThen(instance, () => instance = func())));
        }
        public static T Instance
        {
            get { return GetInstance(() => new T()); }
            set { SetInstance(() => value); }
        }
        public static void UnsetInstance() { Instance = default(T); }
        public static bool Exist { get { return false == ObjectExtends.EqualsDefault(instance); } }
    }
}