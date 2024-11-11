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
    /// CreateTokenRequest
    /// </summary>
    [DataContract(Name = "CreateTokenRequest")]
    public partial class CreateTokenRequest : IEquatable<CreateTokenRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTokenRequest" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="type">type.</param>
        /// <param name="data">data.</param>
        /// <param name="privacy">privacy.</param>
        /// <param name="metadata">metadata.</param>
        /// <param name="searchIndexes">searchIndexes.</param>
        /// <param name="fingerprintExpression">fingerprintExpression.</param>
        /// <param name="mask">mask.</param>
        /// <param name="deduplicateToken">deduplicateToken.</param>
        /// <param name="expiresAt">expiresAt.</param>
        /// <param name="containers">containers.</param>
        /// <param name="tokenIntentId">tokenIntentId.</param>
        public CreateTokenRequest(string id = default(string), string type = default(string), Object data = default(Object), Privacy privacy = default(Privacy), Dictionary<string, string> metadata = default(Dictionary<string, string>), List<string> searchIndexes = default(List<string>), string fingerprintExpression = default(string), Object mask = default(Object), bool? deduplicateToken = default(bool?), string expiresAt = default(string), List<string> containers = default(List<string>), string tokenIntentId = default(string))
        {
            this.Id = id;
            this.Type = type;
            this.Data = data;
            this.Privacy = privacy;
            this.Metadata = metadata;
            this.SearchIndexes = searchIndexes;
            this.FingerprintExpression = fingerprintExpression;
            this.Mask = mask;
            this.DeduplicateToken = deduplicateToken;
            this.ExpiresAt = expiresAt;
            this.Containers = containers;
            this.TokenIntentId = tokenIntentId;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = true)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        [DataMember(Name = "data", EmitDefaultValue = true)]
        public Object Data { get; set; }

        /// <summary>
        /// Gets or Sets Privacy
        /// </summary>
        [DataMember(Name = "privacy", EmitDefaultValue = false)]
        public Privacy Privacy { get; set; }

        /// <summary>
        /// Gets or Sets Metadata
        /// </summary>
        [DataMember(Name = "metadata", EmitDefaultValue = true)]
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// Gets or Sets SearchIndexes
        /// </summary>
        [DataMember(Name = "search_indexes", EmitDefaultValue = true)]
        public List<string> SearchIndexes { get; set; }

        /// <summary>
        /// Gets or Sets FingerprintExpression
        /// </summary>
        [DataMember(Name = "fingerprint_expression", EmitDefaultValue = true)]
        public string FingerprintExpression { get; set; }

        /// <summary>
        /// Gets or Sets Mask
        /// </summary>
        [DataMember(Name = "mask", EmitDefaultValue = true)]
        public Object Mask { get; set; }

        /// <summary>
        /// Gets or Sets DeduplicateToken
        /// </summary>
        [DataMember(Name = "deduplicate_token", EmitDefaultValue = true)]
        public bool? DeduplicateToken { get; set; }

        /// <summary>
        /// Gets or Sets ExpiresAt
        /// </summary>
        [DataMember(Name = "expires_at", EmitDefaultValue = true)]
        public string ExpiresAt { get; set; }

        /// <summary>
        /// Gets or Sets Containers
        /// </summary>
        [DataMember(Name = "containers", EmitDefaultValue = true)]
        public List<string> Containers { get; set; }

        /// <summary>
        /// Gets or Sets TokenIntentId
        /// </summary>
        [DataMember(Name = "token_intent_id", EmitDefaultValue = true)]
        public string TokenIntentId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CreateTokenRequest {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  Privacy: ").Append(Privacy).Append("\n");
            sb.Append("  Metadata: ").Append(Metadata).Append("\n");
            sb.Append("  SearchIndexes: ").Append(SearchIndexes).Append("\n");
            sb.Append("  FingerprintExpression: ").Append(FingerprintExpression).Append("\n");
            sb.Append("  Mask: ").Append(Mask).Append("\n");
            sb.Append("  DeduplicateToken: ").Append(DeduplicateToken).Append("\n");
            sb.Append("  ExpiresAt: ").Append(ExpiresAt).Append("\n");
            sb.Append("  Containers: ").Append(Containers).Append("\n");
            sb.Append("  TokenIntentId: ").Append(TokenIntentId).Append("\n");
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
            return this.Equals(input as CreateTokenRequest);
        }

        /// <summary>
        /// Returns true if CreateTokenRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CreateTokenRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CreateTokenRequest input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.Data == input.Data ||
                    (this.Data != null &&
                    this.Data.Equals(input.Data))
                ) && 
                (
                    this.Privacy == input.Privacy ||
                    (this.Privacy != null &&
                    this.Privacy.Equals(input.Privacy))
                ) && 
                (
                    this.Metadata == input.Metadata ||
                    this.Metadata != null &&
                    input.Metadata != null &&
                    this.Metadata.SequenceEqual(input.Metadata)
                ) && 
                (
                    this.SearchIndexes == input.SearchIndexes ||
                    this.SearchIndexes != null &&
                    input.SearchIndexes != null &&
                    this.SearchIndexes.SequenceEqual(input.SearchIndexes)
                ) && 
                (
                    this.FingerprintExpression == input.FingerprintExpression ||
                    (this.FingerprintExpression != null &&
                    this.FingerprintExpression.Equals(input.FingerprintExpression))
                ) && 
                (
                    this.Mask == input.Mask ||
                    (this.Mask != null &&
                    this.Mask.Equals(input.Mask))
                ) && 
                (
                    this.DeduplicateToken == input.DeduplicateToken ||
                    (this.DeduplicateToken != null &&
                    this.DeduplicateToken.Equals(input.DeduplicateToken))
                ) && 
                (
                    this.ExpiresAt == input.ExpiresAt ||
                    (this.ExpiresAt != null &&
                    this.ExpiresAt.Equals(input.ExpiresAt))
                ) && 
                (
                    this.Containers == input.Containers ||
                    this.Containers != null &&
                    input.Containers != null &&
                    this.Containers.SequenceEqual(input.Containers)
                ) && 
                (
                    this.TokenIntentId == input.TokenIntentId ||
                    (this.TokenIntentId != null &&
                    this.TokenIntentId.Equals(input.TokenIntentId))
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
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                if (this.Type != null)
                {
                    hashCode = (hashCode * 59) + this.Type.GetHashCode();
                }
                if (this.Data != null)
                {
                    hashCode = (hashCode * 59) + this.Data.GetHashCode();
                }
                if (this.Privacy != null)
                {
                    hashCode = (hashCode * 59) + this.Privacy.GetHashCode();
                }
                if (this.Metadata != null)
                {
                    hashCode = (hashCode * 59) + this.Metadata.GetHashCode();
                }
                if (this.SearchIndexes != null)
                {
                    hashCode = (hashCode * 59) + this.SearchIndexes.GetHashCode();
                }
                if (this.FingerprintExpression != null)
                {
                    hashCode = (hashCode * 59) + this.FingerprintExpression.GetHashCode();
                }
                if (this.Mask != null)
                {
                    hashCode = (hashCode * 59) + this.Mask.GetHashCode();
                }
                if (this.DeduplicateToken != null)
                {
                    hashCode = (hashCode * 59) + this.DeduplicateToken.GetHashCode();
                }
                if (this.ExpiresAt != null)
                {
                    hashCode = (hashCode * 59) + this.ExpiresAt.GetHashCode();
                }
                if (this.Containers != null)
                {
                    hashCode = (hashCode * 59) + this.Containers.GetHashCode();
                }
                if (this.TokenIntentId != null)
                {
                    hashCode = (hashCode * 59) + this.TokenIntentId.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
