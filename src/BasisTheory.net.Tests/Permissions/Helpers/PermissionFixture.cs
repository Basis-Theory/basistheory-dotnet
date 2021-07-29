using BasisTheory.net.Permissions;
using BasisTheory.net.Tests.Helpers;

namespace BasisTheory.net.Tests.Permissions.Helpers
{
    public class PermissionFixture : BaseFixture
    {
        public readonly IPermissionClient Client;

        public PermissionFixture()
        {
            Client = new PermissionClient(apiKey: ApiKey, httpClient: HttpClient);
        }
    }
}
