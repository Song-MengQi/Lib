using Lib.Socket;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Sockets;

namespace Test.Lib.Socket
{
    [TestClass]
    public class SocketExtendsTest
    {
        [TestMethod]
        public void TestIsConnected()
        {
            Assert.IsFalse(SocketExtends.IsConnected(default(System.Net.Sockets.Socket)));
            Assert.IsFalse(SocketExtends.IsConnected(new System.Net.Sockets.Socket(SocketType.Stream, ProtocolType.Tcp)));
        }
        //[TestMethod]
        //public void TestIsAlive()
        //{
        //    Assert.IsFalse(SocketExtends.IsAlive(default(System.Net.Sockets.Socket)));
        //    Assert.IsFalse(SocketExtends.IsAlive(new System.Net.Sockets.Socket(SocketType.Stream, ProtocolType.Tcp)));
        //}
    }
}