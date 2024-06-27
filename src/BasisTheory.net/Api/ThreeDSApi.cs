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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using RestSharp;
using BasisTheory.net.Client;
using BasisTheory.net.Model;

namespace BasisTheory.net.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IThreeDSApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId"></param>
        /// <param name="authenticateThreeDSSessionRequest"> (optional)</param>
        /// <returns>ThreeDSAuthentication</returns>
        ThreeDSAuthentication ThreeDSAuthenticateSession (Guid sessionId, AuthenticateThreeDSSessionRequest authenticateThreeDSSessionRequest = default(AuthenticateThreeDSSessionRequest));

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId"></param>
        /// <param name="authenticateThreeDSSessionRequest"> (optional)</param>
        /// <returns>ApiResponse of ThreeDSAuthentication</returns>
        ApiResponse<ThreeDSAuthentication> ThreeDSAuthenticateSessionWithHttpInfo (Guid sessionId, AuthenticateThreeDSSessionRequest authenticateThreeDSSessionRequest = default(AuthenticateThreeDSSessionRequest));
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId"></param>
        /// <returns>ThreeDSAuthentication</returns>
        ThreeDSAuthentication ThreeDSGetChallengeResult (Guid sessionId);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId"></param>
        /// <returns>ApiResponse of ThreeDSAuthentication</returns>
        ApiResponse<ThreeDSAuthentication> ThreeDSGetChallengeResultWithHttpInfo (Guid sessionId);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>ThreeDSSession</returns>
        ThreeDSSession ThreeDSGetSessionById (Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>ApiResponse of ThreeDSSession</returns>
        ApiResponse<ThreeDSSession> ThreeDSGetSessionByIdWithHttpInfo (Guid id);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId"></param>
        /// <param name="authenticateThreeDSSessionRequest"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel request (optional) </param>
        /// <returns>Task of ThreeDSAuthentication</returns>
        System.Threading.Tasks.Task<ThreeDSAuthentication> ThreeDSAuthenticateSessionAsync (Guid sessionId, AuthenticateThreeDSSessionRequest authenticateThreeDSSessionRequest = default(AuthenticateThreeDSSessionRequest), CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId"></param>
        /// <param name="authenticateThreeDSSessionRequest"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel request (optional) </param>
        /// <returns>Task of ApiResponse (ThreeDSAuthentication)</returns>
        System.Threading.Tasks.Task<ApiResponse<ThreeDSAuthentication>> ThreeDSAuthenticateSessionWithHttpInfoAsync (Guid sessionId, AuthenticateThreeDSSessionRequest authenticateThreeDSSessionRequest = default(AuthenticateThreeDSSessionRequest), CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel request (optional) </param>
        /// <returns>Task of ThreeDSAuthentication</returns>
        System.Threading.Tasks.Task<ThreeDSAuthentication> ThreeDSGetChallengeResultAsync (Guid sessionId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel request (optional) </param>
        /// <returns>Task of ApiResponse (ThreeDSAuthentication)</returns>
        System.Threading.Tasks.Task<ApiResponse<ThreeDSAuthentication>> ThreeDSGetChallengeResultWithHttpInfoAsync (Guid sessionId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel request (optional) </param>
        /// <returns>Task of ThreeDSSession</returns>
        System.Threading.Tasks.Task<ThreeDSSession> ThreeDSGetSessionByIdAsync (Guid id, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel request (optional) </param>
        /// <returns>Task of ApiResponse (ThreeDSSession)</returns>
        System.Threading.Tasks.Task<ApiResponse<ThreeDSSession>> ThreeDSGetSessionByIdWithHttpInfoAsync (Guid id, CancellationToken cancellationToken = default(CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ThreeDSApi : IThreeDSApi
    {
        private BasisTheory.net.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThreeDSApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ThreeDSApi(String basePath)
        {
            this.Configuration = new BasisTheory.net.Client.Configuration { BasePath = basePath };

            ExceptionFactory = BasisTheory.net.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThreeDSApi"/> class
        /// </summary>
        /// <returns></returns>
        public ThreeDSApi()
        {
            this.Configuration = BasisTheory.net.Client.Configuration.Default;

            ExceptionFactory = BasisTheory.net.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThreeDSApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ThreeDSApi(BasisTheory.net.Client.Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = BasisTheory.net.Client.Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = BasisTheory.net.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public BasisTheory.net.Client.Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public BasisTheory.net.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<String, String> DefaultHeader()
        {
            return new ReadOnlyDictionary<string, string>(this.Configuration.DefaultHeader);
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId"></param>
        /// <param name="authenticateThreeDSSessionRequest"> (optional)</param>
        /// <returns>ThreeDSAuthentication</returns>
        public ThreeDSAuthentication ThreeDSAuthenticateSession (Guid sessionId, AuthenticateThreeDSSessionRequest authenticateThreeDSSessionRequest = default(AuthenticateThreeDSSessionRequest))
        {
             ApiResponse<ThreeDSAuthentication> localVarResponse = ThreeDSAuthenticateSessionWithHttpInfo(sessionId, authenticateThreeDSSessionRequest);
             return localVarResponse.Data;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId"></param>
        /// <param name="authenticateThreeDSSessionRequest"> (optional)</param>
        /// <returns>ApiResponse of ThreeDSAuthentication</returns>
        public ApiResponse<ThreeDSAuthentication> ThreeDSAuthenticateSessionWithHttpInfo (Guid sessionId, AuthenticateThreeDSSessionRequest authenticateThreeDSSessionRequest = default(AuthenticateThreeDSSessionRequest))
        {
            // verify the required parameter 'sessionId' is set
            if (sessionId == null)
                throw new ApiException(400, "Missing required parameter 'sessionId' when calling ThreeDSApi->ThreeDSAuthenticateSession");

            var localVarPath = "/3ds/sessions/{sessionId}/authenticate";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (sessionId != null) localVarPathParams.Add("sessionId", this.Configuration.ApiClient.ParameterToString(sessionId)); // path parameter
            if (authenticateThreeDSSessionRequest != null && authenticateThreeDSSessionRequest.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(authenticateThreeDSSessionRequest); // http body (model) parameter
            }
            else
            {
                localVarPostBody = authenticateThreeDSSessionRequest; // byte array
            }

            // authentication (ApiKey) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("BT-API-KEY")))
            {
                localVarHeaderParams["BT-API-KEY"] = this.Configuration.GetApiKeyWithPrefix("BT-API-KEY");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ThreeDSAuthenticateSession", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ThreeDSAuthentication>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (ThreeDSAuthentication) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(ThreeDSAuthentication)));
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId"></param>
        /// <param name="authenticateThreeDSSessionRequest"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel request (optional) </param>
        /// <returns>Task of ThreeDSAuthentication</returns>
        public async System.Threading.Tasks.Task<ThreeDSAuthentication> ThreeDSAuthenticateSessionAsync (Guid sessionId, AuthenticateThreeDSSessionRequest authenticateThreeDSSessionRequest = default(AuthenticateThreeDSSessionRequest), CancellationToken cancellationToken = default(CancellationToken))
        {
             ApiResponse<ThreeDSAuthentication> localVarResponse = await ThreeDSAuthenticateSessionWithHttpInfoAsync(sessionId, authenticateThreeDSSessionRequest, cancellationToken);
             return localVarResponse.Data;

        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId"></param>
        /// <param name="authenticateThreeDSSessionRequest"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel request (optional) </param>
        /// <returns>Task of ApiResponse (ThreeDSAuthentication)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<ThreeDSAuthentication>> ThreeDSAuthenticateSessionWithHttpInfoAsync (Guid sessionId, AuthenticateThreeDSSessionRequest authenticateThreeDSSessionRequest = default(AuthenticateThreeDSSessionRequest), CancellationToken cancellationToken = default(CancellationToken))
        {
            // verify the required parameter 'sessionId' is set
            if (sessionId == null)
                throw new ApiException(400, "Missing required parameter 'sessionId' when calling ThreeDSApi->ThreeDSAuthenticateSession");

            var localVarPath = "/3ds/sessions/{sessionId}/authenticate";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (sessionId != null) localVarPathParams.Add("sessionId", this.Configuration.ApiClient.ParameterToString(sessionId)); // path parameter
            if (authenticateThreeDSSessionRequest != null && authenticateThreeDSSessionRequest.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(authenticateThreeDSSessionRequest); // http body (model) parameter
            }
            else
            {
                localVarPostBody = authenticateThreeDSSessionRequest; // byte array
            }

            // authentication (ApiKey) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("BT-API-KEY")))
            {
                localVarHeaderParams["BT-API-KEY"] = this.Configuration.GetApiKeyWithPrefix("BT-API-KEY");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType, cancellationToken);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ThreeDSAuthenticateSession", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ThreeDSAuthentication>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (ThreeDSAuthentication) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(ThreeDSAuthentication)));
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId"></param>
        /// <returns>ThreeDSAuthentication</returns>
        public ThreeDSAuthentication ThreeDSGetChallengeResult (Guid sessionId)
        {
             ApiResponse<ThreeDSAuthentication> localVarResponse = ThreeDSGetChallengeResultWithHttpInfo(sessionId);
             return localVarResponse.Data;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId"></param>
        /// <returns>ApiResponse of ThreeDSAuthentication</returns>
        public ApiResponse<ThreeDSAuthentication> ThreeDSGetChallengeResultWithHttpInfo (Guid sessionId)
        {
            // verify the required parameter 'sessionId' is set
            if (sessionId == null)
                throw new ApiException(400, "Missing required parameter 'sessionId' when calling ThreeDSApi->ThreeDSGetChallengeResult");

            var localVarPath = "/3ds/sessions/{sessionId}/challenge-result";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (sessionId != null) localVarPathParams.Add("sessionId", this.Configuration.ApiClient.ParameterToString(sessionId)); // path parameter

            // authentication (ApiKey) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("BT-API-KEY")))
            {
                localVarHeaderParams["BT-API-KEY"] = this.Configuration.GetApiKeyWithPrefix("BT-API-KEY");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ThreeDSGetChallengeResult", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ThreeDSAuthentication>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (ThreeDSAuthentication) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(ThreeDSAuthentication)));
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel request (optional) </param>
        /// <returns>Task of ThreeDSAuthentication</returns>
        public async System.Threading.Tasks.Task<ThreeDSAuthentication> ThreeDSGetChallengeResultAsync (Guid sessionId, CancellationToken cancellationToken = default(CancellationToken))
        {
             ApiResponse<ThreeDSAuthentication> localVarResponse = await ThreeDSGetChallengeResultWithHttpInfoAsync(sessionId, cancellationToken);
             return localVarResponse.Data;

        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sessionId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel request (optional) </param>
        /// <returns>Task of ApiResponse (ThreeDSAuthentication)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<ThreeDSAuthentication>> ThreeDSGetChallengeResultWithHttpInfoAsync (Guid sessionId, CancellationToken cancellationToken = default(CancellationToken))
        {
            // verify the required parameter 'sessionId' is set
            if (sessionId == null)
                throw new ApiException(400, "Missing required parameter 'sessionId' when calling ThreeDSApi->ThreeDSGetChallengeResult");

            var localVarPath = "/3ds/sessions/{sessionId}/challenge-result";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (sessionId != null) localVarPathParams.Add("sessionId", this.Configuration.ApiClient.ParameterToString(sessionId)); // path parameter

            // authentication (ApiKey) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("BT-API-KEY")))
            {
                localVarHeaderParams["BT-API-KEY"] = this.Configuration.GetApiKeyWithPrefix("BT-API-KEY");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType, cancellationToken);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ThreeDSGetChallengeResult", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ThreeDSAuthentication>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (ThreeDSAuthentication) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(ThreeDSAuthentication)));
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>ThreeDSSession</returns>
        public ThreeDSSession ThreeDSGetSessionById (Guid id)
        {
             ApiResponse<ThreeDSSession> localVarResponse = ThreeDSGetSessionByIdWithHttpInfo(id);
             return localVarResponse.Data;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <returns>ApiResponse of ThreeDSSession</returns>
        public ApiResponse<ThreeDSSession> ThreeDSGetSessionByIdWithHttpInfo (Guid id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling ThreeDSApi->ThreeDSGetSessionById");

            var localVarPath = "/3ds/sessions/{id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (id != null) localVarPathParams.Add("id", this.Configuration.ApiClient.ParameterToString(id)); // path parameter

            // authentication (ApiKey) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("BT-API-KEY")))
            {
                localVarHeaderParams["BT-API-KEY"] = this.Configuration.GetApiKeyWithPrefix("BT-API-KEY");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ThreeDSGetSessionById", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ThreeDSSession>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (ThreeDSSession) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(ThreeDSSession)));
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel request (optional) </param>
        /// <returns>Task of ThreeDSSession</returns>
        public async System.Threading.Tasks.Task<ThreeDSSession> ThreeDSGetSessionByIdAsync (Guid id, CancellationToken cancellationToken = default(CancellationToken))
        {
             ApiResponse<ThreeDSSession> localVarResponse = await ThreeDSGetSessionByIdWithHttpInfoAsync(id, cancellationToken);
             return localVarResponse.Data;

        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel request (optional) </param>
        /// <returns>Task of ApiResponse (ThreeDSSession)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<ThreeDSSession>> ThreeDSGetSessionByIdWithHttpInfoAsync (Guid id, CancellationToken cancellationToken = default(CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling ThreeDSApi->ThreeDSGetSessionById");

            var localVarPath = "/3ds/sessions/{id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (id != null) localVarPathParams.Add("id", this.Configuration.ApiClient.ParameterToString(id)); // path parameter

            // authentication (ApiKey) required
            if (!String.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("BT-API-KEY")))
            {
                localVarHeaderParams["BT-API-KEY"] = this.Configuration.GetApiKeyWithPrefix("BT-API-KEY");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType, cancellationToken);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ThreeDSGetSessionById", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ThreeDSSession>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (ThreeDSSession) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(ThreeDSSession)));
        }

    }
}