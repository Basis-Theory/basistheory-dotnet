using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.ApplicationKeys.Entities
{

    public class ApplicationKey
    {

        [JsonProperty("description")]
        [JsonPropertyName("description")]
        public Guid Id { get; set; }

        [JsonProperty("key")]
        [JsonPropertyName("key")]
        public Guid? Key { get; set; }

        [JsonProperty("createdAt")]
        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("createdBy")]
        [JsonPropertyName("createdBy")]
        public Guid CreatedBy { get; set; }

    }
}