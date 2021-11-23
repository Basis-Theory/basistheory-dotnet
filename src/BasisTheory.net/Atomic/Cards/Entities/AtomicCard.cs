using System.Text.Json.Serialization;
using BasisTheory.net.Common.Responses;
using Newtonsoft.Json;

namespace BasisTheory.net.Atomic.Cards.Entities
{
    public class AtomicCard : TokenResponse
    {
        [JsonProperty("card")]
        [JsonPropertyName("card")]
        public Card Card { get; set; }
    }
}
