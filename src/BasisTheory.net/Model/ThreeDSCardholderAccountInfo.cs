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
    /// ThreeDSCardholderAccountInfo
    /// </summary>
    [DataContract]
    public partial class ThreeDSCardholderAccountInfo :  IEquatable<ThreeDSCardholderAccountInfo>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ThreeDSCardholderAccountInfo" /> class.
        /// </summary>
        /// <param name="accountAge">accountAge.</param>
        /// <param name="accountLastChanged">accountLastChanged.</param>
        /// <param name="accountChangeDate">accountChangeDate.</param>
        /// <param name="accountCreatedDate">accountCreatedDate.</param>
        /// <param name="accountPwdLastChanged">accountPwdLastChanged.</param>
        /// <param name="accountPwdChangeDate">accountPwdChangeDate.</param>
        /// <param name="purchaseCountHalfYear">purchaseCountHalfYear.</param>
        /// <param name="transactionCountDay">transactionCountDay.</param>
        /// <param name="paymentAccountAge">paymentAccountAge.</param>
        /// <param name="transactionCountYear">transactionCountYear.</param>
        /// <param name="paymentAccountCreated">paymentAccountCreated.</param>
        /// <param name="shippingAddressFirstUsed">shippingAddressFirstUsed.</param>
        /// <param name="shippingAddressUsageDate">shippingAddressUsageDate.</param>
        /// <param name="shippingAccountNameMatch">shippingAccountNameMatch.</param>
        /// <param name="suspiciousActivityObserved">suspiciousActivityObserved.</param>
        public ThreeDSCardholderAccountInfo(string accountAge = default(string), string accountLastChanged = default(string), string accountChangeDate = default(string), string accountCreatedDate = default(string), string accountPwdLastChanged = default(string), string accountPwdChangeDate = default(string), string purchaseCountHalfYear = default(string), string transactionCountDay = default(string), string paymentAccountAge = default(string), string transactionCountYear = default(string), string paymentAccountCreated = default(string), string shippingAddressFirstUsed = default(string), string shippingAddressUsageDate = default(string), bool? shippingAccountNameMatch = default(bool?), bool? suspiciousActivityObserved = default(bool?))
        {
            this.AccountAge = accountAge;
            this.AccountLastChanged = accountLastChanged;
            this.AccountChangeDate = accountChangeDate;
            this.AccountCreatedDate = accountCreatedDate;
            this.AccountPwdLastChanged = accountPwdLastChanged;
            this.AccountPwdChangeDate = accountPwdChangeDate;
            this.PurchaseCountHalfYear = purchaseCountHalfYear;
            this.TransactionCountDay = transactionCountDay;
            this.PaymentAccountAge = paymentAccountAge;
            this.TransactionCountYear = transactionCountYear;
            this.PaymentAccountCreated = paymentAccountCreated;
            this.ShippingAddressFirstUsed = shippingAddressFirstUsed;
            this.ShippingAddressUsageDate = shippingAddressUsageDate;
            this.ShippingAccountNameMatch = shippingAccountNameMatch;
            this.SuspiciousActivityObserved = suspiciousActivityObserved;
            this.AccountAge = accountAge;
            this.AccountLastChanged = accountLastChanged;
            this.AccountChangeDate = accountChangeDate;
            this.AccountCreatedDate = accountCreatedDate;
            this.AccountPwdLastChanged = accountPwdLastChanged;
            this.AccountPwdChangeDate = accountPwdChangeDate;
            this.PurchaseCountHalfYear = purchaseCountHalfYear;
            this.TransactionCountDay = transactionCountDay;
            this.PaymentAccountAge = paymentAccountAge;
            this.TransactionCountYear = transactionCountYear;
            this.PaymentAccountCreated = paymentAccountCreated;
            this.ShippingAddressFirstUsed = shippingAddressFirstUsed;
            this.ShippingAddressUsageDate = shippingAddressUsageDate;
            this.ShippingAccountNameMatch = shippingAccountNameMatch;
            this.SuspiciousActivityObserved = suspiciousActivityObserved;
        }

        /// <summary>
        /// Gets or Sets AccountAge
        /// </summary>
        [DataMember(Name="account_age", EmitDefaultValue=true)]
        public string AccountAge { get; set; }

        /// <summary>
        /// Gets or Sets AccountLastChanged
        /// </summary>
        [DataMember(Name="account_last_changed", EmitDefaultValue=true)]
        public string AccountLastChanged { get; set; }

        /// <summary>
        /// Gets or Sets AccountChangeDate
        /// </summary>
        [DataMember(Name="account_change_date", EmitDefaultValue=true)]
        public string AccountChangeDate { get; set; }

        /// <summary>
        /// Gets or Sets AccountCreatedDate
        /// </summary>
        [DataMember(Name="account_created_date", EmitDefaultValue=true)]
        public string AccountCreatedDate { get; set; }

        /// <summary>
        /// Gets or Sets AccountPwdLastChanged
        /// </summary>
        [DataMember(Name="account_pwd_last_changed", EmitDefaultValue=true)]
        public string AccountPwdLastChanged { get; set; }

        /// <summary>
        /// Gets or Sets AccountPwdChangeDate
        /// </summary>
        [DataMember(Name="account_pwd_change_date", EmitDefaultValue=true)]
        public string AccountPwdChangeDate { get; set; }

        /// <summary>
        /// Gets or Sets PurchaseCountHalfYear
        /// </summary>
        [DataMember(Name="purchase_count_half_year", EmitDefaultValue=true)]
        public string PurchaseCountHalfYear { get; set; }

        /// <summary>
        /// Gets or Sets TransactionCountDay
        /// </summary>
        [DataMember(Name="transaction_count_day", EmitDefaultValue=true)]
        public string TransactionCountDay { get; set; }

        /// <summary>
        /// Gets or Sets PaymentAccountAge
        /// </summary>
        [DataMember(Name="payment_account_age", EmitDefaultValue=true)]
        public string PaymentAccountAge { get; set; }

        /// <summary>
        /// Gets or Sets TransactionCountYear
        /// </summary>
        [DataMember(Name="transaction_count_year", EmitDefaultValue=true)]
        public string TransactionCountYear { get; set; }

        /// <summary>
        /// Gets or Sets PaymentAccountCreated
        /// </summary>
        [DataMember(Name="payment_account_created", EmitDefaultValue=true)]
        public string PaymentAccountCreated { get; set; }

        /// <summary>
        /// Gets or Sets ShippingAddressFirstUsed
        /// </summary>
        [DataMember(Name="shipping_address_first_used", EmitDefaultValue=true)]
        public string ShippingAddressFirstUsed { get; set; }

        /// <summary>
        /// Gets or Sets ShippingAddressUsageDate
        /// </summary>
        [DataMember(Name="shipping_address_usage_date", EmitDefaultValue=true)]
        public string ShippingAddressUsageDate { get; set; }

        /// <summary>
        /// Gets or Sets ShippingAccountNameMatch
        /// </summary>
        [DataMember(Name="shipping_account_name_match", EmitDefaultValue=true)]
        public bool? ShippingAccountNameMatch { get; set; }

        /// <summary>
        /// Gets or Sets SuspiciousActivityObserved
        /// </summary>
        [DataMember(Name="suspicious_activity_observed", EmitDefaultValue=true)]
        public bool? SuspiciousActivityObserved { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ThreeDSCardholderAccountInfo {\n");
            sb.Append("  AccountAge: ").Append(AccountAge).Append("\n");
            sb.Append("  AccountLastChanged: ").Append(AccountLastChanged).Append("\n");
            sb.Append("  AccountChangeDate: ").Append(AccountChangeDate).Append("\n");
            sb.Append("  AccountCreatedDate: ").Append(AccountCreatedDate).Append("\n");
            sb.Append("  AccountPwdLastChanged: ").Append(AccountPwdLastChanged).Append("\n");
            sb.Append("  AccountPwdChangeDate: ").Append(AccountPwdChangeDate).Append("\n");
            sb.Append("  PurchaseCountHalfYear: ").Append(PurchaseCountHalfYear).Append("\n");
            sb.Append("  TransactionCountDay: ").Append(TransactionCountDay).Append("\n");
            sb.Append("  PaymentAccountAge: ").Append(PaymentAccountAge).Append("\n");
            sb.Append("  TransactionCountYear: ").Append(TransactionCountYear).Append("\n");
            sb.Append("  PaymentAccountCreated: ").Append(PaymentAccountCreated).Append("\n");
            sb.Append("  ShippingAddressFirstUsed: ").Append(ShippingAddressFirstUsed).Append("\n");
            sb.Append("  ShippingAddressUsageDate: ").Append(ShippingAddressUsageDate).Append("\n");
            sb.Append("  ShippingAccountNameMatch: ").Append(ShippingAccountNameMatch).Append("\n");
            sb.Append("  SuspiciousActivityObserved: ").Append(SuspiciousActivityObserved).Append("\n");
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
            return this.Equals(input as ThreeDSCardholderAccountInfo);
        }

        /// <summary>
        /// Returns true if ThreeDSCardholderAccountInfo instances are equal
        /// </summary>
        /// <param name="input">Instance of ThreeDSCardholderAccountInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ThreeDSCardholderAccountInfo input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.AccountAge == input.AccountAge ||
                    (this.AccountAge != null &&
                    this.AccountAge.Equals(input.AccountAge))
                ) && 
                (
                    this.AccountLastChanged == input.AccountLastChanged ||
                    (this.AccountLastChanged != null &&
                    this.AccountLastChanged.Equals(input.AccountLastChanged))
                ) && 
                (
                    this.AccountChangeDate == input.AccountChangeDate ||
                    (this.AccountChangeDate != null &&
                    this.AccountChangeDate.Equals(input.AccountChangeDate))
                ) && 
                (
                    this.AccountCreatedDate == input.AccountCreatedDate ||
                    (this.AccountCreatedDate != null &&
                    this.AccountCreatedDate.Equals(input.AccountCreatedDate))
                ) && 
                (
                    this.AccountPwdLastChanged == input.AccountPwdLastChanged ||
                    (this.AccountPwdLastChanged != null &&
                    this.AccountPwdLastChanged.Equals(input.AccountPwdLastChanged))
                ) && 
                (
                    this.AccountPwdChangeDate == input.AccountPwdChangeDate ||
                    (this.AccountPwdChangeDate != null &&
                    this.AccountPwdChangeDate.Equals(input.AccountPwdChangeDate))
                ) && 
                (
                    this.PurchaseCountHalfYear == input.PurchaseCountHalfYear ||
                    (this.PurchaseCountHalfYear != null &&
                    this.PurchaseCountHalfYear.Equals(input.PurchaseCountHalfYear))
                ) && 
                (
                    this.TransactionCountDay == input.TransactionCountDay ||
                    (this.TransactionCountDay != null &&
                    this.TransactionCountDay.Equals(input.TransactionCountDay))
                ) && 
                (
                    this.PaymentAccountAge == input.PaymentAccountAge ||
                    (this.PaymentAccountAge != null &&
                    this.PaymentAccountAge.Equals(input.PaymentAccountAge))
                ) && 
                (
                    this.TransactionCountYear == input.TransactionCountYear ||
                    (this.TransactionCountYear != null &&
                    this.TransactionCountYear.Equals(input.TransactionCountYear))
                ) && 
                (
                    this.PaymentAccountCreated == input.PaymentAccountCreated ||
                    (this.PaymentAccountCreated != null &&
                    this.PaymentAccountCreated.Equals(input.PaymentAccountCreated))
                ) && 
                (
                    this.ShippingAddressFirstUsed == input.ShippingAddressFirstUsed ||
                    (this.ShippingAddressFirstUsed != null &&
                    this.ShippingAddressFirstUsed.Equals(input.ShippingAddressFirstUsed))
                ) && 
                (
                    this.ShippingAddressUsageDate == input.ShippingAddressUsageDate ||
                    (this.ShippingAddressUsageDate != null &&
                    this.ShippingAddressUsageDate.Equals(input.ShippingAddressUsageDate))
                ) && 
                (
                    this.ShippingAccountNameMatch == input.ShippingAccountNameMatch ||
                    (this.ShippingAccountNameMatch != null &&
                    this.ShippingAccountNameMatch.Equals(input.ShippingAccountNameMatch))
                ) && 
                (
                    this.SuspiciousActivityObserved == input.SuspiciousActivityObserved ||
                    (this.SuspiciousActivityObserved != null &&
                    this.SuspiciousActivityObserved.Equals(input.SuspiciousActivityObserved))
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
                if (this.AccountAge != null)
                    hashCode = hashCode * 59 + this.AccountAge.GetHashCode();
                if (this.AccountLastChanged != null)
                    hashCode = hashCode * 59 + this.AccountLastChanged.GetHashCode();
                if (this.AccountChangeDate != null)
                    hashCode = hashCode * 59 + this.AccountChangeDate.GetHashCode();
                if (this.AccountCreatedDate != null)
                    hashCode = hashCode * 59 + this.AccountCreatedDate.GetHashCode();
                if (this.AccountPwdLastChanged != null)
                    hashCode = hashCode * 59 + this.AccountPwdLastChanged.GetHashCode();
                if (this.AccountPwdChangeDate != null)
                    hashCode = hashCode * 59 + this.AccountPwdChangeDate.GetHashCode();
                if (this.PurchaseCountHalfYear != null)
                    hashCode = hashCode * 59 + this.PurchaseCountHalfYear.GetHashCode();
                if (this.TransactionCountDay != null)
                    hashCode = hashCode * 59 + this.TransactionCountDay.GetHashCode();
                if (this.PaymentAccountAge != null)
                    hashCode = hashCode * 59 + this.PaymentAccountAge.GetHashCode();
                if (this.TransactionCountYear != null)
                    hashCode = hashCode * 59 + this.TransactionCountYear.GetHashCode();
                if (this.PaymentAccountCreated != null)
                    hashCode = hashCode * 59 + this.PaymentAccountCreated.GetHashCode();
                if (this.ShippingAddressFirstUsed != null)
                    hashCode = hashCode * 59 + this.ShippingAddressFirstUsed.GetHashCode();
                if (this.ShippingAddressUsageDate != null)
                    hashCode = hashCode * 59 + this.ShippingAddressUsageDate.GetHashCode();
                if (this.ShippingAccountNameMatch != null)
                    hashCode = hashCode * 59 + this.ShippingAccountNameMatch.GetHashCode();
                if (this.SuspiciousActivityObserved != null)
                    hashCode = hashCode * 59 + this.SuspiciousActivityObserved.GetHashCode();
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
            yield break;
        }
    }

}