using BasisTheory.net.Tests.Helpers;
using BasisTheory.net.Tokens;

namespace BasisTheory.net.Tests.Tokens.Helpers
{
    public class TokenFixture : BaseFixture
    {
        public readonly ITokenClient Client;

        public TokenFixture()
        {
            Client = new TokenClient(ApiKey, HttpClient);
        }
    }
}
