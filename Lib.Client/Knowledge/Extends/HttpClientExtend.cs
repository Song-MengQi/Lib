using Lib.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Lib.Client
{
    public static class HttpClientExtend
    {
        #region Get
        public static async Task<HttpResponseMessage> GetAsync(this HttpClient httpClient, string uri, TimeSpan timeout)
        {
            return await httpClient.GetAsync(uri, new CancellationTokenSource(timeout).Token);
        }

        public static async Task<byte[]> GetBytesAsync(this HttpClient httpClient, string uri, CancellationToken cancellationToken)
        {
            return await HttpResponseMessageExtends.ReadAsByteArrayAsync(await httpClient.GetAsync(uri, cancellationToken));
        }
        public static async Task<byte[]> GetBytesAsync(this HttpClient httpClient, string uri, TimeSpan timeout)
        {
            return await HttpResponseMessageExtends.ReadAsByteArrayAsync(await httpClient.GetAsync(uri, timeout));
        }

        public static async Task<string> GetStringAsync(this HttpClient httpClient, string uri, CancellationToken cancellationToken)
        {
            return await HttpResponseMessageExtends.ReadAsStringAsync(await httpClient.GetAsync(uri, cancellationToken));
        }
        public static async Task<string> GetStringAsync(this HttpClient httpClient, string uri, TimeSpan timeout)
        {
            return await HttpResponseMessageExtends.ReadAsStringAsync(await httpClient.GetAsync(uri, timeout));
        }

        public static async Task<TResponse> GetAsync<TResponse>(this HttpClient httpClient, string uri)
        {
            return Jsons.TryDeserialize<TResponse>(await httpClient.GetStringAsync(uri));
        }
        public static async Task<TResponse> GetAsync<TResponse>(this HttpClient httpClient, string uri, CancellationToken cancellationToken)
        {
            return Jsons.TryDeserialize<TResponse>(await httpClient.GetStringAsync(uri, cancellationToken));
        }
        public static async Task<TResponse> GetAsync<TResponse>(this HttpClient httpClient, string uri, TimeSpan timeout)
        {
            return Jsons.TryDeserialize<TResponse>(await httpClient.GetStringAsync(uri, timeout));
        }
        #endregion
        #region Post
        #region HttpContent => Any
        public static async Task<HttpResponseMessage> PostAsync(this HttpClient httpClient, string uri, HttpContent httpContent, TimeSpan timeout)
        {
            return await httpClient.PostAsync(uri, httpContent, new CancellationTokenSource(timeout).Token);
        }

        public static async Task<string> PostAndReadStringAsync(this HttpClient httpClient, string uri, HttpContent httpContent)
        {
            return await HttpResponseMessageExtends.ReadAsStringAsync(await httpClient.PostAsync(uri, httpContent));
        }
        public static async Task<string> PostAndReadStringAsync(this HttpClient httpClient, string uri, HttpContent httpContent, CancellationToken cancellationToken)
        {
            return await HttpResponseMessageExtends.ReadAsStringAsync(await httpClient.PostAsync(uri, httpContent, cancellationToken));
        }
        public static async Task<string> PostAndReadStringAsync(this HttpClient httpClient, string uri, HttpContent httpContent, TimeSpan timeout)
        {
            return await HttpResponseMessageExtends.ReadAsStringAsync(await httpClient.PostAsync(uri, httpContent, timeout));
        }

        public static async Task<byte[]> PostAndReadBytesAsync(this HttpClient httpClient, string uri, HttpContent httpContent)
        {
            return await HttpResponseMessageExtends.ReadAsByteArrayAsync(await httpClient.PostAsync(uri, httpContent));
        }
        public static async Task<byte[]> PostAndReadBytesAsync(this HttpClient httpClient, string uri, HttpContent httpContent, CancellationToken cancellationToken)
        {
            return await HttpResponseMessageExtends.ReadAsByteArrayAsync(await httpClient.PostAsync(uri, httpContent, cancellationToken));
        }
        public static async Task<byte[]> PostAndReadBytesAsync(this HttpClient httpClient, string uri, HttpContent httpContent, TimeSpan timeout)
        {
            return await HttpResponseMessageExtends.ReadAsByteArrayAsync(await httpClient.PostAsync(uri, httpContent, timeout));
        }

        public static async Task<TResponse> PostAndReadAsync<TResponse>(this HttpClient httpClient, string uri, HttpContent httpContent)
        {
            return Jsons.TryDeserialize<TResponse>(await httpClient.PostAndReadStringAsync(uri, httpContent));
        }
        public static async Task<TResponse> PostAndReadAsync<TResponse>(this HttpClient httpClient, string uri, HttpContent httpContent, CancellationToken cancellationToken)
        {
            return Jsons.TryDeserialize<TResponse>(await httpClient.PostAndReadStringAsync(uri, httpContent, cancellationToken));
        }
        public static async Task<TResponse> PostAndReadAsync<TResponse>(this HttpClient httpClient, string uri, HttpContent httpContent, TimeSpan timeout)
        {
            return Jsons.TryDeserialize<TResponse>(await httpClient.PostAndReadStringAsync(uri, httpContent, timeout));
        }
        #endregion
        #region string => Any
        public static async Task<HttpResponseMessage> PostAsync(this HttpClient httpClient, string uri, string content)
        {
            return await httpClient.PostAsync(uri, LibClientExtends.JsonToStringContent(content) as HttpContent);
        }
        public static async Task<HttpResponseMessage> PostAsync(this HttpClient httpClient, string uri, string content, CancellationToken cancellationToken)
        {
            return await httpClient.PostAsync(uri, LibClientExtends.JsonToStringContent(content) as HttpContent, cancellationToken);
        }
        public static async Task<HttpResponseMessage> PostAsync(this HttpClient httpClient, string uri, string content, TimeSpan timeout)
        {
            return await httpClient.PostAsync(uri, LibClientExtends.JsonToStringContent(content) as HttpContent, timeout);
        }

        public static async Task<string> PostAndReadStringAsync(this HttpClient httpClient, string uri, string content)
        {
            return await HttpResponseMessageExtends.ReadAsStringAsync(await httpClient.PostAsync(uri, content));
        }
        public static async Task<string> PostAndReadStringAsync(this HttpClient httpClient, string uri, string content, CancellationToken cancellationToken)
        {
            return await HttpResponseMessageExtends.ReadAsStringAsync(await httpClient.PostAsync(uri, content, cancellationToken));
        }
        public static async Task<string> PostAndReadStringAsync(this HttpClient httpClient, string uri, string content, TimeSpan timeout)
        {
            return await HttpResponseMessageExtends.ReadAsStringAsync(await httpClient.PostAsync(uri, content, timeout));
        }

        public static async Task<byte[]> PostAndReadBytesAsync(this HttpClient httpClient, string uri, string content)
        {
            return await HttpResponseMessageExtends.ReadAsByteArrayAsync(await httpClient.PostAsync(uri, content));
        }
        public static async Task<byte[]> PostAndReadBytesAsync(this HttpClient httpClient, string uri, string content, CancellationToken cancellationToken)
        {
            return await HttpResponseMessageExtends.ReadAsByteArrayAsync(await httpClient.PostAsync(uri, content, cancellationToken));
        }
        public static async Task<byte[]> PostAndReadBytesAsync(this HttpClient httpClient, string uri, string content, TimeSpan timeout)
        {
            return await HttpResponseMessageExtends.ReadAsByteArrayAsync(await httpClient.PostAsync(uri, content, timeout));
        }

        public static async Task<TResponse> PostAndReadAsync<TResponse>(this HttpClient httpClient, string uri, string content)
        {
            return Jsons.TryDeserialize<TResponse>(await httpClient.PostAndReadStringAsync(uri, content));
        }
        public static async Task<TResponse> PostAndReadAsync<TResponse>(this HttpClient httpClient, string uri, string content, CancellationToken cancellationToken)
        {
            return Jsons.TryDeserialize<TResponse>(await httpClient.PostAndReadStringAsync(uri, content, cancellationToken));
        }
        public static async Task<TResponse> PostAndReadAsync<TResponse>(this HttpClient httpClient, string uri, string content, TimeSpan timeout)
        {
            return Jsons.TryDeserialize<TResponse>(await httpClient.PostAndReadStringAsync(uri, content, timeout));
        }
        #endregion
        #region TRequest => Any
        public static async Task<HttpResponseMessage> PostAsync<TRequest>(this HttpClient httpClient, string uri, TRequest request)
        {
            return await httpClient.PostAsync(uri, Jsons.Serialize(request));
        }
        public static async Task<HttpResponseMessage> PostAsync<TRequest>(this HttpClient httpClient, string uri, TRequest request, CancellationToken cancellationToken)
        {
            return await httpClient.PostAsync(uri, Jsons.Serialize(request), cancellationToken);
        }
        public static async Task<HttpResponseMessage> PostAsync<TRequest>(this HttpClient httpClient, string uri, TRequest request, TimeSpan timeout)
        {
            return await httpClient.PostAsync(uri, Jsons.Serialize(request), timeout);
        }

        public static async Task<string> PostAndReadStringAsync<TRequest>(this HttpClient httpClient, string uri, TRequest request)
        {
            return await HttpResponseMessageExtends.ReadAsStringAsync(await httpClient.PostAsync(uri, request));
        }
        public static async Task<string> PostAndReadStringAsync<TRequest>(this HttpClient httpClient, string uri, TRequest request, CancellationToken cancellationToken)
        {
            return await HttpResponseMessageExtends.ReadAsStringAsync(await httpClient.PostAsync(uri, request, cancellationToken));
        }
        public static async Task<string> PostAndReadStringAsync<TRequest>(this HttpClient httpClient, string uri, TRequest request, TimeSpan timeout)
        {
            return await HttpResponseMessageExtends.ReadAsStringAsync(await httpClient.PostAsync(uri, request, timeout));
        }

        public static async Task<byte[]> PostAndReadBytesAsync<TRequest>(this HttpClient httpClient, string uri, TRequest request)
        {
            return await HttpResponseMessageExtends.ReadAsByteArrayAsync(await httpClient.PostAsync(uri, request));
        }
        public static async Task<byte[]> PostAndReadBytesAsync<TRequest>(this HttpClient httpClient, string uri, TRequest request, CancellationToken cancellationToken)
        {
            return await HttpResponseMessageExtends.ReadAsByteArrayAsync(await httpClient.PostAsync(uri, request, cancellationToken));
        }
        public static async Task<byte[]> PostAndReadBytesAsync<TRequest>(this HttpClient httpClient, string uri, TRequest request, TimeSpan timeout)
        {
            return await HttpResponseMessageExtends.ReadAsByteArrayAsync(await httpClient.PostAsync(uri, request, timeout));
        }

        public static async Task<TResponse> PostAndReadAsync<TRequest, TResponse>(this HttpClient httpClient, string uri, TRequest request)
        {
            return Jsons.TryDeserialize<TResponse>(await httpClient.PostAndReadStringAsync(uri, Jsons.Serialize(request)));
        }
        public static async Task<TResponse> PostAndReadAsync<TRequest, TResponse>(this HttpClient httpClient, string uri, TRequest request, CancellationToken cancellationToken)
        {
            return Jsons.TryDeserialize<TResponse>(await httpClient.PostAndReadStringAsync(uri, Jsons.Serialize(request), cancellationToken));
        }
        public static async Task<TResponse> PostAndReadAsync<TRequest, TResponse>(this HttpClient httpClient, string uri, TRequest request, TimeSpan timeout)
        {
            return Jsons.TryDeserialize<TResponse>(await httpClient.PostAndReadStringAsync(uri, Jsons.Serialize(request), timeout));
        }
        #endregion
        #endregion
        #region Send
        public static async Task<HttpResponseMessage> SendAsync(this HttpClient httpClient, HttpRequestMessage request, TimeSpan timeout)
        {
            return await httpClient.SendAsync(request, new CancellationTokenSource(timeout).Token);
        }

        public static async Task<string> SendAndReadStringAsync(this HttpClient httpClient, HttpRequestMessage request)
        {
            return await HttpResponseMessageExtends.ReadAsStringAsync(await httpClient.SendAsync(request));
        }
        public static async Task<string> SendAndReadStringAsync(this HttpClient httpClient, HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return await HttpResponseMessageExtends.ReadAsStringAsync(await httpClient.SendAsync(request, cancellationToken));
        }
        public static async Task<string> SendAndReadStringAsync(this HttpClient httpClient, HttpRequestMessage request, TimeSpan timeout)
        {
            return await HttpResponseMessageExtends.ReadAsStringAsync(await httpClient.SendAsync(request, timeout));
        }

        public static async Task<byte[]> SendAndReadBytesAsync(this HttpClient httpClient, HttpRequestMessage request)
        {
            return await HttpResponseMessageExtends.ReadAsByteArrayAsync(await httpClient.SendAsync(request));
        }
        public static async Task<byte[]> SendAndReadBytesAsync(this HttpClient httpClient, HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return await HttpResponseMessageExtends.ReadAsByteArrayAsync(await httpClient.SendAsync(request, cancellationToken));
        }
        public static async Task<byte[]> SendAndReadBytesAsync(this HttpClient httpClient, HttpRequestMessage request, TimeSpan timeout)
        {
            return await HttpResponseMessageExtends.ReadAsByteArrayAsync(await httpClient.SendAsync(request, timeout));
        }

        public static async Task<TResponse> SendAndReadAsync<TResponse>(this HttpClient httpClient, HttpRequestMessage request)
        {
            return Jsons.TryDeserialize<TResponse>(await httpClient.SendAndReadStringAsync(request));
        }
        public static async Task<TResponse> SendAndReadAsync<TResponse>(this HttpClient httpClient, HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Jsons.TryDeserialize<TResponse>(await httpClient.SendAndReadStringAsync(request, cancellationToken));
        }
        public static async Task<TResponse> SendAndReadAsync<TResponse>(this HttpClient httpClient, HttpRequestMessage request, TimeSpan timeout)
        {
            return Jsons.TryDeserialize<TResponse>(await httpClient.SendAndReadStringAsync(request, timeout));
        }
        #endregion
    }
}