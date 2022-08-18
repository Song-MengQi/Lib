using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Lib.Server
{
    public static class ServerExtends
    {
        public const string NamedPipeService = "NamedPipeService";
        public const string TcpService = "TcpService";
        public const string Service = "Service";
        public static bool EndsWithNamedPipeService(string str)
        {
            return default(string) != str && str.EndsWith(NamedPipeService);
        }
        public static bool EndsWithTcpService(string str)
        {
            return default(string) != str && str.EndsWith(TcpService);
        }
        public static BindingType GetDefaultServiceType(Type serviceType)
        {
            if (ServerExtends.EndsWithNamedPipeService(serviceType.Name)) return BindingType.NetNamedPipe;
            if (ServerExtends.EndsWithTcpService(serviceType.Name)) return BindingType.NetTcp;
            return BindingType.WebHttp;
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

        public static string GetAddress(string protocol, string path)
        {
            return string.Format("{0}://{1}", protocol, path);
        }
        public static string GetAddress(string protocol, string host, ushort port, string path)
        {
            return string.Format("{0}://{1}:{2}/{3}", protocol, host, port, path);
        }


        public static IT GetCallbackChannel<IT>()
        {
            //return ObjectExtends.DefaultThen(IoC<IT>.Instance, OperationContext.Current.GetCallbackChannel<IT>);
            return ObjectExtends.DefaultThen(IoC<IT>.Instance, ()=>OperationContext.Current.GetCallbackChannel<IT>());
        }

        public static RemoteEndpointMessageProperty GetRemoteEndpointMessageProperty()
        {
            try { return OperationContext.Current.IncomingMessageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty; }
            catch { return default(RemoteEndpointMessageProperty); }
        }
        public static TcpConfig GetTcpConfig()
        {
            RemoteEndpointMessageProperty remoteEndpointMessageProperty = GetRemoteEndpointMessageProperty();
            return default(RemoteEndpointMessageProperty) == remoteEndpointMessageProperty
                ? default(TcpConfig)
                : new TcpConfig {
                    Host = remoteEndpointMessageProperty.Address,
                    Port = (ushort)remoteEndpointMessageProperty.Port,
                };
        }
        #region Port
        public static bool IsInUsePort(ushort port)
        {
            return IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpListeners().Any(ipEndPoint=>ipEndPoint.Port==port);
        }
        public static bool CanUsePort(ushort port)
        {
            return port>(ushort)0 && false==IsInUsePort(port);
        }
        public static IEnumerable<ushort> UsedPorts
        {
            get
            {
                foreach (ServiceItem serviceItem in Server.Instance.ServiceItemList)
                {
                    switch (serviceItem.BindingType)
                    {
                        case BindingType.NetNamedPipe:
                            break;
                        case BindingType.NetTcp:
                            yield return Config.Instance.GetNetTcpPort(serviceItem.ContractType);
                            break;
                        default:
                            yield return Config.Instance.GetWebHttpPort(serviceItem.ContractType);
                            break;
                    }
                }
            }
        }
        #endregion
    }
}