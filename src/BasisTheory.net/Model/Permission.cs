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
    /// Permission
    /// </summary>
    [DataContract]
    public partial class Permission :  IEquatable<Permission>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Permission" /> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="description">description.</param>
        /// <param name="applicationTypes">applicationTypes.</param>
        public Permission(string type = default(string), string description = default(string), List<string> applicationTypes = default(List<string>))
        {
            this.Type = type;
            this.Description = description;
            this.ApplicationTypes = applicationTypes;
            this.Type = type;
            this.Description = description;
            this.ApplicationTypes = applicationTypes;
        }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue=true)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue=true)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets ApplicationTypes
        /// </summary>
        [DataMember(Name="application_types", EmitDefaultValue=true)]
        public List<string> ApplicationTypes { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Permission {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  ApplicationTypes: ").Append(ApplicationTypes).Append("\n");
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
            return this.Equals(input as Permission);
        }

        /// <summary>
        /// Returns true if Permission instances are equal
        /// </summary>
        /// <param name="input">Instance of Permission to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Permission input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.ApplicationTypes == input.ApplicationTypes ||
                    this.ApplicationTypes != null &&
                    input.ApplicationTypes != null &&
                    this.ApplicationTypes.SequenceEqual(input.ApplicationTypes)
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
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.ApplicationTypes != null)
                    hashCode = hashCode * 59 + this.ApplicationTypes.GetHashCode();
                return hashCode;
            }
        }

    }

}
