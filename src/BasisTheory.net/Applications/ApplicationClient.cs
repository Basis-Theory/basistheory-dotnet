using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Applications.Entities;
using BasisTheory.net.Applications.Requests;
using BasisTheory.net.Common;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Common.Responses;

namespace BasisTheory.net.Applications
{
    public interface IApplicationClient
    {
        Application GetById(Guid applicationId, ApplicationGetByIdRequest request = null,
            RequestOptions requestOptions = null);

        Task<Application> GetByIdAsync(Guid applicationId, ApplicationGetByIdRequest request = null,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        Application GetByKey(ApplicationGetByIdRequest request = null,
            RequestOptions requestOptions = null);

        Task<Application> GetByKeyAsync(ApplicationGetByIdRequest request = null,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        PaginatedList<Application> Get(ApplicationGetRequest request = null, RequestOptions requestOptions = null);

        Task<PaginatedList<Application>> GetAsync(ApplicationGetRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        Application Create(Application application, RequestOptions requestOptions = null);

        Task<Application> CreateAsync(Application application, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        Application Update(Guid applicationId, Application application, RequestOptions requestOptions = null);

        Task<Application> UpdateAsync(Guid applicationId, Application application, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        Application RegenerateKey(Guid applicationId, RequestOptions requestOptions = null);

        Task<Application> RegenerateKeyAsync(Guid applicationId, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        void Delete(Guid applicationId, RequestOptions requestOptions = null);

        Task DeleteAsync(Guid applicationId, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
    }

    public class ApplicationClient : BaseClient, IApplicationClient
    {
        protected override string BasePath => "applications";

        public ApplicationClient(string apiKey = null, HttpClient httpClient = null, string apiBase = DefaultBaseUrl) :
            base(apiKey, httpClient, apiBase)
        {
        }

        public Application GetById(Guid applicationId, ApplicationGetByIdRequest request = null, RequestOptions requestOptions = null)
        {
            return Get<Application>($"{BasePath}/{applicationId}", request, requestOptions);
        }

        public async Task<Application> GetByIdAsync(Guid applicationId, ApplicationGetByIdRequest request = null,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await GetAsync<Application>($"{BasePath}/{applicationId}", request, requestOptions, cancellationToken);
        }

        public Application GetByKey(ApplicationGetByIdRequest request = null, RequestOptions requestOptions = null)
        {
            return Get<Application>($"{BasePath}/key", request, requestOptions);
        }

        public async Task<Application> GetByKeyAsync(ApplicationGetByIdRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<Application>($"{BasePath}/key", request, requestOptions, cancellationToken);
        }

        public PaginatedList<Application> Get(ApplicationGetRequest request = null, RequestOptions requestOptions = null)
        {
            return Get<PaginatedList<Application>>(BasePath, request, requestOptions);
        }

        public async Task<PaginatedList<Application>> GetAsync(ApplicationGetRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<PaginatedList<Application>>(BasePath, request, requestOptions, cancellationToken);
        }

        public Application Create(Application application, RequestOptions requestOptions = null)
        {
            return Post<Application>(BasePath, application, requestOptions);
        }

        public async Task<Application> CreateAsync(Application application, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await PostAsync<Application>(BasePath, application, requestOptions, cancellationToken);
        }

        public Application Update(Guid applicationId, Application application, RequestOptions requestOptions = null)
        {
            return Put<Application>($"BasePath/{applicationId}", application, requestOptions);
        }

        public async Task<Application> UpdateAsync(Guid applicationId, Application application, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await PutAsync<Application>($"BasePath/{applicationId}", application, requestOptions, cancellationToken);
        }

        public Application RegenerateKey(Guid applicationId, RequestOptions requestOptions = null)
        {
            return Post<Application>($"{BasePath}/regenerate", null, requestOptions);
        }

        public async Task<Application> RegenerateKeyAsync(Guid applicationId, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await PostAsync<Application>($"{BasePath}/regenerate", null, requestOptions, cancellationToken);
        }

        public void Delete(Guid applicationId, RequestOptions requestOptions = null)
        {
            Delete($"{BasePath}/{applicationId}", requestOptions);
        }

        public async Task DeleteAsync(Guid applicationId, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            await DeleteAsync($"{BasePath}/{applicationId}", requestOptions, cancellationToken);
        }
    }
}
