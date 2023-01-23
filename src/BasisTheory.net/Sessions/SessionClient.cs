using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Common;
using BasisTheory.net.Common.Entities;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.Sessions.Responses;
using BasisTheory.net.Sessions.Requests;
using BasisTheory.net.Tokens.Entities;

namespace BasisTheory.net.Sessions
{
    public interface ISessionClient
    {
        CreateSessionResponse Create(RequestOptions requestOptions = null);

        Task<CreateSessionResponse> CreateAsync(
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
        
        void Authorize(AuthorizeSessionRequest authorizeSessionRequest, RequestOptions requestOptions = null);

        Task AuthorizeAsync(
            AuthorizeSessionRequest authorizeSessionRequest,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
    }
    
    public class SessionClient : BaseClient, ISessionClient
    {
        protected override string BasePath => "sessions";
        
        public SessionClient(
            string apiKey = null,
            HttpClient httpClient = null,
            string apiBase = DefaultBaseUrl,
            ApplicationInfo appInfo = null) :
            base(apiKey, httpClient, apiBase, appInfo)
        {
        }
        
        public CreateSessionResponse Create(RequestOptions requestOptions = null)
        {
            return Post<CreateSessionResponse>(BasePath, null, requestOptions);
        }

        public async Task<CreateSessionResponse> CreateAsync(
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await PostAsync<CreateSessionResponse>(BasePath, null, requestOptions, cancellationToken);
        }
        
        public void Authorize(AuthorizeSessionRequest authorizeSessionRequest, RequestOptions requestOptions = null)
        {
            Post($"{BasePath}/authorize", authorizeSessionRequest, requestOptions);
        }

        public async Task AuthorizeAsync(
            AuthorizeSessionRequest authorizeSessionRequest,
            RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            await PostAsync($"{BasePath}/authorize", authorizeSessionRequest, requestOptions, cancellationToken);
        }
    }
}
