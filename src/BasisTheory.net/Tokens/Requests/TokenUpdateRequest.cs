using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BasisTheory.net.Tokens.Entities;
using Newtonsoft.Json;

namespace BasisTheory.net.Tokens.Requests
{
    public class TokenUpdateRequest
    {
        [JsonProperty("data")]
        [JsonPropertyName("data")]
        public dynamic Data { get; set; }
        
        [JsonProperty("mask")]
        [JsonPropertyName("mask")]
        public dynamic Mask { get; set; }
        
        [JsonProperty("encryption")]
        [JsonPropertyName("encryption")]
        public EncryptionMetadata Encryption { get; set; }

        [JsonProperty("privacy")]
        [JsonPropertyName("privacy")]
        public PrivacyUpdateModel Privacy { get; set; }

        [JsonProperty("container")]
        [JsonPropertyName("container")]
        public string Container { get; set; }

        [JsonProperty("search_indexes")]
        [JsonPropertyName("search_indexes")]
        public List<string> SearchIndexes { get; set; }

        [JsonProperty("fingerprint_expression")]
        [JsonPropertyName("fingerprint_expression")]
        public string FingerprintExpression { get; set; }

        [JsonProperty("metadata")]
        [JsonPropertyName("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        [JsonProperty("deduplicate_token")]
        [JsonPropertyName("deduplicate_token")]
        public bool? DeduplicateToken { get; set; }
        
        [JsonProperty("expires_at")]
        [JsonPropertyName("expires_at")]
        public DateTimeOffset? ExpiresAt { get; set; }
    }
    
    public class PrivacyUpdateModel
    {
        [JsonProperty("impact_level")]
        [JsonPropertyName("impact_level")]
        public string ImpactLevel { get; set; }

        [JsonProperty("restriction_policy")]
        [JsonPropertyName("restriction_policy")]
        public string RestrictionPolicy { get; set; }
    }
}