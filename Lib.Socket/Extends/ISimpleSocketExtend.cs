using System.Text;
using System.Threading.Tasks;

namespace Lib.Socket
{
    public static class ISimpleSocketExtend
    {
        private static byte[] ToASCIIBytes(string str) { return Encoding.ASCII.GetBytes(str); }
        private static byte[] ToUTF8Bytes(string str) { return Encoding.UTF8.GetBytes(str); }

        public static int SendASCII(this ISimpleSocket simpleSocket, string str) { return simpleSocket.Send(ToASCIIBytes(str)); }
        public static async Task<int> SendASCIIAsync(this ISimpleSocket simpleSocket, string str) { return await simpleSocket.SendAsync(ToASCIIBytes(str)); }
        public static void SendASCIIBackground(this ISimpleSocket simpleSocket, string str) { simpleSocket.SendBackground(ToASCIIBytes(str)); }

        public static int SendUTF8(this ISimpleSocket simpleSocket, string str) { return simpleSocket.Send(ToUTF8Bytes(str)); }
        public static async Task<int> SendUTF8Async(this ISimpleSocket simpleSocket, string str) { return await simpleSocket.SendAsync(ToUTF8Bytes(str)); }
        public static void SendUTF8Background(this ISimpleSocket simpleSocket, string str) { simpleSocket.SendBackground(ToUTF8Bytes(str)); }
    }
}