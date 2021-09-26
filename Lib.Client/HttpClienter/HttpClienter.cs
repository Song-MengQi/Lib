using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Lib.Client
{
    public class HttpClienter : IHttpClienter, IDisposable
    {
        private HttpClient httpClient;
        private readonly Func<HttpClient> createHttpClientFunc;
        public HttpClienter() : this(() => new HttpClient()) { }
        public HttpClienter(Func<HttpClient> createHttpClientFunc)
        {
            this.createHttpClientFunc = createHttpClientFunc;
            httpClient = createHttpClientFunc();
        }
        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                IDisposableExtends.Dispose(httpClient);
            }
        }
        #endregion
        #region request
        private async Task request(Func<Task> func)
        {
            try { await func(); }
            catch
            {
                httpClient.Dispose();
                httpClient = createHttpClientFunc();
            }
            await func();
        }
        private async Task<TResult> request<TResult>(Func<Task<TResult>> func)
        {
            try { return await func(); }
            catch
            {
                httpClient.Dispose();
                httpClient = createHttpClientFunc();
            }
            return await func();
        }
        #endregion
        #region Get
        public async Task<HttpResponseMessage> GetAsync(string uri)
        {
            return await request(() => httpClient.GetAsync(uri));
        }
        public async Task<HttpResponseMessage> GetAsync(string uri, CancellationToken cancellationToken)
        {
            return await request(() => httpClient.GetAsync(uri, cancellationToken));
        }
        public async Task<string> GetStringAsync(string uri)
        {
            return await request(() => httpClient.GetStringAsync(uri));
        }
        public async Task<byte[]> GetByteArrayAsync(string uri)
        {
            return await request(() => httpClient.GetByteArrayAsync(uri));
        }
        #endregion
        #region Post
        public async Task<HttpResponseMessage> PostAsync(string uri, HttpContent httpContent)
        {
            return await request(() => httpClient.PostAsync(uri, httpContent));
        }
        public async Task<HttpResponseMessage> PostAsync(string uri, HttpContent httpContent, CancellationToken cancellationToken)
        {
            return await request(() => httpClient.PostAsync(uri, httpContent, cancellationToken));
        }
        #endregion
        #region Send
        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage)
        {
            return await request(() => httpClient.SendAsync(httpRequestMessage));
        }
        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage, CancellationToken cancellationToken)
        {
            return await request(() => httpClient.SendAsync(httpRequestMessage, cancellationToken));
        }
        #endregion
    }
}