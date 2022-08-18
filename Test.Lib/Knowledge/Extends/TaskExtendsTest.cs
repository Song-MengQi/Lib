using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Test.Lib
{
    [TestClass]
    public class TaskExtendsTest
    {
        [TestMethod]
        public void TestRun()
        {
            TaskExtends.Run(default(Action));
            TaskExtends.Run(default(Func<bool>));

            bool x = false;
            TaskExtends.Run(() => x = true).Wait();
            Assert.IsTrue(x);

            Assert.IsTrue(TaskExtends.Run(() => true).Result);
        }
        [TestMethod]
        public void TestRunLong()
        {
            TaskExtends.RunLong(default(Action));
            TaskExtends.RunLong(default(Func<bool>));

            bool x = false;
            TaskExtends.RunLong(() => x = true).Wait();
            Assert.IsTrue(x);

            Assert.IsTrue(TaskExtends.RunLong(() => true).Result);
        }
        [TestMethod]
        public void TestRunEmpty()
        {
            TaskExtends.RunEmpty();
            Assert.AreEqual(TaskExtends.RunEmpty<string>().Result, default(string));
        }
        [TestMethod]
        public void TestWait()
        {
            TaskExtends.Wait(new Result<Task> {
                State = ResultState.Fail,
                Data = TaskExtends.RunEmpty()
            });
            TaskExtends.Wait(new Result<Task> {
                State = ResultState.Success,
                Data = TaskExtends.RunEmpty()
            });

            Assert.IsFalse(TaskExtends.Wait(new Result<Task<bool>> {
                State = ResultState.Fail,
                Data = Task.FromResult(true)
            }));
            Assert.IsTrue(TaskExtends.Wait(new Result<Task<bool>> {
                State = ResultState.Success,
                Data = Task.FromResult(true)
            }));
        }
    }
}
