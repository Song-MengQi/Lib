using System;

namespace Lib.Server
{
    public static class LibServerStringExtends
    {
        public const string NamedPipeService = "NamedPipeService";
        public const string TcpService = "TcpService";
        public const string JsonService = "JsonService";
        public const string Service = "Service";
        public static bool EndsWithNamedPipeService(string str)
        {
            return default(string) != str && str.EndsWith(NamedPipeService);
        }
        public static bool EndsWithTcpService(string str)
        {
            return default(string) != str && str.EndsWith(TcpService);
        }
        public static bool EndsWithJsonService(string str)
        {
            return default(string) != str && str.EndsWith(JsonService);
        }

        public static string GetNamespace(Type type)
        {
            return type.Namespace.Replace(".", string.Empty);
        }
        public static string GetNetNamedPipeNameInUrl(string contractName)
        {
            return contractName.TrimOnceStart("I").TrimOnceEnd(NamedPipeService);
        }
        public static string GetNetTcpNameInUrl(string contractName)
        {
            return contractName.TrimOnceStart("I").TrimOnceEnd(TcpService);
        }
        public static string GetWebHttpNameInUrl(string contractName)
        {
            return contractName.TrimOnceStart("I").TrimOnceEnd(Service);
        }
        public static string GetJsonNameInUrl(string contractName)
        {
            return contractName.TrimOnceStart("I").TrimOnceEnd(JsonService);
        }

        public static string GetAddress(string protocol, string path)
        {
            return string.Format("{0}://{1}", protocol, path);
        }
        public static string GetAddress(string protocol, string host, ushort port, string path)
        {
            return string.Format("{0}://{1}:{2}/{3}", protocol, host, port, path);
        }
    }
}