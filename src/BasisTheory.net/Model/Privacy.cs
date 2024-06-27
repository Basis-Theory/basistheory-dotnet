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
    /// Privacy
    /// </summary>
    [DataContract]
    public partial class Privacy :  IEquatable<Privacy>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Privacy" /> class.
        /// </summary>
        /// <param name="classification">classification.</param>
        /// <param name="impactLevel">impactLevel.</param>
        /// <param name="restrictionPolicy">restrictionPolicy.</param>
        public Privacy(string classification = default(string), string impactLevel = default(string), string restrictionPolicy = default(string))
        {
            this.Classification = classification;
            this.ImpactLevel = impactLevel;
            this.RestrictionPolicy = restrictionPolicy;
            this.Classification = classification;
            this.ImpactLevel = impactLevel;
            this.RestrictionPolicy = restrictionPolicy;
        }

        /// <summary>
        /// Gets or Sets Classification
        /// </summary>
        [DataMember(Name="classification", EmitDefaultValue=true)]
        public string Classification { get; set; }

        /// <summary>
        /// Gets or Sets ImpactLevel
        /// </summary>
        [DataMember(Name="impact_level", EmitDefaultValue=true)]
        public string ImpactLevel { get; set; }

        /// <summary>
        /// Gets or Sets RestrictionPolicy
        /// </summary>
        [DataMember(Name="restriction_policy", EmitDefaultValue=true)]
        public string RestrictionPolicy { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Privacy {\n");
            sb.Append("  Classification: ").Append(Classification).Append("\n");
            sb.Append("  ImpactLevel: ").Append(ImpactLevel).Append("\n");
            sb.Append("  RestrictionPolicy: ").Append(RestrictionPolicy).Append("\n");
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
            return this.Equals(input as Privacy);
        }

        /// <summary>
        /// Returns true if Privacy instances are equal
        /// </summary>
        /// <param name="input">Instance of Privacy to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Privacy input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Classification == input.Classification ||
                    (this.Classification != null &&
                    this.Classification.Equals(input.Classification))
                ) && 
                (
                    this.ImpactLevel == input.ImpactLevel ||
                    (this.ImpactLevel != null &&
                    this.ImpactLevel.Equals(input.ImpactLevel))
                ) && 
                (
                    this.RestrictionPolicy == input.RestrictionPolicy ||
                    (this.RestrictionPolicy != null &&
                    this.RestrictionPolicy.Equals(input.RestrictionPolicy))
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
                if (this.Classification != null)
                    hashCode = hashCode * 59 + this.Classification.GetHashCode();
                if (this.ImpactLevel != null)
                    hashCode = hashCode * 59 + this.ImpactLevel.GetHashCode();
                if (this.RestrictionPolicy != null)
                    hashCode = hashCode * 59 + this.RestrictionPolicy.GetHashCode();
                return hashCode;
            }
        }

    }

}
