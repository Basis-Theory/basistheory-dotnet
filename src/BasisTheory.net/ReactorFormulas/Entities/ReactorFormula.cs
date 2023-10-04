using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.ReactorFormulas.Entities
{
    [Obsolete("Reactor Formulas are deprecated and will be removed in a future release. Please visit https://developers.basistheory.com/docs/api/reactors#create-reactor for more information.")]
    public class ReactorFormula
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

        [JsonProperty("icon")]
        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonProperty("code")]
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonProperty("configuration")]
        [JsonPropertyName("configuration")]
        public List<ReactorFormulaConfiguration> Configuration { get; set; }

        [JsonProperty("request_parameters")]
        [JsonPropertyName("request_parameters")]
        public List<ReactorFormulaRequestParameter> RequestParameters { get; set; }

        [JsonProperty("created_by")]
        [JsonPropertyName("created_by")]
        public Guid? CreatedBy { get; set; }

        [JsonProperty("created_at")]
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedDate { get; set; }

        [JsonProperty("modified_by")]
        [JsonPropertyName("modified_by")]
        public Guid? ModifiedBy { get; set; }

        [JsonProperty("modified_at")]
        [JsonPropertyName("modified_at")]
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
