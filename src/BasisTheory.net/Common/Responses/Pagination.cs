using Newtonsoft.Json;

namespace BasisTheory.net.Common.Responses
{
    public class Pagination
    {
        [JsonProperty("total_items")]
        public int TotalItems { get; }

        [JsonProperty("page_number")]
        public int PageNumber { get; }

        [JsonProperty("page_size")]
        public int PageSize { get; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; }
    }
}
