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
    /// ThreeDSPurchaseInfo
    /// </summary>
    [DataContract]
    public partial class ThreeDSPurchaseInfo :  IEquatable<ThreeDSPurchaseInfo>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ThreeDSPurchaseInfo" /> class.
        /// </summary>
        /// <param name="amount">amount.</param>
        /// <param name="currency">currency.</param>
        /// <param name="exponent">exponent.</param>
        /// <param name="date">date.</param>
        /// <param name="transactionType">transactionType.</param>
        /// <param name="installmentCount">installmentCount.</param>
        /// <param name="recurringExpiration">recurringExpiration.</param>
        /// <param name="recurringFrequency">recurringFrequency.</param>
        public ThreeDSPurchaseInfo(string amount = default(string), string currency = default(string), string exponent = default(string), string date = default(string), string transactionType = default(string), string installmentCount = default(string), string recurringExpiration = default(string), string recurringFrequency = default(string))
        {
            this.Amount = amount;
            this.Currency = currency;
            this.Exponent = exponent;
            this.Date = date;
            this.TransactionType = transactionType;
            this.InstallmentCount = installmentCount;
            this.RecurringExpiration = recurringExpiration;
            this.RecurringFrequency = recurringFrequency;
            this.Amount = amount;
            this.Currency = currency;
            this.Exponent = exponent;
            this.Date = date;
            this.TransactionType = transactionType;
            this.InstallmentCount = installmentCount;
            this.RecurringExpiration = recurringExpiration;
            this.RecurringFrequency = recurringFrequency;
        }

        /// <summary>
        /// Gets or Sets Amount
        /// </summary>
        [DataMember(Name="amount", EmitDefaultValue=true)]
        public string Amount { get; set; }

        /// <summary>
        /// Gets or Sets Currency
        /// </summary>
        [DataMember(Name="currency", EmitDefaultValue=true)]
        public string Currency { get; set; }

        /// <summary>
        /// Gets or Sets Exponent
        /// </summary>
        [DataMember(Name="exponent", EmitDefaultValue=true)]
        public string Exponent { get; set; }

        /// <summary>
        /// Gets or Sets Date
        /// </summary>
        [DataMember(Name="date", EmitDefaultValue=true)]
        public string Date { get; set; }

        /// <summary>
        /// Gets or Sets TransactionType
        /// </summary>
        [DataMember(Name="transaction_type", EmitDefaultValue=true)]
        public string TransactionType { get; set; }

        /// <summary>
        /// Gets or Sets InstallmentCount
        /// </summary>
        [DataMember(Name="installment_count", EmitDefaultValue=true)]
        public string InstallmentCount { get; set; }

        /// <summary>
        /// Gets or Sets RecurringExpiration
        /// </summary>
        [DataMember(Name="recurring_expiration", EmitDefaultValue=true)]
        public string RecurringExpiration { get; set; }

        /// <summary>
        /// Gets or Sets RecurringFrequency
        /// </summary>
        [DataMember(Name="recurring_frequency", EmitDefaultValue=true)]
        public string RecurringFrequency { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ThreeDSPurchaseInfo {\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  Currency: ").Append(Currency).Append("\n");
            sb.Append("  Exponent: ").Append(Exponent).Append("\n");
            sb.Append("  Date: ").Append(Date).Append("\n");
            sb.Append("  TransactionType: ").Append(TransactionType).Append("\n");
            sb.Append("  InstallmentCount: ").Append(InstallmentCount).Append("\n");
            sb.Append("  RecurringExpiration: ").Append(RecurringExpiration).Append("\n");
            sb.Append("  RecurringFrequency: ").Append(RecurringFrequency).Append("\n");
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
            return this.Equals(input as ThreeDSPurchaseInfo);
        }

        /// <summary>
        /// Returns true if ThreeDSPurchaseInfo instances are equal
        /// </summary>
        /// <param name="input">Instance of ThreeDSPurchaseInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ThreeDSPurchaseInfo input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Amount == input.Amount ||
                    (this.Amount != null &&
                    this.Amount.Equals(input.Amount))
                ) && 
                (
                    this.Currency == input.Currency ||
                    (this.Currency != null &&
                    this.Currency.Equals(input.Currency))
                ) && 
                (
                    this.Exponent == input.Exponent ||
                    (this.Exponent != null &&
                    this.Exponent.Equals(input.Exponent))
                ) && 
                (
                    this.Date == input.Date ||
                    (this.Date != null &&
                    this.Date.Equals(input.Date))
                ) && 
                (
                    this.TransactionType == input.TransactionType ||
                    (this.TransactionType != null &&
                    this.TransactionType.Equals(input.TransactionType))
                ) && 
                (
                    this.InstallmentCount == input.InstallmentCount ||
                    (this.InstallmentCount != null &&
                    this.InstallmentCount.Equals(input.InstallmentCount))
                ) && 
                (
                    this.RecurringExpiration == input.RecurringExpiration ||
                    (this.RecurringExpiration != null &&
                    this.RecurringExpiration.Equals(input.RecurringExpiration))
                ) && 
                (
                    this.RecurringFrequency == input.RecurringFrequency ||
                    (this.RecurringFrequency != null &&
                    this.RecurringFrequency.Equals(input.RecurringFrequency))
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
                if (this.Amount != null)
                    hashCode = hashCode * 59 + this.Amount.GetHashCode();
                if (this.Currency != null)
                    hashCode = hashCode * 59 + this.Currency.GetHashCode();
                if (this.Exponent != null)
                    hashCode = hashCode * 59 + this.Exponent.GetHashCode();
                if (this.Date != null)
                    hashCode = hashCode * 59 + this.Date.GetHashCode();
                if (this.TransactionType != null)
                    hashCode = hashCode * 59 + this.TransactionType.GetHashCode();
                if (this.InstallmentCount != null)
                    hashCode = hashCode * 59 + this.InstallmentCount.GetHashCode();
                if (this.RecurringExpiration != null)
                    hashCode = hashCode * 59 + this.RecurringExpiration.GetHashCode();
                if (this.RecurringFrequency != null)
                    hashCode = hashCode * 59 + this.RecurringFrequency.GetHashCode();
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
