using Newtonsoft.Json;

namespace OWASP.Zed.Attack.Proxy.Api.Development.Kit.Response.Core;

public class ViewHostsResponse : IResponse
{
    [JsonProperty("hosts")]
    public string[] Hosts { get; set; }
}