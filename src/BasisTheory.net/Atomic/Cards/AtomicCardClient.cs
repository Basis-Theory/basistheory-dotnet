using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Atomic.Cards.Entities;
using BasisTheory.net.Atomic.Cards.Requests;
using BasisTheory.net.Common;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Reactors.Entities;
using BasisTheory.net.Reactors.Requests;

namespace BasisTheory.net.Atomic.Cards
{
    public interface IAtomicCardClient
    {
        AtomicCard GetById(Guid atomicCardId, CardGetByIdRequest request = null, RequestOptions requestOptions = null);
        AtomicCard GetById(string atomicCardId, CardGetByIdRequest request = null, RequestOptions requestOptions = null);
        Task<AtomicCard> GetByIdAsync(Guid atomicCardId, CardGetByIdRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
        Task<AtomicCard> GetByIdAsync(string atomicCardId, CardGetByIdRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        PaginatedList<AtomicCard> Get(CardGetRequest request = null, RequestOptions requestOptions = null);
        Task<PaginatedList<AtomicCard>> GetAsync(CardGetRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        AtomicCard Create(AtomicCard atomicCard, RequestOptions requestOptions = null);
        Task<AtomicCard> CreateAsync(AtomicCard atomicCard, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        AtomicCard Update(Guid atomicCardId, UpdateAtomicCardRequest request, RequestOptions requestOptions = null);
        AtomicCard Update(string atomicCardId, UpdateAtomicCardRequest request, RequestOptions requestOptions = null);
        Task<AtomicCard> UpdateAsync(Guid atomicCardId, UpdateAtomicCardRequest request, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
        Task<AtomicCard> UpdateAsync(string atomicCardId, UpdateAtomicCardRequest request, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        void Delete(Guid atomicCardId, RequestOptions requestOptions = null);
        void Delete(string atomicCardId, RequestOptions requestOptions = null);
        Task DeleteAsync(Guid atomicCardId, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
        Task DeleteAsync(string atomicCardId, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        ReactResponse React(Guid atomicCardId, ReactRequest request, RequestOptions requestOptions = null);
        ReactResponse React(string atomicCardId, ReactRequest request, RequestOptions requestOptions = null);
        Task<ReactResponse> ReactAsync(Guid atomicCardId, ReactRequest request, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
        Task<ReactResponse> ReactAsync(string atomicCardId, ReactRequest request, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
    }

    public class AtomicCardClient : BaseClient, IAtomicCardClient
    {
        protected override string BasePath => "atomic/cards";

        public AtomicCardClient(string apiKey = null, HttpClient httpClient = null, string apiBase = DefaultBaseUrl) :
            base(apiKey, httpClient, apiBase)
        {
        }

        public AtomicCard GetById(Guid atomicCardId, CardGetByIdRequest request = null, RequestOptions requestOptions = null)
        {
            return GetById(atomicCardId.ToString(), request, requestOptions);
        }

        public AtomicCard GetById(string atomicCardId, CardGetByIdRequest request = null, RequestOptions requestOptions = null)
        {
            var decryptPath = request?.Decrypt ?? false ? "/decrypt" : string.Empty;

            return Get<AtomicCard>($"{BasePath}/{atomicCardId}{decryptPath}", request, requestOptions);
        }

        public async Task<AtomicCard> GetByIdAsync(Guid atomicCardId, CardGetByIdRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await GetByIdAsync(atomicCardId.ToString(), request, requestOptions, cancellationToken);
        }

        public async Task<AtomicCard> GetByIdAsync(string atomicCardId, CardGetByIdRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            var decryptPath = request?.Decrypt ?? false ? "/decrypt" : string.Empty;

            return await GetAsync<AtomicCard>($"{BasePath}/{atomicCardId}{decryptPath}", request, requestOptions, cancellationToken);
        }

        public PaginatedList<AtomicCard> Get(CardGetRequest request = null, RequestOptions requestOptions = null)
        {
            return Get<PaginatedList<AtomicCard>>(BasePath, request, requestOptions);
        }

        public async Task<PaginatedList<AtomicCard>> GetAsync(CardGetRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<PaginatedList<AtomicCard>>(BasePath, request, requestOptions, cancellationToken);
        }

        public AtomicCard Create(AtomicCard atomicCard, RequestOptions requestOptions = null)
        {
            return Post<AtomicCard>(BasePath, atomicCard, requestOptions);
        }

        public async Task<AtomicCard> CreateAsync(AtomicCard atomicCard, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await PostAsync<AtomicCard>(BasePath, atomicCard, requestOptions, cancellationToken);
        }

        public AtomicCard Update(Guid atomicCardId, UpdateAtomicCardRequest request, RequestOptions requestOptions = null)
        {
            return Update(atomicCardId.ToString(), request, requestOptions);
        }

        public AtomicCard Update(string atomicCardId, UpdateAtomicCardRequest request, RequestOptions requestOptions = null)
        {
            return Patch<AtomicCard>($"{BasePath}/{atomicCardId}", request, requestOptions);
        }

        public async Task<AtomicCard> UpdateAsync(Guid atomicCardId, UpdateAtomicCardRequest request,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await UpdateAsync(atomicCardId.ToString(), request, requestOptions, cancellationToken);
        }

        public async Task<AtomicCard> UpdateAsync(string atomicCardId, UpdateAtomicCardRequest request,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await PatchAsync<AtomicCard>($"{BasePath}/{atomicCardId}", request, requestOptions,
                cancellationToken);
        }

        public void Delete(Guid atomicCardId, RequestOptions requestOptions = null)
        {
            Delete(atomicCardId.ToString(), requestOptions);
        }

        public new void Delete(string atomicCardId, RequestOptions requestOptions = null)
        {
            base.Delete($"{BasePath}/{atomicCardId}", requestOptions);
        }

        public async Task DeleteAsync(Guid atomicCardId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            await DeleteAsync(atomicCardId.ToString(), requestOptions, cancellationToken);
        }

        public new async Task DeleteAsync(string atomicCardId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            await base.DeleteAsync($"{BasePath}/{atomicCardId}", requestOptions, cancellationToken);
        }

        public ReactResponse React(Guid atomicCardId, ReactRequest request, RequestOptions requestOptions = null)
        {
            return React(atomicCardId.ToString(), request, requestOptions);
        }

        public ReactResponse React(string atomicCardId, ReactRequest request, RequestOptions requestOptions = null)
        {
            return Post<ReactResponse>($"{BasePath}/{atomicCardId}/react", request, requestOptions);
        }

        public async Task<ReactResponse> ReactAsync(Guid atomicCardId, ReactRequest request, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await ReactAsync(atomicCardId.ToString(), request, requestOptions, cancellationToken);
        }

        public async Task<ReactResponse> ReactAsync(string atomicCardId, ReactRequest request, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await PostAsync<ReactResponse>($"{BasePath}/{atomicCardId}/react", request, requestOptions, cancellationToken);
        }
    }
}
