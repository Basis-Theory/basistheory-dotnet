using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Atomic.Cards.Entities
{
    public class Address
    {
        [JsonProperty("city")]
        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonProperty("line1")]
        [JsonPropertyName("line1")]
        public string LineOne { get; set; }

        [JsonProperty("line2")]
        [JsonPropertyName("line2")]
        public string LineTwo { get; set; }

        [JsonProperty("postal_code")]
        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("state")]
        [JsonPropertyName("state")]
        public string State { get; set; }
    }
}
