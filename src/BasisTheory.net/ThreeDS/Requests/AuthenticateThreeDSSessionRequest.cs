using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using BasisTheory.net.ThreeDS.Entities;

namespace BasisTheory.net.ThreeDS.Requests
{
  public class AuthenticateThreeDSSessionRequest
  {
    [JsonProperty("authentication_category")]
    [JsonPropertyName("authentication_category")]
    public string AuthenticationCategory { get; set; }

    [JsonProperty("authentication_type")]
    [JsonPropertyName("authentication_type")]
    public string AuthenticationType { get; set; }

    [JsonProperty("challenge_preference")]
    [JsonPropertyName("challenge_preference")]
    public string ChallengePreference { get; set; }

    [JsonProperty("purchase_info")]
    [JsonPropertyName("purchase_info")]
    public ThreeDSPurchaseInfo PurchaseInfo { get; set; }

    [JsonProperty("merchant_info")]
    [JsonPropertyName("merchant_info")]
    public ThreeDSMerchantInfo MerchantInfo { get; set; }

    [JsonProperty("requestor_info")]
    [JsonPropertyName("requestor_info")]
    public ThreeDSRequestorInfo RequestorInfo { get; set; }

    [JsonProperty("cardholder_info")]
    [JsonPropertyName("cardholder_info")]
    public ThreeDSCardholderInfo CardholderInfo { get; set; }

    [JsonProperty("broadcast_info")]
    [JsonPropertyName("broadcast_info")]
    public object BroadcastInfo { get; set; }

    [JsonProperty("message_extensions")]
    [JsonPropertyName("message_extensions")]
    public List<ThreeDSMessageExtension> MessageExtensions { get; set; }
  }
}
