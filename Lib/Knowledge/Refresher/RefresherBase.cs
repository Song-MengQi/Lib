using System;

namespace Lib
{
    public abstract class RefresherBase<T> : IRefresher<T>
    {
        public Func<T> GetFunc { get; set; }
        protected T t;
        protected RefresherBase(Func<T> getFunc)
        {
            t = default(T);
            GetFunc = getFunc;
        }
        public virtual void Refresh()
        {
            t = GetFunc();
        }
        public virtual T Get()
        {
            return t;
        }
    }
}