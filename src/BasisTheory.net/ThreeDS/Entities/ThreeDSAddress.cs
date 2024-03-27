using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.ThreeDS.Entities
{
  public class ThreeDSAddress
  {
    [JsonProperty("line1")]
    [JsonPropertyName("line1")]
    public string Line1 { get; set; }

    [JsonProperty("line2")]
    [JsonPropertyName("line2")]
    public string Line2 { get; set; }

    [JsonProperty("line3")]
    [JsonPropertyName("line3")]
    public string Line3 { get; set; }

    [JsonProperty("city")]
    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonProperty("state_code")]
    [JsonPropertyName("state_code")]
    public string StateCode { get; set; }

    [JsonProperty("postal_code")]
    [JsonPropertyName("postal_code")]
    public string PostalCode { get; set; }

    [JsonProperty("country_code")]
    [JsonPropertyName("country_code")]
    public string CountryCode { get; set; }
  }
}