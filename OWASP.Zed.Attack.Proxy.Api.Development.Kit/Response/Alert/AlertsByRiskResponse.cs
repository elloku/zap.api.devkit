using Newtonsoft.Json;

namespace OWASP.Zed.Attack.Proxy.Api.Development.Kit.Response.Alert;

public class AlertsByRiskResponse : IResponse
{
    public AlertsByRisk[] alertsByRisk { get; set; }
}

public class AlertsByRisk
{
    public Informational[] Informational { get; set; }
    public Low[] Low { get; set; }
    public Medium[] Medium { get; set; }
    public object[] High { get; set; }
}

public class Informational
{
    [JsonProperty("Information Disclosure - Suspicious Comments")]
    public InformationDisclosureSuspiciousComments[] InformationDisclosureSuspiciousComments { get; set; }

    [JsonProperty("Re-examine Cache-control Directives")]
    public ReExamineCacheControlDirectives[] ReexamineCachecontrolDirectives { get; set; }
}

public class InformationDisclosureSuspiciousComments
{
    public string param { get; set; }
    public string confidence { get; set; }
    public string name { get; set; }
    public string risk { get; set; }
    public string id { get; set; }
    public string url { get; set; }
}

public class ReExamineCacheControlDirectives
{
    public string param { get; set; }
    public string confidence { get; set; }
    public string name { get; set; }
    public string risk { get; set; }
    public string id { get; set; }
    public string url { get; set; }
}

public class Low
{
    [JsonProperty("Timestamp Disclosure - Unix")]
    public TimestampDisclosureUnix[] TimestampDisclosureUnix { get; set; }

    [JsonProperty("X-Content-Type-Options Header Missing")]
    public XContentTypeOptionsHeaderMissing[] XContentTypeOptionsHeaderMissing { get; set; }
}

public class TimestampDisclosureUnix
{
    public string param { get; set; }
    public string confidence { get; set; }
    public string name { get; set; }
    public string risk { get; set; }
    public string id { get; set; }
    public string url { get; set; }
}

public class XContentTypeOptionsHeaderMissing
{
    public string param { get; set; }
    public string confidence { get; set; }
    public string name { get; set; }
    public string risk { get; set; }
    public string id { get; set; }
    public string url { get; set; }
}

public class Medium
{
    [JsonProperty("Content Security Policy (CSP) Header Not Set")]
    public ContentSecurityPolicyCSPHeaderNotSet[] ContentSecurityPolicyCSPHeaderNotSet { get; set; }

    [JsonProperty("Missing Anti-clickjacking Header")]
    public MissingAntiClickjackingHeader[] MissingAnticlickjackingHeader { get; set; }

    [JsonProperty("Vulnerable JS Library")]
    public VulnerableJSLibrary[] VulnerableJSLibrary { get; set; }
}

public class ContentSecurityPolicyCSPHeaderNotSet
{
    public string param { get; set; }
    public string confidence { get; set; }
    public string name { get; set; }
    public string risk { get; set; }
    public string id { get; set; }
    public string url { get; set; }
}

public class MissingAntiClickjackingHeader
{
    public string param { get; set; }
    public string confidence { get; set; }
    public string name { get; set; }
    public string risk { get; set; }
    public string id { get; set; }
    public string url { get; set; }
}

public class VulnerableJSLibrary
{
    public string param { get; set; }
    public string confidence { get; set; }
    public string name { get; set; }
    public string risk { get; set; }
    public string id { get; set; }
    public string url { get; set; }
}