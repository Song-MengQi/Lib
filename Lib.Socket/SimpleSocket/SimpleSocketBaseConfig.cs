using System;
using System.Linq;
using System.Net.Sockets;

namespace Lib.Socket
{
    public abstract partial class SimpleSocketBase
    {
        #region ConfigSocket
        public int SendBufferSize { get; set; }
        public int ReceiveBufferSize { get; set; }
        public int SendTimeout { get; set; }
        public int ReceiveTimeout { get; set; }
        private void ConfigSocket()
        {
            socket.SendBufferSize = SendBufferSize;
            socket.ReceiveBufferSize = ReceiveBufferSize;
            socket.SendTimeout = SendTimeout;
            socket.ReceiveTimeout = ReceiveTimeout;
            socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);
        }
        #endregion
        #region ConfigSocketKeepAlive
        public KeepAliveConfig KeepAliveConfig { get; set; }
        private ulong keepAliveKey = 0ul;
        private void ConfigSocketKeepAlive()
        {
            if (false == KeepAliveConfig.IsKeepAlive) return;
            //uint dummy = 0;
            //byte[] inOptionValues = new byte[Marshal.SizeOf(dummy) * 3];
            //BitConverter.GetBytes((uint)1).CopyTo(inOptionValues, 0);
            //BitConverter.GetBytes((uint)3000).CopyTo(inOptionValues, Marshal.SizeOf(dummy));//keep-alive间隔
            //BitConverter.GetBytes((uint)500).CopyTo(inOptionValues, Marshal.SizeOf(dummy) * 2);//尝试间隔
            socket.IOControl(IOControlCode.KeepAliveValues,
                IEnumerableExtends.Concat(new uint[] { 1u, KeepAliveConfig.KeepAliveDuration, KeepAliveConfig.KeepAliveTryDuration }.Select(u => BitConverter.GetBytes(u))).ToArray(),
                null);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
        }
        #endregion
        protected void Config()
        {
            ConfigSocket();
            ConfigSocketKeepAlive();
        }
    }
}