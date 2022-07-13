using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Tokens.Requests
{
    public class TokenSearchRequest
    {
        [JsonProperty("query")]
        [JsonPropertyName("query")]
        public string Query { get; set; }


        [JsonProperty("page")]
        [JsonPropertyName("page")]
        public int? Page { get; set; }


        [JsonProperty("size")]
        [JsonPropertyName("size")]
        public int? PageSize { get; set; }
    }
}
