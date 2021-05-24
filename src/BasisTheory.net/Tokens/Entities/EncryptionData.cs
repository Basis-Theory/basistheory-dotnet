using Newtonsoft.Json;

namespace BasisTheory.net.Tokens.Entities
{
    public class EncryptionData
    {
        [JsonProperty("cek")]
        public EncryptionKey ContentEncryptionKey { get; set; }

        [JsonProperty("kek")]
        public EncryptionKey KeyEncryptionKey { get; set; }
    }
}
