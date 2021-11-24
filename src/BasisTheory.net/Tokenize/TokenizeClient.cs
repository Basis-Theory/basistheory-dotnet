using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BasisTheory.net.Common;
using BasisTheory.net.Common.Requests;
using Newtonsoft.Json.Linq;

namespace BasisTheory.net.Tokenize
{
    public interface ITokenizeClient
    {
        JToken Tokenize(dynamic tokens, RequestOptions requestOptions = null);
        Task<JToken> TokenizeAsync(dynamic tokens, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default);
    }

    public class TokenizeClient : BaseClient, ITokenizeClient
    {
        protected override string BasePath => "tokenize";

        public TokenizeClient(string apiKey = null, HttpClient httpClient = null, string apiBase = DefaultBaseUrl) :
            base(apiKey, httpClient, apiBase)
        {
        }

        public JToken Tokenize(dynamic tokens, RequestOptions requestOptions = null)
        {
            return Post<JToken>(BasePath, tokens, requestOptions);
        }

        public async Task<JToken> TokenizeAsync(dynamic tokens, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await PostAsync<JToken>(BasePath, tokens, requestOptions, cancellationToken);
        }
    }
}
