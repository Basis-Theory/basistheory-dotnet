using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.ReactorFormulas.Entities
{
    public class ReactorFormulaRequestParameter
    {
        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonProperty("optional")]
        [JsonPropertyName("optional")]
        public bool IsOptional { get; set; }
    }
}
