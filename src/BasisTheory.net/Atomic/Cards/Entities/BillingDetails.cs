using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Atomic.Cards.Entities
{
    public class BillingDetails
    {
        [JsonProperty("address")]
        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        [JsonPropertyName("phone")]
        public string PhoneNumber { get; set; }
    }
}
