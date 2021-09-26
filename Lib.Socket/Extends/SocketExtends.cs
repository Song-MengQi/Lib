namespace Lib.Socket
{
    public static class SocketExtends
    {
        public static bool IsConnected(System.Net.Sockets.Socket socket) { return default(System.Net.Sockets.Socket) != socket && socket.Connected; }
        //public static bool IsAlive(System.Net.Sockets.Socket socket) { return default(System.Net.Sockets.Socket) != socket && socket.IsAlive(); }
    }
}