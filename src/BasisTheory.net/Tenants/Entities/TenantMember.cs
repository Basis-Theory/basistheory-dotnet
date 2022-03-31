using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Tenants.Entities
{
    public class TenantMember
    {
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonProperty("tenant_id")]
        [JsonPropertyName("tenant_id")]
        public Guid TenantId { get; set; }

        [JsonProperty("role")]
        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonProperty("user")]
        [JsonPropertyName("user")]
        public UserModel User { get; set; }

        [JsonProperty("expires_at")]
        [JsonPropertyName("expires_at")]
        public DateTimeOffset? ExpirationDate { get; set; }

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

    public class UserModel
    {
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public Guid UserId { get; set; }

        [JsonProperty("email")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonProperty("picture")]
        [JsonPropertyName("picture")]
        public string Picture { get; set; }
    }
}
