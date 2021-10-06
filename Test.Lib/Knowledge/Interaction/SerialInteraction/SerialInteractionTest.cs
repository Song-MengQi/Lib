using System.Threading;
using System.Threading.Tasks;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public class SerialInteractionTest : TestBase
    {
        [TestMethod]
        public void Test()
        {
            int message = 0;
            AutoResetEvent autoResetEvent = new AutoResetEvent(false);
            bool isRunning = true;
            

            SerialInteraction<int, int> serialInteraction = new SerialInteraction<int, int> {
                SendFunc = request => {
                    switch (request)
                    {
                        case 1://发送失败
                            return 1;
                        case 2://模拟回复
                            message = request;
                            autoResetEvent.Set();
                            break;
                    }
                    return ResultState.Success;
                }
            };

            Task.Run(()=>{
                while (isRunning)
                {
                    if (autoResetEvent.WaitOne(1000))
                    {
                        serialInteraction.Arrive(message);
                        Thread.Sleep(10);
                    }
                }
            });

            serialInteraction.SendBackground(0);

            Assert.AreEqual(1, serialInteraction.Send(1).State);
            Assert.AreEqual(1, serialInteraction.SendAsync(1).Result.State);
            Assert.AreEqual(1, serialInteraction.SendAndReceive(1).State);
            Assert.AreEqual(1, serialInteraction.SendAndReceiveAsync(1).Result.State);
            Assert.AreEqual(0, message);

            Assert.AreEqual(0, serialInteraction.Send(2).State);
            Assert.AreEqual(0, serialInteraction.SendAsync(2).Result.State);
            Assert.AreEqual(0, serialInteraction.SendAndReceive(2).State);
            Assert.AreEqual(0, serialInteraction.SendAndReceiveAsync(2).Result.State);
            Assert.AreEqual(2, message);

            Task<Result<int>> task = serialInteraction.SendAndReceiveAsync(3);
            Thread.Sleep(10);
            serialInteraction.Abort();
            Assert.AreEqual(ResultState.Fail, task.Result.State);

            isRunning = false;

            serialInteraction.Dispose();
        }
    }
}
