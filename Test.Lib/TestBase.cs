using Lib;
using System;

namespace Test.Lib
{
    public abstract class TestBase
    {
        protected TestBase()
        {
            //可能会有一些公共的配置
        }
        public static void DeleteData()
        {
            DirectoryExtends.EnsureNotExist("Data");
        }
    }
    public abstract class TestBase<T> : TestBase
    {
        private readonly Lazy<T> lazy;
        protected T Instance { get { return lazy.Value; } }
        protected TestBase() : base()
        {
            lazy = new Lazy<T>(CreateInstance);
        }
        protected abstract T CreateInstance();
    }
    public abstract class TestBase<T, IT> : TestBase<IT>
        where T : IT
    {
    }

    public abstract class NewTestBase<T> : TestBase<T>
        where T : new()
    {
        protected override T CreateInstance() { return new T(); }
    }
    public abstract class NewTestBase<T, IT> : TestBase<T, IT>
        where T : IT, new()
    {
        protected override IT CreateInstance() { return new T(); }
    }
}