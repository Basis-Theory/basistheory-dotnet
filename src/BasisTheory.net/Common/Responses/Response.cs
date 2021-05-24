using System;
using Newtonsoft.Json;

namespace BasisTheory.net.Common.Responses
{
    public class Response
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("tenant_id")]
        public Guid TenantId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        public dynamic Metadata { get; set; }

        [JsonProperty("created_by")]
        public Guid CreatedBy { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedDate { get; set; }
    }
}
