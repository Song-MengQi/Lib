using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using Lib;

namespace Test.Lib
{
    [TestClass]
    public class StackExtendTest : TestBase
    {
        [TestMethod]
        public void TestIsEmptyObject()
        {
            Stack stack = new Stack();
            Assert.IsTrue(stack.IsEmpty());
            stack.Push(default(object));
            Assert.IsFalse(stack.IsEmpty());
        }
        [TestMethod]
        public void TestTryPeekObject()
        {
            Stack stack = new Stack();
            object result;
            Assert.IsFalse(stack.TryPeek(out result));
            Assert.AreEqual(result, default(object));
            object value = new object();
            stack.Push(value);
            Assert.IsTrue(stack.TryPeek(out result));
            Assert.AreEqual(result, value);
            Assert.IsFalse(stack.IsEmpty());
        }
        [TestMethod]
        public void TestTryPopObject()
        {
            Stack stack = new Stack();
            object result;
            Assert.IsFalse(stack.TryPop(out result));
            Assert.AreEqual(result, default(object));
            object value = new object();
            stack.Push(value);
            Assert.IsTrue(stack.TryPop(out result));
            Assert.AreEqual(result, value);
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void TestIsEmpty()
        {
            Stack<int> stack = new Stack<int>();
            Assert.IsTrue(stack.IsEmpty());
            stack.Push(1);
            Assert.IsFalse(stack.IsEmpty());
        }
        [TestMethod]
        public void TestTryPeek()
        {
            Stack<string> stack = new Stack<string>();
            string result;
            Assert.IsFalse(stack.TryPeek(out result));
            Assert.AreEqual(result, default(string));
            string value = "123";
            stack.Push(value);
            Assert.IsTrue(stack.TryPeek(out result));
            Assert.AreEqual(result, value);
            Assert.IsFalse(stack.IsEmpty());
        }
        [TestMethod]
        public void TestTryPop()
        {
            Stack<string> stack = new Stack<string>();
            string result;
            Assert.IsFalse(stack.TryPop(out result));
            Assert.AreEqual(result, default(string));
            string value = "123";
            stack.Push(value);
            Assert.IsTrue(stack.TryPop(out result));
            Assert.AreEqual(result, value);
            Assert.IsTrue(stack.IsEmpty());
        }
    }
}
