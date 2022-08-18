using System.Linq;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class ArrayExtendsTest : TestBase
    {
        [TestMethod]
        public void TestCreate()
        {
            int[] ints = ArrayExtends.Create(2);
            Assert.AreEqual(ints.Length, 1);
            Assert.AreEqual(ints.First(), 2);
        }
        [TestMethod]
        public void TestIsNullOrEmpty()
        {
            Assert.IsTrue(ArrayExtends.IsNullOrEmpty(default(int[])));
            Assert.IsTrue(ArrayExtends.IsNullOrEmpty(new int[0]));
            Assert.IsFalse(ArrayExtends.IsNullOrEmpty(new int[] { 1 }));
        }
        [TestMethod]
        public void TestGetSpecialOrder()
        {
            int[] src;
            int[] preKeys;
            int[] result;

            src = new int[] { 1, 2, 3 };
            preKeys = new int[] { 2, 4, 6 };
            result = ArrayExtends.GetSpecialOrder(src, preKeys, i => i);
            Assert.AreEqual(result.Length, src.Length);
            Assert.AreEqual(result[0], 2);
            Assert.AreEqual(result[1], 1);
            Assert.AreEqual(result[2], 3);
        }
        [TestMethod]
        public void TestGetArray()
        {
            int[] intArray = ArrayExtends.GetArray(3, ()=>111);
            Assert.AreEqual(intArray.Length, 3);
            Assert.AreEqual(intArray[0], 111);
            Assert.AreEqual(intArray[1], 111);
            Assert.AreEqual(intArray[2], 111);

            string[] stringArray = ArrayExtends.GetArray(3, i => i.ToString());
            Assert.AreEqual(stringArray.Length, 3);
            Assert.AreEqual(stringArray[0], "0");
            Assert.AreEqual(stringArray[1], "1");
            Assert.AreEqual(stringArray[2], "2");
        }
        [TestMethod]
        public void TestGetCopy()
        {
            int[] array = new int[] { 0, 1, 2, 3, 4, 5 };
            int[] result;

            result = ArrayExtends.GetCopy(array);
            Assert.AreEqual(result.Length, 6);
            Assert.AreEqual(result[0], 0);
            Assert.AreEqual(result[1], 1);
            Assert.AreEqual(result[2], 2);
            Assert.AreEqual(result[3], 3);
            Assert.AreEqual(result[4], 4);
            Assert.AreEqual(result[5], 5);

            result = ArrayExtends.GetCopy(array, 3);
            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual(result[0], 0);
            Assert.AreEqual(result[1], 1);
            Assert.AreEqual(result[2], 2);

            result = ArrayExtends.GetCopy(array, 1, 2);
            Assert.AreEqual(result.Length, 2);
            Assert.AreEqual(result[0], 1);
            Assert.AreEqual(result[1], 2);
        }
        [TestMethod]
        public void TestClear()
        {
            int[] array = new int[] { 0, 1, 2 };
            ArrayExtends.Clear(array);
            Assert.AreEqual(array.Length, 3);
            Assert.AreEqual(array[0], default(int));
            Assert.AreEqual(array[1], default(int));
            Assert.AreEqual(array[2], default(int));
        }
        [TestMethod]
        public void TestSetValue()
        {
            int[] array = new int[] { 0, 0, 0 };

            ArrayExtends.SetValue(array, 1);
            Assert.AreEqual(array[0], 1);
            Assert.AreEqual(array[1], 1);
            Assert.AreEqual(array[2], 1);

            ArrayExtends.SetValue(array, 10, 1, 2);
            Assert.AreEqual(array[0], 1);
            Assert.AreEqual(array[1], 10);
            Assert.AreEqual(array[2], 10);
        }

        [TestMethod]
        public void TestFindAllIndexs()
        {
            int[] array = new int[] { 0, 1, 2 };
            int[] indexs = ArrayExtends.FindAllIndexs(array, item => item > 0);

            Assert.AreEqual(indexs.Length, 2);
            Assert.AreEqual(indexs[0], 1);
            Assert.AreEqual(indexs[1], 2);
        }
    }
}