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
        [JsonProperty("metrics_by_type")]
        [JsonPropertyName("metrics_by_type")]
        public Dictionary<string, TokenTypeMetrics> TokenTypeMetrics { get; set; }

        [JsonProperty("included_monthly_active_tokens")]
        [JsonPropertyName("included_monthly_active_tokens")]
        public long IncludedMonthlyActiveTokens { get; set; }

        [JsonProperty("monthly_active_tokens")]
        [JsonPropertyName("monthly_active_tokens")]
        public long MonthlyActiveTokens { get; set; }

        [JsonProperty("monthly_active_token_history")]
        [JsonPropertyName("monthly_active_token_history")]
        public List<MonthlyActiveTokenHistory> MonthlyActiveTokenHistory { get; set; }
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

    public class MonthlyActiveTokenHistory
    {
        [JsonProperty("count")]
        [JsonPropertyName("count")]
        public long Count { get; set; }

        [JsonProperty("year")]
        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonProperty("month")]
        [JsonPropertyName("month")]
        public int Month { get; set; }
    }
}
