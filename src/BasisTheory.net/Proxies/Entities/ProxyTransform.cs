using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Proxies.Entities
{
    public class ProxyTransform
    {
        [JsonProperty("code")]
        [JsonPropertyName("code")]
        public string Code { get; set; }
    }
}
