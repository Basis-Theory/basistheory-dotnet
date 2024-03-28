using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.ThreeDS.Entities
{
  public class ThreeDSMerchantInfo
  {
    [JsonProperty("mid")]
    [JsonPropertyName("mid")]
    public string MerchantId { get; set; }

    [JsonProperty("acquirer_bin")]
    [JsonPropertyName("acquirer_bin")]
    public string AcquirerBin { get; set; }

    [JsonProperty("name")]
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonProperty("country_code")]
    [JsonPropertyName("country_code")]
    public string CountryCode { get; set; }

    [JsonProperty("category_code")]
    [JsonPropertyName("category_code")]
    public string CategoryCode { get; set; }

    [JsonProperty("risk_info")]
    [JsonPropertyName("risk_info")]
    public ThreeDSMerchantRiskInfo RiskInfo { get; set; }
  }
}