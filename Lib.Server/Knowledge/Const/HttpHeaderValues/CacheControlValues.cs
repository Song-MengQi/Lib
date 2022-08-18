
namespace Lib.Server
{
    public static class CacheControlValues
    {
        public const string NoStore = "no-store";//客户端不准缓存
        public const string NoCache = "no-cache";//客户端可以存储，但是需要去服务端校验（协商缓存）
        public const string Public = "public";//所有内容都将被缓存（客户端和代理服务器都可缓存
        public const string Private = "private";//内容只缓存到私有缓存中（仅客户端可以缓存，代理服务器不可缓存）
        public const string MaxAge60 = "max-age=60";//缓存一分钟
        public const string MaxAge600 = "max-age=600";//缓存十分钟
        public const string MaxAge3600 = "max-age=3600";//缓存一小时
        public const string MaxAge86400 = "max-age=86400";//缓存一日
        public const string MaxAge604800 = "max-age=604800";//缓存一周
        public const string MaxAge2592000 = "max-age=2592000";//缓存一月
        public const string MaxAge31536000 = "max-age=31536000";//缓存一年
    }
}