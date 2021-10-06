using System;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class FuncExtendsTest : TestBase
    {
        [TestMethod]
        public void TestInvoke()
        {
            int x = 1;
            Assert.AreEqual(FuncExtends.Invoke(() => x), x);
            FuncExtends.Invoke(default(Func<int>));

            FuncExtends.Invoke(default(Func<int, string>), 1);
            FuncExtends.Invoke(default(Func<int, int, string>), 1, 2);
            FuncExtends.Invoke(default(Func<int, int, int, string>), 1, 2, 3);
            FuncExtends.Invoke(default(Func<int, int, int, int, string>), 1, 2, 3, 4);
            FuncExtends.Invoke(default(Func<int, int, int, int, int, string>), 1, 2, 3, 4, 5);
            FuncExtends.Invoke(default(Func<int, int, int, int, int, int, string>), 1, 2, 3, 4, 5, 6);
            FuncExtends.Invoke(default(Func<int, int, int, int, int, int, int, string>), 1, 2, 3, 4, 5, 6, 7);
            FuncExtends.Invoke(default(Func<int, int, int, int, int, int, int, int, string>), 1, 2, 3, 4, 5, 6, 7, 8);
            FuncExtends.Invoke(default(Func<int, int, int, int, int, int, int, int, int, string>), 1, 2, 3, 4, 5, 6, 7, 8, 9);
            FuncExtends.Invoke(default(Func<int, int, int, int, int, int, int, int, int, int, string>), 1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            FuncExtends.Invoke(default(Func<int, int, int, int, int, int, int, int, int, int, int, string>), 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);
            FuncExtends.Invoke(default(Func<int, int, int, int, int, int, int, int, int, int, int, int, string>), 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
            FuncExtends.Invoke(default(Func<int, int, int, int, int, int, int, int, int, int, int, int, int, string>), 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
            FuncExtends.Invoke(default(Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, string>), 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);
            FuncExtends.Invoke(default(Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string>), 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);

            FuncExtends.Invoke((t1)=>0, 1);
            FuncExtends.Invoke((t1, t2)=>0, 1, 2);
            FuncExtends.Invoke((t1, t2, t3)=>0, 1, 2, 3);
            FuncExtends.Invoke((t1, t2, t3, t4)=>0, 1, 2, 3, 4);
            FuncExtends.Invoke((t1, t2, t3, t4, t5)=>0, 1, 2, 3, 4, 5);
            FuncExtends.Invoke((t1, t2, t3, t4, t5, t6)=>0, 1, 2, 3, 4, 5, 6);
            FuncExtends.Invoke((t1, t2, t3, t4, t5, t6, t7)=>0, 1, 2, 3, 4, 5, 6, 7);
            FuncExtends.Invoke((t1, t2, t3, t4, t5, t6, t7, t8)=>0, 1, 2, 3, 4, 5, 6, 7, 8);
            FuncExtends.Invoke((t1, t2, t3, t4, t5, t6, t7, t8, t9)=>0, 1, 2, 3, 4, 5, 6, 7, 8, 9);
            FuncExtends.Invoke((t1, t2, t3, t4, t5, t6, t7, t8, t9, t10)=>0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            FuncExtends.Invoke((t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11)=>0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);
            FuncExtends.Invoke((t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12)=>0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
            FuncExtends.Invoke((t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13)=>0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
            FuncExtends.Invoke((t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14)=>0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);
            FuncExtends.Invoke((t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15)=>0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
        }
    }
}
