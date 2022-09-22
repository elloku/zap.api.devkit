using OWASP.Zed.Attack.Proxy.Api.Development.Kit;
using OWASP.Zed.Attack.Proxy.Api.Development.Kit.V1.Spider;

namespace OWASP.Zed.Attack.Proxy.Api.UnitTest
{
    public class AlertUnitTest
    {
        [SetUp]
        public void Setup()
        {
            Env.BaseUri = "http://172.19.30.81:9090/JSON";
            Env.ApiKey = "songxuanlong";
        }

        [Test]
        public async Task ViewAlert()
        {
            var id = 1;
            await new Alert().ViewAlert(id);
        }

        [Test]
        public async Task ViewAlerts()
        {
            var baseUrl = "https://www.baidu.cn";
            var start = 1;
            var count = 10;
            var riskId = "1";
            await new Alert().ViewAlerts(baseUrl, start, count, riskId);
        }

        [Test]
        public async Task ViewAlertsSummary()
        {
            var baseUrl = "https://www.baidu.cn";
            await new Alert().ViewAlertsSummary(baseUrl);
        }

        [Test]
        public async Task ViewNumberOfAlerts()
        {
            var baseUrl = "https://www.baidu.cn";
            var riskId = "1";
            await new Alert().ViewNumberOfAlerts(baseUrl, riskId);
        }

        [Test]
        public async Task ViewAlertsByRisk()
        {
            var url = "https://www.baidu.cn";
            var recurse = true;
            await new Alert().ViewAlertsByRisk(url, recurse);
        }

        [Test]
        public async Task ViewAlertCountsByRisk()
        {
            var url = "https://www.baidu.cn";
            var recurse = true;
            await new Alert().ViewAlertCountsByRisk(url, recurse);
        }

        [Test]
        public async Task ActionDeleteAllAlerts()
        {
            await new Alert().ActionDeleteAllAlerts();
        }

        [Test]
        public async Task ActionDeleteAlert()
        {
            var id = 1;
            await new Alert().ActionDeleteAlert(id);
        }


    }
}