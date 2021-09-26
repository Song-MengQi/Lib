namespace Lib.Socket
{
    public class ConnectConfig
    {
        public int Timeout { get; set; }//毫秒，-1表示无限
        public int TryTimes { get; set; }//尝试次数，负数表示无限
    }
}