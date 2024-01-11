using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Common.Responses;

public class Pagination
{
    [JsonProperty("total_items")]
    [JsonPropertyName("total_items")]
    public int TotalItems { get; set; }

    [JsonProperty("page_number")]
    [JsonPropertyName("page_number")]
    public int PageNumber { get; set; }

    [JsonProperty("page_size")]
    [JsonPropertyName("page_size")]
    public int PageSize { get; set; }

    [JsonProperty("total_pages")]
    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }
        
    [JsonProperty("after")]
    [JsonPropertyName("after")]
    public string After { get; set; }
}