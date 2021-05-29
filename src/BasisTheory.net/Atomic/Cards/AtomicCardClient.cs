using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Atomic.Cards.Entities;
using BasisTheory.net.Atomic.Cards.Requests;
using BasisTheory.net.Common;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Common.Responses;

namespace BasisTheory.net.Atomic.Cards
{
    public interface IAtomicCardClient
    {
        AtomicCard GetById(Guid tokenId, CardGetByIdRequest request = null, RequestOptions requestOptions = null);

        Task<AtomicCard> GetByIdAsync(Guid tokenId, CardGetByIdRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        PaginatedList<AtomicCard> Get(CardGetRequest request = null, RequestOptions requestOptions = null);

        Task<PaginatedList<AtomicCard>> GetAsync(CardGetRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        AtomicCard Create(AtomicCard bank, RequestOptions requestOptions = null);

        Task<AtomicCard> CreateAsync(AtomicCard bank, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        void Delete(Guid tokenId, RequestOptions requestOptions = null);

        Task DeleteAsync(Guid tokenId, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
    }

    public class AtomicCardClient : BaseClient, IAtomicCardClient
    {
        protected override string BasePath => "atomic/cards";

        public AtomicCardClient(string apiKey = null, HttpClient httpClient = null, string apiBase = DefaultBaseUrl) :
            base(apiKey, httpClient, apiBase)
        {
        }

        public AtomicCard GetById(Guid tokenId, CardGetByIdRequest request = null, RequestOptions requestOptions = null)
        {
            var decryptPath = request?.DecryptCard ?? false ? "/decrypt" : string.Empty;

            return Get<AtomicCard>($"{BasePath}/{tokenId}{decryptPath}", request, requestOptions);
        }

        public async Task<AtomicCard> GetByIdAsync(Guid tokenId, CardGetByIdRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            var decryptPath = request?.DecryptCard ?? false ? "/decrypt" : string.Empty;

            return await GetAsync<AtomicCard>($"{BasePath}/{tokenId}{decryptPath}", request, requestOptions, cancellationToken);
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

        public AtomicCard Create(AtomicCard bank, RequestOptions requestOptions = null)
        {
            return Post<AtomicCard>(BasePath, bank, requestOptions);
        }

        public async Task<AtomicCard> CreateAsync(AtomicCard bank, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await PostAsync<AtomicCard>(BasePath, bank, requestOptions, cancellationToken);
        }

        public void Delete(Guid tokenId, RequestOptions requestOptions = null)
        {
            Delete($"{BasePath}/{tokenId}", requestOptions);
        }

        public async Task DeleteAsync(Guid tokenId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            await DeleteAsync($"{BasePath}/{tokenId}", requestOptions, cancellationToken);
        }
    }
}
