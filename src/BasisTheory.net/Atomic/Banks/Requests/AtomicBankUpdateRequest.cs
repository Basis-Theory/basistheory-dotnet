using System.Text.Json.Serialization;
using BasisTheory.net.Atomic.Banks.Entities;
using Newtonsoft.Json;

namespace BasisTheory.net.Atomic.Banks.Requests
{
    public class AtomicBankUpdateRequest
    {
        [JsonProperty("bank")]
        [JsonPropertyName("bank")]
        public Bank Bank { get; set; }
    }
}