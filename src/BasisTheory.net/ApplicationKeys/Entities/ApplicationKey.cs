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

        [JsonProperty("created_at")]
        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("created_by")]
        [JsonPropertyName("created_by")]
        public Guid CreatedBy { get; set; }

    }
}