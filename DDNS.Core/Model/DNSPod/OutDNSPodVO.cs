using System;
using System.Collections.Generic;

namespace DDNS.Core.Model.DNSPod
{
    public class OutDNSPodVO
    {
        public Status status { get; set; }
        public Domain domain { get; set; }
        public Info info { get; set; }
        public List<Records> records { get; set; }
        public Record record { get; set; }
    }
    public class Status
    {
        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime created_at { get; set; }
    }

    public class Domain
    {
        /// <summary>
        /// 域名ID，即为 domain_id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 域名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// punycode 转码之后的域名
        /// </summary>
        public string punycode { get; set; }
        /// <summary>
        /// 域名等级，详见 Domain.List 或 Domain.Info 接口
        /// </summary>
        public string grade { get; set; }
        /// <summary>
        /// 域名所有者
        /// </summary>
        public string owner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ext_status { get; set; }
        /// <summary>
        /// 记录的 TTL 值
        /// </summary>
        public int ttl { get; set; }
        /// <summary>
        /// 域名等级对应的ns服务器地址
        /// </summary>
        public List<string> dnspod_ns { get; set; }
    }

    public class Info
    {
        /// <summary>
        /// 指定域名下所有记录的总数
        /// </summary>
        public string sub_domains { get; set; }
        /// <summary>
        /// 指定域名下符合查询条件的记录总数
        /// </summary>
        public string record_total { get; set; }
        /// <summary>
        /// 返回的 records 列表里的记录数目
        /// </summary>
        public string records_num { get; set; }
    }

    public class Records
    {
        /// <summary>
        /// 记录ID编号
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 子域名(主机记录)
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 解析记录的线路, 详见 Record.Line 接口
        /// </summary>
        public string line { get; set; }
        /// <summary>
        /// 解析记录的线路ID，详见 Record.Line 接口
        /// </summary>
        public string line_id { get; set; }
        /// <summary>
        /// 记录类型, 详见 Record.Type 接口
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 记录的 TTL 值
        /// </summary>
        public string ttl { get; set; }
        /// <summary>
        /// 记录值
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string weight { get; set; }
        /// <summary>
        /// 记录的 MX 记录值, 非 MX 记录类型，默认为 0
        /// </summary>
        public string mx { get; set; }
        /// <summary>
        /// 记录状态 “0”: 禁用 “1”: 启用
        /// </summary>
        public string enabled { get; set; }
        /// <summary>
        /// 系统内部标识状态, 开发者可忽略
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 该记录的D监控状态
        ///“Ok”: 服务器正常
        ///“Warn”: 该记录有报警, 服务器返回 4XX
        ///“Down”: 服务器宕机
        ///“”: 该记录未开启D监控
        /// </summary>
        public string monitor_status { get; set; }
        /// <summary>
        ///  记录备注
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 记录最后更新时间
        /// </summary>
        public DateTime updated_on { get; set; }
        /// <summary>
        /// 是否开通网站安全中心 “yes”: 已经开启 “no”: 未开启
        /// </summary>
        public string use_aqb { get; set; }
    }

    public class Record
    {
        /// <summary>
        /// 记录ID, 即为 record_id。
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 子域名(主机记录)
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 域名记录的状态。
        /// </summary>
        public string status { get; set; }
    }
}
