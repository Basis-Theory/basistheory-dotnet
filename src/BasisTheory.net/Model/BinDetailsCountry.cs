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
    /// BinDetailsCountry
    /// </summary>
    [DataContract]
    public partial class BinDetailsCountry :  IEquatable<BinDetailsCountry>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BinDetailsCountry" /> class.
        /// </summary>
        /// <param name="alpha2">alpha2.</param>
        /// <param name="name">name.</param>
        /// <param name="numeric">numeric.</param>
        public BinDetailsCountry(string alpha2 = default(string), string name = default(string), string numeric = default(string))
        {
            this.Alpha2 = alpha2;
            this.Name = name;
            this.Numeric = numeric;
            this.Alpha2 = alpha2;
            this.Name = name;
            this.Numeric = numeric;
        }

        /// <summary>
        /// Gets or Sets Alpha2
        /// </summary>
        [DataMember(Name="alpha2", EmitDefaultValue=true)]
        public string Alpha2 { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Numeric
        /// </summary>
        [DataMember(Name="numeric", EmitDefaultValue=true)]
        public string Numeric { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BinDetailsCountry {\n");
            sb.Append("  Alpha2: ").Append(Alpha2).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Numeric: ").Append(Numeric).Append("\n");
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
            return this.Equals(input as BinDetailsCountry);
        }

        /// <summary>
        /// Returns true if BinDetailsCountry instances are equal
        /// </summary>
        /// <param name="input">Instance of BinDetailsCountry to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BinDetailsCountry input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Alpha2 == input.Alpha2 ||
                    (this.Alpha2 != null &&
                    this.Alpha2.Equals(input.Alpha2))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Numeric == input.Numeric ||
                    (this.Numeric != null &&
                    this.Numeric.Equals(input.Numeric))
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
                if (this.Alpha2 != null)
                    hashCode = hashCode * 59 + this.Alpha2.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Numeric != null)
                    hashCode = hashCode * 59 + this.Numeric.GetHashCode();
                return hashCode;
            }
        }

    }

}
