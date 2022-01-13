using BasisTheory.net.Tests.Helpers;
using BasisTheory.net.Tokenize;

namespace BasisTheory.net.Tests.Tokenize.Helpers;

public class TokenizeFixture : BaseFixture
{
    public readonly ITokenizeClient Client;

    public TokenizeFixture()
    {
        Client = new TokenizeClient(ApiKey, HttpClient, appInfo: AppInfo);
    }
}
