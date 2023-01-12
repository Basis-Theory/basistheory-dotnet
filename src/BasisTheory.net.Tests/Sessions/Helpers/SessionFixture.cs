using BasisTheory.net.Sessions;
using BasisTheory.net.Tests.Helpers;

namespace BasisTheory.net.Tests.Sessions.Helpers
{
    public class SessionFixture : BaseFixture
    {
        public readonly ISessionClient Client;

        public SessionFixture()
        {
            Client = new SessionClient(ApiKey, HttpClient, appInfo: AppInfo);
        }
    }
}