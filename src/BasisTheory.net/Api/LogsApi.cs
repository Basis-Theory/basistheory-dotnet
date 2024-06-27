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
    public interface ILogsApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityType"> (optional)</param>
        /// <param name="entityId"> (optional)</param>
        /// <param name="startDate"> (optional)</param>
        /// <param name="endDate"> (optional)</param>
        /// <param name="page"> (optional)</param>
        /// <param name="start"> (optional)</param>
        /// <param name="size"> (optional)</param>
        /// <returns>LogPaginatedList</returns>
        LogPaginatedList Get (string entityType = default(string), string entityId = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int? page = default(int?), string start = default(string), int? size = default(int?));

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityType"> (optional)</param>
        /// <param name="entityId"> (optional)</param>
        /// <param name="startDate"> (optional)</param>
        /// <param name="endDate"> (optional)</param>
        /// <param name="page"> (optional)</param>
        /// <param name="start"> (optional)</param>
        /// <param name="size"> (optional)</param>
        /// <returns>ApiResponse of LogPaginatedList</returns>
        ApiResponse<LogPaginatedList> GetWithHttpInfo (string entityType = default(string), string entityId = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int? page = default(int?), string start = default(string), int? size = default(int?));
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List<LogEntityType></returns>
        List<LogEntityType> GetEntityTypes ();

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List<LogEntityType></returns>
        ApiResponse<List<LogEntityType>> GetEntityTypesWithHttpInfo ();
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityType"> (optional)</param>
        /// <param name="entityId"> (optional)</param>
        /// <param name="startDate"> (optional)</param>
        /// <param name="endDate"> (optional)</param>
        /// <param name="page"> (optional)</param>
        /// <param name="start"> (optional)</param>
        /// <param name="size"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel request (optional) </param>
        /// <returns>Task of LogPaginatedList</returns>
        System.Threading.Tasks.Task<LogPaginatedList> GetAsync (string entityType = default(string), string entityId = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int? page = default(int?), string start = default(string), int? size = default(int?), CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityType"> (optional)</param>
        /// <param name="entityId"> (optional)</param>
        /// <param name="startDate"> (optional)</param>
        /// <param name="endDate"> (optional)</param>
        /// <param name="page"> (optional)</param>
        /// <param name="start"> (optional)</param>
        /// <param name="size"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel request (optional) </param>
        /// <returns>Task of ApiResponse (LogPaginatedList)</returns>
        System.Threading.Tasks.Task<ApiResponse<LogPaginatedList>> GetWithHttpInfoAsync (string entityType = default(string), string entityId = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int? page = default(int?), string start = default(string), int? size = default(int?), CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="cancellationToken">Cancellation Token to cancel request (optional) </param>
        /// <returns>Task of List<LogEntityType></returns>
        System.Threading.Tasks.Task<List<LogEntityType>> GetEntityTypesAsync (CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="cancellationToken">Cancellation Token to cancel request (optional) </param>
        /// <returns>Task of ApiResponse (List&lt;LogEntityType&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<LogEntityType>>> GetEntityTypesWithHttpInfoAsync (CancellationToken cancellationToken = default(CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class LogsApi : ILogsApi
    {
        private BasisTheory.net.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public LogsApi(String basePath)
        {
            this.Configuration = new BasisTheory.net.Client.Configuration { BasePath = basePath };

            ExceptionFactory = BasisTheory.net.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogsApi"/> class
        /// </summary>
        /// <returns></returns>
        public LogsApi()
        {
            this.Configuration = BasisTheory.net.Client.Configuration.Default;

            ExceptionFactory = BasisTheory.net.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public LogsApi(BasisTheory.net.Client.Configuration configuration = null)
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
        /// <param name="entityType"> (optional)</param>
        /// <param name="entityId"> (optional)</param>
        /// <param name="startDate"> (optional)</param>
        /// <param name="endDate"> (optional)</param>
        /// <param name="page"> (optional)</param>
        /// <param name="start"> (optional)</param>
        /// <param name="size"> (optional)</param>
        /// <returns>LogPaginatedList</returns>
        public LogPaginatedList Get (string entityType = default(string), string entityId = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int? page = default(int?), string start = default(string), int? size = default(int?))
        {
             ApiResponse<LogPaginatedList> localVarResponse = GetWithHttpInfo(entityType, entityId, startDate, endDate, page, start, size);
             return localVarResponse.Data;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityType"> (optional)</param>
        /// <param name="entityId"> (optional)</param>
        /// <param name="startDate"> (optional)</param>
        /// <param name="endDate"> (optional)</param>
        /// <param name="page"> (optional)</param>
        /// <param name="start"> (optional)</param>
        /// <param name="size"> (optional)</param>
        /// <returns>ApiResponse of LogPaginatedList</returns>
        public ApiResponse<LogPaginatedList> GetWithHttpInfo (string entityType = default(string), string entityId = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int? page = default(int?), string start = default(string), int? size = default(int?))
        {

            var localVarPath = "/logs";
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

            if (entityType != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "entity_type", entityType)); // query parameter
            if (entityId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "entity_id", entityId)); // query parameter
            if (startDate != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "start_date", startDate)); // query parameter
            if (endDate != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "end_date", endDate)); // query parameter
            if (page != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "page", page)); // query parameter
            if (start != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "start", start)); // query parameter
            if (size != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "size", size)); // query parameter

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
                Exception exception = ExceptionFactory("Get", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<LogPaginatedList>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (LogPaginatedList) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(LogPaginatedList)));
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityType"> (optional)</param>
        /// <param name="entityId"> (optional)</param>
        /// <param name="startDate"> (optional)</param>
        /// <param name="endDate"> (optional)</param>
        /// <param name="page"> (optional)</param>
        /// <param name="start"> (optional)</param>
        /// <param name="size"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel request (optional) </param>
        /// <returns>Task of LogPaginatedList</returns>
        public async System.Threading.Tasks.Task<LogPaginatedList> GetAsync (string entityType = default(string), string entityId = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int? page = default(int?), string start = default(string), int? size = default(int?), CancellationToken cancellationToken = default(CancellationToken))
        {
             ApiResponse<LogPaginatedList> localVarResponse = await GetWithHttpInfoAsync(entityType, entityId, startDate, endDate, page, start, size, cancellationToken);
             return localVarResponse.Data;

        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="entityType"> (optional)</param>
        /// <param name="entityId"> (optional)</param>
        /// <param name="startDate"> (optional)</param>
        /// <param name="endDate"> (optional)</param>
        /// <param name="page"> (optional)</param>
        /// <param name="start"> (optional)</param>
        /// <param name="size"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel request (optional) </param>
        /// <returns>Task of ApiResponse (LogPaginatedList)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<LogPaginatedList>> GetWithHttpInfoAsync (string entityType = default(string), string entityId = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int? page = default(int?), string start = default(string), int? size = default(int?), CancellationToken cancellationToken = default(CancellationToken))
        {

            var localVarPath = "/logs";
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

            if (entityType != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "entity_type", entityType)); // query parameter
            if (entityId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "entity_id", entityId)); // query parameter
            if (startDate != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "start_date", startDate)); // query parameter
            if (endDate != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "end_date", endDate)); // query parameter
            if (page != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "page", page)); // query parameter
            if (start != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "start", start)); // query parameter
            if (size != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "size", size)); // query parameter

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
                Exception exception = ExceptionFactory("Get", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<LogPaginatedList>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (LogPaginatedList) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(LogPaginatedList)));
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List<LogEntityType></returns>
        public List<LogEntityType> GetEntityTypes ()
        {
             ApiResponse<List<LogEntityType>> localVarResponse = GetEntityTypesWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List<LogEntityType></returns>
        public ApiResponse<List<LogEntityType>> GetEntityTypesWithHttpInfo ()
        {

            var localVarPath = "/logs/entity-types";
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
                Exception exception = ExceptionFactory("GetEntityTypes", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<LogEntityType>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (List<LogEntityType>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<LogEntityType>)));
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="cancellationToken">Cancellation Token to cancel request (optional) </param>
        /// <returns>Task of List<LogEntityType></returns>
        public async System.Threading.Tasks.Task<List<LogEntityType>> GetEntityTypesAsync (CancellationToken cancellationToken = default(CancellationToken))
        {
             ApiResponse<List<LogEntityType>> localVarResponse = await GetEntityTypesWithHttpInfoAsync(cancellationToken);
             return localVarResponse.Data;

        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="cancellationToken">Cancellation Token to cancel request (optional) </param>
        /// <returns>Task of ApiResponse (List&lt;LogEntityType&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<LogEntityType>>> GetEntityTypesWithHttpInfoAsync (CancellationToken cancellationToken = default(CancellationToken))
        {

            var localVarPath = "/logs/entity-types";
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
                Exception exception = ExceptionFactory("GetEntityTypes", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<LogEntityType>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (List<LogEntityType>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<LogEntityType>)));
        }

    }
}