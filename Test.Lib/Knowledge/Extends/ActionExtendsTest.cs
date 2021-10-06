using System;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class ActionExtendsTest : TestBase
    {
        [TestMethod]
        public void TestInvoke()
        {
            int x = 0;
            ActionExtends.Invoke(() => ++x);
            Assert.AreEqual(x, 1);

            int y = 100;
            Action<int> action = i => x=i;
            ActionExtends.Invoke(action, y);
            Assert.AreEqual(x, y);

            ActionExtends.Invoke(default(Action));

            ActionExtends.Invoke(null, 1);
            ActionExtends.Invoke(null, 1, 2);
            ActionExtends.Invoke(null, 1, 2, 3);
            ActionExtends.Invoke(null, 1, 2, 3, 4);
            ActionExtends.Invoke(null, 1, 2, 3, 4, 5);
            ActionExtends.Invoke(null, 1, 2, 3, 4, 5, 6);
            ActionExtends.Invoke(null, 1, 2, 3, 4, 5, 6, 7);
            ActionExtends.Invoke(null, 1, 2, 3, 4, 5, 6, 7, 8);
            ActionExtends.Invoke(null, 1, 2, 3, 4, 5, 6, 7, 8, 9);
            ActionExtends.Invoke(null, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            ActionExtends.Invoke(null, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);
            ActionExtends.Invoke(null, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
            ActionExtends.Invoke(null, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
            ActionExtends.Invoke(null, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);
            ActionExtends.Invoke(null, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);

            ActionExtends.Invoke((t1)=>{ }, 1);
            ActionExtends.Invoke((t1, t2)=>{ }, 1, 2);
            ActionExtends.Invoke((t1, t2, t3)=>{ }, 1, 2, 3);
            ActionExtends.Invoke((t1, t2, t3, t4)=>{ }, 1, 2, 3, 4);
            ActionExtends.Invoke((t1, t2, t3, t4, t5)=>{ }, 1, 2, 3, 4, 5);
            ActionExtends.Invoke((t1, t2, t3, t4, t5, t6)=>{ }, 1, 2, 3, 4, 5, 6);
            ActionExtends.Invoke((t1, t2, t3, t4, t5, t6, t7)=>{ }, 1, 2, 3, 4, 5, 6, 7);
            ActionExtends.Invoke((t1, t2, t3, t4, t5, t6, t7, t8)=>{ }, 1, 2, 3, 4, 5, 6, 7, 8);
            ActionExtends.Invoke((t1, t2, t3, t4, t5, t6, t7, t8, t9)=>{ }, 1, 2, 3, 4, 5, 6, 7, 8, 9);
            ActionExtends.Invoke((t1, t2, t3, t4, t5, t6, t7, t8, t9, t10)=>{ }, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            ActionExtends.Invoke((t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11)=>{ }, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);
            ActionExtends.Invoke((t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12)=>{ }, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
            ActionExtends.Invoke((t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13)=>{ }, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
            ActionExtends.Invoke((t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14)=>{ }, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);
            ActionExtends.Invoke((t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15)=>{ }, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
        }
    }
}