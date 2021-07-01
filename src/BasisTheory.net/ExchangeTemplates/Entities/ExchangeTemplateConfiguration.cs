using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.ExchangeTemplates.Entities
{
    public class ExchangeTemplateConfiguration
    {
        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
