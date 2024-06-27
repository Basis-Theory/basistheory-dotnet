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
    /// Reactor
    /// </summary>
    [DataContract]
    public partial class Reactor :  IEquatable<Reactor>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Reactor" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="tenantId">tenantId.</param>
        /// <param name="name">name.</param>
        /// <param name="formula">formula.</param>
        /// <param name="code">code.</param>
        /// <param name="application">application.</param>
        /// <param name="createdBy">createdBy.</param>
        /// <param name="createdAt">createdAt.</param>
        /// <param name="modifiedBy">modifiedBy.</param>
        /// <param name="modifiedAt">modifiedAt.</param>
        /// <param name="configuration">configuration.</param>
        public Reactor(Guid id = default(Guid), Guid tenantId = default(Guid), string name = default(string), ReactorFormula formula = default(ReactorFormula), string code = default(string), Application application = default(Application), Guid? createdBy = default(Guid?), DateTime? createdAt = default(DateTime?), Guid? modifiedBy = default(Guid?), DateTime? modifiedAt = default(DateTime?), Dictionary<string, string> configuration = default(Dictionary<string, string>))
        {
            this.Name = name;
            this.Code = code;
            this.CreatedBy = createdBy;
            this.CreatedAt = createdAt;
            this.ModifiedBy = modifiedBy;
            this.ModifiedAt = modifiedAt;
            this._Configuration = configuration;
            this.Id = id;
            this.TenantId = tenantId;
            this.Name = name;
            this.Formula = formula;
            this.Code = code;
            this.Application = application;
            this.CreatedBy = createdBy;
            this.CreatedAt = createdAt;
            this.ModifiedBy = modifiedBy;
            this.ModifiedAt = modifiedAt;
            this._Configuration = configuration;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or Sets TenantId
        /// </summary>
        [DataMember(Name="tenant_id", EmitDefaultValue=false)]
        public Guid TenantId { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Formula
        /// </summary>
        [DataMember(Name="formula", EmitDefaultValue=false)]
        [Obsolete]
        public ReactorFormula Formula { get; set; }

        /// <summary>
        /// Gets or Sets Code
        /// </summary>
        [DataMember(Name="code", EmitDefaultValue=true)]
        public string Code { get; set; }

        /// <summary>
        /// Gets or Sets Application
        /// </summary>
        [DataMember(Name="application", EmitDefaultValue=false)]
        public Application Application { get; set; }

        /// <summary>
        /// Gets or Sets CreatedBy
        /// </summary>
        [DataMember(Name="created_by", EmitDefaultValue=true)]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        [DataMember(Name="created_at", EmitDefaultValue=true)]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets ModifiedBy
        /// </summary>
        [DataMember(Name="modified_by", EmitDefaultValue=true)]
        public Guid? ModifiedBy { get; set; }

        /// <summary>
        /// Gets or Sets ModifiedAt
        /// </summary>
        [DataMember(Name="modified_at", EmitDefaultValue=true)]
        public DateTime? ModifiedAt { get; set; }

        /// <summary>
        /// Gets or Sets _Configuration
        /// </summary>
        [DataMember(Name="configuration", EmitDefaultValue=true)]
        public Dictionary<string, string> _Configuration { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Reactor {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  TenantId: ").Append(TenantId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Formula: ").Append(Formula).Append("\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  Application: ").Append(Application).Append("\n");
            sb.Append("  CreatedBy: ").Append(CreatedBy).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  ModifiedBy: ").Append(ModifiedBy).Append("\n");
            sb.Append("  ModifiedAt: ").Append(ModifiedAt).Append("\n");
            sb.Append("  _Configuration: ").Append(_Configuration).Append("\n");
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
            return this.Equals(input as Reactor);
        }

        /// <summary>
        /// Returns true if Reactor instances are equal
        /// </summary>
        /// <param name="input">Instance of Reactor to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Reactor input)
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
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Formula == input.Formula ||
                    (this.Formula != null &&
                    this.Formula.Equals(input.Formula))
                ) && 
                (
                    this.Code == input.Code ||
                    (this.Code != null &&
                    this.Code.Equals(input.Code))
                ) && 
                (
                    this.Application == input.Application ||
                    (this.Application != null &&
                    this.Application.Equals(input.Application))
                ) && 
                (
                    this.CreatedBy == input.CreatedBy ||
                    (this.CreatedBy != null &&
                    this.CreatedBy.Equals(input.CreatedBy))
                ) && 
                (
                    this.CreatedAt == input.CreatedAt ||
                    (this.CreatedAt != null &&
                    this.CreatedAt.Equals(input.CreatedAt))
                ) && 
                (
                    this.ModifiedBy == input.ModifiedBy ||
                    (this.ModifiedBy != null &&
                    this.ModifiedBy.Equals(input.ModifiedBy))
                ) && 
                (
                    this.ModifiedAt == input.ModifiedAt ||
                    (this.ModifiedAt != null &&
                    this.ModifiedAt.Equals(input.ModifiedAt))
                ) && 
                (
                    this._Configuration == input._Configuration ||
                    this._Configuration != null &&
                    input._Configuration != null &&
                    this._Configuration.SequenceEqual(input._Configuration)
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Formula != null)
                    hashCode = hashCode * 59 + this.Formula.GetHashCode();
                if (this.Code != null)
                    hashCode = hashCode * 59 + this.Code.GetHashCode();
                if (this.Application != null)
                    hashCode = hashCode * 59 + this.Application.GetHashCode();
                if (this.CreatedBy != null)
                    hashCode = hashCode * 59 + this.CreatedBy.GetHashCode();
                if (this.CreatedAt != null)
                    hashCode = hashCode * 59 + this.CreatedAt.GetHashCode();
                if (this.ModifiedBy != null)
                    hashCode = hashCode * 59 + this.ModifiedBy.GetHashCode();
                if (this.ModifiedAt != null)
                    hashCode = hashCode * 59 + this.ModifiedAt.GetHashCode();
                if (this._Configuration != null)
                    hashCode = hashCode * 59 + this._Configuration.GetHashCode();
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
            // Id (Guid) maxLength
            if(this.Id != null && this.Id.ToString().Length > 36)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Id, length must be less than 36.", new [] { "Id" });
            }


            // Id (Guid) pattern
            Regex regexId = new Regex(@"^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$", RegexOptions.CultureInvariant);
            if (false == regexId.Match(this.Id.ToString()).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Id, must match a pattern of " + regexId, new [] { "Id" });
            }

            // TenantId (Guid) maxLength
            if(this.TenantId != null && this.TenantId.ToString().Length > 36)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for TenantId, length must be less than 36.", new [] { "TenantId" });
            }


            // TenantId (Guid) pattern
            Regex regexTenantId = new Regex(@"^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$", RegexOptions.CultureInvariant);
            if (false == regexTenantId.Match(this.TenantId.ToString()).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for TenantId, must match a pattern of " + regexTenantId, new [] { "TenantId" });
            }

            // Name (string) maxLength
            if(this.Name != null && this.Name.ToString().Length > 200)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Name, length must be less than 200.", new [] { "Name" });
            }


            // Name (string) pattern
            Regex regexName = new Regex(@"^.+$", RegexOptions.CultureInvariant);
            if (false == regexName.Match(this.Name.ToString()).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Name, must match a pattern of " + regexName, new [] { "Name" });
            }

            // CreatedBy (Guid?) maxLength
            if(this.CreatedBy != null && this.CreatedBy.ToString().Length > 36)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for CreatedBy, length must be less than 36.", new [] { "CreatedBy" });
            }


            // CreatedBy (Guid?) pattern
            Regex regexCreatedBy = new Regex(@"^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$", RegexOptions.CultureInvariant);
            if (false == regexCreatedBy.Match(this.CreatedBy.ToString()).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for CreatedBy, must match a pattern of " + regexCreatedBy, new [] { "CreatedBy" });
            }

            // CreatedAt (DateTime?) maxLength
            if(this.CreatedAt != null && this.CreatedAt.ToString().Length > 40)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for CreatedAt, length must be less than 40.", new [] { "CreatedAt" });
            }


            // ModifiedBy (Guid?) maxLength
            if(this.ModifiedBy != null && this.ModifiedBy.ToString().Length > 36)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ModifiedBy, length must be less than 36.", new [] { "ModifiedBy" });
            }


            // ModifiedBy (Guid?) pattern
            Regex regexModifiedBy = new Regex(@"^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$", RegexOptions.CultureInvariant);
            if (false == regexModifiedBy.Match(this.ModifiedBy.ToString()).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ModifiedBy, must match a pattern of " + regexModifiedBy, new [] { "ModifiedBy" });
            }

            // ModifiedAt (DateTime?) maxLength
            if(this.ModifiedAt != null && this.ModifiedAt.ToString().Length > 40)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ModifiedAt, length must be less than 40.", new [] { "ModifiedAt" });
            }


            yield break;
        }
    }

}