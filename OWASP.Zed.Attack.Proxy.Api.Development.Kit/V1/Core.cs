using Newtonsoft.Json;
using OWASP.Zed.Attack.Proxy.Api.Development.Kit.Response;
using OWASP.Zed.Attack.Proxy.Api.Development.Kit.Response.Alert;
using OWASP.Zed.Attack.Proxy.Api.Development.Kit.Response.Core;
using OWASP.Zed.Attack.Proxy.Api.Development.Kit.Utils;

namespace OWASP.Zed.Attack.Proxy.Api.Development.Kit.V1;

public class Core
{
    private const string ViewHostsUri = "/core/view/hosts/";
    private const string ViewSitesUri = "/core/view/sites/";
    private const string ActionLoadSessionUri = "/core/action/loadSession/";
    private const string OtherHtmlReportUri = "/core/other/htmlreport/";
    private const string OtherJsonReportUri = "/core/other/jsonreport/";
    private const string OtherXmlReportUri = "/core/other/xmlreport/";
    private const string OtherMdReportUri = "/core/other/mdreport/";
    
    private ZapApiClient _client;
    
    /// <summary>
    /// Gets the sites accessed through/by ZAP (scheme and domain)
    /// </summary>
    /// <returns></returns>
    public async Task<IResponse?> ViewSites()
    {
        return await new ZapApiClient(ViewSitesUri).GetAsync<ViewSitesResponse>();
    }

    /// <summary>
    /// Gets the name of the hosts accessed through/by ZAP
    /// </summary>
    /// <returns></returns>
    public async Task<IResponse?> ViewHosts()
    {
        return await new ZapApiClient(ViewHostsUri).GetAsync<ViewHostsResponse>();
    }

    /// <summary>
    /// Loads the session with the given name. If a relative path is specified it will be resolved against the "session" directory in ZAP "home" dir.
    /// </summary>
    /// <param name="name">relative path or absolute path</param>
    /// <returns></returns>
    public async Task<IResponse?> ActionLoadSession(string name)
    {
        _client = new ZapApiClient(ActionLoadSessionUri);
        _client.AddParameter("name", name);
        var response = await _client.GetAsync<ActionResponse>();
        return response;
    }

    /// <summary>
    /// Generates a report in HTML format
    /// </summary>
    /// <returns></returns>
    public async Task<string> ExportHtml()
    {
        return await new ZapApiClient(OtherHtmlReportUri).GetAsync();
    }
    
    /// <summary>
    /// Generates a report in JSON format
    /// </summary>
    /// <returns></returns>
    public async Task<string> ExportJson()
    {
        return await new ZapApiClient(OtherJsonReportUri).GetAsync();
    }
    
    /// <summary>
    /// Generates a report in XML format
    /// </summary>
    /// <returns></returns>
    public async Task<string> ExportXml()
    {
        return await new ZapApiClient(OtherXmlReportUri).GetAsync();
    }
    
    /// <summary>
    /// Generates a report in Markdown format
    /// </summary>
    /// <returns></returns>
    public async Task<string> ExportMarkdown()
    {
        return await new ZapApiClient(OtherMdReportUri).GetAsync();
    }
}