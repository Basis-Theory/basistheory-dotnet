using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Atomic.Cards.Entities
{
    public class Card
    {
        [JsonProperty("number")]
        [JsonPropertyName("number")]
        public string CardNumber { get; set; }

        [JsonProperty("expiration_month")]
        [JsonPropertyName("expiration_month")]
        public int ExpirationMonth { get; set; }

        [JsonProperty("expiration_year")]
        [JsonPropertyName("expiration_year")]
        public int ExpirationYear { get; set; }

        [JsonProperty("cvc")]
        [JsonPropertyName("cvc")]
        public string CardVerificationCode { get; set; }
    }
}
