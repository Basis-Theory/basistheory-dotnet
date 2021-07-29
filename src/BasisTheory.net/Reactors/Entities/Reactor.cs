using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BasisTheory.net.ReactorFormulas.Entities;
using Newtonsoft.Json;

namespace BasisTheory.net.Reactors.Entities
{
    public class Reactor
    {
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonProperty("tenant_id")]
        [JsonPropertyName("tenant_id")]
        public Guid TenantId { get; set; }

        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("formula")]
        [JsonPropertyName("formula")]
        public ReactorFormula ReactorFormula { get; set; }

        [JsonProperty("configuration")]
        [JsonPropertyName("configuration")]
        public Dictionary<string, string> Configuration { get; set; }

        [JsonProperty("created_at")]
        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedDate { get; set; }

        [JsonProperty("modified_at")]
        [JsonPropertyName("modified_at")]
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
