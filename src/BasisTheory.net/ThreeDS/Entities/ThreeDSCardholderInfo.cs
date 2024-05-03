using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.ThreeDS.Entities
{
    public class ThreeDSCardholderInfo
    {
        [JsonProperty("account_id")]
        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("account_type")]
        [JsonPropertyName("account_type")]
        public string AccountType { get; set; }

        [JsonProperty("account_info")]
        [JsonPropertyName("account_info")]
        public ThreeDSCardholderAccountInfo AccountInfo { get; set; }

        [JsonProperty("authentication_info")]
        [JsonPropertyName("authentication_info")]
        public ThreeDSCardholderAuthenticationInfo AuthenticationInfo { get; set; }

        [JsonProperty("prior_authentication_info")]
        [JsonPropertyName("prior_authentication_info")]
        public ThreeDSPriorAuthenticationInfo PriorAuthenticationInfo { get; set; }

        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonProperty("phone_number")]
        [JsonPropertyName("phone_number")]
        public ThreeDSCardholderPhoneNumber PhoneNumber { get; set; }

        [JsonProperty("mobile_phone_number")]
        [JsonPropertyName("mobile_phone_number")]
        public ThreeDSCardholderPhoneNumber MobilePhoneNumber { get; set; }

        [JsonProperty("work_phone_number")]
        [JsonPropertyName("work_phone_number")]
        public ThreeDSCardholderPhoneNumber WorkPhoneNumber { get; set; }

        [JsonProperty("billing_shipping_address_match")]
        [JsonPropertyName("billing_shipping_address_match")]
        public string BillingShippingAddressMatch { get; set; }

        [JsonProperty("billing_address")]
        [JsonPropertyName("billing_address")]
        public ThreeDSAddress BillingAddress { get; set; }

        [JsonProperty("shipping_address")]
        [JsonPropertyName("shipping_address")]
        public ThreeDSAddress ShippingAddress { get; set; }
    }
}