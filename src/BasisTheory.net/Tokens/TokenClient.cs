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
        Token GetById(Guid tokenId, TokenGetByIdRequest request = null, RequestOptions requestOptions = null);

        Task<Token> GetByIdAsync(Guid tokenId, TokenGetByIdRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        PaginatedList<Token> Get(TokenGetRequest request = null, RequestOptions requestOptions = null);

        Task<PaginatedList<Token>> GetAsync(TokenGetRequest request = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        PaginatedList<Token> GetChildren(Guid parentTokenId, TokenGetRequest request = null,
            RequestOptions requestOptions = null);

        Task<PaginatedList<Token>> GetChildrenAsync(Guid parentTokenId, TokenGetRequest request = null,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        Token Create(Token token, RequestOptions requestOptions = null);

        Task<Token> CreateAsync(Token token, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        Token Create(object data, object metadata = null, RequestOptions requestOptions = null);

        Task<Token> CreateAsync(object data, object metadata = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        Token CreateChild(Guid parentTokenId, Token child, RequestOptions requestOptions = null);

        Task<Token> CreateChildAsync(Guid parentTokenId, Token child,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        void Delete(Guid tokenId, RequestOptions requestOptions = null);

        Task DeleteAsync(Guid tokenId, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);

        void CreateAssociation(Guid parentTokenId, Guid childTokenId, RequestOptions requestOptions = null);

        Task CreateAssociationAsync(Guid parentTokenId, Guid childTokenId,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        void DeleteAssociation(Guid parentTokenId, Guid childTokenId, RequestOptions requestOptions = null);

        Task DeleteAssociationAsync(Guid parentTokenId, Guid childTokenId,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
    }

    public class TokenClient : BaseClient, ITokenClient
    {
        protected override string BasePath => "tokens";

        public TokenClient(string apiKey = null, HttpClient httpClient = null, string apiBase = DefaultBaseUrl) :
            base(apiKey, httpClient, apiBase)
        {
        }

        public Token GetById(Guid tokenId, TokenGetByIdRequest request = null, RequestOptions requestOptions = null)
        {
            return Get<Token>($"{BasePath}/{tokenId}", request, requestOptions);
        }

        public async Task<Token> GetByIdAsync(Guid tokenId, TokenGetByIdRequest request = null,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await GetAsync<Token>($"{BasePath}/{tokenId}", request, requestOptions, cancellationToken);
        }

        public PaginatedList<Token> Get(TokenGetRequest request = null, RequestOptions requestOptions = null)
        {
            return Get<PaginatedList<Token>>(BasePath, request, requestOptions);
        }

        public async Task<PaginatedList<Token>> GetAsync(TokenGetRequest request = null,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await GetAsync<PaginatedList<Token>>(BasePath, request, requestOptions, cancellationToken);
        }

        public PaginatedList<Token> GetChildren(Guid parentTokenId, TokenGetRequest request = null,
            RequestOptions requestOptions = null)
        {
            return Get<PaginatedList<Token>>($"{BasePath}/{parentTokenId}/children", request, requestOptions);
        }

        public async Task<PaginatedList<Token>> GetChildrenAsync(Guid parentTokenId, TokenGetRequest request = null,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await GetAsync<PaginatedList<Token>>($"{BasePath}/{parentTokenId}/children", request, requestOptions,
                cancellationToken);
        }

        public Token Create(Token token, RequestOptions requestOptions = null)
        {
            return Post<Token>(BasePath, token, requestOptions);
        }

        public async Task<Token> CreateAsync(Token token, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await PostAsync<Token>(BasePath, token, requestOptions, cancellationToken);
        }

        public Token Create(object data, object metadata = null, RequestOptions requestOptions = null)
        {
            var token = new Token
            {
                Data = data,
                Metadata = metadata
            };

            return Post<Token>(BasePath, token, requestOptions);
        }

        public async Task<Token> CreateAsync(object data, object metadata = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            var token = new Token
            {
                Data = data,
                Metadata = metadata
            };

            return await PostAsync<Token>(BasePath, token, requestOptions, cancellationToken);
        }

        public Token CreateChild(Guid parentTokenId, Token child, RequestOptions requestOptions = null)
        {
            return Post<Token>($"{BasePath}/{parentTokenId}/children", child, requestOptions);
        }

        public async Task<Token> CreateChildAsync(Guid parentTokenId, Token child,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await PostAsync<Token>($"{BasePath}/{parentTokenId}/children", child, requestOptions,
                cancellationToken);
        }

        public void Delete(Guid tokenId, RequestOptions requestOptions = null)
        {
            Delete($"{BasePath}/{tokenId}", requestOptions);
        }

        public async Task DeleteAsync(Guid tokenId, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            await DeleteAsync($"{BasePath}/{tokenId}", requestOptions, cancellationToken);
        }

        public void CreateAssociation(Guid parentTokenId, Guid childTokenId, RequestOptions requestOptions = null)
        {
            Post($"{BasePath}/{parentTokenId}/children/{childTokenId}", null, requestOptions);
        }

        public async Task CreateAssociationAsync(Guid parentTokenId, Guid childTokenId,
            RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            await PostAsync($"{BasePath}/{parentTokenId}/children/{childTokenId}", null, requestOptions,
                cancellationToken);
        }

        public void DeleteAssociation(Guid parentTokenId, Guid childTokenId, RequestOptions requestOptions = null)
        {
            Delete($"{BasePath}/{parentTokenId}/children/{childTokenId}", requestOptions);
        }

        public async Task DeleteAssociationAsync(Guid parentTokenId, Guid childTokenId, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            await DeleteAsync($"{BasePath}/{parentTokenId}/children/{childTokenId}", requestOptions, cancellationToken);
        }
    }
}
