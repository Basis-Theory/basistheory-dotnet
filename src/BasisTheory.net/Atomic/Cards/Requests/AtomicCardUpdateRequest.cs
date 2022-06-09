using System.Text.Json.Serialization;
using BasisTheory.net.Atomic.Cards.Entities;
using Newtonsoft.Json;

namespace BasisTheory.net.Atomic.Cards.Requests
{
    public class AtomicCardUpdateRequest
    {
        [JsonProperty("card")]
        [JsonPropertyName("card")]
        public Card Card { get; set; }
    }
}
