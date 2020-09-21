using System;
using System.Collections.Generic;

namespace DDNS.Core.Model
{
    public class ConfigModel
    {
        public int ThreadSleep { get; set; }
        public List<ConfigItem> Config { get; set; }
    }
    public class ConfigItem
    {
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; set; }
        /// <summary>
        /// 备注信息可以随便写
        /// </summary>
        public string remark { get; set; }
        public string id { get; set; }
        public string token { get; set; }
        /// <summary>
        /// dnspod 或 alidns 或 dnscom 或 cloudflare 或 he 或 huaweidns 或 callback
        /// </summary>
        public string dnsType { get; set; }
        public List<ipItem> ipv4 { get; set; }
        public List<ipItem> ipv6 { get; set; }
        public int ttl { get; set; }
    }

    public class ipItem {
        public string domain { get; set; }
        public string sub_domain { get; set; }
    }
}
