using Newtonsoft.Json;

namespace OWASP.Zed.Attack.Proxy.Api.Development.Kit.Response.Core;

public class ViewUrlsResponse : IResponse
{
    [JsonProperty("urls")] public string[] Urls { get; set; }
}