using System.Net.Http;
using System.Text;

namespace Lib.Client
{
    public static class ClientExtends
    {
        public static StringContent JsonToStringContent(string json)
        {
            return default(string) == json ? default(StringContent) : new StringContent(json, Encodings.UTF8, "application/json");
        }
    }
}
