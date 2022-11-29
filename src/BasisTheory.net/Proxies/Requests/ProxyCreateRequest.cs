using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BasisTheory.net.Applications.Entities;
using BasisTheory.net.Proxies.Entities;
using Newtonsoft.Json;

namespace BasisTheory.net.Proxies.Requests
{
    public class ProxyCreateRequest
    {
        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("destination_url")]
        [JsonPropertyName("destination_url")]
        public string DestinationUrl { get; set; }

        [JsonProperty("request_reactor_id")]
        [JsonPropertyName("request_reactor_id")]
        [Obsolete("RequestReactorId has been deprecated in favor of RequestTransform")]
        public Guid? RequestReactorId { get; set; }

        [JsonProperty("response_reactor_id")]
        [JsonPropertyName("response_reactor_id")]
        [Obsolete("ResponseReactorId has been deprecated in favor of ResponseTransform")]
        public Guid? ResponseReactorId { get; set; }

        [JsonProperty("request_transform")]
        [JsonPropertyName("request_transform")]
        public ProxyTransform RequestTransform { get; set; }

        [JsonProperty("response_transform")]
        [JsonPropertyName("response_transform")]
        public ProxyTransform ResponseTransform { get; set; }

        [JsonProperty("application")]
        [JsonPropertyName("application")]
        public Application Application { get; set; }

        [JsonProperty("configuration")]
        [JsonPropertyName("configuration")]
        public Dictionary<string, string> Configuration { get; set; }

        [JsonProperty("require_auth")]
        [JsonPropertyName("require_auth")]
        public bool? RequireAuthentication { get; set; } = true;
    }
}
