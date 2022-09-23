namespace OWASP.Zed.Attack.Proxy.Api.Development.Kit.Response.Alert;

public class AlertsSummary:IResponse
{
    public int High { get; set; }
    
    public int Low { get; set; }
    
    public int Medium { get; set; }
    
    public int Informational { get; set; }
}