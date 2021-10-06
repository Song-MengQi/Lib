using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Lib.Client
{
    public interface IHttpClienter
    {
        Task<HttpResponseMessage> GetAsync(string uri);
        Task<HttpResponseMessage> GetAsync(string uri, CancellationToken cancellationToken);

        Task<string> GetStringAsync(string uri);
        Task<byte[]> GetByteArrayAsync(string uri);

        Task<HttpResponseMessage> PostAsync(string uri, HttpContent httpContent);
        Task<HttpResponseMessage> PostAsync(string uri, HttpContent httpContent, CancellationToken cancellationToken);

        Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage);
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage, CancellationToken cancellationToken);
    }
}