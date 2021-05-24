using System.Collections.Generic;
using BasisTheory.net.Tokens.Entities;
using Newtonsoft.Json;

namespace BasisTheory.net.Tokens.Requests
{
    public class TokenCreateRequest
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("data")]
        public dynamic Data { get; set; }

        [JsonProperty("metadata")]
        public dynamic Metadata { get; set; }

        [JsonProperty("encryption")]
        public EncryptionData Encryption { get; set; }

        [JsonProperty("children")]
        public List<TokenCreateRequest> Children { get; set; }
    }
}
