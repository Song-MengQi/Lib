namespace Lib.Socket
{
    public class KeepAliveConfig
    {
        public bool IsKeepAlive { get; set; }
        public uint KeepAliveDuration { get; set; }
        public uint KeepAliveTryDuration { get; set; }
    }
}