/*
 * Basis Theory API
 *
 * ## Getting Started * Sign-in to [Basis Theory](https://basistheory.com) and go to [Applications](https://portal.basistheory.com/applications) * Create a Basis Theory Private Application * All permissions should be selected * Paste the API Key into the `BT-API-KEY` variable
 *
 * The version of the OpenAPI document: v1
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using BasisTheory.net.Client;
using BasisTheory.net.Client.Auth;
using BasisTheory.net.Model;

namespace BasisTheory.net.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ILogsApiSync : IApiAccessor
    {
        #region Synchronous Operations
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
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="requestOptions"></param>
        /// <returns>LogPaginatedList</returns>
        LogPaginatedList Get(string entityType = default(string), string entityId = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int? page = default(int?), string start = default(string), int? size = default(int?), int operationIndex = 0, BasisTheory.net.Client.RequestOptions requestOptions = default(BasisTheory.net.Client.RequestOptions));

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
        /// <param name="requestOptions"></param>
        /// <returns>ApiResponse of LogPaginatedList</returns>
        ApiResponse<LogPaginatedList> GetWithHttpInfo(string entityType = default(string), string entityId = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int? page = default(int?), string start = default(string), int? size = default(int?), int operationIndex = 0, BasisTheory.net.Client.RequestOptions requestOptions = default(BasisTheory.net.Client.RequestOptions));
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="requestOptions"></param>
        /// <returns>List&lt;LogEntityType&gt;</returns>
        List<LogEntityType> GetEntityTypes(int operationIndex = 0, BasisTheory.net.Client.RequestOptions requestOptions = default(BasisTheory.net.Client.RequestOptions));

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="requestOptions"></param>
        /// <returns>ApiResponse of List&lt;LogEntityType&gt;</returns>
        ApiResponse<List<LogEntityType>> GetEntityTypesWithHttpInfo(int operationIndex = 0, BasisTheory.net.Client.RequestOptions requestOptions = default(BasisTheory.net.Client.RequestOptions));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ILogsApiAsync : IApiAccessor
    {
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
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="requestOptions"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LogPaginatedList</returns>
        System.Threading.Tasks.Task<LogPaginatedList> GetAsync(string entityType = default(string), string entityId = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int? page = default(int?), string start = default(string), int? size = default(int?), int operationIndex = 0, BasisTheory.net.Client.RequestOptions requestOptions = default(BasisTheory.net.Client.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

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
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="requestOptions"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LogPaginatedList)</returns>
        System.Threading.Tasks.Task<ApiResponse<LogPaginatedList>> GetWithHttpInfoAsync(string entityType = default(string), string entityId = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int? page = default(int?), string start = default(string), int? size = default(int?), int operationIndex = 0, BasisTheory.net.Client.RequestOptions requestOptions = default(BasisTheory.net.Client.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="requestOptions"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;LogEntityType&gt;</returns>
        System.Threading.Tasks.Task<List<LogEntityType>> GetEntityTypesAsync(int operationIndex = 0, BasisTheory.net.Client.RequestOptions requestOptions = default(BasisTheory.net.Client.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="requestOptions"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;LogEntityType&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<LogEntityType>>> GetEntityTypesWithHttpInfoAsync(int operationIndex = 0, BasisTheory.net.Client.RequestOptions requestOptions = default(BasisTheory.net.Client.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ILogsApi : ILogsApiSync, ILogsApiAsync
    {

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
        public LogsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public LogsApi(string basePath)
        {
            this.Configuration = BasisTheory.net.Client.Configuration.MergeConfigurations(
                BasisTheory.net.Client.GlobalConfiguration.Instance,
                new BasisTheory.net.Client.Configuration { BasePath = basePath }
            );
            this.Client = new BasisTheory.net.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new BasisTheory.net.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = BasisTheory.net.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public LogsApi(BasisTheory.net.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = BasisTheory.net.Client.Configuration.MergeConfigurations(
                BasisTheory.net.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.Client = new BasisTheory.net.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new BasisTheory.net.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = BasisTheory.net.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public LogsApi(BasisTheory.net.Client.ISynchronousClient client, BasisTheory.net.Client.IAsynchronousClient asyncClient, BasisTheory.net.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = BasisTheory.net.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public BasisTheory.net.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public BasisTheory.net.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public BasisTheory.net.Client.IReadableConfiguration Configuration { get; set; }

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
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="requestOptions"></param>
        /// <returns>LogPaginatedList</returns>
        public LogPaginatedList Get(string entityType = default(string), string entityId = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int? page = default(int?), string start = default(string), int? size = default(int?), int operationIndex = 0, BasisTheory.net.Client.RequestOptions requestOptions = default(BasisTheory.net.Client.RequestOptions))
        {
            BasisTheory.net.Client.ApiResponse<LogPaginatedList> localVarResponse = GetWithHttpInfo(entityType, entityId, startDate, endDate, page, start, size, operationIndex, requestOptions);
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
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="requestOptions"></param>
        /// <returns>ApiResponse of LogPaginatedList</returns>
        public BasisTheory.net.Client.ApiResponse<LogPaginatedList> GetWithHttpInfo(string entityType = default(string), string entityId = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int? page = default(int?), string start = default(string), int? size = default(int?), int operationIndex = 0, BasisTheory.net.Client.RequestOptions requestOptions = default(BasisTheory.net.Client.RequestOptions))
        {
            if(requestOptions == default(BasisTheory.net.Client.RequestOptions))
            {
                requestOptions = new BasisTheory.net.Client.RequestOptions();
            }

            

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = BasisTheory.net.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                requestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = BasisTheory.net.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                requestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (entityType != null)
            {
                requestOptions.QueryParameters.Add(BasisTheory.net.Client.ClientUtils.ParameterToMultiMap("", "entity_type", entityType));
            }
            if (entityId != null)
            {
                requestOptions.QueryParameters.Add(BasisTheory.net.Client.ClientUtils.ParameterToMultiMap("", "entity_id", entityId));
            }
            if (startDate != null)
            {
                requestOptions.QueryParameters.Add(BasisTheory.net.Client.ClientUtils.ParameterToMultiMap("", "start_date", startDate));
            }
            if (endDate != null)
            {
                requestOptions.QueryParameters.Add(BasisTheory.net.Client.ClientUtils.ParameterToMultiMap("", "end_date", endDate));
            }
            if (page != null)
            {
                requestOptions.QueryParameters.Add(BasisTheory.net.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (start != null)
            {
                requestOptions.QueryParameters.Add(BasisTheory.net.Client.ClientUtils.ParameterToMultiMap("", "start", start));
            }
            if (size != null)
            {
                requestOptions.QueryParameters.Add(BasisTheory.net.Client.ClientUtils.ParameterToMultiMap("", "size", size));
            }

            requestOptions.Operation = "LogsApi.Get";
            requestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("BT-API-KEY")))
            {
                requestOptions.HeaderParameters.Add("BT-API-KEY", this.Configuration.GetApiKeyWithPrefix("BT-API-KEY"));
            }
            // authentication (oauth2_password) required
            // oauth required
            if (!requestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    requestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    requestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<LogPaginatedList>("/logs", requestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("Get", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
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
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="requestOptions"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LogPaginatedList</returns>
        public async System.Threading.Tasks.Task<LogPaginatedList> GetAsync(string entityType = default(string), string entityId = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int? page = default(int?), string start = default(string), int? size = default(int?), int operationIndex = 0, BasisTheory.net.Client.RequestOptions requestOptions = default(BasisTheory.net.Client.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            BasisTheory.net.Client.ApiResponse<LogPaginatedList> localVarResponse = await GetWithHttpInfoAsync(entityType, entityId, startDate, endDate, page, start, size, operationIndex, requestOptions, cancellationToken).ConfigureAwait(false);
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
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="requestOptions"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LogPaginatedList)</returns>
        public async System.Threading.Tasks.Task<BasisTheory.net.Client.ApiResponse<LogPaginatedList>> GetWithHttpInfoAsync(string entityType = default(string), string entityId = default(string), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int? page = default(int?), string start = default(string), int? size = default(int?), int operationIndex = 0, BasisTheory.net.Client.RequestOptions requestOptions = default(BasisTheory.net.Client.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            if(requestOptions == default(BasisTheory.net.Client.RequestOptions))
            {
                requestOptions = new BasisTheory.net.Client.RequestOptions();
            }

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = BasisTheory.net.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                requestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = BasisTheory.net.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                requestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (entityType != null)
            {
                requestOptions.QueryParameters.Add(BasisTheory.net.Client.ClientUtils.ParameterToMultiMap("", "entity_type", entityType));
            }
            if (entityId != null)
            {
                requestOptions.QueryParameters.Add(BasisTheory.net.Client.ClientUtils.ParameterToMultiMap("", "entity_id", entityId));
            }
            if (startDate != null)
            {
                requestOptions.QueryParameters.Add(BasisTheory.net.Client.ClientUtils.ParameterToMultiMap("", "start_date", startDate));
            }
            if (endDate != null)
            {
                requestOptions.QueryParameters.Add(BasisTheory.net.Client.ClientUtils.ParameterToMultiMap("", "end_date", endDate));
            }
            if (page != null)
            {
                requestOptions.QueryParameters.Add(BasisTheory.net.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (start != null)
            {
                requestOptions.QueryParameters.Add(BasisTheory.net.Client.ClientUtils.ParameterToMultiMap("", "start", start));
            }
            if (size != null)
            {
                requestOptions.QueryParameters.Add(BasisTheory.net.Client.ClientUtils.ParameterToMultiMap("", "size", size));
            }

            requestOptions.Operation = "LogsApi.Get";
            requestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("BT-API-KEY")))
            {
                requestOptions.HeaderParameters.Add("BT-API-KEY", this.Configuration.GetApiKeyWithPrefix("BT-API-KEY"));
            }
            // authentication (oauth2_password) required
            // oauth required
            if (!requestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    requestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    requestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<LogPaginatedList>("/logs", requestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("Get", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="requestOptions"></param>
        /// <returns>List&lt;LogEntityType&gt;</returns>
        public List<LogEntityType> GetEntityTypes(int operationIndex = 0, BasisTheory.net.Client.RequestOptions requestOptions = default(BasisTheory.net.Client.RequestOptions))
        {
            BasisTheory.net.Client.ApiResponse<List<LogEntityType>> localVarResponse = GetEntityTypesWithHttpInfo(operationIndex, requestOptions);
            return localVarResponse.Data;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="requestOptions"></param>
        /// <returns>ApiResponse of List&lt;LogEntityType&gt;</returns>
        public BasisTheory.net.Client.ApiResponse<List<LogEntityType>> GetEntityTypesWithHttpInfo(int operationIndex = 0, BasisTheory.net.Client.RequestOptions requestOptions = default(BasisTheory.net.Client.RequestOptions))
        {
            if(requestOptions == default(BasisTheory.net.Client.RequestOptions))
            {
                requestOptions = new BasisTheory.net.Client.RequestOptions();
            }

            

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = BasisTheory.net.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                requestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = BasisTheory.net.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                requestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }


            requestOptions.Operation = "LogsApi.GetEntityTypes";
            requestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("BT-API-KEY")))
            {
                requestOptions.HeaderParameters.Add("BT-API-KEY", this.Configuration.GetApiKeyWithPrefix("BT-API-KEY"));
            }
            // authentication (oauth2_password) required
            // oauth required
            if (!requestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    requestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    requestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<List<LogEntityType>>("/logs/entity-types", requestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetEntityTypes", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="requestOptions"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;LogEntityType&gt;</returns>
        public async System.Threading.Tasks.Task<List<LogEntityType>> GetEntityTypesAsync(int operationIndex = 0, BasisTheory.net.Client.RequestOptions requestOptions = default(BasisTheory.net.Client.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            BasisTheory.net.Client.ApiResponse<List<LogEntityType>> localVarResponse = await GetEntityTypesWithHttpInfoAsync(operationIndex, requestOptions, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="BasisTheory.net.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="requestOptions"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;LogEntityType&gt;)</returns>
        public async System.Threading.Tasks.Task<BasisTheory.net.Client.ApiResponse<List<LogEntityType>>> GetEntityTypesWithHttpInfoAsync(int operationIndex = 0, BasisTheory.net.Client.RequestOptions requestOptions = default(BasisTheory.net.Client.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            if(requestOptions == default(BasisTheory.net.Client.RequestOptions))
            {
                requestOptions = new BasisTheory.net.Client.RequestOptions();
            }

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = BasisTheory.net.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                requestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = BasisTheory.net.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                requestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }


            requestOptions.Operation = "LogsApi.GetEntityTypes";
            requestOptions.OperationIndex = operationIndex;

            // authentication (ApiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("BT-API-KEY")))
            {
                requestOptions.HeaderParameters.Add("BT-API-KEY", this.Configuration.GetApiKeyWithPrefix("BT-API-KEY"));
            }
            // authentication (oauth2_password) required
            // oauth required
            if (!requestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    requestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    requestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<List<LogEntityType>>("/logs/entity-types", requestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetEntityTypes", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
