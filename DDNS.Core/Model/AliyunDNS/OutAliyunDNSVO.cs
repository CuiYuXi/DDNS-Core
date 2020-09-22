using System;
using System.Collections.Generic;
using System.Text;

namespace DDNS.Core.Model.AliyunDNS
{
    public class OutAliyunDNSVO
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string HostId { get; set; }
        public string Recommend { get; set; }
        public string RecordId { get; set; }
        /// <summary>
        /// 请求ID。
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// 解析记录总数。
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 当前页码。
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// 本次查询获取的解析数量。
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 解析记录列表。
        /// </summary>
        public DomainRecords DomainRecords { get; set; }
    }

    public class RecordItem
    {
        /// <summary>
        /// 域名名称。
        /// </summary>
        public string DomainName { get; set; }
        /// <summary>
        /// 解析记录ID。
        /// </summary>
        public string RecordId { get; set; }
        /// <summary>
        /// 主机记录。
        /// </summary>
        public string RR { get; set; }
        /// <summary>
        /// 记录类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 记录值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 解析线路
        /// </summary>
        public string Line { get; set; }
        /// <summary>
        /// MX记录的优先级
        /// </summary>
        public int Priority { get; set; }
        /// <summary>
        /// 生存时间
        /// </summary>
        public int TTL { get; set; }
        /// <summary>
        /// 当前的解析记录状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 当前解析记录锁定状态
        /// </summary>
        public string Locked { get; set; }
    }

    public class DomainRecords
    {
        /// <summary>
        /// 
        /// </summary>
        public List<RecordItem> Record { get; set; }
    }
}
