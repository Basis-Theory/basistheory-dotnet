using BasisTheory.net.Reactors;
using BasisTheory.net.Tests.Helpers;

namespace BasisTheory.net.Tests.Reactors.Helpers
{
    public class ReactorFixture : BaseFixture
    {
        public readonly IReactorClient Client;

        public ReactorFixture()
        {
            Client = new ReactorClient(apiKey: ApiKey, httpClient: HttpClient);
        }
    }
}
