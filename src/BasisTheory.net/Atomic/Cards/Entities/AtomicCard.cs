using System.Text.Json.Serialization;
using BasisTheory.net.Common.Responses;
using Newtonsoft.Json;

namespace BasisTheory.net.Atomic.Cards.Entities
{
    public class AtomicCard : Response
    {
        [JsonProperty("card")]
        [JsonPropertyName("card")]
        public Card Card { get; set; }

        [JsonProperty("billing_details")]
        [JsonPropertyName("billing_details")]
        public BillingDetails BillingDetails { get; set; }
    }
}
