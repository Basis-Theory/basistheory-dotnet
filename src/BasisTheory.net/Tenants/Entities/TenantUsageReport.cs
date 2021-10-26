using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Tenants.Entities
{
    public class TenantUsageReport
    {
        [JsonProperty("token_report")]
        [JsonPropertyName("token_report")]
        public TokenReport TokenReport { get; set; }
    }

    public class TokenReport
    {
        [JsonProperty("enrichment_limit")]
        [JsonPropertyName("enrichment_limit")]
        public long? EnrichmentLimit { get; set; }

        [JsonProperty("free_enriched_token_limit")]
        [JsonPropertyName("free_enriched_token_limit")]
        public long? FreeEnrichedTokenLimit { get; set; }

        [JsonProperty("number_of_enriched_tokens")]
        [JsonPropertyName("number_of_enriched_tokens")]
        public long NumberOfEnrichedTokens { get; set; }

        [JsonProperty("number_of_enrichments")]
        [JsonPropertyName("number_of_enrichments")]
        public long NumberOfEnrichments { get; set; }

        [JsonProperty("metrics_by_type")]
        [JsonPropertyName("metrics_by_type")]
        public Dictionary<string, TokenTypeMetrics> TokenTypeMetrics { get; set; }
    }

    public class TokenTypeMetrics
    {
        [JsonProperty("count")]
        [JsonPropertyName("count")]
        public long Count { get; set; }

        [JsonProperty("last_created_at")]
        [JsonPropertyName("last_created_at")]
        public DateTimeOffset? LastCreatedDate { get; set; }
    }
}
