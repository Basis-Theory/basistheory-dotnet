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
    /// ReactorFormulaRequestParameter
    /// </summary>
    [DataContract(Name = "ReactorFormulaRequestParameter")]
    public partial class ReactorFormulaRequestParameter : IEquatable<ReactorFormulaRequestParameter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReactorFormulaRequestParameter" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ReactorFormulaRequestParameter() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ReactorFormulaRequestParameter" /> class.
        /// </summary>
        /// <param name="name">name (required).</param>
        /// <param name="description">description.</param>
        /// <param name="type">type (required).</param>
        /// <param name="optional">optional.</param>
        public ReactorFormulaRequestParameter(string name = default(string), string description = default(string), string type = default(string), bool optional = default(bool))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for ReactorFormulaRequestParameter and cannot be null");
            }
            this.Name = name;
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new ArgumentNullException("type is a required property for ReactorFormulaRequestParameter and cannot be null");
            }
            this.Type = type;
            this.Description = description;
            this.Optional = optional;
        }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = true)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets Optional
        /// </summary>
        [DataMember(Name = "optional", EmitDefaultValue = true)]
        public bool Optional { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ReactorFormulaRequestParameter {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Optional: ").Append(Optional).Append("\n");
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
            return this.Equals(input as ReactorFormulaRequestParameter);
        }

        /// <summary>
        /// Returns true if ReactorFormulaRequestParameter instances are equal
        /// </summary>
        /// <param name="input">Instance of ReactorFormulaRequestParameter to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ReactorFormulaRequestParameter input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.Optional == input.Optional ||
                    this.Optional.Equals(input.Optional)
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
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }
                if (this.Type != null)
                {
                    hashCode = (hashCode * 59) + this.Type.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Optional.GetHashCode();
                return hashCode;
            }
        }

    }

}
