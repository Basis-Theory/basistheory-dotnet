using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Common.Entities
{
    public class DataPrivacy
    {
        [JsonProperty("classification", Order = 0)]
        [JsonPropertyName("classification")]
        public string Classification { get; set; }

        [JsonProperty("impact_level", Order = 1)]
        [JsonPropertyName("impact_level")]
        public string ImpactLevel { get; set; }

        [JsonProperty("restriction_policy", Order = 2)]
        [JsonPropertyName("restriction_policy")]
        public string RestrictionPolicy { get; set; }
    }
}
