using Newtonsoft.Json;

namespace OWASP.Zed.Attack.Proxy.Api.Development.Kit.Response.Ascan;

public class ScanResponse:IResponse
{
    [JsonProperty("scan")]
    public  string Scan { get; set; }
}