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
        private Task Request(Func<Task> func)
        {
            try { return func(); }
            catch (Exception)
            {
                httpClient.Dispose();
                httpClient = createHttpClientFunc();
                throw;
            }
        }
        private Task<TResult> Request<TResult>(Func<Task<TResult>> func)
        {
            try { return func(); }
            catch (Exception)
            {
                httpClient.Dispose();
                httpClient = createHttpClientFunc();
                throw;
            }
        }
        #endregion
        #region Get
        public Task<HttpResponseMessage> GetAsync(string uri)
        {
            return Request(() => httpClient.GetAsync(uri));
        }
        public Task<HttpResponseMessage> GetAsync(string uri, CancellationToken cancellationToken)
        {
            return Request(() => httpClient.GetAsync(uri, cancellationToken));
        }
        public Task<string> GetStringAsync(string uri)
        {
            return Request(() => httpClient.GetStringAsync(uri));
        }
        public Task<byte[]> GetByteArrayAsync(string uri)
        {
            return Request(() => httpClient.GetByteArrayAsync(uri));
        }
        #endregion
        #region Post
        public Task<HttpResponseMessage> PostAsync(string uri, HttpContent httpContent)
        {
            return Request(() => httpClient.PostAsync(uri, httpContent));
        }
        public Task<HttpResponseMessage> PostAsync(string uri, HttpContent httpContent, CancellationToken cancellationToken)
        {
            return Request(() => httpClient.PostAsync(uri, httpContent, cancellationToken));
        }
        #endregion
        #region Send
        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage)
        {
            return Request(() => httpClient.SendAsync(httpRequestMessage));
        }
        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage, CancellationToken cancellationToken)
        {
            return Request(() => httpClient.SendAsync(httpRequestMessage, cancellationToken));
        }
        #endregion
    }
}