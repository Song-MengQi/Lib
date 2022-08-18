using Lib.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib.UI
{
    [TestClass]
    public class DirectionExtendsTest
    {
        [TestMethod]
        public void TestDirectionToAngle()
        {
            Assert.AreEqual(DirectionExtends.ToAngle(Direction.Up), 0d);
            Assert.AreEqual(DirectionExtends.ToAngle(Direction.RightUp), 45d);
            Assert.AreEqual(DirectionExtends.ToAngle(Direction.Right), 90d);
            Assert.AreEqual(DirectionExtends.ToAngle(Direction.RightDown), 135d);
            Assert.AreEqual(DirectionExtends.ToAngle(Direction.Down), 180d);
            Assert.AreEqual(DirectionExtends.ToAngle(Direction.LeftDown), 225d);
            Assert.AreEqual(DirectionExtends.ToAngle(Direction.Left), 270d);
            Assert.AreEqual(DirectionExtends.ToAngle(Direction.LeftUp), 315d);
        }
        [TestMethod]
        public void TestAngleToDirection()
        {
            Assert.AreEqual(DirectionExtends.ToDirection(350d), Direction.Up);
            Assert.AreEqual(DirectionExtends.ToDirection(0d), Direction.Up);
            Assert.AreEqual(DirectionExtends.ToDirection(10d), Direction.Up);
            Assert.AreEqual(DirectionExtends.ToDirection(35d), Direction.RightUp);
            Assert.AreEqual(DirectionExtends.ToDirection(45d), Direction.RightUp);
            Assert.AreEqual(DirectionExtends.ToDirection(55d), Direction.RightUp);
            Assert.AreEqual(DirectionExtends.ToDirection(80d), Direction.Right);
            Assert.AreEqual(DirectionExtends.ToDirection(90d), Direction.Right);
            Assert.AreEqual(DirectionExtends.ToDirection(100d), Direction.Right);
            Assert.AreEqual(DirectionExtends.ToDirection(125d), Direction.RightDown);
            Assert.AreEqual(DirectionExtends.ToDirection(135d), Direction.RightDown);
            Assert.AreEqual(DirectionExtends.ToDirection(145d), Direction.RightDown);
            Assert.AreEqual(DirectionExtends.ToDirection(170d), Direction.Down);
            Assert.AreEqual(DirectionExtends.ToDirection(180d), Direction.Down);
            Assert.AreEqual(DirectionExtends.ToDirection(190d), Direction.Down);
            Assert.AreEqual(DirectionExtends.ToDirection(215d), Direction.LeftDown);
            Assert.AreEqual(DirectionExtends.ToDirection(225d), Direction.LeftDown);
            Assert.AreEqual(DirectionExtends.ToDirection(235d), Direction.LeftDown);
            Assert.AreEqual(DirectionExtends.ToDirection(260d), Direction.Left);
            Assert.AreEqual(DirectionExtends.ToDirection(270d), Direction.Left);
            Assert.AreEqual(DirectionExtends.ToDirection(280d), Direction.Left);
            Assert.AreEqual(DirectionExtends.ToDirection(305d), Direction.LeftUp);
            Assert.AreEqual(DirectionExtends.ToDirection(315d), Direction.LeftUp);
            Assert.AreEqual(DirectionExtends.ToDirection(325d), Direction.LeftUp);
        }
    }
}