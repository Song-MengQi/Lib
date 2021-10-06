using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    public abstract class SerialQueueTestBase<T> : TestBase<T>
        where T : SerialQueueBase
    {
        public virtual void TestIsEmptyAndClear()
        {
            int i = 0;
            Assert.IsTrue(Instance.IsEmpty);
            Instance.Assign(new RunnableAction(() => ++i));
            Assert.IsFalse(Instance.IsEmpty);
            Instance.Clear();
            Assert.IsTrue(Instance.IsEmpty);
            Assert.AreEqual(0, i);//不Run就不会执行
        }
    }
}