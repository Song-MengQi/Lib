using System;

namespace Lib.Server
{
    public static class ConfigExtend
    {
        #region Host
        public const string Localhost = "localhost";
        public static string GetServerHost(this Config config, string nameSpace, bool isExtranet = false)
        {
            return (isExtranet
                ? config.ExtranetHostDic[nameSpace] ?? config.DefaultExtranetHost
                : config.IntranetHostDic[nameSpace] ?? config.DefaultIntranetHost
                ) ?? Localhost;
        }
        #endregion

        #region Port
        public static ushort GetWebHttpPort(this Config config, Type contractType)
        {
            return config.PortDic.Contains(contractType.FullName)
                ? config.PortDic[contractType.FullName]
                : config.DefaultWebHttpPort;
        }
        public static ushort GetNetTcpPort(this Config config, Type contractType)
        {
            return config.PortDic.Contains(contractType.FullName)
                ? config.PortDic[contractType.FullName]
                : config.DefaultNetTcpPort;
        }
        #endregion

        #region GetPath
        public static string GetNetNamedPipePath(this Config config, Type contractType)
        {
            return config.PathDic.Contains(contractType.FullName)
                ? config.PathDic[contractType.FullName]
                : string.Format("{0}/{1}", LibServerStringExtends.GetNamespace(contractType), LibServerStringExtends.GetNetNamedPipeNameInUrl(contractType.Name));
        }
        public static string GetNetTcpPath(this Config config, Type contractType)
        {
            return config.PathDic.Contains(contractType.FullName)
                ? config.PathDic[contractType.FullName]
                : string.Format("api/{0}/{1}", LibServerStringExtends.GetNamespace(contractType), LibServerStringExtends.GetNetTcpNameInUrl(contractType.Name));
        }
        public static string GetWebHttpPath(this Config config, Type contractType)
        {
            return config.PathDic.Contains(contractType.FullName)
                ? config.PathDic[contractType.FullName]
                : string.Format("api/{0}/{1}", LibServerStringExtends.GetNamespace(contractType), LibServerStringExtends.GetWebHttpNameInUrl(contractType.Name));
        }
        public static string GetJsonPath(this Config config, Type contractType)
        {
            return config.PathDic.Contains(contractType.FullName)
                ? config.PathDic[contractType.FullName]
                : string.Format("api/{0}/{1}", LibServerStringExtends.GetNamespace(contractType), LibServerStringExtends.GetJsonNameInUrl(contractType.Name));
        }
        #endregion

        #region GetAddress
        public static string GetNetNamedPipeAddress(this Config config, Type contractType)
        {
            return LibServerStringExtends.GetAddress("net.pipe", GetNetNamedPipePath(config, contractType));
        }

        private static string GetNetTcpAddress(this Config config, string host, Type contractType)
        {
            return LibServerStringExtends.GetAddress("net.tcp", host, GetNetTcpPort(config, contractType), GetNetTcpPath(config, contractType));
        }
        private static string GetWebHttpAddress(this Config config, string host, Type contractType)
        {
            return LibServerStringExtends.GetAddress("http", host, GetWebHttpPort(config, contractType), GetWebHttpPath(config, contractType));
        }
        private static string GetJsonAddress(this Config config, string host, Type contractType)
        {
            return LibServerStringExtends.GetAddress("http", host, GetWebHttpPort(config, contractType), GetJsonPath(config, contractType));
        }

        public static string GetServerNetTcpAddress(this Config config, Type contractType)
        {
            return GetNetTcpAddress(config, Localhost, contractType);
        }
        public static string GetServerWebHttpAddress(this Config config, Type contractType)
        {
            return GetWebHttpAddress(config, Localhost, contractType);
        }
        public static string GetServerJsonAddress(this Config config, Type contractType)
        {
            return GetJsonAddress(config, Localhost, contractType);
        }

        public static string GetClientNetTcpAddress(this Config config, Type contractType, bool isExtranet = false)
        {
            return GetNetTcpAddress(config, GetServerHost(config, contractType.Namespace, isExtranet), contractType);
        }
        public static string GetClientWebHttpAddress(this Config config, Type contractType, bool isExtranet = false)
        {
            return GetWebHttpAddress(config, GetServerHost(config, contractType.Namespace, isExtranet), contractType);
        }
        public static string GetClientJsonAddress(this Config config, Type contractType, bool isExtranet = false)
        {
            return GetJsonAddress(config, GetServerHost(config, contractType.Namespace, isExtranet), contractType);
        }
        #endregion
    }
}