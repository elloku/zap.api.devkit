using Newtonsoft.Json;
using OWASP.Zed.Attack.Proxy.Api.Development.Kit.V1;

namespace OWASP.Zed.Attack.Proxy.Api.UnitTest;

public class AlertUnitTest
{
    [SetUp]
    public void Setup()
    {
        Env.BaseUri = "http://localhost:8080/JSON";
        Env.ApiKey = "hrci86ufqv442haua6eea9lj50";
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
        var baseUrl = "http://lyra.mediinfo.cn";
        var start = 1;
        var count = 10;
        string riskId = "3";
        var result = await new Alert().ViewAlerts(baseUrl, start, count, riskId);
        Console.WriteLine(JsonConvert.SerializeObject(result));
    }

    [Test]
    public async Task ViewAlertsSummary()
    {
        var baseUrl = "https://lyra.mediinfo.cn";
        await new Alert().ViewAlertsSummary(baseUrl);
    }

    [Test]
    public async Task ViewNumberOfAlerts()
    {
        var baseUrl = "https://lyra.mediinfo.cn";
        var riskId = "1";
        await new Alert().ViewNumberOfAlerts(baseUrl, riskId);
    }

    [Test]
    public async Task ViewAlertsByRisk()
    {
        var url = "https://lyra.mediinfo.cn";
        var recurse = true;
        await new Alert().ViewAlertsByRisk(url, recurse);
    }

    [Test]
    public async Task ViewAlertCountsByRisk()
    {
        var url = "http://lyra.mediinfo.cn";
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