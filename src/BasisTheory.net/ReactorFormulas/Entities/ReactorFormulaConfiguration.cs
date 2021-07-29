using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.ReactorFormulas.Entities
{
    public class ReactorFormulaConfiguration
    {
        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
