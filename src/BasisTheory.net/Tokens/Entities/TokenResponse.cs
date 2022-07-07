using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Tokens.Entities
{
    public abstract class TokenResponse
    {
        [JsonProperty("id", Order = -3)]
        [JsonPropertyName("id"), JsonPropertyOrder(-3)]
        public string Id { get; set; }

        [JsonProperty("tenant_id", Order = -2)]
        [JsonPropertyName("tenant_id"), JsonPropertyOrder(-2)]
        public Guid? TenantId { get; set; }

        [JsonProperty("type", Order = -1)]
        [JsonPropertyName("type"), JsonPropertyOrder(-1)]
        public string Type { get; set; }

        [JsonProperty("fingerprint", Order = 0)]
        [JsonPropertyName("fingerprint"), JsonPropertyOrder(0)]
        public string Fingerprint { get; set; }

        [JsonProperty("metadata", Order = 1)]
        [JsonPropertyName("metadata"), JsonPropertyOrder(1)]
        public Dictionary<string, string> Metadata { get; set; }

        [JsonProperty("created_by", Order = 2)]
        [JsonPropertyName("created_by"), JsonPropertyOrder(2)]
        public Guid? CreatedBy { get; set; }

        [JsonProperty("created_at", Order = 3)]
        [JsonPropertyName("created_at"), JsonPropertyOrder(3)]
        public DateTimeOffset? CreatedDate { get; set; }

        [JsonProperty("modified_by", Order = 4)]
        [JsonPropertyName("modified_by"), JsonPropertyOrder(4)]
        public Guid? ModifiedBy { get; set; }

        [JsonProperty("modified_at", Order = 5)]
        [JsonPropertyName("modified_at"), JsonPropertyOrder(5)]
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
