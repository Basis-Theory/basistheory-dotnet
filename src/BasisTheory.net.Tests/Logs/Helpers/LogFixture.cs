using BasisTheory.net.Logs;
using BasisTheory.net.Tests.Helpers;

namespace BasisTheory.net.Tests.Logs.Helpers
{
    public class LogFixture : BaseFixture
    {
        public readonly ILogClient Client;

        public LogFixture()
        {
            Client = new LogClient(ApiKey, HttpClient, appInfo: AppInfo);
        }
    }
}
