using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Applications.Entities
{
    public class AccessRule
    {
        [JsonProperty("description")]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonProperty("priority")]
        [JsonPropertyName("priority")]
        public int Priority { get; set; }

        [JsonProperty("container")]
        [JsonPropertyName("container")]
        public string Container { get; set; }

        [JsonProperty("transform")]
        [JsonPropertyName("transform")]
        public string Transform { get; set; }

        [JsonProperty("permissions")]
        [JsonPropertyName("permissions")]
        public List<string> Permissions { get; set; }
    }
}