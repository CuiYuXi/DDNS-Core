using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using DDNS.Core.Model;
using DDNS.Core.Model.DNSPod;
using DDNS.Core.Plugin;
using DDNS.Core.Utils;
using Newtonsoft.Json;

namespace DDNS.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region  获取Json文件配置信息
                string path = AppDomain.CurrentDomain.BaseDirectory + "config.json";
                string josnString = File.ReadAllText(path, Encoding.Default);
                ConfigModel configModel = JsonConvert.DeserializeObject<ConfigModel>(josnString);
                var config = configModel.Config.Where(x => x.IsEnable);
                #endregion
                string ipv4 = string.Empty;

                Console.WriteLine("DDNS.Core 1.0.0");
                //Console.WriteLine($"公网ipv4：{ IpHelper.GetPublicIPv4()}");
                while (true)
                {
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
