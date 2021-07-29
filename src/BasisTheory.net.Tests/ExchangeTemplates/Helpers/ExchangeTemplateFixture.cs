using BasisTheory.net.ExchangeTemplates;
using BasisTheory.net.Tests.Helpers;

namespace BasisTheory.net.Tests.ExchangeTemplates.Helpers
{
    public class ExchangeTemplateFixture : BaseFixture
    {
        public readonly IExchangeTemplateClient Client;

        public ExchangeTemplateFixture()
        {
            Client = new ExchangeTemplateClient(apiKey: ApiKey, httpClient: HttpClient);
        }
    }
}
