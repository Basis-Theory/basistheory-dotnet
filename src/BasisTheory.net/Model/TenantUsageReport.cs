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
    /// TenantUsageReport
    /// </summary>
    [DataContract]
    public partial class TenantUsageReport :  IEquatable<TenantUsageReport>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TenantUsageReport" /> class.
        /// </summary>
        /// <param name="tokenReport">tokenReport.</param>
        public TenantUsageReport(TokenReport tokenReport = default(TokenReport))
        {
            this.TokenReport = tokenReport;
        }

        /// <summary>
        /// Gets or Sets TokenReport
        /// </summary>
        [DataMember(Name="token_report", EmitDefaultValue=false)]
        public TokenReport TokenReport { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TenantUsageReport {\n");
            sb.Append("  TokenReport: ").Append(TokenReport).Append("\n");
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
            return this.Equals(input as TenantUsageReport);
        }

        /// <summary>
        /// Returns true if TenantUsageReport instances are equal
        /// </summary>
        /// <param name="input">Instance of TenantUsageReport to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TenantUsageReport input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.TokenReport == input.TokenReport ||
                    (this.TokenReport != null &&
                    this.TokenReport.Equals(input.TokenReport))
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
                if (this.TokenReport != null)
                    hashCode = hashCode * 59 + this.TokenReport.GetHashCode();
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
