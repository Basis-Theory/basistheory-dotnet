
using BasisTheory.net.ApplicationKeys;
using BasisTheory.net.Tests.Helpers;

namespace BasisTheory.net.Tests.Applications.Helpers
{
    public class ApplicationKeysFixture : BaseFixture
    {
        public readonly IApplicationKeysClient Client;

        public ApplicationKeysFixture()
        {
            Client = new ApplicationKeysClient(ApiKey, HttpClient, appInfo: AppInfo);
        }
    }
}