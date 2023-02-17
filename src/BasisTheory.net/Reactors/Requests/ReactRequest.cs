using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Reactors.Requests
{
    public class ReactRequest
    {
        [JsonProperty("args")]
        [JsonPropertyName("args")]
        public dynamic Arguments { get; set; }
        
        [JsonProperty("callback_url")]
        [JsonPropertyName("callback_url")]
        public string? CallbackUrl { get; set; }
        
        [JsonProperty("timeout_ms")]
        [JsonPropertyName("timeout_ms")]
        public int? TimeoutMs { get; set; }
    }
}