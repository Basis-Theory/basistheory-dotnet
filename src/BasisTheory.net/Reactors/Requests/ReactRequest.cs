using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Reactors.Requests
{
    public class ReactRequest
    {
        [JsonProperty("reactor_id")]
        [JsonPropertyName("reactor_id")]
        public Guid ReactorId { get; set; }

        [JsonProperty("request_parameters")]
        [JsonPropertyName("request_parameters")]
        public Dictionary<string, object> RequestParameters { get; set; }

        [JsonProperty("metadata")]
        [JsonPropertyName("metadata")]
        public Dictionary<string, string> Metadata { get; set; }
    }
}
