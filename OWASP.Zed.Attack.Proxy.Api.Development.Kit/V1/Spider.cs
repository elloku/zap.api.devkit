using RestSharp;

namespace OWASP.Zed.Attack.Proxy.Api.Development.Kit.V1
{
    public class Spider
    {
        string uri = "http://172.19.30.81:9090";

        public async Task SpiderViewStatus(string aa)
        {
            int scanId = 1;
            var client = new RestClient();
            var request = new RestRequest(new Uri($"{uri}/JSON/spider/view/status"));
            request.AddHeader("Accept", "application/json");
            request.AddHeader("X-ZAP-API-Key", "songxuanlong");
            request.AddParameter("scanId", aa);
            var response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
        }

        public async Task SpiderViewResults()
        {
            int scanId = 1;
            var client = new RestClient();
            var request = new RestRequest(new Uri($"{uri}/JSON/spider/view/results"));
            request.AddHeader("Accept", "application/json");
            request.AddHeader("X-ZAP-API-Key", "songxuanlong");
            request.AddParameter("scanId", scanId);
            var response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
        }
    }
}