using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.Tenants.Requests;

public class TenantMemberUpdateRequest
{
    [JsonProperty("role")]
    [JsonPropertyName("role")]
    public string Role { get; set; }
}