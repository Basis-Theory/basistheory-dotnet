using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Proxies.Entities
{
    public class Proxy
    {
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonProperty("key")]
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonProperty("tenant_id")]
        [JsonPropertyName("tenant_id")]
        public Guid TenantId { get; set; }

        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("destination_url")]
        [JsonPropertyName("destination_url")]
        public string DestinationUrl { get; set; }

        [JsonProperty("request_reactor_id")]
        [JsonPropertyName("request_reactor_id")]
        public Guid RequestReactorId { get; set; }

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
    }
}
