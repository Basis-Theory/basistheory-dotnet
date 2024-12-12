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
    /// TokenExtras
    /// </summary>
    [DataContract(Name = "TokenExtras")]
    public partial class TokenExtras : IEquatable<TokenExtras>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenExtras" /> class.
        /// </summary>
        /// <param name="deduplicated">deduplicated.</param>
        public TokenExtras(bool deduplicated = default(bool))
        {
            this.Deduplicated = deduplicated;
        }

        /// <summary>
        /// Gets or Sets Deduplicated
        /// </summary>
        [DataMember(Name = "deduplicated", EmitDefaultValue = true)]
        public bool Deduplicated { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TokenExtras {\n");
            sb.Append("  Deduplicated: ").Append(Deduplicated).Append("\n");
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
            return this.Equals(input as TokenExtras);
        }

        /// <summary>
        /// Returns true if TokenExtras instances are equal
        /// </summary>
        /// <param name="input">Instance of TokenExtras to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TokenExtras input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Deduplicated == input.Deduplicated ||
                    this.Deduplicated.Equals(input.Deduplicated)
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
                hashCode = (hashCode * 59) + this.Deduplicated.GetHashCode();
                return hashCode;
            }
        }

    }

}