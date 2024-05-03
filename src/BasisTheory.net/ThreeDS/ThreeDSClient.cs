using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Common;
using BasisTheory.net.Common.Entities;
using BasisTheory.net.Common.Requests;
using BasisTheory.net.ThreeDS.Entities;
using BasisTheory.net.ThreeDS.Requests;

namespace BasisTheory.net.ThreeDS
{
    public interface IThreeDSClient
    {
        ThreeDSSession GetSessionById(string sessionId, RequestOptions requestOptions = null);
        Task<ThreeDSSession> GetSessionByIdAsync(string sessionId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        ThreeDSAuthentication AuthenticateThreeDSSession(string sessionId, AuthenticateThreeDSSessionRequest request, RequestOptions requestOptions = null);
        Task<ThreeDSAuthentication> AuthenticateThreeDSSessionAsync(string sessionId, AuthenticateThreeDSSessionRequest request, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

        ThreeDSAuthentication GetChallengeResult(string sessionId, RequestOptions requestOptions = null);
        Task<ThreeDSAuthentication> GetChallengeResultAsync(string sessionId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
    }

    public class ThreeDSClient : BaseClient, IThreeDSClient
    {
        protected override string BasePath => "3ds";

        public ThreeDSClient(string apiKey = null, HttpClient httpClient = null, string apiBase = DefaultBaseUrl,
            ApplicationInfo appInfo = null) :
            base(apiKey, httpClient, apiBase, appInfo)
        {
        }

        public ThreeDSSession GetSessionById(string sessionId, RequestOptions requestOptions = null)
        {
            return Get<ThreeDSSession>($"{BasePath}/sessions/{sessionId}", null, requestOptions);
        }

        public Task<ThreeDSSession> GetSessionByIdAsync(string sessionId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return GetAsync<ThreeDSSession>($"{BasePath}/sessions/{sessionId}", null, requestOptions, cancellationToken);
        }

        public ThreeDSAuthentication AuthenticateThreeDSSession(string sessionId, AuthenticateThreeDSSessionRequest request, RequestOptions requestOptions)
        {
            return Post<ThreeDSAuthentication>($"{BasePath}/sessions/{sessionId}/authenticate", request, requestOptions);
        }

        public Task<ThreeDSAuthentication> AuthenticateThreeDSSessionAsync(string sessionId, AuthenticateThreeDSSessionRequest request, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return PostAsync<ThreeDSAuthentication>($"{BasePath}/sessions/{sessionId}/authenticate", request, requestOptions, cancellationToken);
        }

        public ThreeDSAuthentication GetChallengeResult(string sessionId, RequestOptions requestOptions = null)
        {
            return Get<ThreeDSAuthentication>($"{BasePath}/sessions/{sessionId}/challenge-result", null, requestOptions);
        }

        public Task<ThreeDSAuthentication> GetChallengeResultAsync(string sessionId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return GetAsync<ThreeDSAuthentication>($"{BasePath}/sessions/{sessionId}/challenge-result", null, requestOptions, cancellationToken);
        }
    }
}