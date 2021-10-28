using System.Text.Json.Serialization;
using BasisTheory.net.Atomic.Cards.Entities;
using Newtonsoft.Json;

namespace BasisTheory.net.Atomic.Cards.Requests
{
    public class UpdateAtomicCardRequest
    {
        [JsonProperty("card")]
        [JsonPropertyName("card")]
        public Card Card { get; set; }

        [JsonProperty("billing_details")]
        [JsonPropertyName("billing_details")]
        public BillingDetails BillingDetails { get; set; }
    }
}
