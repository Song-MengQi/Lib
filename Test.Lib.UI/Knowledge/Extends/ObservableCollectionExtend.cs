using Lib.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Test.Lib.UI
{
    [TestClass]
    public class ObservableCollectionExtendTest
    {
        [TestMethod]
        public void TestSort()
        {
            ObservableCollection<int> ocs = new ObservableCollection<int>(new int[] { 2, 1, 3 });
            Action assertAction = ()=>{
                Assert.AreEqual(ocs[0], 1);
                Assert.AreEqual(ocs[1], 2);
                Assert.AreEqual(ocs[2], 3);

            };
            Action assertDescAction = ()=>{
                Assert.AreEqual(ocs[0], 3);
                Assert.AreEqual(ocs[1], 2);
                Assert.AreEqual(ocs[2], 1);
            };

            ocs.Sort(false);
            assertAction();
            ocs.Sort(Comparer<int>.Default, true);
            assertDescAction();
            ocs.SortBy(i=>i, false);
            assertAction();
            ocs.SortBy(i=>i, Comparer<int>.Default, true);
            assertDescAction();
        }
    }
}