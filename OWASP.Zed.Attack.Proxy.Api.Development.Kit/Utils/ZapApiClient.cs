using System.Net;
using Newtonsoft.Json;
using RestSharp;
using OWASP.Zed.Attack.Proxy.Api.Development.Kit.Response;

namespace OWASP.Zed.Attack.Proxy.Api.Development.Kit.Utils;

public class ZapApiClient
{
    private readonly RestClient _client;
    private RestRequest? _request;
    private readonly ParametersCollection _parameters;

    public ZapApiClient()
    {
        _client ??= new RestClient();
        _request = new RestRequest(Env.BaseUri);
        _parameters ??= new ParametersCollection();
    }

    public ZapApiClient(string requestUri)
    {
        _client ??= new RestClient();
        _request = new RestRequest(Env.BaseUri + requestUri);
        _parameters ??= new ParametersCollection();
    }

    public void SetRequest(string requestUri)
    {
        _request = new RestRequest(Env.BaseUri + requestUri);
    }

    public void AddParameter(string name, string? value, bool encode = true)
    {
        _parameters.AddParameter(new GetOrPostParameter(name, value, encode));
    }

    public void AddParameter<T>(string name, T value, bool encode = true) where T : struct
    {
        _parameters.AddParameter(new GetOrPostParameter(name, value.ToString(), encode));
    }

    public void AddParameters(Dictionary<string, object?> keyValuePairs)
    {
        foreach (var (key, value) in keyValuePairs)
        {
            if (value != null)
            {
                this.AddParameter(key, value.ToString());
            }
        }
    }


    public async Task<IResponse?> GetAsync<T>()
    {
        if (_request == null)
        {
            return new ErrorResponse("Enter you endpoint please!");
        }

        var response = await this.ExecuteAsync();
        
        if (response.Content == null)
        {
            return new ErrorResponse("this url call result is null!");
        }

        if (response.StatusCode != HttpStatusCode.OK)
        {
            return JsonConvert.DeserializeObject<ErrorResponse>(response.Content);
        }

        return JsonConvert.DeserializeObject<T>(response.Content) as IResponse;
    }

    public async Task<string> GetAsync()
    {
        if (_request == null)
        {
            return "Enter you endpoint please!";
        }

        var response = await this.ExecuteAsync();
        
        return response.Content ?? "this url call result is null!";
    }

    private async Task<RestResponse> ExecuteAsync()
    {
        _request!.AddHeader("Accept", "application/json");
        _request!.AddHeader("X-ZAP-API-Key", Env.ApiKey);
        foreach (var parameter in _parameters)
        {
            _request!.AddParameter(parameter);
        }

        return await _client.ExecuteAsync(_request!);
    }

}