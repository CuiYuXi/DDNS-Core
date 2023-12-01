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
3. 前两者均无法解决或者确定是 bug,[在此新建 issue](https:github.com/CuiYuXi/DDNS-Core/issues/new)
   - [ ] Attach these contents: **Running version and mode**, **System environment**, **Error log**, **Remove id/token** configuration file
</details>|  key   |        type        | required |   default   |    description    | tips                                                                                                        |
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
3. 前两者均无法解决或者确定是 bug,[在此新建 issue](https:github.com/CuiYuXi/DDNS-Core/issues/new)
   - [ ] Attach these contents: **Running version and mode**, **System environment**, **Error log**, **Remove id/token** configuration file
</details>
