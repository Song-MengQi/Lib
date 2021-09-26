using System.Net.Http;
using System.Threading.Tasks;

namespace Lib.Client
{
    public static class HttpResponseMessageExtends
    {
        public static async Task<string> ReadAsStringAsync(HttpResponseMessage httpResponseMessage)
        {
            if (default(HttpResponseMessage) == httpResponseMessage) return default(string);
            try { return await httpResponseMessage.Content.ReadAsStringAsync(); }
            catch { return default(string); }
        }
        public static async Task<byte[]> ReadAsByteArrayAsync(HttpResponseMessage httpResponseMessage)
        {
            if (default(HttpResponseMessage) == httpResponseMessage) return default(byte[]);
            try { return await httpResponseMessage.Content.ReadAsByteArrayAsync(); }
            catch { return default(byte[]); }
        }
    }
}