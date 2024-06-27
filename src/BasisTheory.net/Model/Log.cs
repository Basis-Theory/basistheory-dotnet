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
    /// Log
    /// </summary>
    [DataContract]
    public partial class Log :  IEquatable<Log>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Log" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="tenantId">tenantId.</param>
        /// <param name="actorId">actorId.</param>
        /// <param name="actorType">actorType.</param>
        /// <param name="entityType">entityType.</param>
        /// <param name="entityId">entityId.</param>
        /// <param name="operation">operation.</param>
        /// <param name="message">message.</param>
        /// <param name="createdAt">createdAt.</param>
        public Log(string id = default(string), Guid tenantId = default(Guid), Guid? actorId = default(Guid?), string actorType = default(string), string entityType = default(string), string entityId = default(string), string operation = default(string), string message = default(string), DateTime? createdAt = default(DateTime?))
        {
            this.Id = id;
            this.ActorId = actorId;
            this.ActorType = actorType;
            this.EntityType = entityType;
            this.EntityId = entityId;
            this.Operation = operation;
            this.Message = message;
            this.CreatedAt = createdAt;
            this.Id = id;
            this.TenantId = tenantId;
            this.ActorId = actorId;
            this.ActorType = actorType;
            this.EntityType = entityType;
            this.EntityId = entityId;
            this.Operation = operation;
            this.Message = message;
            this.CreatedAt = createdAt;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=true)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets TenantId
        /// </summary>
        [DataMember(Name="tenant_id", EmitDefaultValue=false)]
        public Guid TenantId { get; set; }

        /// <summary>
        /// Gets or Sets ActorId
        /// </summary>
        [DataMember(Name="actor_id", EmitDefaultValue=true)]
        public Guid? ActorId { get; set; }

        /// <summary>
        /// Gets or Sets ActorType
        /// </summary>
        [DataMember(Name="actor_type", EmitDefaultValue=true)]
        public string ActorType { get; set; }

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
        /// Gets or Sets Operation
        /// </summary>
        [DataMember(Name="operation", EmitDefaultValue=true)]
        public string Operation { get; set; }

        /// <summary>
        /// Gets or Sets Message
        /// </summary>
        [DataMember(Name="message", EmitDefaultValue=true)]
        public string Message { get; set; }

        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        [DataMember(Name="created_at", EmitDefaultValue=true)]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Log {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  TenantId: ").Append(TenantId).Append("\n");
            sb.Append("  ActorId: ").Append(ActorId).Append("\n");
            sb.Append("  ActorType: ").Append(ActorType).Append("\n");
            sb.Append("  EntityType: ").Append(EntityType).Append("\n");
            sb.Append("  EntityId: ").Append(EntityId).Append("\n");
            sb.Append("  Operation: ").Append(Operation).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
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
            return this.Equals(input as Log);
        }

        /// <summary>
        /// Returns true if Log instances are equal
        /// </summary>
        /// <param name="input">Instance of Log to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Log input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.TenantId == input.TenantId ||
                    (this.TenantId != null &&
                    this.TenantId.Equals(input.TenantId))
                ) && 
                (
                    this.ActorId == input.ActorId ||
                    (this.ActorId != null &&
                    this.ActorId.Equals(input.ActorId))
                ) && 
                (
                    this.ActorType == input.ActorType ||
                    (this.ActorType != null &&
                    this.ActorType.Equals(input.ActorType))
                ) && 
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
                    this.Operation == input.Operation ||
                    (this.Operation != null &&
                    this.Operation.Equals(input.Operation))
                ) && 
                (
                    this.Message == input.Message ||
                    (this.Message != null &&
                    this.Message.Equals(input.Message))
                ) && 
                (
                    this.CreatedAt == input.CreatedAt ||
                    (this.CreatedAt != null &&
                    this.CreatedAt.Equals(input.CreatedAt))
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
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.TenantId != null)
                    hashCode = hashCode * 59 + this.TenantId.GetHashCode();
                if (this.ActorId != null)
                    hashCode = hashCode * 59 + this.ActorId.GetHashCode();
                if (this.ActorType != null)
                    hashCode = hashCode * 59 + this.ActorType.GetHashCode();
                if (this.EntityType != null)
                    hashCode = hashCode * 59 + this.EntityType.GetHashCode();
                if (this.EntityId != null)
                    hashCode = hashCode * 59 + this.EntityId.GetHashCode();
                if (this.Operation != null)
                    hashCode = hashCode * 59 + this.Operation.GetHashCode();
                if (this.Message != null)
                    hashCode = hashCode * 59 + this.Message.GetHashCode();
                if (this.CreatedAt != null)
                    hashCode = hashCode * 59 + this.CreatedAt.GetHashCode();
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
            // TenantId (Guid) maxLength
            if(this.TenantId != null && this.TenantId.Length > 36)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for TenantId, length must be less than 36.", new [] { "TenantId" });
            }


            // TenantId (Guid) pattern
            Regex regexTenantId = new Regex(@"^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$", RegexOptions.CultureInvariant);
            if (false == regexTenantId.Match(this.TenantId).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for TenantId, must match a pattern of " + regexTenantId, new [] { "TenantId" });
            }

            // ActorId (Guid?) maxLength
            if(this.ActorId != null && this.ActorId.Length > 36)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ActorId, length must be less than 36.", new [] { "ActorId" });
            }


            // ActorId (Guid?) pattern
            Regex regexActorId = new Regex(@"^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$", RegexOptions.CultureInvariant);
            if (false == regexActorId.Match(this.ActorId).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ActorId, must match a pattern of " + regexActorId, new [] { "ActorId" });
            }

            // ActorType (string) maxLength
            if(this.ActorType != null && this.ActorType.Length > 50)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ActorType, length must be less than 50.", new [] { "ActorType" });
            }


            // ActorType (string) pattern
            Regex regexActorType = new Regex(@"^[A-z]+$", RegexOptions.CultureInvariant);
            if (false == regexActorType.Match(this.ActorType).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ActorType, must match a pattern of " + regexActorType, new [] { "ActorType" });
            }

            // EntityType (string) maxLength
            if(this.EntityType != null && this.EntityType.Length > 50)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for EntityType, length must be less than 50.", new [] { "EntityType" });
            }


            // EntityType (string) pattern
            Regex regexEntityType = new Regex(@"^[A-z]+$", RegexOptions.CultureInvariant);
            if (false == regexEntityType.Match(this.EntityType).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for EntityType, must match a pattern of " + regexEntityType, new [] { "EntityType" });
            }

            // EntityId (string) maxLength
            if(this.EntityId != null && this.EntityId.Length > 200)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for EntityId, length must be less than 200.", new [] { "EntityId" });
            }


            // EntityId (string) pattern
            Regex regexEntityId = new Regex(@"^.+$", RegexOptions.CultureInvariant);
            if (false == regexEntityId.Match(this.EntityId).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for EntityId, must match a pattern of " + regexEntityId, new [] { "EntityId" });
            }

            // Operation (string) maxLength
            if(this.Operation != null && this.Operation.Length > 50)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Operation, length must be less than 50.", new [] { "Operation" });
            }


            // Operation (string) pattern
            Regex regexOperation = new Regex(@"^[A-z]+$", RegexOptions.CultureInvariant);
            if (false == regexOperation.Match(this.Operation).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Operation, must match a pattern of " + regexOperation, new [] { "Operation" });
            }

            // Message (string) maxLength
            if(this.Message != null && this.Message.Length > 250)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Message, length must be less than 250.", new [] { "Message" });
            }


            // Message (string) pattern
            Regex regexMessage = new Regex(@"^.+$", RegexOptions.CultureInvariant);
            if (false == regexMessage.Match(this.Message).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Message, must match a pattern of " + regexMessage, new [] { "Message" });
            }

            // CreatedAt (DateTime?) maxLength
            if(this.CreatedAt != null && this.CreatedAt.Length > 40)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for CreatedAt, length must be less than 40.", new [] { "CreatedAt" });
            }


            yield break;
        }
    }

}
