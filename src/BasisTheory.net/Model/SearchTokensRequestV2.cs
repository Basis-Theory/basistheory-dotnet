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
    /// SearchTokensRequestV2
    /// </summary>
    [DataContract(Name = "SearchTokensRequestV2")]
    public partial class SearchTokensRequestV2 : IEquatable<SearchTokensRequestV2>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchTokensRequestV2" /> class.
        /// </summary>
        /// <param name="query">query.</param>
        /// <param name="start">start.</param>
        /// <param name="size">size.</param>
        public SearchTokensRequestV2(string query = default(string), string start = default(string), int? size = default(int?))
        {
            this.Query = query;
            this.Start = start;
            this.Size = size;
        }

        /// <summary>
        /// Gets or Sets Query
        /// </summary>
        [DataMember(Name = "query", EmitDefaultValue = true)]
        public string Query { get; set; }

        /// <summary>
        /// Gets or Sets Start
        /// </summary>
        [DataMember(Name = "start", EmitDefaultValue = true)]
        public string Start { get; set; }

        /// <summary>
        /// Gets or Sets Size
        /// </summary>
        [DataMember(Name = "size", EmitDefaultValue = true)]
        public int? Size { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SearchTokensRequestV2 {\n");
            sb.Append("  Query: ").Append(Query).Append("\n");
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
            return this.Equals(input as SearchTokensRequestV2);
        }

        /// <summary>
        /// Returns true if SearchTokensRequestV2 instances are equal
        /// </summary>
        /// <param name="input">Instance of SearchTokensRequestV2 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SearchTokensRequestV2 input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Query == input.Query ||
                    (this.Query != null &&
                    this.Query.Equals(input.Query))
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
                {
                    hashCode = (hashCode * 59) + this.Query.GetHashCode();
                }
                if (this.Start != null)
                {
                    hashCode = (hashCode * 59) + this.Start.GetHashCode();
                }
                if (this.Size != null)
                {
                    hashCode = (hashCode * 59) + this.Size.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
