using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.ThreeDS.Entities
{
    public class ThreeDSSession
    {
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonProperty("tenant_id")]
        [JsonPropertyName("tenant_id")]
        public Guid TenantId { get; set; }

        [JsonProperty("pan_token_id")]
        [JsonPropertyName("pan_token_id")]
        public string PanTokenId { get; set; }

        [JsonProperty("card_brand")]
        [JsonPropertyName("card_brand")]
        public string CardBrand { get; set; }

        [JsonProperty("expiration_date")]
        [JsonPropertyName("expiration_date")]
        public DateTimeOffset ExpirationDate { get; set; }

        [JsonProperty("created_date")]
        [JsonPropertyName("created_date")]
        public DateTimeOffset? CreatedDate { get; set; }

        [JsonProperty("created_by")]
        [JsonPropertyName("created_by")]
        public Guid? CreatedBy { get; set; }

        [JsonProperty("modified_date")]
        [JsonPropertyName("modified_date")]
        public DateTimeOffset? ModifiedDate { get; set; }

        [JsonProperty("modified_by")]
        [JsonPropertyName("modified_by")]
        public Guid? ModifiedBy { get; set; }

        [JsonProperty("device")]
        [JsonPropertyName("device")]
        public string Device { get; set; }

        [JsonProperty("device_info")]
        [JsonPropertyName("device_info")]
        public ThreeDSDeviceInfo DeviceInfo { get; set; }

        [JsonProperty("version")]
        [JsonPropertyName("version")]
        public ThreeDSVersion Version { get; set; }

        [JsonProperty("method")]
        [JsonPropertyName("method")]
        public ThreeDSMethod Method { get; set; }

        [JsonProperty("authentication")]
        [JsonPropertyName("authentication")]
        public ThreeDSAuthentication Authentication { get; set; }
    }
}