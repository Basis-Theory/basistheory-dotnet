using System.Text.Json.Serialization;
using BasisTheory.net.Tokens.Entities;
using Newtonsoft.Json;

namespace BasisTheory.net.Encryption.Entities
{
    public class EncryptedData
    {
        [JsonProperty("ciphertext")]
        [JsonPropertyName("ciphertext")]
        public string CipherText { get; set; }

        [JsonProperty("cek")]
        [JsonPropertyName("cek")]
        public EncryptionKey ContentEncryptionKey { get; set; }

        [JsonProperty("kek")]
        [JsonPropertyName("kek")]
        public EncryptionKey KeyEncryptionKey { get; set; }
    }
}
