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
    /// StringStringKeyValuePair
    /// </summary>
    [DataContract]
    public partial class StringStringKeyValuePair :  IEquatable<StringStringKeyValuePair>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringStringKeyValuePair" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected StringStringKeyValuePair() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="StringStringKeyValuePair" /> class.
        /// </summary>
        /// <param name="key">key (required).</param>
        /// <param name="value">value (required).</param>
        public StringStringKeyValuePair(string key = default(string), string value = default(string))
        {
            // to ensure "key" is required (not null)
            if (key == null)
            {
                throw new InvalidDataException("key is a required property for StringStringKeyValuePair and cannot be null");
            }
            else
            {
                this.Key = key;
            }

            // to ensure "value" is required (not null)
            if (value == null)
            {
                throw new InvalidDataException("value is a required property for StringStringKeyValuePair and cannot be null");
            }
            else
            {
                this.Value = value;
            }

        }

        /// <summary>
        /// Gets or Sets Key
        /// </summary>
        [DataMember(Name="key", EmitDefaultValue=true)]
        public string Key { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name="value", EmitDefaultValue=true)]
        public string Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StringStringKeyValuePair {\n");
            sb.Append("  Key: ").Append(Key).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
            return this.Equals(input as StringStringKeyValuePair);
        }

        /// <summary>
        /// Returns true if StringStringKeyValuePair instances are equal
        /// </summary>
        /// <param name="input">Instance of StringStringKeyValuePair to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(StringStringKeyValuePair input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Key == input.Key ||
                    (this.Key != null &&
                    this.Key.Equals(input.Key))
                ) && 
                (
                    this.Value == input.Value ||
                    (this.Value != null &&
                    this.Value.Equals(input.Value))
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
                if (this.Key != null)
                    hashCode = hashCode * 59 + this.Key.GetHashCode();
                if (this.Value != null)
                    hashCode = hashCode * 59 + this.Value.GetHashCode();
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
            // Key (string) maxLength
            if(this.Key != null && this.Key.Length > 200)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Key, length must be less than 200.", new [] { "Key" });
            }

            // Key (string) minLength
            if(this.Key != null && this.Key.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Key, length must be greater than 1.", new [] { "Key" });
            }

            // Key (string) pattern
            Regex regexKey = new Regex(@"^[\\w-]+$", RegexOptions.CultureInvariant);
            if (false == regexKey.Match(this.Key).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Key, must match a pattern of " + regexKey, new [] { "Key" });
            }

            // Value (string) maxLength
            if(this.Value != null && this.Value.Length > 200)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Value, length must be less than 200.", new [] { "Value" });
            }

            // Value (string) minLength
            if(this.Value != null && this.Value.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Value, length must be greater than 1.", new [] { "Value" });
            }

            yield break;
        }
    }

}
