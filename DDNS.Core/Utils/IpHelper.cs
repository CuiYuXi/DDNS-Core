using System;
using System.Text.RegularExpressions;

namespace DDNS.Core.Utils
{
    public class IpHelper
    {
        public static string GetPublicIPv4()
        {
            //ipv4正则
            string reg = "((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])";
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                //万网ipv4接口备用：http://www.net.cn/static/customercare/yourip.asp
                URL = $"https://pv.sohu.com/cityjson?ie=utf-8",
                Method = "get"
            };
            HttpResult result = http.GetHtml(item);
            Match m = Regex.Match(result.Html, reg);
            if (m.Success)
            {
                return m.Value;
            }
            return result.Html;
        }

        public static string GetPublicIpv6()
        {
            return "";
        }
    }
}
