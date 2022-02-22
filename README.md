# DDNS-Core

自动更新 DNS 解析 到公网 IP 地址,支持 ipv4 和 ipv6。
支持自动创建域名记录。

> 找了一圈没有合适的就自己写一个吧 初次提交 些许潦草 先解自己燃眉之急 后面慢慢优化
> 目前只支持[DNSPod,alidns] ipv4 后期会慢慢扩展其他服务商和 ipv6

## Features

- 兼容和跨平台:
- [x] 可执行文件
- [x] 多系统兼容
- [ ] Docker 支持
- 域名支持：
 - [x] 多个域名支持
 - [x] 多级域名解析
 - [x] 自动创建新记录
- IP 类型:
  - [ ] 内网 IPv4 / IPv6
  - [x] 公网 IPv4 / IPv6
- 服务商支持:
  - [x] [DNSPOD](https://www.dnspod.cn/)
  - [x] [阿里 DNS](http://www.alidns.com/)
  - [ ] [DNS.COM](https://www.dns.com/)
  - [ ] [DNSPOD 国际版](https://www.dnspod.com/)
  - [ ] [CloudFlare](https://www.cloudflare.com/)
  - [ ] [HE.net](https://dns.he.net/)
  - [ ] [华为云](https://huaweicloud.com/)
 
## 使用

### ① 安装

- #### 二进制版
- Windows [DDNS.Core-win-x86](https://github.com/CuiYuXi/DDNS-Core/releases)
- Linux [DDNS.Core-linux-x64](https://github.com/CuiYuXi/DDNS-Core/releases)
- Mac OSX 敬请期待

#### 各平台下载/使用方式
<details>
 <summary markdown="span">Windows</summary>
 
1.下载DDNS.Core-win-x86.zip    
2.解压后 运行文件夹 DDNS.Core.exe  
</details>

<details>
 <summary markdown="span">Linux</summary>
 
1.下载DDNS.Core-linux-x64  
2.解压后 运行文件夹 DDNS.Core
</details>

### ② 快速配置

1. 申请 api `token`,填写到对应的`id`和`token`字段:

   - [DNSPOD(国内版)创建 token](https://support.dnspod.cn/Kb/showarticle/tsid/227/)
   - [阿里云 accesskey](https://help.aliyun.com/document_detail/28637.html)
   - [DNS.COM API Key/Secret](https://www.dns.com/member/apiSet)
   - [DNSPOD(国际版)](https://www.dnspod.com/docs/info.html#get-the-user-token)
   - [CloudFlare API Key](https://support.cloudflare.com/hc/en-us/articles/200167836-Where-do-I-find-my-Cloudflare-API-key-) (除了`email + API KEY`,也可使用`Token`需要列出 Zone 权限)
   - [HE.net DDNS 文档](https://dns.he.net/docs.html)（仅需将设置的密码填入`token`字段，`id`字段可留空）
   - [华为 APIKEY 申请](https://console.huaweicloud.com/iam/)（点左边访问密钥，然后点新增访问密钥）

2. 修改配置文件,`ipv4`和`ipv6`字段，为待更新的域名,详细参照配置说明

## 详细配置

<details open>

<summary markdown="span">config.json 配置文件
</summary>

- 根文件夹有一个模板配置文件config.json
- 推荐使用 vscode 等支持 JsonSchema 的编辑器编辑配置文件

#### 配置参数表

|  key   |        type        | required |   default   |    description    | tips                                                                                                        |
| :----: | :----------------: | :------: | :---------: | :---------------: | ----------------------------------------------------------------------------------------------------------- |
|   ThreadSleep   |       int       |    √     |     300000      |    检查IP时间    | 默认每隔5分钟检查一次ip 值为毫秒 可自定义
|   IsEnable      |       bool       |    √     |     true      |    是否启用    | 是否启用-设置为false即忽略
|   id   |       string       |    √     |     无      |    api 访问 ID    | Cloudflare 为邮箱(使用 Token 时留空)<br>HE.net 可留空   |
| token  |       string       |    √     |     无      |  api 授权 toke|n   | 部分平台叫 secret key , **反馈粘贴时删除**                                                                |
|  dnsType   |       string       |    No    | `"dnspod"`  |    dns 服务商     | 阿里`alidns`,<br>dns.com 为`dnscom`,<br>DNSPOD 国际版`dnspod_com`,<br>HE.net 为`he`，华为 DNS 为`huaweidns`，<br>自定义回调为`callback` |
|  ipv4  |       array        |    No    |    `[]`     |   ipv4 域名列表   | 为`[]`时,不会获取和更新 IPv4 地址                                                                          |
|  ipv6  |       array        |    No    |    `[]`     |   ipv6 域名列表   | 为`[]`时,不会获取和更新 IPv6 地址                                                                          |
|  domain   |       string       |    √    |   ""    | 根域名 | 例: studenty.cn                                                                                                       |
|  sub_domain   |       string       |    √    |   ""    | 主机记录 | 例：www，ddns_01等 如果不传，默认为@                                                                              |
|  ttl   |       number       |    √    |   600    | DNS 解析 TTL 时间 | 默认设置600                                                                                    |

#### 配置示例

```json
{
  "ThreadSleep": 300000,
  "Config": [
    {
      "IsEnable": false,
      "remark": "备注信息可以随便写",
      "id": "12345",
      "token": "tokenkey",
      "dnsType": "dnspod 或 alidns 或 dnscom 或 cloudflare 或 he 或 huaweidns 或 callback",
      "ipv4": [
        {
          "domain": "studenty.cn",
          "sub_domain": ""
        },
        {
          "domain": "studenty.cn",
          "sub_domain": "ddns_01"
        }
      ],
      "ipv6": [
        {
          "domain": "",
          "sub_domain": ""
        }
      ],
      "ttl": 600
    },
    {
      "IsEnable": true,
      "remark": "备注信息可以随便写",
      "id": "12345",
      "token": "tokenkey",
      "dnsType": "dnspod",
      "ipv4": [
        {
          "domain": "studenty.cn",
          "sub_domain": ""
        },
        {
          "domain": "studenty.cn",
          "sub_domain": "ddns_01"
        }
      ],
      "ipv6": [],
      "ttl": 600
    }
  ]
}
```

</details>

## FAQ

<details>
  <summary markdown="span"> 问题排查反馈
</summary>

1. 先确认排查是否是系统/网络环境问题。
2. 在[issues](https://github.com/CuiYuXi/DDNS-Core/issues)中搜索是否有类似问题
3. 前两者均无法解决或者确定是 bug,[在此新建 issue](https://github.com/CuiYuXi/DDNS-Core/issues/new)
   - [ ] 附上这些内容 **运行版本和方式**,**系统环境**, **出错日志**,**去掉 id/token**的配置文件
</details>


## 本项目即将得到[JetBrains](https://www.jetbrains.com/shop/eform/opensource)的支持！  
<img src="https://www.jetbrains.com/shop/static/images/jetbrains-logo-inv.svg" height="100">     
