using Newtonsoft.Json;

namespace BasisTheory.net.Tokens.Entities
{
    public class EncryptionKey
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("alg")]
        public string Algorithm { get; set; }
    }
}
