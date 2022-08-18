using Lib.Json;
using System;

namespace Lib.Timer
{
    public class Config : ConfigBase<Config>
    {
        public TimeSpan PeriodDuration { get; set; }
        public Config() : base()
        {
            PeriodDuration = TimeSpan.FromSeconds(1d);//默认周期粒度为1秒
        }
    }
}