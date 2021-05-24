using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Common.Responses
{
    public class PaginatedList<T> where T : class
    {
        [JsonProperty("pagination")]
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }

        [JsonProperty("data")]
        [JsonPropertyName("data")]
        public List<T> Data { get; set; }
    }
}
