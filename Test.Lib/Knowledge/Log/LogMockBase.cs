using Lib;
using System;

namespace Test.Lib
{
    public abstract class LogMockBase : MockBase, ILog
    {
        public ConsoleColor ForegroundColor { get { return GetValue<ConsoleColor>(); } set { } }
        public ConsoleColor BackgroundColor { get { return GetValue<ConsoleColor>(); } set { } }
        public bool HasConsole { get { return GetValue<bool>(); } set { } }
        public string FileName { get { return GetValue<string>(); } }
        public void Append(string record) { }
    }
}
