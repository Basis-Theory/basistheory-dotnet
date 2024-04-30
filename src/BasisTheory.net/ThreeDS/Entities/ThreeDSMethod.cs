using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.ThreeDS.Entities
{
    public class ThreeDSMethod
    {
        [JsonProperty("method_url")]
        [JsonPropertyName("method_url")]
        public string MethodUrl { get; set; }

        [JsonProperty("method_completion_indicator")]
        [JsonPropertyName("method_completion_indicator")]
        public string MethodCompletionIndicator { get; set; }
    }
}