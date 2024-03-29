using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BasisTheory.net.Common.Entities;
using BasisTheory.net.Encryption.Entities;
using Newtonsoft.Json;

namespace BasisTheory.net.Tokens.Entities
{
    public class Token : TokenResponse
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
        public DataPrivacy Privacy { get; set; }

        [JsonProperty("containers")]
        [JsonPropertyName("containers")]
        public List<string> Containers { get; set; }

        [JsonProperty("search_indexes")]
        [JsonPropertyName("search_indexes")]
        public List<string> SearchIndexes { get; set; }

        [JsonProperty("fingerprint_expression")]
        [JsonPropertyName("fingerprint_expression")]
        public string FingerprintExpression { get; set; }

        [JsonProperty("expires_at")]
        [JsonPropertyName("expires_at")]
        public DateTimeOffset? ExpiresAt { get; set; }

        [JsonProperty("enrichments")]
        [JsonPropertyName("enrichments")]
        public TokenEnrichments Enrichments { get; set; }
        
        public Token()
        {
        }

        public Token(EncryptedData encryptedData)
        {
            if (encryptedData == null) return;

            Data = encryptedData.CipherText;
            Encryption = new EncryptionMetadata
            {
                ContentEncryptionKey = encryptedData.ContentEncryptionKey,
                KeyEncryptionKey = encryptedData.KeyEncryptionKey
            };
        }
    }
}
