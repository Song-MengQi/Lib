using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Lib.Server
{
    public abstract class ServerBase<T, IT> : SingletonBase<T, IT>, IServer
        where T : ServerBase<T, IT>, IT, new()
        where IT : IServer
    {
        public Dictionary<Type, Type> ServiceTypeDic { get; private set; }
        private ServiceHost[] serviceHosts;
        protected ServerBase() : base()
        {
            ServiceTypeDic = new Dictionary<Type, Type>();
        }
        #region private
        private IServiceHostBuilder GetServiceHostBuilder(Type serviceType)
        {
            if (LibServerStringExtends.EndsWithNamedPipeService(serviceType.Name)) return NetNamedPipeServiceHostBuilder.Instance;
            if (LibServerStringExtends.EndsWithTcpService(serviceType.Name)) return NetTcpServiceHostBuilder.Instance;
            if (LibServerStringExtends.EndsWithJsonService(serviceType.Name)) return JsonServiceHostBuilder.Instance;
            return WebHttpServiceHostBuilder.Instance;
        }
        private ServiceHost GetServiceHost(Type serviceType, Type contractType)
        {
            return GetServiceHostBuilder(serviceType).BuildServiceHost(serviceType, contractType);
        }
        #endregion
        public void Open()
        {
            serviceHosts = ServiceTypeDic.Select(kv => GetServiceHost(kv.Key, kv.Value)).ToArray();
            //注册完服务之后，Builder实例就没用了，释放。
            NetNamedPipeServiceHostBuilder.UnsetInstance();
            NetTcpServiceHostBuilder.UnsetInstance();
            JsonServiceHostBuilder.UnsetInstance();
            WebHttpServiceHostBuilder.UnsetInstance();
            foreach (ServiceHost serviceHost in serviceHosts)
            {
                serviceHost.Open();
            }
        }
        public void Close()
        {
            if (default(ServiceHost[]) == serviceHosts) return;
            foreach (ServiceHost serviceHost in serviceHosts)
            {
                serviceHost.Close();
            }
        }
    }
}
