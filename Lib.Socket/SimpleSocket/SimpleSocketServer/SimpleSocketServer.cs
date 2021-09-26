using System.Net.Sockets;
using System.Threading.Tasks;

namespace Lib.Socket
{
    public partial class SimpleSocketServer : SimpleSocketBase, ISimpleSocketServer
    {
        private System.Net.Sockets.Socket serverSocket = default(System.Net.Sockets.Socket);
        public SimpleSocketServer(string ip, int port) : base(ip, port) { }
        #region Dispose
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                //IDisposableExtends.Dispose(serverSocket);
                if (default(System.Net.Sockets.Socket) != serverSocket) serverSocket.Dispose();
            }
        }
        #endregion
        #region shutcut
        private int TryOpen()
        {
            if (default(System.Net.Sockets.Socket) != serverSocket) return ResultState.Success;
            try
            {
                serverSocket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(1);
            }
            catch { return ResultState.Fail; }
            return ResultState.Success;
        }
        private int TryClose()
        {
            TryClose(serverSocket);
            serverSocket = default(System.Net.Sockets.Socket);
            return ResultState.Success;
        }
        private int TryClose(System.Net.Sockets.Socket _serverSocket)
        {
            if (default(System.Net.Sockets.Socket) == _serverSocket) return ResultState.Success;
            try { _serverSocket.Close(); }
            catch { }
            IDisposableExtends.Dispose(_serverSocket);
            return ResultState.Success;
        }
        #endregion
        protected override int TryConnect()
        {
            return ResultExtends.Check(TryOpen, () => {
                try { socket = serverSocket.Accept(); }
                catch { return ResultState.Fail; }
                Config();
                return ResultState.Success;
            });
        }
        public override int Disconnect()
        {
            shouldConnect = false;
            TryClose(serverSocket);
            TryDisconnect(socket);
            return socketSerializable.Invoke(() => ResultExtends.Check(
                TryClose,
                TryDisconnect));
        }
        public override Task<int> DisconnectAsync()
        {
            shouldConnect = false;
            return Task.Run(()=>{
                TryClose(serverSocket);
                TryDisconnect(socket);
                return socketSerializable.Invoke(()=>ResultExtends.Check(
                    TryClose,
                    TryDisconnect));
            });
        }
        public override void DisconnectBackground()
        {
            shouldConnect = false;
            Task.Run(()=>{
                TryClose(serverSocket);
                TryDisconnect(socket);
                socketSerializable.InvokeBackground(() => ResultExtends.Check(
                    TryClose,
                    TryDisconnect));
            });
        }
    }
}