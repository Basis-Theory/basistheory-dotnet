using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Tenants.Requests
{
    public class TenantUpdateRequest
    {
        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("settings")]
        [JsonPropertyName("settings")]
        public Dictionary<string, string> Settings { get; set; }
    }
}
