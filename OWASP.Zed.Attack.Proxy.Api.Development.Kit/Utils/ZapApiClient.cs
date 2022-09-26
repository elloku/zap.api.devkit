using System.Net;
using Newtonsoft.Json;
using RestSharp;
using OWASP.Zed.Attack.Proxy.Api.Development.Kit.Response;

namespace OWASP.Zed.Attack.Proxy.Api.Development.Kit.Utils;

public class ZapApiClient
{
    private RestClient _client;
    private RestRequest _request;
    private ParametersCollection _parameters;

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

    public ZapApiClient(string requestUri)
    {
        _client ??= new RestClient();
        _request = new RestRequest(Env.BaseUri + requestUri);
        _parameters ??= new ParametersCollection();
    }

    public async Task<IResponse?> GetAsync<T>()
    {
        _request.AddHeader("Accept", "application/json");
        _request.AddHeader("X-ZAP-API-Key", Env.ApiKey);
        foreach (var parameter in _parameters)
        {
            _request.AddParameter(parameter);
        }
        var response = await _client.ExecuteAsync(_request);
        if (response.Content == null)
        {
            return new ErrorResponse();
        }
        if (response.StatusCode != HttpStatusCode.OK)
        {
            return JsonConvert.DeserializeObject<ErrorResponse>(response.Content) as IResponse;
        }
        return JsonConvert.DeserializeObject<T>(response.Content) as IResponse;
    }

    public async Task<IResponse?> PostAsync<T>()
    {
        _request.AddHeader("Accept", "application/json");
        _request.AddHeader("X-ZAP-API-Key", Env.ApiKey);
        foreach (var parameter in _parameters)
        {
            _request.AddParameter(parameter);
        }
        var response = await _client.ExecuteAsync(_request, Method.Post);
        if (response.Content == null)
        {
            return new ErrorResponse();
        }
        if (response.StatusCode != HttpStatusCode.OK)
        {
            return JsonConvert.DeserializeObject<ErrorResponse>(response.Content) as IResponse;
        }
        return JsonConvert.DeserializeObject<T>(response.Content) as IResponse;
    }
}