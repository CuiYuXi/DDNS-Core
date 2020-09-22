using System;
using System.Collections.Generic;
using System.Text;
using Aliyun.Acs.Alidns.Model.V20150109;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using DDNS.Core.Model;
using DDNS.Core.Model.AliyunDNS;
using DDNS.Core.Utils;
using Newtonsoft.Json;

namespace DDNS.Core.Plugin
{
    public class AliyunDNS
    {
        private AliyunDNS() { }

        public static AliyunDNS Instance()
        {
            return new AliyunDNS();
        }

        /// <summary>
        /// 获取记录列表
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public OutAliyunDNSVO DescribeDomainRecords(InAliyunDNSVO info)
        {
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", info.accessKeyId, info.accessSecret);
            DefaultAcsClient client = new DefaultAcsClient(profile);
            var request = new DescribeDomainRecordsRequest()
            {
                DomainName = info.DomainName,
                KeyWord = info.KeyWord,
                SearchMode = "EXACT",
                Type = "A"
            };
            var response = client.GetAcsResponse(request);
            return JsonConvert.DeserializeObject<OutAliyunDNSVO>(Encoding.Default.GetString(response.HttpResponse.Content));
        }

        /// <summary>
        /// 修改记录值
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public OutAliyunDNSVO UpdateDomainRecord(InAliyunDNSVO info)
        {
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", info.accessKeyId, info.accessSecret);
            DefaultAcsClient client = new DefaultAcsClient(profile);
            var request = new UpdateDomainRecordRequest()
            {
                RecordId = info.RecordId,
                RR = info.RR,
                _Value = info.Value,
                Type = info.Type
            };
            var response = client.GetAcsResponse(request);
            return JsonConvert.DeserializeObject<OutAliyunDNSVO>(Encoding.Default.GetString(response.HttpResponse.Content));
        }

        /// <summary>
        /// 添加记录值
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public OutAliyunDNSVO AddDomainRecord(InAliyunDNSVO info)
        {
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", info.accessKeyId, info.accessSecret);
            DefaultAcsClient client = new DefaultAcsClient(profile);
            var request = new AddDomainRecordRequest()
            {
                DomainName = info.DomainName,
                RR = info.RR,
                _Value = info.Value,
                Type = info.Type
            };
            var response = client.GetAcsResponse(request);
            return JsonConvert.DeserializeObject<OutAliyunDNSVO>(Encoding.Default.GetString(response.HttpResponse.Content));
        }

        public void UpdateAliyunDNS(ConfigItem item, string ipv4, string ipv6)
        {
            foreach (var ipv4Item in item.ipv4)
            {
                var request = new InAliyunDNSVO()
                {
                    accessKeyId = item.id,
                    accessSecret = item.token,
                    DomainName = ipv4Item.domain,
                    KeyWord = ipv4Item.sub_domain,
                    SearchMode = "EXACT",
                    Type = "A"
                };
                OutAliyunDNSVO domainRecords = DescribeDomainRecords(request);
                List<RecordItem> records = domainRecords.DomainRecords.Record;
                if (records.Count > 0)
                {
                    request.RecordId = records[0].RecordId;
                    request.RR = string.IsNullOrEmpty(ipv4Item.sub_domain) ? "@" : ipv4Item.sub_domain;
                    request.Value = ipv4;
                    if (records[0].Value == ipv4)
                    {
                        Console.WriteLine($"域名主机记录：{records[0].RR}.{ipv4Item.domain}");
                        Console.WriteLine($"域名记录值：{records[0].Value}");
                    }
                    else
                    {
                        OutAliyunDNSVO outUpdateDomainRecord = UpdateDomainRecord(request);
                        if (string.IsNullOrEmpty(outUpdateDomainRecord.Code))
                        {
                            Console.WriteLine($"域名主机记录：{records[0].RR}.{ipv4Item.domain}");
                            Console.WriteLine($"域名记录值更新：{records[0].Value}->{ipv4}");
                        }
                        else
                        {
                            Console.WriteLine(JsonConvert.SerializeObject(outUpdateDomainRecord));
                        }
                    }
                }
                else
                {
                    request.RR = string.IsNullOrEmpty(ipv4Item.sub_domain) ? "@" : ipv4Item.sub_domain;
                    request.Value = ipv4;
                    OutAliyunDNSVO outUpdateDomainRecord = AddDomainRecord(request);
                    if (string.IsNullOrEmpty(outUpdateDomainRecord.Code))
                    {
                        Console.WriteLine($"添加域名主机记录：{request.RR}.{ipv4Item.domain}");
                        Console.WriteLine($"域名记录值：{request.Value}");
                    }
                    else
                    {
                        Console.WriteLine(JsonConvert.SerializeObject(outUpdateDomainRecord));
                    }
                }
            }


        }
    }
}
