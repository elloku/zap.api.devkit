using Newtonsoft.Json;

namespace OWASP.Zed.Attack.Proxy.Api.Development.Kit.Response
{
    public class BaseResponse : IResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
