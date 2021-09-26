using System.Net.NetworkInformation;

namespace Lib.Socket
{
    public static class SocketExtend
    {
        public static bool IsAlive(this System.Net.Sockets.Socket socket)
        {
            TcpConnectionInformation[] tcpConnections = IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpConnections();
            try//socket可能已被释放，加个try防异常
            {
                foreach (TcpConnectionInformation tcpConnection in tcpConnections)
                {
                    if (tcpConnection.LocalEndPoint.Equals(socket.LocalEndPoint) && tcpConnection.RemoteEndPoint.Equals(socket.RemoteEndPoint))
                    {
                        return tcpConnection.State == TcpState.Established;
                    }
                }
            }
            catch { }
            return false;
        }
    }
}