using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;

namespace Test.Lib
{
    [TestClass]
    public class LockableTest : TestBase
    {
        [TestMethod]
        public void Test()
        {
            ILockable instance = new Lockable();
            int x = 0;
            int row = 10, col = 4;
            Task.WaitAll(ArrayExtends.GetArray(row, i => Task.Run(()=>{
                instance.Invoke(()=>{
                    int y = x;
                    for (int j = 0; j < col; ++j)
                    {
                        x++;
                        Thread.Sleep(10);
                    }
                    Assert.AreEqual(x, y + col);
                });
            })));
            Assert.AreEqual(instance.Invoke(()=>x), row * col);
        }
    }
}