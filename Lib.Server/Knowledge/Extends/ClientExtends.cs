using System.ServiceModel;
using System.ServiceModel.Description;

namespace Lib.Server
{
    public static class ClientExtends
    {
        #region Channel
        private static ChannelFactory<IT> CreateNetNamedPipeChannelFactory<IT>()
        {
            return new ChannelFactory<IT>(Bindings.NetNamedPipeBinding, Config.Instance.GetNetNamedPipeAddress(typeof(IT)));
        }
        private static ChannelFactory<IT> CreateNetTcpChannelFactory<IT>(bool isExtranet = false)
        {
            return new ChannelFactory<IT>(Bindings.NetTcpBinding, Config.Instance.GetClientNetTcpAddress(typeof(IT), isExtranet));
        }
        private static ChannelFactory<IT> CreateWebHttpChannelFactory<IT>(bool isExtranet = false)
        {
            ChannelFactory<IT> channelFactory = new ChannelFactory<IT>(Bindings.WebHttpBinding, Config.Instance.GetClientWebHttpAddress(typeof(IT), isExtranet));
            channelFactory.Endpoint.EndpointBehaviors.Add(new WebHttpBehavior());
            return channelFactory;
        }
        private static ChannelFactory<IT> CreateChannelFactory<IT>(BindingType bindingType, bool isExtranet = false)
        {
            switch (bindingType)
            {
                case BindingType.NetNamedPipe:
                    return CreateNetNamedPipeChannelFactory<IT>();
                case BindingType.NetTcp:
                    return CreateNetTcpChannelFactory<IT>(isExtranet);
                default:
                    return CreateWebHttpChannelFactory<IT>(isExtranet);
            }
        }
        public static IT GetChannel<IT>(BindingType bindingType, bool isExtranet = false)
        {
            return ObjectExtends.DefaultThen(IoC<IT>.Instance, ()=>CreateChannelFactory<IT>(bindingType, isExtranet).CreateChannel());
        }
        public static IT GetChannel<IT>(bool isExtranet = false)
        {
            return GetChannel<IT>(ServerExtends.GetDefaultServiceType(typeof(IT)), isExtranet);
        }
        #endregion
        #region DuplexChannel
        private static DuplexChannelFactory<IT> CreateNetNamedPipeDuplexChannelFactory<IT>(object callbackObject)
        {
            return new DuplexChannelFactory<IT>(callbackObject, Bindings.NetNamedPipeBinding, Config.Instance.GetNetNamedPipeAddress(typeof(IT)));
        }
        private static DuplexChannelFactory<IT> CreateNetTcpDuplexChannelFactory<IT>(object callbackObject, bool isExtranet = false)
        {
            return new DuplexChannelFactory<IT>(callbackObject, Bindings.NetTcpBinding, Config.Instance.GetClientNetTcpAddress(typeof(IT), isExtranet));
        }
        private static DuplexChannelFactory<IT> CreateDuplexChannelFactory<IT>(BindingType bindingType, object callbackObject, bool isExtranet = false)
        {
            switch (bindingType)
            {
                case BindingType.NetNamedPipe:
                    return CreateNetNamedPipeDuplexChannelFactory<IT>(callbackObject);
                case BindingType.NetTcp:
                default:
                    return CreateNetTcpDuplexChannelFactory<IT>(callbackObject, isExtranet);
            }
        }
        public static IT GetDuplexChannel<IT>(BindingType bindingType, object callbackObject, bool isExtranet = false)
        {
            return ObjectExtends.DefaultThen(IoC<IT>.Instance, ()=>CreateDuplexChannelFactory<IT>(bindingType, callbackObject, isExtranet).CreateChannel());
        }
        public static IT GetDuplexChannel<IT>(object callbackObject, bool isExtranet = false)
        {
            return GetDuplexChannel<IT>(ServerExtends.GetDefaultServiceType(typeof(IT)), callbackObject, isExtranet);
        }
        #endregion
    }
}