using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Reactors.Entities
{
    public class ReactResponse
    {
        [JsonProperty("tokens")]
        [JsonPropertyName("tokens")]
        public dynamic Tokens { get; set; }

        [JsonProperty("raw")]
        [JsonPropertyName("raw")]
        public dynamic Raw { get; set; }
    }
}
