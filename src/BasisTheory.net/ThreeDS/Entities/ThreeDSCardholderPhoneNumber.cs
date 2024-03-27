using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.ThreeDS.Entities
{
  public class ThreeDSCardholderPhoneNumber
  {
    [JsonProperty("country_code")]
    [JsonPropertyName("country_code")]
    public string CountryCode { get; set; }

    [JsonProperty("number")]
    [JsonPropertyName("number")]
    public string Number { get; set; }
  }
}