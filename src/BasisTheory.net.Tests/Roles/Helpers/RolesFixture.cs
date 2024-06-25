using BasisTheory.net.Roles;
using BasisTheory.net.Tests.Helpers;

namespace BasisTheory.net.Tests.Roles.Helpers;

public class RolesFixture : BaseFixture
{
    public readonly IRolesClient Client;

    public RolesFixture()
    {
        Client = new RolesClient(ApiKey, HttpClient, appInfo: AppInfo);
    }
}