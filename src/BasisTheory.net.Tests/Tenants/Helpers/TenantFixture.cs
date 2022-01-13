using BasisTheory.net.Tenants;
using BasisTheory.net.Tests.Helpers;

namespace BasisTheory.net.Tests.Tenants.Helpers
{
    public class TenantFixture : BaseFixture
    {
        public readonly ITenantClient Client;

        public TenantFixture()
        {
            Client = new TenantClient(ApiKey, HttpClient, appInfo: AppInfo);
        }
    }
}
