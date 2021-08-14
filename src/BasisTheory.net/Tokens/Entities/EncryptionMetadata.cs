using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Tokens.Entities
{
    public class EncryptionMetadata
    {
        [JsonProperty("cek")]
        [JsonPropertyName("cek")]
        public EncryptionKey ContentEncryptionKey { get; set; }

        [JsonProperty("kek")]
        [JsonPropertyName("kek")]
        public EncryptionKey KeyEncryptionKey { get; set; }
    }
}
