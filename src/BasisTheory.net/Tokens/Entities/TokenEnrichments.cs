using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Tokens.Entities
{
    public class TokenEnrichments
    {
        [JsonProperty("bin_details")]
        [JsonPropertyName("bin_details")]
        public BinDetails BinDetails { get; set; }
    }
}