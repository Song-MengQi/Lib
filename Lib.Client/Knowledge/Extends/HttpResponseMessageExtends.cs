using System.Net.Http;
using System.Threading.Tasks;

namespace Lib.Client
{
    public static class HttpResponseMessageExtends
    {
        public static Task<string> ReadAsStringAsync(HttpResponseMessage httpResponseMessage)
        {
            if (default(HttpResponseMessage) != httpResponseMessage)
            {
                try { return httpResponseMessage.Content.ReadAsStringAsync(); }
                catch { }
            }
            return TaskExtends.RunEmpty<string>();
        }
        public static Task<byte[]> ReadAsByteArrayAsync(HttpResponseMessage httpResponseMessage)
        {
            if (default(HttpResponseMessage) != httpResponseMessage)
            {
                try { return httpResponseMessage.Content.ReadAsByteArrayAsync(); }
                catch { }
            }
            return TaskExtends.RunEmpty<byte[]>();
        }
    }
}