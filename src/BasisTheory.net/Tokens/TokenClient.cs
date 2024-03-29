using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Common;
using BasisTheory.net.Common.Entities;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Common.Responses;
using BasisTheory.net.Tokens.Entities;
using BasisTheory.net.Tokens.Requests;

namespace BasisTheory.net.Tokens
{
    public interface ITokenClient
    {
        Token GetById(string tokenId, TokenGetByIdRequest request = null, RequestOptions requestOptions = null);

        Task<Token> GetByIdAsync(
            string tokenId,
            TokenGetByIdRequest request = null,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        PaginatedList<Token> Get(TokenGetRequest request = null, RequestOptions requestOptions = null);

        Task<PaginatedList<Token>> GetAsync(
            TokenGetRequest request = null,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        PaginatedList<Token> Search(TokenSearchRequest request = null, RequestOptions requestOptions = null);

        Task<PaginatedList<Token>> SearchAsync(
            TokenSearchRequest request = null,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        Token Create(TokenCreateRequest token, RequestOptions requestOptions = null);

        Task<Token> CreateAsync(
            TokenCreateRequest token,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        Token Create(object data, Dictionary<string, string> metadata = null, RequestOptions requestOptions = null);

        Task<Token> CreateAsync(
            object data,
            Dictionary<string, string> metadata = null,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        Token Update(string tokenId, TokenUpdateRequest updateRequest, RequestOptions requestOptions = null);

        Task<Token> UpdateAsync(
            string tokenId,
            TokenUpdateRequest updateRequest,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
        
        void Delete(string tokenId, RequestOptions requestOptions = null);

        Task DeleteAsync(
            string tokenId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
    }

    public class TokenClient : BaseClient, ITokenClient
    {
        protected override string BasePath => "tokens";

        public TokenClient(
            string apiKey = null,
            HttpClient httpClient = null,
            string apiBase = DefaultBaseUrl,
            ApplicationInfo appInfo = null) :
            base(apiKey, httpClient, apiBase, appInfo)
        {
        }

        public Token GetById(string tokenId, TokenGetByIdRequest request = null, RequestOptions requestOptions = null)
        {
            return Get<Token>($"{BasePath}/{tokenId}", request, requestOptions);
        }

        public async Task<Token> GetByIdAsync(
            string tokenId,
            TokenGetByIdRequest request = null,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<Token>($"{BasePath}/{tokenId}", request, requestOptions, cancellationToken);
        }

        public PaginatedList<Token> Get(TokenGetRequest request = null, RequestOptions requestOptions = null)
        {
            return Get<PaginatedList<Token>>(BasePath, request, requestOptions);
        }

        public async Task<PaginatedList<Token>> GetAsync(
            TokenGetRequest request = null,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<PaginatedList<Token>>(BasePath, request, requestOptions, cancellationToken);
        }

        public PaginatedList<Token> Search(TokenSearchRequest request = null, RequestOptions requestOptions = null)
        {
            return Post<PaginatedList<Token>>($"{BasePath}/search", request, requestOptions);
        }

        public async Task<PaginatedList<Token>> SearchAsync(
            TokenSearchRequest request = null,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await PostAsync<PaginatedList<Token>>($"{BasePath}/search", request, requestOptions,
                cancellationToken);
        }

        public Token Create(TokenCreateRequest token, RequestOptions requestOptions = null)
        {
            return Post<Token>(BasePath, token, requestOptions);
        }

        public async Task<Token> CreateAsync(
            TokenCreateRequest token,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await PostAsync<Token>(BasePath, token, requestOptions, cancellationToken);
        }

        public Token Create(
            object data,
            Dictionary<string, string> metadata = null,
            RequestOptions requestOptions = null)
        {
            var token = new TokenCreateRequest
            {
                Data = data,
                Metadata = metadata
            };

            return Post<Token>(BasePath, token, requestOptions);
        }

        public async Task<Token> CreateAsync(
            object data,
            Dictionary<string, string> metadata = null,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            var token = new TokenCreateRequest
            {
                Data = data,
                Metadata = metadata
            };

            return await PostAsync<Token>(BasePath, token, requestOptions, cancellationToken);
        }

        public Token Update(string tokenId, TokenUpdateRequest updateRequest, RequestOptions requestOptions = null)
        {
            return PatchWithMerge<Token>($"{BasePath}/{tokenId}", updateRequest, requestOptions);
        }

        public async Task<Token> UpdateAsync(
            string tokenId,
            TokenUpdateRequest updateRequest,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await PatchWithMergeAsync<Token>($"{BasePath}/{tokenId}", updateRequest, requestOptions, cancellationToken);
        }

        public new void Delete(string tokenId, RequestOptions requestOptions = null)
        {
            base.Delete($"{BasePath}/{tokenId}", requestOptions);
        }

        public new async Task DeleteAsync(
            string tokenId,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            await base.DeleteAsync($"{BasePath}/{tokenId}", requestOptions, cancellationToken);
        }
    }
}