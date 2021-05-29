using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Permissions.Entities
{
    public class Permission
    {
        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonProperty("application_types")]
        [JsonPropertyName("application_types")]
        public List<string> ApplicationTypes { get; set; }

        [JsonProperty("dependencies")]
        [JsonPropertyName("dependencies")]
        public List<string> Dependencies { get; set; }
    }
}
