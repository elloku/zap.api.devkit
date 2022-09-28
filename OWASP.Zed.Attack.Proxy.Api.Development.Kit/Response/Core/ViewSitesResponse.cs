using Newtonsoft.Json;

namespace OWASP.Zed.Attack.Proxy.Api.Development.Kit.Response.Core;

public class ViewSitesResponse : IResponse
{
    [JsonProperty("sites")]
    public string[] Sites { get; set; }
}