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
    /// GetLogs
    /// </summary>
    [DataContract]
    public partial class GetLogs :  IEquatable<GetLogs>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetLogs" /> class.
        /// </summary>
        /// <param name="entityType">entityType.</param>
        /// <param name="entityId">entityId.</param>
        /// <param name="startDate">startDate.</param>
        /// <param name="endDate">endDate.</param>
        /// <param name="page">page.</param>
        /// <param name="start">start.</param>
        /// <param name="size">size.</param>
        public GetLogs(string entityType = default(string), string entityId = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int? page = default(int?), string start = default(string), int? size = default(int?))
        {
            this.EntityType = entityType;
            this.EntityId = entityId;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Page = page;
            this.Start = start;
            this.Size = size;
            this.EntityType = entityType;
            this.EntityId = entityId;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Page = page;
            this.Start = start;
            this.Size = size;
        }

        /// <summary>
        /// Gets or Sets EntityType
        /// </summary>
        [DataMember(Name="entity_type", EmitDefaultValue=true)]
        public string EntityType { get; set; }

        /// <summary>
        /// Gets or Sets EntityId
        /// </summary>
        [DataMember(Name="entity_id", EmitDefaultValue=true)]
        public string EntityId { get; set; }

        /// <summary>
        /// Gets or Sets StartDate
        /// </summary>
        [DataMember(Name="start_date", EmitDefaultValue=true)]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or Sets EndDate
        /// </summary>
        [DataMember(Name="end_date", EmitDefaultValue=true)]
        public DateTime? EndDate { get; set; }

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
            sb.Append("class GetLogs {\n");
            sb.Append("  EntityType: ").Append(EntityType).Append("\n");
            sb.Append("  EntityId: ").Append(EntityId).Append("\n");
            sb.Append("  StartDate: ").Append(StartDate).Append("\n");
            sb.Append("  EndDate: ").Append(EndDate).Append("\n");
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
            return this.Equals(input as GetLogs);
        }

        /// <summary>
        /// Returns true if GetLogs instances are equal
        /// </summary>
        /// <param name="input">Instance of GetLogs to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetLogs input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.EntityType == input.EntityType ||
                    (this.EntityType != null &&
                    this.EntityType.Equals(input.EntityType))
                ) && 
                (
                    this.EntityId == input.EntityId ||
                    (this.EntityId != null &&
                    this.EntityId.Equals(input.EntityId))
                ) && 
                (
                    this.StartDate == input.StartDate ||
                    (this.StartDate != null &&
                    this.StartDate.Equals(input.StartDate))
                ) && 
                (
                    this.EndDate == input.EndDate ||
                    (this.EndDate != null &&
                    this.EndDate.Equals(input.EndDate))
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
                if (this.EntityType != null)
                    hashCode = hashCode * 59 + this.EntityType.GetHashCode();
                if (this.EntityId != null)
                    hashCode = hashCode * 59 + this.EntityId.GetHashCode();
                if (this.StartDate != null)
                    hashCode = hashCode * 59 + this.StartDate.GetHashCode();
                if (this.EndDate != null)
                    hashCode = hashCode * 59 + this.EndDate.GetHashCode();
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
            // EntityType (string) maxLength
            if(this.EntityType != null && this.EntityType.ToString().Length > 50)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for EntityType, length must be less than 50.", new [] { "EntityType" });
            }


            // EntityType (string) pattern
            Regex regexEntityType = new Regex(@"^[A-z]+$", RegexOptions.CultureInvariant);
            if (false == regexEntityType.Match(this.EntityType.ToString()).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for EntityType, must match a pattern of " + regexEntityType, new [] { "EntityType" });
            }

            // EntityId (string) maxLength
            if(this.EntityId != null && this.EntityId.ToString().Length > 200)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for EntityId, length must be less than 200.", new [] { "EntityId" });
            }


            // EntityId (string) pattern
            Regex regexEntityId = new Regex(@"^.+$", RegexOptions.CultureInvariant);
            if (false == regexEntityId.Match(this.EntityId.ToString()).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for EntityId, must match a pattern of " + regexEntityId, new [] { "EntityId" });
            }

            // StartDate (DateTime?) maxLength
            if(this.StartDate != null && this.StartDate.ToString().Length > 40)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for StartDate, length must be less than 40.", new [] { "StartDate" });
            }


            // EndDate (DateTime?) maxLength
            if(this.EndDate != null && this.EndDate.ToString().Length > 40)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for EndDate, length must be less than 40.", new [] { "EndDate" });
            }


            // Start (string) maxLength
            if(this.Start != null && this.Start.ToString().Length > 500)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Start, length must be less than 500.", new [] { "Start" });
            }


            // Start (string) pattern
            Regex regexStart = new Regex(@"^.+$", RegexOptions.CultureInvariant);
            if (false == regexStart.Match(this.Start.ToString()).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Start, must match a pattern of " + regexStart, new [] { "Start" });
            }



            // Size (int?) maximum
            if(this.Size > (int?)5000)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Size, must be a value less than or equal to 5000.", new [] { "Size" });
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