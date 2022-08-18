using System;
using System.ServiceModel;

namespace Lib.Server
{
    public static class Bindings
    {
        public static readonly NetNamedPipeBinding NetNamedPipeBinding = new NetNamedPipeBinding {
            OpenTimeout = TimeSpan.FromSeconds(2),
            CloseTimeout = TimeSpan.FromSeconds(2),
            SendTimeout = TimeSpan.FromSeconds(3600),
            ReceiveTimeout = TimeSpan.FromSeconds(3600),
            //ListenBacklog = Environment.ProcessorCount * 1200,//net 4.5或以上，默认处理器数*12；以前的默认10
            //MaxConnections = Environment.ProcessorCount * 1200,//net 4.5或以上，默认处理器数*12；以前的默认10
            MaxReceivedMessageSize = 1 << 20 | 1 << 12,
            //MaxBufferSize = 1 << 16,
            MaxBufferPoolSize = 1 << 20 | 1 << 12,
            //PortSharingEnabled = true,
            Security = new NetNamedPipeSecurity { Mode = NetNamedPipeSecurityMode.None }
        };

        public static readonly NetTcpBinding NetTcpBinding = new NetTcpBinding {
            OpenTimeout = TimeSpan.FromSeconds(2),
            CloseTimeout = TimeSpan.FromSeconds(2),
            SendTimeout = TimeSpan.FromSeconds(3600),
            ReceiveTimeout = TimeSpan.FromSeconds(3600),
            //ListenBacklog = Environment.ProcessorCount * 1200,//net 4.5或以上，默认处理器数*12；以前的默认10
            //MaxConnections = Environment.ProcessorCount * 1200,//net 4.5或以上，默认处理器数*12；以前的默认10
            MaxReceivedMessageSize = 1 << 20 | 1 << 12,
            //MaxBufferSize = 1 << 16,
            MaxBufferPoolSize = 1 << 20 | 1 << 12,
            //PortSharingEnabled = true,
            ReliableSession = new OptionalReliableSession {
                Enabled = false,
                InactivityTimeout = TimeSpan.FromSeconds(16)
            },
            Security = new NetTcpSecurity { Mode = SecurityMode.None }
        };

        //nginx配置中的client_max_body_size默认1M，限制数据量
        public static readonly WebHttpBinding WebHttpBinding = new WebHttpBinding {
            OpenTimeout = TimeSpan.FromSeconds(2),
            CloseTimeout = TimeSpan.FromSeconds(2),
            SendTimeout = TimeSpan.FromSeconds(16),
            ReceiveTimeout = TimeSpan.FromSeconds(16),
            MaxReceivedMessageSize = 1 << 22 | 1 << 12,
            //MaxBufferSize = 1 << 16,
            MaxBufferPoolSize = 1 << 22 | 1 << 12,
            /*CrossDomainScriptAccessEnabled = true,*/
            ContentTypeMapper = new RawWebContentTypeMapper()
        };//超过4M考虑分段传输
    }
}