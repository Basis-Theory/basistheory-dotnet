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
    /// SearchTokensRequest
    /// </summary>
    [DataContract]
    public partial class SearchTokensRequest :  IEquatable<SearchTokensRequest>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchTokensRequest" /> class.
        /// </summary>
        /// <param name="query">query.</param>
        /// <param name="page">page.</param>
        /// <param name="start">start.</param>
        /// <param name="size">size.</param>
        public SearchTokensRequest(string query = default(string), int? page = default(int?), string start = default(string), int? size = default(int?))
        {
            this.Query = query;
            this.Page = page;
            this.Start = start;
            this.Size = size;
            this.Query = query;
            this.Page = page;
            this.Start = start;
            this.Size = size;
        }

        /// <summary>
        /// Gets or Sets Query
        /// </summary>
        [DataMember(Name="query", EmitDefaultValue=true)]
        public string Query { get; set; }

        /// <summary>
        /// Gets or Sets Page
        /// </summary>
        [DataMember(Name="page", EmitDefaultValue=true)]
        public int? Page { get; set; }

        /// <summary>
        /// Gets or Sets Start
        /// </summary>
        [DataMember(Name="start", EmitDefaultValue=true)]
        public string Start { get; set; }

        /// <summary>
        /// Gets or Sets Size
        /// </summary>
        [DataMember(Name="size", EmitDefaultValue=true)]
        public int? Size { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SearchTokensRequest {\n");
            sb.Append("  Query: ").Append(Query).Append("\n");
            sb.Append("  Page: ").Append(Page).Append("\n");
            sb.Append("  Start: ").Append(Start).Append("\n");
            sb.Append("  Size: ").Append(Size).Append("\n");
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
            return this.Equals(input as SearchTokensRequest);
        }

        /// <summary>
        /// Returns true if SearchTokensRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of SearchTokensRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SearchTokensRequest input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Query == input.Query ||
                    (this.Query != null &&
                    this.Query.Equals(input.Query))
                ) && 
                (
                    this.Page == input.Page ||
                    (this.Page != null &&
                    this.Page.Equals(input.Page))
                ) && 
                (
                    this.Start == input.Start ||
                    (this.Start != null &&
                    this.Start.Equals(input.Start))
                ) && 
                (
                    this.Size == input.Size ||
                    (this.Size != null &&
                    this.Size.Equals(input.Size))
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
                if (this.Query != null)
                    hashCode = hashCode * 59 + this.Query.GetHashCode();
                if (this.Page != null)
                    hashCode = hashCode * 59 + this.Page.GetHashCode();
                if (this.Start != null)
                    hashCode = hashCode * 59 + this.Start.GetHashCode();
                if (this.Size != null)
                    hashCode = hashCode * 59 + this.Size.GetHashCode();
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
            // Query (string) maxLength
            if(this.Query != null && this.Query.ToString().Length > 200)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Query, length must be less than 200.", new [] { "Query" });
            }


            // Query (string) pattern
            Regex regexQuery = new Regex(@"^.*$", RegexOptions.CultureInvariant);
            if (false == regexQuery.Match(this.Query.ToString()).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Query, must match a pattern of " + regexQuery, new [] { "Query" });
            }



            // Page (int?) maximum
            if(this.Page > (int?)2147483647)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Page, must be a value less than or equal to 2147483647.", new [] { "Page" });
            }

            // Page (int?) minimum
            if(this.Page < (int?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Page, must be a value greater than or equal to 0.", new [] { "Page" });
            }



            // Size (int?) maximum
            if(this.Size > (int?)100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Size, must be a value less than or equal to 100.", new [] { "Size" });
            }

            // Size (int?) minimum
            if(this.Size < (int?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Size, must be a value greater than or equal to 0.", new [] { "Size" });
            }

            yield break;
        }
    }

}
