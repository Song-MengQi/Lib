using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Lib.Server
{
    public static class Clients
    {
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
        private static ChannelFactory<IT> CreateChannelFactory<IT>(bool isExtranet = false)
        {
            string name = typeof(IT).Name;
            if (LibServerStringExtends.EndsWithNamedPipeService(name)) return CreateNetNamedPipeChannelFactory<IT>();
            if (LibServerStringExtends.EndsWithTcpService(name)) return CreateNetTcpChannelFactory<IT>(isExtranet);
            return CreateWebHttpChannelFactory<IT>(isExtranet);
        }
        public static IT GetChannel<IT>(bool isExtranet = false)
        {
            //return ObjectExtends.DefaultThen(IoC<IT>.Instance, CreateChannelFactory<IT>(isExtranet).CreateChannel);
            return ObjectExtends.DefaultThen(IoC<IT>.Instance, ()=>CreateChannelFactory<IT>(isExtranet).CreateChannel());
        }
        private static DuplexChannelFactory<IT> CreateDuplexChannelFactory<IT>(object callbackObject, bool isExtranet = false)
        {
            Type type = typeof(IT);
            string name = type.Name;
            if (LibServerStringExtends.EndsWithNamedPipeService(name)) return new DuplexChannelFactory<IT>(callbackObject, Bindings.NetNamedPipeBinding, Config.Instance.GetNetNamedPipeAddress(type));
            //if (LibServerStringExtends.EndsWithTcpService(name)) return new DuplexChannelFactory<IT>(callbackObject, Bindings.NetTcpBinding, Config.Instance.GetClientNetTcpAddress(type, isExtranet));
            return new DuplexChannelFactory<IT>(callbackObject, Bindings.NetTcpBinding, Config.Instance.GetClientNetTcpAddress(type, isExtranet));
        }
        public static IT GetDuplexChannel<IT>(object callbackObject, bool isExtranet = false)
        {
            //return ObjectExtends.DefaultThen(IoC<IT>.Instance, CreateDuplexChannelFactory<IT>(callbackObject, isExtranet).CreateChannel);
            return ObjectExtends.DefaultThen(IoC<IT>.Instance, ()=>CreateDuplexChannelFactory<IT>(callbackObject, isExtranet).CreateChannel());
        }
    }
}