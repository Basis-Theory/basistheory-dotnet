using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Common.Responses
{
    public abstract class TokenResponse
    {
        [JsonProperty("id", Order = -3)]
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonProperty("tenant_id", Order = -2)]
        [JsonPropertyName("tenant_id")]
        public Guid? TenantId { get; set; }

        [JsonProperty("type", Order = -1)]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonProperty("fingerprint", Order = 0)]
        [JsonPropertyName("fingerprint")]
        public string Fingerprint { get; set; }

        [JsonProperty("metadata", Order = 1)]
        [JsonPropertyName("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        [JsonProperty("created_by", Order = 2)]
        [JsonPropertyName("created_by")]
        public Guid? CreatedBy { get; set; }

        [JsonProperty("created_at", Order = 3)]
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedDate { get; set; }
    }
}
