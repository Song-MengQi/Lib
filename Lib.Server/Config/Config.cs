using Lib.Json;

namespace Lib.Server
{
    public class Config : ConfigBase<Config>
    {
        public Config() : base()
        {
            DefaultIntranetHost = default(string);
            DefaultExtranetHost = default(string);
            IntranetHostDic = new ListDictionary<string, string>();
            ExtranetHostDic = new ListDictionary<string, string>();

            DefaultWebHttpPort = (ushort)0;
            DefaultNetTcpPort = (ushort)0;
            PortDic = new ListDictionary<string, ushort>();

            PathDic = new ListDictionary<string, string>();
        }
        #region Ip
        public string DefaultIntranetHost { get; set; }
        public string DefaultExtranetHost { get; set; }
        //NameSpace=>Host
        public ListDictionary<string, string> IntranetHostDic { get; set; }
        public ListDictionary<string, string> ExtranetHostDic { get; set; }
        #endregion

        #region Port
        public ushort DefaultWebHttpPort { get; set; }
        public ushort DefaultNetTcpPort { get; set; }
        //ContractType.FullName=>Port
        public ListDictionary<string, ushort> PortDic { get; set; }
        #endregion

        #region Path
        //ContractType.FullName=>Path
        public ListDictionary<string, string> PathDic { get; set; }
        #endregion
    }
}