using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BasisTheory.net.Applications.Entities;
using Newtonsoft.Json;

namespace BasisTheory.net.Sessions.Requests
{
    public class AuthorizeSessionRequest
    {
        [JsonProperty("nonce")]
        [JsonPropertyName("nonce")]
        public string Nonce { get; set; }

        [JsonProperty("expires_at")]
        [JsonPropertyName("expires_at")]
        public DateTimeOffset? ExpiresAt { get; set; }
#nullable enable
        [JsonProperty("permissions")]
        [JsonPropertyName("permissions")]
        public List<string>? Permissions { get; set; }
        
        [JsonProperty("rules")]
        [JsonPropertyName("rules")]
        public List<AccessRule>? Rules { get; set; }
#nullable disable
    }
}