using System.Text.Json.Serialization;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Encryption.Entities;
using Newtonsoft.Json;

namespace BasisTheory.net.Tokens.Entities
{
    public class Token : TokenResponse
    {
        [JsonProperty("data")]
        [JsonPropertyName("data")]
        public dynamic Data { get; set; }

        [JsonProperty("encryption")]
        [JsonPropertyName("encryption")]
        public EncryptionMetadata Encryption { get; set; }

        [JsonProperty("mask")]
        [JsonPropertyName("mask")]
        public dynamic Mask { get; set; }

        public Token() {}

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
