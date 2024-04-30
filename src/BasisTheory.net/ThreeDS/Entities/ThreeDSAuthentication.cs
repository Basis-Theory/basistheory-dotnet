using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BasisTheory.net.ThreeDS.Entities
{
    public class ThreeDSAuthentication
    {
        [JsonProperty("threeds_version")]
        [JsonPropertyName("threeds_version")]
        public string ThreeDSVersion { get; set; }

        [JsonProperty("acs_transaction_id")]
        [JsonPropertyName("acs_transaction_id")]
        public Guid? AcsTransactionId { get; set; }

        [JsonProperty("ds_transaction_id")]
        [JsonPropertyName("ds_transaction_id")]
        public Guid? DirectoryServerTransactionId { get; set; }

        [JsonProperty("sdk_transaction_id")]
        [JsonPropertyName("sdk_transaction_id")]
        public Guid? SdkTransactionId { get; set; }

        [JsonProperty("acs_reference_number")]
        [JsonPropertyName("acs_reference_number")]
        public string AcsReferenceNumber { get; set; }

        [JsonProperty("ds_reference_number")]
        [JsonPropertyName("ds_reference_number")]
        public string DirectoryServerReferenceNumber { get; set; }

        [JsonProperty("authentication_value")]
        [JsonPropertyName("authentication_value")]
        public string AuthenticationValue { get; set; }

        [JsonProperty("authentication_status")]
        [JsonPropertyName("authentication_status")]
        public string AuthenticationStatus { get; set; }

        [JsonProperty("authentication_status_reason")]
        [JsonPropertyName("authentication_status_reason")]
        public string AuthenticationStatusReason { get; set; }

        [JsonProperty("eci")]
        [JsonPropertyName("eci")]
        public string Eci { get; set; }

        [JsonProperty("acs_challenge_mandated")]
        [JsonPropertyName("acs_challenge_mandated")]
        public string AcsChallengeMandated { get; set; }

        [JsonProperty("acs_decoupled_authentication")]
        [JsonPropertyName("acs_decoupled_authentication")]
        public string AcsDecoupledAuthentication { get; set; }

        [JsonProperty("authentication_challenge_type")]
        [JsonPropertyName("authentication_challenge_type")]
        public string AuthenticationChallengeType { get; set; }

        [JsonProperty("acs_rendering_type")]
        [JsonPropertyName("acs_rendering_type")]
        public ThreeDSAcsRenderingType AcsRenderingType { get; set; }

        [JsonProperty("acs_signed_content")]
        [JsonPropertyName("acs_signed_content")]
        public string AcsSignedContent { get; set; }

        [JsonProperty("acs_challenge_url")]
        [JsonPropertyName("acs_challenge_url")]
        public string AcsChallengeUrl { get; set; }

        [JsonProperty("challenge_attempts")]
        [JsonPropertyName("challenge_attempts")]
        public string ChallengeAttempts { get; set; }

        [JsonProperty("challenge_cancel_reason")]
        [JsonPropertyName("challenge_cancel_reason")]
        public string ChallengeCancelReason { get; set; }

        [JsonProperty("cardholder_info")]
        [JsonPropertyName("cardholder_info")]
        public string CardholderInfo { get; set; }

        [JsonProperty("whitelist_status")]
        [JsonPropertyName("whitelist_status")]
        public string WhitelistStatus { get; set; }

        [JsonProperty("whitelist_status_source")]
        [JsonPropertyName("whitelist_status_source")]
        public string WhitelistStatusSource { get; set; }

        [JsonProperty("message_extensions")]
        [JsonPropertyName("message_extensions")]
        public List<ThreeDSMessageExtension> MessageExtensions { get; set; }
    }
}