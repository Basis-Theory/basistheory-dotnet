using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Common;
using BasisTheory.net.Common.Entities;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Reactors.Entities;
using BasisTheory.net.Reactors.Requests;

namespace BasisTheory.net.Reactors
{
    public interface IReactorClient
    {
        Reactor GetById(
            Guid reactorId,
            ReactorGetByIdRequest request = null,
            RequestOptions requestOptions = null);

        Reactor GetById(
            string reactorId,
            ReactorGetByIdRequest request = null,
            RequestOptions requestOptions = null);

        Task<Reactor> GetByIdAsync(
            Guid reactorId,
            ReactorGetByIdRequest request = null,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        Task<Reactor> GetByIdAsync(
            string reactorId,
            ReactorGetByIdRequest request = null,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        PaginatedList<Reactor> Get(ReactorGetRequest request = null, RequestOptions requestOptions = null);

        Task<PaginatedList<Reactor>> GetAsync(
            ReactorGetRequest request = null,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        Reactor Create(Reactor reactor, RequestOptions requestOptions = null);

        Task<Reactor> CreateAsync(
            Reactor reactor,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        Reactor Update(Guid reactorId, Reactor reactor, RequestOptions requestOptions = null);
        Reactor Update(string reactorId, Reactor reactor, RequestOptions requestOptions = null);

        Task<Reactor> UpdateAsync(
            Guid reactorId,
            Reactor reactor,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        Task<Reactor> UpdateAsync(
            string reactorId,
            Reactor reactor,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        void Delete(Guid reactorId, RequestOptions requestOptions = null);
        void Delete(string reactorId, RequestOptions requestOptions = null);

        Task DeleteAsync(
            Guid reactorId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        Task DeleteAsync(
            string reactorId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        ReactResponse React(string reactorId, ReactRequest request, RequestOptions requestOptions = null);

        ReactResponse React(Guid reactorId, ReactRequest request, RequestOptions requestOptions = null);

        Task<ReactResponse> ReactAsync(
            string reactorId,
            ReactRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        Task<ReactResponse> ReactAsync(
            Guid reactorId,
            ReactRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
    }

    public class ReactorClient : BaseClient, IReactorClient
    {
        protected override string BasePath => "reactors";

        public ReactorClient(
            string apiKey = null,
            HttpClient httpClient = null,
            string apiBase = DefaultBaseUrl,
            ApplicationInfo appInfo = null) :
            base(apiKey, httpClient, apiBase, appInfo)
        {
        }

        public Reactor GetById(
            Guid reactorId,
            ReactorGetByIdRequest request = null,
            RequestOptions requestOptions = null)
        {
            return GetById(reactorId.ToString(), request, requestOptions);
        }

        public Reactor GetById(
            string reactorId,
            ReactorGetByIdRequest request = null,
            RequestOptions requestOptions = null)
        {
            return Get<Reactor>($"{BasePath}/{reactorId}", request, requestOptions);
        }

        public async Task<Reactor> GetByIdAsync(
            Guid reactorId,
            ReactorGetByIdRequest request = null,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await GetByIdAsync(reactorId.ToString(), request, requestOptions, cancellationToken);
        }

        public async Task<Reactor> GetByIdAsync(
            string reactorId,
            ReactorGetByIdRequest request = null,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<Reactor>($"{BasePath}/{reactorId}", request, requestOptions, cancellationToken);
        }

        public PaginatedList<Reactor> Get(ReactorGetRequest request = null, RequestOptions requestOptions = null)
        {
            return Get<PaginatedList<Reactor>>(BasePath, request, requestOptions);
        }

        public async Task<PaginatedList<Reactor>> GetAsync(
            ReactorGetRequest request = null,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<PaginatedList<Reactor>>(BasePath, request, requestOptions, cancellationToken);
        }

        public Reactor Create(Reactor reactor, RequestOptions requestOptions = null)
        {
            return Post<Reactor>(BasePath, reactor, requestOptions);
        }

        public async Task<Reactor> CreateAsync(
            Reactor reactor,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await PostAsync<Reactor>(BasePath, reactor, requestOptions, cancellationToken);
        }

        public Reactor Update(Guid reactorId, Reactor reactor, RequestOptions requestOptions = null)
        {
            return Update(reactorId.ToString(), reactor, requestOptions);
        }

        public Reactor Update(string reactorId, Reactor reactor, RequestOptions requestOptions = null)
        {
            return Put<Reactor>($"{BasePath}/{reactorId}", reactor, requestOptions);
        }

        public async Task<Reactor> UpdateAsync(
            Guid reactorId,
            Reactor reactor,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await UpdateAsync(reactorId.ToString(), reactor, requestOptions, cancellationToken);
        }

        public async Task<Reactor> UpdateAsync(
            string reactorId,
            Reactor reactor,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await PutAsync<Reactor>($"{BasePath}/{reactorId}", reactor, requestOptions,
                cancellationToken);
        }

        public void Delete(Guid reactorId, RequestOptions requestOptions = null)
        {
            Delete(reactorId.ToString(), requestOptions);
        }

        public new void Delete(string reactorId, RequestOptions requestOptions = null)
        {
            base.Delete($"{BasePath}/{reactorId}", requestOptions);
        }

        public async Task DeleteAsync(
            Guid reactorId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            await DeleteAsync(reactorId.ToString(), requestOptions, cancellationToken);
        }

        public new async Task DeleteAsync(
            string reactorId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            await base.DeleteAsync($"{BasePath}/{reactorId}", requestOptions, cancellationToken);
        }

        public ReactResponse React(Guid reactorId, ReactRequest request, RequestOptions requestOptions = null) =>
            React(reactorId.ToString(), request, requestOptions);

        public Task<ReactResponse> ReactAsync(
            Guid reactorId,
            ReactRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default) =>
            ReactAsync(reactorId.ToString(), request, requestOptions, cancellationToken);

        public ReactResponse React(string reactorId, ReactRequest request, RequestOptions requestOptions = null) =>
            Post<ReactResponse>($"{BasePath}/{reactorId}/react", request, requestOptions);

        public Task<ReactResponse> ReactAsync(
            string reactorId,
            ReactRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default) =>
            PostAsync<ReactResponse>($"{BasePath}/{reactorId}/react", request, requestOptions, cancellationToken);
    }
}