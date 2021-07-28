using BasisTheory.net.Tenants;

namespace BasisTheory.net.Tests.Tenants.Helpers
{
    public class TenantFixture : BaseFixture
    {
        public readonly ITenantClient Client;

        public TenantFixture()
        {
            Client = new TenantClient(apiKey: ApiKey, httpClient: HttpClient);
        }
    }
}
