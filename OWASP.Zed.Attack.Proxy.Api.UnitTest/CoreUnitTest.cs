using Newtonsoft.Json;
using OWASP.Zed.Attack.Proxy.Api.Development.Kit.V1;

namespace OWASP.Zed.Attack.Proxy.Api.UnitTest;

public class CoreUnitTest
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
        const string name = "/Users/torolleys/Dev/security/zap/202209261537.session";
        var result = await new Core().ActionLoadSession(name);
        Console.WriteLine(JsonConvert.SerializeObject(result));
    }

    [Test]
    public async Task Export()
    {
        const string format = "Html";
        Env.BaseUri = "http://localhost:8080/OTHER";

        var result = format switch
        {
            "Html" => await new Core().ExportHtml(),
            "Json" => await new Core().ExportJson(),
            "Xml" => await new Core().ExportXml(),
            "Markdown" => await new Core().ExportMarkdown(),
            _ => throw new ArgumentOutOfRangeException()
        };

        Console.WriteLine(result);
    }
}