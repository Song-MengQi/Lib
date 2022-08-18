using System;
using System.Collections.Generic;

namespace Lib.Server
{
    public class ServiceItem
    {
        public Type ServiceType { get; set; }
        public Type ContractType { get; set; }
        public BindingType BindingType { get; set; }
    }
    public interface IServer
    {
        List<ServiceItem> ServiceItemList { get; }
        void Open();
        void Close();
    }
}