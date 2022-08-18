using System.Net.Sockets;

namespace Lib.Socket
{
    public class SimpleSocketClient : SimpleSocketBase, ISimpleSocketClient
    {
        public SimpleSocketClient(string ip, ushort port) : base(ip, port) { }
        protected override int TryConnect()
        {
            socket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Config();
            try { socket.Connect(endPoint); }
            catch { return ResultState.Fail; }
            return ResultState.Success;
        }
    }
}