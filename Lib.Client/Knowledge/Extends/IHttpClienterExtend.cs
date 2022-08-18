using Lib.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Lib.Client
{
    public static class IHttpClienterExtend
    {
        #region Get
        public static Task<HttpResponseMessage> GetAsync(this IHttpClienter httpClienter, string uri, TimeSpan timeout)
        {
            return CancellationTokenSourceExtends.InvokeAsync(timeout, token=>httpClienter.GetAsync(uri, token));
        }

        public static async Task<byte[]> GetBytesAsync(this IHttpClienter httpClienter, string uri, CancellationToken cancellationToken)
        {
            return await HttpResponseMessageExtends.ReadAsByteArrayAsync(await httpClienter.GetAsync(uri, cancellationToken));
        }
        public static async Task<byte[]> GetBytesAsync(this IHttpClienter httpClienter, string uri, TimeSpan timeout)
        {
            return await HttpResponseMessageExtends.ReadAsByteArrayAsync(await httpClienter.GetAsync(uri, timeout));
        }

        public static async Task<string> GetStringAsync(this IHttpClienter httpClienter, string uri, CancellationToken cancellationToken)
        {
            return await HttpResponseMessageExtends.ReadAsStringAsync(await httpClienter.GetAsync(uri, cancellationToken));
        }
        public static async Task<string> GetStringAsync(this IHttpClienter httpClienter, string uri, TimeSpan timeout)
        {
            return await HttpResponseMessageExtends.ReadAsStringAsync(await httpClienter.GetAsync(uri, timeout));
        }

        public static async Task<TResponse> GetAsync<TResponse>(this IHttpClienter httpClienter, string uri)
        {
            return JsonExtends.TryDeserialize<TResponse>(await httpClienter.GetStringAsync(uri));
        }
        public static async Task<TResponse> GetAsync<TResponse>(this IHttpClienter httpClienter, string uri, CancellationToken cancellationToken)
        {
            return JsonExtends.TryDeserialize<TResponse>(await httpClienter.GetStringAsync(uri, cancellationToken));
        }
        public static async Task<TResponse> GetAsync<TResponse>(this IHttpClienter httpClienter, string uri, TimeSpan timeout)
        {
            return JsonExtends.TryDeserialize<TResponse>(await httpClienter.GetStringAsync(uri, timeout));
        }
        #endregion
        #region Post
        #region HttpContent => Any
        public static Task<HttpResponseMessage> PostAsync(this IHttpClienter httpClienter, string uri, HttpContent httpContent, TimeSpan timeout)
        {
            return CancellationTokenSourceExtends.InvokeAsync(timeout, token=>httpClienter.PostAsync(uri, httpContent, token));
        }

        public static async Task<string> PostAndReadStringAsync(this IHttpClienter httpClienter, string uri, HttpContent httpContent)
        {
            return await HttpResponseMessageExtends.ReadAsStringAsync(await httpClienter.PostAsync(uri, httpContent));
        }
        public static async Task<string> PostAndReadStringAsync(this IHttpClienter httpClienter, string uri, HttpContent httpContent, CancellationToken cancellationToken)
        {
            return await HttpResponseMessageExtends.ReadAsStringAsync(await httpClienter.PostAsync(uri, httpContent, cancellationToken));
        }
        public static async Task<string> PostAndReadStringAsync(this IHttpClienter httpClienter, string uri, HttpContent httpContent, TimeSpan timeout)
        {
            return await HttpResponseMessageExtends.ReadAsStringAsync(await httpClienter.PostAsync(uri, httpContent, timeout));
        }

        public static async Task<byte[]> PostAndReadBytesAsync(this IHttpClienter httpClienter, string uri, HttpContent httpContent)
        {
            return await HttpResponseMessageExtends.ReadAsByteArrayAsync(await httpClienter.PostAsync(uri, httpContent));
        }
        public static async Task<byte[]> PostAndReadBytesAsync(this IHttpClienter httpClienter, string uri, HttpContent httpContent, CancellationToken cancellationToken)
        {
            return await HttpResponseMessageExtends.ReadAsByteArrayAsync(await httpClienter.PostAsync(uri, httpContent, cancellationToken));
        }
        public static async Task<byte[]> PostAndReadBytesAsync(this IHttpClienter httpClienter, string uri, HttpContent httpContent, TimeSpan timeout)
        {
            return await HttpResponseMessageExtends.ReadAsByteArrayAsync(await httpClienter.PostAsync(uri, httpContent, timeout));
        }

        public static async Task<TResponse> PostAndReadAsync<TResponse>(this IHttpClienter httpClienter, string uri, HttpContent httpContent)
        {
            return JsonExtends.TryDeserialize<TResponse>(await httpClienter.PostAndReadStringAsync(uri, httpContent));
        }
        public static async Task<TResponse> PostAndReadAsync<TResponse>(this IHttpClienter httpClienter, string uri, HttpContent httpContent, CancellationToken cancellationToken)
        {
            return JsonExtends.TryDeserialize<TResponse>(await httpClienter.PostAndReadStringAsync(uri, httpContent, cancellationToken));
        }
        public static async Task<TResponse> PostAndReadAsync<TResponse>(this IHttpClienter httpClienter, string uri, HttpContent httpContent, TimeSpan timeout)
        {
            return JsonExtends.TryDeserialize<TResponse>(await httpClienter.PostAndReadStringAsync(uri, httpContent, timeout));
        }
        #endregion
        #region string => Any
        public static Task<HttpResponseMessage> PostAsync(this IHttpClienter httpClienter, string uri, string content)
        {
            return httpClienter.PostAsync(uri, ClientExtends.JsonToStringContent(content) as HttpContent);
        }
        public static Task<HttpResponseMessage> PostAsync(this IHttpClienter httpClienter, string uri, string content, CancellationToken cancellationToken)
        {
            return httpClienter.PostAsync(uri, ClientExtends.JsonToStringContent(content) as HttpContent, cancellationToken);
        }
        public static Task<HttpResponseMessage> PostAsync(this IHttpClienter httpClienter, string uri, string content, TimeSpan timeout)
        {
            return httpClienter.PostAsync(uri, ClientExtends.JsonToStringContent(content) as HttpContent, timeout);
        }

        public static async Task<string> PostAndReadStringAsync(this IHttpClienter httpClienter, string uri, string content)
        {
            return await HttpResponseMessageExtends.ReadAsStringAsync(await httpClienter.PostAsync(uri, content));
        }
        public static async Task<string> PostAndReadStringAsync(this IHttpClienter httpClienter, string uri, string content, CancellationToken cancellationToken)
        {
            return await HttpResponseMessageExtends.ReadAsStringAsync(await httpClienter.PostAsync(uri, content, cancellationToken));
        }
        public static async Task<string> PostAndReadStringAsync(this IHttpClienter httpClienter, string uri, string content, TimeSpan timeout)
        {
            return await HttpResponseMessageExtends.ReadAsStringAsync(await httpClienter.PostAsync(uri, content, timeout));
        }

        public static async Task<byte[]> PostAndReadBytesAsync(this IHttpClienter httpClienter, string uri, string content)
        {
            return await HttpResponseMessageExtends.ReadAsByteArrayAsync(await httpClienter.PostAsync(uri, content));
        }
        public static async Task<byte[]> PostAndReadBytesAsync(this IHttpClienter httpClienter, string uri, string content, CancellationToken cancellationToken)
        {
            return await HttpResponseMessageExtends.ReadAsByteArrayAsync(await httpClienter.PostAsync(uri, content, cancellationToken));
        }
        public static async Task<byte[]> PostAndReadBytesAsync(this IHttpClienter httpClienter, string uri, string content, TimeSpan timeout)
        {
            return await HttpResponseMessageExtends.ReadAsByteArrayAsync(await httpClienter.PostAsync(uri, content, timeout));
        }

        public static async Task<TResponse> PostAndReadAsync<TResponse>(this IHttpClienter httpClienter, string uri, string content)
        {
            return JsonExtends.TryDeserialize<TResponse>(await httpClienter.PostAndReadStringAsync(uri, content));
        }
        public static async Task<TResponse> PostAndReadAsync<TResponse>(this IHttpClienter httpClienter, string uri, string content, CancellationToken cancellationToken)
        {
            return JsonExtends.TryDeserialize<TResponse>(await httpClienter.PostAndReadStringAsync(uri, content, cancellationToken));
        }
        public static async Task<TResponse> PostAndReadAsync<TResponse>(this IHttpClienter httpClienter, string uri, string content, TimeSpan timeout)
        {
            return JsonExtends.TryDeserialize<TResponse>(await httpClienter.PostAndReadStringAsync(uri, content, timeout));
        }
        #endregion
        #region TRequest => Any
        public static Task<HttpResponseMessage> PostAsync<TRequest>(this IHttpClienter httpClienter, string uri, TRequest request)
        {
            return httpClienter.PostAsync(uri, JsonExtends.Serialize(request));
        }
        public static Task<HttpResponseMessage> PostAsync<TRequest>(this IHttpClienter httpClienter, string uri, TRequest request, CancellationToken cancellationToken)
        {
            return httpClienter.PostAsync(uri, JsonExtends.Serialize(request), cancellationToken);
        }
        public static Task<HttpResponseMessage> PostAsync<TRequest>(this IHttpClienter httpClienter, string uri, TRequest request, TimeSpan timeout)
        {
            return httpClienter.PostAsync(uri, JsonExtends.Serialize(request), timeout);
        }

        public static async Task<string> PostAndReadStringAsync<TRequest>(this IHttpClienter httpClienter, string uri, TRequest request)
        {
            return await HttpResponseMessageExtends.ReadAsStringAsync(await httpClienter.PostAsync(uri, request));
        }
        public static async Task<string> PostAndReadStringAsync<TRequest>(this IHttpClienter httpClienter, string uri, TRequest request, CancellationToken cancellationToken)
        {
            return await HttpResponseMessageExtends.ReadAsStringAsync(await httpClienter.PostAsync(uri, request, cancellationToken));
        }
        public static async Task<string> PostAndReadStringAsync<TRequest>(this IHttpClienter httpClienter, string uri, TRequest request, TimeSpan timeout)
        {
            return await HttpResponseMessageExtends.ReadAsStringAsync(await httpClienter.PostAsync(uri, request, timeout));
        }

        public static async Task<byte[]> PostAndReadBytesAsync<TRequest>(this IHttpClienter httpClienter, string uri, TRequest request)
        {
            return await HttpResponseMessageExtends.ReadAsByteArrayAsync(await httpClienter.PostAsync(uri, request));
        }
        public static async Task<byte[]> PostAndReadBytesAsync<TRequest>(this IHttpClienter httpClienter, string uri, TRequest request, CancellationToken cancellationToken)
        {
            return await HttpResponseMessageExtends.ReadAsByteArrayAsync(await httpClienter.PostAsync(uri, request, cancellationToken));
        }
        public static async Task<byte[]> PostAndReadBytesAsync<TRequest>(this IHttpClienter httpClienter, string uri, TRequest request, TimeSpan timeout)
        {
            return await HttpResponseMessageExtends.ReadAsByteArrayAsync(await httpClienter.PostAsync(uri, request, timeout));
        }

        public static async Task<TResponse> PostAndReadAsync<TRequest, TResponse>(this IHttpClienter httpClienter, string uri, TRequest request)
        {
            return JsonExtends.TryDeserialize<TResponse>(await httpClienter.PostAndReadStringAsync(uri, JsonExtends.Serialize(request)));
        }
        public static async Task<TResponse> PostAndReadAsync<TRequest, TResponse>(this IHttpClienter httpClienter, string uri, TRequest request, CancellationToken cancellationToken)
        {
            return JsonExtends.TryDeserialize<TResponse>(await httpClienter.PostAndReadStringAsync(uri, JsonExtends.Serialize(request), cancellationToken));
        }
        public static async Task<TResponse> PostAndReadAsync<TRequest, TResponse>(this IHttpClienter httpClienter, string uri, TRequest request, TimeSpan timeout)
        {
            return JsonExtends.TryDeserialize<TResponse>(await httpClienter.PostAndReadStringAsync(uri, JsonExtends.Serialize(request), timeout));
        }
        #endregion
        #endregion
        #region Send
        public static Task<HttpResponseMessage> SendAsync(this IHttpClienter httpClienter, HttpRequestMessage request, TimeSpan timeout)
        {
            return CancellationTokenSourceExtends.InvokeAsync(timeout, token=>httpClienter.SendAsync(request, token));
        }

        public static async Task<string> SendAndReadStringAsync(this IHttpClienter httpClienter, HttpRequestMessage request)
        {
            return await HttpResponseMessageExtends.ReadAsStringAsync(await httpClienter.SendAsync(request));
        }
        public static async Task<string> SendAndReadStringAsync(this IHttpClienter httpClienter, HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return await HttpResponseMessageExtends.ReadAsStringAsync(await httpClienter.SendAsync(request, cancellationToken));
        }
        public static async Task<string> SendAndReadStringAsync(this IHttpClienter httpClienter, HttpRequestMessage request, TimeSpan timeout)
        {
            return await HttpResponseMessageExtends.ReadAsStringAsync(await httpClienter.SendAsync(request, timeout));
        }

        public static async Task<byte[]> SendAndReadBytesAsync(this IHttpClienter httpClienter, HttpRequestMessage request)
        {
            return await HttpResponseMessageExtends.ReadAsByteArrayAsync(await httpClienter.SendAsync(request));
        }
        public static async Task<byte[]> SendAndReadBytesAsync(this IHttpClienter httpClienter, HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return await HttpResponseMessageExtends.ReadAsByteArrayAsync(await httpClienter.SendAsync(request, cancellationToken));
        }
        public static async Task<byte[]> SendAndReadBytesAsync(this IHttpClienter httpClienter, HttpRequestMessage request, TimeSpan timeout)
        {
            return await HttpResponseMessageExtends.ReadAsByteArrayAsync(await httpClienter.SendAsync(request, timeout));
        }

        public static async Task<TResponse> SendAndReadAsync<TResponse>(this IHttpClienter httpClienter, HttpRequestMessage request)
        {
            return JsonExtends.TryDeserialize<TResponse>(await httpClienter.SendAndReadStringAsync(request));
        }
        public static async Task<TResponse> SendAndReadAsync<TResponse>(this IHttpClienter httpClienter, HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return JsonExtends.TryDeserialize<TResponse>(await httpClienter.SendAndReadStringAsync(request, cancellationToken));
        }
        public static async Task<TResponse> SendAndReadAsync<TResponse>(this IHttpClienter httpClienter, HttpRequestMessage request, TimeSpan timeout)
        {
            return JsonExtends.TryDeserialize<TResponse>(await httpClienter.SendAndReadStringAsync(request, timeout));
        }
        #endregion
    }
}