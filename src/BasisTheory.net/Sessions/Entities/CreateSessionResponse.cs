using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Sessions.Entities
{
    public class CreateSessionResponse
    {
        [JsonProperty("session_key")]
        [JsonPropertyName("session_key")]
        public string SessionKey { get; set; }
        
        [JsonProperty("nonce")]
        [JsonPropertyName("nonce")]
        public string Nonce { get; set; }
        
        [JsonProperty("expires_at")]
        [JsonPropertyName("expires_at")]
        public DateTimeOffset? ExpiresAt { get; set; }
    }
}