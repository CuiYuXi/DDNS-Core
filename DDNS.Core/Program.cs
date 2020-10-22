using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Aliyun.Acs.Core.Exceptions;
using DDNS.Core.Model;
using DDNS.Core.Model.DNSPod;
using DDNS.Core.Plugin;
using DDNS.Core.Utils;
using Newtonsoft.Json;

namespace DDNS.Core
{
    class Program
    {
        #region  获取Json文件配置信息
        private static string path = AppDomain.CurrentDomain.BaseDirectory + "config.json";
        private static string josnString = File.ReadAllText(path, Encoding.Default);
        private static ConfigModel configModel = JsonConvert.DeserializeObject<ConfigModel>(josnString);
        //var config = configModel.Config.Where(x => x.IsEnable);
        #endregion
        static void Main(string[] args)
        {
            try
            {               
                string ipv4 = string.Empty;
                Console.WriteLine("DDNS.Core 1.1.1");
                while (true)
                {
                    var config = configModel.Config.Where(x => x.IsEnable);
                    string publicIPv4 = IpHelper.GetPublicIPv4();
                    if (string.IsNullOrEmpty(ipv4) || ipv4 != publicIPv4)
                    {
                        foreach (var item in config)
                        {
                            switch (item.dnsType)
                            {
                                case "dnspod":
                                    Console.WriteLine("\n 【DNSPod】");
                                    DNSPod.Instance().UpdateDNSPod(item, publicIPv4, "");
                                    break;
                                case "alidns":
                                    Console.WriteLine("\n 【alidns】");
                                    AliyunDNS.Instance().UpdateAliyunDNS(item, publicIPv4, "");
                                    break;
                                default:
                                    break;
                            }

                        }
                        ipv4 = publicIPv4;
                        Console.WriteLine($"执行完毕：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
                    }
                    Thread.Sleep(configModel.ThreadSleep);
                    //Console.ReadLine();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
