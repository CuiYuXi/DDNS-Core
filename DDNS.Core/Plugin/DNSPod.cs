using System;
using System.Collections.Generic;
using System.Linq;
using DDNS.Core.Model;
using DDNS.Core.Model.DNSPod;
using DDNS.Core.Utils;
using Newtonsoft.Json;

namespace DDNS.Core.Plugin
{
    public class DNSPod
    {
        private DNSPod() { }

        public static DNSPod Instance()
        {
            return new DNSPod();
        }

        /// <summary>
        /// 获取记录列表。
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public OutDNSPodVO RecordList(InDNSPodVO info)
        {
            Console.WriteLine("domain:" + info.domain);
            info.domain = !string.IsNullOrEmpty(info.domain) ? $"&domain={info.domain}" : $"&domain_id={info.domain_id}";
            Console.WriteLine("参数：" + JsonConvert.SerializeObject(info));
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                ContentType = "application/x-www-form-urlencoded",
                UserAgent = "DDNS-Core/1.0(cuiyuxi@foxmail.com)",
                Method = "post",
                URL = $"https://dnsapi.cn/Record.List",
                Postdata = $"login_token={info.login_token}&format=json{info.domain}&offset={info.offset}&length={info.length}" +
                          $"&sub_domain={info.sub_domain}&record_type={info.record_type}&record_line={info.record_line}" +
                          $"&record_line_id={info.record_line_id}&keyword={info.keyword}",
            };
            HttpResult result = http.GetHtml(item);
            
            Console.WriteLine("Log:" + result.Html);
            return JsonConvert.DeserializeObject<OutDNSPodVO>(result.Html);
        }

        /// <summary>
        /// 修改记录值
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public OutDNSPodVO RecordModify(InDNSPodVO info)
        {
            info.domain = !string.IsNullOrEmpty(info.domain) ? $"&domain={info.domain}" : $"&domain_id={info.domain_id}";

            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                ContentType = "application/x-www-form-urlencoded",
                UserAgent = "DDNS-Core/1.0(cuiyuxi@foxmail.com)",
                Method = "post",
                URL = $"https://dnsapi.cn/Record.Modify",
                Postdata = $"login_token={info.login_token}&format=json{info.domain}&record_id={info.record_id}&sub_domain={info.sub_domain}" +
                $"&record_type={info.record_type}&record_line={info.record_line}&value={info.value}" +
                $"&mx={info.mx}&ttl={info.ttl}&status={info.status}&weight={info.weight}"
            };
            HttpResult result = http.GetHtml(item);
            return JsonConvert.DeserializeObject<OutDNSPodVO>(result.Html);
        }

        /// <summary>
        /// 添加记录值
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public OutDNSPodVO RecordCreate(InDNSPodVO info)
        {
            info.domain = !string.IsNullOrEmpty(info.domain) ? $"&domain={info.domain}" : $"&domain_id={info.domain_id}";

            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                ContentType = "application/x-www-form-urlencoded",
                UserAgent = "DDNS-Core/1.0(cuiyuxi@foxmail.com)",
                Method = "post",
                URL = $"https://dnsapi.cn/Record.Create",
                Postdata = $"login_token={info.login_token}&format=json{info.domain}&sub_domain={info.sub_domain}" +
                $"&record_type={info.record_type}&record_line={info.record_line}&value={info.value}" +
                $"&mx={info.mx}&ttl={info.ttl}&status={info.status}&weight={info.weight}"
            };
            HttpResult result = http.GetHtml(item);
            return JsonConvert.DeserializeObject<OutDNSPodVO>(result.Html);
        }

        /// <summary>
        /// 更新DNSPod记录
        /// </summary>
        /// <param name="item"></param>
        /// <param name="ipv4"></param>
        /// <param name="ipv6"></param>
        public void UpdateDNSPod(ConfigItem item, string ipv4, string ipv6)
        {
            foreach (var ipv4Item in item.ipv4)
            {
                InDNSPodVO info = new InDNSPodVO()
                {
                    login_token = $"{item.id},{item.token}",
                    domain = ipv4Item.domain,
                    sub_domain = string.IsNullOrEmpty(ipv4Item.sub_domain) ? "" : ipv4Item.sub_domain,
                    record_type = "A",
                    record_line = "默认"
                };
                OutDNSPodVO recordList = RecordList(info);
                List<Records> records = recordList.records;
                if (records != null)
                {
                    info.record_id = records[0].id;
                    info.value = ipv4.Trim();
                    if (records[0].value == ipv4.Trim())
                    {
                        Console.WriteLine($"域名主机记录：{records[0].name}.{ipv4Item.domain}");
                        Console.WriteLine($"域名记录值：{records[0].value}");
                    }
                    else
                    {
                        OutDNSPodVO outRecordModify = RecordModify(info);
                        if (outRecordModify.status.code == "1")
                        {
                            Console.WriteLine($"域名主机记录：{records[0].name}.{ipv4Item.domain}");
                            Console.WriteLine($"域名记录值更新：{records[0].value}->{ipv4.Trim()}");
                        }
                        else
                        {
                            Console.WriteLine(JsonConvert.SerializeObject(outRecordModify.status));
                        }
                    }

                }
                else
                {
                    info.value = ipv4;
                    OutDNSPodVO outRecordCreate = RecordCreate(info);
                    if (outRecordCreate.status.code == "1")
                    {
                        Console.WriteLine($"添加域名主机记录：{info.sub_domain}.{ipv4Item.domain}");
                        Console.WriteLine($"域名记录值：{info.value}");
                    }
                    else
                    {
                        Console.WriteLine(JsonConvert.SerializeObject(outRecordCreate.status));
                    }
                }
            }
        }
    }
}
