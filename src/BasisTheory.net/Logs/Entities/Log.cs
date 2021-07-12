using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Logs.Entities
{
    public class Log
    {
        [JsonProperty("tenant_id")]
        [JsonPropertyName("tenant_id")]
        public Guid TenantId { get; set; }

        [JsonProperty("application_id")]
        [JsonPropertyName("application_id")]
        public Guid? ApplicationId { get; set; }

        [JsonProperty("entity_type")]
        [JsonPropertyName("entity_type")]
        public string EntityType { get; set; }

        [JsonProperty("entity_id")]
        [JsonPropertyName("entity_id")]
        public string EntityId { get; set; }

        [JsonProperty("operation")]
        [JsonPropertyName("operation")]
        public string Operation { get; set; }

        [JsonProperty("message")]
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonProperty("created_at")]
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedDate { get; set; }
    }
}
