using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BasisTheory.net.Applications.Entities;
using BasisTheory.net.ReactorFormulas.Entities;
using Newtonsoft.Json;

namespace BasisTheory.net.Reactors.Entities
{
    public class Reactor
    {
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonProperty("tenant_id")]
        [JsonPropertyName("tenant_id")]
        public Guid TenantId { get; set; }

        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonProperty("code")]
        [JsonPropertyName("code")]
        public string? Code { get; set; }

        [JsonProperty("formula")]
        [JsonPropertyName("formula")]
        [Obsolete("Reactor Formulas are now deprecated and will be removed in a future release. We have introduced a `code` property for Reactors to replace Formula's code. For more details, visit https://developers.basistheory.com/docs/api/reactors#create-reactor")]
        public ReactorFormula? ReactorFormula { get; set; }

        [JsonProperty("application")]
        [JsonPropertyName("application")]
        public Application Application { get; set; }

        [JsonProperty("configuration")]
        [JsonPropertyName("configuration")]
        public Dictionary<string, string> Configuration { get; set; }

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
