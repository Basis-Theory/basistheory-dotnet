using BasisTheory.net.Proxies;
using BasisTheory.net.Tests.Helpers;

namespace BasisTheory.net.Tests.Proxies.Helpers
{
    public class ProxyFixture : BaseFixture
    {
        public readonly IProxyClient Client;

        public ProxyFixture()
        {
            Client = new ProxyClient(ApiKey, HttpClient, appInfo: AppInfo);
        }
    }
}
