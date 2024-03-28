using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.ThreeDS.Entities
{
  public class ThreeDSDeviceInfo
  {
    [JsonProperty("browser_accept_header")]
    [JsonPropertyName("browser_accept_header")]
    public string BrowserAcceptHeader { get; set; }

    [JsonProperty("browser_ip")]
    [JsonPropertyName("browser_ip")]
    public string BrowserIpAddress { get; set; }

    [JsonProperty("browser_javascript_enabled")]
    [JsonPropertyName("browser_javascript_enabled")]
    public bool? BrowserJavascriptEnabled { get; set; }

    [JsonProperty("browser_java_enabled")]
    [JsonPropertyName("browser_java_enabled")]
    public bool? BrowserJavaEnabled { get; set; }

    [JsonProperty("browser_language")]
    [JsonPropertyName("browser_language")]
    public string BrowserLanguage { get; set; }

    [JsonProperty("browser_color_depth")]
    [JsonPropertyName("browser_color_depth")]
    public string BrowserColorDepth { get; set; }

    [JsonProperty("browser_screen_height")]
    [JsonPropertyName("browser_screen_height")]
    public string BrowserScreenHeight { get; set; }

    [JsonProperty("browser_screen_width")]
    [JsonPropertyName("browser_screen_width")]
    public string BrowserScreenWidth { get; set; }

    [JsonProperty("browser_tz")]
    [JsonPropertyName("browser_tz")]
    public string BrowserTimezone { get; set; }

    [JsonProperty("browser_user_agent")]
    [JsonPropertyName("browser_user_agent")]
    public string BrowserUserAgent { get; set; }

    [JsonProperty("sdk_transaction_id")]
    [JsonPropertyName("sdk_transaction_id")]
    public string MobileSdkTransactionId { get; set; }

    [JsonProperty("sdk_application_id")]
    [JsonPropertyName("sdk_application_id")]
    public string MobileSdkApplicationId { get; set; }

    [JsonProperty("sdk_encryption_data")]
    [JsonPropertyName("sdk_encryption_data")]
    public string MobileSdkEncryptionData { get; set; }

    [JsonProperty("sdk_ephemeral_public_key")]
    [JsonPropertyName("sdk_ephemeral_public_key")]
    public string MobileSdkEphemeralPublicKey { get; set; }

    [JsonProperty("sdk_max_timeout")]
    [JsonPropertyName("sdk_max_timeout")]
    public string MobileSdkMaxTimeout { get; set; }

    [JsonProperty("sdk_reference_number")]
    [JsonPropertyName("sdk_reference_number")]
    public string MobileSdkReferenceNumber { get; set; }

    [JsonProperty("sdk_render_options")]
    [JsonPropertyName("sdk_render_options")]
    public ThreeDSMobileSdkRenderOptions MobileSdkRenderOptions { get; set; }
  }

  public class ThreeDSMobileSdkRenderOptions
  {
    [JsonProperty("sdk_interface")]
    [JsonPropertyName("sdk_interface")]
    public string MobileSdkInterface { get; set; }

    [JsonProperty("sdk_ui_type")]
    [JsonPropertyName("sdk_ui_type")]
    public List<string> MobileSdkUiType { get; set; }
  }
}