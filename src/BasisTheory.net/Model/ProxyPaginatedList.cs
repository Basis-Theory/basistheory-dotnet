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
    /// ProxyPaginatedList
    /// </summary>
    [DataContract]
    public partial class ProxyPaginatedList :  IEquatable<ProxyPaginatedList>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyPaginatedList" /> class.
        /// </summary>
        /// <param name="pagination">pagination.</param>
        /// <param name="data">data.</param>
        public ProxyPaginatedList(Pagination pagination = default(Pagination), List<Proxy> data = default(List<Proxy>))
        {
            this.Data = data;
            this.Pagination = pagination;
            this.Data = data;
        }

        /// <summary>
        /// Gets or Sets Pagination
        /// </summary>
        [DataMember(Name="pagination", EmitDefaultValue=false)]
        public Pagination Pagination { get; set; }

        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        [DataMember(Name="data", EmitDefaultValue=true)]
        public List<Proxy> Data { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ProxyPaginatedList {\n");
            sb.Append("  Pagination: ").Append(Pagination).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
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
            return this.Equals(input as ProxyPaginatedList);
        }

        /// <summary>
        /// Returns true if ProxyPaginatedList instances are equal
        /// </summary>
        /// <param name="input">Instance of ProxyPaginatedList to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProxyPaginatedList input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Pagination == input.Pagination ||
                    (this.Pagination != null &&
                    this.Pagination.Equals(input.Pagination))
                ) && 
                (
                    this.Data == input.Data ||
                    this.Data != null &&
                    input.Data != null &&
                    this.Data.SequenceEqual(input.Data)
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
                if (this.Pagination != null)
                    hashCode = hashCode * 59 + this.Pagination.GetHashCode();
                if (this.Data != null)
                    hashCode = hashCode * 59 + this.Data.GetHashCode();
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
