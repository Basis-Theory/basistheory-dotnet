using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Common.Entities
{
    public class DataPrivacy
    {
        [JsonProperty("classification", Order = 0)]
        [JsonPropertyName("classification"), JsonPropertyOrder(0)]
        public string Classification { get; set; }

        [JsonProperty("impact_level", Order = 1)]
        [JsonPropertyName("impact_level"), JsonPropertyOrder(1)]
        public string ImpactLevel { get; set; }

        [JsonProperty("restriction_policy", Order = 2)]
        [JsonPropertyName("restriction_policy"), JsonPropertyOrder(2)]
        public string RestrictionPolicy { get; set; }
    }
}
