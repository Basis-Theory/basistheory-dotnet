using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.ExchangeTemplates.Entities
{
    public class ExchangeTemplate
    {
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonProperty("source_token_type")]
        [JsonPropertyName("source_token_type")]
        public string SourceTokenType { get; set; }

        [JsonProperty("icon")]
        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonProperty("code")]
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonProperty("configuration")]
        [JsonPropertyName("configuration")]
        public List<ExchangeTemplateConfiguration> Configuration { get; set; }

        [JsonProperty("request_parameters")]
        [JsonPropertyName("request_parameters")]
        public List<ExchangeTemplateRequestParameter> RequestParameters { get; set; }

        [JsonProperty("created_at")]
        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedDate { get; set; }

        [JsonProperty("modified_at")]
        [JsonPropertyName("modified_at")]
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
