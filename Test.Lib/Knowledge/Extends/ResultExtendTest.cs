using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class ResultExtendTest : TestBase
    {
        [TestMethod]
        public void TestGetDataOrDefault()
        {
            Assert.AreEqual(new Result<int> {
                Data = 1
            }.GetDataOrDefault(), 1);
            Assert.AreEqual(new Result<int>(ResultState.Fail).GetDataOrDefault(), default(int));
            Assert.AreEqual(new Result<int>(ResultState.Fail).GetDataOrDefault(1), 1);

            Assert.AreEqual(new Result<int> {
                Data = 1
            }.GetDataOrDefault(()=>2), 1);
            Assert.AreEqual(new Result<int>(ResultState.Fail).GetDataOrDefault(()=>2), 2);

            Assert.AreEqual(State.Positive, new Result<State> {
                Data = State.Positive
            }.GetDataOrDefault());
            Assert.AreEqual(State.None, new Result<State>(ResultState.Fail).GetDataOrDefault());
        }
    }
}