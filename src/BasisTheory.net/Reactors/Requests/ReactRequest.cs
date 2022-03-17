using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Reactors.Requests
{
    public class ReactRequest
    {
        [JsonProperty("args")]
        [JsonPropertyName("args")]
        public dynamic Arguments { get; set; }
    }
}