﻿using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    [TestClass]
    public abstract class LogTestBase<T, IT> : NewTestBase<T, IT>
        where T : LogBase, IT, new()
        where IT : class, ILog
    {
        public virtual void TestAppend()
        {
            Instance.Append(GetType().Name);
        }
    }
}