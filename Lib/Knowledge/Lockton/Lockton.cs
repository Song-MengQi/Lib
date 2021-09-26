using System;

namespace Lib
{
    //锁例
    public class Lockton<IT>
    {
        private readonly ILockable lockable = new Lockable();
        private IT instance = default(IT);
        public void SetInstance(Func<IT> func)
        {
            lockable.Invoke(() => instance = func());
        }
        public IT GetInstance(Func<IT> func)
        {
            return ObjectExtends.DefaultThen(instance, () => lockable.Invoke(() => ObjectExtends.DefaultThen(instance, () => instance = func())));
        }
        public IT Instance
        {
            get { return instance; }
            set { SetInstance(() => value); }
        }
        public void UnsetInstance() { Instance = default(IT); }
        public void SetInstance<T>()
            where T : IT, new()
        {
            SetInstance(() => new T());
        }
        public IT GetInstance<T>()
            where T : IT, new()
        {
            return GetInstance(() => new T());
        }
        public bool Exist { get { return false == ObjectExtends.EqualsDefault(instance); } }
    }
}