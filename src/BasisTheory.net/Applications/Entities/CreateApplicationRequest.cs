using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Applications.Entities
{
    public class CreateApplicationRequest
    {
        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonProperty("expires_at")]
        [JsonPropertyName("expires_at")]
        public string ExpiresAt { get; set; }

        [JsonProperty("permissions")]
        [JsonPropertyName("permissions")]
        public List<string> Permissions { get; set; } = new();

        [JsonProperty("rules")]
        [JsonPropertyName("rules")]
        public List<AccessRule> Rules { get; set; } = new();

        [JsonProperty("create_key")]
        [JsonPropertyName("create_key")]
        public bool? CreateKey { get; set; }
        
    }
}