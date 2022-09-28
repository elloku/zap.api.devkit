namespace OWASP.Zed.Attack.Proxy.Api.Development.Kit.Response.Alert;

public class AlertResponse : IResponse
{
    public Alert alerts { get; set; }
}

public class AlertsResponse : IResponse
{
    public Alert[] alerts { get; set; }
}

public class Alert
{
    public string sourceid { get; set; }
    public string other { get; set; }
    public string method { get; set; }
    public string evidence { get; set; }
    public string pluginId { get; set; }
    public string cweid { get; set; }
    public string confidence { get; set; }
    public string wascid { get; set; }
    public string description { get; set; }
    public string messageId { get; set; }
    public string url { get; set; }
    public Dictionary<string, string> tags { get; set; }
    public string reference { get; set; }
    public string solution { get; set; }
    public string alert { get; set; }
    public string param { get; set; }
    public string attack { get; set; }
    public string name { get; set; }
    public string risk { get; set; }
    public string id { get; set; }
    public string alertRef { get; set; }
}

public class Tags
{
    public string OWASP_2021_A05 { get; set; }
    public string WSTGv42CLNT09 { get; set; }
    public string OWASP_2017_A06 { get; set; }
    public string OWASP_2021_A01 { get; set; }
    public string OWASP_2017_A03 { get; set; }
}