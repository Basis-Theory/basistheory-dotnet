using BasisTheory.net.Logs;

namespace BasisTheory.net.Tests.Logs.Helpers
{
    public class LogFixture : BaseFixture
    {
        public readonly ILogClient Client;

        public LogFixture()
        {
            Client = new LogClient(apiKey: ApiKey, httpClient: HttpClient);
        }
    }
}
