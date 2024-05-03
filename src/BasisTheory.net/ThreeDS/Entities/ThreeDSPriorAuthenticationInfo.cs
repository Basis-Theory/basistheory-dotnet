using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.ThreeDS.Entities
{
    public class ThreeDSPriorAuthenticationInfo
    {
        [JsonProperty("method")]
        [JsonPropertyName("method")]
        public string Method { get; set; }

        [JsonProperty("timestamp")]
        [JsonPropertyName("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("reference_id")]
        [JsonPropertyName("reference_id")]
        public string ReferenceId { get; set; }

        [JsonProperty("data")]
        [JsonPropertyName("data")]
        public string Data { get; set; }
    }
}