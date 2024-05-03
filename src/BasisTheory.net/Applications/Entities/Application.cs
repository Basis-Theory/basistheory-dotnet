using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BasisTheory.net.ApplicationKeys.Entities;
using Newtonsoft.Json;

namespace BasisTheory.net.Applications.Entities
{
    public class Application
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

        [JsonProperty("key")]
        [JsonPropertyName("key")]
        [Obsolete("Use `keys` instead.")]
        public string Key { get; set; }

        [JsonProperty("keys")]
        [JsonPropertyName("keys")]
        public List<ApplicationKey> Keys { get; set; }

        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonProperty("created_by")]
        [JsonPropertyName("created_by")]
        public Guid? CreatedBy { get; set; }

        [JsonProperty("created_at")]
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedDate { get; set; }

        [JsonProperty("modified_by")]
        [JsonPropertyName("modified_by")]
        public Guid? ModifiedBy { get; set; }

        [JsonProperty("modified_at")]
        [JsonPropertyName("modified_at")]
        public DateTimeOffset? ModifiedDate { get; set; }

        [JsonProperty("expires_at")]
        [JsonPropertyName("expires_at")]
        public DateTimeOffset? ExpiresAt { get; set; }

        [JsonProperty("permissions")]
        [JsonPropertyName("permissions")]
        public List<string> Permissions { get; set; }

        [JsonProperty("rules")]
        [JsonPropertyName("rules")]
        public List<AccessRule> Rules { get; set; }
    }
}
