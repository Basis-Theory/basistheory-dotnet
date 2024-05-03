using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.ApplicationKeys.Entities;
using BasisTheory.net.Common;
using BasisTheory.net.Common.Entities;
using BasisTheory.net.Common.Requests;

namespace BasisTheory.net.ApplicationKeys
{
    public interface IApplicationKeysClient
    {
        ApplicationKey GetById(Guid applicationId, Guid keyId, RequestOptions requestOptions = null);

        Task<ApplicationKey> GetByIdAsync(Guid applicationId, Guid keyId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
        List<ApplicationKey> Get(Guid applicationId, RequestOptions requestOptions = null);
        Task<List<ApplicationKey>> GetAsync(Guid applicationId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
        ApplicationKey Create(Guid applicationId, RequestOptions requestOptions = null);
        Task<ApplicationKey> CreateAsync(Guid applicationId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
        void Delete(Guid applicationId, Guid keyId, RequestOptions requestOptions = null);
        Task DeleteAsync(Guid applicationId, Guid keyId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
    }

    public class ApplicationKeysClient : BaseClient, IApplicationKeysClient
    {
        protected override string BasePath => "applications";

        public ApplicationKeysClient(string apiKey = null, HttpClient httpClient = null, string apiBase = DefaultBaseUrl, ApplicationInfo appInfo = null) :
            base(apiKey, httpClient, apiBase, appInfo)
        { }

        T GetEntity<T>(string path, RequestOptions requestOptions = null) =>
            Get<T>(path, null, requestOptions);

        T PostEntity<T>(string path, RequestOptions requestOptions = null) =>
            Post<T>(path, new { }, requestOptions);

        void DeleteEntity(string path, RequestOptions requestOptions = null) =>
            Delete(path, requestOptions);

        async Task<T> GetEntityAsync<T>(string path, RequestOptions requestOptions = null, CancellationToken cancellationToken = default) =>
            await GetAsync<T>(path, null, requestOptions, cancellationToken);

        async Task<T> PostEntityAsync<T>(string path, RequestOptions requestOptions = null, CancellationToken cancellationToken = default) =>
            await PostAsync<T>(path, new { }, requestOptions, cancellationToken);

        async Task DeleteEntityAsync(string path, RequestOptions requestOptions = null, CancellationToken cancellationToken = default) =>
            await DeleteAsync(path, requestOptions, cancellationToken);

        public ApplicationKey GetById(Guid applicationId, Guid keyId, RequestOptions requestOptions = null) =>
            GetById(applicationId.ToString(), keyId.ToString(), requestOptions);

        public ApplicationKey GetById(string applicationId, string keyId, RequestOptions requestOptions = null) =>
            GetEntity<ApplicationKey>($"{BasePath}/{applicationId}/keys/{keyId}", requestOptions);

        public List<ApplicationKey> Get(Guid applicationId, RequestOptions requestOptions = null) =>
            Get<List<ApplicationKey>>($"{BasePath}/{applicationId}/keys", null, requestOptions);

        public ApplicationKey Create(Guid applicationId, RequestOptions requestOptions = null) =>
            PostEntity<ApplicationKey>($"{BasePath}/{applicationId}/keys", requestOptions);

        public Task<ApplicationKey> GetByIdAsync(Guid applicationId, Guid keyId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default) =>
            GetByIdAsync(applicationId.ToString(), keyId.ToString(), requestOptions, cancellationToken);

        public Task<ApplicationKey> GetByIdAsync(string applicationId, string keyId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default) =>
            GetEntityAsync<ApplicationKey>($"{BasePath}/{applicationId}/keys/{keyId}", requestOptions, cancellationToken);

        public Task<List<ApplicationKey>> GetAsync(Guid applicationId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default) =>
            GetAsync<List<ApplicationKey>>($"{BasePath}/{applicationId}/keys", null, requestOptions, cancellationToken);

        public Task<ApplicationKey> CreateAsync(Guid applicationId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default) =>
            PostEntityAsync<ApplicationKey>($"{BasePath}/{applicationId}/keys", requestOptions, cancellationToken);

        public void Delete(Guid applicationId, Guid keyId, RequestOptions requestOptions = null) =>
            DeleteEntity($"{BasePath}/{applicationId}/keys/{keyId}", requestOptions);

        public Task DeleteAsync(Guid applicationId, Guid keyId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default) =>
            DeleteEntityAsync($"{BasePath}/{applicationId}/keys/{keyId}", requestOptions, cancellationToken);
    }
}
