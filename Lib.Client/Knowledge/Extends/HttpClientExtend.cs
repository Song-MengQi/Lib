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
        public static Task<HttpResponseMessage> GetAsync(this HttpClient httpClient, string uri, TimeSpan timeout)
        {
            return CancellationTokenSourceExtends.InvokeAsync(timeout, token=>httpClient.GetAsync(uri, token));
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
            return JsonExtends.TryDeserialize<TResponse>(await httpClient.GetStringAsync(uri));
        }
        public static async Task<TResponse> GetAsync<TResponse>(this HttpClient httpClient, string uri, CancellationToken cancellationToken)
        {
            return JsonExtends.TryDeserialize<TResponse>(await httpClient.GetStringAsync(uri, cancellationToken));
        }
        public static async Task<TResponse> GetAsync<TResponse>(this HttpClient httpClient, string uri, TimeSpan timeout)
        {
            return JsonExtends.TryDeserialize<TResponse>(await httpClient.GetStringAsync(uri, timeout));
        }
        #endregion
        #region Post
        #region HttpContent => Any
        public static Task<HttpResponseMessage> PostAsync(this HttpClient httpClient, string uri, HttpContent httpContent, TimeSpan timeout)
        {
            return CancellationTokenSourceExtends.InvokeAsync(timeout, token=>httpClient.PostAsync(uri, httpContent, token));
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
            return JsonExtends.TryDeserialize<TResponse>(await httpClient.PostAndReadStringAsync(uri, httpContent));
        }
        public static async Task<TResponse> PostAndReadAsync<TResponse>(this HttpClient httpClient, string uri, HttpContent httpContent, CancellationToken cancellationToken)
        {
            return JsonExtends.TryDeserialize<TResponse>(await httpClient.PostAndReadStringAsync(uri, httpContent, cancellationToken));
        }
        public static async Task<TResponse> PostAndReadAsync<TResponse>(this HttpClient httpClient, string uri, HttpContent httpContent, TimeSpan timeout)
        {
            return JsonExtends.TryDeserialize<TResponse>(await httpClient.PostAndReadStringAsync(uri, httpContent, timeout));
        }
        #endregion
        #region string => Any
        public static Task<HttpResponseMessage> PostAsync(this HttpClient httpClient, string uri, string content)
        {
            return httpClient.PostAsync(uri, ClientExtends.JsonToStringContent(content) as HttpContent);
        }
        public static Task<HttpResponseMessage> PostAsync(this HttpClient httpClient, string uri, string content, CancellationToken cancellationToken)
        {
            return httpClient.PostAsync(uri, ClientExtends.JsonToStringContent(content) as HttpContent, cancellationToken);
        }
        public static Task<HttpResponseMessage> PostAsync(this HttpClient httpClient, string uri, string content, TimeSpan timeout)
        {
            return httpClient.PostAsync(uri, ClientExtends.JsonToStringContent(content) as HttpContent, timeout);
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
            return JsonExtends.TryDeserialize<TResponse>(await httpClient.PostAndReadStringAsync(uri, content));
        }
        public static async Task<TResponse> PostAndReadAsync<TResponse>(this HttpClient httpClient, string uri, string content, CancellationToken cancellationToken)
        {
            return JsonExtends.TryDeserialize<TResponse>(await httpClient.PostAndReadStringAsync(uri, content, cancellationToken));
        }
        public static async Task<TResponse> PostAndReadAsync<TResponse>(this HttpClient httpClient, string uri, string content, TimeSpan timeout)
        {
            return JsonExtends.TryDeserialize<TResponse>(await httpClient.PostAndReadStringAsync(uri, content, timeout));
        }
        #endregion
        #region TRequest => Any
        public static Task<HttpResponseMessage> PostAsync<TRequest>(this HttpClient httpClient, string uri, TRequest request)
        {
            return httpClient.PostAsync(uri, JsonExtends.Serialize(request));
        }
        public static Task<HttpResponseMessage> PostAsync<TRequest>(this HttpClient httpClient, string uri, TRequest request, CancellationToken cancellationToken)
        {
            return httpClient.PostAsync(uri, JsonExtends.Serialize(request), cancellationToken);
        }
        public static Task<HttpResponseMessage> PostAsync<TRequest>(this HttpClient httpClient, string uri, TRequest request, TimeSpan timeout)
        {
            return httpClient.PostAsync(uri, JsonExtends.Serialize(request), timeout);
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
            return JsonExtends.TryDeserialize<TResponse>(await httpClient.PostAndReadStringAsync(uri, JsonExtends.Serialize(request)));
        }
        public static async Task<TResponse> PostAndReadAsync<TRequest, TResponse>(this HttpClient httpClient, string uri, TRequest request, CancellationToken cancellationToken)
        {
            return JsonExtends.TryDeserialize<TResponse>(await httpClient.PostAndReadStringAsync(uri, JsonExtends.Serialize(request), cancellationToken));
        }
        public static async Task<TResponse> PostAndReadAsync<TRequest, TResponse>(this HttpClient httpClient, string uri, TRequest request, TimeSpan timeout)
        {
            return JsonExtends.TryDeserialize<TResponse>(await httpClient.PostAndReadStringAsync(uri, JsonExtends.Serialize(request), timeout));
        }
        #endregion
        #endregion
        #region Send
        public static Task<HttpResponseMessage> SendAsync(this HttpClient httpClient, HttpRequestMessage request, TimeSpan timeout)
        {
            return CancellationTokenSourceExtends.InvokeAsync(timeout, token=>httpClient.SendAsync(request, token));
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
            return JsonExtends.TryDeserialize<TResponse>(await httpClient.SendAndReadStringAsync(request));
        }
        public static async Task<TResponse> SendAndReadAsync<TResponse>(this HttpClient httpClient, HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return JsonExtends.TryDeserialize<TResponse>(await httpClient.SendAndReadStringAsync(request, cancellationToken));
        }
        public static async Task<TResponse> SendAndReadAsync<TResponse>(this HttpClient httpClient, HttpRequestMessage request, TimeSpan timeout)
        {
            return JsonExtends.TryDeserialize<TResponse>(await httpClient.SendAndReadStringAsync(request, timeout));
        }
        #endregion
    }
}