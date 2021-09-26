using System;
using System.Threading;

namespace Lib
{
    public static class ThreadPoolExtends
    {
        //把工作线程数的Min和Max都设置成同一个值，不要动态调控，禁用并发限制算法
        //有效区间[Environment.ProcessorCount, short.MaxValue]
        public static int WorkerThreadCount
        {
            get { return WorkerThreadCountMin; }
            set
            {
                int workerThreadsMin;//默认物理线程数
                int completionPortThreadsMin;//默认物理线程数
                int workerThreadsMax;//64位默认32767，32位默认1000
                int completionPortThreadsMax;//默认1000
                ThreadPool.GetMinThreads(out workerThreadsMin, out completionPortThreadsMin);
                ThreadPool.GetMaxThreads(out workerThreadsMax, out completionPortThreadsMax);

                int count = MathExtends.Clip(value, Environment.ProcessorCount, short.MaxValue);
                //一定有workerThreadsMin<workerThreadsMax
                //completionPortThreadsMin和completionPortThreadsMax不管，保持原值
                if (value > workerThreadsMax)
                {
                    ThreadPool.SetMaxThreads(count, completionPortThreadsMax);
                    ThreadPool.SetMinThreads(count, completionPortThreadsMin);
                }
                else
                {
                    ThreadPool.SetMinThreads(count, completionPortThreadsMin);
                    ThreadPool.SetMaxThreads(count, completionPortThreadsMax);
                }
            }
        }
        //有效区间[Environment.ProcessorCount, workerThreadsMax]
        public static int WorkerThreadCountMin
        {
            get
            {
                int workerThreadsMin;
                int completionPortThreadsMin;
                ThreadPool.GetMinThreads(out workerThreadsMin, out completionPortThreadsMin);
                return workerThreadsMin;
            }
            set
            {
                int workerThreadsMin;//默认物理线程数
                int completionPortThreadsMin;//默认物理线程数
                int workerThreadsMax;//64位默认32767，32位默认1000
                int completionPortThreadsMax;//默认1000
                ThreadPool.GetMinThreads(out workerThreadsMin, out completionPortThreadsMin);
                ThreadPool.GetMaxThreads(out workerThreadsMax, out completionPortThreadsMax);

                int count = MathExtends.Clip(value, Environment.ProcessorCount, workerThreadsMax);
                ThreadPool.SetMinThreads(count, completionPortThreadsMin);
            }
        }
        //有效区间[workerThreadsMin, short.MaxValue]
        public static int WorkerThreadCountMax
        {
            get
            {
                int workerThreadsMax;
                int completionPortThreadsMax;
                ThreadPool.GetMaxThreads(out workerThreadsMax, out completionPortThreadsMax);
                return workerThreadsMax;
            }
            set
            {
                int workerThreadsMin;//默认物理线程数
                int completionPortThreadsMin;//默认物理线程数
                int workerThreadsMax;//64位默认32767，32位默认1000
                int completionPortThreadsMax;//默认1000
                ThreadPool.GetMinThreads(out workerThreadsMin, out completionPortThreadsMin);
                ThreadPool.GetMaxThreads(out workerThreadsMax, out completionPortThreadsMax);

                int count = MathExtends.Clip(value, workerThreadsMin, short.MaxValue);
                ThreadPool.SetMaxThreads(count, completionPortThreadsMax);
            }
        }
    }
}