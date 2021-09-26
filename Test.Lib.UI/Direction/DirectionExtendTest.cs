using Lib.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib.UI
{
    [TestClass]
    public class DirectionExtendTest
    {
        [TestMethod]
        public void TestToAngle()
        {
            Assert.AreEqual(Direction.Up.ToAngle(), 0d);
            Assert.AreEqual(Direction.RightUp.ToAngle(), 45d);
            Assert.AreEqual(Direction.Right.ToAngle(), 90d);
            Assert.AreEqual(Direction.RightDown.ToAngle(), 135d);
            Assert.AreEqual(Direction.Down.ToAngle(), 180d);
            Assert.AreEqual(Direction.LeftDown.ToAngle(), 225d);
            Assert.AreEqual(Direction.Left.ToAngle(), 270d);
            Assert.AreEqual(Direction.LeftUp.ToAngle(), 315d);
        }
    }
}