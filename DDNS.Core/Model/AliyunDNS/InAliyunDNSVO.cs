using Aliyun.Acs.Alidns.Model.V20150109;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDNS.Core.Model.AliyunDNS
{
    public class InAliyunDNSVO: DescribeDomainRecordsRequest
    {
        public string accessKeyId { get; set; }
        public string accessSecret { get; set; }
        public string RecordId { get; set; }
        public string Value { get; set; }
        public string RR { get; set; }
    }
}
