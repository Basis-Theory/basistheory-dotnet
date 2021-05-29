using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Atomic.Banks.Entities
{
    public class Bank
    {
        [JsonProperty("routing_number")]
        [JsonPropertyName("routing_number")]
        public string RoutingNumber { get; set; }

        [JsonProperty("account_number")]
        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }
    }
}
