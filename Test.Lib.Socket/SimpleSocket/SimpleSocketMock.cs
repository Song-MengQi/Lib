using Lib.Socket;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Test.Lib.Socket
{
    public class SimpleSocketMock : MockBase, ISimpleSocket
    {
        public int SendBufferSize { get { return GetValue<int>(); } set { } }
        public int ReceiveBufferSize { get { return GetValue<int>(); } set { } }
        public int SendTimeout { get { return GetValue<int>(); } set { } }
        public int ReceiveTimeout { get { return GetValue<int>(); } set { } }

        public Action<byte[]> DidReceive { get { return GetValue<Action<byte[]>>(); } set { } }
        public Action DidConnect { get { return GetValue<Action>(); } set { } }
        public Action DidDisconnect { get { return GetValue<Action>(); } set { } }
        public Action DidConnectFail { get { return GetValue<Action>(); } set { } }

        public ConnectConfig ConnectConfig { get { return GetValue<ConnectConfig>(); } set { } }
        public AutoReconnectConfig AutoReconnectConfig { get { return GetValue<AutoReconnectConfig>(); } set { } }
        public KeepAliveConfig KeepAliveConfig { get { return GetValue<KeepAliveConfig>(); } set { } }

        public bool IsConnected { get { return GetValue<bool>(); } set { } }

        public ManualResetEventSlim SendReplyManualResetEventSlim { get { return GetValue<ManualResetEventSlim>(); } }

        public int Connect() { return GetValue<int>(); }
        public Task<int> ConnectAsync() { return GetValue<Task<int>>(); }
        public void ConnectBackground() { }

        public int Disconnect() { return GetValue<int>(); }
        public Task<int> DisconnectAsync() { return GetValue<Task<int>>(); }
        public void DisconnectBackground() { }

        public int Send(byte[] bytes) { return GetValue<int>(); }
        public Task<int> SendAsync(byte[] bytes) { return GetValue<Task<int>>(); }
        public void SendBackground(byte[] bytes) { }
    }
}