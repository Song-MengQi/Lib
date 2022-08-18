using Lib.Timer;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Lib.Socket
{
    public abstract partial class SimpleSocketBase : ISimpleSocket, IDisposable
    {
        public Action<byte[]> DidReceive { get; set; }
        public Action DidConnect { get; set; }
        public Action DidDisconnect { get; set; }
        public Action DidConnectFail { get; set; }
        public ConnectConfig ConnectConfig { get; set; }
        public AutoReconnectConfig AutoReconnectConfig { get; set; }
        public bool IsConnected { get { return SocketExtends.IsConnected(socket); } }

        protected readonly ISerializable socketSerializable = new Serializable();//用来锁socket
        protected readonly ISerializable sendSerializable = new Serializable();//用来锁send
        protected readonly EndPoint endPoint;
        protected System.Net.Sockets.Socket socket = default(System.Net.Sockets.Socket);
        protected bool shouldConnect = false;
        protected SimpleSocketBase(string ip, ushort port)
        {
            endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            ConnectConfig = new ConnectConfig {
                TryTimes = 1,
                Timeout = 1000
            };
            AutoReconnectConfig = new AutoReconnectConfig {
                IsAutoReconnect = false,
                ConnectConfig = new ConnectConfig {
                    TryTimes = 1,
                    Timeout = 1000
                }
            };

            KeepAliveConfig = new KeepAliveConfig {
                IsKeepAlive = false,//是否使用KeepAlive检测掉线
                KeepAliveDuration = 5000,//5秒检测一次
                KeepAliveTryDuration = 500//0.5秒尝试一次，Win10默认重试10次
            };

            SendBufferSize = 0;
            ReceiveBufferSize = 4096;
            SendTimeout = 1000;
            ReceiveTimeout = 0;
        }
        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                IDisposableExtends.Dispose(socket);
            }
        }
        #endregion
        #region shutcut
        #region OnEvent
        private void OnConnected()
        {
            if (KeepAliveConfig.IsKeepAlive) TotalTimerExtends.RegisterRepeat(ref keepAliveKey, KeepAlive, 1);
            TaskExtends.Run(DidConnect);
            TaskExtends.RunLong(TryReceive);
        }
        private void OnDisconnected()
        {
            if (KeepAliveConfig.IsKeepAlive) TotalTimerExtends.UnRegisterRepeat(ref keepAliveKey);
            TaskExtends.Run(DidDisconnect);
        }
        private void OnConnectedFail()
        {
            TaskExtends.Run(DidConnectFail);
        }
        #endregion
        private void KeepAlive()
        {
            System.Net.Sockets.Socket _socket = socket;
            if (false == SocketExtends.IsConnected(_socket)) return;
            if (_socket.IsAlive()) return;
            socketSerializable.InvokeBackground(() => {
                if (false == SocketExtends.IsConnected(_socket)) return;
                if (_socket.IsAlive()) return;
                DetectOffline(_socket);
            });
        }
        private void DetectOffline(System.Net.Sockets.Socket _socket)
        {
            //判断检测到掉线时的socket和当前的socket是不是同一个对象，来决定要不要重连。从而保证多个触发点过来只有一个被执行。
            if (_socket != socket) return;
            //确保断开
            TryDisconnect();

            if (AutoReconnectConfig.IsAutoReconnect) TryConnect(AutoReconnectConfig.ConnectConfig);
        }

        private int TryConnect(ConnectConfig connectConfig)
        {
            if (IsConnected) return ResultState.Success;//如果之前已经连上了

            int tryTimes = connectConfig.TryTimes;
            if (tryTimes < 0) tryTimes = int.MaxValue;
            for (int i = 0; i < tryTimes; ++i)
            {
                if (false == shouldConnect) return ResultState.Success;//如果不应该连接，直接返回成功

                Task<int> task = Task.Run(()=>TryConnect());
                if (task.Wait(connectConfig.Timeout) && ResultState.Success == task.Result && IsConnected)
                {
                    OnConnected();
                    return ResultState.Success;//成功
                }
                TryDisconnect();
            }
            OnConnectedFail();
            return ResultState.Timeout;
        }
        protected abstract int TryConnect();

        protected int TryDisconnect()
        {
            if (default(System.Net.Sockets.Socket) == socket) return ResultState.Success;
            TryDisconnect(socket);
            socket = default(System.Net.Sockets.Socket);
            OnDisconnected();
            return ResultState.Success;
        }
        protected int TryDisconnect(System.Net.Sockets.Socket _socket)
        {
            if (default(System.Net.Sockets.Socket) == _socket) return ResultState.Success;
            if (_socket.Connected)
            {
                try
                {
                    _socket.Shutdown(SocketShutdown.Both);
                    //_socket.Disconnect(false);
                    _socket.Close();//查看源码可知，Close底层也会Disconnect
                }
                catch (ObjectDisposedException) { /*The System.Net.Sockets.Socket has been closed.*/ }
                catch (SocketException) { /*An error occurred when attempting to access the socket.*/ }
                catch { }
            }
            IDisposableExtends.Dispose(_socket);
            return ResultState.Success;
        }

        private void TryReceive()
        {
            System.Net.Sockets.Socket _socket = socket;
            byte[] buffer = new byte[ReceiveBufferSize];
            ISerializable receiveSerializable = new Serializable();
            while (SocketExtends.IsConnected(_socket))
            {
                Array.Clear(buffer, 0, ReceiveBufferSize);
                int receiveLength = 0;
                try { receiveLength = _socket.Receive(buffer); }
                catch { continue; }
                if (receiveLength < 1) break;
                else
                {
                    if (default(Action<byte[]>) != DidReceive)
                    {
                        byte[] bytes = ArrayExtends.GetCopy(buffer, receiveLength);
                        //如果需要try-catch，请在DidReceive内自行解决
                        //要保证执行顺序与接收顺序一致，需要串行化
                        receiveSerializable.InvokeBackground(() => DidReceive(bytes));
                    }
                }
            }
            socketSerializable.InvokeBackground(()=>DetectOffline(_socket));
        }
        private int TrySend(byte[] bytes)
        {
            if (ArrayExtends.IsNullOrEmpty(bytes)) return ResultState.Refuse;

            System.Net.Sockets.Socket _socket = socket;
            if (false == SocketExtends.IsConnected(_socket)) return ResultState.LostConnect;
            try
            {
                if (bytes.Length != _socket.Send(bytes)) return ResultState.Fail;
            }
            catch
            {
                socketSerializable.InvokeBackground(() => DetectOffline(_socket));
                return ResultState.Fail;
            }
            return ResultState.Success;
        }
        #endregion
        public virtual int Connect()
        {
            shouldConnect = true;
            return socketSerializable.Invoke(() => TryConnect(ConnectConfig));
        }
        public virtual Task<int> ConnectAsync()
        {
            shouldConnect = true;
            return socketSerializable.InvokeAsync(() => TryConnect(ConnectConfig));
        }
        public virtual void ConnectBackground()
        {
            shouldConnect = true;
            socketSerializable.InvokeBackground(() => TryConnect(ConnectConfig));
        }

        public virtual int Disconnect()
        {
            shouldConnect = false;
            TryDisconnect(socket);//先中断
            return socketSerializable.Invoke(() => TryDisconnect());
        }
        public virtual Task<int> DisconnectAsync()
        {
            shouldConnect = false;
            return Task.Run(()=>{
                TryDisconnect(socket);//先中断
                return socketSerializable.Invoke(() => TryDisconnect());
            });
        }
        public virtual void DisconnectBackground()
        {
            shouldConnect = false;
            Task.Run(()=>{
                TryDisconnect(socket);//先中断
                socketSerializable.InvokeBackground(() => TryDisconnect());
            });
        }

        public virtual int Send(byte[] bytes)
        {
            return sendSerializable.Invoke(() => TrySend(bytes));
        }
        public virtual Task<int> SendAsync(byte[] bytes)
        {
            return sendSerializable.InvokeAsync(() => TrySend(bytes));
        }
        public virtual void SendBackground(byte[] bytes)
        {
            sendSerializable.InvokeBackground(() => TrySend(bytes));
        }
    }
}