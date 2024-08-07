/*
 * Basis Theory API
 *
 * ## Getting Started * Sign-in to [Basis Theory](https://basistheory.com) and go to [Applications](https://portal.basistheory.com/applications) * Create a Basis Theory Private Application * All permissions should be selected * Paste the API Key into the `BT-API-KEY` variable
 *
 * The version of the OpenAPI document: v1
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using OpenAPIDateConverter = BasisTheory.net.Client.OpenAPIDateConverter;

namespace BasisTheory.net.Model
{
    /// <summary>
    /// CardDetails
    /// </summary>
    [DataContract(Name = "CardDetails")]
    public partial class CardDetails : IEquatable<CardDetails>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CardDetails" /> class.
        /// </summary>
        /// <param name="bin">bin.</param>
        /// <param name="last4">last4.</param>
        public CardDetails(string bin = default(string), string last4 = default(string))
        {
            this.Bin = bin;
            this.Last4 = last4;
        }

        /// <summary>
        /// Gets or Sets Bin
        /// </summary>
        [DataMember(Name = "bin", EmitDefaultValue = true)]
        public string Bin { get; set; }

        /// <summary>
        /// Gets or Sets Last4
        /// </summary>
        [DataMember(Name = "last4", EmitDefaultValue = true)]
        public string Last4 { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CardDetails {\n");
            sb.Append("  Bin: ").Append(Bin).Append("\n");
            sb.Append("  Last4: ").Append(Last4).Append("\n");
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
            return this.Equals(input as CardDetails);
        }

        /// <summary>
        /// Returns true if CardDetails instances are equal
        /// </summary>
        /// <param name="input">Instance of CardDetails to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CardDetails input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Bin == input.Bin ||
                    (this.Bin != null &&
                    this.Bin.Equals(input.Bin))
                ) && 
                (
                    this.Last4 == input.Last4 ||
                    (this.Last4 != null &&
                    this.Last4.Equals(input.Last4))
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
                if (this.Bin != null)
                {
                    hashCode = (hashCode * 59) + this.Bin.GetHashCode();
                }
                if (this.Last4 != null)
                {
                    hashCode = (hashCode * 59) + this.Last4.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
