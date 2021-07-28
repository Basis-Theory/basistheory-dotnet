using BasisTheory.net.Tokens;

namespace BasisTheory.net.Tests.Tokens.Helpers
{
    public class TokenFixture : BaseFixture
    {
        public readonly ITokenClient Client;

        public TokenFixture()
        {
            Client = new TokenClient(apiKey: ApiKey, httpClient: HttpClient);
        }
    }
}
