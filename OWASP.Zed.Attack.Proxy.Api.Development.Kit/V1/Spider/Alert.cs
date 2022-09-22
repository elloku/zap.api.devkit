using Newtonsoft.Json;
using OWASP.Zed.Attack.Proxy.Api.Development.Kit.Response;
using OWASP.Zed.Attack.Proxy.Api.Development.Kit.Utils;
using System.Diagnostics.CodeAnalysis;

namespace OWASP.Zed.Attack.Proxy.Api.Development.Kit.V1.Spider
{
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

        public async Task<IResponse?> ViewAlert(int id)
        {
            Http http = new(ViewAlertUri);
            http.AddParameter("id", id);
            var response = await http.GetAsync<BaseResponse>();
            Console.WriteLine(JsonConvert.SerializeObject(response));
            return response;
        }

        public async Task<IResponse?> ViewAlerts(string baseUrl, int start, int count, string riskId)
        {
            Http http = new(ViewAlertsUri);
            http.AddParameters(new Dictionary<string, object?>()
            {
                { "baseUrl", baseUrl },
                { "start", start },
                { "count", count },
                { "riskId", riskId }
            });
            var response = await http.GetAsync<BaseResponse>();
            Console.WriteLine(JsonConvert.SerializeObject(response));
            return response;
        }

        public async Task<IResponse?> ViewAlertsSummary(string baseUrl)
        {
            Http http = new(ViewAlertsSummaryUri);
            http.AddParameter("baseUrl", baseUrl);
            var response = await http.GetAsync<BaseResponse>();
            Console.WriteLine(JsonConvert.SerializeObject(response));
            return response;
        }

        public async Task<IResponse?> ViewNumberOfAlerts(string baseUrl, string riskId)
        {
            Http http = new(ViewNumberOfAlertsUri);
            http.AddParameter("baseUrl", baseUrl);
            http.AddParameter("riskId", riskId);
            var response = await http.GetAsync<BaseResponse>();
            Console.WriteLine(JsonConvert.SerializeObject(response));
            return response;
        }

        public async Task<IResponse?> ViewAlertsByRisk(string url,bool recurse)
        {
            Http http = new(ViewAlertsByRiskUri);
            http.AddParameter("url", url);
            http.AddParameter("recurse", recurse);
            var response = await http.GetAsync<BaseResponse>();
            Console.WriteLine(JsonConvert.SerializeObject(response));
            return response;
        }

        public async Task<IResponse?> ViewAlertCountsByRisk(string url, bool recurse)
        {
            Http http = new(ViewAlertCountsByRiskUri);
            http.AddParameter("url", url);
            http.AddParameter("recurse", recurse);
            var response = await http.GetAsync<BaseResponse>();
            Console.WriteLine(JsonConvert.SerializeObject(response));
            return response;
        }
        public async Task<IResponse?> ActionDeleteAllAlerts()
        {
            Http http = new(ActionDeleteAllAlertsUri);
            var response = await http.GetAsync<BaseResponse>();
            Console.WriteLine(JsonConvert.SerializeObject(response));
            return response;
        }
        public async Task<IResponse?> ActionDeleteAlert(int id)
        {
            Http http = new(ActionDeleteAlertUri);
            http.AddParameter("id", id);
            var response = await http.GetAsync<BaseResponse>();
            Console.WriteLine(JsonConvert.SerializeObject(response));
            return response;
        }
    }
}
