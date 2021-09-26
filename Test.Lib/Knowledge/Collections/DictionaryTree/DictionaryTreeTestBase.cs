using System;
using System.Collections.Generic;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Lib
{
    public abstract class DictionaryTreeTestBase<T> : TestBase<T>
        where T : DictionaryTreeBase<T, string, string>
    {
        protected Func<string, Dictionary<string, string>>[] getTestData()
        {
            return new Func<string,Dictionary<string,string>>[]{
                (str)=>new Dictionary<string,string>{
                    {"CN","中国"},
                    {"US","United States"},
                },
                (str)=> str == "中国"
                    ? new Dictionary<string, string> {
                        {"CN-11","北京"},
                        {"CN-12","天津"},
                        {"CN-37","山东"},
                    } : new Dictionary<string,string>{
                        {"US-AK","Alaska"},
                        {"US-AL","Alabama"},
                        {"US-AR","Arkansas"},
                    },
                (str) => {
                    switch(str)
                    {
                        case "山东":
                            return new Dictionary<string, string>{
                                {"CN-3701","济南"},
                                {"CN-3702","青岛"},
                                {"CN-3712","莱芜"},
                                {"CN-3713","临沂"},
                            };
                        default:
                            return new Dictionary<string, string>();
                    }
                }
            };
        }
        
        public virtual void TestValue()
        {
            Assert.AreEqual(default(string), Instance.Value);
        }
        public virtual void TestChildrenDic()
        {
            Dictionary<string, T> dic;
            dic = Instance.ChildrenDic;
            Assert.IsNotNull(dic);
            Assert.AreEqual(2, dic.Count);
            Assert.AreEqual("中国", dic["CN"].Value);

            dic = dic["CN"].ChildrenDic;
            Assert.IsNotNull(dic);
            dic = dic["CN-11"].ChildrenDic;
            Assert.IsNull(dic);
        }
        public virtual void TestCount()
        {
            Assert.AreEqual(2, Instance.Count);
        }
        public virtual void TestContainsKey()
        {
            Assert.IsTrue(Instance.ContainsKey("CN"));
            Assert.IsFalse(Instance.ContainsKey("EN"));
        }

        public virtual void TestGetChildValue()
        {
            Assert.AreEqual("中国", Instance.GetChildValue("CN"));
            Assert.AreEqual(default(string), Instance.GetChildValue("EN"));
        }
        public virtual void TestGetChildrenValueDic()
        {
            Dictionary<string, string> dic = Instance.GetChildrenValueDic();
            Assert.IsNotNull(dic);
            Assert.AreEqual(2, dic.Count);
            Assert.AreEqual("中国", dic["CN"]);
        }

        public virtual void TestGetChildrenValues()
        {
            string[] values = Instance.GetChildrenValues();
            Assert.IsNotNull(values);
            Assert.AreEqual(2, values.Length);
        }
        public virtual void TestGetChild()
        {
            T child;
            child = Instance.GetChild("EN");
            Assert.IsNull(child);

            child = Instance.GetChild("CN");
            Assert.IsNotNull(child);
            Assert.AreEqual(3, child.Count);
            Assert.AreEqual("北京", child.GetChildValue("CN-11"));
        }
        public virtual void TestGetChildren()
        {
            T[] childrenTrees;
            childrenTrees = Instance.GetChildren();
            Assert.IsNotNull(childrenTrees);
            Assert.AreEqual(2, childrenTrees.Length);
            Assert.AreEqual("中国", childrenTrees[0].Value);

            childrenTrees = childrenTrees[0].GetChildren();
            Assert.IsNotNull(childrenTrees);
            childrenTrees = childrenTrees[0].GetChildren();
            Assert.IsNull(childrenTrees);
        }
    }
}