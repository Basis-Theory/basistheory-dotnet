using BasisTheory.net.Exchanges;
using BasisTheory.net.Tests.Helpers;

namespace BasisTheory.net.Tests.Exchanges.Helpers
{
    public class ExchangeFixture : BaseFixture
    {
        public readonly IExchangeClient Client;

        public ExchangeFixture()
        {
            Client = new ExchangeClient(apiKey: ApiKey, httpClient: HttpClient);
        }
    }
}
