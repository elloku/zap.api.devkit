using Newtonsoft.Json;
using OWASP.Zed.Attack.Proxy.Api.Development.Kit.Response;
using OWASP.Zed.Attack.Proxy.Api.Development.Kit.Response.Alert;
using OWASP.Zed.Attack.Proxy.Api.Development.Kit.Utils;

namespace OWASP.Zed.Attack.Proxy.Api.Development.Kit.V1;

public class Alert
{
    private const string ViewAlertUri = "/alert/view/alert/";
    private const string ViewAlertsUri = "/alert/view/alerts/";
    private const string ViewAlertsSummaryUri = "/alert/view/alertsSummary/";
    private const string ViewNumberOfAlertsUri = "/alert/view/numberOfAlerts/";
    private const string ViewAlertsByRiskUri = "/alert/view/alertsByRisk/";
    private const string ViewAlertCountsByRiskUri = "/alert/view/alertCountsByRisk/";
    private const string ActionDeleteAllAlertsUri = "/alert/action/deleteAllAlerts/";
    private const string ActionDeleteAlertUri = "/alert/action/deleteAlert/";

    private ZapApiClient _client;

    public async Task<IResponse?> ViewAlert(int id)
    {
        _client = new ZapApiClient(ViewAlertUri);
        _client.AddParameter("id", id);
        var response = await _client.GetAsync<AlertResponse>();
        Console.WriteLine(JsonConvert.SerializeObject(response));
        return response;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="baseUrl"></param>
    /// <param name="start"></param>
    /// <param name="count"></param>
    /// <param name="riskId">0:INFO 1:LOW 2:MEDIUM 3:HIGH</param>
    /// <returns></returns>
    public async Task<IResponse?> ViewAlerts(string baseUrl, int start, int count, string riskId)
    {
        _client = new ZapApiClient(ViewAlertsUri);
        _client.AddParameters(new Dictionary<string, object?>()
        {
            {"baseUrl", baseUrl},
            {"start", start},
            {"count", count},
            {"riskId", riskId}
        });
        var response = await _client.GetAsync<AlertsResponse>();
        return response;
    }

    public async Task<IResponse?> ViewAlertsSummary(string baseUrl)
    {
        _client = new ZapApiClient(ViewAlertsSummaryUri);
        _client.AddParameter("baseUrl", baseUrl);
        var response = await _client.GetAsync<AlertsSummaryResponse>();
        return response;
    }

    public async Task<IResponse?> ViewNumberOfAlerts(string baseUrl, string riskId)
    {
        _client = new ZapApiClient(ViewNumberOfAlertsUri);
        _client.AddParameter("baseUrl", baseUrl);
        _client.AddParameter("riskId", riskId);
        var response = await _client.GetAsync<NumberOfAlertsResponse>();
        return response;
    }

    /// <summary>
    /// Gets a summary of the alerts
    /// </summary>
    /// <param name="url">filtered by a 'url'</param>
    /// <param name="recurse">true:start with the specified 'url'
    ///                       false:only those on exactly the same 'url' (ignoring url parameters)</param>
    /// <returns></returns>
    public async Task<IResponse?> ViewAlertsByRisk(string url, bool recurse)
    {
        _client = new ZapApiClient(ViewAlertsByRiskUri);
        _client.AddParameter("url", url);
        _client.AddParameter("recurse", recurse);
        var response = await _client.GetAsync<AlertsByRiskResponse>();
        return response;
    }

    public async Task<IResponse?> ViewAlertCountsByRisk(string url, bool recurse)
    {
        _client = new ZapApiClient(ViewAlertCountsByRiskUri);
        _client.AddParameter("url", url);
        _client.AddParameter("recurse", recurse);
        var response = await _client.GetAsync<AlertsSummary>();
        return response;
    }

    public async Task<IResponse?> ActionDeleteAllAlerts()
    {
        _client = new ZapApiClient(ActionDeleteAllAlertsUri);
        var response = await _client.GetAsync<ActionResponse>();
        return response;
    }

    public async Task<IResponse?> ActionDeleteAlert(int id)
    {
        _client = new ZapApiClient(ActionDeleteAlertUri);
        _client.AddParameter("id", id);
        var response = await _client.GetAsync<ActionResponse>();
        return response;
    }
}