using System.Collections.Generic;
using System.Text.Json.Serialization;
using BasisTheory.net.Common.Entities;
using BasisTheory.net.Tokens.Entities;
using Newtonsoft.Json;

namespace BasisTheory.net.Tokens.Requests
{
    public class TokenCreateRequest
    {
        [JsonProperty("type", Order = -1)]
        [JsonPropertyName("type"), JsonPropertyOrder(-1)]
        public string Type { get; set; }

        [JsonProperty("data")]
        [JsonPropertyName("data")]
        public dynamic Data { get; set; }

        [JsonProperty("encryption")]
        [JsonPropertyName("encryption")]
        public EncryptionMetadata Encryption { get; set; }

        [JsonProperty("privacy")]
        [JsonPropertyName("privacy")]
        public DataPrivacy Privacy { get; set; }

        [JsonProperty("search_indexes")]
        [JsonPropertyName("search_indexes")]
        public List<string> SearchIndexes { get; set; }

        [JsonProperty("fingerprint_expression")]
        [JsonPropertyName("fingerprint_expression")]
        public string FingerprintExpression { get; set; }

        [JsonProperty("metadata", Order = 1)]
        [JsonPropertyName("metadata"), JsonPropertyOrder(1)]
        public Dictionary<string, string> Metadata { get; set; }

        [JsonProperty("deduplicate_token")]
        [JsonPropertyName("deduplicate_token")]
        public bool? DuplicateToken { get; set; }
    }
}
