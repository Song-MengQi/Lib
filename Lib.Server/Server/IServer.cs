using System;
using System.Collections.Generic;

namespace Lib.Server
{
    public interface IServer
    {
        //Service=>Contract
        Dictionary<Type, Type> ServiceTypeDic { get; }
        void Open();
        void Close();
    }
}