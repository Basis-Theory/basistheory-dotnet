/*
 * Basis Theory API
 *
 * ## Getting Started * Sign-in to [Basis Theory](https://basistheory.com) and go to [Applications](https://portal.basistheory.com/applications) * Create a Basis Theory Private Application * All permissions should be selected * Paste the API Key into the `BT-API-KEY` variable
 *
 * The version of the OpenAPI document: v1
 * 
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = BasisTheory.net.Client.OpenAPIDateConverter;

namespace BasisTheory.net.Model
{
    /// <summary>
    /// AuthenticateThreeDSSessionRequest
    /// </summary>
    [DataContract]
    public partial class AuthenticateThreeDSSessionRequest :  IEquatable<AuthenticateThreeDSSessionRequest>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticateThreeDSSessionRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AuthenticateThreeDSSessionRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticateThreeDSSessionRequest" /> class.
        /// </summary>
        /// <param name="authenticationCategory">authenticationCategory (required).</param>
        /// <param name="authenticationType">authenticationType (required).</param>
        /// <param name="challengePreference">challengePreference.</param>
        /// <param name="purchaseInfo">purchaseInfo.</param>
        /// <param name="merchantInfo">merchantInfo.</param>
        /// <param name="requestorInfo">requestorInfo (required).</param>
        /// <param name="cardholderInfo">cardholderInfo.</param>
        /// <param name="broadcastInfo">broadcastInfo.</param>
        /// <param name="messageExtensions">messageExtensions.</param>
        public AuthenticateThreeDSSessionRequest(string authenticationCategory = default(string), string authenticationType = default(string), string challengePreference = default(string), ThreeDSPurchaseInfo purchaseInfo = default(ThreeDSPurchaseInfo), ThreeDSMerchantInfo merchantInfo = default(ThreeDSMerchantInfo), ThreeDSRequestorInfo requestorInfo = default(ThreeDSRequestorInfo), ThreeDSCardholderInfo cardholderInfo = default(ThreeDSCardholderInfo), Object broadcastInfo = default(Object), List<ThreeDSMessageExtension> messageExtensions = default(List<ThreeDSMessageExtension>))
        {
            // to ensure "authenticationCategory" is required (not null)
            if (authenticationCategory == null)
            {
                throw new InvalidDataException("authenticationCategory is a required property for AuthenticateThreeDSSessionRequest and cannot be null");
            }
            else
            {
                this.AuthenticationCategory = authenticationCategory;
            }

            // to ensure "authenticationType" is required (not null)
            if (authenticationType == null)
            {
                throw new InvalidDataException("authenticationType is a required property for AuthenticateThreeDSSessionRequest and cannot be null");
            }
            else
            {
                this.AuthenticationType = authenticationType;
            }

            this.ChallengePreference = challengePreference;
            // to ensure "requestorInfo" is required (not null)
            if (requestorInfo == null)
            {
                throw new InvalidDataException("requestorInfo is a required property for AuthenticateThreeDSSessionRequest and cannot be null");
            }
            else
            {
                this.RequestorInfo = requestorInfo;
            }

            this.BroadcastInfo = broadcastInfo;
            this.MessageExtensions = messageExtensions;
            this.ChallengePreference = challengePreference;
            this.PurchaseInfo = purchaseInfo;
            this.MerchantInfo = merchantInfo;
            this.CardholderInfo = cardholderInfo;
            this.BroadcastInfo = broadcastInfo;
            this.MessageExtensions = messageExtensions;
        }

        /// <summary>
        /// Gets or Sets AuthenticationCategory
        /// </summary>
        [DataMember(Name="authentication_category", EmitDefaultValue=true)]
        public string AuthenticationCategory { get; set; }

        /// <summary>
        /// Gets or Sets AuthenticationType
        /// </summary>
        [DataMember(Name="authentication_type", EmitDefaultValue=true)]
        public string AuthenticationType { get; set; }

        /// <summary>
        /// Gets or Sets ChallengePreference
        /// </summary>
        [DataMember(Name="challenge_preference", EmitDefaultValue=true)]
        public string ChallengePreference { get; set; }

        /// <summary>
        /// Gets or Sets PurchaseInfo
        /// </summary>
        [DataMember(Name="purchase_info", EmitDefaultValue=false)]
        public ThreeDSPurchaseInfo PurchaseInfo { get; set; }

        /// <summary>
        /// Gets or Sets MerchantInfo
        /// </summary>
        [DataMember(Name="merchant_info", EmitDefaultValue=false)]
        public ThreeDSMerchantInfo MerchantInfo { get; set; }

        /// <summary>
        /// Gets or Sets RequestorInfo
        /// </summary>
        [DataMember(Name="requestor_info", EmitDefaultValue=true)]
        public ThreeDSRequestorInfo RequestorInfo { get; set; }

        /// <summary>
        /// Gets or Sets CardholderInfo
        /// </summary>
        [DataMember(Name="cardholder_info", EmitDefaultValue=false)]
        public ThreeDSCardholderInfo CardholderInfo { get; set; }

        /// <summary>
        /// Gets or Sets BroadcastInfo
        /// </summary>
        [DataMember(Name="broadcast_info", EmitDefaultValue=true)]
        public Object BroadcastInfo { get; set; }

        /// <summary>
        /// Gets or Sets MessageExtensions
        /// </summary>
        [DataMember(Name="message_extensions", EmitDefaultValue=true)]
        public List<ThreeDSMessageExtension> MessageExtensions { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AuthenticateThreeDSSessionRequest {\n");
            sb.Append("  AuthenticationCategory: ").Append(AuthenticationCategory).Append("\n");
            sb.Append("  AuthenticationType: ").Append(AuthenticationType).Append("\n");
            sb.Append("  ChallengePreference: ").Append(ChallengePreference).Append("\n");
            sb.Append("  PurchaseInfo: ").Append(PurchaseInfo).Append("\n");
            sb.Append("  MerchantInfo: ").Append(MerchantInfo).Append("\n");
            sb.Append("  RequestorInfo: ").Append(RequestorInfo).Append("\n");
            sb.Append("  CardholderInfo: ").Append(CardholderInfo).Append("\n");
            sb.Append("  BroadcastInfo: ").Append(BroadcastInfo).Append("\n");
            sb.Append("  MessageExtensions: ").Append(MessageExtensions).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as AuthenticateThreeDSSessionRequest);
        }

        /// <summary>
        /// Returns true if AuthenticateThreeDSSessionRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of AuthenticateThreeDSSessionRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AuthenticateThreeDSSessionRequest input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.AuthenticationCategory == input.AuthenticationCategory ||
                    (this.AuthenticationCategory != null &&
                    this.AuthenticationCategory.Equals(input.AuthenticationCategory))
                ) && 
                (
                    this.AuthenticationType == input.AuthenticationType ||
                    (this.AuthenticationType != null &&
                    this.AuthenticationType.Equals(input.AuthenticationType))
                ) && 
                (
                    this.ChallengePreference == input.ChallengePreference ||
                    (this.ChallengePreference != null &&
                    this.ChallengePreference.Equals(input.ChallengePreference))
                ) && 
                (
                    this.PurchaseInfo == input.PurchaseInfo ||
                    (this.PurchaseInfo != null &&
                    this.PurchaseInfo.Equals(input.PurchaseInfo))
                ) && 
                (
                    this.MerchantInfo == input.MerchantInfo ||
                    (this.MerchantInfo != null &&
                    this.MerchantInfo.Equals(input.MerchantInfo))
                ) && 
                (
                    this.RequestorInfo == input.RequestorInfo ||
                    (this.RequestorInfo != null &&
                    this.RequestorInfo.Equals(input.RequestorInfo))
                ) && 
                (
                    this.CardholderInfo == input.CardholderInfo ||
                    (this.CardholderInfo != null &&
                    this.CardholderInfo.Equals(input.CardholderInfo))
                ) && 
                (
                    this.BroadcastInfo == input.BroadcastInfo ||
                    (this.BroadcastInfo != null &&
                    this.BroadcastInfo.Equals(input.BroadcastInfo))
                ) && 
                (
                    this.MessageExtensions == input.MessageExtensions ||
                    this.MessageExtensions != null &&
                    input.MessageExtensions != null &&
                    this.MessageExtensions.SequenceEqual(input.MessageExtensions)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.AuthenticationCategory != null)
                    hashCode = hashCode * 59 + this.AuthenticationCategory.GetHashCode();
                if (this.AuthenticationType != null)
                    hashCode = hashCode * 59 + this.AuthenticationType.GetHashCode();
                if (this.ChallengePreference != null)
                    hashCode = hashCode * 59 + this.ChallengePreference.GetHashCode();
                if (this.PurchaseInfo != null)
                    hashCode = hashCode * 59 + this.PurchaseInfo.GetHashCode();
                if (this.MerchantInfo != null)
                    hashCode = hashCode * 59 + this.MerchantInfo.GetHashCode();
                if (this.RequestorInfo != null)
                    hashCode = hashCode * 59 + this.RequestorInfo.GetHashCode();
                if (this.CardholderInfo != null)
                    hashCode = hashCode * 59 + this.CardholderInfo.GetHashCode();
                if (this.BroadcastInfo != null)
                    hashCode = hashCode * 59 + this.BroadcastInfo.GetHashCode();
                if (this.MessageExtensions != null)
                    hashCode = hashCode * 59 + this.MessageExtensions.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {

            // AuthenticationCategory (string) minLength
            if(this.AuthenticationCategory != null && this.AuthenticationCategory.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for AuthenticationCategory, length must be greater than 1.", new [] { "AuthenticationCategory" });
            }


            // AuthenticationType (string) minLength
            if(this.AuthenticationType != null && this.AuthenticationType.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for AuthenticationType, length must be greater than 1.", new [] { "AuthenticationType" });
            }

            yield break;
        }
    }

}
