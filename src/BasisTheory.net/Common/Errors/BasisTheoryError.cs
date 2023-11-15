using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Common.Errors
{
    public class BasisTheoryError
    {
        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonProperty("title")]
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonProperty("status")]
        [JsonPropertyName("status")]
        public int? Status { get; set; }

        [JsonProperty("detail")]
        [JsonPropertyName("detail")]
        public string Detail { get; set; }

        [JsonProperty("errors")]
        [JsonPropertyName("errors")]
        public IDictionary<string, string[]> Errors { get; } = new Dictionary<string, string[]>(StringComparer.Ordinal);
    }
}
