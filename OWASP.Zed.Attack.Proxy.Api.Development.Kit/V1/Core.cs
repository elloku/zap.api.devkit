using OWASP.Zed.Attack.Proxy.Api.Development.Kit.Response;
using OWASP.Zed.Attack.Proxy.Api.Development.Kit.Response.Core;
using OWASP.Zed.Attack.Proxy.Api.Development.Kit.Utils;

namespace OWASP.Zed.Attack.Proxy.Api.Development.Kit.V1;

public class Core
{
    private const string ViewHostsUri = "/core/view/hosts/";
    private const string ViewSitesUri = "/core/view/sites/";
    private const string ViewUrlsUri = "/core/view/urls/";
    private const string ActionLoadSessionUri = "/core/action/loadSession/";
    private const string HtmlReportUri = "/core/other/htmlreport/";
    private const string JsonReportUri = "/core/other/jsonreport/";
    private const string XmlReportUri = "/core/other/xmlreport/";
    private const string MdReportUri = "/core/other/mdreport/";

    private ZapApiClient? _client = null;

    #region View

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
    /// Gets the URLs accessed through/by ZAP, optionally filtering by (base) URL
    /// </summary>
    /// <returns></returns>
    public async Task<IResponse?> ViewUrls(string baseurl)
    {
        _client = new ZapApiClient(ViewUrlsUri);
        _client.AddParameter("baseurl", baseurl);
        return await _client.GetAsync<ViewUrlsResponse>();
    }

    #endregion

    #region Action

    /// <summary>
    /// Loads the session with the given name.
    /// If a relative path is specified it will be resolved against the "session" directory in ZAP "home" dir.
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

    

    #endregion

    #region Report

    /// <summary>
    /// Generates a report in HTML format
    /// </summary>
    /// <returns></returns>
    public async Task<string> ExportHtml()
    {
        return await new ZapApiClient(HtmlReportUri).GetAsync();
    }

    /// <summary>
    /// Generates a report in JSON format
    /// </summary>
    /// <returns></returns>
    public async Task<string> ExportJson()
    {
        return await new ZapApiClient(JsonReportUri).GetAsync();
    }

    /// <summary>
    /// Generates a report in XML format
    /// </summary>
    /// <returns></returns>
    public async Task<string> ExportXml()
    {
        return await new ZapApiClient(XmlReportUri).GetAsync();
    }

    /// <summary>
    /// Generates a report in Markdown format
    /// </summary>
    /// <returns></returns>
    public async Task<string> ExportMarkdown()
    {
        return await new ZapApiClient(MdReportUri).GetAsync();
    }

    #endregion
    
}