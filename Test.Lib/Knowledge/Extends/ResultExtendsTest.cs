using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class ResultExtendsTest : TestBase
    {
        #region check
        [TestMethod]
        public void TestCheck()
        {
            Assert.AreEqual(2, ResultExtends.GetResult(
                ()=>0,
                ()=>2,
                ()=>0).State);
            Assert.AreEqual(0, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0).State);

            #region func返回T
            Assert.AreEqual(0, ResultExtends.GetResult(
                ()=>0,
                ()=>{}).State);
            Assert.AreEqual(0, ResultExtends.GetResult(
                ()=>0,
                ()=>"abc").State);

            Assert.AreEqual(1, ResultExtends.GetResult(
                ()=>1,
                ()=>{}).State);
            Assert.AreEqual(2, ResultExtends.GetResult(
                ()=>0,
                ()=>2,
                ()=>{}).State);
            Assert.AreEqual(3, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>3,
                ()=>{}).State);
            Assert.AreEqual(4, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>4,
                ()=>{}).State);
            Assert.AreEqual(5, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>5,
                ()=>{}).State);
            Assert.AreEqual(6, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>6,
                ()=>{}).State);
            Assert.AreEqual(7, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>7,
                ()=>{}).State);
            Assert.AreEqual(8, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>8,
                ()=>{}).State);
            Assert.AreEqual(9, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>9,
                ()=>{}).State);
            Assert.AreEqual(10, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>10,
                ()=>{}).State);
            Assert.AreEqual(11, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>11,
                ()=>{}).State);
            Assert.AreEqual(12, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>12,
                ()=>{}).State);
            Assert.AreEqual(13, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>13,
                ()=>{}).State);
            Assert.AreEqual(14, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>14,
                ()=>{}).State);
            Assert.AreEqual(15, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>15,
                ()=>{}).State);

            Assert.AreEqual(1, ResultExtends.GetResult(
                ()=>1,
                ()=>"abc").State);
            Assert.AreEqual(2, ResultExtends.GetResult(
                ()=>0,
                ()=>2,
                ()=>"abc").State);
            Assert.AreEqual(3, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>3,
                ()=>"abc").State);
            Assert.AreEqual(4, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>4,
                ()=>"abc").State);
            Assert.AreEqual(5, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>5,
                ()=>"abc").State);
            Assert.AreEqual(6, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>6,
                ()=>"abc").State);
            Assert.AreEqual(7, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>7,
                ()=>"abc").State);
            Assert.AreEqual(8, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>8,
                ()=>"abc").State);
            Assert.AreEqual(9, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>9,
                ()=>"abc").State);
            Assert.AreEqual(10, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>10,
                ()=>"abc").State);
            Assert.AreEqual(11, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>11,
                ()=>"abc").State);
            Assert.AreEqual(12, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>12,
                ()=>"abc").State);
            Assert.AreEqual(13, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>13,
                ()=>"abc").State);
            Assert.AreEqual(14, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>14,
                ()=>"abc").State);
            Assert.AreEqual(15, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>15,
                ()=>"abc").State);
            #endregion


            #region func返回Result
            Assert.AreEqual(0, ResultExtends.GetResult(
                ()=>0,
                ()=>new Result()).State);
            Assert.AreEqual(0, ResultExtends.GetResult(
                ()=>0,
                ()=>new Result<string>()).State);

            Assert.AreEqual(1, ResultExtends.GetResult(
                ()=>1,
                ()=>new Result()).State);
            Assert.AreEqual(2, ResultExtends.GetResult(
                ()=>0,
                ()=>2,
                ()=>new Result()).State);
            Assert.AreEqual(3, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>3,
                ()=>new Result()).State);
            Assert.AreEqual(4, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>4,
                ()=>new Result()).State);
            Assert.AreEqual(5, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>5,
                ()=>new Result()).State);
            Assert.AreEqual(6, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>6,
                ()=>new Result()).State);
            Assert.AreEqual(7, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>7,
                ()=>new Result()).State);
            Assert.AreEqual(8, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>8,
                ()=>new Result()).State);
            Assert.AreEqual(9, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>9,
                ()=>new Result()).State);
            Assert.AreEqual(10, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>10,
                ()=>new Result()).State);
            Assert.AreEqual(11, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>11,
                ()=>new Result()).State);
            Assert.AreEqual(12, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>12,
                ()=>new Result()).State);
            Assert.AreEqual(13, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>13,
                ()=>new Result()).State);
            Assert.AreEqual(14, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>14,
                ()=>new Result()).State);
            Assert.AreEqual(15, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>15,
                ()=>new Result()).State);

            Assert.AreEqual(1, ResultExtends.GetResult(
                ()=>1,
                ()=>new Result<string>()).State);
            Assert.AreEqual(2, ResultExtends.GetResult(
                ()=>0,
                ()=>2,
                ()=>new Result<string>()).State);
            Assert.AreEqual(3, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>3,
                ()=>new Result<string>()).State);
            Assert.AreEqual(4, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>4,
                ()=>new Result<string>()).State);
            Assert.AreEqual(5, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>5,
                ()=>new Result<string>()).State);
            Assert.AreEqual(6, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>6,
                ()=>new Result<string>()).State);
            Assert.AreEqual(7, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>7,
                ()=>new Result<string>()).State);
            Assert.AreEqual(8, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>8,
                ()=>new Result<string>()).State);
            Assert.AreEqual(9, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>9,
                ()=>new Result<string>()).State);
            Assert.AreEqual(10, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>10,
                ()=>new Result<string>()).State);
            Assert.AreEqual(11, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>11,
                ()=>new Result<string>()).State);
            Assert.AreEqual(12, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>12,
                ()=>new Result<string>()).State);
            Assert.AreEqual(13, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>13,
                ()=>new Result<string>()).State);
            Assert.AreEqual(14, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>14,
                ()=>new Result<string>()).State);
            Assert.AreEqual(15, ResultExtends.GetResult(
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>0,
                ()=>15,
                ()=>new Result<string>()).State);
            #endregion
        }
        #endregion
        #region func from source
        //[TestMethod]
        //public void TestGetResult()
        //{
        //    int source1;
        //    Result<int> result1;

        //    source1 = 0;
        //    result1 = ResultExtends.GetResult(source1, i=>i+1);
        //    Assert.AreEqual(result1.State, 0);
        //    Assert.AreEqual(result1.data, 1);

        //    string source2;
        //    Result<int> result2;

        //    source2 = default(string);
        //    result2 = ResultExtends.GetResult(source2, s=>int.Parse(s)+1, 1);
        //    Assert.AreEqual(result2.State, 1);
        //    Assert.AreEqual(result2.data, default(int));

        //    source2 = "0";
        //    result2 = ResultExtends.GetResult(source2, s=>int.Parse(s)+1, 1);
        //    Assert.AreEqual(result2.State, 0);
        //    Assert.AreEqual(result2.data, 1);
        //}

        //[TestMethod]
        //public void TestGetArrayResult()
        //{
        //    int[] source;
        //    Result<int[]> result;

        //    source = new int[]{1,2};
        //    result = ResultExtends.GetArrayResult(source, i=>i+1);
        //    Assert.AreEqual(result.State, 0);
        //    Assert.AreEqual(result.data.Length, 2);
        //    Assert.AreEqual(result.data[0], 2);
        //    Assert.AreEqual(result.data[1], 3);

        //    result = ResultExtends.GetArrayResult(source, i=>i+1, 1);
        //    Assert.AreEqual(result.State, 0);
        //    Assert.AreEqual(result.data.Length, 2);
        //    Assert.AreEqual(result.data[0], 2);
        //    Assert.AreEqual(result.data[1], 3);

        //    source = default(int[]);    
        //    result = ResultExtends.GetArrayResult(source, i=>i+1, 1);
        //    Assert.AreEqual(result.State, 1);
        //    Assert.AreEqual(result.data, default(int[]));
        //}
        #endregion
    }
}