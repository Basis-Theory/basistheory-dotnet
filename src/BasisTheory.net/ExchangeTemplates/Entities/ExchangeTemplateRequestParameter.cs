using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.ExchangeTemplates.Entities
{
    public class ExchangeTemplateRequestParameter
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
