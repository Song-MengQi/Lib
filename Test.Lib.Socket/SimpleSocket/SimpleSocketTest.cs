using Lib;
using Lib.Socket;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test.Lib.Socket
{
    [TestClass]
    public class SimpleSocketTest
    {
        private SimpleSocketServer GetSimpleSocketServer()
        {
            return new SimpleSocketServer("127.0.0.1", 10001) {
                ReceiveBufferSize = 256
            };
        }
        private SimpleSocketClient GetSimpleSocketClient()
        {
            return new SimpleSocketClient("127.0.0.1", 10001) {
                ReceiveBufferSize = 256
            };
        }
        private void EnsureConnect(SimpleSocketServer server, SimpleSocketClient client)
        {
            Task<int> serverConnectTask = server.ConnectAsync();
            Assert.AreEqual(client.Connect(), ResultState.Success);
            Assert.AreEqual(serverConnectTask.Result, ResultState.Success);
        }
        private void EnsureDisconnect(SimpleSocketServer server, SimpleSocketClient client)
        {
            Assert.AreEqual(client.Disconnect(), ResultState.Success);
            Assert.AreEqual(server.Disconnect(), ResultState.Success);
        }

        [TestMethod]
        public void TestNormal()
        {
            string strServer = string.Empty;
            string strClient = string.Empty;
            SimpleSocketServer server = GetSimpleSocketServer();
            server.DidReceive += (bytes) => strServer += Encoding.UTF8.GetString(bytes);
            SimpleSocketClient client = GetSimpleSocketClient();
            client.DidReceive += (bytes) => strClient += Encoding.UTF8.GetString(bytes);

            EnsureConnect(server, client);

            server.SendUTF8Background("A");
            client.SendUTF8Background("a");
            server.SendUTF8Background("B");
            server.SendUTF8Background("C");
            client.SendUTF8Background("b");
            client.SendUTF8Background("c");
            server.SendUTF8Background("D");
            server.SendUTF8Background("E");
            client.SendUTF8Background("d");
            client.SendUTF8Background("e");
            server.SendUTF8("FFFFFF");
            client.SendUTF8("ffffff");
            Thread.Sleep(100);
            EnsureDisconnect(server, client);

            Assert.AreEqual(strServer, "abcdeffffff");
            Assert.AreEqual(strClient, "ABCDEFFFFFF");
        }
        [TestMethod]
        public void TestOther()
        {
            Assert.AreEqual(new SimpleSocketClient("127.0.0.1", 10001) {
                ReceiveBufferSize = 256,
                ConnectConfig = new ConnectConfig { 
                    TryTimes = 1,
                    Timeout = 1
                }
            }.Connect(), ResultState.Timeout);


            string strServer = string.Empty;
            string strClient = string.Empty;
            SimpleSocketServer server = new SimpleSocketServer("127.0.0.1", 10001) {
                ReceiveBufferSize = 256,
                KeepAliveConfig = new KeepAliveConfig { 
                    IsKeepAlive = true,
                    KeepAliveDuration = 1,
                    KeepAliveTryDuration = 1
                }
            };
            SimpleSocketClient client = new SimpleSocketClient("127.0.0.1", 10001) {
                ReceiveBufferSize = 256
            };

            server.ConnectBackground();
            Assert.AreEqual(client.Connect(), ResultState.Success);
            Assert.AreEqual(client.Connect(), ResultState.Success);
            Assert.IsTrue(server.IsConnected);

            server.SendASCII("A");
            client.SendASCII("a");
            server.SendASCIIAsync("B").Wait();
            client.SendASCIIAsync("b").Wait();
            server.SendASCIIBackground("C");
            client.SendASCIIBackground("c");
            server.SendUTF8Async("D").Wait();
            client.SendUTF8Async("d").Wait();
            server.Send(default(byte[]));
            client.Send(default(byte[]));

            server.DisconnectBackground();
            Assert.AreEqual(client.DisconnectAsync().Result, ResultState.Success);
            Assert.AreEqual(server.DisconnectAsync().Result, ResultState.Success);
        }
        [TestMethod]
        public void TestDisconnectServer()
        {
            string strServer = string.Empty;
            string strClient = string.Empty;
            ManualResetEventSlim clientConnectSlim = new ManualResetEventSlim(false);
            ManualResetEventSlim clientDisconnectSlim = new ManualResetEventSlim(true);
            SimpleSocketServer server = GetSimpleSocketServer();
            server.DidReceive += (bytes) => strServer += Encoding.UTF8.GetString(bytes);
            SimpleSocketClient client = GetSimpleSocketClient();
            client.DidReceive += (bytes) => strClient += Encoding.UTF8.GetString(bytes);
            client.DidConnect += () => {
                clientConnectSlim.Set();
                clientDisconnectSlim.Reset();
            };
            client.DidDisconnect += () => {
                clientConnectSlim.Reset();
                clientDisconnectSlim.Set();
            };

            EnsureConnect(server, client);

            Assert.AreEqual(server.Disconnect(), ResultState.Success);
            clientDisconnectSlim.Wait();
            Assert.AreEqual(server.SendUTF8("A"), ResultState.LostConnect);
            Assert.AreEqual(client.SendUTF8("a"), ResultState.LostConnect);
            Assert.AreEqual(strServer, string.Empty);
            Assert.AreEqual(strClient, string.Empty);

            //重连
            EnsureConnect(server, client);
            //还能发
            Assert.AreEqual(server.SendUTF8("A"), ResultState.Success);
            Assert.AreEqual(client.SendUTF8("a"), ResultState.Success);
            EnsureDisconnect(server, client);
        }
        [TestMethod]
        public void TestDisconnectClient()
        {
            string strServer = string.Empty;
            string strClient = string.Empty;
            ManualResetEventSlim serverConnectSlim = new ManualResetEventSlim(false);
            ManualResetEventSlim serverDisconnectSlim = new ManualResetEventSlim(true);
            SimpleSocketServer server = GetSimpleSocketServer();
            server.DidReceive += (bytes) => strServer += Encoding.UTF8.GetString(bytes);
            server.DidConnect += () => {
                serverConnectSlim.Set();
                serverDisconnectSlim.Reset();
            };
            server.DidDisconnect += () => {
                serverConnectSlim.Reset();
                serverDisconnectSlim.Set();
            };
            SimpleSocketClient client = GetSimpleSocketClient();
            client.DidReceive += (bytes) => strClient += Encoding.UTF8.GetString(bytes);

            EnsureConnect(server, client);

            Assert.AreEqual(client.Disconnect(), ResultState.Success);
            serverDisconnectSlim.Wait();
            Assert.AreEqual(server.SendUTF8("A"), ResultState.LostConnect);
            Assert.AreEqual(client.SendUTF8("a"), ResultState.LostConnect);
            Assert.AreEqual(strServer, string.Empty);
            Assert.AreEqual(strClient, string.Empty);

            //重连
            EnsureConnect(server, client);
            //还能发
            Assert.AreEqual(server.SendUTF8("A"), ResultState.Success);
            Assert.AreEqual(client.SendUTF8("a"), ResultState.Success);
            EnsureDisconnect(server, client);
        }
        [TestMethod]
        public void TestReconnect()
        {
            string strServer = string.Empty;
            string strClient = string.Empty;
            SimpleSocketServer server = GetSimpleSocketServer();
            server.DidReceive += (bytes) => strServer += Encoding.UTF8.GetString(bytes);
            SimpleSocketClient client = GetSimpleSocketClient();
            client.DidReceive += (bytes) => strClient += Encoding.UTF8.GetString(bytes);

            EnsureConnect(server, client);
            EnsureDisconnect(server, client);

            //没重新建立连接都发不出去
            Assert.AreEqual(server.SendUTF8("A"), ResultState.LostConnect);

            Assert.AreEqual(client.SendUTF8("a"), ResultState.LostConnect);

            Assert.AreEqual(strServer, string.Empty);
            Assert.AreEqual(strClient, string.Empty);

            //重连
            EnsureConnect(server, client);

            Assert.AreEqual(server.SendUTF8("B"), ResultState.Success);
            Assert.AreEqual(client.SendUTF8("b"), ResultState.Success);
            EnsureDisconnect(server, client);
        }
        [TestMethod]
        public void TestReconnectServer()
        {
            string strServer = string.Empty;
            string strClient = string.Empty;
            ManualResetEventSlim serverConnectSlim = new ManualResetEventSlim(false);
            ManualResetEventSlim serverDisconnectSlim = new ManualResetEventSlim(true);
            SimpleSocketServer server = GetSimpleSocketServer();
            server.DidReceive += (bytes) => strServer += Encoding.UTF8.GetString(bytes);
            server.DidConnect += () => {
                serverConnectSlim.Set();
                serverDisconnectSlim.Reset();
            };
            server.DidDisconnect += () => {
                serverConnectSlim.Reset();
                serverDisconnectSlim.Set();
            };
            server.AutoReconnectConfig = new AutoReconnectConfig
            {
                IsAutoReconnect = true,
                ConnectConfig = new ConnectConfig {
                    TryTimes = 3,
                    Timeout = 1000
                }
            };
            SimpleSocketClient client = GetSimpleSocketClient();
            client.DidReceive += (bytes) => strClient += Encoding.UTF8.GetString(bytes);

            EnsureConnect(server, client);
            Assert.AreEqual(client.Disconnect(), ResultState.Success);//client主动断开
            serverDisconnectSlim.Wait();
            Assert.AreEqual(client.SendUTF8("a"), ResultState.LostConnect);//client发不了
            Assert.AreEqual(server.SendUTF8("A"), ResultState.LostConnect);//server发不了
            Assert.AreEqual(client.Connect(), ResultState.Success);//client主动连
            serverConnectSlim.Wait();//server会自动重连，这里用信号量标识是否已经重连
            Assert.AreEqual(server.SendUTF8("B"), ResultState.Success);
            Assert.AreEqual(client.SendUTF8("b"), ResultState.Success);
            //EnsureDisconnect(server, client);//这次Server会自动重连，所以server先断开
            Assert.AreEqual(server.Disconnect(), ResultState.Success);
            Assert.AreEqual(client.Disconnect(), ResultState.Success);
        }
        [TestMethod]
        public void TestReconnectClient()
        {
            string strServer = string.Empty;
            string strClient = string.Empty;
            int connectTimes = 0;
            int disconnectTimes = 0;
            ManualResetEventSlim clientConnectSlim = new ManualResetEventSlim(false);
            ManualResetEventSlim clientDisconnectSlim = new ManualResetEventSlim(true);
            SimpleSocketServer server = GetSimpleSocketServer();
            server.DidReceive += (bytes) => strServer += Encoding.UTF8.GetString(bytes);
            SimpleSocketClient client = GetSimpleSocketClient();
            client.DidReceive += (bytes) => strClient += Encoding.UTF8.GetString(bytes);
            client.DidConnect += () => {
                clientConnectSlim.Set();
                clientDisconnectSlim.Reset();
                ++connectTimes;
            };
            client.DidDisconnect += () => {
                clientConnectSlim.Reset();
                clientDisconnectSlim.Set();
                ++disconnectTimes;
            };
            client.AutoReconnectConfig = new AutoReconnectConfig {
                IsAutoReconnect = true,
                ConnectConfig = new ConnectConfig {
                    TryTimes = 3,
                    Timeout = 1000
                }
            };

            EnsureConnect(server, client);
            Assert.AreEqual(server.Disconnect(), ResultState.Success);
            clientDisconnectSlim.Wait();
            Assert.AreEqual(server.SendUTF8("A"), ResultState.LostConnect);
            Assert.AreEqual(client.SendUTF8("a"), ResultState.LostConnect);
            Assert.AreEqual(server.Connect(), ResultState.Success);
            clientConnectSlim.Wait();//client会自动重连
            Assert.AreEqual(server.SendUTF8("B"), ResultState.Success);
            Assert.AreEqual(client.SendUTF8("b"), ResultState.Success);
            EnsureDisconnect(server, client);
        }
    }
}