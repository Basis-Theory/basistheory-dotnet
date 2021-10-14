using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Atomic.Banks.Entities;
using BasisTheory.net.Atomic.Banks.Requests;
using BasisTheory.net.Common;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Reactors.Requests;
using BasisTheory.net.Tokens.Entities;

namespace BasisTheory.net.Atomic.Banks
{
    public interface IAtomicBankClient
    {
        AtomicBank GetById(Guid atomicBankId, BankGetByIdRequest request = null, RequestOptions requestOptions = null);
        AtomicBank GetById(string atomicBankId, BankGetByIdRequest request = null, RequestOptions requestOptions = null);
        Task<AtomicBank> GetByIdAsync(Guid atomicBankId, BankGetByIdRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
        Task<AtomicBank> GetByIdAsync(string atomicBankId, BankGetByIdRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        PaginatedList<AtomicBank> Get(BankGetRequest request = null, RequestOptions requestOptions = null);
        Task<PaginatedList<AtomicBank>> GetAsync(BankGetRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        AtomicBank Create(AtomicBank atomicBank, RequestOptions requestOptions = null);
        Task<AtomicBank> CreateAsync(AtomicBank atomicBank, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        void Delete(Guid atomicBankId, RequestOptions requestOptions = null);
        void Delete(string atomicBankId, RequestOptions requestOptions = null);
        Task DeleteAsync(Guid atomicBankId, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
        Task DeleteAsync(string atomicBankId, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        Token React(Guid atomicBankId, ReactRequest request, RequestOptions requestOptions = null);
        Token React(string atomicBankId, ReactRequest request, RequestOptions requestOptions = null);
        Task<Token> ReactAsync(Guid atomicBankId, ReactRequest request, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
        Task<Token> ReactAsync(string atomicBankId, ReactRequest request, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        Token GetReactionById(Guid atomicBankId, Guid reactionTokenId, ReactionGetByIdRequest request,
            RequestOptions requestOptions = null);
        Token GetReactionById(string atomicBankId, string reactionTokenId, ReactionGetByIdRequest request,
            RequestOptions requestOptions = null);
        Task<Token> GetReactionByIdAsync(Guid atomicBankId, Guid reactionTokenId, ReactionGetByIdRequest request,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
        Task<Token> GetReactionByIdAsync(string atomicBankId, string reactionTokenId, ReactionGetByIdRequest request,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
    }

    public class AtomicBankClient : BaseClient, IAtomicBankClient
    {
        protected override string BasePath => "atomic/banks";

        public AtomicBankClient(string apiKey = null, HttpClient httpClient = null, string apiBase = DefaultBaseUrl) :
            base(apiKey, httpClient, apiBase)
        {
        }

        public AtomicBank GetById(Guid atomicBankId, BankGetByIdRequest request = null, RequestOptions requestOptions = null)
        {
            return GetById(atomicBankId.ToString(), request, requestOptions);
        }

        public AtomicBank GetById(string atomicBankId, BankGetByIdRequest request = null, RequestOptions requestOptions = null)
        {
            var decryptPath = request?.Decrypt ?? false ? "/decrypt" : string.Empty;

            return Get<AtomicBank>($"{BasePath}/{atomicBankId}{decryptPath}", request, requestOptions);
        }

        public async Task<AtomicBank> GetByIdAsync(Guid atomicBankId, BankGetByIdRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await GetByIdAsync(atomicBankId.ToString(), request, requestOptions, cancellationToken);
        }

        public async Task<AtomicBank> GetByIdAsync(string atomicBankId, BankGetByIdRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            var decryptPath = request?.Decrypt ?? false ? "/decrypt" : string.Empty;

            return await GetAsync<AtomicBank>($"{BasePath}/{atomicBankId}{decryptPath}", request, requestOptions, cancellationToken);
        }

        public PaginatedList<AtomicBank> Get(BankGetRequest request = null, RequestOptions requestOptions = null)
        {
            return Get<PaginatedList<AtomicBank>>(BasePath, request, requestOptions);
        }

        public async Task<PaginatedList<AtomicBank>> GetAsync(BankGetRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<PaginatedList<AtomicBank>>(BasePath, request, requestOptions, cancellationToken);
        }

        public AtomicBank Create(AtomicBank atomicBank, RequestOptions requestOptions = null)
        {
            return Post<AtomicBank>(BasePath, atomicBank, requestOptions);
        }

        public async Task<AtomicBank> CreateAsync(AtomicBank atomicBank, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await PostAsync<AtomicBank>(BasePath, atomicBank, requestOptions, cancellationToken);
        }

        public void Delete(Guid atomicBankId, RequestOptions requestOptions = null)
        {
            Delete(atomicBankId.ToString(), requestOptions);
        }

        public new void Delete(string atomicBankId, RequestOptions requestOptions = null)
        {
            base.Delete($"{BasePath}/{atomicBankId}", requestOptions);
        }

        public async Task DeleteAsync(Guid atomicBankId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            await DeleteAsync(atomicBankId.ToString(), requestOptions, cancellationToken);
        }

        public new async Task DeleteAsync(string atomicBankId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            await base.DeleteAsync($"{BasePath}/{atomicBankId}", requestOptions, cancellationToken);
        }

        public Token React(Guid atomicBankId, ReactRequest request, RequestOptions requestOptions = null)
        {
            return React(atomicBankId.ToString(), request, requestOptions);
        }

        public Token React(string atomicBankId, ReactRequest request, RequestOptions requestOptions = null)
        {
            return Post<Token>($"{BasePath}/{atomicBankId}/react", request, requestOptions);
        }

        public async Task<Token> ReactAsync(Guid atomicBankId, ReactRequest request, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await ReactAsync(atomicBankId.ToString(), request, requestOptions, cancellationToken);
        }

        public async Task<Token> ReactAsync(string atomicBankId, ReactRequest request, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await PostAsync<Token>($"{BasePath}/{atomicBankId}/react", request, requestOptions, cancellationToken);
        }

        public Token GetReactionById(Guid atomicBankId, Guid reactionTokenId, ReactionGetByIdRequest request = null,
            RequestOptions requestOptions = null)
        {
            return GetReactionById(atomicBankId.ToString(), reactionTokenId.ToString(), request, requestOptions);
        }

        public Token GetReactionById(string atomicBankId, string reactionTokenId, ReactionGetByIdRequest request = null,
            RequestOptions requestOptions = null)
        {
            return Get<Token>($"{BasePath}/{atomicBankId}/reactions/{reactionTokenId}", request, requestOptions);
        }

        public async Task<Token> GetReactionByIdAsync(Guid atomicBankId, Guid reactionTokenId, ReactionGetByIdRequest request = null,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await GetReactionByIdAsync(atomicBankId.ToString(), reactionTokenId.ToString(), request, requestOptions, cancellationToken);
        }

        public async Task<Token> GetReactionByIdAsync(string atomicBankId, string reactionTokenId, ReactionGetByIdRequest request = null,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await GetAsync<Token>($"{BasePath}/{atomicBankId}/reactions/{reactionTokenId}", request, requestOptions,
                cancellationToken);
        }
    }
}
