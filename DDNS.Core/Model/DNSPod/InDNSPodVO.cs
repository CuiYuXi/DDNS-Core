using System;
namespace DDNS.Core.Model.DNSPod
{
    public class InDNSPodVO
    {
        /// <summary>
        /// token后台生成的密钥
        /// </summary>
        public string login_token { get; set; }
        /// <summary>
        /// 域名, 域名ID和域名提交其中一个即可。
        /// </summary>
        public string domain { get; set; }
        /// <summary>
        /// 域名ID, 域名ID和域名提交其中一个即可。
        /// </summary>
        public string domain_id { get; set; }
        /// <summary>
        /// 子域名，如果指定则只返回此子域名的记录。
        /// </summary>
        public string sub_domain { get; set; }
        /// <summary>
        /// 记录开始的偏移，第一条记录为 0，依次类推（仅当指定 length 参数时才生效）。
        /// </summary>
        public string offset { get; set; }
        /// <summary>
        /// 共要获取的记录数量的最大值，比如最多获取20条，则为20，最大3000。
        /// </summary>
        public string length { get; set; }
        /// <summary>
        /// 记录类型，通过API记录类型获得，大写英文，比如：A。
        /// </summary>
        public string record_type { get; set; }
        /// <summary>
        /// 记录线路，通过API记录线路获得，中文，比如：默认。
        /// </summary>
        public string record_line { get; set; }
        /// <summary>
        /// 线路的ID，通过API记录线路获得，英文字符串，比如：10=1。需要获取特定线路的解析记录时，record_line 和 record_line_id 二者传其一即可，系统优先取 record_line_id 。
        /// </summary>
        public string record_line_id { get; set; }
        /// <summary>
        /// 搜索的关键字，如果指定则只返回符合该关键字的记录， 指定 keyword 后系统忽略查询参数 sub_domain，record_type，record_line，record_line_id 。
        /// </summary>
        public string keyword { get; set; }
        /// <summary>
        /// 记录ID。
        /// </summary>
        public string record_id { get; set; }
        /// <summary>
        /// 记录值, 如 IP:200.200.200.200, CNAME: cname.dnspod.com., MX: mail.dnspod.com. 。
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// MX优先级, 当记录类型是 MX 时有效，范围1-20。
        /// </summary>
        public int mx { get; set; }
        /// <summary>
        /// TTL，范围1-604800，不同等级域名最小值不同。
        /// </summary>
        public int ttl { get; set; }
        /// <summary>
        /// 记录状态，默认为”enable”，如果传入”disable”，解析不会生效，也不会验证负载均衡的限制。
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 权重信息，0到100的整数。仅企业 VIP 域名可用，0 表示关闭，留空或者不传该参数，表示不设置权重信息。
        /// </summary>
        public string weight { get; set; }
    }
}
