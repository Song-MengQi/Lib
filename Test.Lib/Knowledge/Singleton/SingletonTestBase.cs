using Lib;

namespace Test.Lib
{
    public abstract class SingletonTestBase<T> : TestBase<T>
        where T : SingletonBase<T>, new()
    {
        protected override T CreateInstance() { return SingletonBase<T>.Instance; }
    }
    public abstract class SingletonTestBase<T, IT> : TestBase<T, IT>
        where T : SingletonBase<T, IT>, IT, new()
    {
        protected override IT CreateInstance() { return SingletonBase<T, IT>.Instance; }
    }
}