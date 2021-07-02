using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BasisTheory.net.ExchangeTemplates.Entities;
using Newtonsoft.Json;

namespace BasisTheory.net.Exchanges.Entities
{
    public class Exchange
    {
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("template")]
        [JsonPropertyName("template")]
        public ExchangeTemplate ExchangeTemplate { get; set; }

        [JsonProperty("configuration")]
        [JsonPropertyName("configuration")]
        public Dictionary<string, string> Configuration { get; set; }

        [JsonProperty("tenant_id")]
        [JsonPropertyName("tenant_id")]
        public Guid TenantId { get; set; }

        [JsonProperty("created_at")]
        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedDate { get; set; }

        [JsonProperty("modified_at")]
        [JsonPropertyName("modified_at")]
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
