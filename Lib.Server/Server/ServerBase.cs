using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Lib.Server
{
    public abstract class ServerBase<T, IT> : SingletonBase<T, IT>, IServer
        where T : ServerBase<T, IT>, IT, new()
        where IT : IServer
    {
        public List<ServiceItem> ServiceItemList { get; private set; }
        private ServiceHost[] serviceHosts;
        protected ServerBase() : base()
        {
            ServiceItemList = new List<ServiceItem>();
        }
        #region private
        private IServiceHostBuilder GetServiceHostBuilder(BindingType bindingType)
        {
            switch (bindingType)
            {
                case BindingType.NetNamedPipe:
                    return NetNamedPipeServiceHostBuilder.Instance;
                case BindingType.NetTcp:
                    return NetTcpServiceHostBuilder.Instance;
                default:
                    return WebHttpServiceHostBuilder.Instance;
            }
        }
        private ServiceHost GetServiceHost(ServiceItem serviceItem)
        {
            return GetServiceHostBuilder(serviceItem.BindingType).BuildServiceHost(serviceItem.ServiceType, serviceItem.ContractType);
        }
        #endregion
        public void Open()
        {
            serviceHosts = ServiceItemList.Select(GetServiceHost).ToArray();
            //注册完服务之后，Builder实例就没用了，释放。
            NetNamedPipeServiceHostBuilder.UnsetInstance();
            NetTcpServiceHostBuilder.UnsetInstance();
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
            serviceHosts = default(ServiceHost[]);
        }
    }
}
