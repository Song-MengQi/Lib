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
        public static async Task<HttpResponseMessage> GetAsync(this IHttpClienter httpClienter, string uri, TimeSpan timeout)
        {
            return await httpClienter.GetAsync(uri, new CancellationTokenSource(timeout).Token);
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
            return Jsons.TryDeserialize<TResponse>(await httpClienter.GetStringAsync(uri));
        }
        public static async Task<TResponse> GetAsync<TResponse>(this IHttpClienter httpClienter, string uri, CancellationToken cancellationToken)
        {
            return Jsons.TryDeserialize<TResponse>(await httpClienter.GetStringAsync(uri, cancellationToken));
        }
        public static async Task<TResponse> GetAsync<TResponse>(this IHttpClienter httpClienter, string uri, TimeSpan timeout)
        {
            return Jsons.TryDeserialize<TResponse>(await httpClienter.GetStringAsync(uri, timeout));
        }
        #endregion
        #region Post
        #region HttpContent => Any
        public static async Task<HttpResponseMessage> PostAsync(this IHttpClienter httpClienter, string uri, HttpContent httpContent, TimeSpan timeout)
        {
            return await httpClienter.PostAsync(uri, httpContent, new CancellationTokenSource(timeout).Token);
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
            return Jsons.TryDeserialize<TResponse>(await httpClienter.PostAndReadStringAsync(uri, httpContent));
        }
        public static async Task<TResponse> PostAndReadAsync<TResponse>(this IHttpClienter httpClienter, string uri, HttpContent httpContent, CancellationToken cancellationToken)
        {
            return Jsons.TryDeserialize<TResponse>(await httpClienter.PostAndReadStringAsync(uri, httpContent, cancellationToken));
        }
        public static async Task<TResponse> PostAndReadAsync<TResponse>(this IHttpClienter httpClienter, string uri, HttpContent httpContent, TimeSpan timeout)
        {
            return Jsons.TryDeserialize<TResponse>(await httpClienter.PostAndReadStringAsync(uri, httpContent, timeout));
        }
        #endregion
        #region string => Any
        public static async Task<HttpResponseMessage> PostAsync(this IHttpClienter httpClienter, string uri, string content)
        {
            return await httpClienter.PostAsync(uri, LibClientExtends.JsonToStringContent(content) as HttpContent);
        }
        public static async Task<HttpResponseMessage> PostAsync(this IHttpClienter httpClienter, string uri, string content, CancellationToken cancellationToken)
        {
            return await httpClienter.PostAsync(uri, LibClientExtends.JsonToStringContent(content) as HttpContent, cancellationToken);
        }
        public static async Task<HttpResponseMessage> PostAsync(this IHttpClienter httpClienter, string uri, string content, TimeSpan timeout)
        {
            return await httpClienter.PostAsync(uri, LibClientExtends.JsonToStringContent(content) as HttpContent, timeout);
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
            return Jsons.TryDeserialize<TResponse>(await httpClienter.PostAndReadStringAsync(uri, content));
        }
        public static async Task<TResponse> PostAndReadAsync<TResponse>(this IHttpClienter httpClienter, string uri, string content, CancellationToken cancellationToken)
        {
            return Jsons.TryDeserialize<TResponse>(await httpClienter.PostAndReadStringAsync(uri, content, cancellationToken));
        }
        public static async Task<TResponse> PostAndReadAsync<TResponse>(this IHttpClienter httpClienter, string uri, string content, TimeSpan timeout)
        {
            return Jsons.TryDeserialize<TResponse>(await httpClienter.PostAndReadStringAsync(uri, content, timeout));
        }
        #endregion
        #region TRequest => Any
        public static async Task<HttpResponseMessage> PostAsync<TRequest>(this IHttpClienter httpClienter, string uri, TRequest request)
        {
            return await httpClienter.PostAsync(uri, Jsons.Serialize(request));
        }
        public static async Task<HttpResponseMessage> PostAsync<TRequest>(this IHttpClienter httpClienter, string uri, TRequest request, CancellationToken cancellationToken)
        {
            return await httpClienter.PostAsync(uri, Jsons.Serialize(request), cancellationToken);
        }
        public static async Task<HttpResponseMessage> PostAsync<TRequest>(this IHttpClienter httpClienter, string uri, TRequest request, TimeSpan timeout)
        {
            return await httpClienter.PostAsync(uri, Jsons.Serialize(request), timeout);
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
            return Jsons.TryDeserialize<TResponse>(await httpClienter.PostAndReadStringAsync(uri, Jsons.Serialize(request)));
        }
        public static async Task<TResponse> PostAndReadAsync<TRequest, TResponse>(this IHttpClienter httpClienter, string uri, TRequest request, CancellationToken cancellationToken)
        {
            return Jsons.TryDeserialize<TResponse>(await httpClienter.PostAndReadStringAsync(uri, Jsons.Serialize(request), cancellationToken));
        }
        public static async Task<TResponse> PostAndReadAsync<TRequest, TResponse>(this IHttpClienter httpClienter, string uri, TRequest request, TimeSpan timeout)
        {
            return Jsons.TryDeserialize<TResponse>(await httpClienter.PostAndReadStringAsync(uri, Jsons.Serialize(request), timeout));
        }
        #endregion
        #endregion
        #region Send
        public static async Task<HttpResponseMessage> SendAsync(this IHttpClienter httpClienter, HttpRequestMessage request, TimeSpan timeout)
        {
            return await httpClienter.SendAsync(request, new CancellationTokenSource(timeout).Token);
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
            return Jsons.TryDeserialize<TResponse>(await httpClienter.SendAndReadStringAsync(request));
        }
        public static async Task<TResponse> SendAndReadAsync<TResponse>(this IHttpClienter httpClienter, HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Jsons.TryDeserialize<TResponse>(await httpClienter.SendAndReadStringAsync(request, cancellationToken));
        }
        public static async Task<TResponse> SendAndReadAsync<TResponse>(this IHttpClienter httpClienter, HttpRequestMessage request, TimeSpan timeout)
        {
            return Jsons.TryDeserialize<TResponse>(await httpClienter.SendAndReadStringAsync(request, timeout));
        }
        #endregion
    }
}