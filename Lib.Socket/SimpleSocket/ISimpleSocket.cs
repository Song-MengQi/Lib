using System;
using System.Threading.Tasks;

namespace Lib.Socket
{
    public interface ISimpleSocket
    {
        int SendBufferSize { get; set; }
        int ReceiveBufferSize { get; set; }
        int SendTimeout { get; set; }
        int ReceiveTimeout { get; set; }
        Action<byte[]> DidReceive { get; set; }
        Action DidConnect { get; set; }
        Action DidDisconnect { get; set; }
        Action DidConnectFail { get; set; }

        ConnectConfig ConnectConfig { get; set; }
        AutoReconnectConfig AutoReconnectConfig { get; set; }
        KeepAliveConfig KeepAliveConfig { get; set; }

        bool IsConnected { get; }

        int Connect();
        Task<int> ConnectAsync();
        void ConnectBackground();

        int Disconnect();
        Task<int> DisconnectAsync();
        void DisconnectBackground();

        int Send(byte[] bytes);
        Task<int> SendAsync(byte[] bytes);
        void SendBackground(byte[] bytes);
    }
}