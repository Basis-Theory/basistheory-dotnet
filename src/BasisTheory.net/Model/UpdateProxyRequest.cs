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
    /// UpdateProxyRequest
    /// </summary>
    [DataContract(Name = "UpdateProxyRequest")]
    public partial class UpdateProxyRequest : IEquatable<UpdateProxyRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateProxyRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected UpdateProxyRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateProxyRequest" /> class.
        /// </summary>
        /// <param name="name">name (required).</param>
        /// <param name="destinationUrl">destinationUrl (required).</param>
        /// <param name="requestReactorId">requestReactorId.</param>
        /// <param name="responseReactorId">responseReactorId.</param>
        /// <param name="requestTransform">requestTransform.</param>
        /// <param name="responseTransform">responseTransform.</param>
        /// <param name="application">application.</param>
        /// <param name="configuration">configuration.</param>
        /// <param name="requireAuth">requireAuth.</param>
        public UpdateProxyRequest(string name = default(string), string destinationUrl = default(string), Guid? requestReactorId = default(Guid?), Guid? responseReactorId = default(Guid?), ProxyTransform requestTransform = default(ProxyTransform), ProxyTransform responseTransform = default(ProxyTransform), Application application = default(Application), Dictionary<string, string> configuration = default(Dictionary<string, string>), bool? requireAuth = default(bool?))
        {
            this.Name = name;
            this.DestinationUrl = destinationUrl;
            this.RequestReactorId = requestReactorId;
            this.ResponseReactorId = responseReactorId;
            this.RequestTransform = requestTransform;
            this.ResponseTransform = responseTransform;
            this.Application = application;
            this._Configuration = configuration;
            this.RequireAuth = requireAuth;
        }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets DestinationUrl
        /// </summary>
        [DataMember(Name = "destination_url", IsRequired = true, EmitDefaultValue = true)]
        public string DestinationUrl { get; set; }

        /// <summary>
        /// Gets or Sets RequestReactorId
        /// </summary>
        [DataMember(Name = "request_reactor_id", EmitDefaultValue = true)]
        public Guid? RequestReactorId { get; set; }

        /// <summary>
        /// Gets or Sets ResponseReactorId
        /// </summary>
        [DataMember(Name = "response_reactor_id", EmitDefaultValue = true)]
        public Guid? ResponseReactorId { get; set; }

        /// <summary>
        /// Gets or Sets RequestTransform
        /// </summary>
        [DataMember(Name = "request_transform", EmitDefaultValue = false)]
        public ProxyTransform RequestTransform { get; set; }

        /// <summary>
        /// Gets or Sets ResponseTransform
        /// </summary>
        [DataMember(Name = "response_transform", EmitDefaultValue = false)]
        public ProxyTransform ResponseTransform { get; set; }

        /// <summary>
        /// Gets or Sets Application
        /// </summary>
        [DataMember(Name = "application", EmitDefaultValue = false)]
        public Application Application { get; set; }

        /// <summary>
        /// Gets or Sets _Configuration
        /// </summary>
        [DataMember(Name = "configuration", EmitDefaultValue = true)]
        public Dictionary<string, string> _Configuration { get; set; }

        /// <summary>
        /// Gets or Sets RequireAuth
        /// </summary>
        [DataMember(Name = "require_auth", EmitDefaultValue = true)]
        public bool? RequireAuth { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UpdateProxyRequest {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  DestinationUrl: ").Append(DestinationUrl).Append("\n");
            sb.Append("  RequestReactorId: ").Append(RequestReactorId).Append("\n");
            sb.Append("  ResponseReactorId: ").Append(ResponseReactorId).Append("\n");
            sb.Append("  RequestTransform: ").Append(RequestTransform).Append("\n");
            sb.Append("  ResponseTransform: ").Append(ResponseTransform).Append("\n");
            sb.Append("  Application: ").Append(Application).Append("\n");
            sb.Append("  _Configuration: ").Append(_Configuration).Append("\n");
            sb.Append("  RequireAuth: ").Append(RequireAuth).Append("\n");
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
            return this.Equals(input as UpdateProxyRequest);
        }

        /// <summary>
        /// Returns true if UpdateProxyRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of UpdateProxyRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UpdateProxyRequest input)
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
                    this.DestinationUrl == input.DestinationUrl ||
                    (this.DestinationUrl != null &&
                    this.DestinationUrl.Equals(input.DestinationUrl))
                ) && 
                (
                    this.RequestReactorId == input.RequestReactorId ||
                    (this.RequestReactorId != null &&
                    this.RequestReactorId.Equals(input.RequestReactorId))
                ) && 
                (
                    this.ResponseReactorId == input.ResponseReactorId ||
                    (this.ResponseReactorId != null &&
                    this.ResponseReactorId.Equals(input.ResponseReactorId))
                ) && 
                (
                    this.RequestTransform == input.RequestTransform ||
                    (this.RequestTransform != null &&
                    this.RequestTransform.Equals(input.RequestTransform))
                ) && 
                (
                    this.ResponseTransform == input.ResponseTransform ||
                    (this.ResponseTransform != null &&
                    this.ResponseTransform.Equals(input.ResponseTransform))
                ) && 
                (
                    this.Application == input.Application ||
                    (this.Application != null &&
                    this.Application.Equals(input.Application))
                ) && 
                (
                    this._Configuration == input._Configuration ||
                    this._Configuration != null &&
                    input._Configuration != null &&
                    this._Configuration.SequenceEqual(input._Configuration)
                ) && 
                (
                    this.RequireAuth == input.RequireAuth ||
                    (this.RequireAuth != null &&
                    this.RequireAuth.Equals(input.RequireAuth))
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
                if (this.DestinationUrl != null)
                {
                    hashCode = (hashCode * 59) + this.DestinationUrl.GetHashCode();
                }
                if (this.RequestReactorId != null)
                {
                    hashCode = (hashCode * 59) + this.RequestReactorId.GetHashCode();
                }
                if (this.ResponseReactorId != null)
                {
                    hashCode = (hashCode * 59) + this.ResponseReactorId.GetHashCode();
                }
                if (this.RequestTransform != null)
                {
                    hashCode = (hashCode * 59) + this.RequestTransform.GetHashCode();
                }
                if (this.ResponseTransform != null)
                {
                    hashCode = (hashCode * 59) + this.ResponseTransform.GetHashCode();
                }
                if (this.Application != null)
                {
                    hashCode = (hashCode * 59) + this.Application.GetHashCode();
                }
                if (this._Configuration != null)
                {
                    hashCode = (hashCode * 59) + this._Configuration.GetHashCode();
                }
                if (this.RequireAuth != null)
                {
                    hashCode = (hashCode * 59) + this.RequireAuth.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
