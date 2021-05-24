using System.Collections.Generic;
using Newtonsoft.Json;

namespace BasisTheory.net.Common.Responses
{
    public class PaginatedList<T> where T : class
    {
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }

        [JsonProperty("data")]
        public List<T> Data { get; set; }
    }
}
