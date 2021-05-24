using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Common;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Tokens.Entities;
using BasisTheory.net.Tokens.Requests;

namespace BasisTheory.net.Tokens
{
    public interface ITokenClient
    {
        Token GetById(Guid tokenId,
            TokenGetByIdRequest request = null,
            RequestOptions requestOptions = null);

        Task<Token> GetByIdAsync(Guid tokenId,
            TokenGetByIdRequest request = null,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        PaginatedList<Token> Get(TokenGetRequest request = null,
            RequestOptions requestOptions = null);

        Task<PaginatedList<Token>> GetAsync(TokenGetRequest request = null,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        Token Create(TokenCreateRequest request,
            RequestOptions requestOptions = null);

        Task<Token> CreateAsync(TokenCreateRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        void Delete(Guid tokenId,
            RequestOptions requestOptions = null);

        Task DeleteAsync(Guid tokenId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
    }

    public class TokenClient : BaseClient, ITokenClient
    {
        protected override string BasePath => "tokens";

        public TokenClient(string apiKey = null,
            HttpClient httpClient = null,
            string apiBase = DefaultBaseUrl) :
            base(apiKey, httpClient, apiBase)
        {
        }

        public Token GetById(Guid tokenId,
            TokenGetByIdRequest request = null,
            RequestOptions requestOptions = null)
        {
            return Get<Token>($"{BasePath}/{tokenId}", request, requestOptions);
        }

        public async Task<Token> GetByIdAsync(Guid tokenId,
            TokenGetByIdRequest request = null,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<Token>($"{BasePath}/{tokenId}", request, requestOptions, cancellationToken);
        }

        public PaginatedList<Token> Get(TokenGetRequest request = null,
            RequestOptions requestOptions = null)
        {
            return Get<PaginatedList<Token>>(BasePath, request, requestOptions);
        }

        public async Task<PaginatedList<Token>> GetAsync(TokenGetRequest request = null,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<PaginatedList<Token>>(BasePath, request, requestOptions, cancellationToken);
        }

        public Token Create(TokenCreateRequest request,
            RequestOptions requestOptions = null)
        {
            return Post<Token>(BasePath, request, requestOptions);
        }

        public async Task<Token> CreateAsync(TokenCreateRequest request,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await PostAsync<Token>(BasePath, request, requestOptions, cancellationToken);
        }

        public void Delete(Guid tokenId,
            RequestOptions requestOptions = null)
        {
            Delete($"{BasePath}/{tokenId}", requestOptions);
        }

        public async Task DeleteAsync(Guid tokenId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            await DeleteAsync($"{BasePath}/{tokenId}", requestOptions, cancellationToken);
        }
    }
}
