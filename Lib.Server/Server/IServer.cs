using System;
using System.Collections.Generic;

namespace Lib.Server
{
    public interface IServer
    {
        //JsGenerater会用
        //Service=>Contract
        Dictionary<Type, Type> ServiceTypeDic { get; }
        void Open();
        void Close();
    }
}