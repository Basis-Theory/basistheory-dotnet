using System.Text.Json.Serialization;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Tokens.Entities;
using Newtonsoft.Json;

namespace BasisTheory.net.Atomic.Banks.Entities
{
    public class AtomicBank : TokenResponse
    {
        [JsonProperty("bank")]
        [JsonPropertyName("bank")]
        public Bank Bank { get; set; }
    }
}
