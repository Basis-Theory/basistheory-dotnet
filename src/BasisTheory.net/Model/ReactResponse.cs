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
    /// ReactResponse
    /// </summary>
    [DataContract(Name = "ReactResponse")]
    public partial class ReactResponse : IEquatable<ReactResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReactResponse" /> class.
        /// </summary>
        /// <param name="tokens">tokens.</param>
        /// <param name="raw">raw.</param>
        /// <param name="body">body.</param>
        /// <param name="headers">headers.</param>
        public ReactResponse(Object tokens = default(Object), Object raw = default(Object), Object body = default(Object), Object headers = default(Object))
        {
            this.Tokens = tokens;
            this.Raw = raw;
            this.Body = body;
            this.Headers = headers;
        }

        /// <summary>
        /// Gets or Sets Tokens
        /// </summary>
        [DataMember(Name = "tokens", EmitDefaultValue = true)]
        public Object Tokens { get; set; }

        /// <summary>
        /// Gets or Sets Raw
        /// </summary>
        [DataMember(Name = "raw", EmitDefaultValue = true)]
        public Object Raw { get; set; }

        /// <summary>
        /// Gets or Sets Body
        /// </summary>
        [DataMember(Name = "body", EmitDefaultValue = true)]
        public Object Body { get; set; }

        /// <summary>
        /// Gets or Sets Headers
        /// </summary>
        [DataMember(Name = "headers", EmitDefaultValue = true)]
        public Object Headers { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ReactResponse {\n");
            sb.Append("  Tokens: ").Append(Tokens).Append("\n");
            sb.Append("  Raw: ").Append(Raw).Append("\n");
            sb.Append("  Body: ").Append(Body).Append("\n");
            sb.Append("  Headers: ").Append(Headers).Append("\n");
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
            return this.Equals(input as ReactResponse);
        }

        /// <summary>
        /// Returns true if ReactResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of ReactResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ReactResponse input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Tokens == input.Tokens ||
                    (this.Tokens != null &&
                    this.Tokens.Equals(input.Tokens))
                ) && 
                (
                    this.Raw == input.Raw ||
                    (this.Raw != null &&
                    this.Raw.Equals(input.Raw))
                ) && 
                (
                    this.Body == input.Body ||
                    (this.Body != null &&
                    this.Body.Equals(input.Body))
                ) && 
                (
                    this.Headers == input.Headers ||
                    (this.Headers != null &&
                    this.Headers.Equals(input.Headers))
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
                if (this.Tokens != null)
                {
                    hashCode = (hashCode * 59) + this.Tokens.GetHashCode();
                }
                if (this.Raw != null)
                {
                    hashCode = (hashCode * 59) + this.Raw.GetHashCode();
                }
                if (this.Body != null)
                {
                    hashCode = (hashCode * 59) + this.Body.GetHashCode();
                }
                if (this.Headers != null)
                {
                    hashCode = (hashCode * 59) + this.Headers.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
