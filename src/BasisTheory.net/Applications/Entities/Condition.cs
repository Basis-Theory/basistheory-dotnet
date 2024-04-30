using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Applications.Entities
{
    public class Condition
    {
        [JsonProperty("attribute")]
        [JsonPropertyName("attribute")]
        public string Attribute { get; set; }

        [JsonProperty("operator")]
        [JsonPropertyName("operator")]
        public string Operator { get; set; }

        [JsonProperty("value")]
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}