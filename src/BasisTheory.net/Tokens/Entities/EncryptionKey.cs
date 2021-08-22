using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Tokens.Entities
{
    public class EncryptionKey
    {
        [JsonProperty("key")]
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonProperty("alg")]
        [JsonPropertyName("alg")]
        public string Algorithm { get; set; }

        [JsonProperty("prov")]
        [JsonPropertyName("prov")]
        public string Provider { get; set; }
    }
}
