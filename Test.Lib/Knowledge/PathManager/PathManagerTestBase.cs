using Lib;

namespace Test.Lib
{
    public abstract class PathManagerTestBase<T> : NewTestBase<T>
        where T : PathManagerBase<T>, new()
    {
    }
}