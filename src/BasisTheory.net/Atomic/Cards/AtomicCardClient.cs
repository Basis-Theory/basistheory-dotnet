using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Atomic.Cards.Entities;
using BasisTheory.net.Atomic.Cards.Requests;
using BasisTheory.net.Common;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Reactors.Requests;
using BasisTheory.net.Tokens.Entities;

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

        AtomicCard Update(AtomicCard atomicCard, RequestOptions requestOptions = null);
        Task<AtomicCard> UpdateAsync(AtomicCard atomicCard, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        void Delete(Guid atomicCardId, RequestOptions requestOptions = null);
        void Delete(string atomicCardId, RequestOptions requestOptions = null);
        Task DeleteAsync(Guid atomicCardId, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
        Task DeleteAsync(string atomicCardId, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        Token React(Guid atomicCardId, ReactRequest request, RequestOptions requestOptions = null);
        Token React(string atomicCardId, ReactRequest request, RequestOptions requestOptions = null);
        Task<Token> ReactAsync(Guid atomicCardId, ReactRequest request, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
        Task<Token> ReactAsync(string atomicCardId, ReactRequest request, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        Token GetReactionById(Guid atomicCardId, Guid reactionTokenId, ReactionGetByIdRequest request = null,
            RequestOptions requestOptions = null);
        Token GetReactionById(string atomicCardId, string reactionTokenId, ReactionGetByIdRequest request = null,
            RequestOptions requestOptions = null);
        Task<Token> GetReactionByIdAsync(Guid atomicCardId, Guid reactionTokenId, ReactionGetByIdRequest request = null,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
        Task<Token> GetReactionByIdAsync(string atomicCardId, string reactionTokenId, ReactionGetByIdRequest request = null,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
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

        public AtomicCard Update(AtomicCard atomicCard, RequestOptions requestOptions = null)
        {
            return Patch<AtomicCard>($"{BasePath}/{atomicCard.Id}", atomicCard, requestOptions);
        }

        public async Task<AtomicCard> UpdateAsync(AtomicCard atomicCard, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await PatchAsync<AtomicCard>($"{BasePath}/{atomicCard.Id}", atomicCard, requestOptions,
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

        public Token React(Guid atomicCardId, ReactRequest request, RequestOptions requestOptions = null)
        {
            return React(atomicCardId.ToString(), request, requestOptions);
        }

        public Token React(string atomicCardId, ReactRequest request, RequestOptions requestOptions = null)
        {
            return Post<Token>($"{BasePath}/{atomicCardId}/react", request, requestOptions);
        }

        public async Task<Token> ReactAsync(Guid atomicCardId, ReactRequest request, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await ReactAsync(atomicCardId.ToString(), request, requestOptions, cancellationToken);
        }

        public async Task<Token> ReactAsync(string atomicCardId, ReactRequest request, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await PostAsync<Token>($"{BasePath}/{atomicCardId}/react", request, requestOptions, cancellationToken);
        }

        public Token GetReactionById(Guid atomicCardId, Guid reactionTokenId, ReactionGetByIdRequest request = null,
            RequestOptions requestOptions = null)
        {
            return GetReactionById(atomicCardId.ToString(), reactionTokenId.ToString(), request, requestOptions);
        }

        public Token GetReactionById(string atomicCardId, string reactionTokenId, ReactionGetByIdRequest request = null,
            RequestOptions requestOptions = null)
        {
            return Get<Token>($"{BasePath}/{atomicCardId}/reactions/{reactionTokenId}", request, requestOptions);
        }

        public async Task<Token> GetReactionByIdAsync(Guid atomicCardId, Guid reactionTokenId, ReactionGetByIdRequest request = null,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await GetReactionByIdAsync(atomicCardId.ToString(), reactionTokenId.ToString(), request, requestOptions, cancellationToken);
        }

        public async Task<Token> GetReactionByIdAsync(string atomicCardId, string reactionTokenId, ReactionGetByIdRequest request = null,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await GetAsync<Token>($"{BasePath}/{atomicCardId}/reactions/{reactionTokenId}", request, requestOptions,
                cancellationToken);
        }
    }
}
